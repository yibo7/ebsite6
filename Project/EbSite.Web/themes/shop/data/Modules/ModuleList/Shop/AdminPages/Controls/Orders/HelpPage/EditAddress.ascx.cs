using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage
{
    public partial class EditAddress : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "修改收货人地址";
            }
        }
    
        public override string Permission
        {
            get
            {
                return "76";
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (OrderCodeID > 0)
                {
                    ModuleCore.Entity.Buy_Orders m = ModuleCore.BLL.Buy_Orders.Instance.GetEntity(OrderCodeID);
                    if (m != null)
                    {
                        this.txtReUname.Text = m.SendToUserName;

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

                        this.ddlAddress.Value =adds;
                        this.txtAddress.Text = m.Address;
                        this.txtMobil.Text = m.CellPhone;
                        this.txtPhone.Text = m.TelPhone;
                        this.txtZipCode.Text = m.ZipCode;
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
            dicArray.Add("SendToUserName",string.Concat("'",this.txtReUname.Text,"'"));
            string Ids = string.Concat(this.ddlAddress.hfValueParentIDs.CtrValue, ",", this.ddlAddress.Value);
            dicArray.Add("SendRegion", string.Concat("'", Ids, "'"));
            dicArray.Add("RegionId", EbSite.BLL.SendArea.Instance.GetSendAreaIDByAreaIDs(Ids));
            dicArray.Add("Address", string.Concat("'", EbSite.BLL.AreaInfo.Instance.GetAddressByIdAsc(int.Parse(this.ddlAddress.Value)).Replace("中国", "").Trim()," ", this.txtAddress.Text, "'"));
            dicArray.Add("CellPhone", string.Concat("'", this.txtMobil.Text, "'"));
            dicArray.Add("TelPhone", string.Concat("'", this.txtPhone.Text, "'"));
            dicArray.Add("ZipCode", string.Concat("'", this.txtZipCode.Text, "'"));
            
            if (ModuleCore.BLL.Buy_Orders.Instance.UpdateByDic(dicArray, OrderCodeID))
            {
                //添加操作日志
                ModuleCore.BLL.buy_orderlog.Instance.Add(OrderCodeID, "修改收货人地址信息", ModuleCore.SystemEnum.OrderLogType.全部显示);
                base.RunJs("CloseOrder(1);");
            }
            else
            {
                base.RunJs("CloseOrder(0);");
            }
        }
    }
}