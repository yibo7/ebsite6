using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;
using System.Text.RegularExpressions;

namespace EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage
{
    public partial class PrintKDD : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "打印快递单";
            }
        }
    
        public override string Permission
        {
            get
            {
                return "79";
            }
        }

        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }
        protected int OrderCodeID
        {
            get 
            {
                if (Request.Params["id"] != null)
                {
                    return Core.Utils.StrToInt(Request.Params["id"],0);
                }
                return 0;
            }
        }
        protected string ItemContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (OrderCodeID > 0)
                {
                    ModuleCore.Entity.Buy_Orders m = ModuleCore.BLL.Buy_Orders.Instance.GetEntity(OrderCodeID);
                    if (m != null)
                    {
                        this.txtUName.Text = m.SendToUserName;
                        string adds = m.SendRegion.ToString();
                        if (adds.Contains(','))
                        {
                            string[] strArr = adds.Split(',');
                            int tmpId = 1;
                            foreach (string str in strArr)
                            {
                                if (int.Parse(str) > tmpId)
                                {
                                    tmpId = int.Parse(str);
                                }
                            }
                            adds = tmpId.ToString();
                        }

                        this.ddlAddress.Value = adds;
                        //this.ddlAddress.Value = m.RegionId.ToString();
                        this.txtAddress.Text = m.Address;
                        this.txtMobil.Text = m.CellPhone;
                        this.txtPhone.Text = m.TelPhone;
                        this.txtZipCode.Text = m.ZipCode;
                        this.txtEmail.Text = m.EmailAddress;
                        this.litSendTypeName.Text = m.ModeName;
                        //发货人信息
                        //this.litSendUName.Text=

                    }
                    List<EbSite.Entity.Express> ls = EbSite.BLL.Express.Instance.FillList();
                    if (ls != null && ls.Count > 0)
                    {
                        this.ddlTemplate.DataTextField = "Name";
                        this.ddlTemplate.DataValueField = "id";
                        this.ddlTemplate.DataSource = ls;
                        this.ddlTemplate.DataBind();
                    }
                    this.ddlTemplate.Items.Insert(0, new ListItem("-请选择-", "-1"));

                    this.ddlSendRegion.Items.Add(new ListItem("-请选择-", "-1"));
                    this.ddlSendRegion.Items.Add(new ListItem("北京", "0"));
                    this.ddlSendRegion.Items.Add(new ListItem("广州", "1"));

                    //绑定发货人信息
                    List<EbSite.Entity.Shippers> sendList = EbSite.BLL.Shippers.Instance.GetListArray("");
                    if (sendList != null && sendList.Count > 0)
                    {
                        this.ddlSendRegion.DataValueField = "id";
                        this.ddlSendRegion.DataTextField = "shippertag";
                        this.ddlSendRegion.DataSource = sendList;
                        this.ddlSendRegion.DataBind();
                        //初始化
                        EbSite.Entity.Shippers mx = sendList[0];
                        this.litSendUName.Text = mx.ShipperName;
                        this.litSendRegion.Text = mx.RegionId.ToString();
                        this.litZipCode.Text = mx.Zipcode;
                        this.litAddress.Text = mx.Address;
                        this.litMobilNum.Text = mx.CellPhone;
                        this.litPhoneNum.Text = mx.TelPhone;
                    }
                }
            }
        }


        override protected void InitModifyCtr()
        {
           
        }
        override protected void SaveModel()
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dicArray = new Dictionary<string, object>();
            string Ids=string.Concat(this.ddlAddress.hfValueParentIDs.CtrValue, ",", this.ddlAddress.Value);
            dicArray.Add("SendToUserName", string.Concat("'", this.txtUName.Text, "'"));
            dicArray.Add("SendRegion", string.Concat("'",Ids, "'"));
            dicArray.Add("RegionId",EbSite.BLL.SendArea.Instance.GetSendAreaIDByAreaIDs(Ids));
            dicArray.Add("Address", string.Concat("'",EbSite.BLL.AreaInfo.Instance.GetAddressByIdAsc(int.Parse(this.ddlAddress.Value)).Replace("中国","").Trim()," ",this.txtAddress.Text, "'"));
            dicArray.Add("CellPhone", string.Concat("'", this.txtMobil.Text, "'"));
            dicArray.Add("TelPhone", string.Concat("'", this.txtPhone.Text, "'"));
            dicArray.Add("ZipCode", string.Concat("'", this.txtZipCode.Text, "'"));
            dicArray.Add("EmailAddress", string.Concat("'", this.txtEmail.Text, "'"));
            
            if (ModuleCore.BLL.Buy_Orders.Instance.UpdateByDic(dicArray, OrderCodeID))
            {
                base.RunJs("CloseOrder(1);");
            }
            else
            {
                base.RunJs("CloseOrder(0);");
            }
        }

        protected void ddlSendRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selVal =int.Parse(this.ddlSendRegion.SelectedValue);
            List<EbSite.Entity.Shippers> sendList = EbSite.BLL.Shippers.Instance.GetListArray("");
            EbSite.Entity.Shippers m = (from i in sendList where i.id == selVal select i).ToList()[0];

            this.litSendUName.Text = m.ShipperName;
            this.litSendRegion.Text = m.RegionId.ToString();
            this.litZipCode.Text = m.Zipcode;
            this.litAddress.Text = m.Address;
            this.litMobilNum.Text = m.CellPhone;
            this.litPhoneNum.Text = m.TelPhone;
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            ShowPrint();
            this.panel1.Visible = false;
            this.panel2.Visible = true;
        }
        protected void ShowPrint()
        {
            Entity.Express mdEx = new Entity.Express();
            Entity.Shippers mdSh = new Entity.Shippers();
            int Tempid=int.Parse(this.ddlTemplate.SelectedValue);
            int SendId=int.Parse(this.ddlSendRegion.SelectedValue);
            if (Tempid == 0)
            {
                base.TipsAlert("请选择快递模板");
            }
            else
            {
                //查出模板信息
                List<Entity.Express> lsit = EbSite.BLL.Express.Instance.FillList();
                List<Entity.Express> xlist = (from i in lsit where i.id == Tempid select i).ToList();
                if (xlist.Count > 0)
                {
                    mdEx = xlist[0];
                }
            }
            if (SendId == 0)
            {
                base.TipsAlert("请选择发货人");
            }
            else
            {
                //查出出货人的信息
                List<Entity.Shippers> lsit = EbSite.BLL.Shippers.Instance.GetListArray("");
                List<Entity.Shippers> xlist = (from i in lsit where i.id == SendId select i).ToList();
                if (xlist.Count > 0)
                {
                    mdSh = xlist[0];
                }
            }

            if (!Equals(mdEx, null) && !Equals(mdSh, null))
            {
                string s = mdEx.ItemContent;
                string dataStr = Regex.Match(s, @"data\=([^&]*)").Groups[1].ToString();
                string newStr = Server.UrlDecode(Server.UrlDecode(dataStr));
                string ShouAdderss = BLL.AreaInfo.Instance.GetAddressByIdAsc(int.Parse(this.ddlAddress.hfValue.CtrValue));
                ItemContent = mdEx.ItemContent.Replace(dataStr, Server.UrlEncode(Server.UrlEncode(newStr))).Replace("data=", "xml=");
                string str = "<data>";
                str += "<order_count>1</order_count><order_id>" + OrderCodeID + @"</order_id>";
                str += "<order_weight>0.000</order_weight>";
                str += "<ship_time><![CDATA[任意日期 ]]></ship_time>";
                str += "<order_price>" + "100" + @"</order_price>";
                str += "<ship_name><![CDATA[" +this.txtUName.Text+ @"]]></ship_name>";
                str += "<ship_zip>" +this.txtZipCode.Text + @"</ship_zip>";
                str += "<ship_addr><![CDATA[" + ShouAdderss + txtAddress.Text + @"]]></ship_addr>";
                str += "<ship_mobile>" +this.txtMobil.Text + @"</ship_mobile>";
                str += "<ship_tel><![CDATA[" +this.txtPhone.Text+ @"]]></ship_tel>";
                str += "<order_memo><![CDATA[" + "简介" + @"]]></order_memo>";
                str += "<shop_name><![CDATA[" + "网店名称" + @"]]></shop_name>";
                str += "<dly_name><![CDATA[" + mdSh.ShipperName + @"]]></dly_name>";
                str += "<ship_area_0><![CDATA[]]></ship_area_0>";
                str += "<ship_area_1><![CDATA[]]></ship_area_1>";
                str += "<ship_area_2><![CDATA[]]></ship_area_2>";
                str += "<dly_area_0><![CDATA[]]></dly_area_0>";
                str += "<dly_area_1><![CDATA[]]></dly_area_1>";
                str += "<dly_area_2><![CDATA[]]></dly_area_2>";
                str += "<dly_address><![CDATA[" + this.litSendRegion.Text + mdSh.Address + @"]]></dly_address>";
                str += "<dly_tel><![CDATA[" + mdSh.TelPhone + @"]]></dly_tel>";
                str += "<dly_mobile>" + mdSh.CellPhone + @"</dly_mobile>";
                str += "<dly_zip>" + mdSh.Zipcode + @"</dly_zip>";
                str += "<date_y>" + DateTime.Now.Year.ToString() + @"</date_y>";
                str += "<date_m>" + DateTime.Now.Month.ToString() + @"</date_m>";
                str += "<date_d>" + DateTime.Now.Day.ToString() + @"</date_d>";
                str += "</data>";

                ItemContent += "&data=" + Server.UrlEncode(str);
                ItemContent = Server.UrlDecode(ItemContent);
            }
        }
    }
}