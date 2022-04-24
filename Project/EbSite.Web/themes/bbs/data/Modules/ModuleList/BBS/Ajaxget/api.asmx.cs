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
            return "������HelloString���Ǵ�������ֵ" + username;
        }
        [WebMethod]
        public JsonResponse HelloJson(string username)
        {
            return new JsonResponse() { Success = true, Message = "������HelloJson���Ǵ�������ֵ" + username };
        }
        [WebMethod(Description = "���ӵĻظ�", EnableSession = true)]
        public JsonResponse Hf(int postid, string c,  int ep,int count, int site,int cid,int rs,int uid)
        {
            if(EbSite.Base.Host.Instance.UserID>0)
            {
                bool isok = false;
                string sURl = ModuleCore.BLL.TopicReplies.Instance.AddHf(postid, c, "", count, site, ep, out isok, cid);

               
                    #region �����ʼ�֪ͨ

                    //string postuid = ViewState["postuid"] as string;
                     if (rs==1)
                    {
                        if (uid > 0 && uid != EbSite.Base.AppStartInit.UserID)
                        {
                            string OutPurl = string.Format("http://{0}/{1}",HttpContext.Current.Request.Url.Authority, sURl);

                            EbSite.Base.Host.Instance.SendEmailPoolByUserID(uid, "���˻ظ�����������", string.Format("���˻ظ�����������,��������ʱ��ע��Ӧ��<a target=\"_blank\" href=\"{0}\">������ȥ����</a>��", OutPurl));
                        }

                    }


                    #endregion
                
                return new JsonResponse() { Success = true, Message = sURl };
            }
            return new JsonResponse() { Success = false, Message = "���¼�ٷ���ظ���"};
            
        }
        /// <summary>
        /// ���ӵ����
        /// </summary>
        /// <param name="channelId">����ID</param>
        /// <param name="title">���ӵı���</param>
        /// <param name="content">���ӵ�����</param>
        /// <returns></returns>
        [WebMethod(Description = "���ӵ����", EnableSession = true)]
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
        /// �������ӵ�֧���뷵��
        /// </summary>
        /// <param name="id">����ID������������Ҳ�����ǻظ�</param>
        /// <param name="goodbad">1Ϊ֧��,0Ϊ����</param>
        /// <param name="ispost">�Ƿ�����,��Ϊ�ظ�</param>
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
