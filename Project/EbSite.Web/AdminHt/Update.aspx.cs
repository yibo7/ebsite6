using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.DataProfile;
using EbSite.Base.Json;
using EbSite.Core;
using EbSite.Core.FSO;

namespace EbSite.Web.AdminHt
{
    public partial class Update : EbSite.Base.Page.ManagePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            ucPageTags.Title = "系统升级";

            //UpdateNew un = new UpdateNew();
            //bool IsHaveNewVersion = un.CheckVersion();
            //if (IsHaveNewVersion && un.VersionModel != null)
            //{
            //    if (!un.VersionModel.IsUpdate) //是否支持在线升级
            //    {
            //        compupdate.InnerHtml = string.Format("<br><br>本次升级改动过大，为了您网站数据的安全我们不建议在线升级，<a style='color:red' target=_blank href='{0}' >请到这里下载最新版本</a>,如需要我们技术人员的帮忙<a style='color:red' target=_blank href='{1}' >请点这里</a>", un.VersionModel.WebUrl, EbSite.Base.AppStartInit.OfficialsUrl);
            //        //btnUpdate.Enabled = false;
            //    }
            //    else
            //    {

            //        updateinfo.InnerHtml = string.Format("<br>您将要由<span style='color:red' >ebsite {0}</span>级到<span style='color:red' >ebsite {1}</span>，要查看本次升级更新的内容<a style='color:red'  target=_blank href='{2}' >点击这里查看</a>，同时建议升级前先备份（如果条件允许，建议到服务器上打包整个网站）<br><br>",
            //            EbSite.Base.AppStartInit.ASSEMBLY_VERSION, un.VersionModel.Version, un.VersionModel.WebUrl
            //            );


            //        #region 先在判断 UpdateTemp是存在文件 若有先del

            //        if (Core.FSO.FObject.IsExist(sSavePath, FsoMethod.Folder))
            //        {

            //            Core.FSO.FObject.DeleteFiles(sSavePath);

            //        }
            //        else
            //        {
            //            FObject.Create(sSavePath, FsoMethod.Folder);
            //        }

            //        #endregion
            //        #region
            //        string newfileurl = string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "db\\WebBakTemp\\");

            //        if (Core.FSO.FObject.IsExist(newfileurl, FsoMethod.Folder))
            //        {

            //            Core.FSO.FObject.Delete(newfileurl, FsoMethod.Folder);

            //        }
            //        #endregion

