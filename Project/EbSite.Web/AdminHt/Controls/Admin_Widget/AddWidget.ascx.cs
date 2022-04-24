using System;
using System.IO;
using System.Xml;
using EbSite.Base.ControlPage;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.BLL;
using EbSite.Core.DataStore;

namespace EbSite.Web.AdminHt.Controls.Admin_Widgets
{
    public partial class AddWidget : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "123";
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

        override protected void SaveModel()
        {
            WidgetEditBase widget = (WidgetEditBase)FindControl("widget");
            widget.BoxStyleSaveId = Guid.Empty;
            widget.CustomDropDownListPramSaveValue = "";
            widget.CustomColorSaveValue = "";
            widget.CustomTextBoxSaveValue = "";
            

            if (widget != null)
                widget.Save();
            WidgetEditBase.OnSaved();
        }

        private string zone = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.DefualtZoneName;
        protected string sWidgetTypeName;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindData();

            }
            string widget = Request.QueryString["type"];
            sWidgetTypeName = widget;
             
            string id = SID;

            if (!string.IsNullOrEmpty(Request.QueryString["zone"])) //目前没用到，以保留以后有可能使用
                zone = Request.QueryString["zone"];

            if (!string.IsNullOrEmpty(widget) && !string.IsNullOrEmpty(id))
                InitEditor(widget, id, zone);

        }
        private void BindData()
        {
            drpClass.DataTextField = "Title";
            drpClass.DataValueField = "id";
            drpClass.DataSource = BLL.ClassCustom.Provider.Factory.Widget().Fills();
            drpClass.DataBind();


            //drpTheme.DataTextField = "ThemesName";
            //drpTheme.DataValueField = "ID";
            //drpTheme.DataSource = ThemesPC.Instance.FillList();
            //drpTheme.DataBind();
        }
        /// <summary>
        /// Inititiates the editor for widget editing.
        /// </summary>
        /// <param name="type">The type of widget to edit.</param>
        /// <param name="id">The id of the particular widget to edit.</param>
        /// <param name="zone">The zone the widget to be edited is in.</param>
        private void InitEditor(string type, string id, string zone)
        {
            Entity.WidgetShow md = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetEntityByID(new Guid(id), zone);


            string fileName = "";
            if (md.ModulID == Guid.Empty)
            {
                fileName = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetPath_Edit(type);
            }
            else
            {
                fileName = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetPath_Edit(type, md.ModulID);
            }


            if (File.Exists(Server.MapPath(fileName)))
            {
                WidgetEditBase edit = (WidgetEditBase)LoadControl(fileName);
                edit.DataID = md.DataID;//new Guid(node.Attributes["id"].InnerText);
                edit.Title = md.Title;//node.Attributes["title"].InnerText;
                //edit.ThemePath = md.ThemePath;
                edit.ID = "widget";
                
                phEdit.Controls.Add(edit);
                edit.LoadData();
                bntSave.Visible = !edit.IsDisabledSave();

                edit.OnUpdateTitle = UpdateTitle;
                txtCode.Text = EbSite.Control.Widget.GetWidgetCtrCoder(md.DataID.ToString(), edit.Title);

            }
            else
            {
                throw new Exception("找不到文件:" + fileName);
            }
            if (!Page.IsPostBack)
            {
                if (md.ModulID.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    drpClass.SelectedValue = "ee2c9cb6-52cd-4678-8de0-b8e3967df7d0";
                }
                else
                {
                    drpClass.SelectedValue = "789cbcbe-77c4-452b-8598-e2481dac56e1";
                }
                txtTitle.Text = md.Title;
                txtTitle.Focus();
            }
        }
        private void UpdateTitle()
        {
            WidgetEditBase.ToUpdateTitle(Request.QueryString["id"], txtTitle.Text.Trim(), ExtensionType.Widget);
        }


    }
}