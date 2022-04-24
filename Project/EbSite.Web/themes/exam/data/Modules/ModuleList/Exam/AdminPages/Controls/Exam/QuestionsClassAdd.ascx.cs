using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Modules.Exam.AdminPages.Controls.Exam
{
    public partial class QuestionsClassAdd : MPUCBaseSave
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("b41a7dd6-69a0-477a-a6be-d1a60b509b07");
            }
        }
        private int GetInationID
        {
            get { return Core.Utils.StrToInt(Request["iid"], 0); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lbInation.Text = Request["title"];
        }
        public override string PageName
        {
            get
            {
                return "保存考题类别";
            }
        }
        public override string Permission
        {
            get
            {
                return "1";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
            BLL.exam_questionsclass.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {

            lstOtherColumn.Add(new OtherColumn("AddDateTimeInt", Core.SqlDateTimeInt.GetSecond(DateTime.Now).ToString()));
            //lstOtherColumn.Add(new OtherColumn("AddDateTime", DateTime.Now.ToString()));
            lstOtherColumn.Add(new OtherColumn("AddUserID", UserID.ToString()));
            lstOtherColumn.Add(new OtherColumn("AddUserNiName", UserNiname));

            if (GetInationID>0)
                lstOtherColumn.Add(new OtherColumn("ExamID", GetInationID.ToString()));
            

            BLL.exam_questionsclass.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);


        }
    }
}