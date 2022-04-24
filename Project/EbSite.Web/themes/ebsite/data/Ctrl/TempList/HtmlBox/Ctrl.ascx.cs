using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using EbSite.Control;
using EbSite.Core;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.HtmlBox
{
    public partial class Ctrl : ModelCtrlBase
    {


        public override void LoadData()
        {

            StringDictionary settings = GetSettings();
            if (settings.ContainsKey("drpBoxType"))
            {
                string sType = settings["drpBoxType"];
                if (!string.IsNullOrEmpty(sType))
                {
                    if (sType == "0")
                    {
                        editorBox.EditorTools = EditorToolsType.简单模式;
                    }
                    else if (sType == "1")
                    {
                        editorBox.EditorTools = EditorToolsType.简单模式;
                    }
                    else if (sType == "2")
                    {
                        editorBox.EditorTools = EditorToolsType.标准模式;
                    }
                    else
                    {
                        editorBox.EditorTools = EditorToolsType.全功能模式;
                    }

                }

            }
            if (settings.ContainsKey("txtHeight"))
            {
                string sSetingV = settings["txtHeight"];
                if (!string.IsNullOrEmpty(sSetingV))
                {
                    editorBox.Height = int.Parse(sSetingV);
                    //boxparent.Style["height"] = sSetingV+"px"; 
                }
            }
            if (settings.ContainsKey("txtWidth"))
            {
                string sSetingV = settings["txtWidth"];
                if (!string.IsNullOrEmpty(sSetingV))
                {
                    
                    editorBox.Width = int.Parse(sSetingV);

                }
            }

            //if (settings.ContainsKey("SaveFolder"))
            //{
            //    if (!string.IsNullOrEmpty(settings["SaveFolder"]))
            //        editorBox.SaveFolder = settings["SaveFolder"];
            //}
            if (settings.ContainsKey("Size"))
            {
                if (!string.IsNullOrEmpty(settings["Size"]))
                {
                    editorBox.Size = int.Parse(settings["Size"]);
                }

            }
            if (settings.ContainsKey("ExtFlash"))
            {
                editorBox.ExtFlash = settings["ExtFlash"];
            }
            if (settings.ContainsKey("ExtImg"))
            {
                editorBox.ExtImg = settings["ExtImg"];
            }
            if (settings.ContainsKey("ExtLink"))
            {
                editorBox.ExtLink = settings["ExtLink"];
            }
            if (settings.ContainsKey("ExtMedia"))
            {
                editorBox.ExtMedia = settings["ExtMedia"];
            }
            if (settings.ContainsKey("cbUbb"))
            {
                editorBox.IsUBB = Convert.ToBoolean(settings["cbUbb"]);
            }

        }
        public override string Name
        {
            get { return "HtmlBox"; }
        }
        public override void SetValue(string sValue)
        {
            editorBox.Text = sValue;
        }
        public override string GetValue()
        {
            bool IsDownfile = false;
            StringDictionary settings = GetSettings();
            if (settings.ContainsKey("cbPicAddMak"))
            {
                string sSetingV = settings["cbPicAddMak"];
                if (!string.IsNullOrEmpty(sSetingV))
                {
                    IsDownfile = bool.Parse(sSetingV);
                    //boxparent.Style["width"] = sSetingV + "px";
                }
            }



            //进度文件下载与水印处理
            string sValue = string.Empty;
            if (IsDownfile) //下载站外图片
            {
                bool IsPicMark = false;

                if (settings.ContainsKey("cbDownfile"))
                {
                    string sSetingV = settings["cbDownfile"];
                    if (!string.IsNullOrEmpty(sSetingV))
                    {
                        IsPicMark = bool.Parse(sSetingV);
                    }
                }

                HtmlDown hd = new HtmlDown();

                //hd.IsMarkImg = IsPicMark;
                //hd.MarkImgPath = Base.Configs.PicConfigs.ConfigsControl.Instance.PicPath; 
                hd.SaveFilePath = string.Concat(EbSite.Base.AppStartInit.UserUploadPath, "/htmlbox/");
                string sComplete = "";
                sValue = hd.DownloadImages(editorBox.Text, ref sComplete);
            }
            else
            {
                sValue = editorBox.Text;
            }

            return sValue;
        }
    }
}