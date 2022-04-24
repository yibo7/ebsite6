using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.AdminPages
{
    public partial class BBS : MPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {

            if (PageType == 7) //添加论坛板块
            {
                base.LoadAControl("bbsconfigs_add.ascx");
            }
            else if (PageType == 8) //显示板块信息
            {
                base.LoadAControl("bbsconfigs_show.ascx");
            }
            else if (PageType == 9) //添加论坛板块
            {
                base.LoadAControl("Bbsconfigs_ChannelManer_add.ascx");
            }
            else if (PageType == 10) //添加论坛板块
            {
                base.LoadAControl("Bbsconfigs_ChannelManer_show.ascx");
            }
            else if (PageType == 11) //添加论坛板块
            {
                base.LoadAControl("BBS_Topics_gl.ascx");
            }
            else if (PageType == 12) //帖子列表
            {
                base.LoadAControl("BBS_TopicsList.ascx");
                ucTopTags.Visible = true;

            }
            else if (PageType == 13) //帖子添加
            {
                base.LoadAControl("BBS_Topics_add.ascx");

            }
            else if (PageType == 14) //帖子内容
            {
                base.LoadAControl("BBS_Topics_show.ascx");
                ucTopTags.Visible = true;
            }
            else if (PageType == 15) //帖子列表 
            {
                base.LoadAControl("BBS_hf.ascx");
            }
            else
            {
                base.AddControl();
            }

        }

    }
}