using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Exam.AdminPages
{
    public partial class Exam : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("52c1c091-eb45-431e-a880-f32e9c3593a7");
            }
        }
        public override string PageName
        {
            get
            {
                return "考试系统";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType == 1)  //插件配置
            {
                base.LoadAControl("VoteAdd.ascx");

            }
            else if (PageType == 2)
            {
                base.LoadAControl("ItemShow.ascx");
            }
            else if (PageType == 3)
            {
                base.LoadAControl("ItemAdd.ascx");
            }
            else if (PageType == 4)
            {
                base.LoadAControl("ClassAdd.ascx");
            }
            //else if (PageType == 5)
            //{
            //    base.LoadAControl("ExamClassAdd.ascx");
            //}
            //else if (PageType == 5)
            //{
            //    base.LoadAControl("InationAdd.ascx");
            //}
            else
            {
                base.AddControl();
            }
        }
    }
}