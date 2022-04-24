using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.BLL.User;
using EbSite.Modules.BmAsk.Ajaxget;
using EbSite.Modules.BmAsk.ModuleCore;
using EbSite.Modules.BmAsk.ModuleCore.BLL;

namespace EbSite.Modules.BmAsk.Widgets.GetBestAnswer
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
        public int AskID
        {
            get
            {
                return EbSite.Core.Utils.StrToInt(Request.QueryString["id"], 0);
            }
        }
        public override string Name
        {
            get
            {
                return "GetBestAnswer";
            }
        }
        public override void LoadData()
        {
            if (!IsPostBack)
            {
                DataBing();
            }
        }
        public AnswerInfo info = new AnswerInfo();
        private void DataBing()
        {
           // string AskID = Request.QueryString["id"];
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
               // Base.EntityAPI.MembershipUserEb _UserInfos = MembershipUserEb.Instance.GetEntity(list[0].AnswerUserID);
                info.AvatarBig = EbSite.Base.Host.Instance.AvatarBig(list[0].AnswerUserID);//_UserInfos.AvatarBig;
                info.AnswerDT = Convert.ToDateTime(list[0].AnswerTime);
                info.ThankInfo = list[0].ThanksInfo;
                string usserspace = EbSite.Base.Host.Instance.GetUserSiteUrl(list[0].QUserID);
                string asname = AskCommon.GetUserName(list[0].QUserID.ToString());
                info.AskUserInfo = "<a href=" + usserspace + " target=\"_blank\"><span style='color:red;'>" + asname + "</span></a>";
                string spaceurl = String.Format("/jieda-1-{0}-1.ashx",aid);//EbSite.Base.Host.Instance.GetUserSiteUrl(int.Parse(aid));
                info.SpacePath = spaceurl;


                info.IsAnonymity = list[0].IsAnonymity;
                RepSubBind(list[0].id);
            }
        }
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
        protected string UserInfo(bool IsAnonymity, string AvatarBig, string AName)
        {
            string str = " <div style=\"text-align: center\">" +
                         " <img id=\"AvatarBig1\"src='{0}'; width=\"80\" />  </div>" +
                         "<div style=\"text-align: center;\">" +
                         "<a href='{1}' target=\"_blank\">{2}</a> </div> ";
            if (IsAnonymity)
            {
                str = string.Format(str, "/themes/asktheme/css/images/nopic.gif", "", "热心网友");
            }
            else
            {
                string spaceurl = EbSite.Base.Host.Instance.GetUserSiteUrl(AName);
                str = string.Format(str, AvatarBig, spaceurl, AName);
            }
            return str;
        }
        //public int QID
        //{
        //    get
        //    {
        //        string id = Request.QueryString["id"];
        //        return Core.Utils.StrToInt(id, 0);
        //    }
        //}
        public string UsNiName
        {
            get
            {
                EbSite.Entity.NewsContent md = EbSite.BLL.NewsContent.GetModel(AskID);
                return md.UserNiName;
            }
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
    }
}


