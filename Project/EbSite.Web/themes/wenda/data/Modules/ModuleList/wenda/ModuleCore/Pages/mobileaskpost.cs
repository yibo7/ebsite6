using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;
using EbSite.Entity;
using EbSite.Modules.Wenda.Ajaxget;
using EbSite.Modules.Wenda.ModuleCore.BLL;
using EbSite.Modules.Wenda.ModuleCore.Entity;

namespace EbSite.Modules.Wenda.ModuleCore.Pages
{
    public class mobileaskpost : EbSite.Base.Page.BasePageMobile
    {
        #region 控件注册
        protected System.Web.UI.WebControls.LinkButton btnAddAsk;
        protected System.Web.UI.WebControls.TextBox txTitle;
        protected System.Web.UI.WebControls.TextBox txCtent;
        protected System.Web.UI.WebControls.DropDownList DrpScore;
        protected System.Web.UI.WebControls.DropDownList DrpBigClass;
        protected System.Web.UI.WebControls.DropDownList DrpSmallClass;

        protected System.Web.UI.WebControls.HiddenField HidClass;

        //protected System.Web.UI.WebControls.Repeater rpGetSubClassList;



        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBigClass();
               
            }
        }
        protected void BindBigClass()
        {
            DrpBigClass.DataSource = DataNewsClass(0, true);
            DrpBigClass.DataValueField = "id";
            DrpBigClass.DataTextField = "classname";
            DrpBigClass.DataBind();
            DrpBigClass.Items.Insert(0,new ListItem("请选择汽车品牌", "-1"));   
        }

        private List<EbSite.Entity.NewsClass> DataNewsClass(int pid, bool bl)
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
            List<EbSite.Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetListArr(strsql, 0,SettingInfo.Instance.GetSiteID);
            return lst;
        }

        protected void btnAddAsk_Click(object sender, EventArgs e)
        {
            if (UserID > 0)
            {
                int iClassID = EbSite.Core.Utils.StrToInt(HidClass.Value, 0);

                string sTtile = txTitle.Text; //标题
                string sCtent = txCtent.Text;
                int iScore = Core.Utils.StrToInt(DrpScore.SelectedValue, 0);

                #region

                EbSite.Entity.NewsContent newsContent = new NewsContent();

                newsContent.ClassID = iClassID;
                newsContent.ContentInfo = sCtent;
                newsContent.NewsTitle = sTtile;

                newsContent.Annex22 = iScore;
                newsContent.Annex2 = "手机网友"; //来源
                newsContent.Annex3 = "0";
                newsContent.Annex5 = "0";

                newsContent.Annex21 = Convert.ToInt32(SystemEnum.AskState.NoSolve);
                newsContent.Annex6 = DateTime.Now.ToString(); //发表问题 时间
                newsContent.Annex9 = DateTime.Now.AddDays(ConfigControl.Instance.AnswerDays).ToString();
                //到期日期

                newsContent.IsAuditing = !EbSite.Base.Host.Instance.GetIsAuditing();

                newsContent.Annex14 = 0; //是否匿名 1：匿名 0：不匿名
                newsContent.SiteID = SettingInfo.Instance.GetSiteID;
                newsContent.TitleStyle = "";
                newsContent.UserID = UserID;
                //2012-12-07 yhl
                newsContent.ContentHtmlNameRule = "content/{#TitleSpell#}{#KeyID#}";
                newsContent.HtmlName = EbSite.BLL.HtmlReNameRule.GetName(newsContent.ContentHtmlNameRule,
                                                                         newsContent.NewsTitle,
                                                                         newsContent.ClassName);
                //从当前规则转换文件名
                newsContent.IsComment = true;
              

                int tag = Base.AppStartInit.NewsContentInstDefault.Add(newsContent);
                if (tag > 0)
                {

                    //减去 相应的分数
                    if (iScore > 0)
                        EbSite.Base.Host.Instance.MinusUserCreditsByID(UserID, iScore);


                  
                }

                //出使化 userhelp
                List<EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp> md =
                    ModuleCore.BLL.UserHelp.Instance.GetListArray("userid=" + UserID);
                if (md.Count == 0)
                {
                    EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp model = new ModuleCore.Entity.UserHelp();
                    model.UserID = UserID;
                    model.QCount = 1; //提问总数
                    model.ACount = 0; //回答总数
                    model.AdoptionCount = 0; //采纳总数
                    model.LikeAskClass = ""; //推荐类型
                    model.TotalScore = 0;
                    ModuleCore.BLL.UserHelp.Instance.Add(model);
                }
                else
                {
                    EbSite.Modules.Wenda.ModuleCore.Entity.UserHelp model = md[0];
                    model.UserID = UserID;
                    model.QCount = model.QCount + 1; //提问总数
                    ModuleCore.BLL.UserHelp.Instance.Update(model);
                }
                #endregion

                   if (EbSite.Base.Host.Instance.GetIsAuditing())
                   {
                       //审核
                       base.Tips("提示","问题正在审核中，请耐心等待！");
                   }
                   else
                   {
                       //Response.Redirect(EbSite.Base.Host.Instance.MGetContentLink(tag));
                   }
            }
        }
        static private int GetRandNum()
        {
            int min = 1;
            int max = 1000;
            Random a = new Random();
            int result = a.Next(min, max);

            return result;

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