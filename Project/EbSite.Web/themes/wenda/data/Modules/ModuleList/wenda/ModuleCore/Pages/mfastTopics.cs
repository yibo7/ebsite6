using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using EbSite.Base.Page;
using EbSite.Modules.Wenda.Ajaxget;
using EbSite.Modules.Wenda.ModuleCore.BLL;
using Answers = EbSite.Modules.Wenda.ModuleCore.Entity.Answers;
using ExpandContent = EbSite.Modules.Wenda.ModuleCore.Entity.ExpandContent;
using UserHelp = EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp;

namespace EbSite.Modules.Wenda.ModuleCore.Pages
{


    public class mfastTopics : System.Web.UI.Page
    {


        #region 控件定义
        protected global::System.Web.UI.WebControls.TextBox txtTT;//标题
        protected global::System.Web.UI.WebControls.TextBox txtAddCT;//内容
        protected global::System.Web.UI.WebControls.TextBox txtHf1;//回复1
        protected global::System.Web.UI.WebControls.TextBox txtHf2;//回复2
        protected global::System.Web.UI.WebControls.TextBox txtHf3;//回复3
        protected global::System.Web.UI.WebControls.TextBox txtBcCT;//补充内容
        // protected global::EbSite.Control.TextBoxVl txtClassID;//分类ID

        protected global::System.Web.UI.WebControls.Button btnSave;

        protected global::System.Web.UI.WebControls.DropDownList DrpBigClass;

        protected global::System.Web.UI.WebControls.DropDownList DrpSamllClass;

        #endregion

