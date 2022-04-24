//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.IO;
//using System.Xml;
//using EbSite.BLL.Log.Provider;
//using EbSite.Core.FSO;
//using EbSite.Entity;
//namespace EbSite.BLL.Log.XMLProvider
//{
//    /// <summary>
//    /// 业务逻辑类CountData 的摘要说明。
//    /// </summary>
//    public class AdminLoginLog : ILog
//    {
//        public AdminLoginLog()
//        {
//            if (!FObject.IsExist(CurrentLogsFolder, FsoMethod.Folder))
//            {
//                FObject.Create(CurrentLogsFolder, FsoMethod.Folder);
//            }
//        }
//        private string CurrentLogsFolder
//        {
//            get
//            {
//                return LogsFolder+"\\AdminLoginLog" + Path.DirectorySeparatorChar;
//            }
//        }
//        public override Entity.Logs SelectLogs(Guid id)
//        {
//            string fileName = CurrentLogsFolder + id.ToString() + ".xml";
//            XmlDocument doc = new XmlDocument();
//            doc.Load(fileName);

//            Entity.Logs logs = new Entity.Logs();
//            logs.ID = id;
//            logs.Title = doc.SelectSingleNode("Logs/title").InnerText;
//            logs.Description = doc.SelectSingleNode("Logs/description").InnerText;

//            if (doc.SelectSingleNode("Logs/AddDate") != null)
//                logs.AddDate = DateTime.Parse(doc.SelectSingleNode("Logs/AddDate").InnerText);

//            if (doc.SelectSingleNode("Logs/IP") != null)
//                logs.IP = doc.SelectSingleNode("Logs/IP").InnerText;
//            return logs;
//        }

//        public override void InsertLogs(EbSite.Entity.Logs AppLog)
//        {
//            if (!Directory.Exists(CurrentLogsFolder))
//                Directory.CreateDirectory(CurrentLogsFolder);

//            string fileName = CurrentLogsFolder + AppLog.ID.ToString() + ".xml";
//            XmlWriterSettings settings = new XmlWriterSettings();
//            settings.Indent = true;

//            using (XmlWriter writer = XmlWriter.Create(fileName, settings))
//            {
//                writer.WriteStartDocument(true);
//                writer.WriteStartElement("Logs");

//                writer.WriteElementString("title", AppLog.Title);
//                writer.WriteElementString("description", AppLog.Description);
//                writer.WriteElementString("AddDate", AppLog.AddDate.ToString());
//                writer.WriteElementString("IP", AppLog.IP);

//                writer.WriteEndElement();
//            }
//        }

//        public override void UpdateLogs(Logs page)
//        {
//            InsertLogs(page);
//        }
//        public override void DeleteLogs(Logs AppLog)
//        {
//            string fileName = CurrentLogsFolder + AppLog.ID + ".xml";
//            if (File.Exists(fileName))
//                File.Delete(fileName);

//            //if (Logs.Pages.Contains(page))
//            //    Logs.Pages.Remove(page);
//        }

//        public override List<Logs> FillLogs()
//        {
//           // string folder = LogsFolder + CurrentLogsFolder;
//            List<Logs> Logs = new List<Logs>();

//            foreach (string file in Directory.GetFiles(CurrentLogsFolder, "*.xml", SearchOption.TopDirectoryOnly))
//            {
//                FileInfo info = new FileInfo(file);
//                string id = info.Name.Replace(".xml", string.Empty);
//                Logs page = SelectLogs(new Guid(id));
//                Logs.Add(page); 
//            }

//            return Logs;
//        }
		
//    }
//}

