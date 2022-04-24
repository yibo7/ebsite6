using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.Static;
using EbSite.Core;
using EbSite.Core.FSO;

namespace EbSite.BLL
{
    public class JobTask : EbSite.Base.Datastore.XMLProviderBase<Entity.JobTask>
    {
         
        public static readonly JobTask Instance = new JobTask();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return string.Concat(ConfigsControl.Instance.sMapPath, "Datastore/JobTask/");
            }
        }
        private JobTask()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);

            }
             
        }
          

    }
}
