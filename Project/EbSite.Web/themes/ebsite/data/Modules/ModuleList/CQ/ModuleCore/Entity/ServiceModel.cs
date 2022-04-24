using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.CQ.ModuleCore.Entity
{

    public class ServiceModel 
    {
        public ServiceModel()
        {
            
        }
        public ServiceModel(ServiceInfo md)
        {
            this.id =  md.id;
            this.ServiceName = md.ServiceName;
            this.PostName = md.PostName;
            this.Phone = md.Phone;
            this.Mobile = md.Mobile;
            this.Email = md.Email;
            this.OrderID = md.OrderID;
            this.UserID = md.UserID;
            this.UserName = md.UserName;
            this.UserNiName = md.UserNiName;
            this.Photo = EbSite.Base.Host.Instance.GetAvatarFileName(this.UserID, 1);
            this.Info = md.Info;
            this.IsOnline = md.IsOnline;//ModuleCore.BLL.Service.Instance.IsOnline(md);
            this.CustomerID = ModuleCore.BLL.ChatBll.Instance.GetCustomerUserName();
        }
        public int id { get; set; }
        /// <summary>
        /// 客服名称
        /// </summary>
        public string ServiceName{ get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string PostName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Email { get; set; }
       
        /// <summary>
        /// 排序ID
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// 关联ebsite的userID 
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 关联的用户帐号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 关联的用户帐号
        /// </summary>
        public string UserNiName { get; set; }

        public string Photo { get; set; }

        public string Info { get; set; }

        public bool IsOnline { get; set; }

        public string CustomerID { get; set; }
        
    }
}