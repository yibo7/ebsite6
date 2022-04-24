using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Core.FSO;

namespace EbSite.BLL
{
   public class PsFreight:EbSite.Base.Datastore.XMLProviderBaseInt<Entity.PsFreight>
    {
        public static readonly PsFreight Instance = new PsFreight();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/peisong/freight/"));
            }
        }

        private PsFreight()
        {

            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
    }

   public class PsAreaPrice:EbSite.Base.Datastore.XMLProviderBaseInt<Entity.PsAreaPrice>
    {
        public static readonly PsAreaPrice Instance = new PsAreaPrice();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/peisong/areaPrice/"));
            }
        }

        private PsAreaPrice()
        {

            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
       /// <summary>
       /// 获取某个运费模板下的区域配置ID
       /// </summary>
       /// <param name="TemID">运费模板ID</param>
       /// <returns></returns>
       public List<EbSite.Entity.PsAreaPrice> GetListByTempID(int TemID)
       {
           List<EbSite.Entity.PsAreaPrice> modelList = EbSite.BLL.PsAreaPrice.Instance.FillList();
           List<EbSite.Entity.PsAreaPrice> ns =
               (from i in modelList where i.ParentID == TemID select i).ToList();
           return ns;
       }

    }

    
}
