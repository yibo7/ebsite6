using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using EbSite.Base.DataProfile;
using EbSite.BLL;
using EbSite.Core;
using EbSite.Mvc.Controllers;
using EbSite.Mvc.Filters;

namespace EbSite
{
  
    public class auditingcontentController : JobApiBase
    {
        override protected bool IsAsyn
        {
            get { return true; }
         
        }
        override protected string Execute(string key)
        {

            /*
                需求:
                1.每天放出指定量(比如20)未审核文章
                2.将天的时间转成秒
                3.随机出指定量(如20个时间点)
                4.将这些时间点从小到大排序
                5.将一天内的时间点保存下来
                6.到达指定时间点时，放出未审核文章(按时间，只放出发表时间最老的那一条)
            */

            try
            {
                bool istoupdate = false;
                long ispan = Core.Strings.cConvert.DateDiff("h", JobsAuditingContentConfig.Instance.LastUpdate, DateTime.Now);
                //Log.Factory.GetInstance().InfoLog("进来了"+ ispan+"---日期:"+ JobsAuditingContentConfig.Instance.LastUpdate);
                if (ispan > 24)
                {
                    DateTime dtNow = DateTime.Now;
                    int mm = 86400;
                    List<int> lstRand = new List<int>();
                    for (int i = 0; i < JobsAuditingContentConfig.Instance.AuditingNum; i++) //每天放出20条
                    {
                        Thread.Sleep(100);
                        int randnum = Core.Utils.GetRandNum(mm, 1000);
                        lstRand.Add(randnum);
                    }
                    lstRand = lstRand.OrderBy(s => s).ToList();
                    StringBuilder sbRand = new StringBuilder();
                    foreach (int rand in lstRand)
                    {
                        sbRand.Append(dtNow.AddSeconds(rand));
                        sbRand.Append(",");
                    }
                    sbRand.Remove(sbRand.Length - 1, 1);
                    //Log.Factory.GetInstance().InfoLog(string.Format("随机时间：{0},最后时间:{1}", sbRand, dtNow));
                    JobsAuditingContentConfig.Instance.DateTimeToDos = sbRand.ToString();
                    JobsAuditingContentConfig.Instance.LastUpdate = dtNow;
                    JobsAuditingContentConfig.Instance.NextIndex = 0;
                    JobsAuditingContentConfig.Instance.Save();
                    //Log.Factory.GetInstance().InfoLog("更新成功！");
                }

                string[] todotimes = JobsAuditingContentConfig.Instance.DateTimeToDos.Split(',');
                if (todotimes.Length > JobsAuditingContentConfig.Instance.NextIndex)
                {
                    string sDateTodo = todotimes[JobsAuditingContentConfig.Instance.NextIndex];

                    if (!string.IsNullOrEmpty(sDateTodo))
                    {
                        DateTime dtDateTodo = DateTime.Parse(sDateTodo);

                        if (DateTime.Now > dtDateTodo)
                        {
                            int NumberTime = Core.SqlDateTimeInt.GetSecond(DateTime.Now);
                            DbHelperCms.Instance.ExecuteNonQuery(string.Format("UPDATE  eb_newscontent SET IsAuditing=1,AddTime=now(),NumberTime={0} WHERE IsAuditing=0 ORDER BY id ASC LIMIT 1", NumberTime));

                            JobsAuditingContentConfig.Instance.NextIndex = JobsAuditingContentConfig.Instance.NextIndex + 1;

                            JobsAuditingContentConfig.Instance.Save();

                        }

                    }
                }

            }
            catch (Exception e)
            {

                Log.Factory.GetInstance().ErrorLog(string.Format("自动审核文章发生错误：{0},错误追踪:{1}", e.Message, e.StackTrace));

            }
            Log.Factory.GetInstance().InfoLog("自动审核文章成功");
            return "内容审核成功！";
        }

    }
    public class JobsAuditingContentConfig
    {
        public readonly static JobsAuditingContentConfig Instance = new JobsAuditingContentConfig();
        private IniParser iniParser;

        private JobsAuditingContentConfig()
        {
            //D:\\web\\BeiMaiProject\\beimai5.0\\Web\\BeiMai.WebApp\\BeiMai.WebApp\\bin
            string sPath = AppDomain.CurrentDomain.BaseDirectory;
#if DEBUG
            if (sPath.EndsWith("\\bin"))
                sPath = sPath.Replace("\\bin", "");
#endif
            iniParser = new IniParser(string.Concat(sPath, @"\JobsAuditingContent.ini"));



            //app
            LastUpdate = DateTime.Parse(iniParser.GetSetting("App", "LastUpdate"));
            DateTimeToDos = iniParser.GetSetting("App", "DateTimeToDos");
            NextIndex = int.Parse(iniParser.GetSetting("App", "NextIndex"));
            AuditingNum = int.Parse(iniParser.GetSetting("App", "AuditingNum"));

            IsOpen = int.Parse(iniParser.GetSetting("App", "IsOpen"));
        }

        public void Save()
        {
            //app
            iniParser.AddSetting("App", "LastUpdate", LastUpdate.ToString());
            iniParser.AddSetting("App", "DateTimeToDos", DateTimeToDos);
            iniParser.AddSetting("App", "NextIndex", NextIndex.ToString());
            iniParser.AddSetting("App", "AuditingNum", AuditingNum.ToString());

            iniParser.SaveSettings();

        }



        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>The last update.</value>
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Gets or sets the date time to dos.
        /// </summary>
        /// <value>The date time to dos.</value>
        public string DateTimeToDos { get; set; }

        /// <summary>
        /// Gets or sets the index of the next.
        /// </summary>
        /// <value>The index of the next.</value>
        public int NextIndex { get; set; }
        /// <summary>
        ///每天放出多少条
        /// </summary>
        /// <value>The auditing number.</value>
        public int AuditingNum { get; set; }
        /// <summary>
        /// 是否开户
        /// </summary>
        /// <value>The is open.</value>
        public int IsOpen { get; set; }

    }

}
