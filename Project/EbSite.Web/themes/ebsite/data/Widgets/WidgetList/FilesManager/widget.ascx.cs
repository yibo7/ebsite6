
using System.Collections.Specialized;
using System.Web.UI;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.FilesManager
{
    public partial class widget : WidgetBase
    {
       
        public override void LoadData()
        {
            StringDictionary settings = GetSettings();
            if (settings.ContainsKey("ftype"))
            {
                string st = settings["ftype"];
                string sContent = "";
                string sPath = string.Format("{0}Datastore/Widgets/FilesManager/{1}.{2}", Base.AppStartInit.IISPath, DataID, st);
                if (st == "html" || st == "aspx")
                {
                    
                    
                    string sh = settings["iframe-h"];
                    string sw = settings["iframe-w"];
                    sContent = string.Format("<IFRAME height={0} width={1} marginHeight=0 src=\"{2}\" frameBorder=0  marginWidth=0 scrolling=no></IFRAME>", sh, sw, sPath);
                }
                else if(st=="js")
                {
                    sContent = string.Format("<script type=\"text/javascript\" src=\"{0}\"></script>",sPath);
                }
                else if (st == "css")
                {
                    sContent = string.Format("<link type=\"text/css\" href=\"{0}\" rel=\"stylesheet\" />", sPath);
                }


                LiteralControl text = new LiteralControl(sContent);
                this.Controls.Add(text);
            }
        }

        public override string Name
        {
            get { return "FilesManager"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
    }
}