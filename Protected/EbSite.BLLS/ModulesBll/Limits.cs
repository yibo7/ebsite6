using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using EbSite.Entity.Module;

namespace EbSite.BLL.ModulesBll
{
    abstract public class Limits
    {
        /// <summary>
        /// 模块存放的路径
        /// </summary>
        private string _sModulePath;
        private Guid ModuleID;
        public Limits(Guid _ModuleID)
        {
            ModuleID = _ModuleID;
            _sModulePath = Modules.Instance.GetModelPath(ModuleID);
            if (string.IsNullOrEmpty(_sModulePath))
                throw new Exception("找不到相应的模块");
        }
        /// <summary>
        /// 获取权限列表的存放路径
        /// </summary>
        private string GetLimitFilePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(string.Concat(_sModulePath, LimitsDataFile));
            }
        }
       abstract protected string LimitsDataFile { get; }
        public List<LimitInfo> GetLimitsFull
        {
            get
            {
                List<LimitInfo> lst = new List<LimitInfo>();

                string sLimits = Core.FSO.FObject.ReadFile(GetLimitFilePath);

                Regex re = new Regex("\r\n");

                string[] lmList = re.Split(sLimits);

                foreach (string saLimit in lmList)
                {
                    string[] aLimit = saLimit.Split('.');

                    if (aLimit.Length == 2)
                    {
                        LimitInfo md = new LimitInfo();
                        md.LimitID = int.Parse(aLimit[0]);
                        md.LimitName = aLimit[1];
                        lst.Add(md);
                    }
                }
                return lst;
            }
        }

    }
}
