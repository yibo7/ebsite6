using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.JsonList
{
    public partial class edit : WidgetEditBase
    {
        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                if (!Equals(settings, null))
                {
                    txtJsonUrl.Text = settings["txtJsonUrl"];
                    drpTem.CtrlValue = settings["txtTem"];
                    drpEndc.SelectedValue = settings["Endc"];
                    drpPostGet.SelectedValue = settings["PostGet"];


                    txtDeMo.Text = @"<XS:Widget WidgetName=""调用外部Json演示""   ID=""wdTest"" WidgetID=""5f817aed-a526-445e-a375-a4409fbf9258"" runat=""server""/> 
    <script language=""c#"" runat=""server"">
        private void Page_Load(object sender, System.EventArgs e)
        {
            base.Page_Load(sender, e);
            wdTest.Pram = string.Concat(""key="", PramTest);
        }
    </script>";
                }
                 
            }


        }
        

        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            settings["txtJsonUrl"] = txtJsonUrl.Text;
            settings["txtTem"] = drpTem.CtrlValue;
            settings["Endc"] = drpEndc.SelectedValue;
            settings["PostGet"] = drpPostGet.SelectedValue;

            SaveSettings(settings);
        }

    }
}