using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.Control
{
    public class ExtensionsCtrls : UserControl
    {
        private Guid _ModelCtrlID;

        public Guid ModelCtrlID
        {
            get
            {
                return _ModelCtrlID;
            }
            set
            {
                _ModelCtrlID = value;
            }
        }
        private Entity.WidgetShow Model
        {
            get
            {
                return Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetEntityByID(ModelCtrlID);
                //return ModelCtrlUtils.GetCtrlByID(ModelCtrlID);
            }
        }

        public string SetFocusButtonID
        {
            get
            {
                object o = ViewState[this.ClientID + "_ExtensionsCtrls"];
                return (o == null) ? "" : o.ToString();
            }
            set
            {
                ViewState[this.ClientID + "_ExtensionsCtrls"] = value;
                
            }
        }
        public string ShowName
        {
            get
            {
                object o = ViewState["ShowName"];
                return (o == null) ? "" : o.ToString();
            }
            set
            {
                ViewState["ShowName"] = value;

            }
        }

        private string _CtrlValue;
        public string CtrlValue
        {
            get
            {
                if (!Equals(control, null))
                {
                   return control.GetValue();
                }
                return "";
            }
            set
            {
                _CtrlValue = value;
                if(!Equals(control,null))
                {
                    control.SetValue(value);
                }

            }
        }
        
        private ModelCtrlBase control = null;
        protected override void OnLoad(EventArgs e)
        {
            //Entity.WidgetShow mdWidget = ModelCtrlUtils.GetCtrlByID(ModelCtrlID);
            //if(ModelCtrlID==Guid.Empty) return;
            Entity.WidgetShow mdWidget = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetEntityByID(ModelCtrlID);

            string fileName = "";
            if (mdWidget!=null)
            {
                if (mdWidget.ModulID == Guid.Empty)
                {
                    fileName = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetPath_Show(mdWidget.TypeWidget);
                }
                else
                {
                    fileName = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetPath_Show(mdWidget.TypeWidget, mdWidget.ModulID);
                }

                if (!string.IsNullOrEmpty(ShowName))
                {
                    Label lb = new Label();
                    lb.Text = ShowName;
                    this.Controls.Add(lb);
                }

                try
                {


                    control = (ModelCtrlBase)Page.LoadControl(fileName);
                    control.DataID = Model.DataID;//new Guid(widget.Attributes["id"].InnerText);
                    control.ID = control.DataID.ToString().Replace("-", string.Empty);
                    control.Title = Model.Title;
                    //control.Zone = _ZoneName;

                    //if (control.IsEditable)
                    //    control.ShowTitle = false;//bool.Parse(widget.Attributes["showTitle"].InnerText);
                    //else
                    //    control.ShowTitle = control.DisplayHeader;
                    if (!string.IsNullOrEmpty(CtrlValue)) control.SetValue(CtrlValue);
                    control.IsOutLoad = true;//外部调用,模型调用时是内容调用 
                    control.LoadData();
                    this.Controls.Add(control);
                    if (!string.IsNullOrEmpty(_CtrlValue)) control.SetValue(_CtrlValue);
                    CtrlValue = control.GetValue();


                }
                catch (Exception ex)
                {
                    Literal lit = new Literal();
                    lit.Text = string.Format("<p style=\"color:red\">ID为{0}:<br>{1}<p>", ModelCtrlID, ex.Message);
                    //lit.Text += ex.Message;
                    //lit.Text += "<a class=\"delete\" href=\"javascript:void(0)\" onclick=\"BlogEngine.widgetAdmin.removeWidget('" + widget.Attributes["id"].InnerText + "');return false\" title=\"删除部件\">X</a>";

                    this.Controls.Add(lit);
                }
            }
            else
            {
                Literal lit = new Literal();
                lit.Text = string.Format("<p style=\"color:red\">ID为{0}:控件为null,找不到这个控件<p>", ModelCtrlID);
                
                this.Controls.Add(lit);
            }
          

        }
    }
}
