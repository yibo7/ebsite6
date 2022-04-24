using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL.User;

namespace EbSite.Web.AdminHt.Controls.Admin_Member
{
    public partial class MemberToGroup : UserControlBase
    {

        public override string Permission
        {
            get
            {
                return "73";
            }
        } 

        
        
        protected string[] UserGroups
        {
            get
            {
                return Roles.GetRolesForUser(sUserName);
            }
        }



        protected int GetUserGroupID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetUserGroupID = BLL.User.MembershipUserEb.Instance.GetUserGroupId(sUserName);
            rpList.DataSource = UserGroupProfile.UserGroupProfiles;
            rpList.DataBind();

        }

        
        //private int SuppliersSelectedIndex
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(Request.Form["GroupID"]))
        //            return -1;
        //        else
        //            return Convert.ToInt32(Request.Form["GroupID"]);
        //    }
        //}


        protected string sUserName
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["u"]))
                {
                    return Request["u"];
                }
                return string.Empty;
            }
        }
    }
}