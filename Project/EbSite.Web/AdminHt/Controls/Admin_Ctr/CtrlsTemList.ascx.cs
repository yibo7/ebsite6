using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using EbSite.Base.ControlPage;
using EbSite.Base.ExtWidgets;
using EbSite.Base.ExtWidgets.ModelCtr;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Web.AdminHt.Controls.Admin_Ctr
{
    public partial class CtrlsTemList : UserControlListBase
    {
        public override string Permission
        {
            get
            {
                return "108";
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
            //return ModelCtrlUtils.GetExtensionsCtrlsType();
            return Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetTemList();
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            string sKey = ucToolBar.GetItemVal(txtKey);

            string sModuleID = ucToolBar.GetItemVal(drpWidgetCtrType);
            List<WidGetEntity> lst = new List<WidGetEntity>();
            List<WidGetEntity> lstRz = new List<WidGetEntity>();
            if (sModuleID.Equals("0"))
            {

                //lst = ModelCtrlUtils.GetExtensionsCtrlsType();
                lst = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetTemList();

            }
            else
            {
                //lst = ModelCtrlUtils.GetExtensionsCtrlsType(new Guid(sModuleID));
                lst = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetTemList(new Guid(sModuleID));
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
        //    gvCtrlsTemList.DataSource = ModelCtrlUtils.GetExtensionsCtrlsType();
        //    gvCtrlsTemList.DataBind();
        //}
        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string sModuleID = ucToolBar.GetItemVal(drpWidgetCtrType);
            if (Equals(e.CommandName, "add"))
            {
                string type = e.CommandArgument.ToString();
                Guid gID = Guid.NewGuid();

                if (sModuleID.Equals("0"))
                {
                    AddNoneModelCtr(gID, type,  Guid.Empty);
                }
                else
                {
                    AddNoneModelCtr(gID, type,  new Guid(sModuleID));
                }

                

                Response.Redirect("Admin_Ctr.aspx?t=7&id=" + gID + "&type=" + type);
            }
            else if (Equals(e.CommandName, "edittem"))
            {
                string type = e.CommandArgument.ToString();

                Response.Redirect("Admin_Ctr.aspx?t=8&id=" + type + "&type=" + type + "&modulid=" + sModuleID);
            }

        }
        /// <summary>
        /// Adds a widget of the specified type.
        /// </summary>
        /// <param name="type">The type of widget.</param>
        /// <param name="zone">The zone a widget is being added to.</param>
        private void AddNoneModelCtr(Guid ID, string type, Guid sModeulID)
        {
            string sFileName = "";

            if (sModeulID == Guid.Empty)
            {
                //sFileName = ModelCtrlUtils.GetModelCtrPath_Show(type);
                sFileName = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetPath_Show(type);
            }
            else
            {
                //sFileName = ModelCtrlUtils.GetModelCtrPath_Show(type, sModeulID);
                sFileName = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetPath_Show(type, sModeulID);
            }

            ModelCtrlBase ModelCtr = (ModelCtrlBase)LoadControl(sFileName);
            ModelCtr.DataID = ID;
            ModelCtr.ID = ModelCtr.DataID.ToString().Replace("-", string.Empty);
            ModelCtr.Title = type;
            ModelCtr.ModulID = sModeulID;

            Base.ExtWidgets.ModelCtr.DataBLL.Instance.AddData(ModelCtr.DataID, ModelCtr.Name, ModelCtr.Title, ModelCtr.ModulID);
            
            WidgetEditBase.OnSaved();
        }

        protected Control.DropDownList drpWidgetCtrType = new Control.DropDownList();
        protected Control.TextBox txtKey = new Control.TextBox();
        protected override void BindToolBar()
        {
            base.BindToolBar(true, false, true, true, false);
            Label lblTemTp = new Label();
            lblTemTp.Text = "选择模块";
            lblTemTp.ID = "lblTemTp";
            ucToolBar.AddCtr(lblTemTp);

            drpWidgetCtrType.ID = "drpWidgetCtrType";
            drpWidgetCtrType.DataSource = EbSite.BLL.ModulesBll.Modules.Instance.FillList();
            drpWidgetCtrType.DataTextField = "ModuleName";
            drpWidgetCtrType.DataValueField = "id";
            drpWidgetCtrType.DataBind();

            drpWidgetCtrType.Items.Add(new ListItem("主系统控件", "0"));
            drpWidgetCtrType.SelectedValue = "0";
            ucToolBar.AddCtr(drpWidgetCtrType);

            Label lblTemTp2 = new Label();
            lblTemTp2.Text = "控件描述";
            lblTemTp2.ID = "lblTemTp2";
            ucToolBar.AddCtr(lblTemTp2);
            txtKey.ID = "txtKey";
            ucToolBar.AddCtr(txtKey);
            base.ShowCustomSearch(" 查询 ");
        }

    }
}