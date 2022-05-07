using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Control.xsPage;


namespace EbSite.Control
{
    [ParseChildren(true)]//这里加这个特性很重要，否则.net将不会识别在前台的模版里面书写的内容.
    [DefaultProperty("Text"), ToolboxData("<{0}:PagesContrl runat=server></{0}:PagesContrl>")]
    public class PagesContrl : WebControl
    {

        public PagesContrl()
        {
            _Linktype = BLL.Sites.Instance.GetSiteLinkType(EbSite.Base.Host.Instance.GetSiteID);         
        }
        public int _PageIndex = 1;
        public int PageIndex
        {
            get
            {

                //if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["p"]))
                //    return Convert.ToInt32(HttpContext.Current.Request.QueryString["p"]);
                //else
                //    return 1;
                if (this._PageIndex > 1)
                {
                    return this._PageIndex;
                }
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["p"]))
                {
                    return Convert.ToInt32(HttpContext.Current.Request.QueryString["p"]);
                }
                return 1;
            }
            set
            {
                this._PageIndex = value;
            }
        }


        private static XsPages GetInstance(LinkType Linkt)
        {

            if (LinkType.Html == Linkt)
            {
                return new HtmlPages();
            }
            else if (LinkType.Aspx == Linkt)
            {
                return new cAspxPages();
            }
            else
            {
                return new cAutoHtmlPages();
            }
        }

        private LinkType _Linktype = LinkType.AspxRewrite;

        [Bindable(true),Category("Appearance"),DefaultValue("")]
        public LinkType Linktype
        {
            get
            {
                return _Linktype;

            }
            set
            {
                _Linktype = value;
            }
        }
        /// <summary>
        /// 连接路径-构建静态页面分页连接时常会用到
        /// </summary>
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue("")]
        public string ReWritePatchUrl
        {
            get
            {
                object o = ViewState["PatchUrl"];
                if (o == null)
                    return "";
                else
                    return (string)o;
            }
            set
            {
                ViewState["PatchUrl"] = value;
            }
        }
        /// <summary>
        /// 其他参数 格式为 参数名称1,参数值1|参数名称2,参数值3
        /// </summary>
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue("")]
        public string OtherPram
        {
            get
            {
                object o = ViewState["OtherPram"];
                if (o == null)
                    return "";
                else
                    return (string)o;
            }
            set
            {
                ViewState["OtherPram"] = value;
            }
        }

        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue("10")]
        public int AllCount
        {
            get
            {
                object o = ViewState["AllCount"];
                if (o == null)
                    return 1;
                else
                    return (int)o;
            }
            set
            {
                ViewState["AllCount"] = value;
            }
        }
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue("10")]
        public int PageSize
        {
            get
            {
                object o = ViewState["PageSize"];
                if (o == null)
                    return 0;
                else
                    return (int)o;
            }
            set
            {
                ViewState["PageSize"] = value;
            }
        }
        /// <summary>
        /// 显示多少个页码
        /// </summary>
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue("5")]
        public int ShowCodeNum
        {
            get
            {
                object o = ViewState["ShowCodeNum"];
                if (o == null)
                    return 5;
                else
                    return (int)o;
            }
            set
            {
                ViewState["ShowCodeNum"] = value;
            }
        }
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue("上一页")]
        public string UpPageText
        {
            get
            {
                object o = ViewState["UpPageText"];
                if (o == null)
                    return "未定义书籍名称";
                else
                    return (string)o;
            }
            set
            {
                ViewState["UpPageText"] = value;
            }
        }
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue("下一页")]
        public string NextPageText
        {
            get
            {
                object o = ViewState["NextPageText"];
                if (o == null)
                    return "下一页";
                else
                    return (string)o;
            }
            set
            {
                ViewState["NextPageText"] = value;
            }
        }
        /// <summary>
        /// 当前页码样式
        /// </summary>
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue("active")]
        public string CurrentClass
        {
            get
            {
                object o = ViewState["CurrentClass"];
                if (o == null)
                    return "active";
                else
                    return (string)o;
            }
            set
            {
                ViewState["CurrentClass"] = value;
            }
        }
        /// <summary>
        /// 当前页码样式
        /// </summary>
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue("")]
        public string ParentClass
        {
            get
            {
                object o = ViewState["ParentClass"];
                if (o == null)
                    return "";
                else
                    return (string)o;
            }
            set
            {
                ViewState["ParentClass"] = value;
            }
        }
        /// <summary>
        /// 将用户输入的OtherPram转换成hashtable
        /// </summary>
        private Hashtable htPram
        {
            get
            {
                string[] aS = OtherPram.Split('|');
                Hashtable ht = new Hashtable();
                if (aS.Length > 0)
                {
                    foreach (string s in aS)
                    {
                        string[] aS2 = s.Split(',');
                        if (aS2.Length > 1)
                        {
                            ht[aS2[0]] = aS2[1];
                        }

                    }
                }
                return ht;
            }
        }
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue("")]
        public string FirstPageUrl
        {
            get
            {
                object o = ViewState["FirstPageUrl"];
                if (o == null)
                    return "";
                else
                    return o.ToString();
            }
            set
            {
                ViewState["FirstPageUrl"] = value;
            }
        }
        /// <summary>
        /// 算出总共多少页 (YHL 2013-07-31)
        /// </summary>
        [
       Bindable(true),
       Category("Appearance"),
       DefaultValue("")]
        public int PageCount
        {
            get
            {
                if (AllCount <= 0 || PageSize <= 0)
                    return 1;
                else
                    return ((AllCount + PageSize) - 1) / PageSize;
            }
            
        }

        private bool _IsNoFollow = false;
        [Bindable(true), Category("Appearance"), DefaultValue("")]
        public bool IsNoFollow
        {
            get
            {
                return _IsNoFollow;

            }
            set
            {
                _IsNoFollow = value;
            }
        }


        /// <summary> 
        /// 将此控件呈现给指定的输出参数。
        /// </summary>
        /// <param name="output"> 要写出到的 HTML 编写器 </param>
        protected override void Render(HtmlTextWriter output)
        {
            //if (Equals(Linktype,null))
            //     Linktype = ConfigApi.Instance.obSysConfigs.GetConfig().Linktype;
            XsPages pgJzList = GetInstance(Linktype);//从工厂生成一个页码对象
            pgJzList.iCurrentPage = PageIndex;               //设置当前页码
            pgJzList.iTotalCount = this.AllCount;             //记录总数
            pgJzList.iPageSize = this.PageSize;                 //一首显示多少条
            pgJzList.ReWritePatchUrl = ReWritePatchUrl;
            pgJzList.htPrams = htPram;
            pgJzList.NextPageHtml = UpPageText;
            pgJzList.NextPageHtml = NextPageText;
            pgJzList.ShowCodeNum = ShowCodeNum;
            pgJzList.PageClassName = base.CssClass;
            pgJzList.CurrentCss = CurrentClass;
            pgJzList.ParentClassName = ParentClass;
            pgJzList.FirstPageUrl = FirstPageUrl;
            pgJzList.IsNoFollow = IsNoFollow;

            //显示页码代码
            output.Write(pgJzList.showpages());
        }
    }
}
