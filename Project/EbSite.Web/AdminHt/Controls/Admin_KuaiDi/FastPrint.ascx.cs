using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_KuaiDi
{
    public partial class FastPrint : UserControlBaseSave
    {
        protected string ItemContent = "";

        public override string PageName
        {
            get
            {
                return " 快速打印";
            }
        }
        public override string Permission
        {
            get
            {
                return "303";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }

        /// <summary>
        /// 打印模板
        /// </summary>
        public int Tempid = 0;
        /// <summary>
        /// 发货人
        /// </summary>
        public int SendId = 0;

        protected List<Entity.Shippers> ls = BLL.Shippers.Instance.GetListArray("");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (ls.Count == 0)
            {
                this.LabMsg.Text = "您还没有添加发货人信息，请先添加发货人信息!";
                this.PanSend.Visible = false;
            }
            else
            {
                ddlShoperTag.DataSource = ls;
                ddlShoperTag.DataTextField = "ShipperTag";
                ddlShoperTag.DataValueField = "id";

                List<Entity.Shippers> lsit = (from i in ls where i.IsDefault == true select i).ToList();
                if (lsit.Count > 0)
                    ddlShoperTag.SelectedValue = lsit[0].id.ToString();
                ddlShoperTag.DataBind();

                CheckSender();


                // yhl 2013-09-23 从外界传来的
                if (!string.IsNullOrEmpty(SendeeName))
                {
                    this.txtShipName.Text = SendeeName;
                }
                if (!string.IsNullOrEmpty(SendeeAddress))
                {
                    this.txtAddress.Text = SendeeAddress;
                }
                if (!string.IsNullOrEmpty(SendeeTel))
                {
                    this.txtCellphone.Text = SendeeTel;
                }
                if (!string.IsNullOrEmpty(SendeeOrderID))
                {
                    this.txtNumber.Text = SendeeOrderID;
                }

            }
            //快递模板
            List<Entity.Express> exList = BLL.Express.Instance.FillList();

            List<Entity.Express> NexList = (from i in exList where i.IsAct == true select i).ToList();

            ddlTemplates.DataSource = NexList;
            ddlTemplates.DataTextField = "Name";
            ddlTemplates.DataValueField = "id";
            ddlTemplates.DataBind();
            ddlTemplates.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        protected override void InitModifyCtr()
        {

        }
        override protected void SaveModel()
        {

        }

        protected void ddlShoperTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSender();
        }
        /// <summary>
        /// 从新绑定 发送人
        /// </summary>
        protected void CheckSender()
        {
            int k = Convert.ToInt32(ddlShoperTag.SelectedValue);
            Entity.Shippers mdcheck = (from s in ls where s.id == k select s).ToList()[0];
            LbShipperName.Text = mdcheck.ShipperName;
            LbRegionId.Text = BLL.AreaInfo.Instance.GetAddressByIdAsc(mdcheck.RegionId);
            LbAddress.Text = mdcheck.Address;
            LbCellPhone.Text = mdcheck.CellPhone;
            LbTelPhone.Text = mdcheck.TelPhone;
            LbZipcode.Text = mdcheck.Zipcode;
            LbShopName.Text = mdcheck.ShopName;
        }
        protected void BtnPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SendeeAddress))
            {
                if (string.IsNullOrEmpty(alReceiveAreaList.hfValue.CtrValue))
                {
                    base.TipsAlert("请选择地区");
                }
                else
                {
                    Tempid = int.Parse(ddlTemplates.SelectedValue);
                    SendId = int.Parse(ddlShoperTag.SelectedValue);
                    ShowPrint();
                    this.Panel1.Visible = false;
                    this.PrintPanel.Visible = true;
                }
            }
            else
            {
                Tempid = int.Parse(ddlTemplates.SelectedValue);
                SendId = int.Parse(ddlShoperTag.SelectedValue);
                ShowPrint();
                this.Panel1.Visible = false;
                this.PrintPanel.Visible = true;
            }

        }
        protected void ShowPrint()
        {
            Entity.Express mdEx = new Express();
            Entity.Shippers mdSh = new Shippers();
            if (Tempid == 0)
                base.TipsAlert("请选择快递模板");
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
                base.TipsAlert("请选择发货人");
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
                string ShouAdderss = "";
                if (string.IsNullOrEmpty(SendeeAddress))
                    ShouAdderss = BLL.AreaInfo.Instance.GetAddressByIdAsc(int.Parse(alReceiveAreaList.hfValue.CtrValue));
                ItemContent = mdEx.ItemContent.Replace(dataStr, Server.UrlEncode(Server.UrlEncode(newStr))).Replace("data=", "xml=");
                string str = "<data>";
                str += "<order_count>1</order_count><order_id>" + txtNumber.Text + @"</order_id>";
                str += "<order_weight>0.000</order_weight>";
                str += "<ship_time><![CDATA[任意日期 ]]></ship_time>";
                str += "<order_price>" + "100" + @"</order_price>";
                str += "<ship_name><![CDATA[" + txtShipName.CtrValue + @"]]></ship_name>";
                str += "<ship_zip>" + txtZipcode.Text + @"</ship_zip>";
                str += "<ship_addr><![CDATA[" + ShouAdderss + txtAddress.Text + @"]]></ship_addr>";
                str += "<ship_mobile>" + txtCellphone.Text + @"</ship_mobile>";
                str += "<ship_tel><![CDATA[" + txtTelphone.Text + @"]]></ship_tel>";
                str += "<order_memo><![CDATA[" + "简介" + @"]]></order_memo>";
                str += "<shop_name><![CDATA[" + mdSh.ShopName + @"]]></shop_name>";
                str += "<dly_name><![CDATA[" + mdSh.ShipperName + @"]]></dly_name>";
                str += "<ship_area_0><![CDATA[]]></ship_area_0>";
                str += "<ship_area_1><![CDATA[]]></ship_area_1>";
                str += "<ship_area_2><![CDATA[]]></ship_area_2>";
                str += "<dly_area_0><![CDATA[]]></dly_area_0>";
                str += "<dly_area_1><![CDATA[]]></dly_area_1>";
                str += "<dly_area_2><![CDATA[]]></dly_area_2>";
                str += "<dly_address><![CDATA[" + LbRegionId.Text + mdSh.Address + @"]]></dly_address>";
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

        #region yhl 2013-09-23 接收外界传来 收货人姓名，地址，电话，订单号
        /// <summary>
        /// 接收人姓名
        /// </summary>
        private string SendeeName
        {
            get { return Request.QueryString["u"]; }
        }
        /// <summary>
        /// 接收人 地址
        /// </summary>
        private string SendeeAddress
        {
            get { return Request.QueryString["a"]; }
        }
        /// <summary>
        /// 接收人 电话 
        /// </summary>
        private string SendeeTel
        {
            get { return Request.QueryString["tel"]; }
        }
        /// <summary>
        /// 接收人的订单号
        /// </summary>
        private string SendeeOrderID
        {
            get { return Request.QueryString["o"]; }
        }
        #endregion
    }
}