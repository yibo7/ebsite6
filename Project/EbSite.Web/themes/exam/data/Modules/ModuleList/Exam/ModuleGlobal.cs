using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using EbSite.Base;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Modules;
using System.Data;
using System.Data.SqlClient;

namespace EbSite.Modules.Exam
{
    public class ModuleGlobal : ModuleGlobalBase
    {
        private static string StartupOK = null;
        private static object _SyncRoot = new object();
        override public void Application_BeginRequest(object sender, EventArgs e)
        {
            if (StartupOK == null)
            {
                lock (_SyncRoot)
                {
                    if (StartupOK == null)
                    {
                     
                        EbSite.Base.EBSiteEvents.ContentPageLoadEvent += new EventHandler<ContentPageLoadEventArgs>(On_ContentPageLoadEvent);

                        StartupOK = "OK";
                    }
                }
            }

        }
        private static void On_ContentPageLoadEvent(object sender, ContentPageLoadEventArgs e)
        {
            //#region 手机版问答回复列表

            //EbSite.Entity.NewsContent mContent = EbSite.BLL.NewsContent.GetModel(e.ContentID);
            ////判断此问题是否已经有采纳答案
            //if (mContent != null && mContent.Annex21 == 2)
            //{
            //    DataSet ds = ModuleCore.BLL.Answers.Instance.GetDataArticle(e.ContentID, mContent.Annex21);
            //    if (ds != null && ds.Tables.Count > 3)
            //    {
            //        //查询出最佳答案
            //        DataTable dt1 = ds.Tables[2];
            //        Control.Repeater rptBest = e.Page.FindControl("rptBestAnswer") as Control.Repeater;
            //        if (!Equals(rptBest, null))
            //        {
            //            rptBest.ItemDataBound +=
            //                new System.Web.UI.WebControls.RepeaterItemEventHandler(rptBest_ItemDataBound);
            //            rptBest.DataSource = dt1;
            //            rptBest.DataBind();
            //        }
            //        //其他回答列表
            //        DataTable dt2 = ds.Tables[3];
            //        if (dt2 != null && dt2.Rows.Count > 0)
            //        {
            //            Control.Repeater rptOtherList = e.Page.FindControl("rptOtherAnswer") as Control.Repeater;
            //            rptOtherList.DataSource = dt2;
            //            rptOtherList.DataBind();
            //        }
            //    }
            //}
            //else
            //{
            //    Control.Repeater rptRefList = e.Page.FindControl("rptRefList") as Control.Repeater;
            //    List<ModuleCore.Entity.Answers> answersList = ModuleCore.BLL.Answers.Instance.GetListArray("qid=" + e.ContentID);
            //    if (answersList != null && answersList.Count > 0)
            //    {
            //        rptRefList.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(rptRefList_ItemDataBound);
            //        rptRefList.DataSource = answersList;
            //        rptRefList.DataBind();
            //    }
            //    else
            //    {

            //    }
            //}

            //#endregion 手机版问答回复列表
           
            //考题数据源
            Control.Repeater rptDataList = e.Page.FindControl("rptDataList") as Control.Repeater;
            if (!Equals(rptDataList, null))
            {
                rptDataList.DataSource = EbSite.BLL.exam_questions.Instance.GetListArray(0, string.Concat("ExamID=" , e.ContentID), ""); ;
                rptDataList.DataBind();
            }

           // // 查询表
           // EbSite.Entity.NewsContent md = EbSite.BLL.NewsContent.GetModel(e.ContentID);
           // // ‘sum’ 共多少人做过本卷
           // int exyou = int.Parse(md.Annex12.ToString());
           // int exzhong = int.Parse(md.Annex13.ToString());
           // int excha = int.Parse(md.Annex14.ToString());
           // int sum = exyou + exzhong + excha;
           // System.Web.UI.WebControls.Label exsm = e.Page.FindControl("exsum") as System.Web.UI.WebControls.Label;
           //      exsm.Text = sum.ToString();
           // //考试时间
           // System.Web.UI.WebControls.Label ss = e.Page.FindControl("Time") as System.Web.UI.WebControls.Label;
           //      ss.Text = md.Annex11.ToString();
           // //优秀最低分数线
           // System.Web.UI.WebControls.Label fsx = e.Page.FindControl("fenshu") as System.Web.UI.WebControls.Label;
           //      fsx.Text = md.Annex16.ToString();
           // //试卷介绍
           // System.Web.UI.WebControls.Label exsj = e.Page.FindControl("exsjjs") as System.Web.UI.WebControls.Label ;
           //      exsj.Text = md.ContentInfo.ToString();
           // //试卷名称
           // System.Web.UI.WebControls.Label exname= e.Page.FindControl("exsjname") as System.Web.UI.WebControls.Label;
           //      exname.Text = md.NewsTitle.ToString();
           // // 考题类别数据源
           ////EbSite.Entity.exam_questionsclass Lb = EbSite.BLL.exam_questionsclass.Instance.GetEntity(e.ContentID);
           // //  考题名称
           // //System.Web.UI.WebControls.Label  name = e.Page.FindControl("biaot") as System.Web.UI.WebControls.Label;
           // //name.Text = Lb.ClassName.ToString();
            

        }

    }
}