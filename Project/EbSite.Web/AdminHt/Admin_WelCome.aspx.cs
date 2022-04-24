using System;
using System.Collections.Generic;
using EbSite.Base;
using EbSite.Base.EntityAPI;
using EbSite.Core;
using EbSite.Entity;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_WelCome : EbSite.Base.Page.ManagePage
    {
        protected global::EbSite.Control.Repeater rpMenus;
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_WelCome");
            //ServerInfo sif = new ServerInfo();
            //divServerInfo.InnerHtml = sif.Info;

            if (!IsPostBack)
            {
                List<ListItemModelIco> lst = new List<ListItemModelIco>();
                ListItemModelIco llm = new ListItemModelIco() { ID = "1", Text = "快捷菜单", Value = "Admin_WelCome.aspx",Ico= "bi bi-box-arrow-left" };
                lst.Add(llm);
                //llm = new ListItemModel() { ID = "2", Text = "数据汇报", Value = "Admin_WelCome.aspx?t=2" };
                //lst.Add(llm);
                llm = new ListItemModelIco() { ID = "3", Text = "服务器参数", Value = "Admin_WelCome.aspx?t=3", Ico = "bi bi-laptop" };
                lst.Add(llm);
                llm = new ListItemModelIco() { ID = "4", Text = "服务器插件支持", Value = "Admin_WelCome.aspx?t=4", Ico = "bi bi-plugin" };
                lst.Add(llm);

                //llm = new ListItemModel() { ID = "5", Text = "流量统计", Value = "Admin_WelCome.aspx?t=5" };
                //lst.Add(llm);
                llm = new ListItemModelIco() { ID = "6", Text = "在线用户", Value = "Admin_WelCome.aspx?t=6", Ico = "bi bi-person-lines-fill" };
                lst.Add(llm);
                rpMenus.DataSource = lst;
                rpMenus.DataBind();
            }


            lbLastErr.Text = string.IsNullOrEmpty(AppStartInit.LastErr) ? "当前系统运行正常" : AppStartInit.LastErr;
        }
        protected string GetCurrentClass(object id)
        {
            string st;
            if (PageType==-1)
            {
                st = "1";
            }
            else
            {
                st = PageType.ToString();
            }
            return Core.Utils.GetCurrentClass(id, st, "", "active");
        }
        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if(PageType==2)
            {

                base.LoadAControl("DataReport.ascx");
            }
          
            else if (PageType == 3)
            {
                base.LoadAControl("ServerInfo.ascx");
            }
            else if (PageType == 4)
            {
                base.LoadAControl("ServerPlugin.ascx");
            }
            else if (PageType == 6)
            {
                base.LoadAControl("UserOnLine.ascx");
            }
            //else if (PageType == 5)
            //{
            //    base.LoadAControl("cnzz.ascx");
            //}
            else
            {
                base.LoadAControl("Index.ascx");
            }

        }

    }

    
}
