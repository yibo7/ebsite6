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
    public partial class QuestionsClassList : MPUCBaseList
    {
        private string InationID
        {
            get { return Request["iid"]; }
        }
        override protected Guid MenuAddID
        {
            get { return new Guid("b41a7dd6-69a0-477a-a6be-d1a60b509b07"); }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("1ee7395c-252e-4f32-97bd-b34ca0c1cc7a");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

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
                return "考题类别";
            }
        }

        protected string GetTitle
        {
            get { return Request["title"]; }
        }
        override protected string GetAddUrl
        {
            get { return string.Concat(base.GetAddUrl, "&iid=", InationID, "&title=", GetTitle); }
        }
        
        override protected object LoadList(out int iCount)
        {

            return BLL.exam_questionsclass.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, "ExamID=" + InationID, "", out iCount);
        }
        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            BLL.exam_questionsclass.Instance.Delete(int.Parse(iID.ToString()));

        }
    }
}