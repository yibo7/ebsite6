using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL.User;

namespace EbSite.Web.AdminHt.Controls.Admin_Member
{
    public partial class UserLavelList : UserControlListBase
    {

        public override string Permission
        {
            get
            {
                return "73";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "74";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "183";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "187";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "t=11";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            List<Entity.UserLevel> ls = EbSite.BLL.UserLevel.Instance.GetListArray("");
            List<Entity.UserLevel> nls = (from li in ls
                                          orderby li.id descending
                                          select li).ToList();
            return nls;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            int id = int.Parse(iID.ToString());
            EbSite.BLL.UserLevel.Instance.Delete(id);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}