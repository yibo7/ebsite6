using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Web.AdminHt.Controls.Admin_Configs
{
    public partial class UploadFilesTem : UploadFilesBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "226";
            }
        }

        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "228";
            }
        }

        #endregion

        protected override bool IsUsedFile
        {
            get
            {
                return false;
            }
        }
    }
}