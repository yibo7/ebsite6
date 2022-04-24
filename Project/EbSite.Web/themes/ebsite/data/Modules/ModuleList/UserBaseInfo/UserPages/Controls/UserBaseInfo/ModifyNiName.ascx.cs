using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.BLL.User;
using EbSite.Core;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.UserBaseInfo
{
    public partial class ModifyNiName : MPUCBaseSaveForUser
    {
        public string FlashParam = "";
        public override string PageName
        {
            get
            {
                return "修改昵称";
            }
        }
        public override string TipsText
        {
            get
            {
                return "可以给自己起一个有个性的名称!";

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
                return 2;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtNiName.Text = UserNiname;

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
                return new Guid("bf371bdd-a674-4097-a9ed-e2896fb4c857");
            }
        }
       
        override protected void InitModifyCtr()
        {

        }
        override protected void SaveModel()
        {
            bool isok = BLL.User.MembershipUserEb.Instance.ExistsUserName(txtNiName.Text.Trim());
             if (!isok)
             {
                 EbSite.Base.EntityAPI.MembershipUserEb mdUser = HostApi.CurrentUser;
                 mdUser.NiName = txtNiName.Text.Trim();
                 mdUser.Save();
                 TipsAlert("修改成功！");
             }
             else
             {
                 base.TipsAlert("此昵称已被注册");
             }
        }
    }
}