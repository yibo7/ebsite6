using System;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Comment : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_Comment");
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if(PageType==1)
            {
                base.LoadAControl("AddClass.ascx");
                
            }
            else if (PageType == 2)
            {
                base.LoadAControl("CommentList.ascx");
            }
            else if (PageType==10)
            {
                base.LoadAControl("EditTem.ascx");
            }
            else if (PageType == 3)
            {
                base.LoadAControl("CoreTem.ascx");
            }

            //else if(PageType==11)
            //{
            //    base.LoadAControl("EvaluateList.ascx");
            //}
            //else if(PageType==12)
            //{
            //    base.LoadAControl("AskRemarkList.ascx");
            //}
            //else if(PageType==13)
            //{
            //    base.LoadAControl("RemarkAnswer.ascx");
            //}
            //else if (PageType == 14)
            //{
            //    base.LoadAControl("EvaluatePg.ascx");
            //}
            else
            {
                base.AddControl();
            }

            //if (phBody == null) return;
            //switch (GetMat)
            //{
            //    case 0:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/AddClass.ascx"));
            //        break;
            //    case 1:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/ClassList.ascx"));
            //        break;
            //    case 2:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/CommentList.ascx"));
            //        break;
            //    case 3:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/AuditingComment.ascx"));
            //        break;

            //    case 10:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/EditTem.ascx"));
            //        break;
            //}

        }

        //protected override void BindTopTags()
        //{
        //    ucTopTags.Index = (int)CurrentAdtion;
        //    ucTopTags.Title = "管理讨论区";
        //    ucTopTags.Items = "添加讨论分类,?mat=0|管理讨论分类,?mat=1|管理讨论,?mat=2|审核讨论,?mat=3";
        //}
    }
}
