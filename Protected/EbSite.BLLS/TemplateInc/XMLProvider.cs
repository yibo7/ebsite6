using System;
using System.Collections.Generic;

using System.IO;
using System.Xml;
using EbSite.Base;

namespace EbSite.BLL.TempInc
{
	/// <summary>
	/// 业务逻辑类CountData 的摘要说明。
	/// </summary>
    public class XMLProvider
	{
	    private string _ThemeName;
	    private ThemeType _ThemeType = ThemeType.PC;
        public XMLProvider(string ThemeName,ThemeType tt)
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
                //string p = string.Concat("themes\\", EbSite.Base.Host.Instance.CurrentSite.PageTheme, "\\data\\TemData\\incsetupdata");

                string p = string.Empty;

                p = string.Concat(ThemesFolder, "\\", _ThemeName, "\\data\\TemData\\incsetupdata");

                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, p);
            }
        }
        private  string CurrentLogsFolder
	    {
	        get
	        {
                //return LogsFolder + "\\TemplatesInc" + Path.DirectorySeparatorChar;
                //2012-8-14(flz)
                return string.Concat(LogsFolder, Path.DirectorySeparatorChar);
	        }
	    }
        public  EbSite.Entity.Templates SelectTemp(Guid id)
        {
            string fileName = CurrentLogsFolder + id.ToString() + ".xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            Entity.Templates model = new Entity.Templates(ThemesFolder);
            model.ID = id;
            model.TemName = doc.SelectSingleNode("Templates/TemName").InnerText;
            //model.TemPath = doc.SelectSingleNode("Templates/TemPath").InnerText;
            model.TempFileName = doc.SelectSingleNode("Templates/TempFileName").InnerText;
            model.Themes = doc.SelectSingleNode("Templates/Themes").InnerText;
            
            if (doc.SelectSingleNode("Templates/TemType") != null)
                model.TemType = int.Parse(doc.SelectSingleNode("Templates/TemType").InnerText);
            if (doc.SelectSingleNode("Templates/IsNoSysTem") != null)
                model.IsNoSysTem = bool.Parse(doc.SelectSingleNode("Templates/IsNoSysTem").InnerText);

            //if (_ThemeType == ThemeType.PC版)
            //{
            //    model.TemPath = string.Concat(Base.AppStartInit.IISPath, "themes/", _ThemeName, "/pages/", model.TempFileName);
            //}
            //else
            //{
            //    model.TemPath = string.Concat(Base.AppStartInit.IISPath, "themesm/", _ThemeName, "/pages/", model.TempFileName);
            //}
            

            return model;
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

        public  List<EbSite.Entity.Templates> FillTemps()
        {
            //string sThemes = Base.Host.Instance.CurrentSite.PageTheme;
            string sThemes = _ThemeName;
            List<EbSite.Entity.Templates> Logs = new List<EbSite.Entity.Templates>();
            foreach (string file in Directory.GetFiles(CurrentLogsFolder, "*.xml", SearchOption.TopDirectoryOnly))
            {
                FileInfo info = new FileInfo(file);
                string id = info.Name.Replace(".xml", string.Empty);
                Entity.Templates page = SelectTemp(new Guid(id));
                //只获取当前皮肤下的公共代码块 ,这个判断是不是不必要的，因为已经指定在这目录下，所以都是一个皮肤下的
                //if (page.Themes.Equals(sThemes))
                //    Logs.Add(page); 
                Logs.Add(page); 
            }

            return Logs;
        }
		
	}
}

