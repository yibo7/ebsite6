using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Xml;
using EbSite.Base;
using EbSite.Core.FSO;
using EbSite.Entity;
namespace EbSite.BLL.Tem
{
	/// <summary>
	/// 业务逻辑类CountData 的摘要说明。
	/// </summary>
    public class XMLProvider 
	{

	    private string _ThemeName;
        private ThemeType _ThemeType = ThemeType.PC;
        public XMLProvider(string ThemeName, ThemeType tt)
		{
            _ThemeName = ThemeName;
            _ThemeType = tt;
		}
        private string ThemesFolder
        {
            get { return ThemesUtils.GetThemesFolder(_ThemeType); }
        }
        private  string LogsFolder
        {
            get
            {
                string p = string.Concat(ThemesFolder, "\\", _ThemeName, "\\data\\TemData\\temsetupdata");
                //string p = string.Concat(ThemesFolder, "/", _ThemeName, "/data/TemData/temsetupdata");  兼容linux可以这样写
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, p);
            }
        }
        private  string CurrentLogsFolder
        {
            get
            {
                return string.Concat(LogsFolder, Path.DirectorySeparatorChar);
            }
        }
         
        public  EbSite.Entity.Templates SelectTemp(Guid id)
        {
            string fileName = CurrentLogsFolder + id.ToString() + ".xml";
            if (Core.FSO.FObject.IsExist(fileName, FsoMethod.File))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);
                Entity.Templates model = new Entity.Templates(ThemesFolder);
                model.ID = id;
                model.TemName = doc.SelectSingleNode("Templates/TemName").InnerText;
                model.TempFileName = doc.SelectSingleNode("Templates/TempFileName").InnerText;
                model.Themes = doc.SelectSingleNode("Templates/Themes").InnerText;
                //model.TemPath = doc.SelectSingleNode("Templates/TemPath").InnerText;
                //model.ModelClassID =new Guid(doc.SelectSingleNode("Templates/ModelClassID").InnerText);
                if (doc.SelectSingleNode("Templates/TemType") != null)
                    model.TemType = int.Parse(doc.SelectSingleNode("Templates/TemType").InnerText);
                if (doc.SelectSingleNode("Templates/IsNoSysTem") != null)
                    model.IsNoSysTem = bool.Parse(doc.SelectSingleNode("Templates/IsNoSysTem").InnerText);
                if (doc.SelectSingleNode("Templates/AddDate") != null)
                    model.AddDate = DateTime.Parse(doc.SelectSingleNode("Templates/AddDate").InnerText);

                return model;
            }
            else
            {
                string hostIP = "";
                string path = "";
                string referer = "";
                string useragent = string.Empty;
                if (HttpContext.Current != null)
                {
                   
                  
                    if (Base.Configs.SysConfigs.ConfigsControl.Instance.IsOpenAppLog)
                    {
                        path = HttpContext.Current.Request.RawUrl;
                        hostIP = HttpContext.Current.Request.UserHostAddress;
                        referer = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
                        useragent = HttpContext.Current.Request.ServerVariables["http_user_agent"];
                        Entity.Logs mdLogs = new Entity.Logs();
                        mdLogs.Title = string.Concat("找不到模板数据文件，来源:", path, " 来路:", referer);
                        mdLogs.Description = string.Concat(path, "详细:\n找不到模板数据文件:", fileName, "\nUserAgent:", useragent);
                        mdLogs.IP = hostIP;
                        mdLogs.AddDate = DateTime.Now;
                        BLL.AppErrLog.InsertLogs(mdLogs);
                    }

                    AppStartInit.TipsPageRender("找不到模板数据文件", string.Format("找不到文件:{0}", fileName), AppStartInit.IISPath, 404);

                }
              
                return null;
            }
            
        }

        public  void InsertTemp(EbSite.Entity.Templates model)
        {
            if (!Directory.Exists(CurrentLogsFolder))
                Directory.CreateDirectory(CurrentLogsFolder);

            string fileName = CurrentLogsFolder + model.ID.ToString() + ".xml";
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(fileName, settings))
            {
                writer.WriteStartDocument(true);
                writer.WriteStartElement("Templates");
                writer.WriteElementString("TemName", model.TemName);
                writer.WriteElementString("Themes", model.Themes);
                writer.WriteElementString("TempFileName", model.TempFileName);
                //writer.WriteElementString("TemPath", model.TemPath);
                writer.WriteElementString("TemType", model.TemType.ToString());
                writer.WriteElementString("IsNoSysTem", model.IsNoSysTem.ToString());
                //writer.WriteElementString("ModelClassID", model.ModelClassID.ToString());
                writer.WriteElementString("AddDate", DateTime.Now.ToString());

                writer.WriteEndElement();
            }
        }

        public  void UpdateTemp(EbSite.Entity.Templates page)
        {
            InsertTemp(page);
        }
        public  void DeleteTemp(Guid ID)
        {
            string fileName = CurrentLogsFolder + ID + ".xml";
            if (File.Exists(fileName))
                File.Delete(fileName);
        }
        //public static List<EbSite.Entity.Templates> FillTemps(string themeName)
        
        public  List<EbSite.Entity.Templates> FillTemps()
        {
            //string sThemes = themeName;//Base.Host.Instance.CurrentSite.PageTheme;// EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.PageStyle;
            List<EbSite.Entity.Templates> Logs = new List<EbSite.Entity.Templates>();
            foreach (string file in Directory.GetFiles(CurrentLogsFolder, "*.xml", SearchOption.TopDirectoryOnly))
            {
                FileInfo info = new FileInfo(file);
                string id = info.Name.Replace(".xml", string.Empty);
                Entity.Templates page = SelectTemp(new Guid(id));
                //只获取当前皮肤下的模板
                //if (page.Themes.Equals(sThemes))
                //    Logs.Add(page); 
                Logs.Add(page); 
            }

            return Logs;
        }
		
	}
}

