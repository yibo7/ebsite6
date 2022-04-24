using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Web.AdminHt.Controls.Admin_Coupons
{
    public partial class CouponsShow : UserControlBaseShow<Entity.Coupons>
    {
        public override string PageName
        {
            get
            {
                return "优惠券查看";
            }
        }
        /// <summary>
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "160";
            }
        }
        /// <summary>
        /// 重写删除
        /// </summary>
        protected override void Delete()
        {
            Model.Delete();
        }
        /// <summary>
        /// 重写Load事件
        /// </summary>
        protected override Entity.Coupons LoadModel()
        {
           Entity.Coupons md = new Entity.Coupons(int.Parse(GetKeyID));
            if (Equals(md, null)) md = new Entity.Coupons();//防止删除后的页面出错
            return md;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Entity.CouponItems> ls = BLL.CouponItems.Instance.GetListArray(0, "CouponId=" + int.Parse(GetKeyID), "");
                this.RepItem.DataSource = ls;
                this.RepItem.DataBind();


            }
        }
    }
}