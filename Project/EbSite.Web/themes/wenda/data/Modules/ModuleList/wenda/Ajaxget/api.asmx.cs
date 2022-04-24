using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using EbSite.Base;
using EbSite.Base.Json;
using EbSite.Base.Page;
using EbSite.BLL;
using EbSite.Modules.Wenda.ModuleCore.BLL;
using System;
using EbSite.Modules.Wenda.ModuleCore;
using EbSite.Modules.Wenda.ModuleCore.Entity;
using EbSite.Modules.Wenda.ModuleCore.Pages;
using Answers = EbSite.Modules.Wenda.ModuleCore.Entity.Answers;
using UserHelp = EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp;
using EbSite.BLL.User;
using expandanswers = EbSite.Modules.Wenda.ModuleCore.Entity.expandanswers;
using ExpandContent = EbSite.Modules.Wenda.ModuleCore.Entity.ExpandContent;
using expertAsk = EbSite.Modules.Wenda.ModuleCore.Entity.expertAsk;
using NewsContent = EbSite.Entity.NewsContent;
using SameQuestion = EbSite.Modules.Wenda.ModuleCore.Entity.SameQuestion;

namespace EbSite.Modules.Wenda.Ajaxget
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class api : WebServiceBase
    {
        /// <summary>
        /// �õ���վ���SiteID
        /// </summary>
        protected int SiteDI
        {
            get
            {
                return SettingInfo.Instance.GetSiteID;
            }
        }

        [WebMethod]
        public string HelloString(string username)
        {
            return "������HelloString���Ǵ�������ֵ" + username;
        }
        #region ���ר������
        /// <summary>
        /// ���ר������
        /// </summary>
        /// <param name="ly">����</param>
        /// <param name="dq">����</param>
        /// <param name="dm">���ҽ���</param>
        /// <returns></returns>
        [WebMethod]
        public JsonResponse RequestExpert(string ly, string dq, string dm)
        {
            if (EbSite.Base.Host.Instance.UserID > 0)
            {
                EbSite.Base.EntityAPI.MembershipUserEb mdUser = EbSite.Base.Host.Instance.CurrentUser;
                ModuleCore.Entity.ExpertsInfo md = new ModuleCore.Entity.ExpertsInfo();
                md.Area = dq;
                md.Field = ly;
                md.UserID = mdUser.id;
                md.UserName = mdUser.UserName;
                md.UserNiName = mdUser.NiName;
                md.IsAudit = 0; //����δͨ��״̬
                md.Brand = "";
                md.JianJie = dm;
                ModuleCore.BLL.ExpertsControl.Instance.Add(md);
                return new JsonResponse() { Success = true, Message = "�ɹ�������룬�ȴ�����Աͨ��" };
            }
            return new JsonResponse() { Success = false, Message = "���ȵ�¼������!" };
        }
        #endregion
        [WebMethod]
        public JsonResponse HelloJson(string username)
        {
            return new JsonResponse() { Success = true, Message = "������HelloJson���Ǵ�������ֵ" + username };
        }
        ///// <summary>
        /////      
        ///// </summary>
        ///// <param name="pid">���ุ��ID,Ϊ0Ϊ��һ��</param>
        ///// <returns></returns>
        //[WebMethod]
        //public List<TreeItem> BmGetClass(int pid)
        //{

        //    List<Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetSubClass(pid, 0, SiteDI);   //GetListByIDs(pid.ToString(), 2);
        //    List<TreeItem> lstOK = new List<TreeItem>();
        //    foreach (Entity.NewsClass info in lst)
        //    {
        //        lstOK.Add(new TreeItem(info.ID, info.ClassName));   //, info.Level));
        //    }
        //    return lstOK;
        //}
        #region ��� �û� ������ ��ʱ���� ���� ϵͳָ������
        /// <summary>
        /// ��� �û� ������ ��ʱ���� ���� ϵͳָ������
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        private bool IsTimeOut(int userid)
        {
            if (userid > 0)
            {
                int minutes = ConfigControl.Instance.TimeInterval;

                List<Entity.NewsContent> ls = Base.AppStartInit.NewsContentInstDefault.GetListArray("userid=" + userid,
                                                                                                    1, "id desc", "",
                                                                                                    SiteDI);
                if (ls.Count > 0)
                {
                    DateTime addtime = ls[0].AddTime;
                    long i = Core.Strings.cConvert.DateDiff("n", addtime, DateTime.Now);
                    if (i < minutes)
                    {
                        return false;
                    }

                }
                return true;
            }
            return false;
        }
       #endregion

        //var pram = { "NewsTitle": title, "ContentInfo": content,"ScoreDDList":score,"AskClassType":classType };
        //runws("7aaf9c89-d0bc-421b-9045-cdd6ba76c27a", "AddAskClass", pram, aac_runws);

        #region ��������
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="NewsTitle">����</param>
        /// <param name="ContentInfo">����</param>
        /// <param name="ScoreDDList">���ͷ�</param>
        /// <param name="AskClassType">���</param>
        /// <param name="UserID">�û�id</param>
        /// <param name="IsAnonymity">�Ƿ�����</param>
        /// <param name="expansion">��չ��Դ</param>
        /// <param name="tagUserId">��TA���� �û�id</param>
        /// <param name="iemail">���������˵����� Ŀ��  �����������ַ�����˻ش�ʱ���㼰ʱ����������</param>
        /// <param name="ValidCode">��֤��</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public AddAskBkInfo AskContentOp(string NewsTitle, string ContentInfo, string ScoreDDList, string AskClassType, int UserID, int IsAnonymity, string expansion, int tagUserId, string iemail, string ValidCode)
        {
            AddAskBkInfo bkmd = new AddAskBkInfo();
            if (!EbSite.BLL.User.UserIdentity.ValidateSafeCode(ValidCode))
            {
                bkmd.sSafeCoder = "����д����֤���������Ĳ��� !";
                bkmd.IsAddSuccess = false;
            }
            else
            {
                if (IsAllow(true))
                {
                    bkmd.IsCheck = EbSite.Base.Host.Instance.GetIsAuditing();//ϵͳ�� �Ƿ����
                    bkmd.IsAddSuccess = false;
                    bool key = false;
                    if (IsTimeOut(UserID))
                    {

                        #region Ҫ����Email

                        if (!string.IsNullOrEmpty(iemail))
                        {
                            bool isok = BLL.User.MembershipUserEb.Instance.ExistsEmail(iemail);
                            if (!isok)
                            {
                                EbSite.Base.EntityAPI.MembershipUserEb mdUser =
                                    EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(UserID);
                                mdUser.emailAddress = iemail;
                                mdUser.Save();
                                key = true;
                            }
                            else
                            {
                                bkmd.EmailMsg = "��Email�ѱ�ע�ᡣ";
                            }
                        }
                        else
                        {
                            key = true;
                        }

                        #endregion

                        if (key)
                        {
                            #region

                            EbSite.Entity.NewsContent newsContent = new NewsContent();

                            newsContent.ClassID = int.Parse(AskClassType);
                            newsContent.ClassName = EbSite.BLL.NewsClass.GetModel(int.Parse(AskClassType)).ClassName;
                            newsContent.ContentInfo = ContentInfo;
                            newsContent.NewsTitle = NewsTitle;

                            newsContent.Annex1 = ScoreDDList.Trim();
                            newsContent.Annex2 = expansion; //��չ
                            newsContent.Annex3 = "0";
                            newsContent.Annex5 = "0";

                            newsContent.Annex21 = Convert.ToInt32(SystemEnum.AskState.NoSolve);
                            newsContent.Annex6 = DateTime.Now.ToString(); //�������� ʱ��
                            newsContent.Annex9 = DateTime.Now.AddDays(ConfigControl.Instance.AnswerDays).ToString();
                            //��������

                            newsContent.IsAuditing = !EbSite.Base.Host.Instance.GetIsAuditing();
                            //EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.AuditingContent;

                            //  newsContent.Annex12 = 0;//��� 1��ͨ�� 0����ͨ��
                            newsContent.Annex14 = IsAnonymity; //�Ƿ����� 1������ 0��������
                            newsContent.SiteID = SiteDI;
                            newsContent.TitleStyle = "";
                            newsContent.UserID = UserID;
                            //2012-12-07 yhl
                            newsContent.ContentHtmlNameRule = "content/{#TitleSpell#}{#KeyID#}";
                            newsContent.HtmlName = EbSite.BLL.HtmlReNameRule.GetName(newsContent.ContentHtmlNameRule,
                                                                                     newsContent.NewsTitle,
                                                                                     newsContent.ClassName);
                            //�ӵ�ǰ����ת���ļ���
                            newsContent.IsComment = true;
                            int tag = Base.AppStartInit.NewsContentInstDefault.Add(newsContent);

                            if (tag > 0)
                            {
                              
                                bkmd.ID = tag;
                                bkmd.WenPath = EbSite.Base.Host.Instance.GetContentLink(tag, SiteDI, int.Parse(AskClassType));
                              
                                bkmd.IsAddSuccess = true;
                                //��ȥ ��Ӧ�ķ���
                                int iscore = int.Parse(ScoreDDList);
                                if (IsAnonymity == 1)
                                {
                                    iscore += ConfigControl.Instance.NiMingScore;
                                }
                                if (iscore > 0)
                                    EbSite.Base.Host.Instance.MinusUserCreditsByID(UserID, iscore);
                               }

                            //��ʹ�� userhelp
                            UserHelp md = ModuleCore.BLL.UserHelp.Instance.GetEntityByUserID(UserID);
                            if (Equals(md,null) )
                            {
                                EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp model = new UserHelp();
                                model.UserID = UserID;
                                model.QCount = 1; //��������
                                model.ACount = 0; //�ش�����
                                model.AdoptionCount = 0; //��������
                                model.LikeAskClass = ""; //�Ƽ�����
                                model.TotalScore = 0;
                                ModuleCore.BLL.UserHelp.Instance.Add(model);
                            }
                            else
                            {
                               // EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp model = md[0];
                                md.UserID = UserID;
                                md.QCount = md.QCount + 1; //��������
                                ModuleCore.BLL.UserHelp.Instance.Update(md);
                            }

                            if (tagUserId > 0)
                            {
                                
                                string smsg = "��" + NewsTitle + " �������鿴���� <br/><a href='" + Base.Host.Instance.Domain +
                                              Base.Host.Instance.GetContentLink(tag,  SiteDI,int.Parse(AskClassType)) +
                                              "' target='_blank'><span style='color:red;'> ����鿴����</span></a>";

                                SendMsg(tagUserId, "������������", smsg);

                            }

                            #endregion
                        }

                    }
                    else
                    {
                        bkmd.WenPath = ConfigControl.Instance.TimeInterval.ToString();
                    }

                }
            }

            return bkmd;

        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="NewsTitle">����</param>
        /// <param name="ContentInfo">����</param>
        /// <param name="ScoreDDList">���ͷ�</param>
        /// <param name="AskClassType">���</param>
        /// <param name="UserID">�û�id</param>
        /// <param name="IsAnonymity">�Ƿ�����</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true, Description = "�����������")]
        public AddAskBkInfo AddAskContent(string NewsTitle, string ContentInfo, string ScoreDDList, string AskClassType, int UserID, int IsAnonymity, string iemail, string ValidCode)
        {
            return AskContentOp(NewsTitle, ContentInfo, ScoreDDList, AskClassType, UserID, IsAnonymity, "", 0, iemail, ValidCode);
        }

        [WebMethod(EnableSession = true, Description = "�����������")]
        public AddAskBkInfo AddAskContent(string NewsTitle, string ContentInfo, string ScoreDDList, string AskClassType, int UserID, int IsAnonymity, int tagUserId, string iemail, string ValidCode)
        {
            return AskContentOp(NewsTitle, ContentInfo, ScoreDDList, AskClassType, UserID, IsAnonymity, "", tagUserId, iemail, ValidCode);
        }
        #endregion

        #region AddAskContent ��������ӵ�ָ����ר��  �¼�����չ
        [WebMethod(Description = "��������ӵ�ָ����ר��")]
        public int ExpertsAdd(int Qid, int Uid)
        {
            string stitle = "";
            EbSite.Entity.NewsContent mdask = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(Qid);
            if (!Equals(mdask, null))
            {
                stitle = mdask.NewsTitle;
            }
            ModuleCore.Entity.expertAsk md = new expertAsk();
            md.OpTime = DateTime.Now;
            md.Qid = Qid;
            md.State = 0;
            md.UserID = Uid;
            md.Title = stitle;
            int k = ModuleCore.BLL.expertAsk.Instance.Add(md);
            return k;
        }

        #endregion
        #region �ύ����ش�
        /// <summary>
        /// �ύ����ش�
        /// </summary>
        /// <param name="Content">�ش�����</param>
        /// <param name="UID"> �ش���ID</param>
        /// <param name="AskContentID">���� ����ID </param>
        /// <param name="AskUID">������ID</param>
        /// <param name="hideAnwer">�Ƿ����� </param>
        /// <returns></returns>
        [WebMethod(Description = "�ύ����ش�")]
        public SubmitBkInfo SubmitContentInfo(string Content, string UID, string AskContentID, string AskUID, string hideAnwer)
        {
            SubmitBkInfo m = new SubmitBkInfo();
            m.IsCheck = true;
            ModuleCore.Entity.Answers answers = new Answers();
            answers.QID = int.Parse(AskContentID);
            answers.QUserID = int.Parse(AskUID);
            answers.AnswerUserID = int.Parse(UID);
            answers.AnswerContent = Content;
            answers.IsAdoption = false;//����
            answers.AnswerTime = DateTime.Now;
            answers.IsDel = false;
            answers.AnswerIP = Core.Utils.GetClientIP();
            answers.ReferBook = "";
            answers.IsAnonymity = bool.Parse(hideAnwer);
            answers.AnswerUpdateTime = DateTime.Now;
            answers.Score = 0;
            answers.GoodAsk = 0;
            int groupID = EbSite.Base.Host.Instance.RoleID;
            if (EbSite.Base.Host.Instance.GetIsAuditing())
            {
                answers.IsApproved = 0;//��� 1��ͨ�� 0����ͨ��
            }
            else
            {
                answers.IsApproved = 1;//��� 1��ͨ�� 0����ͨ��
            }

            int answeridid = ModuleCore.BLL.Answers.Instance.Add(answers);

            if (answeridid > 0)
            {
                if (!EbSite.Base.Host.Instance.GetIsAuditing())
                {
                    m.IsCheck = false;
                }
                //�� ���� ��Annex11  ��1 �ش�������ܸ���
                EbSite.Entity.NewsContent mdnewcontent = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(int.Parse(AskContentID));
                mdnewcontent.Annex11 = mdnewcontent.Annex11 + 1;
                mdnewcontent.ID = int.Parse(AskContentID);
                Base.AppStartInit.NewsContentInstDefault.Update(mdnewcontent);
                //�ش����� ���Ϸ���
                if (ConfigControl.Instance.AnswerScore > 0)
                    EbSite.Base.Host.Instance.AddUserCreditsByID(int.Parse(UID), ConfigControl.Instance.AnswerScore);
            }

            //��ʹ�� userhelp
            EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp md = ModuleCore.BLL.UserHelp.Instance.GetEntityByUserID(int.Parse(UID));
            if (Equals(md,null))
            {
                EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp model = new UserHelp();
                model.UserID = int.Parse(UID);
                model.QCount = 0;//��������
                model.ACount = 1;//�ش�����
                model.AdoptionCount = 0;//��������
                model.LikeAskClass = "";//�Ƽ�����
                model.TotalScore = 0;
                ModuleCore.BLL.UserHelp.Instance.Add(model);
            }
            else
            {
               // EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp model = md[0];
                md.UserID = int.Parse(UID);
                md.ACount = md.ACount + 1; //�ش�����
                ModuleCore.BLL.UserHelp.Instance.Update(md);
            }

            m.ID = answeridid;//�ش�������е�id
            string userPic = MembershipUserEb.Instance.GetEntity(int.Parse(UID)).AvatarBig;
            string userSpace = EbSite.Base.Host.Instance.GetUserSiteUrl(int.Parse(UID));




            string stTmp = "<div class=\"tab2_onecur\">" +
                          "<div class=\"tab2_photo\">" +
                          "<li> <a href='{1}' target=\"_blank\"><img src='{0}' width=\"63\" /> </a></li>" +
                          "</div>" +
                          " <div class=\"tab2_name\" style=\"width: 640px;\">" +
                          "<div class=\"tab2_que\">" +
                          " <li>{2}</li></div>" +
                          " <div class=\"tab2_min\">" +
                          "<li>�ش�</li><li>" +
                          "{4}</li><li style=\"width: 20px;\">" +
                          "</li> <li>�ش�ʱ�䣺</li><li>" +
                          "{3}</li>" +
                          "</div> </div>" +
                          "<div class=\"clear\"></div>  <div class=\"tab2_time\">" +
                          "</div>" +
                          "</div>";
            string ss =
                " <div style='width:720px;'><div style='float:left; width:120px;'> <div style=\"text-align: center\"> <img src='{0}' width=\"80\" /> </div>" +
                "<div style=\"margin-left: 1px;text-align: center;\"> <a href=\"{1}\" target=\"_blank\">{2} </a> </div></div>" +

                " <div style='float:left; margin-left:10px;'> <div class='ans_wrapper' >{3}</div>" +
                "  <div style=' margin: 10 auto; line-height: 30px'> <div style='border-bottom: 1px dashed #ccc; height: 2px; margin-top: 10px; margin-bottom: 10px;' >  </div>" +
                "<div style='float: right; color: #aaa'>�ش�ʱ��:{4}  </div></div></div></div>";
            if (bool.Parse(hideAnwer))
            {
                ss = string.Format(ss, "/themes/asktheme/css/images/nopic.gif", "", "��������", Core.UBB.Ubb2Html(Content), DateTime.Now);
            }
            else
            {
                stTmp = string.Format(stTmp, userPic, userSpace, Content, DateTime.Now, AskCommon.GetUserName(UID).ToString());
            }
            m.Info = stTmp;

            //����վ�ڶ���
            EbSite.Entity.NewsContent mdask = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(int.Parse(AskContentID));

            string smsg = "�������⡰" + mdask.NewsTitle + " ���Ѿ����˻ظ��������鿴���� <br/><a href='" + Base.Host.Instance.Domain + Base.Host.Instance.GetContentLink(mdask.ID, SiteDI, mdask.ClassID) + "' target='_blank'><span style='color:red;'> ����鿴����</span></a>";
            SendMsg(int.Parse(AskUID), "���������Ѿ����˻ظ�", smsg);


            List<ModuleCore.Entity.SameQuestion> sqls = ModuleCore.BLL.SameQuestion.Instance.GetListArray(0, "cid=" + AskContentID, "");
            if (sqls.Count > 0)
            {
                foreach (SameQuestion xi in sqls)
                {
                    string smsgx = "��ͬ�ʵ����⡰" + mdask.NewsTitle + " ���Ѿ����˻ظ��������鿴���� <br/><a href='" + Base.Host.Instance.Domain + Base.Host.Instance.GetContentLink(mdask.ID, SiteDI,mdask.ClassID) + "' target='_blank'> <span style='color:red;'> ����鿴����</span></a>";
                    SendMsg(int.Parse(xi.UserId.ToString()), "��ͬ�ʵ������Ѿ����˻ظ�", smsgx);
                }
            }
            ModifyExpert(int.Parse(AskContentID), int.Parse(UID));
            return m;

        }
   

        
        /// <summary>
        /// �ش��¼��� ��չ ���� ר�һش�ʱ��Ҫ�� ״̬��Ϊ �ѻش�
        /// </summary>
        /// <param name="Qid">����id</param>
        /// <param name="expertID">ר��id  �û�id</param>
        private void ModifyExpert(int Qid, int expertID)
        {
            if (Qid > 0 && expertID > 0)
            {
                string str = string.Concat("state=0 and userid=", expertID, " and qid=", Qid);

                List<ModuleCore.Entity.expertAsk> ls = ModuleCore.BLL.expertAsk.Instance.GetListArray(1, str, "");

                if (ls.Count > 0)
                {
                    ls[0].State = 1;// ���
                    ls[0].AskDate = DateTime.Now;
                    ModuleCore.BLL.expertAsk.Instance.Update(ls[0]);
                }

            }
        }
        #endregion

        #region �����Ѵ�

        [WebMethod(Description = "�����Ѵ�")]
        public AnswerInfo GetBestAnswer(string AskID)
        {
            AnswerInfo info = new AnswerInfo();
            if (!string.IsNullOrEmpty(AskID))
            {
                string sqlStr = " IsAdoption={0} AND QID={1} ";
                sqlStr = string.Format(sqlStr, 1, AskID);
                var list = ModuleCore.BLL.Answers.Instance.GetListArray(sqlStr);
                if (list.Count == 1)
                {
                    string aid = list[0].AnswerUserID.ToString();
                    string acontent = list[0].AnswerContent;
                    string aname = AskCommon.GetUserName(aid);
                    info.AContent = acontent;
                    info.AName = aname;
                    info.AnswerID = list[0].id;
                    info.GoodSum = int.Parse(list[0].GoodAsk.ToString());
                    Base.EntityAPI.MembershipUserEb _UserInfos =
                        MembershipUserEb.Instance.GetEntity(list[0].AnswerUserID);
                    info.AvatarBig = _UserInfos.AvatarBig;
                }
            }
            return info;
        }
        #endregion

        #region �Բ��ɴ� ����
        [WebMethod(Description = "ͶƱ ����")]
        public int OppVote(int answerid)
        {
            if (answerid > 0)
            {
                ModuleCore.Entity.Answers md = ModuleCore.BLL.Answers.Instance.GetEntity(answerid);
                md.GoodAsk = md.GoodAsk + 1;
                md.id = answerid;
                ModuleCore.BLL.Answers.Instance.Update(md);
                return int.Parse(md.GoodAsk.ToString());
            }
            return 0;
        }
        #endregion


        #region ��ȡ����Ĵ�
        [WebMethod(Description = "��ȡ����Ĵ�")]
        public string GetAnswerContent(string AskQuestionID, string AnswerUid)
        {
            string s = "";
            if (!string.IsNullOrEmpty(AskQuestionID) && !string.IsNullOrEmpty(AnswerUid))
            {
                string sqlStr = " QID={0} AND AnswerUserID={1} ";
                sqlStr = string.Format(sqlStr, AskQuestionID, AnswerUid);
                var list = ModuleCore.BLL.Answers.Instance.GetListArray(sqlStr);

                if (list.Count == 1)
                {
                    s = list[0].AnswerContent;
                }
            }
            return s;
        }
        #endregion 

        #region �ж��û��Ƿ�ش��
        [WebMethod(Description = "�ж��û��Ƿ�ش��")]
        public bool IsHaveAnswer(string AskID)
        {
            bool key = false;
            int currentUid = EbSite.Base.Host.Instance.UserID;
            if (currentUid > 0 && !string.IsNullOrEmpty(AskID))
            {
                string sqlStr = " QID={0} AND AnswerUserID={1} ";
                sqlStr = string.Format(sqlStr, AskID, currentUid);
                var list = ModuleCore.BLL.Answers.Instance.GetListArray(sqlStr);
                if (list.Count > 0)
                {
                    key = true;
                }
            }
            return key;
        }
        #endregion

        #region �޸Ĵ�
        /// <summary>
        /// key  0 ʧ�� 1��������� 2.�������
        /// </summary>
        /// <param name="AskContentID">����id </param>
        /// <param name="UID">������id</param>
        /// <param name="Content">�޸�����</param>
        /// <returns></returns>
        [WebMethod(Description = "�޸Ĵ�")]
        public int UpdateContentInfo(string AskContentID, string UID, string Content)
        {
            int key = 0;
            string sqlStr = " QID={0} AND AnswerUserID={1} ";
            sqlStr = string.Format(sqlStr, AskContentID, UID);
            var list = ModuleCore.BLL.Answers.Instance.GetListArray(sqlStr);
            var askModel = Base.AppStartInit.NewsContentInstDefault.GetModelByFiledOfDefault("Annex21", string.Format("id={0}", int.Parse(AskContentID)));

            if (list.Count == 1 && askModel.Annex21 == Convert.ToInt32(SystemEnum.AskState.NoSolve))
            {
                var item = list[0];
                item.AnswerContent = Content;
                if (EbSite.Base.Host.Instance.GetIsAuditing())
                {
                    item.IsApproved = 0;
                    key = 1;
                }
                else
                {
                    item.IsApproved = 1;
                    key = 2;
                }

                ModuleCore.BLL.Answers.Instance.Update(item);
                return key;
            }
            else
            {
                return key;
            }
        }
        #endregion

        #region  ���ô�Ϊ��Ѵ�
        /// <summary>
        /// ���ô�Ϊ��Ѵ�
        /// </summary>
        /// <param name="AskContentID">�����ID---QID</param>
        /// <param name="AnswerUid">�ش���ID</param>
        /// <param name="ctent">��������</param>
        /// <returns></returns>
        [WebMethod(Description = "���ô�Ϊ��Ѵ�")]
        public ThankModel SetTheBestAnswer(string AskContentID, string AnswerUid, string ctent)
        {
            ThankModel mdoel = new ThankModel();
            ModuleCore.Entity.Answers answers = new Answers();
            if (!string.IsNullOrEmpty(AskContentID) && !string.IsNullOrEmpty(AnswerUid))
            {
                string sqlStr = " QID={0} AND AnswerUserID={1} ";
                sqlStr = string.Format(sqlStr, AskContentID, AnswerUid);
                var list = ModuleCore.BLL.Answers.Instance.GetListArray(sqlStr);

                string sqlStr1  = string.Format("ID={0}", AskContentID);
                var list1 = Base.AppStartInit.NewsContentInstDefault.GetListArray(sqlStr1, 1, "", "*", SiteDI);

                if (list.Count == 1 && list1.Count == 1)
                {
                    answers = list[0];
                    answers.IsAdoption = true;
                    answers.ThanksInfo = ctent;
                    ModuleCore.BLL.Answers.Instance.Update(answers);

                    EbSite.Entity.NewsContent newsContent = list1[0];
                    newsContent.Annex21 = Convert.ToInt32(SystemEnum.AskState.YesSolve);

                    Base.EntityAPI.MembershipUserEb umd =
                        EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(Convert.ToInt32(AnswerUid));
                    newsContent.Annex7 = umd.UserName;

                    newsContent.Annex10 = DateTime.Now.ToString(); //���ʱ��
                    Base.AppStartInit.NewsContentInstDefault.Update(newsContent);

                  
                   
                    var answerid = answers.AnswerUserID;

                    int score = int.Parse(newsContent.Annex1);
                    if (score > 0)
                        EbSite.Base.Host.Instance.AddUserCreditsByID(answerid, score);

                    EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp md =
                        ModuleCore.BLL.UserHelp.Instance.GetEntityByUserID(int.Parse( AnswerUid));

                    if (!Equals(md,null))
                    {
                      //  EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp model = md[0];
                        md.UserID = int.Parse(AnswerUid);
                        md.AdoptionCount = md.AdoptionCount + 1; //��������
                        ModuleCore.BLL.UserHelp.Instance.Update(md);
                    }
                    mdoel.Key = true;
                }
                else
                {
                    mdoel.Key = false;
                }

                //�Ժ��Ϊ�첿�� ����

                string str = "";
                string fabiao = "<div style=\"clear:both; margin-top:15px; margin-bottom:10px;\">" +
                                "<div id=\"showthankinfo\"><div> ������ {0} �ĸ���:</div> <div style=\" margin-top:5px; margin-bottom:5px;\"> {1}</div> </div></div>";
                mdoel.Key = true;
                string usserspace = EbSite.Base.Host.Instance.GetUserSiteUrl(answers.QUserID);
                string asname = AskCommon.GetUserName(answers.QUserID.ToString());
                string i = "<a href=" + usserspace + " target=\"_blank\"><span style='color:red;'>" + asname +
                           "</span></a>";
                mdoel.ThInfo = string.Format(fabiao, i, ctent);

                //����վ�ڶ���
                EbSite.Entity.NewsContent mdask =
                    Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(int.Parse(AskContentID));

                string smsg = "���ش�ġ�" + mdask.NewsTitle + " ���Ѿ���ѡΪ��Ѵ𰸣������鿴���� <br/><a href='" +
                              Base.Host.Instance.Domain +
                              Base.Host.Instance.GetContentLink(mdask.ID, SiteDI, mdask.ClassID) +
                              "' target='_blank'> <span style='color:red;'> ����鿴����</span></a>";
                SendMsg(list[0].AnswerUserID, "���Ļش��ѱ�ѡΪ��Ѵ𰸡�", smsg);


            }
            return mdoel;
        }

        #endregion

        /// <summary>
        /// ����Ϊ�����(�ֻ���)_flz
        /// </summary>
        /// <param name="answerid">�ش��ID</param>
        /// <param name="thankInfo">��л����</param>
        /// <returns></returns>
        [WebMethod(Description = "����Ϊ�����")]
        public string SetBestAnswer(int answerid, string thankInfo)
        {

            //���»ش��
            ModuleCore.Entity.Answers answerModel = ModuleCore.BLL.Answers.Instance.GetEntity(answerid);

            //���������
            EbSite.Entity.NewsContent newsContent = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(answerModel.QID);
            if (newsContent.Annex21 == Convert.ToInt32(SystemEnum.AskState.YesSolve))
            {
                return "0";
            }
            answerModel.IsAdoption = true;
            answerModel.ThanksInfo = thankInfo;
            ModuleCore.BLL.Answers.Instance.Update(answerModel);


            newsContent.Annex21 = Convert.ToInt32(SystemEnum.AskState.YesSolve);
            Base.EntityAPI.MembershipUserEb umd = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(answerModel.AnswerUserID);
            newsContent.Annex7 = umd.UserName;
            newsContent.Annex10 = DateTime.Now.ToString();//���ʱ��
            Base.AppStartInit.NewsContentInstDefault.Update(newsContent);

            //���»���
            int score = Core.Utils.StrToInt(newsContent.Annex1, 0);
            if (score > 0)
            {
                EbSite.Base.Host.Instance.AddUserCreditsByID(answerModel.AnswerUserID, score);
            }
            //���²�����
            List<EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp> md = ModuleCore.BLL.UserHelp.Instance.GetListArray("userid=" + answerModel.AnswerUserID);
            if (md.Count > 0)
            {
                EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp model = md[0];
                model.UserID = answerModel.AnswerUserID;
                model.AdoptionCount = model.AdoptionCount + 1; //��������
                ModuleCore.BLL.UserHelp.Instance.Update(model);
            }

            //����վ�ڶ���
            string smsg = "���ش�ġ�" + newsContent.NewsTitle + " ���Ѿ���ѡΪ��Ѵ𰸣������鿴���� <br/><a href='" + Base.Host.Instance.Domain + Base.Host.Instance.GetContentLink(newsContent.ID,  SiteDI,newsContent.ClassID) + "' target='_blank'> <span style='color:red;'> ����鿴����</span></a>";
            SendMsg(answerModel.AnswerUserID, "���Ļش��ѱ�ѡΪ��Ѵ𰸡�", smsg);

            return "1";
        }

        /// <summary>
        /// �ύ����Ļش�(�ֻ���)_flz
        /// </summary>
        /// <param name="qid"></param>
        /// <param name="quid"></param>
        /// <param name="auid"></param>
        /// <param name="context"></param>
        /// <param name="isanonymity"></param>
        /// <returns></returns>
        [WebMethod(Description = "�ύ����Ļش�")]
        public string SubmitAnswer(int qid, int quid, int auid, string context, int isanonymity)
        {


            if (EbSite.Base.Host.Instance.UserID < 0)
            {
                return EbSite.Base.Host.Instance.MLoginRw + "?ru=" +
                       EbSite.Base.Host.Instance.MGetContentLink(qid, SettingInfo.Instance.GetSiteID);

            }
            else
            {

                //�ж��Ƿ��Ѿ��ش��������
                string sqlStr = " QID={0} AND AnswerUserID={1} ";
                sqlStr = string.Format(sqlStr, qid, auid);
                var list = ModuleCore.BLL.Answers.Instance.GetListArray(sqlStr);
                if (list == null || list.Count == 0)
                {
                    //��ӻش�
                    ModuleCore.Entity.Answers answers = new Answers();
                    answers.QID = qid;
                    answers.QUserID = quid;
                    answers.AnswerUserID = auid;
                    answers.AnswerContent = context;
                    answers.IsAdoption = false;
                    answers.AnswerTime = DateTime.Now;
                    answers.IsDel = false;
                    answers.AnswerIP = Core.Utils.GetClientIP();
                    answers.ReferBook = "";
                    answers.IsAnonymity = isanonymity > 0 ? true : false;
                    answers.AnswerUpdateTime = DateTime.Now;
                    answers.Score = 0;
                    answers.GoodAsk = 0;
                    if (EbSite.Base.Host.Instance.GetIsAuditing())
                    {
                        answers.IsApproved = 0; //��� 1��ͨ�� 0����ͨ��
                    }
                    else
                    {
                        answers.IsApproved = 1; //��� 1��ͨ�� 0����ͨ��
                    }

                    int i = ModuleCore.BLL.Answers.Instance.Add(answers);
                    //���������ӳɹ�
                    if (i > 0)
                    {
                        EbSite.Entity.NewsContent mdnewcontent = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(qid);
                        mdnewcontent.Annex11 = mdnewcontent.Annex11 + 1;
                        mdnewcontent.ID = qid;
                        Base.AppStartInit.NewsContentInstDefault.Update(mdnewcontent);
                        //�ش����� ���Ϸ���
                        if (ConfigControl.Instance.AnswerScore > 0)
                        {
                            EbSite.Base.Host.Instance.AddUserCreditsByID(auid, ConfigControl.Instance.AnswerScore);
                        }
                    }

                    //��ʹ�� userhelp
                    List<EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp> md =
                        ModuleCore.BLL.UserHelp.Instance.GetListArray("userid=" + auid);
                    if (md.Count == 0)
                    {
                        EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp model = new UserHelp();
                        model.UserID = auid;
                        model.QCount = 0; //��������
                        model.ACount = 1; //�ش�����
                        model.AdoptionCount = 0; //��������
                        model.LikeAskClass = ""; //�Ƽ�����
                        model.TotalScore = 0;
                        ModuleCore.BLL.UserHelp.Instance.Add(model);
                    }
                    else
                    {
                        EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp model = md[0];
                        model.UserID = auid;
                        model.ACount = model.ACount + 1; //�ش�����
                        ModuleCore.BLL.UserHelp.Instance.Update(model);
                    }

                    //����վ�ڶ���
                    EbSite.Entity.NewsContent mdask = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(qid);
                    string smsg = "�������⡰" + mdask.NewsTitle + " ���Ѿ����˻ظ��������鿴���� <br/><a href='" +
                                  Base.Host.Instance.Domain +
                                  Base.Host.Instance.GetContentLink(mdask.ID,  SiteDI,mdask.ClassID) +
                                  "' target='_blank'><span style='color:red;'> ����鿴����</span></a>";
                    SendMsg(quid, "���������Ѿ����˻ظ�", smsg);
                    List<ModuleCore.Entity.SameQuestion> sqls = ModuleCore.BLL.SameQuestion.Instance.GetListArray(0,
                                                                                                                  "cid=" +
                                                                                                                  qid,
                                                                                                                  "");
                    if (sqls.Count > 0)
                    {
                        foreach (SameQuestion xi in sqls)
                        {
                            string smsgx = "��ͬ�ʵ����⡰" + mdask.NewsTitle + " ���Ѿ����˻ظ��������鿴���� <br/><a href='" +
                                           Base.Host.Instance.Domain +
                                           Base.Host.Instance.GetContentLink(mdask.ID,  SiteDI,mdask.ClassID) +
                                           "' target='_blank'> <span style='color:red;'> ����鿴����</span></a>";
                            SendMsg(int.Parse(xi.UserId.ToString()), "��ͬ�ʵ������Ѿ����˻ظ�", smsgx);
                        }
                    }
                    ModifyExpert(qid, auid);
                    return "1";
                }
                else
                {
                    return "2";
                }
            }
        }

        #region �ж��û��Ƿ��Ѿ��ش��
        [WebMethod(Description = "�ж��û��Ƿ��Ѿ��ش��")]
        public bool UserHaveSay(string UID, string AskContentID)
        {
            string sqlStr = " QID={0} AND AnswerUserID={1} ";
            sqlStr = string.Format(sqlStr, AskContentID, UID);
            var list = ModuleCore.BLL.Answers.Instance.GetListArray(sqlStr);

            if (list.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region �������
        [WebMethod(Description = "�������")]
        public bool CloseAsk(string ContentID)
        {
            EbSite.Entity.NewsContent content = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(int.Parse(ContentID));
            if (null != content)
            {
                content.Annex21 = Convert.ToInt32(SystemEnum.AskState.Close);
                content.Annex10 = DateTime.Now.ToString();//�ر�ʱ��
                Base.AppStartInit.NewsContentInstDefault.Update(content);

                return true;
            }
            else
                return false;
        }
        #endregion

        #region �õ��û��Ļ���
        [WebMethod(Description = "�õ��û��Ļ���")]
        public int GetUserCredits(int UserID)
        {
            int score = EbSite.Base.Host.Instance.GetUserCreditsByID(UserID);
            return score;
        }
        #endregion



        #region �û��Ƿ�����ղ�����

        [WebMethod(Description = "�û��Ƿ�����ղ�����")]
        public bool GetIfFav(int UserID)
        {
            bool key = false;
            int score = EbSite.Base.Host.Instance.GetUserCreditsByID(UserID);
            int iscore = ConfigControl.Instance.FavLevelScore;
            if (score >= iscore)
            {
                key = true;
            }
            return key;
        }
        #endregion

        #region �û��Ƿ���Ծٱ�����
        [WebMethod(Description = "�û��Ƿ���Ծٱ�����")]
        public bool GetIfJuBao(int UserID)
        {
            bool key = false;
            int score = EbSite.Base.Host.Instance.GetUserCreditsByID(UserID);
            int iscore = ConfigControl.Instance.JuBaoScore;
            if (score >= iscore)
            {
                key = true;
            }
            return key;
        }
        #endregion

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="id">����ID</param>
        /// <param name="info">��������</param>
        /// <returns></returns>
        [WebMethod(Description = "��������")]
        public string AddedAskInfo(int id, string info,int classid)
        {
            string tempTwo = "<div class=\"jgbcwt\"> <li style=\"color: #A0A19D; line-height: 25px;\"><span>��������</span>��{0}</li><li style=\"margin-left: 20px;\">{1}</li></div>";


            string s = "";
            ModuleCore.Entity.ExpandContent model = new ExpandContent();
            model.Cid = id;
            model.ClassID = classid;
            model.TDate = DateTime.Now;
            model.Ctent = Core.UBB.Ubb2Html(info);
            int k = ModuleCore.BLL.ExpandContent.Instance.Add(model);
            if (k > 0)
            {
                s = string.Format(tempTwo, model.TDate, model.Ctent);
            }
            return s;
        }

        #endregion


        [WebMethod(Description = "����׷�����ͷֺ󣬿����ӳ��رյ�����")]
        public UpScoreModel1 UpScoreModel()
        {
            UpScoreModel1 md = new UpScoreModel1();
            md.Days = ConfigControl.Instance.Days;
            md.Score = ConfigControl.Instance.Score;
            md.NiMingScore = ConfigControl.Instance.NiMingScore;
            md.NiMingAnswer = ConfigControl.Instance.NiMingAnswer;
            return md;
        }

        #region  ������ͷֶ���
        /// <summary>
        /// ������ͷֶ���
        /// </summary>
        /// <param name="cid">����id</param>
        /// <param name="score">���ͷ���</param>
        /// <returns></returns>
        [WebMethod(Description = "������ͷֶ���, ͬʱ�۳� ���˵ķ���")]
        public bool UpScoreOp(int cid, int score)
        {
            bool tag = false;
            EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(cid);
            int personscore = EbSite.Base.Host.Instance.GetUserCreditsByID(md.UserID);
            if (personscore >= score)
            {

                md.Annex1 = (int.Parse(md.Annex1) + score).ToString(); //���ͷ�
                //ϵͳ�Զ��ӳ����������Ч�� 3 �죻
                md.Annex9 = DateTime.Parse(md.Annex9).AddDays(ConfigControl.Instance.Days).ToString(); //��������
                //�����һ��׷������ 20 �����ϣ��� 20 �֣���ϵͳ�Ὣ���������ڷ���ġ���������⡱�б�����ʾΪ���£�����������������⡣
                int iscore = ConfigControl.Instance.Score;
                if (iscore <= score)
                {
                    md.Annex13 = 1;
                    md.Annex8 = DateTime.Now.ToString();

                }
                Base.AppStartInit.NewsContentInstDefault.Update(md);

                EbSite.Base.Host.Instance.MinusUserCreditsByID(md.UserID, score);
                tag = true;
            }
            return tag;
        }
        #endregion

        #region ���׷��
        /// <summary>
        /// ���׷�� �ش�
        /// </summary>
        /// <param name="answersid">�ش� id</param>
        /// <param name="ctent">����</param>
        /// <param name="typeid">���� 0��׷�� 1���ش�</param>
        /// <param name="eid">�ش��Ӧ ��׷�ʵ�id</param>
        /// <returns></returns>
        [WebMethod(Description = "���׷��")]
        public bool GoToAddAsk(int answersid, string ctent, int typeid, string eid)
        {
            bool key = false;
            ModuleCore.Entity.expandanswers md = new expandanswers();
            md.AnswerId = answersid;
            md.Ctent = ctent;
            md.TDate = DateTime.Now;
            md.TypeId = typeid;
            ModuleCore.Entity.Answers msd = ModuleCore.BLL.Answers.Instance.GetEntity(answersid);
            EbSite.Entity.NewsContent mdask = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(msd.QID);
            if (typeid == 1)
            {
                md.Eid = int.Parse(eid);
                //�ش�
                //����վ�ڶ���
                string smsg = "�������µĻش�" + mdask.NewsTitle + " �������鿴���� <br/><a href='" + Base.Host.Instance.Domain + Base.Host.Instance.GetContentLink(mdask.ID,  SiteDI,mdask.ClassID) + "' target='_blank'> <span style='color:red;'> ����鿴����</span></a>";
                SendMsg(msd.QUserID, "�������µĻش�" + mdask.NewsTitle + "", smsg);

            }
            else
            {
                //׷��
                //����վ�ڶ���

                string smsg = "�������µ�׷�ʡ�" + mdask.NewsTitle + " �������鿴���� <br/><a href='" + Base.Host.Instance.Domain + Base.Host.Instance.GetContentLink(mdask.ID, SiteDI, mdask.ClassID) + "' target='_blank'> <span style='color:red;'> ����鿴����</span></a>";
                SendMsg(msd.AnswerUserID, "�������µ�׷�ʡ�" + mdask.NewsTitle + " ", smsg);

            }
            md.Uid = Base.Host.Instance.CurrentUser.id;
            int idd = ModuleCore.BLL.expandanswers.Instance.Add(md);
            if (idd > 0)
                key = true;
            return key;
        }

        #endregion

        #region �������� ����վ����Ϣ

        /// <summary>
        /// ��� ��Ϣ
        /// </summary>
        /// <param name="recipientuserid"> ͳһ���� �û�ID</param>
        /// <param name="title">����</param>
        /// <param name="ctent">����</param>
        private void SendMsg(int recipientuserid, string title, string ctent)
        {
            EbSite.BLL.Msg msg = new Msg();
            msg.RecipientUserID = recipientuserid;
            msg.SenderUserID = base.UserID();
            msg.SenderNiName = base.UserName();
            msg.MsgContent = ctent;
            msg.Title = title;
            msg.SendDate = DateTime.Now;
            msg.IsNewMsg = false;
            msg.FolderType = 1;//�ռ�
            string us = MembershipUserEb.Instance.GetEntity(recipientuserid).UserName;
            msg.Recipient = us;
            msg.Sender = base.UserName();
            msg.Save();

            EbSite.Base.EntityAPI.MembershipUserEb mdCurrentUser =
                EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(recipientuserid);

            EbSite.Base.Host.Instance.SendEmailPool(mdCurrentUser.emailAddress, title, ctent);


        }
        #endregion

        [WebMethod(Description = "���Ҷ��ŵ�����")]
        public string GetMsgModel(int id)
        {

            EbSite.BLL.Msg mds = EbSite.BLL.Msg.GetMsg(id);
            mds.IsNewMsg = true;
            string strinfo = "";
            strinfo = EbSite.BLL.Msg.GetMsg(id).MsgContent;
            mds.Save();
            return strinfo;
        }

        /// <summary>
        /// ����Ƿ��� ͬ��
        /// </summary>
        /// <param name="cid">����ID</param>
        /// <param name="userid">�û�ID</param>
        /// <returns></returns>
        [WebMethod(Description = "����Ƿ��� ͬ��")]
        public bool IfSameQuestion(int cid, int userid)
        {
            bool key = true;
            List<ModuleCore.Entity.SameQuestion> ls = ModuleCore.BLL.SameQuestion.Instance.GetListArray(0, " userid=" + userid + " and cid=" + cid, "");
            if (ls.Count > 0)
            {
                key = false;
            }
            return key;

        }

        #region ͬ��
        /// <summary>
        /// ���ͬ��
        /// </summary>
        /// <param name="cid">����ID</param>
        /// <param name="userid">�û�ID</param>
        /// <returns></returns>
        [WebMethod(Description = "���ͬ��")]
        public int SameQuestionOp(int cid, int userid)
        {
            if (IfSameQuestion(cid, userid))
            {
                EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(cid);
                md.Annex15 += 1;
                md.ID = cid;
                Base.AppStartInit.NewsContentInstDefault.Update(md);

                ModuleCore.Entity.SameQuestion sqmd = new SameQuestion();
                sqmd.Cid = cid;
                sqmd.UserId = userid;
                sqmd.TDate = DateTime.Now;
                int k = ModuleCore.BLL.SameQuestion.Instance.Add(sqmd);
                if (k > 0)
                    return int.Parse(md.Annex15.ToString());
            }
            return SameQuestionOpSel(cid);
        }
        /// <summary>
        /// ����ͬ��
        /// </summary>
        /// <param name="cid">����ID</param>
        /// <returns></returns>
        [WebMethod(Description = "����ͬ��")]
        public int SameQuestionOpSel(int cid)
        {
            EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(cid);
            return int.Parse(md.Annex15.ToString());

        }
        #endregion

      


        #region ���  GetBmAskClassList ʹ��
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="bl">true һ����� false �������</param>
        /// <returns></returns>
        [WebMethod(Description = "��ȡ�ʴ�����ܸ���")]
        public int GetBmAskClassListCount(int pid, bool bl)
        {
            string strsql = "";
            if (bl)
            {
                strsql = "annex10=1 ";
            }
            else
            {
                strsql = "ParentID =" + pid;
            }
            List<Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetListArr(strsql, 0, SiteDI);
            // List<Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetSubClass(pid, 0, SiteDI);   //GetListByIDs(pid.ToString(), 2);
            return lst.Count;
        }


        #endregion

        #region ����ҳ ����İ�
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="bl">true һ����� false �������</param>
        /// <returns></returns>
        [WebMethod(Description = "��ȡ�ʴ����")]
        public string GetBmAskClassList(int pid, bool bl)
        {
            string strsql = "";
            if (bl)
            {
                strsql = "annex10=1 ";
            }
            else
            {
                strsql = "ParentID=" + pid;
            }
            List<Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetListArr(strsql, 0, SiteDI);//.GetSubClass(pid, 0, SiteDI);   //GetListByIDs(pid.ToString(), 2);


            List<TreeItem> lstOK = new List<TreeItem>();
            foreach (Entity.NewsClass info in lst)
            {
                lstOK.Add(new TreeItem(info.ID, info.ClassName));   //, info.Level));
            }
            StringBuilder sbHtml = new StringBuilder();
            sbHtml.AppendFormat("<option value=\"{0}\" id=\"{1}\">{2}</option>", "-1", 0, "��ѡ����������");

            if (lst.Count > 0)
            {
                List<Entity.NewsClass> nlst = (from i in lst orderby i.Annex2 select i).ToList();
                foreach (EbSite.Entity.NewsClass model in nlst)
                {
                    if (model != null)
                    {
                        if (model.Annex10 == "1")
                        {
                            sbHtml.AppendFormat("<option value=\"{0}\" name=\"{1}\" id=\"{3}\">{4}-{2}</option>", model.ID, model.ClassName, model.ClassName, model.Annex1, model.Annex2);
                        }
                        else
                        {
                            sbHtml.AppendFormat("<option value=\"{0}\" name=\"{1}\" id=\"{3}\">{2}</option>", model.ID, model.ClassName, model.ClassName, model.Annex1);
                        }
                    }
                }
            }
            return sbHtml.ToString();
        }

        #endregion

        #region ���ͷ�
        [WebMethod(Description = "��ȡ�ʴ����ͻ���")]
        public string GetBmAskScore()
        {

            StringBuilder sbHtml = new StringBuilder();
            sbHtml.AppendFormat("<option value=\"{0}\">{1}</option>", "0", "���ͷ�");

            string scoure = "0,5,10,15,20,30,50,80,100";
            string[] arry = scoure.Split(',');

            foreach (string s in arry)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    sbHtml.AppendFormat("<option value=\"{0}\" name=\"{0}\">{0}</option>", s);
                }
            }

            return sbHtml.ToString();
        }

        #endregion

        [WebMethod(Description = "�õ��Ƿ���UBB")]
        public bool GetIsUbb()
        {
            return ConfigControl.Instance.IsUbb;
        }

        [WebMethod(Description = "�õ������۵ĸ���")]
        public int GoodCount(int id)
        {
            int iCount = 0;
            ModuleCore.Entity.Answers list = ModuleCore.BLL.Answers.Instance.GetEntity(id);
            if (!Equals(list, null))
            {
                iCount = int.Parse(list.GoodAsk.ToString());
            }
            return iCount;
        }

        static private int GetRandNum()
        {
            int min = 1;
            int max = 1000;
            Random a = new Random();
            int result = a.Next(min, max);

            return result;

        }

    }
    public class AnswerInfo
    {
        private string _AName;
        private string _AContent;
        private int _answerid;
        private int _goodsum;
        private string _avatarbig;
        /// <summary>
        /// ��ͷ��·��
        /// </summary>
        public string AvatarBig
        {
            set { _avatarbig = value; }
            get { return _avatarbig; }
        }
        public string AName
        {
            set { _AName = value; }
            get { return _AName; }
        }
        public string AContent
        {
            set { _AContent = value; }
            get { return _AContent; }
        }
        public int AnswerID
        {
            set { _answerid = value; }
            get { return _answerid; }
        }
        public int GoodSum
        {
            get { return _goodsum; }
            set { _goodsum = value; }
        }
    }
    /// <summary>
    /// �������� ���ĵĶ���
    /// </summary>
    public class AddAskBkInfo
    {
        private bool _isaddsuccess;
        private bool _ischeck;
        private int _id;
        private string _wenpath;
        /// <summary>
        /// �Ƿ���ӳɹ�
        /// </summary>
        public bool IsAddSuccess
        {
            get { return _isaddsuccess; }
            set { _isaddsuccess = value; }
        }
        /// <summary>
        /// �Ƿ����
        /// </summary>
        public bool IsCheck
        {
            get { return _ischeck; }
            set { _ischeck = value; }
        }
        /// <summary>
        /// ��Ӻ��ID
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string WenPath
        {
            get { return _wenpath; }
            set { _wenpath = value; }
        }

        private string _emailmsg;
        public string EmailMsg
        {
            get { return _emailmsg; }
            set { _emailmsg = value; }
        }

        private string _ssafecoder;
        /// <summary>
        /// ��֤��
        /// </summary>
        public string sSafeCoder
        {
            get { return _ssafecoder; }
            set { _ssafecoder = value; }
        }
    }
    /// <summary>
    /// �ύ���� ���ĵĶ���
    /// </summary>
    public class SubmitBkInfo
    {
        private int _id;
        private string _info;
        private bool _ischeck;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Info
        {
            get { return _info; }
            set { _info = value; }
        }
        /// <summary>
        /// �Ƿ����
        /// </summary>
        public bool IsCheck
        {
            get { return _ischeck; }
            set { _ischeck = value; }
        }

    }
    public class TreeItem
    {
        public TreeItem()
        {

        }
        public TreeItem(int _id, string _Name)// int _Lavel)
        {
            this.id = _id;
            this.Name = _Name;
            //this.Level = _Lavel;
        }
        public int id { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        public int OrderID { get; set; }
        /// <summary>
        /// ��ID
        /// </summary>
        public int HeadID { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public int Level { get; set; }
    }

    public class SystemEnum
    {
        /// <summary>
        /// 
        /// </summary>
        public enum AskState
        {
            /// <summary>
            /// δ���
            /// </summary>
            NoSolve = 1,
            /// <summary>
            /// �ѽ��
            /// </summary>
            YesSolve = 2,
            /// <summary>
            /// �ѹر�
            /// </summary>
            Close = 3


        }

    }

    public class ThankModel
    {
        private bool _key;
        private string _thinfo;
        public bool Key
        {
            get { return _key; }
            set { _key = value; }
        }
        public string ThInfo
        {
            get { return _thinfo; }
            set { _thinfo = value; }
        }
    }

    public class UpScoreModel1
    {
        private int _days;
        public int Days
        {
            get { return _days; }
            set { _days = value; }
        }

        private int _score;
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        private int _nimingscore;
        public int NiMingScore
        {
            get { return _nimingscore; }
            set { _nimingscore = value; }
        }

        private bool _ifniminganswer;
        /// <summary>
        /// �Ƿ������ش�����
        /// </summary>
        public bool NiMingAnswer
        {
            get { return _ifniminganswer; }
            set { _ifniminganswer = value; }
        }
    }

}
