using System;
using System.Collections.Specialized;
using EbSite.Control;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.WebUpFile
{
    public partial class Ctrl : ModelCtrlBase
    {
        

        public override void LoadData()
        {
            if (!IsPostBack)
            {
                StringDictionary settings = GetSettings();

                 
                if (settings.ContainsKey("txtAllowType"))
                {
                    string sSetingV = settings["txtAllowType"];
                    if (!string.IsNullOrEmpty(sSetingV))
                    {
                        tbuUploadFiles.Ext = sSetingV;
                    }
                }
                if (settings.ContainsKey("txtAllowSize"))
                {
                    string sSetingV = settings["txtAllowSize"];
                    if (!string.IsNullOrEmpty(sSetingV))
                    {
                        tbuUploadFiles.Size = int.Parse(sSetingV);
                    }
                }
                if (settings.ContainsKey("SaveFolder"))
                {
                    string sSetingV = settings["SaveFolder"];
                    if (!string.IsNullOrEmpty(sSetingV))
                    {
                        tbuUploadFiles.SaveFolder = sSetingV;
                    }
                }
                
                if (settings.ContainsKey("UploadModel"))
                {
                    string sSetingV = settings["UploadModel"];
                    if (sSetingV.Equals("1"))
                    {
                        tbuUploadFiles.UploadType = UploadFileType.单文件上传;
                    }
                    else
                    {
                        tbuUploadFiles.UploadType = UploadFileType.多文件上传;
                    }
                    
                }

            }
        }
        public override void SetValue(string sValue)
        {
            tbuUploadFiles.CtrValue = sValue;
        }

        public override string Name
        {
            get { return "WebUpFile"; }
        }

        public override string GetValue()
        {
            return tbuUploadFiles.CtrValue;
        }
    }
}