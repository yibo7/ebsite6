using System;
using System.Collections.Generic;
using System.IO;

using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Modules;
using EbSite.Base.Modules.Configs;
using EbSite.Base.Static;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Entity;
using System.Linq;
namespace EbSite.BLL.ModulesBll
{

    /// <summary>
    /// 业务逻辑类Templates 的摘要说明。
    /// </summary>
    public class Modules : Base.Datastore.XMLProviderBase<ModuleInfo>
    {
        public static readonly Modules Instance = new Modules();
        const double cachetime = 200.0;//
        private const string CacheModules = "modules"; //private readonly string[] MasterCacheKeyArray = { "Modules" };
        //private  CacheManager bllCache;

        public override string SavePath
        {
            get
            {
                //模块不能从站点去获取，因为模块是可以跨站点调用的,如果从当前站点访问另外一个站点时，会出现当前站点未安装模块而找不到模块安装数据的情况
                //所以目前中能从url中去获取模块的安装路径，目前还找不到更好的解决方案
                 
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, string.Concat("Datastore/ModulesSetupData/"));
                //return System.IO.Path.Combine(EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, string.Concat("Datastore/ModulesSetupData/"));

            }
        }

        private Modules()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
            //bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);
        }


        /// <summary>
        /// 获取安装目录
        /// </summary>
        /// <param name="sGid">模块ID</param>
        /// <returns></returns>
        public string GetModelPath(Guid sGid)
        {
            ModuleInfo md = base.GetEntity(sGid);
            if (md!=null)
            {
                return md.SetupPath;
            }
            else
            {
                return string.Empty;
            }
            
        }

        public IEnumerable<ModuleInfo> DataListBySiteID(int SitID)
        {
            List<ModuleInfo> lst = GetAllModules;
            if(lst.Count>0)
            {
               return lst.Where(d => d.SiteID == SitID);
            }
            return null;
        }

        public List<ModuleInfo> GetAllModules
        {
            get
            {

                string CacheKey = string.Concat("GetAllModules");
                List<ModuleInfo> Modules = Host.CacheRawApp.GetCacheItem<List<ModuleInfo>>(CacheKey, CacheModules);//bllCache.GetCacheItem(CacheKey) as List<ModuleInfo>;
                if (Modules == null)
                {
                    Modules = base.FillList();
                    if (!Equals(Modules, null))
                        Host.CacheRawApp.AddCacheItem(CacheKey, Modules, cachetime, ETimeSpanModel.M, CacheModules); //bllCache.AddCacheItem(CacheKey, Modules);
                }
                return Modules;

            }
        }


        public int GetSiteIDByModuleID(Guid ModuleID)
        {
            ModuleInfo md = GetEntity(ModuleID);
            if (!Equals(md, null))
                return md.SiteID;
            return 0;
            
        }
        

        /// <summary>
        /// 获取模块名称
        /// </summary>
        /// <param name="sGid">模块ID</param>
        /// <returns></returns>
        public string GetModelName(Guid sGid)
        {
            ModuleInfo md = base.GetEntity(sGid);
            return md.ModuleName;
        }
    

        public void DelModel(Guid sGid)
        {
            string sSetupPathAll = GetModelPath(sGid);

            #region 实现删除模块前执行事件

            string sPathDll = string.Empty;
            try
            {
                //ConfigsControl<ConfigsBaseInfo> mdBaseConfigs = ModuleBaseConfig(sSetupPathAll);
                //if (mdBaseConfigs != null)
                //{
                //    string sDllName = mdBaseConfigs.Instance.ModuleDLLName;
                //    sPathDll = HttpContext.Current.Server.MapPath(string.Concat(IISPath, "bin/", sDllName));
                     
                //}
                ModuleInfo md = base.GetEntity(sGid);
                string sDllName = md.ModuleDLLName;
                sPathDll = HttpContext.Current.Server.MapPath(string.Concat(IISPath, "bin/", sDllName));
            }
            catch (Exception e)
            {
                
                BLL.CusttomLog.InsertLogs(new Entity.Logs(){Title = "模块删除时找不到相关模块文件",AddDate = DateTime.Now,Description =e.Message });
            }
           
            #endregion

            base.Delete(sGid);

            //删除模块是否同时删除模块项目文件
            if(EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.DelModuleAndFile)
            {
                //同时删除与模块相关的文件
                Core.FSO.FObject.Delete(HttpContext.Current.Server.MapPath(sSetupPathAll), FsoMethod.Folder);
            }


            //同时删除菜单(后台管理菜单与前台用户模块菜单)
            BLL.Menus.Instance.DeleteByModuleID(sGid);
            BLL.MenusForUser.Instance.DeleteByModulID(sGid);

         
            
            //从主站的bin下删除模块DLL););
            if (!string.IsNullOrEmpty(sPathDll))
                Core.FSO.FObject.Delete(sPathDll, FsoMethod.File);

            Host.CacheApp.InvalidateCache(CacheModules);// bllCache.InvalidateCache();
        }

        public Guid SetupModelZip(string sSetupPath, string sFolder, Page pg,int SiteID)
        {
            Guid gModuleID = Guid.Empty;
            string sSetupPathAll = HttpContext.Current.Server.MapPath(string.Concat(sSetupPath, sFolder, "/"));
            //模块安装目录下的bin路径
            string sDllPath = string.Format("{0}bin", sSetupPathAll);

            FileInfo[] fif = FObject.GetFileListByType(sDllPath, "dll", true); //获取所有Dll

            string DllName = string.Empty;

            //好像还要将这些bin下的文件移到主系统的bin下
            foreach (FileInfo fileInfo in fif)
            {
                Assembly asm = Assembly.LoadFrom(fileInfo.FullName);
                foreach (Module m in asm.GetModules())
                {
                    foreach (Type t in m.FindTypes(Module.FilterTypeName, "*")) //采用过滤器进行类名过滤
                    {
                        foreach (object arr in t.GetCustomAttributes(typeof(ModuleAttribute), true))
                        {
                            DllName = fileInfo.Name;
                            break;
                        }
                    }
                }
                //bool isOK = SetupModelDLL(string.Concat(sDllPath, "\\", fileInfo.Name), sSetupPath, sFolder);
                //if (isOK) break; //目前只安装一个，一个安装包里只能是一个模块，这里如果安装成功就跳出来
            }

            if (!string.IsNullOrEmpty(DllName))
                SetupModelDLL(DllName, sSetupPath, sFolder, pg, out gModuleID, SiteID);

            return gModuleID;
        }

        /// <summary>
        /// 安装模块
        /// </summary>
        /// <param name="sFilePath">文件的上传路径(安装包)</param>
        /// <param name="sSetupPath">安装路径，如 /modules/</param>
        /// <param name="sFolder">安装目录 如  VpiCar</param>
        /// <param name="IsRandName">是否随机命名，如果为true,sFolder不启作用</param>
        public Guid SetupModel(string sFilePath, string sSetupPath, string sSetupFolder, bool IsRandName, string DllName, Page pg, int SiteID)
        {
            Guid gModuleID = Guid.Empty;
            if(string.IsNullOrEmpty(sFilePath.Trim()))
            {
                Tips("安装出错","模块上传的过程可能出现了错误，未能获取上传路径，请重新安装模块！","");
                return Guid.Empty;
            }
            string sType = Core.Strings.GetString.getFileType(sFilePath);
            string sFolder = "";
            if (!IsRandName)
            {
                sFolder = sSetupFolder;
            }
            else
            {
                //随机一个文件名
                sFolder = string.Concat("M", Core.Strings.GetString.RandomNUMSTR(12));
            }
            if (Equals(sType.ToLower(), ".dll"))
            {
                SetupModelDLL(DllName, sSetupPath, sFolder, pg, out gModuleID, SiteID);
            }
            else if (Equals(sType.ToLower(), ".zip"))  //压缩包
            {
                //DllName = string.Empty;

                string sZipFilePath = HttpContext.Current.Server.MapPath(sFilePath);
                
                string sSetupPathAll = HttpContext.Current.Server.MapPath(string.Concat(sSetupPath, sFolder, "/"));
                //将文件解压到安装目录
                Core.FSO.FObject.UnZipFile(sZipFilePath, sSetupPathAll);

                //模块安装目录下的bin路径
                string sDllPath = string.Format("{0}bin", sSetupPathAll);

                //要加一个验证 bin 是否存在
                if(!Core.FSO.FObject.IsExist(sDllPath,FsoMethod.Folder))
                {
                    Base.AppStartInit.TipsPageRender("出错了", "模块中没有存在bin 文件！", "");
                }
                else
                {
                    //解压成功后将bin下的文件复制到主站bin下
                    Core.FSO.FObject.CopyDirectory(sDllPath, HttpContext.Current.Server.MapPath(string.Concat(IISPath, "bin")));
                    //复制过去后系统要重新载入，所以要重新打开页面

                    HttpContext.Current.Response.Redirect(string.Format("Admin_Modules.aspx?t=28&s={0}&f={1}", sSetupPath, sFolder), true);

                }            

            }
            else
            {

                Base.AppStartInit.TipsPageRender("出错了", "未知安装文件格式！只支持 .rar,.zip,dll三种安装格式，请确认！", "");
            }
            return gModuleID;
        }
   
        public bool SetupModelDLL(string DLLName, string sSetupPath, string sFolder, Page pg, out Guid gModuleID,int SiteID)
        {
            bool IsOK = false;
            //安装包路径
            string sPath = HttpContext.Current.Server.MapPath(string.Concat(IISPath, "bin/", DLLName));

            if (Core.FSO.FObject.IsExist(sPath, FsoMethod.File))
            {
                //安装目录
                string sSetupPathAll = string.Concat(sSetupPath, sFolder, "/");
                Assembly asm = Assembly.LoadFrom(sPath);
                 gModuleID = Guid.Empty;
                //ModuleStartInit mg = null;
                //string sModuleGlobalFullName = "";
                //获取所有前台用户路由页面
                List<MPage> lstMPageForUer = new List<MPage>();
                //管理员路由页面
                List<MPage> lstMPage = new List<MPage>(); 

                foreach (Module m in asm.GetModules())
                {
                    foreach (Type t in m.FindTypes(Module.FilterTypeName, "*")) //采用过滤器进行类名过滤
                    {
                        
                        if (t.Name == "SettingInfo")
                        {
                            ModuleAttribute sea = null;
                            foreach (object arr in t.GetCustomAttributes(typeof(ModuleAttribute), true))
                            {
                                sea = (ModuleAttribute)arr;
                                IsOK = true;
                                break; //目前一个类库只支持一个
                            }

                            EbSite.Base.Modules.Configs.ModulesConfigsBase ist = Activator.CreateInstance(t) as EbSite.Base.Modules.Configs.ModulesConfigsBase;

                            if(!Equals(ist,null))
                            {
                                gModuleID = ist.CurrentModelID;
                                Entity.ModuleInfo mdif = new ModuleInfo(sea, SiteID, gModuleID, DLLName);
                                mdif.SetupPath = sSetupPathAll;
                                base.Add(mdif);
                                
                            }
                            else
                            {
                                Tips("出错了", "未能反射ModulesConfigsBase","");
                            }

                        }

                        //if (t.Name == "ModuleGlobal")
                        //{
                        //     mg = Activator.CreateInstance(t) as ModuleStartInit;
                        //    //sModuleGlobalFullName = t.FullName;
                        //}

                        if (t.BaseType == typeof(MPageForUer) || t.BaseType == typeof(MPageForUerMobile))
                        {
                            MPage mtMPageForUer = Activator.CreateInstance(t) as MPage;
                            
                            lstMPageForUer.Add(mtMPageForUer);
                        }
                        else if (t.BaseType == typeof (MPage))
                        {
                            MPage mtMPageForUer = Activator.CreateInstance(t) as MPage;
                            lstMPage.Add(mtMPageForUer);
                        }
                        

                       
                        
                    }

                }
                
                // 将模块ID与安装目录更新到base.config
                //ConfigsControl<ConfigsBaseInfo> mdBaseConfigs = ModuleBaseConfig(sSetupPathAll);

                //mdBaseConfigs.Instance.ModuleID = gModuleID;
                //mdBaseConfigs.Instance.ModulePath = sSetupPathAll;
                //mdBaseConfigs.Instance.ModuleDLLName = DLLName; //如 EbSite.Modules.FriendLik.dll

                //没有找出原因，采用以下方法
                //ConfigsBaseInfo md = new ConfigsBaseInfo();
                //md = mdBaseConfigs.Instance;
                //md.ModuleID = gModuleID;
                //md.ModulePath = sSetupPathAll;
                //md.ModuleDLLName = DLLName; //如 EbSite.Modules.FriendLik.dll
                //mdBaseConfigs.SaveConfig(md);

                //安装模块后执行事件
                //if (mg != null) //模块安装后执行此方法
                //{
                //    //ModuleSetuping = mg;
                //    mg.__Module_Setuped(gModuleID, sSetupPathAll);
                //}

                //生成管理员菜单并加入到扩展功能菜单
                EbSite.BLL.ModulesBll.ModuleMenu mm = new EbSite.BLL.ModulesBll.MenusForAdminer(gModuleID);
                mm.ReMakeMenus(pg, lstMPage);
                //生成前台用户模块菜单
                mm = new EbSite.BLL.ModulesBll.MenusForUser(gModuleID);
                mm.ReMakeMenus(pg, lstMPageForUer);


            }
            else
            {
                gModuleID = Guid.Empty;
                Base.AppStartInit.TipsPageRender("出错了", "找不到模块DLL文件，请确认模块下的bin文件夹里是否存在.DLL文件！", "");
            }
            Host.CacheApp.InvalidateCache(CacheModules);// bllCache.InvalidateCache();
            return IsOK;
        }
        ///// <summary>
        ///// 获取一个模块的配置实体
        ///// </summary>
        ///// <param name="sModulePath"></param>
        ///// <returns></returns>
        //public ConfigsControl<ConfigsBaseInfo> ModuleBaseConfig(string sModulePath)
        //{
        //        if (!string.IsNullOrEmpty(sModulePath))
        //        {
        //            return new ConfigsControl<ConfigsBaseInfo>(sModulePath, "DataStore/Configs/Base.config");
        //        }
        //        return null;
            
        //}

        /// <summary>
        /// 导出模块
        /// </summary>
        /// <param name="sID">模块ID</param>
        /// <returns></returns>
        public string OutPutModule(Guid sID)
        {
            string sPath = GetModelPath(sID);
            sPath = HttpContext.Current.Server.MapPath(sPath);
            string sTarget = string.Format("{0}UploadFile/ExtModuleTem/{1}.zip", Base.AppStartInit.IISPath, Path.GetRandomFileName());

            Core.FSO.FObject.ZipFile(sPath, HttpContext.Current.Server.MapPath(sTarget));

            return sTarget;
        }

    }
}
