using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL.User;

namespace EbSite.Web.AdminHt.Controls.Admin_Member
{
    public partial class LockedUsers : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "79";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "195";
            }
        }

        #endregion

        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }
        override protected SearchParameter[] GetSearchParameters
        {
            get
            {
                List<SearchParameter> lstSp = new List<SearchParameter>();
              
                SearchParameter spModel = new SearchParameter();
                spModel.ColumnName = ucToolBar.GetItemVal(drpType);
                spModel.ColumnValue = ucToolBar.GetItemVal(txtKeyWord).Trim();
                spModel.IsString = true;
                spModel.SearchLink = EmSearchLink.与连and;
                spModel.SearchWhere = EmSearchWhere.相等匹配;
                lstSp.Add(spModel);

                spModel = new SearchParameter();
                spModel.ColumnName = "IsLockedOut";
                spModel.ColumnValue = "1";
                spModel.IsString = false;
                spModel.SearchWhere = EmSearchWhere.相等匹配;
                spModel.SearchLink = EmSearchLink.不连用于最后一个;
                lstSp.Add(spModel);

                return lstSp.ToArray();
            }
        }
        override protected object LoadList(out int iCount)
        {
            
            return Base.Host.Instance.EBMembershipInstance.GetLockedUsers(pcPage.PageIndex, pcPage.PageSize, out iCount);
            
        }

        override protected object SearchList(out int iCount)
        {
            
            return Base.Host.Instance.EBMembershipInstance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "", -1, out iCount);
        }
        override protected void Delete(object iID)
        {
            BLL.User.MembershipUserEb.Instance.Delete(iID.ToString());

        }

        #region 工具栏的初始化
        protected Control.TextBox txtKeyWord = new Control.TextBox();
        protected Control.DropDownList drpUserGrou = new Control.DropDownList();
        protected Control.DropDownList drpType = new Control.DropDownList();
        override protected void BindToolBar()
        {

            base.BindToolBar(true, false, true, false, false);

            ucToolBar.AddLine();

            txtKeyWord.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtKeyWord);

            drpType.ID = "drpType";
            drpType.Items.Add(new ListItem("用户帐号", "UserName"));
            drpType.Items.Add(new ListItem("Email", "emailAddress"));
            ucToolBar.AddCtr(drpType);

            

            base.ShowCustomSearch("搜索");


            ucToolBar.AddLine();

            ucToolBar.AddBnt("解锁用户", string.Concat(IISPath, "images/Menus/Key-Add.gif"), "unlock");


        }
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "unlock":
                    foreach (string userName in base.GetSelKeys)
                    {
                        Base.Host.Instance.EBMembershipInstance.UnlockUser(userName);
                    }
                    base.gdList_Bind();
                    break;
            }
        }
        #endregion
       
    }
}