using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.BLL.User;
using EbSite.Modules.BmAsk.Ajaxget;
using EbSite.Modules.BmAsk.ModuleCore;
using EbSite.Modules.BmAsk.ModuleCore.BLL;
using expandanswers = EbSite.Modules.BmAsk.ModuleCore.Entity.expandanswers;

namespace EbSite.Modules.BmAsk.Widgets.GetAnswerList
{
    public partial class widget : WidgetBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override bool IsEditable
        {
            get
            {
                return true;
            }
        }

        public override string Name
        {
            get
            {
                return "GetAnswerList";
            }
        }
        public override void LoadData()
        {
            if (!IsPostBack)
            {
                DataBing();
            }
        }
        public int QID
        {
            get
            {
                string id = Request.QueryString["id"];
                return Core.Utils.StrToInt(id, 0);
            }
        }
        protected int count;
        private void DataBing()
        {

            int key = 0;
            string sqlStr = "";
            StringDictionary settings = base.GetSettings();
            if (settings.ContainsKey("txtKey"))
            {
                key = int.Parse(settings["txtKey"]);
            }
            // string AskID = Request.QueryString["id"];
            OutTimeManage(QID);
            if (key == 0)
            {
                sqlStr += " IsDel={0} AND QID={1} ";
                sqlStr = string.Format(sqlStr, 0, QID);
            }
            if (key == 1)
            {
                sqlStr += " IsDel={0} AND QID={1} and IsAdoption={2} ";
                sqlStr = string.Format(sqlStr, 0, QID, 0);
            }
            if (key == 2)
            {
                sqlStr += " IsDel={0} AND QID={1} and IsAdoption={2} ";
                sqlStr = string.Format(sqlStr, 0, QID, 0);
            }

            this.AnswerList.DataSource = ModuleCore.BLL.Answers.Instance.GetListArray(0, sqlStr, "AnswerUpdateTime asc");
            this.AnswerList.DataBind();
            count = this.AnswerList.Items.Count;

        }
        #region  时间到期 系统自动关闭当前的问题 同时扣除 相应的分数
        /// <summary>
        /// 时间到期 系统自动关闭当前的问题 同时扣除 相应的分数
        /// </summary>
        public void OutTimeManage(int cid)
        {
            EbSite.Entity.NewsContent md = EbSite.BLL.NewsContent.GetModel(cid);
            if (md.Annex4 == Convert.ToInt32(SystemEnum.AskState.NoSolve).ToString())
            {
                long i = Core.Strings.cConvert.DateDiff("h", DateTime.Now, Convert.ToDateTime(md.Annex9.ToString()));
                if (i <= 0)
                {
                    //过期了
                    md.Annex4 = Convert.ToInt32(SystemEnum.AskState.Close).ToString();
                    md.ID = cid;
                    EbSite.BLL.NewsContent.Update(md);
                    //扣分

                    if (ConfigControl.Instance.OutTimeScore > 0)
                    {
                        EbSite.Base.Host.Instance.MinusUserCreditsByID(md.UserID, ConfigControl.Instance.OutTimeScore);
                    }
                }
            }
        }


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
            int key = 0;
            if (isapproved == 1) //通过审核  才出现 设为最佳答案 和 追问
            {
                StringDictionary settings = base.GetSettings();
                if (settings.ContainsKey("txtKey"))
                {
                    key = int.Parse(settings["txtKey"]);
                }

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
                if (key == 0)
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
                        str = string.Format(str, AnswerUserID, aid, UsNiName);
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
                    string isSol = "";
                    var model = EbSite.BLL.NewsContent.GetModel(askquestionID);
                    if (null != model)
                        isSol = model.Annex4;
                    if (answerUid == currentUid && isSol == "1")
                    {
                        //str = "<div class='ans_wrapper'>" +
                        //     "<div style='float:right; margin-right:0px;'><a href='#'  onclick='UpdateAnswer({0},{1})'>修改回答</a></div>" +
                        //     "</div>";
                        str = string.Format(tempstr, askquestionID, answerUid,askct);
                    }
                }
            }
            else
            {
                int currentUid = EbSite.Base.Host.Instance.UserID;
                string isSol = "";
                var model = EbSite.BLL.NewsContent.GetModel(askquestionID);
                if (null != model)
                    isSol = model.Annex4;
                if (answerUid == currentUid && isSol == "1")
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
        protected string UserInfo(bool IsAnonymity, string AnswerUserID)
        {
            string str = "<a href='{1}' target=\"_blank\"><img src='{0}' width=\"63\" /> </a>";

            ;
            if (IsAnonymity)
            {
                str = string.Format(str, "/themes/asktheme/css/images/nopic.gif", "", "热心网友");
            }
            else
            {
               
                string url = EbSite.Base.Host.Instance.AvatarBig(int.Parse(AnswerUserID));//MembershipUserEb.Instance.GetEntity(int.Parse(AnswerUserID)).AvatarBig;
                string spaceurl = String.Format("/jieda-1-{0}-1.ashx", AnswerUserID);//EbSite.Base.Host.Instance.GetUserSiteUrl(int.Parse(AnswerUserID));
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
        public string GetZhiWenAnswer(int id, int pid)
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
                foreach (expandanswers i in ls)
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

        public string UsNiName
        {
            get
            {
                EbSite.Entity.NewsContent md = EbSite.BLL.NewsContent.GetModel(QID);
                return md.UserNiName;
            }
        }
        public void AnswerList_ItemBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ModuleCore.Entity.Answers drData = (ModuleCore.Entity.Answers)e.Item.DataItem;
                if (!Equals(drData, null))
                {
                    int strClassID = drData.id;
                    Repeater llClassList = (Repeater)e.Item.Controls[0].FindControl("rpSubList");
                    string sqlWhere = "typeid=0 and AnswerId =" + strClassID;
                    List<ModuleCore.Entity.expandanswers> ls = ModuleCore.BLL.expandanswers.Instance.GetListArray(0, sqlWhere, "");
                    llClassList.DataSource = ls;
                    llClassList.DataBind();

                }
            }
        }
    }
}