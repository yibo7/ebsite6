using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.ControlPage;


namespace EbSite.Web.AdminHt.Controls.Admin_Coupons
{
    public partial class CouponsAdd : UserControlBaseSave
    {
        public override string PageName
        {
            get
            {
                return "优惠券添加";
            }
        }
        public override string Permission
        {
            get
            {
                return "159";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        override protected void InitModifyCtr()
        {
            BLL.Coupons.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {
            //要检查 名字 

            List<Entity.Coupons> ls = EbSite.BLL.Coupons.Instance.GetListArray(0,
                                                                               "couponname='" +
                                                                               this.CouponName.Text.Trim() + "'", "");
            if (ls.Count > 0)
            {
                base.TipsAlert("存在同名优惠券。");
            }
            else
            {
                EbSite.Base.BLL.OtherColumn cl = new OtherColumn("usedcount", "0");
                lstOtherColumn.Add(cl);
                BLL.Coupons.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
            }
        }
    }
}