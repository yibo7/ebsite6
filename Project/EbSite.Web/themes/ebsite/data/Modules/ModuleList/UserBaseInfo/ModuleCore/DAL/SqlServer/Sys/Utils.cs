using System;
using System.Collections.Generic;

using System.Web;
using EbSite.Modules.UserBaseInfo;


namespace EbSite.Modules.UserBaseInfo.ModuleCore.DAL.SqlServer
{
    public partial class DataProvider
    {
        public static string sPre
        {
            get
            {
                return Base.Host.Instance.GetSysTablePrefix;
                //if (!SettingInfo.Instance.GetBaseConfig.Instance.IsUserSysConn)
                //{
                //    return SettingInfo.Instance.GetBaseConfig.Instance.TablePrefix;
                //}
                //else
                //{

                //    return Base.Host.Instance.GetSysTablePrefix;
                //}
            }
        }
        
        public static readonly DataProfile.DBHelper DB = new DataProfile.DBHelper();
    }
    
}