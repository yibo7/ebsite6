using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_WelCome
{
    public partial class DataReport : Base
    {
        public override string Permission
        {
            get
            {
                return "312";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //取得服务器相关信息
            servername.Text = Server.MachineName;
            serverip.Text = Request.ServerVariables["LOCAL_ADDR"];
            server_name.Text = Request.ServerVariables["SERVER_NAME"];

            //以下就是取值不准的地方，因为用了HTTP_USER_AGENT当做服务器信息。
            //1.0 final 使用Environment类属性，彻底解决了这一问题
            char[] de = {';'};
            string allhttp = Request.ServerVariables["HTTP_USER_AGENT"].ToString();
            string[] myFilename = allhttp.Split(de);
            servernet.Text = myFilename[myFilename.Length - 1].Replace(")", " ");
            int build, major, minor, revision;
            build = Environment.Version.Build;
            major = Environment.Version.Major;
            minor = Environment.Version.Minor;
            revision = Environment.Version.Revision;
            servernet.Text = ".NET CLR  " + major + "." + minor + "." + build + "." + revision;
            serverms.Text = Environment.OSVersion.ToString();
            //服务器端浏览器版本暂时不知道怎么取得，原有不准，故删除
            //1.0 final 修改
            //serverie.Text=myFilename[1];

            serversoft.Text = Request.ServerVariables["SERVER_SOFTWARE"];
            serverport.Text = Request.ServerVariables["SERVER_PORT"];
            serverout.Text = Server.ScriptTimeout.ToString();

            serverppath.Text = Request.ServerVariables["APPL_PHYSICAL_PATH"];
            servernpath.Text = Request.ServerVariables["PATH_TRANSLATED"];
            serverhttps.Text = Request.ServerVariables["HTTPS"];
            servertime.Text = DateTime.Now.ToString();


            //以下几个功能由dvnews4.0看来的。v１.1加入
            cpuc.Text = Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");
            cputype.Text = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            aspnetn.Text = getaspnetn();
            aspnetcpu.Text = getaspnetcpu();
            serverstart.Text = ((Double)System.Environment.TickCount / 3600000).ToString("N2");
            prstart.Text = getprstart();
            serverarea.Text = (DateTime.Now - DateTime.UtcNow).TotalHours > 0 ? "+" + (DateTime.Now - DateTime.UtcNow).TotalHours.ToString() : (DateTime.Now - DateTime.UtcNow).TotalHours.ToString();
            //以上几个功能由dvnews4.0看来的。

            servers.Text = Session.Contents.Count.ToString();
            servera.Text = Application.Contents.Count.ToString();
           
        }
        //自定义组件检测0.1版加入

        
        string getaspnetn()
        {
            string temp;
            try
            {
                temp = ((Double)System.Diagnostics.Process.GetCurrentProcess().WorkingSet / 1048576).ToString("N2");
            }
            catch
            {
                temp = "未知";
            }
            return temp;
        }
        string getaspnetcpu()
        {
            string temp;
            try
            {
                temp = ((TimeSpan)System.Diagnostics.Process.GetCurrentProcess().TotalProcessorTime).TotalSeconds.ToString("N0");
            }
            catch
            {
                temp = "未知";
            }
            return temp;
        }

        string getprstart()
        {
            string temp;
            try
            {
                temp = System.Diagnostics.Process.GetCurrentProcess().StartTime.ToString();
            }
            catch
            {
                temp = "未知";
            }
            return temp;
        }

        string getip()
        {
            string test = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (test == null || test == "")
            {
                test = Request.ServerVariables["REMOTE_ADDR"];
            }
            return test;
        }
    }
}