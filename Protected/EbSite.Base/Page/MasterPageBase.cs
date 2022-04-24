
using System;
using System.Web.UI.HtmlControls;
using EbSite.BLL.User;

namespace EbSite.Base.Page
{
    public class MasterPageBase : System.Web.UI.MasterPage
    {
        public string ThemeCss
        {
            get
            {
                return string.Concat(Host.Instance.CurrentSite.ThemesPath("css"), "/");
            }
        }
        protected int Credits = 0;
        protected bool IsAdmin = false;
        protected int UserID = EbSite.Base.AppStartInit.UserID;
        protected string UserNiName = "";
        protected string UserName = "";
        protected EntityAPI.MembershipUserEb UserInfos;
        protected global::System.Web.UI.WebControls.Literal llFootInfo;
        ///// <summary>
        ///// 如果为true,说明已经登录，如果为false,不一定当前用户已经登录
        ///// </summary>
        //protected bool IsMy
        //{
        //    get
        //    {
        //        if(VUserID>0)
        //        {
        //            return VUserID == EbSite.Base.AppStartInit.UserID;
        //        }
        //        else
        //        {
        //            return EbSite.Base.AppStartInit.UserID > 0;
        //        }

        //    }
        //}
        public Host HostApi
        {
            get
            {
                return Host.Instance;
            }
        }
        /// <summary>
        /// 网站安装目录
        /// </summary>
        protected static string IISPath
        {
            get
            {
                return Base.AppStartInit.IISPath;
            }
        }
        ///// <summary>
        ///// 访问某个用户的ID
        ///// </summary>
        //protected int VUserID
        //{
        //    get
        //    {
        //        return Core.Utils.StrToInt(Request["uid"],0);
        //    }
        //}
        /// <summary>
        /// LOAD事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManagePage_Load(object sender, EventArgs e)
        {
           
                //if (IsMy)
                //{

                //    UserInfos = MembershipUserEb.Instance.GetEntity(Host.Instance.UserID);
                //}
                //else
                //{
                //    if (VUserID > 0)
                //    {
                //        UserInfos = MembershipUserEb.Instance.GetEntity(VUserID);
                //    }
                //    else
                //    {
                //        Tips("输入有误！","找不到对应的页面");
                //    }
                //}

            if (UserID > 0)
            {
                UserInfos = MembershipUserEb.Instance.GetEntity(UserID);
                Credits = UserInfos.Credits;
                IsAdmin = UserInfos.ManagerID > 0;
                UserID = UserInfos.id;
                UserNiName = UserInfos.NiName;
                UserName = UserInfos.UserName;
            }

            
            
            AddHeaderPram();
        }/// <summary>
        /// 版权信息
        /// </summary>
        protected string Copyright
        {
            get
            {
                return AppStartInit.Copyright;
            }
        }
        protected string KeepUserState(string sPram)
        {
            if (!string.IsNullOrEmpty(sPram)) sPram = string.Concat("?", sPram);
            string sUrl = string.Concat(EbSite.Base.AppStartInit.IISPath, "count.ashx", sPram);
            return string.Format("<img src=\"{0}\" width=0 height=0 border=0 />", sUrl);
        }
        // protected void ShowCopyright()
        //{

        //    if (!Equals(llFootInfo, null))
        //    {
        //        string cnzz = string.Empty;
        //        if (!Configs.ContentSet.ConfigsControl.Instance.IsStopCnzz)
        //        {
        //            cnzz = Core.CNZZ.GetJs();
        //        }

        //        llFootInfo.Text = string.Concat("<span>", Copyright, "</span><span>由eBSite", AppStartInit.ASSEMBLY_VERSION, "<a href='", AppStartInit.OfficialsUrl, "'>建站系统</a>修改完成,[<a target=_blank href='", IISPath, "sitemapindex.xml'>网站地图</a>]</span>", string.Concat(KeepUserState(""), cnzz));
        //    }
        //    //else
        //    //{
        //    //    throw new Exception("当前模板缺少ID为llFootInfo的Literal控件,您可以在模板底部添加以下代码:<asp:Literal ID=\"llFootInfo\" runat=\"server\"></asp:Literal>");
        //    //}
        //}
        /// <summary>
        /// 构造函数
        /// </summary>
        public MasterPageBase()
        {
            this.Load += new EventHandler(ManagePage_Load);
            
        }
        protected string SeoTitle;
        protected string SeoKeyWord;
        protected string SeoDes;
        protected virtual void AddHeaderPram()
        {
            HtmlMeta encode = new HtmlMeta();
            encode.HttpEquiv = "Content-Type";
            encode.Content = "text/html; charset=utf-8";
            Page.Header.Controls.Add(encode);
             

            if (!string.IsNullOrEmpty(SeoTitle))
            {
                Page.Title = SeoTitle;
            }
            if (!string.IsNullOrEmpty(SeoKeyWord))
            {
                SetMeta("keywords", SeoKeyWord);
            }
            if (!string.IsNullOrEmpty(SeoDes))
            {
                SetMeta("Description", SeoDes);
            }
        }
        public void SetMeta(string Name, string Content)
        {
            HtmlMeta hm = new HtmlMeta();
            hm.Name = Name;
            hm.Content = Content;
            Page.Header.Controls.Add(hm);

        }
        protected void Tips(string Title, string Info)
        {
            string sUrl = "";
            if (!Equals(Request.UrlReferrer, null))
                sUrl = Request.UrlReferrer.ToString();

            AppStartInit.TipsPageRender(Title, Info, sUrl);
        }
    }
        
}
