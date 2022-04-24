using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Modules.Exam.AdminPages.Controls.Exam
{
    public partial class QuestionsList : MPUCBaseList
    {
        override protected Guid MenuAddID
        {
            get { return new Guid("46f5b5e1-fd20-4dde-b0ed-1b8088672e6b"); }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("75a5534f-e3be-4adb-a697-4978dccf5c53");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override int OrderID
        {
            get
            {
                return 2;
            }
        }

        #region 权限

        public override string Permission
        {
            get
            {
                return "1";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "1";
            }
        }
        /// <summary>
        /// 添加数据的权限ID
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "1";
            }
        }
        /// <summary>
        /// 修改数据权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "1";
            }
        }
        #endregion

        public override string PageName
        {
            get
            {
                return "所有考题";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }

        private string InationID
        {
            get { return Request["iid"]; }
        }

        protected string GetTitle
        {
            get { return Request["title"]; }
        }
        override protected string GetAddUrl
        {
            get { return string.Concat(base.GetAddUrl, "&iid=", InationID, "&title=", GetTitle); }
        }

        public string ModifyUrl(string id)
        {
         
            
                return string.Concat(GetMofifyUrl(id), "&iid=", InationID, "&title=",
                                     Request["title"]);
           

        }

        override protected object LoadList(out int iCount)
        {
            if (!string.IsNullOrEmpty(InationID))
            {
                return BLL.exam_questions.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, "ExamID=" + InationID, "", out iCount);
            }
            else
            {
                return BLL.exam_questions.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize,  out iCount);
            }
            
        }
        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            BLL.exam_questions.Instance.Delete(int.Parse(iID.ToString()));

        }
        override protected void CopyData(object iID)
        {
            BLL.exam_questions.Instance.CopyData(int.Parse(iID.ToString()));

        }
        #region 工具栏的初始化

        override protected void BindToolBar()
        {
            if (string.IsNullOrEmpty(InationID))
            {
                base.BindToolBar(true, false, false, false, false);
            }
            else
            {
                base.BindToolBar();
            }

            //ucToolBar.AddBnt("添加", "/images/menus/add.gif", "", false, "OpenAddPage()", "");
        }
        #endregion
    }
}