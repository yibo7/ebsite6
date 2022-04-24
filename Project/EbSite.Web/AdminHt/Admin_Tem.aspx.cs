using System;
using System.Collections.Generic;
using EbSite.Core;
using EbSite.Entity;
using EbSite.Pages;
using ListItemModel = EbSite.Base.EntityAPI.ListItemModel;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Tem : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            base.SetContolsPath("Admin_Tem");
          

            if (!IsPostBack)
            {
                List<ListItemModelIco> lst = new List<ListItemModelIco>();
                //ListItemModel llm = new ListItemModel() { ID = "10", Text = "模板分类", Value = "Admin_Tem.aspx?t=10" };
                //lst.Add(llm);
                ListItemModelIco llm  = new ListItemModelIco() { ID = "11", Text = "模板列表", Value =GetTabUrl(11),Ico= " fa-th-list" };
                lst.Add(llm);
                llm = new ListItemModelIco() { ID = "12", Text = "公共文件", Value = GetTabUrl(12), Ico = " fa-file" };
                lst.Add(llm);
                llm = new ListItemModelIco() { ID = "13", Text = "样式管理", Value = GetTabUrl(13), Ico = " fa-file-text-o" };
                lst.Add(llm);
                //llm = new ListItemModel() { ID = "14", Text = "用户组扩展", Value = GetTabUrl(14) };
                //lst.Add(llm);
                rpMenus.DataSource = lst;
                rpMenus.DataBind();
            }
        }
        private string GetTabUrl(int tid)
        {
            return string.Format("Admin_Tem.aspx?t={0}&tt={1}&theme={2}", tid, Request["tt"], Request["theme"]);
        }
        protected string GetCurrentClass(object id)
        {
            string st;
            if (PageType == -1)
            {
                st = "11";
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
            if(PageType==4)
            {
                //phBody.Controls.Add(LoadControl(GetControlsPath + "/EditTem.ascx"));
                base.LoadAControl("EditTem.ascx");
            }
          
            else if (PageType == 5)
            {
                //phBody.Controls.Add(LoadControl(GetControlsPath + "/ClassAdd.ascx"));
                base.LoadAControl("ClassAdd.ascx");
            }
            else if (PageType == 6)
            {
                base.LoadAControl("AddTem.ascx");
            }
            else if (PageType == 7)
            {
                base.LoadAControl("IncAdd.ascx");
            }
            else if(PageType==8)
            {
                base.LoadAControl("EditStyle.ascx");
            }
            else if (PageType == 10)
            {
                base.LoadAControl("ClassList.ascx");
            }
            else if (PageType == 11)
            {
                base.LoadAControl("TemList.ascx");
            }
            else if (PageType == 12)
            {
                base.LoadAControl("IncList.ascx");
            }
            else if (PageType == 13)
            {
                base.LoadAControl("StyleList.ascx");
            }
            //else if (PageType == 14)
            //{
            //    base.LoadAControl("UserTem.ascx");
            //}
            else
            {
                base.AddControl();
            }


        }

        //protected override void BindTopTags()
        //{
        //    ucTopTags.Index = (int)CurrentAdtion;
        //    ucTopTags.Title = "页面模板管理";
        //    ucTopTags.Items = "添加模板,?mat=0|管理模板,?mat=1|添加公共模块,?mat=2|管理公共模块,?mat=3";
        //}
    }
}
