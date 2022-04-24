using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Util;
using EbSite.Base;
using EbSite.BLL.GetLink;
using Quartz;

namespace EbSite.Jobs
{
    /// <summary>
    /// 定时更新首页
    /// </summary>
    /// <remarks>
    /// 该Job有两个自定义声明，分明说明如下：
    /// 1.PersistJobDataAfterExecution:支持多次执行数据持久化到该对象中，每次执行完毕之后，会把数据放入JobDataMap，以便下次使用。
    /// 2.DisallowConcurrentExecution:不允许并发执行，如果服务开时执行时，上次执行还没有完成，则等待上次完成后，本次执行才开始；
    /// </remarks>
    [DisallowConcurrentExecution]
    public class UpdateIndex: IJob
    {
        
        public void Execute(IJobExecutionContext context)
        {

            //注意这个转换确保一定不要发生错误,否则异常无法获取到
            //HttpContext mdHttp = context.JobDetail.JobDataMap["context"] as HttpContext;
            //HttpContext mdHttp = HttpContext.Current;
            string RealUrl = string.Empty;
            string CachePath = string.Empty;
            try
            {
                List<Entity.Sites> lst = BLL.Sites.Instance.FillList();
                //IndexCreate Instance = new IndexCreate();
                foreach (Entity.Sites md in lst)
                {
                    //Instance.MakeHtml(md.id);
                    EbSite.Base.Static.HtmlMake htmlMake = new Base.Static.HtmlMake();
                    htmlMake._HttpContext = HttpContext.Current;
                    RealUrl = LinkOrther.Instance.GetAspxInstance(md.id).GetMainIndexHref();
                    CachePath = LinkOrther.Instance.GetHtmlInstance(md.id).GetMainIndexHref();
                    if (!string.IsNullOrEmpty(CachePath))
                    {
                        if (CachePath.StartsWith("/"))
                        {
                            CachePath = CachePath.Remove(0, 1);
                            //CachePath = mdHttp.Server.MapPath(CachePath);

                        }
                        CachePath = CachePath.Replace("/", "\\");
                        CachePath = System.IO.Path.Combine(Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, CachePath);
                        htmlMake.Url = string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName, RealUrl, RealUrl.IndexOf("?") > 1 ? "&" : "?", "$timermake$");
                        htmlMake.SavePath = CachePath;
                        htmlMake.IsUtf8 = true;

                        htmlMake.ToHtml(null);



                    }

                }


            }
            catch (Exception e)
            {
                EbSite.Log.Factory.GetInstance().ErrorLog(string.Format("自动生成首页发生错误,真实页面{0}，写入地址{1},错误信息:{2},{3},{4}", RealUrl, CachePath, e.Message, e.StackTrace, e.Source));
              
            }

            //dtLastUpdate = DateTime.Now;

        }
    }
}