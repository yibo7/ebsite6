using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Modules.Exam;

namespace EbSite.Modules.Exam.ModuleCore.DAL.Access
{
    public partial class Exam
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