//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using EbSite.Base.Static; 
//using EbSite.Core.EbCache;
//using EbSite.Core.STSdbUtils;

//namespace EbSite.Base.EBCache
//{
//    public class HtmlCache
//    {
//        public static HtmlCache Instance = new HtmlCache();
//        protected CacheBll dbBll;
//        public HtmlCache()
//        {
//            dbBll = new CacheBll("htmls");
//        }

//        private bool IsExist(string temp)
//        {
//            return dbBll.Exists(temp);
//        }

//        public string GetHtml(string temp)
//        {
//            ETimeSpanModel spanModel = (ETimeSpanModel)Configs.HtmlConfigs.ConfigsControl.Instance.HtmlTimeSpanModel;
//           return GetHtml(temp, Configs.HtmlConfigs.ConfigsControl.Instance.HtmlTimeSpan, spanModel);
//        }

//        public string GetHtml(string temp,double CacheTime, ETimeSpanModel spanModel)
//        {
//            if (IsExist(temp))
//            {
//                CacheEntity model = dbBll.GetEntity(temp);

//                if (DateTime.Compare(DateTime.Now, model.ExpTime) <= 0)
//                {
//                    return model.Model; 
//                }
//                else
//                {
//                    return AddUpdateHtml(temp, CacheTime, spanModel, false);
//                }
               
//            }
//            else
//            {
//                return AddUpdateHtml(temp, CacheTime, spanModel, true);
//            }
           
//        }
 

//        private string AddUpdateHtml(string temp, double CacheTime, ETimeSpanModel spanModel,bool IsAdd)
//        {
//            if (!string.IsNullOrEmpty(temp))
//            {
//                string shtml = Core.WebUtility.LoadURLString(temp);
//                if (!string.IsNullOrEmpty(shtml))
//                {
//                    DateTime dtSpan;
//                    if (spanModel == ETimeSpanModel.秒)
//                    {
//                        dtSpan = DateTime.Now.AddSeconds(CacheTime);
//                    }
//                    else if (spanModel == ETimeSpanModel.分钟)
//                    {
//                        dtSpan = DateTime.Now.AddMinutes(CacheTime);
//                    }
//                    else if (spanModel == ETimeSpanModel.小时)
//                    {
//                        dtSpan = DateTime.Now.AddHours(CacheTime);
//                    }
//                    else if (spanModel == ETimeSpanModel.天)
//                    {
//                        dtSpan = DateTime.Now.AddDays(CacheTime);
//                    }
//                    else
//                    {
//                        dtSpan = DateTime.Now.AddSeconds(CacheTime);
//                    }
//                    CacheEntity md = new CacheEntity();
//                    md.Id = temp;
//                    md.ExpTime = dtSpan;
//                    md.Model = shtml;
//                    if (IsAdd)
//                    {
//                        dbBll.InsertOne(md);
//                    }
//                    else
//                    {
//                        dbBll.Update(md);
//                    }
                    
//                }
//                return shtml;
//            }
//            else
//            {
//                throw new Exception("缓存的键值为空，或者缓存的对象为null,不能写入缓存！");
//            } 

//        }

         
        
        

//    }
//}
