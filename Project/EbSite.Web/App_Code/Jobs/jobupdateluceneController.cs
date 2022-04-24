using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading;
using System.Web;
using EbSite.Base;
using EbSite.BLL;
using EbSite.Core;
using EbSite.Mvc.Controllers;
using EbSite.Mvc.Filters;

namespace EbSite
{

    public class jobupdateluceneController : JobApiBase
    {

        private static int LastIndex = 0;
        override protected bool IsAsyn
        {
            get { return true; }
            
        }

        override protected string Execute(string key)
        {
            /*
                需求:
                定时获取最新或有变动的内容更新Lucene索引，将最后的更新时间保存到LuceneIndexLastTime.ini下的LastUpdate，
                在LuceneIndexLastTime.ini可以通过IsOpen来控制是否开关此功能
            */

            try
            {

                DateTime dtLastUpDateTime = LuceneIndexLastTime.Instance.LastUpdate;
                List<Entity.Sites> lstSites = BLL.Sites.Instance.FillList();

                //IndexCreate Instance = new IndexCreate();
                foreach (Entity.Sites md in lstSites)
                {
                    int SiteId = md.id;

                    EbSite.Base.LuceneUtils.IInstance<EbSite.Entity.NewsContent> LuceneContent = new EbSite.Base.LuceneUtils.Content(SiteId);

                    //LuceneContent.Rebuild();//清理原有索引

                    LuceneContent.CreateIndex();


                    string sv = string.Empty;
                    //用作搜索的表,在后台可以设置
                    sv = EbSite.BLL.DataSettings.Content.Instance.GetConfigCurrent.ContentTables;
                    if (!string.IsNullOrEmpty(sv))
                    {
                        string[] arryTb = sv.Split(',');
                        foreach (string TableName in arryTb)
                        {
                            EbSite.BLL.NewsContentSplitTable NewsContentInst = AppStartInit.GetNewsContentInst(TableName);

                            string sWhere = string.Format("IsAuditing=1 and LastUpdateTime>='{0}'", dtLastUpDateTime);

                            List<EbSite.Entity.NewsContent> lst = NewsContentInst.GetListArray(sWhere, 0, "", "", SiteId);

                            foreach (EbSite.Entity.NewsContent newsContent in lst)
                            {
                                newsContent.ContentInfo = Core.Strings.GetString.ClearHtml(newsContent.ContentInfo);
                                LuceneContent.Add(newsContent);
                            }

                            int iCount = LuceneContent.EndCreate();
                            if (lst.Count > 0)
                            {
                                if (LuceneIndexLastTime.Instance.IsWriteLog == 1)
                                    Log.Factory.GetInstance().InfoLog(string.Format("来自站点:{0},表名:{1}获取记录{2},成功更新Lucene索引{3}条", md.SiteName, TableName, lst.Count, iCount));
                            }

                        }
                    }
                }

                LuceneIndexLastTime.Instance.LastUpdate = DateTime.Now;
                LuceneIndexLastTime.Instance.Save();
            }
            catch (Exception e)
            {

                Log.Factory.GetInstance().ErrorLog(string.Format("Lucene索引更新出错：{0},错误追踪:{1}", e.Message, e.StackTrace));

            }
            Log.Factory.GetInstance().InfoLog("更新Lucene索引成功");
            return "更新Lucene索引成功";
        }

        

    }
    public class LuceneIndexLastTime
    {
        public readonly static LuceneIndexLastTime Instance = new LuceneIndexLastTime();
        private IniParser iniParser;

        private LuceneIndexLastTime()
        {
            //D:\\web\\BeiMaiProject\\beimai5.0\\Web\\BeiMai.WebApp\\BeiMai.WebApp\\bin
            string sPath = AppDomain.CurrentDomain.BaseDirectory;
#if DEBUG
            if (sPath.EndsWith("\\bin"))
                sPath = sPath.Replace("\\bin", "");
#endif
            iniParser = new IniParser(string.Concat(sPath, @"\LuceneIndexLastTime.ini"));



            //app
            LastUpdate = DateTime.Parse(iniParser.GetSetting("App", "LastUpdate"));
            IsOpen = Core.Utils.StrToInt(iniParser.GetSetting("App", "IsOpen"), 0);
            IsWriteLog = Core.Utils.StrToInt(iniParser.GetSetting("App", "IsWriteLog"), 0);
        }

        public void Save()
        {
            //app
            iniParser.AddSetting("App", "LastUpdate", LastUpdate.ToString());

            iniParser.SaveSettings();

        }

        public DateTime LastUpdate { get; set; }
        public int IsOpen { get; set; }
        public int IsWriteLog { get; set; }

    }


}
