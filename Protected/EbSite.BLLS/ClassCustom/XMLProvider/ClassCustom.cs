using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using EbSite.BLL.ClassCustom.Provider;
using EbSite.Entity;
namespace EbSite.BLL.ClassCustom.XMLProvider
{
	/// <summary>
	/// 业务逻辑类CountData 的摘要说明。
	/// </summary>
    public class ClassCustom : IClassCustom
	{
	    private string _sPath = "";
        public ClassCustom(string sPath)
		{
            this._sPath = sPath;
		}
	    private string CurrentLogsFolder
	    {
	        get
	        {
                return LogsFolder + "\\" + _sPath + Path.DirectorySeparatorChar;
	        }
	    }
        public override Entity.ClassCustom Select(Guid id)
        {
            string fileName = CurrentLogsFolder + id.ToString() + ".xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
           
            Entity.ClassCustom help = new Entity.ClassCustom();
            help.ID = id;
            help.Title = doc.SelectSingleNode("ClassCustom/Title").InnerText;
            help.Description = doc.SelectSingleNode("ClassCustom/description").InnerText;
            if (doc.SelectSingleNode("ClassCustom/AddDate") != null)
                help.AddDate = DateTime.Parse(doc.SelectSingleNode("ClassCustom/AddDate").InnerText);

            return help;
        }

        public override void Insert(EbSite.Entity.ClassCustom help)
        {
            if (!Directory.Exists(CurrentLogsFolder))
                Directory.CreateDirectory(CurrentLogsFolder);

            string fileName = CurrentLogsFolder + help.ID.ToString() + ".xml";
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(fileName, settings))
            {
                writer.WriteStartDocument(true);
                writer.WriteStartElement("ClassCustom");

                writer.WriteElementString("Title", help.Title);
                writer.WriteElementString("description", help.Description);
                writer.WriteElementString("AddDate", help.AddDate.ToString());

                writer.WriteEndElement();
            }
        }

        public override void Update(EbSite.Entity.ClassCustom help)
        {
            Insert(help);
        }
        public override void Delete(string id)
        {
            string fileName = CurrentLogsFolder + id + ".xml";
            if (File.Exists(fileName))
                File.Delete(fileName);

            //if (Logs.Pages.Contains(page))
            //    Logs.Pages.Remove(page);
        }

	    public override void Delete(EbSite.Entity.ClassCustom model)
        {
            Delete(model.ID.ToString());
        }

        public override List<EbSite.Entity.ClassCustom> Fills()
        {
           // string folder = LogsFolder + CurrentLogsFolder;
            List<EbSite.Entity.ClassCustom> Logs = new List<EbSite.Entity.ClassCustom>();

            foreach (string file in Directory.GetFiles(CurrentLogsFolder, "*.xml", SearchOption.TopDirectoryOnly))
            {
                FileInfo info = new FileInfo(file);
                string id = info.Name.Replace(".xml", string.Empty);
                Entity.ClassCustom page = Select(new Guid(id));
                Logs.Add(page); 
            }

            return Logs;
        }
		
	}
}

