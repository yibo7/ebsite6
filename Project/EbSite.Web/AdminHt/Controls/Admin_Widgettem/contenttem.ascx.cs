using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Widgettem
{
    public partial class contenttem : UserControlListBase
    {
        public override string Permission
        {
            get
            {
                return "115";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "116";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "218";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "217";
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
            return BLL.ContentTem.Instance.FillList();
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
        
            return null;
        }
        override protected void Delete(object iID)
        {
            BLL.ContentTem.Instance.DeleteCtrTem(new Guid(iID.ToString()));

        }

    }
}