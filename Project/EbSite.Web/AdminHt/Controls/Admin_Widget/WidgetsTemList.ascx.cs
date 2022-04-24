using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Xml;
using EbSite.Base.ControlPage;
using EbSite.Base.ExtWidgets;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Web.AdminHt.Controls.Admin_Widgets
{
    public partial class WidgetsTemList : UserControlListBase
    {
        public override string Permission
        {
            get
            {
                return "123";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }

        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            //return WidgetUtils.GetWidgetCtrList();
            return EbSite.Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetTemList();
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;

            string sKey = ucToolBar.GetItemVal(txtKey);

            string sModuleID = ucToolBar.GetItemVal(drpWidgetCtrType);
            List<WidGetEntity> lst = new List<WidGetEntity>();
            List<WidGetEntity> lstRz = new List<WidGetEntity>();
            if(sModuleID.Equals("0")) //查找某个模块下的部件
            {
                
                //lst  = WidgetUtils.GetWidgetCtrList();
                lst = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetTemList();

            }
            else if (sModuleID.Equals("1")) //查找当前皮肤(站点)下载的部件
            {
               
                //lst  = WidgetUtils.GetWidgetCtrList();
                lst = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetTemListForCurrentTheme(Base.Host.Instance.CurrentSite);

            }
            else
            {
                //lst = WidgetUtils.GetWidgetCtrList(new Guid(sModuleID));
                lst = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetTemList(new Guid(sModuleID));
            }
            foreach (WidGetEntity getEntity in lst)
            {
                if (getEntity.ReadMe.IndexOf(sKey) > -1)
                    lstRz.Add(getEntity);
            }
            
            return lstRz;
        }
        override protected void Delete(object iID)
        {
            throw new NotImplementedException();

        }
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    gvWidgetsTemList.DataSource = WidgetUtils.GetWidgetsList();
        //    gvWidgetsTemList.DataBind();
        //}
        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            //string zone = WidgetUtils.ZoneName;
            string zone = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.DefualtZoneName;
            string sModuleID = ucToolBar.GetItemVal(drpWidgetCtrType);
            if (Equals(e.CommandName, "add"))
            {
                string type = e.CommandArgument.ToString();
                
                Guid gID = Guid.NewGuid();

                
                if (sModuleID.Equals("0"))  //创建系统自带部件
                {
                    AddNoneWidget(gID, type, zone,Guid.Empty);
                }
                else //创建模块里的部件
                {
                    AddNoneWidget(gID, type, zone, new Guid(sModuleID));
                }

                Response.Redirect("Admin_Widgets.aspx?t=2&id=" + gID + "&zone=" + zone + "&type=" + type);
            }
            else if (Equals(e.CommandName, "edittem"))
            {
                string type = e.CommandArgument.ToString();

                Response.Redirect("Admin_Widgets.aspx?t=3&id=" + type + "&zone=" + zone + "&type=" + type + "&modulid=" + sModuleID);
            }
            
        }
        protected DropDownList drpWidgetCtrType = new DropDownList();
        protected TextBox txtKey = new TextBox();
        protected override void BindToolBar()
        {
            base.BindToolBar(true, false, true, true, false);
             Label lblTemTp = new Label();
            lblTemTp.Text = "选择部件来源";
             lblTemTp.ID = "lblTemTp";
             ucToolBar.AddCtr(lblTemTp);

            drpWidgetCtrType.ID = "drpWidgetCtrType";
             drpWidgetCtrType.DataSource =  EbSite.BLL.ModulesBll.Modules.Instance.FillList();
             drpWidgetCtrType.DataTextField = "ModuleName";
            drpWidgetCtrType.DataValueField = "id";
            drpWidgetCtrType.DataBind();

            drpWidgetCtrType.Items.Insert(0, new ListItem("站点部件", "0"));
            drpWidgetCtrType.SelectedValue = "0";

            //drpWidgetCtrType.Items.Insert(1, new ListItem("当前皮肤里的部件", "1"));
            //drpWidgetCtrType.SelectedValue = "0";

            ucToolBar.AddCtr(drpWidgetCtrType);
            

             lblTemTp = new Label();
             lblTemTp.Text = "部件描述";
             lblTemTp.ID = "lblTemTp";
             ucToolBar.AddCtr(lblTemTp);
             txtKey.ID = "txtKey";
             ucToolBar.AddCtr(txtKey);
             base.ShowCustomSearch(" 查询 ");
        }
        /// <summary>
        /// Adds a widget of the specified type.
        /// </summary>
        /// <param name="type">The type of widget.</param>
        /// <param name="zone">The zone a widget is being added to.</param>
        private void AddNoneWidget(Guid ID, string type, string zone,Guid sModeulID)
        {
            string sFileName = "";

            if(sModeulID==Guid.Empty)
            {
               
                sFileName = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetPath_Show(type);
            }
            else
            {
              
                sFileName = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetPath_Show(type, sModeulID);
            }

            WidgetBase widget = (WidgetBase)LoadControl(sFileName);
            widget.DataID = ID;
            widget.ID = widget.DataID.ToString().Replace("-", string.Empty);
            widget.Title = type;
            widget.Zone = zone;
            widget.ShowTitle = widget.DisplayHeader;
            widget.ModulID = sModeulID;

            Base.ExtWidgets.WidgetsManage.DataBLL.Instance.AddData(widget.DataID, widget.Name, widget.Title, widget.ModulID);
            
            WidgetEditBase.OnSaved();
            
        }


    }
}