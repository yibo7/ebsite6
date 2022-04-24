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

namespace EbSite.ExtensionsCtrls.UEditor
{
    public partial class Ctrl : ModelCtrlBase
    {


        public override void LoadData()
        {

            StringDictionary settings = GetSettings();
             
            if (settings.ContainsKey("txtHeight"))
            {
                string sSetingV = settings["txtHeight"];
                if (!string.IsNullOrEmpty(sSetingV))
                {
                    ebUeditor.Height = int.Parse(sSetingV); 
                }
            }
            if (settings.ContainsKey("txtWidth"))
            {
                string sSetingV = settings["txtWidth"];
                if (!string.IsNullOrEmpty(sSetingV))
                {

                    ebUeditor.Width = int.Parse(sSetingV);

                }
            }

             

        }
        public override string Name
        {
            get { return "UEditor"; }
        }
        public override void SetValue(string sValue)
        {
            ebUeditor.CtrValue = sValue;
        }
        public override string GetValue()
        { 
            string sValue = ebUeditor.CtrValue;
            if (!string.IsNullOrEmpty(sValue))
            {
                HtmlDown hd = new HtmlDown();

                //hd.IsMarkImg = IsPicMark;
                //hd.MarkImgPath = Base.Configs.PicConfigs.ConfigsControl.Instance.PicPath; 
                hd.SaveFilePath = string.Concat(EbSite.Base.AppStartInit.UserUploadPath, "/uectrls/");
                string sComplete = "";
                return hd.DownloadImages(ebUeditor.CtrValue, ref sComplete);
            }

            return "";
        }
    }
}