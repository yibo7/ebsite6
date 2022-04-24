using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.BLL.User;
using EbSite.Modules.Wenda.Ajaxget;
using EbSite.Modules.Wenda.ModuleCore.BLL;

namespace EbSite.Modules.Wenda.ModuleCore.Pages
{
    public class mcontent : EbSite.Base.Page.CustomPage
    {
        #region 控件注册

        protected System.Web.UI.WebControls.Repeater rpSubList;

        protected System.Web.UI.WebControls.Repeater AnswerList;

        protected System.Web.UI.WebControls.Repeater rpRelateContent;


        protected System.Web.UI.WebControls.Repeater RepWaiting;

        #endregion

        protected EbSite.Entity.NewsContent Model = new EbSite.Entity.NewsContent();
        /// <summary>
        /// 问题ID
        /// </summary>
        private int iRequestID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return int.Parse(Request["id"]);
                }
                else
                {

                    return -1;
                }
            }
        }
        /// <summary>
        /// 分类ID 可以知道用的哪个分表
        /// </summary>
        private int iCID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    return int.Parse(Request["cid"]);
                }
                else
                {

                    return -1;
                }
            }
        }
        protected EbSite.Base.EntityAPI.MembershipUserEb UserInfos
        {
            get
            {
                Base.EntityAPI.MembershipUserEb _UserInfos = MembershipUserEb.Instance.GetEntity(Model.UserID);
                if (_UserInfos != null)
                    return _UserInfos;
                else
                {
                    return new Base.EntityAPI.MembershipUserEb();
                }
            }
        }
        protected string GetNav(string Nav)
        {
            return GetNav(Nav, false, 0);
        }
        protected string GetNav(string Nav, bool IsAddIndex)
        {
            return EbSite.BLL.NewsClass.GetNav(Nav, Model.ClassID, IsAddIndex, GetSiteID, 0);
        }
        protected string GetNav(string Nav, bool IsAddIndex, int FilterClassID)
        {
            return EbSite.BLL.NewsClass.GetNav(Nav, Model.ClassID, IsAddIndex, GetSiteID, FilterClassID);
        }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (iCID > 0)
            {
                EbSite.BLL.NewsContentSplitTable NewsContentBll = EbSite.Base.AppStartInit.GetNewsContentInst(iCID);
                Model = NewsContentBll.GetModelDefaultFiled(iRequestID);
            }
            else
            {
                Model = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(iRequestID);
            }

            // OutTimeManage(iRequestID);
            DataSet ds = ModuleCore.BLL.Answers.Instance.GetDataArticle(iRequestID, Model.Annex21);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dtModel = ds.Tables[0];

                #region   //补充内容
                string str = "";
                string tempOne = "<div class=\"jgquesinfo\"><li>{0}</li> </div>";

                string tempTwo = "<div class=\"jgbcwt\"> <li style=\"color: #A0A19D; line-height: 25px;\"><span>补充问题</span>：{0}</li><li style=\"margin-left: 20px;\">{1}</li></div>";


                //int AskID = int.Parse(Request.QueryString["id"]);
                //EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModel(AskID);
                if (ConfigControl.Instance.IsUbb) //显示UBB
                {
                    str = string.Format(tempOne, EbSite.Core.UBB.Ubb2Html(Model.ContentInfo));
                }
                else
                {
                    str = string.Format(tempOne, Model.ContentInfo);
                }
                // List<ModuleCore.Entity.ExpandContent> ls = ModuleCore.BLL.ExpandContent.Instance.GetListArray(0, "cid=" + iRequestID, "id asc");
                DataTable dtAddCt = ds.Tables[1];
                if (dtAddCt.Rows.Count > 0)
                {
                    for (int i = 0; i < dtAddCt.Rows.Count; i++)
                    {
                        if (ConfigControl.Instance.IsUbb) //显示UBB
                        {
                            str += string.Format(tempTwo, dtAddCt.Rows[i]["TDate"], EbSite.Core.UBB.Ubb2Html(dtAddCt.Rows[i]["Ctent"].ToString()));
                        }
                        else
                        {
                            str += string.Format(tempTwo, dtAddCt.Rows[i]["TDate"], dtAddCt.Rows[i]["Ctent"]);
                        }
                    }

                    //foreach (ModuleCore.Entity.ExpandContent i in ls)
                    //{
                    //    if (ConfigControl.Instance.IsUbb) //显示UBB
                    //    {
                    //        str += string.Format(tempTwo, i.TDate, EbSite.Core.UBB.Ubb2Html(i.Ctent));
                    //    }
                    //    else
                    //    {
                    //        str += string.Format(tempTwo, i.TDate, i.Ctent);
                    //    }
                    //}
                }
                sInfo = str;

                #endregion

                #region 最佳答案

                // string AskID = Request.QueryString["id"];
                //string sqlStr = " IsAdoption={0} AND QID={1} ";
                //sqlStr = string.Format(sqlStr, 1, iRequestID);
                // var list = ModuleCore.BLL.Answers.Instance.GetListArray(sqlStr);
                DataTable dtBest = ds.Tables[2];
                if (dtBest.Rows.Count > 0)
                {
                    string aid = dtBest.Rows[0]["AnswerUserID"].ToString();
                    string acontent = dtBest.Rows[0]["AnswerContent"].ToString();
                    string aname = AskCommon.GetUserName(aid);
                    info.AContent = acontent;
                    info.AName = aname;
                    info.AnswerID = int.Parse(dtBest.Rows[0]["id"].ToString());
                    info.GoodSum = int.Parse(dtBest.Rows[0]["GoodAsk"].ToString());
                    // Base.EntityAPI.MembershipUserEb _UserInfos = MembershipUserEb.Instance.GetEntity(list[0].AnswerUserID);
                    info.AvatarBig = EbSite.Base.Host.Instance.AvatarBig(int.Parse(dtBest.Rows[0]["AnswerUserID"].ToString()));//_UserInfos.AvatarBig;
                    info.AnswerDT = Convert.ToDateTime(dtBest.Rows[0]["AnswerTime"]);
                    info.ThankInfo = dtBest.Rows[0]["ThanksInfo"].ToString();
                    // string usserspace = EbSite.Base.Host.Instance.GetUserSiteUrl(dtBest.Rows[0]["QUserID"].ToString());
                    string asname = AskCommon.GetUserName(dtBest.Rows[0]["QUserID"].ToString());
                    info.AskUserInfo = "<span style='color:red;'>" + asname + "</span>";
                    string spaceurl = String.Format("/jieda-{1}-{0}-1.ashx", aid, SettingInfo.Instance.GetSiteID);//EbSite.Base.Host.Instance.GetUserSiteUrl(int.Parse(aid));
                    info.SpacePath = spaceurl;

                    if (dtBest.Rows[0]["IsAnonymity"].ToString() == "0")
                    {
                        info.IsAnonymity = false;
                    }
                    if (dtBest.Rows[0]["IsAnonymity"].ToString() == "1")
                    {
                        info.IsAnonymity = true;
                    }
                    //info.IsAnonymity =Convert.ToBoolean(dtBest.Rows[0]["IsAnonymity"].ToString());
                    RepSubBind(int.Parse(dtBest.Rows[0]["id"].ToString()));
                }

                #endregion

                #region 回答列表

                this.AnswerList.DataSource = ds.Tables[3];// ModuleCore.BLL.Answers.Instance.GetListArray(0, sqlStr, "AnswerUpdateTime asc");
                this.AnswerList.DataBind();
                count = this.AnswerList.Items.Count;

                #endregion

                if (dtBest.Rows.Count > 0)
                {
                    allcount = count + 1;
                }
                else
                {
                    allcount = count;
                }
                //#region 相关问题

                //rpRelateContent.DataSource = ModuleCore.BLL.class_article.Instance.GetListArray(10, "classid="+Model.ClassID,"RAND()");
                //rpRelateContent.DataBind();
                //#endregion

                WaitingDataBind();//等待你来回答
            }


            inithead();
        }
        private void inithead()
        {
            string seoClassTitle = SeoSite.SeoContentTitle;//Base.Configs.ContentSet.ConfigsControl.Instance.SeoContentTitle;
            string seoKeyWord = SeoSite.SeoContentKeyWord;// Base.Configs.ContentSet.ConfigsControl.Instance.SeoContentKeyWord;
            string seoDes = SeoSite.SeoContentDes;//Base.Configs.ContentSet.ConfigsControl.Instance.SeoContentDes;
            GetSeoWord(ref seoClassTitle, ref seoKeyWord, ref seoDes, Model.NewsTitle, Model.ClassName, Model.ClassID, Model.TagIDs, Model.ContentInfo);
            base.SeoTitle = seoClassTitle;
            base.SeoKeyWord = seoKeyWord;
            base.SeoDes = seoDes;

        }
        override protected string KeepUserState()
        {
            return base.KeepUserState(string.Format("id={0}", iRequestID));
        }
        //获得问题内容和补充
        protected string sInfo = "";
        #region 内容和补充

        #endregion

        #region 最佳答案
        public AnswerInfo info = new AnswerInfo();

        private void RepSubBind(int strClassID)
        {
            string sqlWhere = "typeid=0 and AnswerId =" + strClassID;
            List<ModuleCore.Entity.expandanswers> ls = ModuleCore.BLL.expandanswers.Instance.GetListArray(0, sqlWhere, "");
            rpSubList.DataSource = ls;
            rpSubList.DataBind();
        }

        /// <summary>
        /// 匿名 用户信息
        /// </summary>
        /// <param name="IsAnonymity"></param>
        /// <returns></returns>
        protected string UserInfo(string IsAnonymity, string AvatarBig, string AName)
        {
            string str = " <div style=\"text-align: center\">" +
                         " <img id=\"AvatarBig1\"src='{0}'; width=\"80\" />  </div>" +
                         "<div style=\"text-align: center;\">" +
                         "<a href='{1}' target=\"_blank\">{2}</a> </div> ";


            if (IsAnonymity == "1")
            {
                str = string.Format(str, "/themes/wenda/css/images/nopic.gif", "", "热心网友");
            }
            else
            {
                string spaceurl = EbSite.Base.Host.Instance.GetUserSiteUrl(AName);
                str = string.Format(str, AvatarBig, spaceurl, AName);
            }
            return str;
        }


        public string GetZhiWenAnswer(int id, int pid)
        {
            string s = "";
            string sf = "  <div class=\"clear\">" +
                        "</div>" +
                        " <div class=\"normal\" style=\"width: 620px; margin-left: 0px;\">" +
                        " <div class=\"normalarrow\">" +
                        " </div>" +
                        " 回答：{0}" +
                        "</div>";


            List<ModuleCore.Entity.expandanswers> ls = ModuleCore.BLL.expandanswers.Instance.GetListArray(0,
                                                                                                          "eid=" +
                                                                                                          id +
                                                                                                          " and typeid=1 and answerid=" +
                                                                                                          pid,
                                                                                                          "id asc");
            if (ls.Count == 1)
            {
                s = string.Format(sf, ls[0].Ctent);
            }
            return s;
        }
        #endregion


        #region 未解决 已解决 已关闭
        protected int allcount;
        protected int count;

        #region  时间到期 系统自动关闭当前的问题 同时扣除 相应的分数
        /// <summary>
        /// 2014-3-26 写成插件了 时间到期 系统自动关闭当前的问题 同时扣除 相应的分数
        /// </summary>
        //public void OutTimeManage(int cid)
        //{
        //    // EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModel(cid);
        //    if (Model.Annex21 == Convert.ToInt32(SystemEnum.AskState.NoSolve))
        //    {
        //        long i = Core.Strings.cConvert.DateDiff("h", DateTime.Now, Convert.ToDateTime(Model.Annex9.ToString()));
        //        if (i <= 0)
        //        {
        //            //过期了
        //            Model.Annex21 = Convert.ToInt32(SystemEnum.AskState.Close);
        //            Model.ID = cid;
        //            Model.Annex10 = DateTime.Now.ToString();
        //            Base.AppStartInit.NewsContentInstDefault.Update(Model);
        //            //扣分

        //            if (ConfigControl.Instance.OutTimeScore > 0)
        //            {
        //                EbSite.Base.Host.Instance.MinusUserCreditsByID(Model.UserID, ConfigControl.Instance.OutTimeScore);
        //            }
        //        }
        //    }
        //}


        #endregion

        /// <summary>
        /// 设为最佳答案
        /// </summary>
        /// <param name="askUid">提问者ID</param>
        /// <param name="AnswerUserID">回答者ID</param>
        /// <param name="aid">回答表 id</param>
        /// <param name="isapproved">是否通过审核</param>
        /// <returns></returns>
        protected string SetBestAnswer(int askUid, string AnswerUserID, int aid, int isapproved)
        {
            string str = "";
            string sAnswer = "";
            string sZhuiWen = "";
            long key = Model.Annex21;
            if (isapproved == 1) //通过审核  才出现 设为最佳答案 和 追问
            {

                #region

                //<div class="tab2_ques" style="margin-left: 85px;">
                //       <div class="okquebtn jgall">采纳为答案
                //       </div>
                //       <div class="goonque jgall">追问
                //       </div>
                //       <div class="clear">
                //       </div>
                //        <div class="jgjxw">
                //           <div class="jgjxwlarrow9">
                //           </div>
                //           <div class="wth6">
                //               <textarea class="wdinput2 areabornone" rows="4" cols="72" style="margin-top: 5px;
                //                   margin-left: 3px;">谢谢您的回答！</textarea></div>
                //       </div>
                //       <div class="jgjxw">
                //           <div class="jgjxwlarrow">
                //           </div>
                //           <div class="wth6">
                //               <textarea class="wdinput2 areabornone" rows="4" cols="72" style="margin-top: 5px;
                //                   margin-left: 3px;">输入问题内容</textarea></div>
                //       </div>
                //        </div>

                #endregion

                string tpTop = "<div class=\"tab2_ques\" style=\"margin-left: 85px;\">";
                string tpAnswer =
                    "<a href='javascript:void(0)' onclick='SetBestAnswer({0})' ><div class=\"okquebtn jgall\"> </div></a>";
                string tpZhuiWen =
                    "<a href='javascript:void(0)' onclick='SetAddAsk({0},{1})'> <div id='bxZw{0}' class=\"goonque jgall\"> </div></a>";

                string tpMid = "<div class=\"clear\"></div>";
                string ctAnswer = "<div id=\"best{0}\" style='display:none;' class=\"jgjxw\">" +
                                  "<div class=\"jgjxwlarrow9\">" +
                                  "</div>" +
                                  "<div class=\"wth6\">" +
                                  "<textarea id='mc{0}' class=\"wdinput2 areabornone\" rows=\"4\" cols=\"82\" style=\"margin-top: 5px;  margin-left: 3px;\">谢谢您的回答！</textarea></div>" +
                                  "<a href='javascript:void(0)' onclick='toSetBestAnswer({0})'><div style='float:right; margin-top:3px;' class=\"tab2save jgall\"></div></a></div>";

                string ctZhuiWen = "<div id=\"zw{0}\" style='display:none;' class=\"jgjxw\">" +
                                   "<div class=\"jgjxwlarrow\">" +
                                   "</div>" +
                                   "<div class=\"wth6\" >" +
                                   "<textarea id=adaskct{0} class=\"wdinput2 areabornone\" rows=\"4\" cols=\"82\" style=\"margin-top: 5px;  margin-left: 3px;\"></textarea></div>" +
                                   "<a href='javascript:void(0)' onclick='toAddAsk({0},{1})'><div style='float:left; margin-top:3px;' class=\"tab2save jgall\"></div></a></div>";

                string tpend = "</div>";

                str = tpTop;
                List<ModuleCore.Entity.expandanswers> ls = ModuleCore.BLL.expandanswers.Instance.GetListArray(0,
                                                                                                              "answerid=" +
                                                                                                              aid,
                                                                                                              "id asc");
                if (key == 1)
                {
                    int currentUid = EbSite.Base.Host.Instance.UserID;
                    if (currentUid == askUid)
                    {
                        //str = "<div style='float: left; margin-top:5px; margin-left:15px;'>" +
                        //      "<input style=' cursor:pointer;' type='button' value='采纳为答案'  onclick='SetBestAnswer({0})' /></div>";
                        str += tpAnswer;

                        if (ls.Count > 0)
                        {
                            if (ls[ls.Count - 1].TypeId == 1) // 已经发起追问 等待回答 
                            {
                                //   str +=
                                //"<div style='float: left; margin-top:5px; margin-left:5px; '><input style=' cursor:pointer;' type='button' value='继续追问'  onclick='SetAddAsk({1})' /> " +
                                //"</div>";
                                str += tpZhuiWen;

                                sZhuiWen = ctZhuiWen;
                            }
                        }
                        else
                        {
                            //str +=
                            //    "<div style='float: left; margin-top:5px; margin-left:5px; '><input style=' cursor:pointer;' type='button' value='继续追问'  onclick='SetAddAsk({1})' /> " +
                            //    "</div>";
                            str += tpZhuiWen;
                            sZhuiWen = ctZhuiWen;
                        }
                        str += tpMid + ctAnswer + sZhuiWen;
                        str = string.Format(str, AnswerUserID, aid, Model.UserNiName);
                    }
                    //if (currentUid.ToString() == AnswerUserID)
                    //{
                    //    if (ls.Count > 0)
                    //    {
                    //        if (ls[ls.Count - 1].TypeId == 0) // 已经发起追问 等待回答 
                    //        {
                    //            str = "<div style='float: left; margin-top:5px; margin-left:5px; '><input style=' cursor:pointer;' type='button' value='追问回答'  onclick='GoSetAddAsk({0})' /> " + "</div>";
                    //        }
                    //        str = string.Format(str, aid);
                    //    }
                    //}
                }
                str += tpend;
            }
            return str;
        }
        /// <summary>
        /// 修改问题
        /// </summary>
        /// <param name="askquestionID">问题的ID -QID</param>
        /// <param name="answerUid">回答者的  -AnswerUserID</param>
        /// <param name="tag">是否通过审核</param>
        /// <param name="askct">回答的内容</param>
        /// <returns></returns>
        protected string UpdateAnswer(int askquestionID, int answerUid, int tag, string askct)
        {
            string tempstr = "<a href='javascript:void(0)' onclick='editAnswer({0},{1})'><div id='bnedit' class=\"tab2edit jgall\"></div> </a>" +
                             " <a href='javascript:void(0)'  onclick='MdfAnswer({0},{1})'><div id='bnSubit' style='display:none;' class=\"tab2save jgall\"></div> </a> <div class=\"clear\"> </div>" +
                             " <div id=edit{1} class=\"jgjxw\" style=\"display:none;\">" +
                             " <div class=\"normalarrow\"> </div>" +
                             " <div class=\"wth6\"> <textarea id=editCt{1} class=\"wdinput2 areabornone\" rows=\"4\" cols=\"72\" style=\"margin-top: 5px;margin-left: 5px;\">{2}</textarea></div>" +
                             " </div>";
            string str = "";

            if (EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.AuditingContent)
            {
                if (tag == 1)
                {
                    int currentUid = EbSite.Base.Host.Instance.UserID;
                    long isSol = 0;
                    var model = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(askquestionID);
                    if (null != model)
                        isSol = model.Annex21;
                    if (answerUid == currentUid && isSol == 1)
                    {
                        //str = "<div class='ans_wrapper'>" +
                        //     "<div style='float:right; margin-right:0px;'><a href='#'  onclick='UpdateAnswer({0},{1})'>修改回答</a></div>" +
                        //     "</div>";
                        str = string.Format(tempstr, askquestionID, answerUid, askct);
                    }
                }
            }
            else
            {
                int currentUid = EbSite.Base.Host.Instance.UserID;
                long isSol = 0;
                var model = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(askquestionID);
                if (null != model)
                    isSol = model.Annex21;
                if (answerUid == currentUid && isSol == 1)
                {
                    //str = "<div >" +
                    //     "<div style='float:right; margin-top:30px;margin-right:0px; margin-left:4px;'><a href='#'  onclick='UpdateAnswer({0},{1})'>修改回答</a></div>" +
                    //     "</div>";
                    str = string.Format(tempstr, askquestionID, answerUid, askct);
                }
            }

            return str;

        }
        /// <summary>
        /// 是否开启审核 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        protected string SetContent(string content, int tag)
        {
            string str = "";
            if (EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.AuditingContent)
            {
                if (tag == 1) //通过
                {
                    str = EbSite.Core.UBB.Ubb2Html(content);
                }
                else
                {
                    str = "本回答正在审核中...";
                }
            }
            else
            {
                str = EbSite.Core.UBB.Ubb2Html(content);
            }
            return str;
        }

        /// <summary>
        /// 匿名 用户信息
        /// </summary>
        /// <param name="IsAnonymity"></param>
        /// <returns></returns>
        protected string UserInfo(string IsAnonymity, string AnswerUserID)
        {
            string str = "<a href='{1}' target=\"_blank\"><img src='{0}' width=\"63\" /> </a>";

            ;
            if (IsAnonymity == "1")
            {
                str = string.Format(str, "/themes/wenda/css/images/nopic.gif", "", "热心网友");
            }
            else
            {

                string url = EbSite.Base.Host.Instance.AvatarBig(int.Parse(AnswerUserID));//MembershipUserEb.Instance.GetEntity(int.Parse(AnswerUserID)).AvatarBig;
                string spaceurl = String.Format("/jieda-{1}-{0}-1.ashx", AnswerUserID, SettingInfo.Instance.GetSiteID);//EbSite.Base.Host.Instance.GetUserSiteUrl(int.Parse(AnswerUserID));
                string username = AskCommon.GetUserName(AnswerUserID);
                str = string.Format(str, url, spaceurl, username);
            }
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pid">回答者用户ID</param>
        /// <returns></returns>
        public string SecoGetZhiWenAnswer(int id, int pid)
        {

            int currentUid = EbSite.Base.Host.Instance.UserID;

            var answerUid = ModuleCore.BLL.Answers.Instance.GetEntity(pid).AnswerUserID;
            string s = "";
            string fb =
                "<a href=\"javascript:void(0)\" onclick=\"GoSetAddAsk({0})\"> <div id='fs{0}' class=\"tab2answerbtn jgall\">" +
                " </div></a> <div class=\"clear\"> </div>" +
                "  <div id=\"ToHf{0}\" style=\"display:none;\" class=\"jgjxw\">" +
                " <div class=\"normalarrow\"> </div>   <div class=\"wth6\">" +

                " <textarea id=\"adawct{0}\"   class=\"wdinput2 areabornone\" rows=\"4\" cols=\"72\" style=\"margin-top: 5px;   margin-left: 5px;\" >请输入问题内容</textarea>" +
                " </div>  <a href='#' onclick='GoToAddAsk({0},{1})'><div style='float:left; margin-top:3px;' class=\"tab2save jgall\"></div></a></div>";


            string sf = "  <div class=\"clear\">" +
                        "</div>" +
                        " <div class=\"normal\" style=\"width: 620px; margin-left: 0px;\">" +
                        " <div class=\"normalarrow\">" +
                        " </div>" +
                        " 回答：{0}" +
                        "</div>";


            List<ModuleCore.Entity.expandanswers> ls = ModuleCore.BLL.expandanswers.Instance.GetListArray(0,
                                                                                                          "eid=" +
                                                                                                          id +
                                                                                                          " and typeid=1 and answerid=" +
                                                                                                          pid,
                                                                                                          "id asc");
            if (ls.Count == 1)
            {

                s = string.Format(sf, ls[0].Ctent);
            }
            else
            {
                if (answerUid == currentUid)
                {
                    s = string.Format(fb, id, pid);
                }
            }

            return s;
        }
        /// <summary>
        /// 取到 追加问题和答案
        /// </summary>
        /// <param name="answerid">回答的ID</param>
        /// <returns></returns>
        protected string GoToAsInfo(int answerid)
        {
            string s = "";
            string strTop = "<div style=\" margin-top:5px; margin-left:11px;\">";
            string strLine = " <div style='border-bottom: 1px dashed #ccc; height: 2px; margin-top: 5px; margin-bottom: 5px; '></div>";
            string strAsk = " <div style=\" line-height:22px;\"> <span style=\"color:#34A102;\">追问:</span> #askTem#</div>";
            string strAnswers = "<div style=\" line-height:22px;\"> <span style=\"color:#999999;\"> 回答:</span>#answerTem#</div>";
            string strBotton = "</div>";

            List<ModuleCore.Entity.expandanswers> ls = ModuleCore.BLL.expandanswers.Instance.GetListArray(0, "answerid=" + answerid, "id asc");
            if (ls.Count > 0)
            {
                s += strTop;
                foreach (ModuleCore.Entity.expandanswers i in ls)
                {
                    if (i.TypeId == 0)//追问
                    {
                        s += strAsk.Replace("#askTem#", i.Ctent);
                        s += strLine;
                    }
                    else
                    {
                        s += strAnswers.Replace("#answerTem#", i.Ctent);
                        s += strLine;
                    }
                }
                s += strBotton;
            }
            return s;
        }


        public void AnswerList_ItemBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //ModuleCore.Entity.Answers drData = (ModuleCore.Entity.Answers)e.Item.DataItem;

                //DataRow drData = (DataRow)e.Item.DataItem;
                DataRowView drData = (DataRowView)e.Item.DataItem;
                //DataRow drData = drDataSt.Table.Rows[0];
                if (!Equals(drData, null))
                {
                    int strClassID = int.Parse(drData["id"].ToString());//drData.id;
                    Repeater llClassList = (Repeater)e.Item.Controls[0].FindControl("rpSubList");
                    string sqlWhere = "typeid=0 and AnswerId =" + strClassID;
                    List<ModuleCore.Entity.expandanswers> ls = ModuleCore.BLL.expandanswers.Instance.GetListArray(0, sqlWhere, "");
                    llClassList.DataSource = ls;
                    llClassList.DataBind();

                }
            }
        }

        #endregion


        #region 等待你来回答
        protected void WaitingDataBind()
        {
            RepWaiting.DataSource = Base.AppStartInit.NewsContentInstDefault.GetListArray("id!=" + iRequestID + " and annex21=1  and classid=" + Model.ClassID, 10, "", "id,newstitle,Annex11",
                                                                        SettingInfo.Instance.GetSiteID);
            RepWaiting.DataBind();
        }
        #endregion

    }

    public class AnswerInfo
    {
        private string _AName;
        private string _AContent;
        private int _answerid;
        private int _goodsum;
        private string _avatarbig;
        private DateTime _answerdt;
        private string _thankinfo;
        private string _askuserinfo;

        private string _thankshowinfo;

        private string _spacePath;


        /// <summary>
        /// 人空间路径
        /// </summary>
        public string SpacePath
        {
            get { return _spacePath; }
            set { _spacePath = value; }
        }
        public string ThankShowInfo
        {
            get { return _thankshowinfo; }
            set { _thankshowinfo = value; }
        }

        private string _thankshowbtn;
        /// <summary>
        ///  感言按钮
        /// </summary>
        public string ThankShowBtn
        {
            get { return _thankshowbtn; }
            set { _thankshowbtn = value; }
        }
        /// <summary>
        /// 大头像路径
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
        /// <summary>
        /// 回答时间
        /// </summary>
        public DateTime AnswerDT
        {
            get { return _answerdt; }
            set { _answerdt = value; }
        }
        /// <summary>
        /// 感言
        /// </summary>
        public string ThankInfo
        {
            get { return _thankinfo; }
            set { _thankinfo = value; }
        }
        /// <summary>
        /// 提问者的信息
        /// </summary>
        public string AskUserInfo
        {
            get { return _askuserinfo; }
            set { _askuserinfo = value; }
        }

        private bool _isanonymity;
        public bool IsAnonymity
        {
            get { return _isanonymity; }
            set { _isanonymity = value; }
        }

    }
}