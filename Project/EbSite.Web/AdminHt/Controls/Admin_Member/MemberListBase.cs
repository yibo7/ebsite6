using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL.User;

namespace EbSite.Web.AdminHt.Controls.Admin_Member
{
    abstract public class MemberListBase : UserControlListBase
    {
        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }
       
        private bool IsPage
        {
            get
            {
                bool key = false;
                if (!string.IsNullOrEmpty(Request.QueryString["p"]))
                {
                    key = true;
                }
                return key;
            }
       }
        override protected object LoadList(out int iCount)
        {  
            if (Equals(Session["swRoleID"], null))
            {
                Session["swRoleID"] = GetRoleID;
            }
            else
            {
                if (!IsPage)
                {
                    if (int.Parse(Session["swRoleID"].ToString()) != GetRoleID)
                    {
                        Session["swRoleID"] = GetRoleID;
                    }
                }
              
            }
            return BLL.User.MembershipUserEb.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, IsAuditing, out iCount, int.Parse(Session["swRoleID"].ToString()));
        }

        abstract protected bool IsAuditing { get; }
        override protected SearchParameter[] GetSearchParameters
        {
            get
            {
                List<SearchParameter> lstSp = new List<SearchParameter>();

                SearchParameter spModel = new SearchParameter();
                spModel.ColumnName = ucToolBar.GetItemVal(drpType);
                spModel.ColumnValue = ucToolBar.GetItemVal(txtKeyWord);
                spModel.IsString = true;
                spModel.SearchLink = EmSearchLink.不连用于最后一个;
                spModel.SearchWhere = EmSearchWhere.相等匹配;
                lstSp.Add(spModel);

                //spModel = new SearchParameter();
                //spModel.ColumnName = "IsAuditing";
                //spModel.ColumnValue = "0";// (IsAuditing) ? "1" : "0";
                //spModel.IsString = false;
                //spModel.SearchWhere = EmSearchWhere.相等匹配;
                //spModel.SearchLink = EmSearchLink.不连用于最后一个;
                //lstSp.Add(spModel);

                return lstSp.ToArray();
            }
        }
        override protected object SearchList(out int iCount)
        {

            return MembershipUserEb.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, IsAuditing, out iCount, GetRoleID, GetWhere(true));
        }

        override protected void Delete(object iID)
        {
            string sUserName = iID.ToString();
            if (!Base.Configs.BaseCinfigs.ConfigsControl.Instance.FounderuID.Trim().EndsWith(sUserName.Trim()))
            {
                MembershipUserEb.Instance.Delete(sUserName);
            }
            else
            {
                TipsAlert("创始人不可以删除！");
            }

        }

        #region 工具栏的初始化
        protected Control.TextBox txtKeyWord = new Control.TextBox();
        protected Control.DropDownList drpUserGrou = new Control.DropDownList();
        protected Control.DropDownList drpType = new Control.DropDownList();
        override protected void BindToolBar()
        {

            base.BindToolBar(false, false, true, false, false);

            ucToolBar.AddLine();

            txtKeyWord.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtKeyWord);

            drpType.ID = "drpType";
            drpType.Items.Add(new ListItem("用户帐号", "UserName"));
            drpType.Items.Add(new ListItem("用户昵称", "NiName"));
            drpType.Items.Add(new ListItem("用户ID", "UserID"));
            ucToolBar.AddCtr(drpType);

            base.ShowCustomSearch("搜索");
            ucToolBar.AddLine();

            drpUserGrou.ID = "drpUserGrou";
            drpUserGrou.Items.Add(new ListItem("所有用户组", "0"));
            drpUserGrou.AppendDataBoundItems = true;
            drpUserGrou.DataTextField = "GroupName";
            drpUserGrou.DataValueField = "ID";
            drpUserGrou.Attributes.Add("onchange", "OnRoleChange(this)");
            drpUserGrou.DataSource = UserGroupProfile.UserGroupProfiles;
            drpUserGrou.DataBind();
            ucToolBar.AddCtr(drpUserGrou);
            ucToolBar.AddLine();


            //ucToolBar.AddBnt("设为管理员", string.Concat(IISPath, "images/Menus/User-Ok.gif"), "setadmin");
            //ucToolBar.AddBnt("取消管理员", string.Concat(IISPath, "images/Menus/User-Del.gif"), "deladmin");
            //ucToolBar.AddBnt("锁定用户", string.Concat(IISPath, "images/Menus/User-Lock.gif"), "lockuser");


        }

        #endregion

        /// <summary>
        /// 获取当前用户组ID
        /// </summary>
        protected int GetRoleID
        {
            get
            {
                if (string.IsNullOrEmpty(Request["rid"]))
                {
                    return 0;
                  
                }
                else
                {
                    return int.Parse(Request["rid"]);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                ucToolBar.SetItemVal(drpUserGrou, GetRoleID.ToString());
            }


        }
    }
}