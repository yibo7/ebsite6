using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using EbSite.Core;
using EbSite.Core.FSO;

namespace EbSite.Install
{
    public class SetupBase : Page
    {
        public static readonly string producename = Utils.GetAssemblyProductName();  //当前产品版本名称

        public static readonly string footer = "";

        public static readonly string logo = "<img src=\"images/logo.jpg\" width=\"180\" height=\"300\">"; //安装的LOGO

        public static readonly string header = ""; //html页的的<head>属性

        public  string lockfile = string.Concat("/install", "/ebsite.lock");
       

        static SetupBase()
        {


            header = "<HEAD><title>安装 " + Utils.GetAssemblyProductName() + "</title><meta http-equiv=\"Content-Type\" content=\"text/html; \">\r\n";
            header += "<LINK rev=\"stylesheet\" media=\"all\" href=\"css/styles.css\" type=\"text/css\" rel=\"stylesheet\"></HEAD>\r\n";
            header += "<script language=\"javascript\" src=\"../js/jquery.js\"></script>\r\n";
            header += "<script language=\"javascript\" src=\"../js/init.js\"></script>\r\n";
            header += "<script language=\"javascript\" src=\"../js/inc.js\"></script>\r\n";
            header += "<script language=\"javascript\" src=\"../js/comm.js\"></script>\r\n";
            header += "<script language=\"javascript\" src=\"js/setup.js\"></script>\r\n";

            footer = "\r\n<br />\r\n<br /><table width=\"700\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" ID=\"Table1\">";
            footer += "<tr><td align=\"center\"><div align=\"center\" style=\"position:relative ; padding-top:60px;font-size:14px; font-family: Arial\">";
            footer += "<hr style=\"height:1; width:600; height:1; color:#CCCCCC\" />Powered by <a style=\"COLOR: #000000\" href=\"" + EbSite.Base.AppStartInit.OfficialsUrl + "\" target=\"_blank\">" + Utils.GetAssemblyProductName() + "</a>";
            footer += " &nbsp;</div></td></tr></table>";


        }

       
        #region 环境检测

