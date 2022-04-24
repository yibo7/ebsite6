using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Modules.CQ;

namespace EbSite.Modules.CQ.ModuleCore.DAL.SqlServer
{
    public partial class SiteTools
    {
        public static  string sPre
        {
             get
            {
                if (!SettingInfo.Instance.GetBaseConfig.Instance.IsUserSysConn)
                {
                    return SettingInfo.Instance.GetBaseConfig.Instance.TablePrefix;
                }
                else
                {
                   
                    return Base.Host.Instance.GetSysTablePrefix;
                }
            }
        }
        public static readonly DataProfile.DBHelper DB = new DataProfile.DBHelper();
    }
}