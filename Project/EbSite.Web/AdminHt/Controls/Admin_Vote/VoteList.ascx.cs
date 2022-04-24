using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Vote
{
    public partial class VoteList : UserControlListBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region 权限

        public override string Permission
        {
            get
            {
                return "308";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "308";
            }
        }
        /// <summary>
        /// 添加数据的权限ID
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "308";
            }
        }
        /// <summary>
        /// 修改数据权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "308";
            }
        }
        #endregion


        protected DateTime GetDateTime(object intdate)
        {
            return Core.SqlDateTimeInt.GetDateTime(int.Parse(intdate.ToString()));
        }

        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }
        override protected object LoadList(out int iCount)
        {

            return BLL.vote.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount);
        }
        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            BLL.vote.Instance.Delete(int.Parse(iID.ToString()));

        }
    }
}