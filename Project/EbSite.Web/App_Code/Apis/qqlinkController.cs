using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading;
using System.Web;
using EbSite.BLL;
using EbSite.Mvc.Controllers;
using EbSite.Mvc.Filters;

namespace EbSite
{
    /*
编写api要注意：就算方法名一名，但参数变量的命名也不能一样，否则出错
如ebtest(string msg)与tokentest(string msg),msg都一样，会出错，可能是mvc的bug
   */
    //[RoutePrefix("content")]
    public class qqlinkController : ApiBaseController
    {
         

        public string Post(PramModel model)
        {

            List<string> lstUrls = EbSite.Core.WebUtility.GetTextUrls(model.msginfo);
            //Log.Factory.GetInstance().InfoLog(string.Format("来自群：{0}，缩主qq：{1}，发送人：{2}，发送内容：{3}", model.groupqq, model.useqq, model.speaker, model.msginfo));
            if (lstUrls.Count > 0)
            {
                //Log.Factory.GetInstance().InfoLog("开始输出：");
                //Log.Factory.GetInstance().InfoLog(string.Join("|", lstUrls.ToArray()));
                Entity.NewsClass mdClass = BLL.NewsClass.GetModelByCache(1);
                Thread th = new Thread(() =>
                {
                    foreach (var url in lstUrls)
                    {

                        if (Core.WebUtility.ValidateUrl(url))
                        {
                            try
                            {
                                Dictionary<string, string> dic = EbSite.Core.WebUtility.GetBodyKewordDis(url);
                                string sTitle = string.Empty;
                                string sKeyWord = string.Empty;
                                string sDis = string.Empty;
                                string sBody = string.Empty;

                                if (dic.ContainsKey("b"))
                                    sBody = dic["b"];
                                if (dic.ContainsKey("t"))
                                    sTitle = dic["t"];
                                if (dic.ContainsKey("k"))
                                    sKeyWord = dic["k"];
                                if (dic.ContainsKey("d"))
                                    sDis = dic["d"];
                                if (!string.IsNullOrEmpty(sTitle))
                                {
                                    Entity.NewsContent ThisModel = new Entity.NewsContent();

                                    string sKey = Core.Utils.MD5(url);

                                    ThisModel.IsAuditing = false;
                                    ThisModel.ClassName = mdClass.ClassName;
                                    ThisModel.ClassID = mdClass.ID;
                                    ThisModel.SiteID = 1;
                                    ThisModel.UserID = 1;
                                    ThisModel.UserName = model.speaker;
                                    ThisModel.UserNiName = model.speaker;
                                    ThisModel.Annex1 = sKey;
                                    ThisModel.Annex2 = model.groupqq;
                                    ThisModel.Annex3 = url;
                                    ThisModel.Annex4 = sKeyWord;
                                    ThisModel.Annex5 = sDis;
                                    ThisModel.Annex6 = model.useqq;

                                    ThisModel.NewsTitle = sTitle;
                                    ThisModel.ContentInfo = sBody;

                                    NewsContentSplitTable bll = EbSite.Base.AppStartInit.GetNewsContentInst(ThisModel.ClassID);

                                    if (!bll.Exists(string.Format("Annex1='{0}'", sKey)))
                                    {
                                        long contentid = bll.AddBLL(ThisModel, -1, true, ThisModel.SiteID, mdClass.ContentModelID);
                                    }



                                    //string sFileName = string.Format("{0}{1}{2}.jpg", EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "\\webimg\\", Core.Utils.MD5(url));
                                    //if (!Core.FSO.FObject.IsExist(sFileName, FsoMethod.File))
                                    //{

                                    //    MakeImg makeimg = new MakeImg(sFileName, url);
                                    //    MakeThemeImg(makeimg);
                                    //    //IWorkItemResult wir = EbSite.Base.ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(MakeThemeImg), makeimg);
                                    //}
                                }
                                Thread.Sleep(500);
                            }
                            catch (Exception e)
                            {


                            }
                        }



                    }

                });
                th.Start();



            }
            else
            {
                Log.Factory.GetInstance().InfoLog("无法提取url");
            }


            return "返回成功";
        }




    }
    //[Serializable]
    public class PramModel
    {
        public string msginfo { get; set; }
        /// <summary>
        /// 说话者
        /// </summary>
        /// <value>The fromqq.</value>
        public string speaker { get; set; }
        /// <summary>
        /// 来自哪个群,信息的源头  群号,好友QQ,讨论组ID,临时会话对象QQ等
        /// </summary>
        /// <value>The groupqq.</value>
        public string groupqq { get; set; }
        /// <summary>
        /// 使用中的QQ,用来加群的qq
        /// </summary>
        /// <value>The useqq.</value>
        public string useqq { get; set; }

    }
}
