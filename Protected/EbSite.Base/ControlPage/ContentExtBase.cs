using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace EbSite.Base.ControlPage
{
    abstract public class ContentExtBase : System.Web.UI.UserControl
    {
        
        /// <summary>
        /// 功能说明或相关说明
        /// </summary>
        virtual public string TipsText 
        { 
            get
            {
                return "";
            } 
        }
         
        public EbSite.Entity.Sites CurrentSite
        {
            get
            {
                return Host.Instance.CurrentSite;
            }
        }
        /// <summary>
        /// 获取当前编辑内容Id,如果当前是新添加，那么此Id为0,保存后此Id为保存成功后的内容Id
        /// </summary>
        public long ContentId
        {
            get
            {
                return Core.Utils.ObjectToLong(Session["ContentId"],0);
            }
        }
        /// <summary>
        /// 获取当前站点ID，要求当前页面的url有参数site,没有参数site将获取后台默认站点
        /// </summary>
        protected int GetSiteID
        {
            get
            {
                return Host.Instance.GetSiteID;
            }
        }
        
        /// <summary>
        /// 获取来路地址
        /// </summary>
        protected string GetFromURL
        {
            get
            {
                return Request.UrlReferrer.ToString();
            }
        }
        /// <summary>
        /// 可以在提交按钮post是触发一个方法,如checkdata('123'),这里只可以写一个方法，并且这个方法要有返回值 true 或 false
        /// </summary>
        virtual public string OnClientClick { 
            get
            {
                return "";
            }
        }
        /// <summary>
        /// 页面名称，将显示在tab里
        /// </summary>
        abstract public string PageName { get; }
        /// <summary>
        /// 页面载入时执行,如果dataid大于0，说明是修改，如果dataid=0说明是新添加
        /// </summary>
        /// <param name="dataid"></param>
        //public abstract void DataInit(int dataid);
        ///// <summary>
        ///// 当内容页面更新内容时触发
        ///// </summary>
        ///// <param name="dataid"></param>
        //public abstract void Update(int dataid);
        ///// <summary>
        ///// 当内容页面添加内容时触发
        ///// </summary>
        ///// <param name="dataid"></param>
        //public abstract void Add(int dataid);

        /// <param name="dataid"></param>
        public abstract void DataInit(EbSite.Entity.NewsContent mdContent, EbSite.Entity.NewsClass mdClass);
        /// <summary>
        /// 当内容页面更新内容时触发
        /// </summary>
        /// <param name="dataid"></param>
        public abstract void Update(EbSite.Entity.NewsContent model);
        /// <summary>
        /// 当内容页面添加内容时触发
        /// </summary>
        /// <param name="dataid"></param>
        public abstract void Add(EbSite.Entity.NewsContent model);
        /// <summary>
        /// 排序ID
        /// </summary>
        abstract public int OrderID { get; }
      
        
    }
}
