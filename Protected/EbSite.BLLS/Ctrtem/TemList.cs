using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Xml;
using EbSite.Base.Static;
using EbSite.Core.FSO;
using EbSite.Entity;
using System.Linq;
namespace EbSite.BLL.Ctrtem
{
    public class TemListInstace
    {

        public static TemList TemBll(int SiteID)
        {
            string rawKey = string.Concat("TemListInstaceTemBll", SiteID);
            TemList _Instance = Base.Host.CacheRawApp.GetCacheItem<TemList>(rawKey, "TemList");// as TemList;
            if (Equals(_Instance,null))
            {
                _Instance = new TemList(SiteID);
                Base.Host.CacheRawApp.AddCacheItem(rawKey, _Instance, 1, ETimeSpanModel.T, "TemList");
            }
            return _Instance;
        }
    }
    /// <summary>
    /// 业务逻辑类CountData 的摘要说明。
    /// </summary>
    public class TemList
    {


        private EbSite.Entity.Sites CurrentSite;
        public TemList(int siteid)
        {
            if (siteid>0)
            {
                CurrentSite = Base.Host.Instance.GetSite(siteid);
            }
            else
            {
                CurrentSite = Base.Host.Instance.CurrentSite;
            }
        }
         protected string LogsFolder
        {
            get
            {
                return CurrentSite.GetPathWidgetsTempdata(1);
            }
        }
         private string CurrentCtrTempListsFolder
        {
            get
            {
                return string.Concat(LogsFolder, Path.DirectorySeparatorChar);
            }
        }
        /// <summary>
        /// 获取模板相对路径
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         public string GetTemPath(Guid id)
        {
            return string.Concat(CurrentSite.GetPathWidgetsTemplist(0), id, ".ascx");
        }
         public string GetTemPath(string id)
        {
            if (!string.IsNullOrEmpty(id) && !Equals(id, "00000000-0000-0000-0000-000000000000"))
            {
                return string.Concat(CurrentSite.GetPathWidgetsTemplist(0), id, ".ascx");
            }
            return "";

        }
        /// <summary>
        /// 保存一个模板文件
        /// </summary>
        /// <param name="id"></param>
         private void SaveATemFile(Guid id, string TemContent)
        {
            string sTemPath = GetTemPath(id);
            sTemPath = HttpContext.Current.Server.MapPath(sTemPath);
            FObject.WriteFile(sTemPath, TemContent);

        }
        /// <summary>
        /// 删除一个模板文件
        /// </summary>
        /// <param name="id"></param>
         private void DeleteATemFile(Guid id)
        {
            string sTemPath = GetTemPath(id);
            sTemPath = HttpContext.Current.Server.MapPath(sTemPath);
            FObject.Delete(sTemPath, FsoMethod.File);
        }

        /// <summary>
        /// 读取一个模板文件信息
        /// </summary>
        /// <param name="id"></param>
         public string GetATemFileContent(Guid id)
        {
            string sTemPath = GetTemPath(id);
            sTemPath = HttpContext.Current.Server.MapPath(sTemPath);
            return FObject.ReadFile(sTemPath);
        }
         public Entity.CtrTemList SelectCtrTemLists(Guid id)
        {
            string fileName = CurrentCtrTempListsFolder + id.ToString() + ".xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            Entity.CtrTemList TempList = new Entity.CtrTemList();
            TempList.ID = id;
            TempList.Title = doc.SelectSingleNode("TempList/title").InnerText;
            TempList.Description = doc.SelectSingleNode("TempList/Description").InnerText;
            if (doc.SelectSingleNode("TempList/ClassId") != null)
                TempList.ClassId = new Guid(doc.SelectSingleNode("TempList/ClassId").InnerText);
            if (doc.SelectSingleNode("TempList/AddDate") != null)
                TempList.AddDate = DateTime.Parse(doc.SelectSingleNode("TempList/AddDate").InnerText);
            //if (doc.SelectSingleNode("TempList/ModelClassID") != null)
            //    TempList.ModelClassID = new Guid(doc.SelectSingleNode("TempList/ModelClassID").InnerText);
            return TempList;
        }
        /// <summary>
        /// 获取某个分类下的模板列表，如果ID为空，获取全部
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
         public List<CtrTemList> SelectCtrTemLists_ByClassID(Guid cid)
        {

            List<CtrTemList> lst = FillCtrTempLists();

            if (!Equals(cid, Guid.Empty))
            {
                List<CtrTemList> lstByClass = new List<CtrTemList>();
                foreach (CtrTemList temList in lst)
                {
                    if (Equals(temList.ClassId, cid))
                        lstByClass.Add(temList);
                }
                lst = lstByClass;
            }


            return lst.OrderByDescending(d => d.AddDate).ToList();


        }

         public void InsertCtrTemLists(EbSite.Entity.CtrTemList CtrTemList)
        {
            if (!Directory.Exists(CurrentCtrTempListsFolder))
                Directory.CreateDirectory(CurrentCtrTempListsFolder);

            string fileName = CurrentCtrTempListsFolder + CtrTemList.ID.ToString() + ".xml";
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(fileName, settings))
            {
                writer.WriteStartDocument(true);
                writer.WriteStartElement("TempList");

                writer.WriteElementString("title", CtrTemList.Title);
                writer.WriteElementString("ClassId", CtrTemList.ClassId.ToString());
                writer.WriteElementString("Description", CtrTemList.Description);
                writer.WriteElementString("AddDate", CtrTemList.AddDate.ToString());
                //writer.WriteElementString("ModelClassID", CtrTemList.ModelClassID.ToString());
                writer.WriteEndElement();
            }
            //同时生成一个模板文件
            SaveATemFile(CtrTemList.ID, CtrTemList.TemContent);


        }

         public void UpdateCtrTemLists(CtrTemList md)
        {
            InsertCtrTemLists(md);
        }
         public void DeleteCtrTemLists(CtrTemList TempListes)
        {
            DeleteCtrTemLists(TempListes.ID);
        }
         public void DeleteCtrTemLists(Guid ID)
        {
            string fileName = CurrentCtrTempListsFolder + ID + ".xml";
            if (File.Exists(fileName))
                File.Delete(fileName);

            //同时删除一个模板文件
            DeleteATemFile(ID);

            //if (CtrTempLists.Pages.Contains(page))
            //    CtrTempLists.Pages.Remove(page);
        }

         public List<CtrTemList> FillCtrTempLists()
        {
            // string folder = CtrTempListsFolder + CurrentCtrTempListsFolder;
            List<CtrTemList> TempListes = new List<CtrTemList>();

            foreach (string file in Directory.GetFiles(CurrentCtrTempListsFolder, "*.xml", SearchOption.TopDirectoryOnly))
            {
                FileInfo info = new FileInfo(file);
                string id = info.Name.Replace(".xml", string.Empty);
                CtrTemList ctTemp = SelectCtrTemLists(new Guid(id));

                TempListes.Add(ctTemp);
            }

            return TempListes;
        }

    }
}

