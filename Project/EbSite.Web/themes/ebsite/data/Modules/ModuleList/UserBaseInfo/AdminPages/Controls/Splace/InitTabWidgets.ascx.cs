using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Entity;

namespace EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace
{
    public partial class InitTabWidgets : MPUCBaseSave
    {
        
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("106d5cc7-8e4a-438f-9c6f-af6f3d9d51f0");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BinData();
                DropWidgets.DataTextField = "WidgetName";
                DropWidgets.DataValueField = "id";
              //  DropWidgets.DataSource = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetList();
                DropWidgets.DataSource = BLL.HomeWidget.Instance.FillList();
                DropWidgets.DataBind();
                bntAddOne.Click += new EventHandler(bntAddOne_Click);
            }
        }
        public override string Permission
        {
            get
            {
                return "6";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {

        }
        public void BinData()
        {
            List<Entity.SpaceTabDefaultWidgetInfo> ols = BLL.SpaceTabDefaultWidget.Instance.FillList();
            List<Entity.SpaceTabDefaultWidgetInfo> nls = (from c in ols where c.TabId == new Guid(SID) select c).ToList();
           
            gvData.DataSource = nls;
            gvData.DataBind();

        }
        protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (object.Equals(e.CommandName, "deletemodel"))
            {
                BLL.SpaceTabDefaultWidget.Instance.Delete(new Guid(e.CommandArgument.ToString()));
                BinData();

            }
        }
        protected void bntAddOne_Click(object sender, EventArgs e)
        {

            string txtWidgetName = DropWidgets.SelectedItem.ToString();
            string txtWidgetID = DropWidgets.CtrValue.Trim();
            string txtLayoutPane = LayoutPane.Text.Trim();

            //先要判断有没有加过
            if (IsAdd(new Guid(txtWidgetID)))
            {
                SpaceTabDefaultWidgetInfo md = new SpaceTabDefaultWidgetInfo();
                md.LayoutPane = txtLayoutPane;
                md.WidgetsID = new Guid(txtWidgetID);
                md.WidgetsName = txtWidgetName;
                md.TabId = new Guid(SID);
                BLL.SpaceTabDefaultWidget.Instance.Add(md);
            }
            else
            {
                base.ShowTipsPop("已经添加过！");
            }
            BinData();

        }

        //先要判断有没有加过
        protected bool IsAdd(Guid wid)
        {
            List<Entity.SpaceTabDefaultWidgetInfo> ols = BLL.SpaceTabDefaultWidget.Instance.FillList();
            List<Entity.SpaceTabDefaultWidgetInfo> nls = (from c in ols where c.TabId == new Guid(SID) select c).ToList();

            int icount = (from c in nls where c.WidgetsID == wid select c).Count();
            if (icount > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        override protected void SaveModel()
        {
            #region
            //foreach (ListItem li in lbWidgets.Items)
            //{
            //    if(li.Selected)
            //    {
            //        Entity.SpaceTabWidget md = new SpaceTabWidget();
            //        md.TabID = int.Parse(SID);
            //        md.WidgetID = new Guid(li.Value);
            //        md.OrderNum = 0;
            //        md.LayoutPane = "";
            //        md.UserID = 0;
            //        EbSite.BLL.SpaceTabWidget.Instance.Add(md);
            //    }
            //}
            #endregion
            base.ShowTipsPop("保存成功");
        }
    }

}