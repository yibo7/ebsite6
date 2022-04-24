using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base.Entity;
using EbSite.Core.FSO;

namespace EbSite.BLL.IISLOG
{
    public class IISLOGBll : EbSite.Base.Datastore.XMLProviderBaseInt<IISLOGEntity>
    {
       public static readonly IISLOGBll Instance = new IISLOGBll();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "iislog/"));
            }
        }
        private IISLOGBll()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
        private bool IsHave(string logname)
        {
            List<IISLOGEntity> lstLogOld = base.FillList();
            return lstLogOld.Exists(d => d.LogName.ToLower().Equals(logname.ToLower()));
        }
        public void LodingLog()
        {
            List<string> lstLogNewName = new List<string>();
            DirectoryInfo[] ChildDirectory;//子目录集
            DirectoryInfo FatherDirectory = new DirectoryInfo(SavePath); //当前目录
            ChildDirectory = FatherDirectory.GetDirectories("*.*"); //得到子目录集
            foreach (DirectoryInfo directoryInfo in ChildDirectory)
            {
                UpdateLog(string.Concat(SavePath, "\\", directoryInfo.Name, "\\"), directoryInfo.Name, ref lstLogNewName);
            }
            UpdateLog(SavePath, "", ref lstLogNewName);

            List<IISLOGEntity> lstLogOld = base.FillList();
            foreach (IISLOGEntity et in lstLogOld)
            {
                if (!lstLogNewName.Contains(et.LogName))
                {
                    base.Delete(et.id);
                }
            }
        }
        private IISLOGEntity GetByName(string logname)
        {
            IISLOGEntity md = null;
            List<IISLOGEntity> lstLogOld = base.FillList();
            foreach (IISLOGEntity et in lstLogOld)
            {
                if (et.LogName.ToLower() == logname)
                {
                    md = et;
                    break;
                }
            }
            return md;
        }
        private void UpdateLog(string sPath, string subfolder, ref List<string> lstLogNewName)
        {



            FileInfo[] list = Core.FSO.FObject.GetFileListByType(sPath, "log", true);
            
           
            foreach (FileInfo fileInfo in list)
            {
                if(fileInfo.Length>0)
                {
                    string slogname = string.Empty;
                    if (!string.IsNullOrEmpty(subfolder))
                        slogname = string.Concat(subfolder, "\\", fileInfo.Name);
                    else
                    {
                        slogname = fileInfo.Name;
                    }
                    if (!IsHave(slogname))
                    {
                        long size = (fileInfo.Length / 1024 / 1024);

                        base.Add(new IISLOGEntity() { LogName = slogname, AddDateTime = fileInfo.LastWriteTime, Size = size });
                    }
                    else
                    {
                        IISLOGEntity md = GetByName(slogname);
                        if (md != null)
                        {
                            long size = (fileInfo.Length / 1024 / 1024);
                            md.Size = size;
                            base.Update(md);
                        }

                    }
                    lstLogNewName.Add(slogname);
                }
                
            }

            
        }
        public string GetLogPath(string logname)
        {
            return string.Concat(SavePath, logname);
        }
        public void DeleteLog(int logid)
        {
            IISLOGEntity md = base.GetEntity(logid);
            string sPath = GetLogPath(md.LogName);
            if (Core.FSO.FObject.IsExist(sPath,FsoMethod.File))
            {
                FObject.Delete(sPath,FsoMethod.File);
            }
            base.Delete(logid);
        }
        public void CountInfo(int logid)
        {
            IISLOGEntity md = base.GetEntity(logid);
            string sPath = GetLogPath(md.LogName);
            if (Core.FSO.FObject.IsExist(sPath, FsoMethod.File))
            {
                //FileStream fs = new FileStream(url, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                //StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);


                List<SpiderEntity> SpiderList = SpiderBll.Instance.FillList();
                FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sReader = new StreamReader(fStream, Encoding.Default);
                string line;

                try
                {
                    while ((line = sReader.ReadLine()) != null)
                    {

                        foreach (var Spider in SpiderList)
                        {
                            if (line.IndexOf(Spider.SpiderEnName) > -1)
                            {
                                Spider.SpiderCount++;
                                break;
                            }

                        }
                    }



                }
                catch { }
                finally
                {
                    fStream.Flush();
                    fStream.Close();
                    sReader.Close();
                }

                StringBuilder sb = new StringBuilder();

                foreach (var Spider in SpiderList)
                {
                    sb.AppendFormat("{0}访问:<font color=#ff0000>{1}</font>&nbsp;", Spider.SpiderCnName, Spider.SpiderCount);
                }
                md.CountInfo = sb.ToString();
                base.Update(md);
            }
            
            
        }



    }
}
