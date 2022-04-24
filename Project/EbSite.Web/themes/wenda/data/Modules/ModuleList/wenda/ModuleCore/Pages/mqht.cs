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


    public class mqht : System.Web.UI.Page
    {


        #region 控件定义

        protected global::System.Web.UI.WebControls.ListBox LbQuestion;
        protected global::System.Web.UI.WebControls.TextBox txtTT;
        protected global::System.Web.UI.WebControls.TextBox txtNR;
        

        protected global::System.Web.UI.WebControls.TextBox txtCT;
        protected global::System.Web.UI.WebControls.TextBox txtAskID;
        protected global::System.Web.UI.WebControls.Button btnSave;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.Title = "模拟快速回帖";
            //绑定一级分类
            btnSave.Click += new EventHandler(btnSave_Click);
            if(!IsPostBack)
            {
                DataBind();
            }

        }
        protected static int SiteDI
        {
            get
            {
                return SettingInfo.Instance.GetSiteID;
            }
        }
        protected void DataBind()
        {
            List<EbSite.Entity.NewsContent> ls = Base.AppStartInit.NewsContentInstDefault.GetListArray("Annex11=0", 10, "id desc",
                                                                                        "id,newstitle,ContentInfo", SiteDI);
            LbQuestion.DataSource = ls;
            LbQuestion.DataTextField = "newstitle";
            LbQuestion.DataValueField = "id";
            LbQuestion.DataBind();
        }
        protected void LbQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id =Convert.ToInt32( LbQuestion.SelectedValue);
            EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModelByFiledOfDefault("id,newstitle,ContentInfo", string.Concat("id=", id));
            txtTT.Text = md.NewsTitle;
            txtNR.Text = md.ContentInfo;
            txtAskID.Text = md.ID.ToString();
        }
        protected void btnSave_Click(object sender,EventArgs e)
        {
            //回复1
            if (!string.IsNullOrEmpty(txtCT.Text)&&!string.IsNullOrEmpty(txtAskID.Text))
            {
                int dc = 0;
                if(int.TryParse(txtAskID.Text,out dc))
                {
                    int uid1 = 0;
                    string ips1 = "";
                    //查出发贴人ID
                    EbSite.Entity.NewsContent model = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(int.Parse(txtAskID.Text));

                    mfastTopics fst = new mfastTopics();
                    uid1 = fst.RandUserID(new int[] {model.UserID});
                    ips1 =fst.RandIp(new string[] {});
                    fst.AddHfAnwser(model.ID, model.UserID, uid1, txtCT.Text, 0, ips1);

                    txtCT.Text = "";
                    txtAskID.Text = "";
                    DataBind();
                }
            }
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