        /// <summary>
        /// 导入数据 批量回复
        /// </summary>
        /// <param name="txtTitle">标题</param>
        /// <param name="classid">分类ID</param>
        /// <param name="txtContent">内容</param>
        /// <param name="arryHf">回复内容 数组  格式（ 回复内容|间隔时间）如：朝秦暮楚栽植大本营|5 </param>
        public void DataImportList(string txtTitle, int classid, string txtContent, string[] arryHf)
        {
            if (!string.IsNullOrEmpty(txtTitle))
            {
                int fauid = RandUserID(new int[0]);
                if (fauid > 0)
                {
                    EbSite.Entity.NewsContent newsContent = new EbSite.Entity.NewsContent();

                    newsContent.ClassID = classid;
                    newsContent.ContentInfo = txtContent;
                    newsContent.NewsTitle = txtTitle;

                    newsContent.Annex1 = "0"; //悬赏分
                    newsContent.Annex2 = ""; //扩展//扩展属性：用来标实来源
                    newsContent.Annex3 = "0";
                    newsContent.Annex5 = "0";
                    newsContent.AddTime = DateTime.Now.AddMinutes(-30);
                    newsContent.Annex21 = Convert.ToInt32(SystemEnum.AskState.NoSolve); //问题状态 1.未解决 2.已 3.无满意
                    newsContent.Annex6 = DateTime.Now.AddMinutes(-30).ToString(); //发表问题 时间 -10分钟
                    newsContent.Annex9 = DateTime.Now.AddDays(ConfigControl.Instance.AnswerDays).ToString(); //到期日期
                    newsContent.IsAuditing = true; // newsContent.Annex12 = 1; //审核 1：通过 0：不通过
                    newsContent.Annex14 = 0; //是否匿名 1：匿名 0：不匿名
                    newsContent.SiteID = SiteDI;
                    newsContent.TitleStyle = "";
                    newsContent.UserID = fauid; // 发表人ID 

                    newsContent.ContentHtmlNameRule = "content/{#TitleSpell#}{#KeyID#}";
                    newsContent.HtmlName = EbSite.BLL.HtmlReNameRule.GetName(newsContent.ContentHtmlNameRule,
                                                                             newsContent.NewsTitle,
                                                                             null);
                    //从当前规则转换文件名
                    newsContent.IsComment = true;
                    //newsContent.ContentTemID =EbSite.BLL.NewsClass.GetModel(classid).Configs.ContentTemID;


                    int tag = Base.AppStartInit.NewsContentInstDefault.Add(newsContent);
                    List<int> lis = new List<int>();
                    lis.Add(fauid);
                    for (int i = 0; i < arryHf.Length; i++)
                    {
                        int uid1 = 0;
                        string ips1 = "";
                        //回复 数组
                        if (!string.IsNullOrEmpty(arryHf[i]))
                        {
                            string[] arry = arryHf[i].Split('|');
                            uid1 = RandUserID(lis.ToArray());
                            ips1 = RandIp(new string[] { });
                            lis.Add(uid1);
                            AddHfAnwser(tag, fauid, uid1, arry[0], Convert.ToInt32(arry[1]), ips1);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="txtTitle">标题</param>
        /// <param name="classid">分类ID</param>
        /// <param name="txtContent">内容</param>
        /// <param name="txtHf">回复</param>
        public void DataImport(string txtTitle, int classid, string txtContent, string txtHf, string ip)
        {
            if (!string.IsNullOrEmpty(txtTitle))
            {
                int fauid = RandUserID(new int[0]);
                if (fauid > 0)
                {
                    EbSite.Entity.NewsContent newsContent = new EbSite.Entity.NewsContent();

                    newsContent.ClassID = classid;
                    newsContent.ContentInfo = txtContent;
                    newsContent.NewsTitle = txtTitle;

                    newsContent.Annex1 = "0"; //悬赏分
                    newsContent.Annex2 = ""; //扩展//扩展属性：用来标实来源
                    newsContent.Annex3 = "0";
                    newsContent.Annex5 = "0";
                    newsContent.AddTime = DateTime.Now.AddMinutes(-10);
                    newsContent.Annex21 = Convert.ToInt32(SystemEnum.AskState.NoSolve); //问题状态 1.未解决 2.已 3.无满意
                    newsContent.Annex6 = DateTime.Now.AddMinutes(-10).ToString(); //发表问题 时间 -10分钟
                    newsContent.Annex9 = DateTime.Now.AddDays(ConfigControl.Instance.AnswerDays).ToString(); //到期日期
                    newsContent.IsAuditing = true;// newsContent.Annex12 = 1; //审核 1：通过 0：不通过
                    newsContent.Annex14 = 0; //是否匿名 1：匿名 0：不匿名
                    newsContent.SiteID = SiteDI;
                    newsContent.TitleStyle = "";
                    newsContent.UserID = fauid; // 发表人ID 

                    newsContent.ContentHtmlNameRule = "content/{#TitleSpell#}{#KeyID#}";
                    newsContent.HtmlName = EbSite.BLL.HtmlReNameRule.GetName(newsContent.ContentHtmlNameRule,
                                                                             newsContent.NewsTitle,
                                                                            null);
                    //从当前规则转换文件名
                    newsContent.IsComment = true;
                    //newsContent.ContentTemID =EbSite.BLL.NewsClass.GetModel(classid).Configs.ContentTemID;


                    int tag = Base.AppStartInit.NewsContentInstDefault.Add(newsContent);

                    int uid1 = 0;
                    //  string ips1 = "";
                    //回复1
                    if (!string.IsNullOrEmpty(txtHf))
                    {
                        uid1 = RandUserID(new int[] { fauid });
                        // ips1 = //RandIp(new string[] { });
                        AddHfAnwser(tag, fauid, uid1, txtHf, 6, ip);
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.Title = "快速发帖";
            btnSave.Click += new EventHandler(btnSave_Click);
            DrpBigClass.SelectedIndexChanged += new EventHandler(DrpBigClass_SelectedIndexChanged);

            //绑定一级分类
            if (!IsPostBack)
            {
                DrpBigClass.DataSource = EbSite.BLL.NewsClass.GetListArr("annex10=1", SiteDI);
                DrpBigClass.DataTextField = "ClassName";
                DrpBigClass.DataValueField = "ID";
                DrpBigClass.DataBind();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            // Response.Write(RandUserID(new int[0]));
            //Response.Write(RandIp());
            //eb_content 发表提问表
            //eb_expandcontent  补充表
            //eb_answers  回答表

            if (!string.IsNullOrEmpty(txtTT.Text))
            {
                int fauid = RandUserID(new int[0]);
                if (fauid > 0)
                {
                    EbSite.Entity.NewsContent newsContent = new EbSite.Entity.NewsContent();

                    newsContent.ClassID = int.Parse(DrpSamllClass.SelectedValue);
                    newsContent.ContentInfo = txtAddCT.Text;
                    newsContent.NewsTitle = txtTT.Text;

                    newsContent.Annex1 = "0"; //悬赏分
                    newsContent.Annex2 = ""; //扩展//扩展属性：用来标实来源
                    newsContent.Annex3 = "0";
                    newsContent.Annex5 = "0";
                    newsContent.AddTime = DateTime.Now.AddMinutes(-10);
                    newsContent.Annex4 = Convert.ToInt32(SystemEnum.AskState.NoSolve).ToString(); //问题状态 1.未解决 2.已 3.无满意
                    newsContent.Annex6 = DateTime.Now.AddMinutes(-10).ToString(); //发表问题 时间 -10分钟
                    newsContent.Annex9 = DateTime.Now.AddDays(ConfigControl.Instance.AnswerDays).ToString(); //到期日期
                    newsContent.IsAuditing = true;// newsContent.Annex12 = 1; //审核 1：通过 0：不通过
                    newsContent.Annex14 = 0; //是否匿名 1：匿名 0：不匿名
                    newsContent.SiteID = SiteDI;
                    newsContent.TitleStyle = "";
                    newsContent.UserID = fauid; // 发表人ID 

                    newsContent.ContentHtmlNameRule = "content/{#TitleSpell#}{#KeyID#}";
                    newsContent.HtmlName = EbSite.BLL.HtmlReNameRule.GetName(newsContent.ContentHtmlNameRule,
                                                                             newsContent.NewsTitle,
                                                                             newsContent.ClassName);
                    //从当前规则转换文件名
                    newsContent.IsComment = true;
                    //newsContent.ContentTemID =EbSite.BLL.NewsClass.GetModel(int.Parse(DrpSamllClass.SelectedValue)).Configs.ContentTemID;
                    //new Guid("31999A34-5DFC-4E90-9CF1-DCB33ABCC786");


                    int tag = Base.AppStartInit.NewsContentInstDefault.Add(newsContent);

                    //补充内容
                    if (!string.IsNullOrEmpty(txtBcCT.Text))
                    {
                        ModuleCore.Entity.ExpandContent model = new ExpandContent();
                        model.Cid = tag;
                        model.Ctent = txtBcCT.Text;
                        model.TDate = DateTime.Now.AddMinutes(-8); //补充 -8分钟
                        ModuleCore.BLL.ExpandContent.Instance.Add(model);
                    }
                    int uid1 = 0;
                    string ips1 = "";
                    //回复1
                    if (!string.IsNullOrEmpty(txtHf1.Text))
                    {
                        uid1 = RandUserID(new int[] { fauid });
                        ips1 = RandIp(new string[] { });
                        AddHfAnwser(tag, fauid, uid1, txtHf1.Text, 6, ips1);
                    }
                    int uid2 = 0;
                    string ips2 = "";
                    //回复2
                    if (!string.IsNullOrEmpty(txtHf2.Text))
                    {
                        uid2 = RandUserID(new int[] { fauid, uid1 });
                        ips2 = RandIp(new string[] { ips1 });
                        AddHfAnwser(tag, fauid, uid2, txtHf2.Text, 4, ips2);
                    }
                    //回复3
                    int uid3 = 0;
                    string ips3 = "";
                    if (!string.IsNullOrEmpty(txtHf3.Text))
                    {
                        uid3 = RandUserID(new int[] { fauid, uid1, uid2 });
                        ips3 = RandIp(new string[] { ips1, ips2 });
                        AddHfAnwser(tag, fauid, uid3, txtHf3.Text, 1, ips3);
                    }

                    txtTT.Text = "";
                    txtAddCT.Text = ""; //内容
                    txtHf1.Text = ""; //回复1
                    txtHf2.Text = ""; //回复2
                    txtHf3.Text = ""; //回复3
                    txtBcCT.Text = ""; //补充内容
                }
            }

        }


        /// <summary>
        /// 随机一个发帖人的ID
        /// </summary>
        /// <param name="arryuid">不检索的ID</param>
        /// <returns></returns>
        public int RandUserID(int[] arryuid)
        {
            int?[] arriTemp = new int?[0];

            arriTemp = new int?[arryuid.Length];
            for (int i = 0; i < arryuid.Length; i++)
            {
                arriTemp[i] = arryuid[i];
            }
            List<ModuleCore.Entity.PostUser> ls = ModuleCore.BLL.PostUserControl.Instance.FillList();
            ModuleCore.Entity.PostUser x = (from q in ls where !arriTemp.Contains(q.UserID) orderby Guid.NewGuid() select q).Take(1).ToList()[0];

            bool isExist = EbSite.Base.Host.Instance.ExistsUserUserID(x.UserID);
            if (isExist)
            {
                return x.UserID;
            }
            else
            {
                return RandUserID(arryuid);
            }
        }

        public string RandIp(string[] arryip)
        {
            string[] arriTemp = new string[] { };

            arriTemp = new string[arryip.Length];
            for (int i = 0; i < arryip.Length; i++)
            {
                arriTemp[i] = arryip[i];
            }

            string[] arryips = IpControl.Instance.Ips.Split(',');
            var s = (from i in arryips where !arriTemp.Contains(i) orderby Guid.NewGuid() select i).Take(1).ToList()[0];
            return s.ToString();

        }
        /// <summary>
        ///  回复问题 ，同时给回复用户 添加 回答记录总数
        /// </summary>
        /// <param name="tag"> 问题ID</param>
        /// <param name="askuid">提问者ID</param>
        /// <param name="answeruserid">回答者ID</param>
        /// <param name="txtHf">回复内容</param>
        /// <param name="minute">时间间隔</param>
        /// <param name="ips">ip 地址</param>
        public void AddHfAnwser(long tag, int askuid, int answeruserid, string txtHf, int minute, string ips)
        {
            ModuleCore.Entity.Answers answers = new Answers();
            answers.QID = tag;//问题ID
            answers.QUserID = askuid; //int.Parse(AskUID);
            answers.AnswerUserID = answeruserid;// int.Parse(UID);//回答用户ID
            answers.AnswerContent = txtHf;
            answers.IsAdoption = false;
            answers.AnswerTime = DateTime.Now.AddMinutes(-minute);//第一个回复 -6分
            answers.IsDel = false;
            answers.AnswerIP = ips;
            answers.ReferBook = "";
            answers.IsAnonymity = false;
            answers.AnswerUpdateTime = DateTime.Now.AddMinutes(-minute);//回答者修改时间
            answers.Score = 0;//本次得分
            answers.GoodAsk = 0;
            answers.IsApproved = 1;//审核 1：通过 0：不通过
            int i = ModuleCore.BLL.Answers.Instance.Add(answers);

            if (i > 0)
            {
                //给 问题 的Annex11  加1 回答问题的总个数
                EbSite.Entity.NewsContent mdnewcontent = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(tag);
                mdnewcontent.Annex11 = mdnewcontent.Annex11 + 1;
                mdnewcontent.ID = tag;
                Base.AppStartInit.NewsContentInstDefault.Update(mdnewcontent);

            }

            //出使化 userhelp
            List<EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp> md = ModuleCore.BLL.UserHelp.Instance.GetListArray("userid=" + answeruserid);
            if (md.Count == 0)
            {
                EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp model = new UserHelp();
                model.UserID = answeruserid;
                model.QCount = 0;//提问总数
                model.ACount = 1;//回答总数
                model.AdoptionCount = 0;//采纳总数
                model.LikeAskClass = "";//推荐类型
                model.TotalScore = 0;
                ModuleCore.BLL.UserHelp.Instance.Add(model);
            }
            else
            {
                EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp model = md[0];
                model.UserID = answeruserid;
                model.ACount = model.ACount + 1; //回答总数
                ModuleCore.BLL.UserHelp.Instance.Update(model);
            }
        }
        /// <summary>
        /// 得到当站点的SiteID
        /// </summary>
        protected static int SiteDI
        {
            get
            {
                return SettingInfo.Instance.GetSiteID;
            }
        }

        protected void DrpBigClass_SelectedIndexChanged(Object sender, EventArgs e)
        {
            string ikey = this.DrpBigClass.SelectedValue;
            DrpSamllClass.DataSource = EbSite.BLL.NewsClass.GetListArr("ParentID=" + ikey, SiteDI);
            DrpSamllClass.DataTextField = "ClassName";
            DrpSamllClass.DataValueField = "ID";
            DrpSamllClass.DataBind();

        }
        #region 解决重写url后，保持postback地址不改变的问题

        //// <summary>
        ///  重写默认的HtmlTextWriter方法，修改form标记中的value属性，使其值为重写的URL而不是真实URL。
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (writer is System.Web.UI.Html32TextWriter)
            {
                writer = new FormFixerHtml32TextWriter(writer.InnerWriter);
            }
            else
            {
                writer = new FormFixerHtmlTextWriter(writer.InnerWriter);
            }

            base.Render(writer);
        }
        #endregion

    }

}