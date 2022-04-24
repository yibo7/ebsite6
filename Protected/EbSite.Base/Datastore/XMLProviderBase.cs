using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using EbSite.Base.BLL;
using EbSite.Base.Entity;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.Base.Datastore
{
    
    [Serializable]
    public class XMLProviderBase<TYPE> : Base<TYPE, Guid> where TYPE : XmlEntityBase<Guid>, new()
    {

        public XMLProviderBase()
        {

        }
        public override Guid Add(TYPE tpMd)
        {
            if (!Directory.Exists(this.SavePath))
            {
                Directory.CreateDirectory(this.SavePath);
            }

            if(tpMd.id==Guid.Empty)
            {
                tpMd.id = Guid.NewGuid();
            }

            XmlEntityBase<Guid> ModelData = tpMd;// as XmlEntityBase
            string outputFileName = string.Concat(this.SavePath, ModelData.id, ".xml");
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(outputFileName, settings))
            {
                writer.WriteStartDocument(true);
                writer.WriteStartElement(this._DataFolder);
                foreach (PropertyInfo info in ModelData.GetFieldInfos())
                {
                    string name = info.Name;
                    if (!object.Equals(name, "GetFieldInfos") && !object.Equals(name, "GetColumNames"))
                    {
                        object obstr3 = info.GetValue(ModelData, null);
                        if (!Equals(obstr3, null))
                        {
                            writer.WriteElementString(name, obstr3.ToString());
                        }
                        else
                        {
                            writer.WriteElementString(name, "");
                        }

                    }
                }
                writer.WriteEndElement();
            }
            base.InvalidateCache();
            return ModelData.id;
        }

        public override void Delete(Guid ID)
        {
            string path = this.SavePath + ID + ".xml";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            base.InvalidateCache();
        }
       new  public void CopyData(Guid id)
        {
            TYPE md = GetEntity(id);
            md.id = Guid.NewGuid();
            Add(md);
        }
        public List<TYPE> FillList()
        {
            List<TYPE> cacheItem = new List<TYPE>();
            foreach (string str2 in Directory.GetFiles(this.SavePath, "*.xml", SearchOption.TopDirectoryOnly))
            {
                FileInfo info = new FileInfo(str2);
                string g = info.Name.Replace(".xml", string.Empty);
                TYPE entity = this.GetEntity(new Guid(g));
                cacheItem.Add(entity);
            }
            return cacheItem;

        }
        /// <summary>
        /// 检测是否存在某个记录
        /// </summary>
        /// <param name="ID">记录ID</param>
        /// <returns></returns>
        public bool IsHave(Guid ID)
        {
            string filename = string.Concat(this.SavePath, ID, ".xml");
            return Core.FSO.FObject.IsExist(filename, FsoMethod.File);
        }
        public override TYPE GetEntity(Guid id)
        {
            if (id != Guid.Empty )
            {
                string filename = string.Concat(this.SavePath, id, ".xml");
                XmlDocument document = new XmlDocument();
                document.Load(filename);
                Type type = typeof(TYPE);
                TYPE local = (TYPE)Activator.CreateInstance(type);
                //PropertyInfo[] properties = local.GetType().GetProperties();
                List<PropertyInfo> properties = local.GetFieldInfos();
                foreach (PropertyInfo info in properties)
                {
                    string name = info.Name;
                    if (!object.Equals(name, "GetFieldInfos") && !object.Equals(name, "GetColumNames"))
                    {
                        string xpath = string.Format("{0}/{1}", this._DataFolder, name);
                        if (!object.Equals(document.SelectSingleNode(xpath), null))
                        {
                            string innerText = document.SelectSingleNode(xpath).InnerText;
                            if (object.Equals(info.PropertyType, typeof(Guid)))
                            {
                                Guid guid = new Guid(innerText);
                                info.SetValue(local, Convert.ChangeType(guid, info.PropertyType), null);
                            }
                            else
                            {
                                info.SetValue(local, Convert.ChangeType(innerText, info.PropertyType), null);
                            }
                        }
                    }
                }
                return local;
            }
            else
            {
                return null;
            }

        }

        public override List<TYPE> GetListArray(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        public List<TYPE> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            RecordCount = this.lstDataList.Count;
            return PagedListExpansion.ToPagedList(this.lstDataList, PageIndex, PageSize);
        }

        public override List<TYPE> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            throw new NotImplementedException();
        }

        public override void Update(TYPE model)
        {
            this.Add(model);
        }

        private string _DataFolder
        {
            get
            {
                if (string.IsNullOrEmpty(this.DataFolder))
                {
                    Type type = typeof(TYPE);
                    return type.Name; //泛型时会在后面加上 `1,不知道为什么
                }
                return this.DataFolder;
            }
        }
        /// <summary>
        /// 保存文件夹及给xml类命名,为空将使用实体类名称,如果实体类是泛型一定要重写，否则会有出错 如 
        /// </summary>
        public virtual string DataFolder
        {
            get
            {
                return "";
            }
        }

        public List<TYPE> lstDataList
        {
            get
            {
                return this.FillList();
            }
        }

        public virtual string SavePath
        {
            get
            {
                string str = "datastore";
                return string.Concat(new object[] { Path.Combine(HttpRuntime.AppDomainAppPath, str), @"\", this._DataFolder, Path.DirectorySeparatorChar });
            }
        }

        #region  共用代码

        /// <summary>
        /// 修改时获取当前实例，并载入控件到PlaceHolder
        /// </summary>
        public void InitModifyCtr(Guid id, PlaceHolder ph)
        {
            if (!Equals(id, Guid.Empty))
            {
                TYPE mdEt = GetEntity(id);
                foreach (System.Web.UI.Control uc in ph.Controls)
                {
                    if (Equals(uc.ID, null) || !mdEt.GetColumNames().Contains(uc.ID)) continue;
                    string sValue = mdEt.GetValueForColumn(uc.ID);
                    SetValueFromControl(uc, sValue);
                }
            }
        }
        /// <summary>
        /// 获取控件里的数据映射到一个实体，接着保存这个实例到数据
        /// </summary>
        public void SaveEntityFromCtr(PlaceHolder ph, List<Base.BLL.OtherColumn> lstOtherColumn)
        {
            TYPE mdEntity = GetEntityFromCtr(ph);
            if (!Equals(lstOtherColumn, null) && lstOtherColumn.Count > 0)
            {
                foreach (Base.BLL.OtherColumn column in lstOtherColumn)
                {
                    mdEntity.SetValueForColumn(column.ColumnName, column.ColumnValue);
                }
            }
            if (!Equals(mdEntity.id, Guid.Empty))
            {
                Update(mdEntity);
            }
            else
            {
                Add(mdEntity);
            }
        }

        /// <summary>
        /// 从PlaceHolder中获取一个实例
        /// </summary>
        public TYPE GetEntityFromCtr(PlaceHolder ph)
        {
            TYPE mdEt = new TYPE();
            string sKeyID;
            if (GetIDFromCtr(ph, out sKeyID))
            {
                mdEt = GetEntity(new Guid(sKeyID));
            }
            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                string sValue = GetValueFromControl(uc);

                foreach (string column in mdEt.GetColumNames())
                {
                    if (Equals(uc.ID.ToLower(), column.ToLower()))
                    {
                        mdEt.SetValueForColumn(column, sValue);
                        break;
                    }
                }

            }
            return mdEt;
        }

        #endregion
    }


}
