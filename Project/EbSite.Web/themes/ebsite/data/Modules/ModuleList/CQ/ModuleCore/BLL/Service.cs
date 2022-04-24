using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Modules.CQ.ModuleCore.Configs;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.ModuleCore.BLL
{
    public class Service : EbSite.Base.Datastore.XMLProviderBaseInt<ServiceInfo>
    {
        public static readonly Service Instance = new Service();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(VoteSaveUrl);
            }
        }
       
        public int ServerForFree(int thisid)
        {
            List<ServiceInfo> lst = Service.Instance.FillList();
            List<EbSite.Modules.CQ.ModuleCore.Entity.ServiceInfo> onlinenls;
            onlinenls = (from i in lst where i.IsOnline == true orderby Guid.NewGuid() select i).ToList();//Take(1)

            int ServiceId = 0;
            foreach (ServiceInfo info in onlinenls)
            {
                if (info.IsOnline )
                {
                    if (thisid > 0 && info.id != thisid) //进入聊天
                    {
                        List<Customer> lstCustomer = ChatBll.Instance.CustomersOnline(info.id);
                        if (lstCustomer.Count == 0)
                        {
                            ServiceId =  info.id;
                            break;
                        }
                    }
                    else //前台主动邀请情况
                    {
                        List<Customer> lstCustomer = ChatBll.Instance.CustomersOnline(info.id);
                        if (lstCustomer.Count == 0)
                        {
                            ServiceId = info.id;
                            break;
                        }
                    }
                    
                }
            }

            if (ServiceId == 0)
            {
                List<ServiceInfo> nonls = (from i in lst where i.IsOnline == false orderby Guid.NewGuid() select i).ToList();
                if (nonls.Count > 0)
                {
                    ServiceId =  nonls[0].id;
                }
                else
                {
                   ServiceId =  lst[0].id;
                }
            }

            return ServiceId;
        }

        private readonly string VoteSaveUrl = string.Concat(SettingInfo.Instance.GetBaseConfig.Instance.ModulePath, "DataStore/ServiceInfo/");
        private Service()
        {

            string sPath = HttpContext.Current.Server.MapPath(VoteSaveUrl);
            if(!FObject.IsExist(sPath,FsoMethod.Folder))
            {
                FObject.Create(sPath,FsoMethod.Folder);
            }

           
        }

        public ServiceInfo GetServerByUserID(int iUserID)
        {
            List<ServiceInfo> lst = base.FillList();

            foreach (ServiceInfo info in lst)
            {
                if(info.UserID==iUserID)
                {
                    return info;
                   
                }
            }
            return null;
        }

        public void AllOfLine()
        {
            List<ServiceInfo> lst = base.FillList();

            foreach (ServiceInfo info in lst)
            {
                info.IsOnline = false;
                Update(info);
            }
        }

        //public bool IsOnline(int suid)
        //{
        //    ServiceInfo md = GetEntity(suid);
        //    return IsOnline(md);
        //}
        //public bool IsOnline(ServiceInfo md)
        //{
            
        //    long span = EbSite.Core.Strings.cConvert.DateDiff("minute", md.LastDateTime, DateTime.Now);
        //    return (span < 1); //离开聊天窗口一分钟算离线
        //}
        public void UpdateFloatJsData()
        {
            string sPath = HttpContext.Current.Server.MapPath("../js/chatcf.js");
            List<ServiceInfo> lst = ModuleCore.BLL.Service.Instance.FillList();
            if (lst.Count > 0)
            {
                StringBuilder sb = new StringBuilder("var chatcf = [ ");
              
                foreach (ServiceInfo info in lst)
                {
                    if (info.IsEabled)
                    {
                        sb.Append("{  ");
                        sb.AppendFormat("id: {0}, realname: \"{1}\",uid:\"{2}\", photo: \"{3}\",gid:{4}", info.id, info.ServiceName, info.UserID, EbSite.Base.Host.Instance.GetAvatarFileName(info.UserID, 3), info.ClassID);
                        sb.Append("},");
                    }
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("] ;");


                Core.FSO.FObject.WriteFileUtf8(sPath, sb.ToString());
            }
        }
        
        

    }
}