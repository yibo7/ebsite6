using System;
using System.Collections.Generic;
using System.Web;

namespace EbSite.Modules.BBS.ModuleCore.DAL.Access
{
    public partial class BBS
    {
        public static  string sPre
        {
             get
            {
                //if(!SettingInfo.Instance.IsUserSysConn)
                //{
                //    return SettingInfo.Instance.TablePrefix;
                //}
                //else
                //{

                //    return Base.Host.Instance.GetSysTablePrefix;
                //}
                return Base.Host.Instance.GetSysTablePrefix;
            }
        }
        public static readonly DataProfile.DBHelper DB = new DataProfile.DBHelper();
    }
}