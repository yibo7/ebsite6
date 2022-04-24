using System;

using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Log : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_Log");
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if(PageType==3)
            {
               
                base.LoadAControl("AppErrLog_Show.ascx");
            }
            else if(PageType==2)
            {

                base.LoadAControl("HtmlErrLog.ascx");
            }
            else if (PageType == 1)
            {

                base.LoadAControl("ErrInfoAdd.ascx");
            }
            else if (PageType == 4)
            {

                base.LoadAControl("SpiderList.ascx");
            }
            else if (PageType == 5)
            {

                base.LoadAControl("SpiderAdd.ascx");
            }
            else
            {
                base.AddControl();
            }

            //if (phBody == null) return;
            //switch (GetMat)
            //{
            //    case 0:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/AppErrLog.ascx"));
            //        break;
            //    case 1:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/AdminLogInLog.ascx"));
            //        break;
            //    case 2:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/HtmlErrLog.ascx"));
            //        break;
            //    case 3:
            //        phBody.Controls.Add(LoadControl(GetControlsPath + "/AppErrLog_Show.ascx"));
            //        break;
             
            //}

        }

        //protected override void BindTopTags()
        //{
        //    ucTopTags.Index = (int)CurrentAdtion;
        //    ucTopTags.Title = "日志管理";
        //    ucTopTags.Items = "系统异常日志,?mat=0|管理员登录日志,?mat=1|静态页错误生成日志,?mat=2";
        //}
    }
}
