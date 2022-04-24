using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_KuaiDi
{
    public partial class SenderMsgAdd : UserControlBaseSave
    {
        public int SSID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override string PageName
        {
            get
            {
                return " 发货人信息添加";
            }
        }
        public override string Permission
        {
            get
            {
                return "302";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }


        protected override void InitModifyCtr()
        {
            SSID = int.Parse(SID);
            EbSite.BLL.Shippers.Instance.InitModifyCtr(SID, this.phCtrList);
            EbSite.Entity.Shippers md = EbSite.BLL.Shippers.Instance.GetEntity(int.Parse(SID));
            // RadKey.SelectedValue = md.IsDefault.ToString();
            alReceiveAreaList.hfValue.CtrValue = md.RegionId.ToString();

        }
        override protected void SaveModel()
        {
            if (string.IsNullOrEmpty(SID))
            {
                OtherColumn otherColumn = new OtherColumn("IsDefault", RadKey.SelectedValue);
                lstOtherColumn.Add(otherColumn);
                if (RadKey.SelectedValue == "True")
                {
                    //批量更新其他的 默认
                    List<Entity.Shippers> ls = EbSite.BLL.Shippers.Instance.GetListArray("");
                    foreach (var shipperse in ls)
                    {
                        shipperse.IsDefault = false;
                        EbSite.BLL.Shippers.Instance.Update(shipperse);
                    }
                }
            }

            OtherColumn otherColumn1 = new OtherColumn("RegionId", alReceiveAreaList.hfValue.CtrValue);
            lstOtherColumn.Add(otherColumn1);
            EbSite.BLL.Shippers.Instance.SaveEntityFromCtr(this.phCtrList, lstOtherColumn);

            
        }
    }
}