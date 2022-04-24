using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL.User;
using EbSite.Data.User.Interface;

namespace EbSite.Web.AdminHt.Controls.Admin_Member
{
    public partial class MemberList : MemberListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "75";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "76";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "83";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "192";
            }
        }

        #endregion


        #region 工具栏的初始化
        override protected void BindToolBar()
        {


            base.BindToolBar();

            ucToolBar.AddBnt("设为管理员", string.Concat(IISPath, "images/Menus/User-Ok.gif"), "setadmin");
            ucToolBar.AddBnt("取消管理员", string.Concat(IISPath, "images/Menus/User-Del.gif"), "deladmin");
            ucToolBar.AddBnt("锁定用户", string.Concat(IISPath, "images/Menus/User-Lock.gif"), "lockuser");


        }
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "setadmin":
                    foreach (string userName in base.GetSelKeys)
                    {
                        if(!EbSite.BLL.AdminUser.HasUser(userName))
                        {

                            BLL.User.MembershipUserEb.Instance.SetForManager(userName);
                        }
                        
                    }
                    base.gdList_Bind();
                    break;
                case "deladmin":
                    foreach (string userName in base.GetSelKeys)
                    {
                        if (EbSite.BLL.AdminUser.HasUser(userName))
                        {
                            BLL.User.MembershipUserEb.Instance.RemoveForManager(userName);
                        }
                        
                    }
                    base.gdList_Bind();
                    break;
                case "lockuser":

                    foreach (string userName in base.GetSelKeys)
                    {
                        Base.Host.Instance.EBMembershipInstance.LockUser(userName);
                    }
                    break;
                    
                    
            }
        }
        
        #endregion
        /// <summary>
        /// 只显示已经通过用户
        /// </summary>
        protected override bool IsAuditing
        {
            get
            {
                return true;
            }
        }

        
        
    }
}