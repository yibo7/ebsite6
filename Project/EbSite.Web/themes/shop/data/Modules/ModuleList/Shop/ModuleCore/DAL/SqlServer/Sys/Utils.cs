using System;
using System.Collections.Generic;
using System.Web;

namespace EbSite.Modules.Shop.ModuleCore.DAL.SqlServer
{
    public partial class Shop : DALInterface.IDataProvider
    {
        public static  string sPre
        {
             get
            {
                if (SettingInfo.Instance.GetBaseConfig.Instance.IsUserSysConn)
                {
                    return Base.Host.Instance.GetSysTablePrefix;
                    
                }
                else
                {
                    return SettingInfo.Instance.GetBaseConfig.Instance.TablePrefix;
                    
                }
            }
        }
        public static readonly DataProfile.DBHelper DB = new DataProfile.DBHelper();
    }
}