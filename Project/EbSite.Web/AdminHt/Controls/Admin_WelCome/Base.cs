using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.ControlPage;
using EbSite.Base.EntityAPI;

namespace EbSite.Web.AdminHt.Controls.Admin_WelCome
{
    public class Base : UserControlBase
    {
        protected global::EbSite.Control.Repeater rpMenus;
        public Base()
        {
           
            this.Load += new EventHandler(B_Load);
        }
        protected void B_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //List<EbSite.Base.EntityAPI.ListItemModel> lst = new List<ListItemModel>();
                //ListItemModel llm = new ListItemModel() { ID = "1", Text = "快捷菜单", Value = "Admin_WelCome.aspx" };
                //lst.Add(llm);
                //llm = new ListItemModel() { ID = "2", Text = "数据汇报", Value = "Admin_WelCome.aspx?t=2" };
                //lst.Add(llm);
                //llm = new ListItemModel() { ID = "3", Text = "服务器参数", Value = "Admin_WelCome.aspx?t=3" };
                //lst.Add(llm);
                //llm = new ListItemModel() { ID = "4", Text = "服务器插件支持", Value = "Admin_WelCome.aspx?t=4" };
                //lst.Add(llm);
                //llm = new ListItemModel() { ID = "5", Text = "流量统计", Value = "Admin_WelCome.aspx?t=5" };
                //lst.Add(llm);
                //rpMenus.DataSource = lst;
                //rpMenus.DataBind();
            }
        }
       
      
    }
}