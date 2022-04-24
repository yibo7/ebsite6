using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Core.FSO;

namespace EbSite.Modules.Shop.ModuleCore.BLL
{
    public class MFloorSetInfo : EbSite.Base.Datastore.XMLProviderBaseInt<ModuleCore.Entity.MFloorSet>
    {
        public static readonly MFloorSetInfo Instance = new MFloorSetInfo();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                string path = "";
                string mpath = EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"));
                if (!Equals(HttpContext.Current, null))
                {

                    path = HttpContext.Current.Server.MapPath("~/" + mpath + "/DataStore/Floor/MFloorSet/");
                }
                return path;
            }
        }
        private MFloorSetInfo()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);    
            }
        }
       
        /// <summary>
        /// 验证是否添加过 存在返回true
        /// </summary>
        /// <param name="floorid"></param>
        /// <returns></returns>
        public bool IsAdd(int floorid)
        {
            bool key = false;
            List<ModuleCore.Entity.MFloorSet> getsites = base.FillList();
            int iCount = (from c in getsites where c.FloorId == floorid select c).Count();
            if(iCount>0)
            {
                key = true;
            }
            return key;
        }
    }

    public class MFloorBigClassInfo : EbSite.Base.Datastore.XMLProviderBaseInt<ModuleCore.Entity.MFloorBigClass>
    {
        public static readonly MFloorBigClassInfo Instance = new MFloorBigClassInfo();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                string path = "";
                string mpath = EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"));
                if (!Equals(HttpContext.Current, null))
                {

                    path = HttpContext.Current.Server.MapPath("~/" + mpath + "/DataStore/Floor/MFloorBigClass/");
                }
                return path;
            }
        }
        private MFloorBigClassInfo()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }

      
    }

    public class MFloorSmallClassInfo : EbSite.Base.Datastore.XMLProviderBaseInt<ModuleCore.Entity.MFloorSmallClass>
    {
        public static readonly MFloorSmallClassInfo Instance = new MFloorSmallClassInfo();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                string path = "";
                string mpath = EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"));
                if (!Equals(HttpContext.Current, null))
                {

                    path = HttpContext.Current.Server.MapPath("~/" + mpath + "/DataStore/Floor/MFloorSmallClass/");
                }
                return path;
            }
        }
        private MFloorSmallClassInfo()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }

       
    }


     public class MFlashInfo : EbSite.Base.Datastore.XMLProviderBaseInt<ModuleCore.Entity.MFlash>
    {
        public static readonly MFlashInfo Instance = new MFlashInfo();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                string path = "";
                string mpath = EbSite.Base.Host.Instance.GetModulePath(new Guid("cfccc599-4585-43ed-ba31-fdb50024714b"));
                if (!Equals(HttpContext.Current, null))
                {

                    path = HttpContext.Current.Server.MapPath("~/" + mpath + "/DataStore/Floor/MFlashInfo/");
                }
                return path;
            }
        }
        private MFlashInfo()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }

       
    }


    
}