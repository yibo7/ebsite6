using System;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using EbSite.Base;
using EbSite.Base.Json;
using EbSite.Base.Page;
using EbSite.Modules.BBS.ModuleCore;
using EbSite.Modules.BBS.ModuleCore.Entity;

namespace EbSite.Modules.BBS.Ajaxget
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class api : WebServiceBase
    {

        [WebMethod]
        public string HelloString(string username)
        {
            return "调用了HelloString这是传来参数值" + username;
        }
        [WebMethod]
        public JsonResponse HelloJson(string username)
        {
            return new JsonResponse() { Success = true, Message = "调用了HelloJson这是传来参数值" + username };
        }
        [WebMethod(Description = "帖子的回复", EnableSession = true)]
        public JsonResponse Hf(int postid, string c,  int ep,int count, int site,int cid,int rs,int uid)
        {
            if(EbSite.Base.Host.Instance.UserID>0)
            {
                bool isok = false;
                string sURl = ModuleCore.BLL.TopicReplies.Instance.AddHf(postid, c, "", count, site, ep, out isok, cid);

               
                    #region 发送邮件通知

                    //string postuid = ViewState["postuid"] as string;
                     if (rs==1)
                    {
                        if (uid > 0 && uid != EbSite.Base.AppStartInit.UserID)
                        {
                            string OutPurl = string.Format("http://{0}/{1}",HttpContext.Current.Request.Url.Authority, sURl);

                            EbSite.Base.Host.Instance.SendEmailPoolByUserID(uid, "有人回复了您的帖子", string.Format("有人回复了您的帖子,邀请您及时关注回应，<a target=\"_blank\" href=\"{0}\">点这里去看看</a>！", OutPurl));
                        }

                    }


                    #endregion
                
                return new JsonResponse() { Success = true, Message = sURl };
            }
            return new JsonResponse() { Success = false, Message = "请登录再发表回复！"};
            
        }
        /// <summary>
        /// 帖子的添加
        /// </summary>
        /// <param name="channelId">版块的ID</param>
        /// <param name="title">帖子的标题</param>
        /// <param name="content">帖子的内容</param>
        /// <returns></returns>
        [WebMethod(Description = "帖子的添加", EnableSession = true)]
        public int IsTopiceAdd(string channelId, string title, string content)
        {
            int key = 0;
            //ModuleCore.Entity.Topics md = new Topics();
            //md.ChannelID = int.Parse(channelId);
            //md.TopicTitle = title;
            //md.TopicContent = content;
            //long id= ModuleCore.BLL.Topics.Instance.Add(md);
            //if(id>0)
            //{
            //    key = 1;
            //}
            return key;
        }
        /// <summary>
        /// 更新帖子的支持与返回
        /// </summary>
        /// <param name="id">帖子ID，可能是主题也可能是回复</param>
        /// <param name="goodbad">1为支持,0为返回</param>
        /// <param name="ispost">是否主题,否为回复</param>
        /// <returns></returns>
        [WebMethod]
        public int PostGoodBad(int id,int goodbad,bool ispost,int site,int cid)
        {
            if (ispost)
            {
                if (goodbad == 1)
                {
                    EbSite.Base.AppStartInit.GetNewsContentInst(cid).Update(id, "Annex11", "Annex11+1");
                }
                else
                {
                    EbSite.Base.AppStartInit.GetNewsContentInst(cid).Update(id, "Annex12", "Annex12+1");
                }

            }
            else
            {
                if (goodbad == 1)
                {

                    ModuleCore.BLL.TopicReplies.Instance.Update(id, "IsGoodCount", "IsGoodCount+1", cid);
                }
                else
                {
                    ModuleCore.BLL.TopicReplies.Instance.Update(id, "IsBadCount", "IsBadCount+1", cid);
                }
            }
            return 1;
        }

    }
}