        /// <summary>
        /// 系统BIN目录检查
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static string IISSystemBINCheck(ref bool error)
        {
            string binfolderpath = HttpRuntime.BinDirectory;

            string result = "";
            try
            {
                string[] assemblylist = new string[] { "EbSite.BLL.dll",  "EbSite.Control.dll", "EbSite.Core.dll", 
                    "EbSite.Data.Interface.dll",  "EbSite.Data.User.Interface.dll","EbSite.Data.User.MySql.dll", "EbSite.Entity.dll",
                      "EbSite.Base.dll","EbSite.Web.dll" };
                bool isAssemblyInexistence = false;
                ArrayList inexistenceAssemblyList = new ArrayList();
                foreach (string assembly in assemblylist)
                {
                    if (!File.Exists(binfolderpath + assembly))
                    {
                        isAssemblyInexistence = true;
                        error = true;
                        inexistenceAssemblyList.Add(assembly);
                    }
                }
                if (isAssemblyInexistence)
                {
                    foreach (string assembly in inexistenceAssemblyList)
                    {
                        result += "<tr><td bgcolor='#ffffff' width='5%'><img src='images/error.gif' width='16' height='16'></td><td bgcolor='#ffffff' width='95%'>" + assembly + " 文件放置不正确<br/>请将所有的dll文件复制到目录 " + binfolderpath + " 中.</td></tr>";
                    }
                }
                //string[] DataDll = new string[] {"EbSite.Data.SqlServer.dll", "EbSite.Data.Access.dll"};
                //bool IsDataDll = false;
                //foreach (string assembly in DataDll)
                //{
                //    if (File.Exists(binfolderpath + assembly))
                //    {
                //        IsDataDll = true;
                //        break;
                //    }
                //}

                //if(!IsDataDll)
                //{
                //    result += "<tr><td bgcolor='#ffffff' width='5%'><img src='images/error.gif' width='16' height='16'></td><td bgcolor='#ffffff' width='95%'>" + assembly + " 文件放置不正确<br/>请将所有的dll文件复制到目录 " + binfolderpath + " 中.</td></tr>";
                //}

            }
            catch
            {
                result += "<tr><td bgcolor='#ffffff' width='5%'><img src='images/error.gif' width='16' height='16'></td><td bgcolor='#ffffff' width='95%'>请将所有的dll文件复制到目录 " + binfolderpath + " 中.</td></tr>";
                error = true;
            }

            return result;
        }
        /// <summary>
        /// 检查Base.config文件的有效性
        /// </summary>
        /// <returns></returns>
        public static bool GetRootDntconfigPath()
        {
            try
            {

                HttpContext context = HttpContext.Current;
                //如果文件不存在退出
                //string webconfigpath = Path.Combine(context.Request.PhysicalApplicationPath, "dnt.config");
                string webconfigfile = "";
                if (!Utils.FileExists(webconfigfile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Base.config"))
                    && (!Utils.FileExists(webconfigfile = Utils.GetMapPath("~/dnt.config")))
                    && (!Utils.FileExists(webconfigfile = Path.Combine(context.Request.PhysicalApplicationPath, "Base.config")))
                    && (!Utils.FileExists(webconfigfile = Utils.GetMapPath("../Base.config")))
                    && (!Utils.FileExists(webconfigfile = Utils.GetMapPath("../../Base.config")))
                    && (!Utils.FileExists(webconfigfile = Utils.GetMapPath("../../../Base.config"))))
                {
                    return false;
                }
                else
                {
                    StreamReader sr = new StreamReader(webconfigfile);
                    string content = sr.ReadToEnd();
                    sr.Close();
                    content += " ";
                    StreamWriter sw = new StreamWriter(webconfigfile, false);
                    sw.Write(content);
                    sw.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool SystemFolderCheck(string foldername)
        {
            string physicsPath = Utils.GetMapPath(@"..\" + foldername);
            try
            {
                using (FileStream fs = new FileStream(physicsPath + "\\a.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    fs.Close();
                }
                if (File.Exists(physicsPath + "\\a.txt"))
                {
                    System.IO.File.Delete(physicsPath + "\\a.txt");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool SystemFileCheck(string filename)
        {
            filename = Utils.GetMapPath(@"..\" + filename);
            try
            {
                if (filename.IndexOf("systemfile.aspx") == -1 && !File.Exists(filename))
                    return false;
                if (filename.IndexOf("systemfile.aspx") != -1)  //做删除测试
                {
                    File.Delete(filename);
                    return true;
                }
                StreamReader sr = new StreamReader(filename);
                string content = sr.ReadToEnd();
                sr.Close();
                content += " ";
                StreamWriter sw = new StreamWriter(filename, false);
                sw.Write(content);
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private static bool TempTest()
        {
            string UserGuid = Guid.NewGuid().ToString();
            string TempPath = Path.GetTempPath();
            string path = TempPath + UserGuid;
            try
            {

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(DateTime.Now);
                }

                using (StreamReader sr = new StreamReader(path))
                {
                    sr.ReadLine();
                    return true;
                }


            }
            catch
            {
                return false;

            }

        }
        private static bool SerialiazeTest()
        {

            try
            {
                string sSite = EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string InitialSystemValidCheck(ref bool error)
        {
            error = false;
            StringBuilder sb = new StringBuilder();
            sb.Append("<table cellSpacing='0' cellPadding='0' width='90%' align='center' border='0' bgcolor='#666666' style='font-size:12px'>");

            HttpContext context = HttpContext.Current;

            string filename = null;
            if (context != null)
                filename = context.Server.MapPath(EbSite.Base.Host.Instance.IISPath + "Base.config");
            else
                filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Base.config");

            //系统BIN目录检查
            sb.Append(IISSystemBINCheck(ref error));


            //检查Base.config文件的有效性
            if (!GetRootDntconfigPath())
            {
                sb.Append("<tr style=\"height:15px\"><td bgcolor='#ffffff' width='5%'><img src='images/error.gif' width='16' height='16'></td><td bgcolor='#ffffff' width='95%'> Dase.config 不可写或没有放置正确, 相关问题详见安装文档!</td></tr>");
                error = true;
            }
            else
            {
                sb.Append("<tr style=\"height:15px\"><td bgcolor='#ffffff' width='5%'><img src='images/ok.gif' width='16' height='16'></td><td bgcolor='#ffffff' width='95%'>对 Base.config 验证通过!</td></tr>");
            }

            //检查系统目录的有效性
            string folderstr = "ConfigsFile,datastore";
            foreach (string foldler in folderstr.Split(','))
            {
                if (!SystemFolderCheck(foldler))
                {
                    sb.Append("<tr><td bgcolor='#ffffff' width='5%'><img src='images/error.gif' width='16' height='16'></td><td bgcolor='#ffffff' width='95%'>对 " + foldler + " 目录没有写入和删除权限!</td></tr>");
                    error = true;
                }
                else
                {
                    sb.Append("<tr><td bgcolor='#ffffff' width='5%'><img src='images/ok.gif' width='16' height='16'></td><td bgcolor='#ffffff' width='95%'>对 " + foldler + " 目录权限验证通过!</td></tr>");
                }
            }
            string filestr = "js\\init.js,install\\systemfile.aspx,ConfigsFile\\SysConfig.config";
            foreach (string file in filestr.Split(','))
            {
                if (!SystemFileCheck(file))
                {
                    sb.Append("<tr><td bgcolor='#ffffff' width='5%'><img src='images/error.gif' width='16' height='16'></td><td bgcolor='#ffffff' width='95%'>对 " + file.Substring(0, file.LastIndexOf('\\')) + " 目录没有写入和删除权限!</td></tr>");
                    error = true;
                }
                else
                {
                    sb.Append("<tr><td bgcolor='#ffffff' width='5%'><img src='images/ok.gif' width='16' height='16'></td><td bgcolor='#ffffff' width='95%'>对 " + file.Substring(0, file.LastIndexOf('\\')) + " 目录权限验证通过!</td></tr>");
                }
            }

            if (!TempTest())
            {
                sb.Append("<tr><td bgcolor='#ffffff' width='5%'><img src='images/error.gif' width='16' height='16'></td><td bgcolor='#ffffff' width='95%'>您没有对 " + Path.GetTempPath() + " 文件夹访问权限，详情参见安装文档.</td></tr>");
                error = true;
            }
            else
            {
                if (!SerialiazeTest())
                {
                    sb.Append("<tr><td bgcolor='#ffffff' width='5%'><img src='images/error.gif' width='16' height='16'></td><td bgcolor='#ffffff' width='95%'>对config文件反序列化失败，详情参见安装文档.</td></tr>");
                    error = true;
                }
                else
                {
                    sb.Append("<tr><td bgcolor='#ffffff' width='5%'><img src='images/ok.gif' width='16' height='16'></td><td bgcolor='#ffffff' width='95%'>反序列化验证通过！</td></tr>");
                }
            }
            sb.Append("</table>");

            return sb.ToString();
        }

        #endregion

       

    }
}
