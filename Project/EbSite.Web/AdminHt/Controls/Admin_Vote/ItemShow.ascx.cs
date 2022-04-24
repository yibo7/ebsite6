using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Vote
{
    public partial class ItemShow : UserControlListBase
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
        private int GetVoteID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["vid"]))
                {
                    return int.Parse(Request["vid"]);
                }
                return 0;
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=3&vid=" + GetVoteID;
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return BLL.voteitem.Instance.GetListArray(GetVoteID);
        }
        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            BLL.voteitem.Instance.Delete(int.Parse(iID.ToString()));

        }
    }
}