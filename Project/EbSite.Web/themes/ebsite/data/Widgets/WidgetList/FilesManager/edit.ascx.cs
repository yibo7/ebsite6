using System;
using System.Collections.Specialized;
using System.Text;
using EbSite.Core.FSO;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.FilesManager
{
    public partial class edit : WidgetEditBase
    {
        private string GetUrl
        {
            get
            {
                return string.Format("{0}{1}.{2}", Base.AppStartInit.IISPath, DataID, drpFileTpye.SelectedValue);

            }
        }
        private string GetPath
        {
            get
            {
                return Server.MapPath(GetUrl);

            }
        }
        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                if (!Equals(settings, null))
                {
                    drpFileTpye.SelectedValue = settings["ftype"];
                    txtHeigth.Text = settings["iframe-h"];
                    txtWidth.Text = settings["iframe-w"];
                }
                    
                ShowBox();
                if (!string.IsNullOrEmpty(drpFileTpye.SelectedValue))
                    lbUrl.Text = string.Format("<a target=_blank href='{0}'>{0}</a>", GetUrl);

            }
            
        }
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            settings["ftype"] = drpFileTpye.SelectedValue;
            settings["iframe-h"] = txtHeigth.Text;
            settings["iframe-w"] = txtWidth.Text;
            SaveSettings(settings);

            
            
            if(drpFileEnCoder.SelectedValue=="0")
            {
                Core.FSO.FObject.WriteFile(GetPath, txtText.Text);
            }
            else
            {
                Core.FSO.FObject.WriteFile(GetPath, txtText.Text, false, Encoding.UTF8);
            }

            

        }
        private void ShowBox()
        {
            string sV = drpFileTpye.SelectedValue;

            if(!string.IsNullOrEmpty(sV))
            {
                plContent.Visible = true;

                if (sV == "html" || sV == "aspx")
                {
                    plHtml.Visible = true;
                }
                else
                {
                    plHtml.Visible = false;
                }

                string sContent = "";

                if (Core.FSO.FObject.IsExist(GetPath,FsoMethod.File))
                    sContent = Core.FSO.FObject.ReadFile(GetPath);
                StringBuilder sbHTML = new StringBuilder();
                if (!string.IsNullOrEmpty(sContent.Trim()))
                {
                    sbHTML.Append(sContent);
                }
                else
                {
                    switch (sV)
                    {
                        case "js":

                            break;
                        //case "html":



                        //    sbHTML.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n\t");
                        //    sbHTML.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\n\t");
                        //    sbHTML.Append("<head>\n\t<title>EbSite - Powered by EbSite</title>\n\t</head>\n\t<body >\n\t");
                        //    sbHTML.Append("");
                        //    sbHTML.Append("\n\t</body>\n\t</html>");

                        //    break;
                        //case "aspx":
                        //    sbHTML.Append("<%@ Page Language=\"C#\" AutoEventWireup=\"true\"  %>\n\t");
                        //    sbHTML.Append("<%@ Register Assembly=\"EbSite.Control\" Namespace=\"EbSite.Control\" TagPrefix=\"XS\" %>\n\t");
                        //    sbHTML.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                        //    sbHTML.Append("\n\t<html xmlns=\"http://www.w3.org/1999/xhtml\">");
                        //    sbHTML.Append("\n\t<head>\n\t<title>EbSite - Powered by EbSite</title>\n\t</head>\n\t<body >\n\t");
                        //    sbHTML.Append("");
                        //    sbHTML.Append("\n\t</body>\n\t</html>");
                        //    break;
                        //case "css":

                        //    break;


                    }
                }
                
                txtText.Text = sbHTML.ToString();
            }
            else
            {
                plContent.Visible = false;
            }
        }
        protected void drpFileTpye_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowBox();
        }
    }
}