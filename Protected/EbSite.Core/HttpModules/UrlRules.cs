using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base;

namespace EbSite.Core.HttpModules
{
    public static class UrlRules
    {

        #region 电脑版规则

        public static string ContentCusttomRule { get; set; }
        // 规则>专题ID
        public static Dictionary<string, int> SpecialRuleHtmlNames = new Dictionary<string, int>();
        // 专题ID>规则
        public static Dictionary<int, string> SpecialRuleHtmlNames2 = new Dictionary<int, string>();

        // 规则>分类ID
        public static Dictionary<string,int> ClassRuleHtmlNames  = new Dictionary<string,int>();
        // 分类ID>规则
        public static Dictionary<int, string> ClassRuleHtmlNames2 = new Dictionary<int,string>();

        //public static Dictionary<string, int> ClassRuleHtmlNameForContentPre = new Dictionary<string, int>();
        public static Dictionary<int, string> ClassRuleHtmlNameForContentPre2 = new Dictionary<int, string>();

        //public static Dictionary<string, long> ContentRuleHtmlNames = new Dictionary<string, long>();
        //public static Dictionary<long, string> ContentRuleHtmlNames2 = new Dictionary<long, string>();

        //首页的重写，因为有时首页也用来做列表，即所有数据列表，所以有分页码
        public static readonly  string IndexRule = string.Concat("([0-9]+)-", Base.Configs.ContentSet.ConfigsControl.Instance.IndexPathRw);
        //分类页
        //public static readonly string ClassRule = string.Concat("([0-9]+)-([0-9]+)-([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.ListPathRw);
        public static string ClassRule { get; set; }

        //{
        //    get
        //    {
        //        string url = Base.Configs.ContentSet.ConfigsControl.Instance.ListPathRw.Replace("{分类ID}", "([0-9]+)").Replace("{页码}", "([0-9]+)").Replace("{排序类别}", "([0-9]+)");
        //        return url;
        //    }
        //}
        //内容页
        //public static readonly string ContentRule = string.Concat("([0-9]+)-([0-9]+)-([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.ContentPathRw);
        //专题页
        //public static readonly string SpecialRule = string.Concat("([0-9]+)-([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.SpecialPathRw);
        public static string ContentRule { get; set; }

        //public static readonly string ContentRuleDefault = string.Concat("([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.ContentPathRw);

        //public static string ContentCusttomRule { get; set; }

        //表单
        public static readonly string CustomFormRule = string.Concat("([A-Za-z0-9]+-[A-Za-z0-9]+-[A-Za-z0-9]+-[A-Za-z0-9]+-[A-Za-z0-9]+)-([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.CustomFormRw);

       
        public static string SpecialRule { get; set; }

        //标签搜索页
        public static readonly string TagsSearchRuleByID = string.Concat("([0-9]+)-([0-9]+)",
                                              Base.Configs.ContentSet.ConfigsControl.Instance.TagSearchRw);
        //标签列表页
        public static readonly string TagsRule = string.Concat("([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.TaglistRw);

        //错误页面
        public static readonly string errPage = string.Concat("err([0-9]+).ashx");


        public static readonly string sUserAlbum = string.Concat("([0-9]+)-([0-9]+)-([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.UserAlbumRw);

        //第三方登录回调地址
        public static readonly string sLoginBackBind = string.Concat("([A-Za-z0-9]+)-", Base.Configs.ContentSet.ConfigsControl.Instance.LoginbindRw);

        //支付页面
        //string sPayment = string.Concat("([A-Za-z0-9]+)-", Base.PageLink.GetBaseLinks.GetDefault.PaymentRw);

        //配送页面
        //string sDelivery = string.Concat("([A-Za-z0-9]+)-", Base.PageLink.GetBaseLinks.GetDefault.DeliveryRw);

        //默认用户信息展示页，如果您还没有开通个人空间，点击用户连接时会连接到这个模板页面
        public static readonly string uinfoRule = string.Concat("([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.UserInfoRw);


        public static readonly string voteviewRule = string.Concat("([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.VoteViewRw);
        public static readonly string votepostRule = string.Concat("([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.VotePostRw);

        public static readonly string topRule = string.Concat("([0-9]+)", "-", "([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.TopRw);

        public static readonly string AllClassRule = Base.Configs.ContentSet.ConfigsControl.Instance.ListPathAllRw;
        //评论,连接规则:评论类别ID_系统分类ID_内容ID_展示模板ID_站点ID_分内或内容标记_dc.aspx
        public static readonly string discussRule = "([0-9]+)_(-?[0-9]+)_([0-9]+)_([0-9]+)_([0-9]+)_([0-9]+)dc.aspx";

        #endregion

        #region 手机版地址规则

        //static public string MPathUrl
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.MPathUrl))
        //        return string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.IISPath, EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.MPathUrl.ToLower());
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}

        public static  string MPathUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.MPath))
                {
                    if (EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.MPath.StartsWith("http://"))
                    {
                        return string.Concat(EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.MPath, "/");
                    }

                    return string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName,"/", EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.MPath, "/");

                }
                else
                {
                    return string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName, "/");
                }

                //if (!string.IsNullOrEmpty(EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.MPath))
                //{
                //    if (EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.MPath.StartsWith("http://"))
                //    {
                //        return string.Concat(EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.MPath, "/");
                //    }

                //    return string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.IISPath, EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.MPath, "/");

                //}
                //else
                //{
                //    return Base.Configs.SysConfigs.ConfigsControl.Instance.IISPath;
                //}

                
            }
        }
        //    EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.MPathUrl.ToLower();//string.Concat(Base.Configs.SysConfigs.ConfigsControl.Instance.IISPath, EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.MPathUrl.ToLower());
        public static readonly string sMIndex = string.Concat("([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.MIndexPathRw);
        public static readonly string sMIndexNoPram = string.Concat(MPathUrl, Base.Configs.ContentSet.ConfigsControl.Instance.MIndexPathRw).ToLower();// 

        public static readonly string sMClassIndexRule = string.Concat("([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.MListPathRw);
        ///m/list.ashx

        public static readonly string sMClassRule = string.Concat("([0-9]+)-([0-9]+)-([0-9]+)-([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.MListPathRw);


         //标签搜索页
        public static readonly string sMTagsSearchRuleByID = string.Concat("([0-9]+)-([0-9]+)-([0-9]+)",
                                              Base.Configs.ContentSet.ConfigsControl.Instance.MTagSearchRw);
        //标签列表页
        public static readonly string sMTagsRule = string.Concat("([0-9]+)-([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.MTaglistRw);

        //内容页
        //public static readonly string sMContentRuleDefault = string.Concat("([0-9]+)-([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.MContentPathRw.ToLower());
        public static readonly string sMContentRule = string.Concat("([0-9]+)-([0-9]+)-([0-9]+)-([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.MContentPathRw.ToLower());
        public static readonly string sMSpecialIndex = string.Concat("([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.MSpecialPathRw);
        public static readonly string sMSpecial = string.Concat("([0-9]+)-([0-9]+)-([0-9]+)", Base.Configs.ContentSet.ConfigsControl.Instance.MSpecialPathRw);

        #endregion

    }
}
