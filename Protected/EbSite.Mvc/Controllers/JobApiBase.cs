
using Amib.Threading;
using EbSite.Base;

namespace EbSite.Mvc.Controllers
{
   abstract public class JobApiBase : ApiBaseController
    {
       
        public JobApiBase()
        {
            
        }
        /// <summary>
        /// 是否异步执行
        /// </summary>
        /// <value><c>true</c> if this instance is asyn; otherwise, <c>false</c>.</value>
        protected virtual bool IsAsyn { get; }
        /// <summary>
        /// 实现一个任务执行方法，此方法key为任务key,可不使用
        /// </summary>
        /// <param name="key">任务的主键，可以通过任务的key来获取一个任务对象，并对任务进行相关操作，如删除，暂停等</param>
        /// <returns></returns>
        abstract protected string Execute(string key);
        /// <summary>
        /// 任务被调用是采用接口
        /// </summary>
        /// <param name="key">任务的主键，可以通过任务的key来获取一个任务对象，并对任务进行相关操作，如删除，暂停等</param>
        /// <param name="tk">key加密后的md5值，用户验证传来的key是不是正确的，防止外面的人恶意调用api执行</param>
        /// <returns></returns>
        public string Get(string key,string tk)
        {

            string decKey = Host.Instance.EncodeByMD5(Host.Instance.EncodeByKey(key));
            if (Equals(decKey, tk))
            {
                if (IsAsyn)
                {
                    IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(LoadUrl, key);

                    return "成功将任务添加到异步队列!";
                }
                else
                {
                    return Execute(key);
                }

            }
            return "请求失败，非法请求!";

        }

        public object LoadUrl(object model)
        {
            string skey = model as string;
            Execute(skey);
            return 1;
        }

    }
}
