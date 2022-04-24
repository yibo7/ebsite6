using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Json;
using EbSite.Entity;
using ListItemModel = EbSite.Base.EntityAPI.ListItemModel;

namespace EbSite.Web.AdminHt.Controls.Admin_WelCome
{
    public partial class Index : Base
    {
        public override string Permission
        {
            get
            {
                return "";
            }
        }
       
        protected void LoadList()
        {
           
            List<Entity.FastMenu> lst = BLL.FastMenu.Instance.FillList();
            List<Entity.FastMenu> nls = (from li in lst // where li.UserID==base.UserID
                                         orderby li.OrderID  //descending
                                         select li).ToList();
            rpList.DataSource =  nls;
            rpList.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                LoadList();

            }
        }
      

        //添加快捷菜单
        protected void btnAddMenu_Add(Object Sender, EventArgs e)
        {
            EbSite.Entity.FastMenu md = new FastMenu();
            md.Title = this.txtName.Text.ToString();//标题
            md.Url = this.txtUrl.Text;//URL
            md.Target = int.Parse(drpTarget.SelectedValue);
            md.OrderID = BLL.FastMenu.Instance.GetMaxID;
            md.UserID = base.UserID;
            EbSite.BLL.FastMenu.Instance.Add(md);
            LoadList();
        }
        //protected void btnAddMenu_edit(Object Sender, EventArgs e)
        //{
        //    EbSite.Entity.FastMenu md = new FastMenu();
        //    md.Title = this.txtName.Text.ToString();//标题
        //    md.Url = this.txtUrl.Text;//URL
        //    md.Target = int.Parse(drpTarget.SelectedValue);
        //    md.OrderID = BLL.FastMenu.Instance.GetMaxID;
        //    md.id = int.Parse(EdFastID.Value);
        //    md.UserID = base.UserID;
        //    EbSite.BLL.FastMenu.Instance.Update(md);
        //    LoadList();

        //}


    }
}