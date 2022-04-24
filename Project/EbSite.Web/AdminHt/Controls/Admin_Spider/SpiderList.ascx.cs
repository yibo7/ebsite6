using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Spider
{
    public partial class SpiderList : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "163";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "163";
            }
        }
        /// <summary>
        /// 添加数据的权限ID
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "163";
            }
        }
        /// <summary>
        /// 修改数据权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "163";
            }
        }
        #endregion

        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return BLL.IISLOG.SpiderBll.Instance.FillList();
        }
        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            BLL.IISLOG.SpiderBll.Instance.Delete(int.Parse(iID.ToString()));

        }
        //protected override void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    base.gdList_RowCommand(sender, e);
        //    if (object.Equals(e.CommandName, "SetCount"))
        //    {
        //        string iD = e.CommandArgument.ToString();
        //        Entity.ErrInfo md = BLL.IISLOG.SpiderBll.Instance.GetEntity(int.Parse(iD));
        //        md.ErrCount = 0;
        //        BLL.ErrInfo.Instance.Update(md);
        //        base.gdList_Bind();
        //    }

        //}
    }
}