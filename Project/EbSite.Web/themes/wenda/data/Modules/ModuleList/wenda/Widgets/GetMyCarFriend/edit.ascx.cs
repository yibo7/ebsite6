using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.BLL;
using EbSite.Control;
using EbSite.Core.Strings;
using CheckBox = System.Web.UI.WebControls.CheckBox;
using DropDownList = System.Web.UI.WebControls.DropDownList;
using ListBox = System.Web.UI.WebControls.ListBox;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace EbSite.Modules.Wenda.Widgets.GetMyCarFriend
{
    public partial class edit : WidgetEditBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override void LoadData()
        {
            if (!this.Page.IsPostBack)
            {
                StringDictionary settings = base.GetSettings();
                if (!object.Equals(settings, null))
                {
                    this.txtKey.Text = settings["txtKey"];

                }
            }

        }

        public override void Save()
        {
            base.Save();
            StringDictionary settings = base.GetSettings();
            settings["txtKey"] = this.txtKey.Text;
            this.SaveSettings(settings);
        }
    }
}