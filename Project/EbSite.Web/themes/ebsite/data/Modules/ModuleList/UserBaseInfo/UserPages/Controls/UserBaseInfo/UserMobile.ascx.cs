using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.UserBaseInfo
{
    public partial class UserMobile : MPUCBaseSaveForUser
    {
       
        public override string PageName
        {
            get
            {
                return "完善手机号";
            }
        }
        public override string TipsText
        {
            get
            {
                return "请添写您的手机号码!";

            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        public override int OrderID
        {
            get
            {
                return 6;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtMobile.Text = EbSite.Base.Host.Instance.CurrentUser.MobileNumber; 
            }

        }
        /// <summary>
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "5";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("3840b798-44a5-49a0-af7e-9e48f5be8508");
            }
        }

        override protected void InitModifyCtr()
        {

        }
        override protected void SaveModel()
        {
            if (Base.Host.Instance.CurrentUser.MobileNumber == txtMobile.Text.Trim())
            {
                TipsAlert("手机号和原来的一样。");
            }
            else
            {
                bool isok = BLL.User.MembershipUserEb.Instance.ExistsMobile(txtMobile.Text.Trim());
                if (!isok)
                {
                    Base.EntityAPI.MembershipUserEb mdUser = HostApi.CurrentUser;
                    mdUser.MobileNumber = txtMobile.Text.Trim();
                    mdUser.Save();
                    TipsAlert("修改成功！");
                }
                else
                {
                    base.TipsAlert("此手机号已被注册");
                }
            }
        }
    }
}