using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Core.FSO;

namespace EbSite.Modules.Shop.ModuleCore.BLL
{
    public class FloorSetInfo : EbSite.Base.Datastore.XMLProviderBaseInt<ModuleCore.Entity.FloorSet>
    {
        public static readonly FloorSetInfo Instance = new FloorSetInfo();
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

                    path = HttpContext.Current.Server.MapPath("~/" + mpath + "/DataStore/Floor/FloorSet/");
                }
                return path;
            }
        }
        private FloorSetInfo()
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
            List<ModuleCore.Entity.FloorSet> getsites = base.FillList();
            int iCount = (from c in getsites where c.FloorId == floorid select c).Count();
            if(iCount>0)
            {
                key = true;
            }
            return key;
        }
    }

    public class FloorBigClassInfo : EbSite.Base.Datastore.XMLProviderBaseInt<ModuleCore.Entity.FloorBigClass>
    {
        public static readonly FloorBigClassInfo Instance = new FloorBigClassInfo();
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

                    path = HttpContext.Current.Server.MapPath("~/" + mpath + "/DataStore/Floor/FloorBigClass/");
                }
                return path;
            }
        }
        private FloorBigClassInfo()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }

      
    }

    public class FloorSmallClassInfo : EbSite.Base.Datastore.XMLProviderBaseInt<ModuleCore.Entity.FloorSmallClass>
    {
        public static readonly FloorSmallClassInfo Instance = new FloorSmallClassInfo();
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

                    path = HttpContext.Current.Server.MapPath("~/" + mpath + "/DataStore/Floor/FloorSmallClass/");
                }
                return path;
            }
        }
        private FloorSmallClassInfo()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }

       
    }
    public class FloorLeftAdInfo : EbSite.Base.Datastore.XMLProviderBaseInt<ModuleCore.Entity.FloorLeftAd>
    {
        public static readonly FloorLeftAdInfo Instance = new FloorLeftAdInfo();
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

                    path = HttpContext.Current.Server.MapPath("~/" + mpath + "/DataStore/Floor/FloorLeftAd/");
                }
                return path;
            }
        }
        private FloorLeftAdInfo()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }

       
    }
    public class FloorProductsInfo : EbSite.Base.Datastore.XMLProviderBaseInt<ModuleCore.Entity.FloorProducts>
    {
        public static readonly FloorProductsInfo Instance = new FloorProductsInfo();
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

                    path = HttpContext.Current.Server.MapPath("~/" + mpath + "/DataStore/Floor/FloorProducts/");
                }
                return path;
            }
        }
        private FloorProductsInfo()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }

        public bool Exist(int floorid)
        {
            if (floorid > 0)
            {
                List<ModuleCore.Entity.FloorProducts> ls = ModuleCore.BLL.FloorProductsInfo.Instance.FillList();
                List<ModuleCore.Entity.FloorProducts> nls = (from i in ls where i.FloorSetId == floorid select i).ToList();
                if (nls != null && nls.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class FloorRightBrandInfo : EbSite.Base.Datastore.XMLProviderBaseInt<ModuleCore.Entity.FloorRightBrand>
    {
        public static readonly FloorRightBrandInfo Instance = new FloorRightBrandInfo();
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

                    path = HttpContext.Current.Server.MapPath("~/" + mpath + "/DataStore/Floor/FloorRightBrand/");
                }
                return path;
            }
        }
        private FloorRightBrandInfo()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }


    }
    public class FloorRightAdInfo : EbSite.Base.Datastore.XMLProviderBaseInt<ModuleCore.Entity.FloorRightAd>
    {
        public static readonly FloorRightAdInfo Instance = new FloorRightAdInfo();
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

                    path = HttpContext.Current.Server.MapPath("~/" + mpath + "/DataStore/Floor/FloorRightAd/");
                }
                return path;
            }
        }
        private FloorRightAdInfo()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }


    }
}