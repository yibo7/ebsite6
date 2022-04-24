using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;

namespace EbSite.Web.AdminHt.Controls.Admin_Class
{
    abstract public class ClassListBase : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "56";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "55";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "184";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "185";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=0";
            }
        }
        #endregion
        protected Guid ModelID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["modelid"]))
                    return new Guid(Request.QueryString["modelid"]);
                else
                    // return Guid.Empty; //解决默认 选上一个的问题
                    return GetClassDataTable()[0].ID;
            }
        }
       
        protected global::System.Web.UI.WebControls.Repeater repWebModel;

        override protected object SearchList(out int iCount)
        {
            return BLL.NewsClass.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "", out iCount, base.GetSiteID);
        }
        override protected void Delete(object iID)
        {
            BLL.NewsClass.Delete(int.Parse(iID.ToString()), base.GetSiteID);

        }

       

        private List<Entity.ModelClass> GetClassDataTable()
        {
            ClassModel wm = new ClassModel(GetSiteID);
            List<Entity.ModelClass> ls = wm.ModelClassList;
            ls = (from i in ls orderby i.AddDate ascending select i).ToList();
            return ls;
        }
        public ClassListBase()
        {
            this.Load += new EventHandler(ClassListBase_Load);
        }
        private void ClassListBase_Load(object sender, EventArgs e)
        {
            //取分类 模型
            repWebModel.DataSource = GetClassDataTable();
            repWebModel.DataBind();

        }

    }
}