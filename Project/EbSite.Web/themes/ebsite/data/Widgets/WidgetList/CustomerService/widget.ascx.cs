using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.CustomerService
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {

                StringDictionary settings = GetSettings();
                if (!Equals(settings,null))
                {
                    if (settings.ContainsKey("Themes"))
                    {
                        sTheme = settings["Themes"];

                    }
                    if (settings.ContainsKey("Float"))
                    {
                        sFloat = settings["Float"];

                    }
                    if (settings.ContainsKey("Chatonline"))
                    {
                        sChatonline = settings["Chatonline"];

                    }
                    if (settings.ContainsKey("IsClose"))
                    {
                        if (!string.IsNullOrEmpty(settings["IsClose"]))
                        IsColse = bool.Parse(settings["IsClose"]);

                    }
                    if(!IsColse)
                    {

                        DataTable dt = GetSettingsTable();
                        StringBuilder sbQQ = new StringBuilder();
                        StringBuilder sbWW = new StringBuilder();
                        string sTem = "<div><a href='{2}' {3}><img border='0' SRC='{0}' alt='点击这里给我发消息' align='absmiddle'> </a><br><a href='{2}' {3}>{1}</a></div>";
                        foreach (DataRow dr in dt.Rows)
                        {
                            string sTm = dr["Tms"].ToString();
                            string sTmUser = dr["TmUserName"].ToString();
                            string sUserName = dr["ServiceName"].ToString();
                            if (Equals(sTm, "0"))
                            {
                                sbQQ.AppendFormat(sTem, string.Format("http://wpa.qq.com/pa?p=1:{0}:17", sTmUser), sUserName, string.Format("tencent://message/?uin={0}&Menu=yes", sTmUser), "");
                            }
                            else if (Equals(sTm, "1"))
                            {
                                sbWW.AppendFormat(sTem, string.Format("http://amos1.taobao.com/online.ww?v=2&uid={0}&s=2", sTmUser), sUserName, string.Format("http://amos1.taobao.com/msg.ww?v=2&uid={0}&s=2", sTmUser), "target='_blank'");
                            }
                        }
                        string sTemHeader = "<tr><td class='CustomerService'>{0}</td></tr>";
                        if (sbQQ.Length > 0)
                        {
                            sQQHTML = string.Format(sTemHeader, sbQQ);
                        }
                        if (sbWW.Length > 0)
                        {
                            sWWHTML = string.Format(sTemHeader, sbWW);
                        }
                        
                    }
                    
                }
                 
            }
        }
        protected string sIIsPath
        {
            get
            {
                return EbSite.Base.Host.Instance.ThemePath;       
            }
        }
        protected string sTheme = "orange";
        protected string sFloat = "right";
        protected string sQQHTML = "";
        protected string sWWHTML = "";
        protected string sChatonline = "";
        protected bool IsColse = false;
        protected string GetJs()
        {
            string sStyle = "";
            
            if (!IsColse)
            {
                
                string sJs =
                    string.Format(
                        "<script>var qqs=\"{0}\"; var wws=\"{1}\";var themes = \"{2}data/Widgets/WidgetList/CustomerService/themes/{3}/\";var sFloat = \"{4}\";var sChatonline = \"{5}\";</script><SCRIPT language=javascript src=\"{2}data/Widgets/WidgetList/CustomerService/js/main.js\"></SCRIPT>",
                        sQQHTML, sWWHTML, sIIsPath,sTheme, sFloat, sChatonline
                        );
                 sStyle =
                    string.Concat("<style>.CustomerService {display:block;text-align:center;	background-image: url(", sIIsPath, "data/Widgets/WidgetList/CustomerService/themes/", sTheme, "/content.gif);color:#000; vertical-align:top;};.CustomerService div{padding-top:5px; line-height:20px;}</style>", sJs);
            }

            return sStyle;
        }
        /// <summary>
        /// 返回部件数据构成所需要列格式
        /// </summary>
        /// <returns></returns>
        public override List<string> InitColumns()
        {
            List<string> lst = new List<string>();
            lst.Add("Tms");
            lst.Add("ServiceName");
            lst.Add("TmUserName");
            lst.Add("Email");
            return lst;
        }
        public override string Name
        {
            get { return "CustomerService"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
        
    }
}