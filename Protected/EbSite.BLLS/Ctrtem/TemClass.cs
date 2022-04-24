using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using EbSite.Entity;
namespace EbSite.BLL.Ctrtem
{
	/// <summary>
	/// 业务逻辑类CountData 的摘要说明。
	/// </summary>
    public class TemClass 
	{
        public TemClass()
		{
            
		}
        static protected string LogsFolder
        {
            get
            {
                //string p = "datastore/Ctrtem/TemClass";
               return EbSite.Base.Host.Instance.CurrentSite.GetPathWidgetsTempClass(1);

                //return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, p);
            }
        }
	    static private string CurrentCtrTemClasssFolder
	    {
	        get
	        {
                return string.Concat(LogsFolder, Path.DirectorySeparatorChar);
	        }
	    }
        static public  Entity.CtrTemClass SelectCtrTemClasss(Guid id)
        {
            string fileName = CurrentCtrTemClasssFolder + id.ToString() + ".xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            Entity.CtrTemClass TemClass = new Entity.CtrTemClass();
            TemClass.ID = id;
            TemClass.Title = doc.SelectSingleNode("TemClass/title").InnerText;
            TemClass.Description = doc.SelectSingleNode("TemClass/description").InnerText;

            if (doc.SelectSingleNode("TemClass/AddDate") != null)
                TemClass.AddDate = DateTime.Parse(doc.SelectSingleNode("TemClass/AddDate").InnerText);

            return TemClass;
        }

        static public void InsertCtrTemClasss(EbSite.Entity.CtrTemClass AppCtrTemClass)
        {
            if (!Directory.Exists(CurrentCtrTemClasssFolder))
                Directory.CreateDirectory(CurrentCtrTemClasssFolder);

            string fileName = CurrentCtrTemClasssFolder + AppCtrTemClass.ID.ToString() + ".xml";
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(fileName, settings))
            {
                writer.WriteStartDocument(true);
                writer.WriteStartElement("TemClass");

                writer.WriteElementString("title", AppCtrTemClass.Title);
                writer.WriteElementString("description", AppCtrTemClass.Description);
                writer.WriteElementString("AddDate", AppCtrTemClass.AddDate.ToString());

                writer.WriteEndElement();
            }
        }

        static public void UpdateCtrTemClasss(CtrTemClass page)
        {
            InsertCtrTemClasss(page);
        }
        static public void DeleteCtrTemClasss(CtrTemClass TemClasses)
        {
            string fileName = CurrentCtrTemClasssFolder + TemClasses.ID + ".xml";
            if (File.Exists(fileName))
                File.Delete(fileName);

            //if (CtrTemClasss.Pages.Contains(page))
            //    CtrTemClasss.Pages.Remove(page);
        }
        static public void DeleteCtrTemClasss(Guid ID)
        {
            string fileName = CurrentCtrTemClasssFolder + ID + ".xml";
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        static public List<CtrTemClass> FillCtrTemClasss()
        {
           // string folder = CtrTemClasssFolder + CurrentCtrTemClasssFolder;
            List<CtrTemClass> TemClasses = new List<CtrTemClass>();

            foreach (string file in Directory.GetFiles(CurrentCtrTemClasssFolder, "*.xml", SearchOption.TopDirectoryOnly))
            {
                FileInfo info = new FileInfo(file);
                string id = info.Name.Replace(".xml", string.Empty);
                CtrTemClass page = SelectCtrTemClasss(new Guid(id));
                TemClasses.Add(page); 
            }

            return TemClasses;
        }
		
	}
}

