using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage; 

namespace EbSite.Web.AdminHt.Controls.Admin_Configs
{
    public partial class UploadFilesUsed : UploadFilesBase
    {

        #region 权限

        public override string Permission
        {
            get
            {
                return "225";
            }
        }

        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "227";
            }
        }

        #endregion

        protected override bool IsUsedFile
        {
            get
            {
                return true;
            }
        }
    }
}