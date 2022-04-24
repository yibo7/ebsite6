using System;
using System.Collections.Specialized;
using EbSite.Control;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.UploadImg
{
    public partial class Ctrl : ModelCtrlBase
    {
        

        public override void LoadData()
        {
            if (!IsPostBack)
            {
                StringDictionary settings = GetSettings();

                if (settings.ContainsKey("txtHeight"))
                {
                    string sSetingV = settings["txtHeight"];
                    if (!string.IsNullOrEmpty(sSetingV))
                    {
                        tbuUploadImg.Height = int.Parse(sSetingV);
                    }
                }
                if (settings.ContainsKey("txtWidth"))
                {
                    string sSetingV = settings["txtWidth"];
                    if (!string.IsNullOrEmpty(sSetingV))
                    {
                        tbuUploadImg.Width = int.Parse(sSetingV);
                    }
                }
                if (settings.ContainsKey("txtAllowType"))
                {
                    string sSetingV = settings["txtAllowType"];
                    if (!string.IsNullOrEmpty(sSetingV))
                    {
                        tbuUploadImg.Ext = sSetingV;
                    }
                }
                if (settings.ContainsKey("txtAllowSize"))
                {
                    string sSetingV = settings["txtAllowSize"];
                    if (!string.IsNullOrEmpty(sSetingV))
                    {
                        tbuUploadImg.Size = int.Parse(sSetingV);
                    }
                }
                if (settings.ContainsKey("SaveFolder"))
                {
                    string sSetingV = settings["SaveFolder"];
                    if (!string.IsNullOrEmpty(sSetingV))
                    {
                        tbuUploadImg.SaveFolder = sSetingV;
                    }
                }
                
                if (settings.ContainsKey("UploadModel"))
                {
                    string sSetingV = settings["UploadModel"];
                    if (sSetingV.Equals("1"))
                    {
                        tbuUploadImg.UploadType = UploadImgType.单个图片;
                    }
                    else
                    {
                        tbuUploadImg.UploadType = UploadImgType.多个图片;
                    }
                    
                }

            }
        }
        public override void SetValue(string sValue)
        {
            tbuUploadImg.CtrValue = sValue;
        }

        public override string Name
        {
            get { return "UploadImg"; }
        }

        public override string GetValue()
        {
            return tbuUploadImg.CtrValue;
        }
    }
}