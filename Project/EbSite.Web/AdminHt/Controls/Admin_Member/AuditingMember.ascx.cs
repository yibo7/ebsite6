using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EbSite.Base.ControlPage;
using EbSite.BLL.User;

namespace EbSite.Web.AdminHt.Controls.Admin_Member
{
    public partial class AuditingMember : MemberListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "77";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "194";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "193";
            }
        }

        #endregion

        #region 工具栏的初始化
        override protected void BindToolBar()
        {

            base.BindToolBar();

            ucToolBar.AddLine();

            ucToolBar.AddBnt("审核通过", string.Concat(IISPath, "images/Menus/User-Ok.gif"), "through");


        }
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "through":
                    foreach (string key in GetSelKeys)
                    {
                        EbSite.Base.EntityAPI.MembershipUserEb ucf = BLL.User.MembershipUserEb.Instance.GetEntity(key);
                        //BLL.User.MembershipUserEb.Instance.ActivateUser(ucf);
                        ucf.IsApproved = true;
                        ucf.Save();
                    }
                    break;
            }
        }
        #endregion
        /// <summary>
        /// 只显示未通过用户
        /// </summary>
        protected override bool IsAuditing
        {
            get
            {
                return false;
            }
        }
    }
}