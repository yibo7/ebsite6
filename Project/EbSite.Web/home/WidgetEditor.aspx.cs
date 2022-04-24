using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Base.Page;
using EbSite.Control;
using EbSite.Core.DataStore;
using EbSite.Entity;
using WidgetBoxStyle = EbSite.BLL.WidgetBoxStyle;

namespace EbSite.Web.home
{
    public partial class WidgetEditor : UserPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                drpBoxTheme.DataValueField = "id";
                drpBoxTheme.DataTextField = "StyleName";
                drpBoxTheme.DataSource = EbSite.BLL.WidgetBoxStyle.Instance.GetBoxStyleList(0);
                drpBoxTheme.DataBind();
            }
            string widget = Request.QueryString["t"];
            string id = Request.QueryString["id"];

            if (!string.IsNullOrEmpty(widget) && !string.IsNullOrEmpty(id))
                InitEditor(widget, id);

            
        }
        /// <summary>
        /// Inititiates the editor for widget editing.
        /// </summary>
        /// <param name="type">The type of widget to edit.</param>
        /// <param name="id">The id of the particular widget to edit.</param>
        /// <param name="zone">The zone the widget to be edited is in.</param>
        private void InitEditor(string type, string id)
        {
            Entity.WidgetShow md = Base.ExtWidgets.HomeWidgetManage.DataBLL.Instance.GetEntityByID(new Guid(id));//Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetEntityByID(new Guid(id));


            string fileName = "";
            if (md==null)
            {
                Tips("出错了", "找不到模块数据","");
                return;
            }
            if (md.ModulID == Guid.Empty)
            {
                fileName = Base.ExtWidgets.HomeWidgetManage.DataBLL.Instance.GetPath_Edit(type);
            }
            else
            {
                fileName = Base.ExtWidgets.HomeWidgetManage.DataBLL.Instance.GetPath_Edit(type, md.ModulID);
            }

            if (File.Exists(Server.MapPath(fileName)))
            {
                WidgetEditBase edit = (WidgetEditBase)LoadControl(fileName);
                edit.Extensiontype = ExtensionType.HomeWidget;
                edit.DataID = md.DataID;//new Guid(node.Attributes["id"].InnerText);
                edit.Title = md.Title;//node.Attributes["title"].InnerText;
                edit.ID = "widget";
                phEdit.Controls.Add(edit);
                edit.LoadData();
                btnSave.Visible = !edit.IsDisabledSave();
                edit.OnUpdateTitle = UpdateTitle;
                drpBoxTheme.SelectedValue = edit.GetBoxStyleID.ToString();

                //载入部件皮肤参数
                Entity.WidgetBoxStyle BoxStyle = WidgetBoxStyle.Instance.GetEntity(edit.GetBoxStyleID);
                if (BoxStyle!=null)
                {
                    if (!string.IsNullOrEmpty(BoxStyle.StyleColorPram)) //颜色样式
                    {
                        string[] sList = BoxStyle.StyleColorPram.Split('|');
                        for (int i = 0; i < sList.Length; i++)
                        {
                            string mdItem = sList[i];
                            phColorPram.Controls.Add(this.ParseControl(string.Concat("<div>", mdItem, ":")));
                            ColorPicker pc = new ColorPicker();
                            pc.ID = BoxStyle.CtrColorName(i.ToString());
                            pc.Color = BoxStyle.GetOneCustomColorValue(i, edit.CustomColor);
                            phColorPram.Controls.Add(pc);
                            phColorPram.Controls.Add(this.ParseControl("</div>"));
                        }
                    }
                    if (!string.IsNullOrEmpty(BoxStyle.CustomDropDownListPram))
                    {
                        List<ListItemModels> lstListItemModels = BoxStyle.CustomDropDownListPramList();
                        for (int i = 0; i < lstListItemModels.Count; i++)
                        {
                            ListItemModels drpItem = lstListItemModels[i];
                            phColorPram.Controls.Add(this.ParseControl(string.Concat("<div>", drpItem.CtrName, ":")));
                            EbSite.Control.DropDownList drpCtr = new EbSite.Control.DropDownList();
                            drpCtr.ID = drpItem.CtrID;
                            drpCtr.DataTextField = "Text";
                            drpCtr.DataValueField = "value";
                            drpCtr.DataSource = drpItem.Items;
                            drpCtr.DataBind();
                            drpCtr.SelectedValue = BoxStyle.GetOneCustomDrpValue(i, edit.CustomDropDownListPram);
                            phColorPram.Controls.Add(drpCtr);
                            phColorPram.Controls.Add(this.ParseControl("</div>"));
                        }
                    }
                    if (!string.IsNullOrEmpty(BoxStyle.CustomTextBoxPram))
                    {
                        string[] sListTextBoxPram = BoxStyle.CustomTextBoxPram.Split('|');
                        for (int i = 0; i < sListTextBoxPram.Length; i++)
                        {
                            string[] aItem = sListTextBoxPram[i].Split('=');
                            if (aItem.Length == 2)
                            {
                                string[] aTextBoxPram = aItem[1].Split('*');
                                if (aTextBoxPram.Length >= 3)
                                {
                                    phColorPram.Controls.Add(this.ParseControl(string.Concat("<div>", aItem[0], ":")));
                                    EbSite.Control.TextBox txt = new Control.TextBox();
                                    txt.ID = string.Concat("txtPram", i);
                                    if (aTextBoxPram[0] == "1")
                                        txt.TextMode = TextBoxMode.MultiLine;

                                    txt.Height = Core.Utils.StrToInt(aTextBoxPram[1], 25);
                                    txt.Width = Core.Utils.StrToInt(aTextBoxPram[2], 50);
                                    if (aTextBoxPram.Length == 4)
                                        txt.HintInfo = aTextBoxPram[3];
                                    txt.Text = BoxStyle.GetOneCustomTextBoxValue(i, edit.CustomTextBoxPram);
                                    phColorPram.Controls.Add(txt);

                                    phColorPram.Controls.Add(this.ParseControl("</div>"));
                                }

                            }

                        }
                    }
                }
                

            }
            else
            {
                throw new Exception("找不到文件:" + fileName);
            }
            if (!Page.IsPostBack)
            {
                txtTitle.Text = md.Title;
                txtTitle.Focus();
            }
        }
        private void UpdateTitle()
        {
            WidgetEditBase.ToUpdateTitle(Request.QueryString["id"], txtTitle.Text.Trim(), ExtensionType.HomeWidget);

            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "RefeshParent();", true);

        }
        private string GetColors
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (System.Web.UI.Control uc in phColorPram.Controls)
                {
                     if(uc is ColorPicker)
                     {
                         ColorPicker pc = (ColorPicker) uc;
                         sb.Append(pc.Color);
                         sb.Append(",");
                     }
                }
                if (sb.Length > 0)
                    sb.Remove(sb.Length - 1, 1);

                return sb.ToString();
            }
        }
        private string GetDrpPramValues
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (System.Web.UI.Control uc in phColorPram.Controls)
                {
                    if (uc is Control.DropDownList)
                    {
                        Control.DropDownList pc = (Control.DropDownList)uc;
                        sb.Append(pc.SelectedValue);
                        sb.Append("^");
                    }
                }
                if (sb.Length > 0)
                    sb.Remove(sb.Length - 1, 1);

                return sb.ToString();
            }
        }
        private string GetTextBoxValue
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (System.Web.UI.Control uc in phColorPram.Controls)
                {
                    if (uc is Control.TextBox)
                    {
                        EbSite.Control.TextBox txt = (Control.TextBox)uc;
                        sb.Append(txt.Text);
                        sb.Append("^");
                    }
                }
                if (sb.Length > 0)
                    sb.Remove(sb.Length - 1, 1);

                return sb.ToString();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            WidgetEditBase widget = (WidgetEditBase)FindControl("widget");
            widget.BoxStyleSaveId = new Guid(drpBoxTheme.SelectedValue);
            widget.CustomDropDownListPramSaveValue = GetDrpPramValues;
            widget.CustomColorSaveValue = GetColors;
            widget.CustomTextBoxSaveValue = GetTextBoxValue;
            if (widget != null)
                widget.Save();
            WidgetEditBase.OnSaved();


        }

        protected void drpBoxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}