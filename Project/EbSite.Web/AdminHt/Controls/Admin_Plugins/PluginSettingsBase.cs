﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Extension.Manager;

namespace EbSite.Web.AdminHt.Controls.Admin_Component
{
    abstract public class PluginSettingsBase : UserControlBase
    {

        abstract public ManagerExtBase ExtManager { get; }

        #region Private members

        protected string _extensionName = string.Empty;
        protected ExtensionSettings _settings = null;


        public string SettingName
        {
            get
            {
                return _extensionName;
            }
            set
            {
                _extensionName = value;
            }
        }
        public bool GenerateDeleteButton = true;
        public bool GenerateEditButton = true;
        protected int iModifyRowIndex
        {
            get
            {
                return Core.Utils.StrToInt(Request["rindex"], -1);
            }
        }
        #endregion
        protected  PlaceHolder phAddForm;
        protected global::EbSite.Control.GridView grid;
        protected global::System.Web.UI.WebControls.Label lbAddLink;
        
        public PluginSettingsBase()
        {
            this.Load += new EventHandler(PageLoad);
        }

        protected void PageLoad(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Binds settings values formatted as
        /// data table to grid view
        /// </summary>
        protected void BindGrid()
        {
            if (GenerateEditButton)
                grid.AutoGenerateEditButton = true;

            if (GenerateDeleteButton)
                grid.AutoGenerateDeleteButton = true;

            grid.DataKeyNames = new string[] { _settings.KeyField };
            grid.DataSource = _settings.GetDataTable();
            grid.DataBind();
        }


        /// <summary>
        /// 生成数据列表的头部列
        /// </summary>
       protected void CreateTemplatedGridView()
        {
            foreach (ExtensionParameter par in _settings.Parameters)
            {
                BoundField col = new BoundField();
                col.DataField = par.Name;
                col.HeaderText = par.Label;
                grid.Columns.Add(col);
            }
        }

        

        /// <summary>
        /// Deliting row in the data grid
        /// </summary>
        /// <param name="sender">Grid View</param>
        /// <param name="e">Arguments</param>
       protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int paramIndex = ParameterValueIndex(sender, e.RowIndex);

            foreach (ExtensionParameter par in _settings.Parameters)
            {
                par.DeleteValue(paramIndex);
            }
            ExtManager.SaveSettings(_extensionName, _settings);
            Response.Redirect(Request.RawUrl);
        }

        

        /// <summary>
        /// Gets a handle on grid data just before
        /// bound them to grid view
        /// </summary>
        /// <param name="sender">Grid view</param>
        /// <param name="e">Event args</param>
        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            AddConfirmDelete((GridView)sender, e);
        }

        /// <summary>
        /// Adds confirmation box to delete buttons
        /// in the data grid
        /// </summary>
        /// <param name="gv">Data grid view</param>
        /// <param name="e">Event args</param>
        protected static void AddConfirmDelete(GridView gv, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            foreach (DataControlFieldCell dcf in e.Row.Cells)
            {
                if (string.IsNullOrEmpty(dcf.Text.Trim()))
                {
                    foreach (System.Web.UI.Control ctrl in dcf.Controls)
                    {
                        LinkButton deleteButton = ctrl as LinkButton;
                        if (deleteButton != null && (deleteButton.Text == "Delete" || deleteButton.Text == "删除"))//by Spoony 09.02.11
                        {
                            deleteButton.Attributes.Add("onClick", "return confirm('确定要删除这一行吗？');");//by Spoony 09.02.11
                            break;
                        }
                    }
                    break;
                }
            }
        }
        /// <summary>
        /// Handles page changing event in the data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid.PageIndex = e.NewPageIndex;
            grid.DataSource = _settings.GetDataTable();
            grid.DataBind();
        }

        /// <summary>
        /// Editing data in the data grid
        /// </summary>
        /// <param name="sender">Grid View</param>
        /// <param name="e">Event args</param>
        protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //int paramIndex = ParameterValueIndex(sender, e.NewEditIndex);
            Response.Redirect("Admin_Component.aspx?t=1&ext=" + Request["ext"] + "&rindex=" + e.NewEditIndex);
        }

        /// <summary>
        /// Returns index of the parameter calculated 
        /// based on the page number and size
        /// </summary>
        /// <param name="sender">GridView object</param>
        /// <param name="rowindex">Index of the row in the grid</param>
        /// <returns>Index of the parameter</returns>
        private static int ParameterValueIndex(object sender, int rowindex)
        {
            int paramIndex = rowindex;
            GridView gv = (GridView)sender;
            if (gv.PageIndex > 0)
            {
                paramIndex = gv.PageIndex * gv.PageSize + rowindex;
            }
            return paramIndex;
        }
        /// <summary>
        /// 添加或修改数据
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Arguments</param>
       protected void btnAdd_Click(object sender, EventArgs e)
        {
            string sErr = "";
            if (iModifyRowIndex==-1)
            {
                if (ExtManager.IsValidForm(_settings, phAddForm, out sErr))
                {

                    ExtensionSettings st = ExtManager.GetSettingsFromPH(_settings, phAddForm, iModifyRowIndex);

                    ExtManager.SaveSettings(_extensionName, st);
                    Core.Utils.AppRestart();
                    if (_settings.IsScalar) //单条数据
                    {
                        //InfoMsg.InnerHtml = "已保存";//by Spoony 09.02.11
                        //InfoMsg.Visible = true;
                        TipsAlert("保存成功!");
                    }
                    else
                    {
                        BindGrid();
                    }
                }
            }
            else
            {
                ExtManager.UpdateOneDataOfList(_settings, phAddForm, iModifyRowIndex, _extensionName, out sErr);
            }
            

            if (!string.IsNullOrEmpty(sErr))
            {
                TipsAlert(sErr);
                //ErrorMsg.InnerHtml = sErr;
                //ErrorMsg.Visible = true;
            }
        }
    }
}