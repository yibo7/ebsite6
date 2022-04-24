using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Base.Modules;
using EbSite.Base.Page;
using EbSite.BLL.User;
using EbSite.Entity;


namespace EbSite.Widgets.EvaluatePg
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {

            }
        }


        public override string Name
        {
            get { return "EvaluatePg"; }
        }

        /// <summary>
        /// 评论留言的类别，如内容，用户或是网站，能过这个id来区分，可的后台添加
        /// </summary>
        public int cid
        {
            get
            {
                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("txtCid"))
                {
                    return int.Parse(settings["txtCid"]);
                }
                return 0;
            }
        }

        public string SiteName
        {
            get
            {
                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("txtSiteName"))
                {
                    return settings["txtSiteName"];
                }
                return "ebsite";
            }
        }
        
        private string TypeState
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["t"]))
                {
                    string k = Request["t"];
                    if (k == "1")
                    {
                        return "(EvaluationScore='4'or EvaluationScore='5') ";
                    }
                    if (k == "2")
                    {
                        return "(EvaluationScore='2'or EvaluationScore='3') ";
                    }
                    if (k == "3")
                    {
                        return "EvaluationScore='1'";
                    }
                }
                return "";
            }
        }

        protected EbSite.Base.EntityAPI.MembershipUserEb UserInfos(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                Base.EntityAPI.MembershipUserEb _UserInfos = MembershipUserEb.Instance.GetEntity(username);
                if (_UserInfos != null)
                    return _UserInfos;
                else
                {
                    return new Base.EntityAPI.MembershipUserEb();

                }
            }
            else
            {
                return new Base.EntityAPI.MembershipUserEb();

            }
        }
        /// <summary>
        /// 引用评论
        /// </summary>
        private string QuoteContent
        {
            get
            {
                return Request.Form["quote"];
            }
        }

        protected int iSearchCount = 0;
        private int PageIndex
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["p"]))
                    return Convert.ToInt32(Request.QueryString["p"]);
                else
                    return 1;
            }
        }
        private int iPageSize
        {
            get
            {
                return 5;
            }

        }
        protected int ClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["classid"]))
                {
                    return int.Parse(Request["classid"]);
                }
                else
                {
                    return 0;
                }
            }
        }

        protected int ContentID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["contentid"]))
                {
                    return int.Parse(Request["contentid"]);
                }
                else
                {
                    return 0;
                }
            }
        }

        public int AllPJ = 0;
        public int GooDPJ = 0;
        public int MidPJ = 0;
        public int BadPJ = 0;

        protected int CountScore = 0;
        private void BindData()
        {
            this.iSearchCount = EbSite.BLL.Remark.GetCount(this.cid, true, out CountScore, ClassID, ContentID, TypeState);
           

            List<Entity.Remark> ls = EbSite.BLL.Remark.GetModelList(string.Format(" RemarkClassID={0} and ClassID={1} and ContentID={2}", cid, ClassID, ContentID), true, this.PageIndex, this.iPageSize);
            if (!string.IsNullOrEmpty(TypeState))
            {
                List<Entity.Remark> lsx = EbSite.BLL.Remark.GetModelList(string.Format(" RemarkClassID={0} and ClassID={1} and ContentID={2} and {3}", cid, ClassID, ContentID, TypeState), true, this.PageIndex, this.iPageSize);

                this.rpComment.DataSource = lsx;
                this.rpComment.DataBind();
            }
            else
            {
                this.rpComment.DataSource = ls;
                this.rpComment.DataBind();
            }

            AllPJ = iSearchCount;
            GooDPJ = EbSite.BLL.Remark.GetCount(this.cid, ClassID, ContentID, true, "(EvaluationScore=4 or EvaluationScore=5) ");
            MidPJ = EbSite.BLL.Remark.GetCount(this.cid, ClassID, ContentID, true, "(EvaluationScore=2 or EvaluationScore=3)");
            BadPJ = EbSite.BLL.Remark.GetCount(this.cid, ClassID, ContentID, true, "(EvaluationScore=1)");
            
          
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.BindData();
                //EbSite.Base.Page.BasePage father = new BasePage();
                //father.AddStylesheetInclude(father.CurrentSite.ThemesPath("pj/css.css"));
                //father.AddJavaScriptInclude(father.CurrentSite.ThemesPath("pj/js.js"));

            }
        }

        public string GetScoreStyle(string iscore)
        {
            string str = "<span class=\"star sa{0}\"></span>";
            str = string.Format(str, iscore);
            return str;
        }
      
        /// <summary>
        /// 得到子项的数据ReplySublist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetChindRep(int id)
        {
            string strinfo = "";
            string str = " <div class=\"item-reply\">" +
                         "<strong>{0}</strong>" +
                         " <dl>" +
                         "<dt><span class=\"u-name\"><a href=\"\" target=\"_blank\">{1}</a>回复说：</span> <span class=\"date-comment\">{2}</span>" +
                         " </dt> <dd>" +
                         "{3}</dd></dl>  </div>";

            //string end = " <div class=\"ac\">" +
            //             "<a href=\"#{0}\" target=\"_blank\">查看全部{1}条回复&gt;&gt;</a></div>";

            int icount = BLL.RemarkSublist.GetCount("parentid=" + id);
            List<Entity.RemarkSublist> ls = BLL.RemarkSublist.GetModelList("parentid=" + id, true, 1, 20);
            if (ls.Count > 0)
            {
                for (int i = 0; i < ls.Count; i++)
                {
                    strinfo += string.Format(str, icount - i, ls[i].UserName, ls[i].DateAndTime, ls[i].Body);
                }
                // strinfo += string.Format(end, "", icount);
            }

            return strinfo;
        }

        public string GetSocre()
        {
            string str = " <div class=\"rate\"> <strong>{0}<span>%</span></strong><br /><span>好评度</span> </div>" +
                             "<div class=\"percent\">" +
                             "<dl> <dt>好评<span>({0}%)</span></dt><dd><div style=\"width: {0}px\"> </div> </dd></dl>" +
                             " <dl><dt>中评<span>({1}%)</span></dt>  <dd class=\"d1\"><div style=\"width: {1}%\"> </div></dd></dl>" +
                             " <dl><dt>差评<span>({2}%)</span></dt><dd class=\"d1\"> <div style=\"width: {2}%\"> </div> </dd> </dl>" +
                             " </div>";
            if (AllPJ > 0)
            {
                int gooDPj_P = (GooDPJ * 100 / AllPJ);
                int midPJ_P = (MidPJ * 100 / AllPJ);
                int badPJ_P = (BadPJ * 100 / AllPJ);
                str = string.Format(str, gooDPj_P, midPJ_P, badPJ_P);
            }
            else
            {
                str = string.Format(str, 0, 0, 0);
            }
            return str;


        }
        public override bool IsEditable
        {
            get { return true; }
        }

    }

}