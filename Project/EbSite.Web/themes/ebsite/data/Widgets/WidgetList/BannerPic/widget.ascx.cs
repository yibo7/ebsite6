
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.BannerPic
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                StringDictionary settings = GetSettings();

                sStyle = sStyle.Replace("#w#", settings["width"]);
            }
        }
        protected string sIIsPath
        {
            get
            {
                return EbSite.Base.Host.Instance.ThemePath;
            }
        }
        public string GetFlashNum = "";
        public string SpeedStr()
        {
            StringDictionary settings = GetSettings();
            int speed = int.Parse(settings["speed"]);
            return string.Concat(" SlideShow(", 1000 * speed, ")");
        }

        public string sStyle="style=\"float:left; width:#w#px\"";
        protected string GetFlashInfo()
        {

            string strTemp = " <li><a href='#url#' target='_blank'><img src='#picurl#' width='#w#' height='#h#' alt='' /></a><span class='title'>#title#</span></li>";


            StringBuilder sb = new StringBuilder();

            StringDictionary settings = GetSettings();

            DataTable dt = GetSettingsTable();

            string tmp = "  <li class='on'>#num#</li>";
            string tmp2 = "  <li >#num#</li>";

          
          
            if (!Equals(dt, null))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        GetFlashNum += tmp.Replace("#num#", (i + 1).ToString());
                    }
                    else
                    {
                        GetFlashNum += tmp2.Replace("#num#", (i + 1).ToString());
                    }

                    sb.Append(strTemp.Replace("#url#", dt.Rows[i]["url"].ToString())
                                     .Replace("#picurl#", dt.Rows[i]["flashpath"].ToString()).Replace("#w#", settings["width"]).Replace("#h#", settings["heith"]).Replace("#title#", dt.Rows[i]["title"].ToString()));
                }
            }

            return sb.ToString();
        }


        public override List<string> InitColumns()
        {
            List<string> lst = new List<string>();
            lst.Add("flashpath");
            lst.Add("url");
            lst.Add("title");
            return lst;
        }
        public override string Name
        {
            get { return "BannerPic"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }

    }
}