
using System.Collections.Specialized;
using System.Web.UI;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.TextBox
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
            StringDictionary settings = GetSettings();
            if (settings.ContainsKey("content"))
            {
                LiteralControl text = new LiteralControl(settings["content"]);
                this.Controls.Add(text);
            }
        }

        public override string Name
        {
            get { return "TextBox"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
    }
}