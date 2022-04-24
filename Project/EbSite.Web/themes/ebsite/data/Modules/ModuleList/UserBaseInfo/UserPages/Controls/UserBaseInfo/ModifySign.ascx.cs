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
    public partial class ModifySign : MPUCBaseSaveForUser
    {
        public string FlashParam = "";
        public override string PageName
        {
            get
            {
                return "修改签名";
            }
        }
        public override string TipsText
        {
            get
            {
                return "请给自己更新签名 !";

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
                return 8;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Base.EntityAPI.MembershipUserEb md = BLL.User.MembershipUserEb.Instance.GetEntity(base.UserID);
                txtSign.Text = md.Sign;

            }

        }
        /// <summary>
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "12";
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
                return new Guid("82429e49-d598-4814-a19b-64ced84c54bc");
            }
        }

        override protected void InitModifyCtr()
        {

        }
        override protected void SaveModel()
        {
            if (!string.IsNullOrEmpty(txtSign.Text.Trim()))
            {
                Base.EntityAPI.MembershipUserEb md = BLL.User.MembershipUserEb.Instance.GetEntity(base.UserID);
                md.Sign = txtSign.Text.Trim();
                BLL.User.MembershipUserEb.Instance.Update(md);
                base.TipsAlert("此签名修改成功！");
            }
            else
            {
                base.TipsAlert("请输入签名内容！");
            }
           

        }
    }
}