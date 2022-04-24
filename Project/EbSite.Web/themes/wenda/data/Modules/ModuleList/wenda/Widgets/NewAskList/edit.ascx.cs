using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Modules.Wenda.Widgets.NewAskList
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
                    txtTOP.Text = settings["txtTOP"];
                    txtBegin.Text = settings["txtBegin"];
                    txtEnd.Text = settings["txtEnd"];
                    if (!string.IsNullOrEmpty(settings["classTs"]))
                    {
                        string[] strtemp = settings["classTs"].Split(',');
                        foreach (string str in strtemp)
                        {
                            for (int i = 0; i < ChBk.Items.Count; i++)
                            {
                                if (this.ChBk.Items[i].Value == str)
                                {
                                    this.ChBk.Items[i].Selected = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            settings["txtTOP"] = txtTOP.Text.Trim();
            settings["txtBegin"] = txtBegin.Text.Trim();
            settings["txtEnd"] = txtEnd.Text.Trim();
            string s = "";

            for (int i = 0; i < ChBk.Items.Count; i++)
            {
                if (ChBk.Items[i].Selected == true)
                {
                    s += ChBk.Items[i].Value + ",";
                }
            }
            if (s.Length > 0)
                s = s.Remove(s.Length - 1, 1);
            settings["classTs"] = s;
            SaveSettings(settings);
        }

    }
}