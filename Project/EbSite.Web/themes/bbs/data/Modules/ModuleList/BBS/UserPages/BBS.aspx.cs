using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.UserPages
{
    public partial class BBS : MPageForUer
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        /// <summary>
        /// 自定义模板页，目前只能应用于路由,不能应用于单独页面
        /// </summary>
        protected override string MasterPagePath
        {
            get
            {
                return "index.Master";
            }
        }
        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {

            if (PageType == 1) //帖子列表
            {
                base.LoadAControl("BBS_TopicsList.ascx");

            }
            else if (PageType == 2) //子分类的列表
            {
                base.LoadAControl("bbslist.ascx");

            }
            else if(PageType==3)
            {
                base.LoadAControl("BBS_Topics_show.ascx");
            }
            else if(PageType==4)
            {
                base.LoadAControl("BBS_Topics_add.ascx");
            }
            else if(PageType==5)
            {
                base.LoadAControl("BBS_NewTopice.ascx");
            }
            
            else
            {
                base.AddControl();
            }

        }

    }
}