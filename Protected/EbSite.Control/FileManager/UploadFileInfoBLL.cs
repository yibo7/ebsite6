using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using EbSite.Base.Datastore;
using EbSite.Core;
using EbSite.Core.FSO;

namespace EbSite.Control.FileManager
{
    /// <summary>
    /// 将上传的文件记录下来
    /// </summary>
    [Serializable]
    public class UploadFileInfoBLL : XMLProviderBase<UploadFileInfo>
    {
        public void UpdataToSave(Guid sGid)
        {
            UploadFileInfo entity = base.GetEntity(sGid);
            entity.IsSave = true;
            base.Update(entity);
        }
        public void DeleteDataAndFile(Guid sGid)
        {
            UploadFileInfo entity = base.GetEntity(sGid);
            string SaveUrl = HttpContext.Current.Server.MapPath(entity.FileNewName);

            if(Core.FSO.FObject.IsExist(SaveUrl,FsoMethod.File))
            {
                Core.FSO.FObject.Delete(SaveUrl, FsoMethod.File);
            }
            base.Delete(sGid);
        }
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(this.sPath);
            }
        }
        public List<UploadFileInfo> GetListPages(int PageIndex, int PageSize, out int RecordCount,bool IsUsed)
        {
           
            List<UploadFileInfo> lst = new List<UploadFileInfo>();

            foreach (UploadFileInfo fileInfo in this.lstDataList)
            {
                if (IsUsed)
                {
                    if (fileInfo.IsSave)
                    {
                        lst.Add(fileInfo);
                    }
                }
                else
                {
                    if (!fileInfo.IsSave)
                    {
                        lst.Add(fileInfo);
                    }
                }
                
            }
            RecordCount = lst.Count;
            return PagedListExpansion.ToPagedList(lst, PageIndex, PageSize);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RecordCount"></param>
        /// <param name="itype">时间类别,0为所有，1为今天，2为本周，3为本月</param>
        /// <param name="sName">文件名称，为空时表示所有</param>
        /// <returns></returns>
        public List<UploadFileInfo> GetListPages(int PageIndex, int PageSize, out int RecordCount, int itype,string sName,bool IsUsed)
        {
            List<UploadFileInfo> lstSoure = GetListPages(PageIndex, PageSize, out RecordCount, IsUsed);
            
            List<UploadFileInfo> lst = new List<UploadFileInfo>();
            if (itype > 0)
            {
                foreach (UploadFileInfo fileInfo in lstSoure)
                {

                    DateTime dtEnd = DateTime.Now;
                    DateTime dtStart = fileInfo.AddDate;
                    long sp = Core.Strings.cConvert.DateDiff("d", dtStart, dtEnd);
                   
                    if (itype == 1)
                    {
                        if (sp < 1)  //今天)
                            lst.Add(fileInfo);
                    }
                    else if (itype == 2) //本周
                    {
                        if (sp < 7)
                            lst.Add(fileInfo);
                    }
                    else if (itype == 3)
                    {
                        if (sp < 30)
                            lst.Add(fileInfo);
                    }

                }
            }
            else
            {
                lst = lstSoure;
            }

            List<UploadFileInfo> lstRz = new List<UploadFileInfo>();

            if (!string.IsNullOrEmpty(sName))
            {
                foreach (UploadFileInfo fileInfo in lst)
                {
                    if (fileInfo.FileOldName.IndexOf(sName) > -1)
                    {
                        lstRz.Add(fileInfo);
                    }
                }
                
            }
            else
            {
                lstRz = lst;
            }

            RecordCount = lstRz.Count;
            return lstRz;
        }

        public string sPath
        {
            get
            {
                return (Base.AppStartInit.IISPath + "DataStore/UploadFileData/");
            }
        }
    }
}
