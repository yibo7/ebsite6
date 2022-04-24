using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using EbSite.Core.FSO;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.ModuleCore.BLL
{
    public class ServiceClass: EbSite.Base.Datastore.XMLProviderBaseInt<Entity.ServiceClass>
    {
        public static readonly ServiceClass Instance = new ServiceClass();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(SaveUrl);
            }
        }
        private readonly string SaveUrl = string.Concat(SettingInfo.Instance.GetBaseConfig.Instance.ModulePath, "DataStore/ServiceClass/");
        private ServiceClass()
        {

            string sPath = HttpContext.Current.Server.MapPath(SaveUrl);
            if(!FObject.IsExist(sPath,FsoMethod.Folder))
            {
                FObject.Create(sPath,FsoMethod.Folder);
            }
        }
       
        public void UpdateFloatJsData()
        {
            string sPath = HttpContext.Current.Server.MapPath("../js/serviceclass.js");
            List<Entity.ServiceClass> lst = FillList();
            if (lst.Count > 0)
            {
                StringBuilder sb = new StringBuilder("var sclass = [ ");

                foreach (Entity.ServiceClass info in lst)
                {
                    sb.Append("{  ");
                    sb.AppendFormat("id: {0}, title: \"{1}\"", info.id, info.Title);
                    sb.Append("},");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("] ;");
                Core.FSO.FObject.WriteFileUtf8(sPath, sb.ToString());
            }
        }


    }
}