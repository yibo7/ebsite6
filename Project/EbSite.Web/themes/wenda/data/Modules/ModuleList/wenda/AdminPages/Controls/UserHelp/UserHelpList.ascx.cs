using System;
using EbSite.Base.ControlPage;
using EbSite.Base.EntityAPI;
using EbSite.Base.Modules;
using EbSite.Base.Page;
using System.Collections.Generic;
using EbSite.Control;
using System.Web.UI.WebControls;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace EbSite.Modules.Wenda.AdminPages.Controls.UserHelp
{
    public partial class UserHelpList : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "用户积分";
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
        /// <summary>
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "16";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "17";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "18";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "19";
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("df8b4a9d-ca18-4c69-b4e0-df3d8f644349");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=6";
            }
        }
        override protected string ShowUrl
        {
            get
            {
                return "t=7";
            }
        }
        public override int OrderID
        {
            get
            {
                return 3;
            }
        }
        public string strSqlWhere = "";
        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.UserHelp.Instance.GetListPages(pcPage.PageIndex, iPageSize, out iCount);
        }
        override protected string BulderSearchWhere(bool IsValueEmpytNoSearch)
        {
            return string.Format(strSqlWhere);
        }
        protected override string BulderSearchWhereAdv(bool IsValueEmpytNoSearch)
        {
            return string.Format(strSqlWhere);
        }

        override protected object SearchList(out int iCount)
        {
            string username = ucToolBar.GetItemVal(this.username);     //标题

            strSqlWhere = StrWhere(username);


            return ModuleCore.BLL.UserHelp.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "", out iCount);
        }
        protected string StrWhere(string username)
        {
            string strWhere = "";
            string newstr = "";

            if (!string.IsNullOrEmpty(username))
            {
                strWhere = " username like '%" + username.Trim() + "%' ";
            }
            List<EbSite.Base.EntityAPI.MembershipUserEb> ls = BLL.User.MembershipUserEb.Instance.GetListArray(0, strWhere, "");
            if(ls.Count>0)
            {
                foreach (MembershipUserEb membershipUserEb in ls)
                {
                    newstr += membershipUserEb.id + ",";
                }
                if (!string.IsNullOrEmpty(newstr))
                {
                    newstr = newstr.Remove(newstr.Length - 1, 1);
                  
                }

            }
            else
            {
                newstr = "0";
            }

            return "userid in(" +newstr+")";
        }
        override protected void Delete(object iID)
        {
            
        }
        #region  工具栏的初始化
        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.TextBox username = new TextBox();
        protected EbSite.Control.DatePicker SalesDate = new DatePicker();
        override protected void BindToolBar()
        {
            base.BindToolBar(true,true,true,true,true);
           
            LbName.ID = "LbName";
            LbName.Text = "用户名";
            ucToolBar.AddCtr(LbName);
            username.ID = "username";
            username.Attributes.Add("style", "width:90px");
            ucToolBar.AddCtr(username);

           

          
            base.ShowCustomSearch("查询");
        }
        #endregion
    }
}