            //    }
            //}
            //else
            //{
            //    compupdate.InnerHtml = string.Format("<br><br><font color=red>你目前使用的是最新版，不用升级！</font>");
            //    btnUpdate.Enabled = false;
            //}


        }


        /// <summary>
        ///升级第5步 。将  UpdateTemp/upzip  拷到根目录 ，采用的是 解压的方法(没有OK) sFileName 没有取到值
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        static public JsonResponse CopyZip()
        {
            string fileurl = string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "UploadFile\\UpdateTemp\\unzip\\");

            Core.FSO.FObject.CopyDirectory(fileurl, Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath);
            //string fileurl = string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "UploadFile\\UpdateTemp\\");
            //string sZipName = string.Concat(fileurl, sFileName);//dli.FileName//"update2.1.zip"
            //Core.FSO.FObject.UnZipFile(sZipName, Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath);
            return new JsonResponse() { Success = true, Message = "<br><br><font size='12' color=red>恭喜,升级成功!</font><br><br>系统已经成功升级到最新版本,<span onclick='RefeshParent1()'>可以点击刷新页面体验新版功能</span>!" };
        }
        /// <summary>
        /// 升级第4 步 ，升级数据库角本
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        static public JsonResponse RunScript()
        {
            //读到主站用的什么类型的数据库
            string sql = string.Empty;
            // HttpContext.Current.Server.MapPath("UploadFile//UpdateTemp//unzip//");
            string fileurl = string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "UploadFile\\UpdateTemp\\unzip\\");
            if (EbSite.Base.Host.Instance.GetCMSDbType == "Access")
            {

            }
            else
            {
                sql = Core.FSO.FObject.ReadFile(fileurl + "sqlserver.txt").Replace("#UserName#", Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix);
            }
            DbHelperCms.Instance.ExecuteCommandWithSplitter(sql);
            //运行此角本

            return new JsonResponse() { Success = true, Message = "<br><br><font size='12' color=red>恭喜,升级成功!</font><br><br>系统已经成功升级到最新版本,可以刷新页面体验新版功能!" };
        }
        /// <summary>
        /// 升级第3步 备份要升级的文件夹 到 UpdateTemp/upzip 然后读取文件名称 
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        static public JsonResponse BakFile()
        {
            #region 备份文件

            //得到更新的文件夹名称
            string fileurl = string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath,
                                           "UploadFile\\UpdateTemp\\unzip\\");
            //开始备件原来的文件夹
            //BackupFile(GetUpdateFileNames(fileurl));//这个是复制所有文件夹的内容这个不可取
            BakCreateFolder(); //创建目录文件夹
            BakSelectFiles(); //写入文件


            #endregion
            return new JsonResponse() { Success = true, Message = "<br><br><font size='12' color=red>恭喜,升级成功!</font><br><br>系统已经成功升级到最新版本,可以刷新页面体验新版功能!" };
        }
        /// <summary>
        /// 升级第2步 解压文件 
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        static public JsonResponse UpdateSys()
        {
            try
            {

                string sZipName = string.Concat(sSavePath, sFileName);
                Core.FSO.FObject.UnZipFile(sZipName, string.Concat(sSavePath, "unzip\\"));

                return new JsonResponse() { Success = true, Message = "<br><br><font size='10' color=red>恭喜,升级成功!</font><br><br>系统已经成功升级到最新版本,可以刷新页面体验新版功能!" };
            }
            catch (Exception e)
            {
                return new JsonResponse() { Success = false, Message = "<br><br><font size='10' color=red>抱歉,升级失败!</font><br><br>" + e.Message };
            }

        }
        /// <summary>
        /// 第一步 下载升级包，下载之前 先在判断 UpdateTemp是存在文件 若有先del
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        static public JsonResponse ToUpdate()
        {

            if (dli == null)
            {
                sUrl = string.Empty;
                //sSavePath = string.Empty;
                //sFileName = string.Empty;



                DownToUpdate();
                return new JsonResponse() { Success = true, Message = "0" };
            }
            else
            {
                int iCurrentSize = dli.CurrentSize;
                int iMax = dli.MaxSize;
                iCurrentSize = (iCurrentSize * 100) / iMax;
                if (dli.IsComplete)
                {
                    dli = null;
                    return new JsonResponse() { Success = true, Message = "100" };
                }
                else
                {
                    return new JsonResponse() { Success = true, Message = iCurrentSize.ToString() };
                }

            }

        }

        static private DownLoadInfo dli;
        static private string GetFileName(string FileName)
        {
            int Index = FileName.LastIndexOf(".");
            return FileName.Substring(0, Index);
        }
        static private string sUrl = "";
        static private string sSavePath = string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "UploadFile\\UpdateTemp\\");
        static private string sFileName;
        static protected void DownToUpdate()
        {

            
            //UpdateNew un = new UpdateNew();
            //bool IsHaveNewVersion = un.CheckVersion();
            //if (IsHaveNewVersion && un.IsUpdate) //是否有新版本，并且可以在线升级
            //{
            //    sUrl = un.VersionModel.PathUrl;

            //    Thread CurrentThread = new Thread(DownZip);
            //    CurrentThread.Start();


            //}


        }

        static public void DownZip()
        {
            DownLoads mt = new DownLoads(2, sUrl, sSavePath);
            mt.FileName = GetFileName(Path.GetFileName(sUrl)); //保存的文件名
            mt.Start();

            dli = new DownLoadInfo();
            dli.MaxSize = (int)mt.FileSize;
            dli.FileName = Path.GetFileName(sUrl);
            sFileName = dli.FileName;
            while (!mt.IsComplete)
            {
                if (dli != null)
                {
                    dli.CurrentSize = mt.DownloadSize;
                    dli.IsComplete = mt.IsComplete;
                }
            }
        }
        /// <summary>
        /// 得到指定目录下的文件夹名称集合
        /// </summary>
        /// <returns></returns>
        static string GetUpdateFileNames(string fileurl)
        {
            string filenames = "";
            DataTable dt = Core.FSO.FObject.getDirectoryInfos(fileurl, FsoMethod.Folder);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                filenames += dt.Rows[i]["name"] + ",";
            }
            if (filenames.Length > 0)
            {
                filenames = filenames.Remove(filenames.Length - 1, 1);
            }
            return filenames;
        }
        /// <summary>
        /// 先备份要升级的文件夹,放到 db/webbak/中 日期来命名 ZIP
        /// </summary>
        /// <param name="files">要升级的文件夹名称</param>
        static void BackupFile(string files)
        {
            string[] FileArry = Core.Strings.cConvert.SplitArray(files, ',');
            string oldfileurl = "";

            string newfileurl = string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "db//WebBakTemp//");
            //先要创建临时文件夹
            Core.FSO.FObject.Create(newfileurl, FsoMethod.Folder);
            for (int i = 0; i < FileArry.Length; i++)
            {
                oldfileurl = string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, FileArry[i]);
                //先把文件复制到 db\WebBak
                Core.FSO.FObject.CopyDirectory(oldfileurl, newfileurl + FileArry[i]);
            }
            //然后把文件给备份成 zip
            string sTarget = string.Format(string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "db//WebBak//") + "{0}.zip", DateTime.Now.ToString("yyyyMMddHHmmss"));
            Core.FSO.FObject.ZipFile(newfileurl, sTarget);

            //然后把转移的文件给删除         
            Core.FSO.FObject.Delete(newfileurl, FsoMethod.Folder);
        }


        /// <summary>
        /// 备份 目录中的一部分文件夹（根据解压文件中的目录为依据）
        /// </summary>
        static void BakCreateFolder()
        {
            string filenames = "";
            string fileurl = string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "UploadFile\\UpdateTemp\\unzip\\");
            DataTable dt = Core.FSO.FObject.getDirectoryAllInfos(fileurl, FsoMethod.Folder);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                filenames += dt.Rows[i]["path"].ToString().Replace(fileurl, "") + dt.Rows[i]["name"] + ",";
            }
            if (filenames.Length > 0)
            {
                filenames = filenames.Remove(filenames.Length - 1, 1);
            }

            string[] FileArry = Core.Strings.cConvert.SplitArray(filenames, ',');

            string newfileurl = string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "db\\WebBakTemp\\");
            //先要创建临时文件夹
            Core.FSO.FObject.Create(newfileurl, FsoMethod.Folder);
            for (int i = 0; i < FileArry.Length; i++)
            {
                Core.FSO.FObject.Create(newfileurl + FileArry[i], FsoMethod.Folder);
            }

        }
        /// <summary>
        /// 备份 目录中的一部分文件（根据解压文件中的目录为依据）
        /// </summary>
        static void BakSelectFiles()
        {
            string filenames = "";
            string fileurl = string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "UploadFile\\UpdateTemp\\unzip\\");
            DataTable dt = Core.FSO.FObject.getDirectoryAllInfos(fileurl, FsoMethod.File);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                filenames += dt.Rows[i]["path"].ToString().Replace(fileurl, "") + dt.Rows[i]["name"] + ",";
            }
            if (filenames.Length > 0)
            {
                filenames = filenames.Remove(filenames.Length - 1, 1);
            }

            string[] FileArry = Core.Strings.cConvert.SplitArray(filenames, ',');
            string oldfileurl = "";
            string newfileurl = string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "db\\WebBakTemp\\");
            //先要创建临时文件夹
            // Core.FSO.FObject.Create(newfileurl, FsoMethod.Folder);
            for (int i = 0; i < FileArry.Length; i++)
            {
                oldfileurl = string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, FileArry[i]);

                if (Core.FSO.FObject.IsExist(oldfileurl, FsoMethod.File))
                {
                    //先把文件复制到 db\WebBak\gfsf\sf\a.txt
                    Core.FSO.FObject.CopyFile(oldfileurl, newfileurl + FileArry[i]);
                }


            }
            //然后把文件给备份成 zip
            string sTarget = string.Format(string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "db\\WebBak\\") + "{0}.zip", DateTime.Now.ToString("yyyyMMddHHmmss"));
            Core.FSO.FObject.ZipFile(newfileurl, sTarget);

            //然后把转移的文件给删除         
            Core.FSO.FObject.Delete(newfileurl, FsoMethod.Folder);
        }

    }
}