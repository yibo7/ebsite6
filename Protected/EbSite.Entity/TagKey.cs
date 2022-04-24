using System;
using System.Collections.Generic;
using System.Linq;
using EbSite.BLL;

namespace EbSite.Entity
{
	/// <summary>
	/// 实体类TagKey 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [Serializable]
    public class TagKey
	{
		public TagKey()
		{} 
		#region Model
		private int _id;
		private string _tagname;
		private int _num;
        private string _relateclassids;
        private int _siteid;

	    private string _HtmlName;
        private string _HtmlNameRule;
        private string _SeoTitle;
        private string _SeoKeyWord;
        private string _SeoDescription;

	    public string HtmlName
	    {
	        get
	        {
                if (!string.IsNullOrEmpty(_HtmlName))
                {
                    return _HtmlName;
                }
                else
                {
                    return HtmlReNameRule.GetName(HtmlNameRule, TagName, "");
                }
	        } 
            set
            {
                _HtmlName = value;
            }
	    }
        public string HtmlNameRule
        {
            get
            {
                if (!string.IsNullOrEmpty(_HtmlNameRule))
                {
                    return _HtmlNameRule;
                }
                else
                {
                    return Base.Configs.HtmlConfigs.ConfigsControl.Instance.TagsSearchList;
                }
                
            }
            set
            {
                _HtmlNameRule = value;
            }
        }
        public string SeoTitle
        {
            get
            {
                if (!string.IsNullOrEmpty(_SeoTitle))
                {
                    return _SeoTitle;
                }
                else
                {
                    List<EbSite.Base.EntityCustom.SeoSite> ls = BLL.SeoSites.Instance.FillList();
                    int siteid = SiteID;
                    List<EbSite.Base.EntityCustom.SeoSite> md = (from i in ls where i.SiteID == siteid select i).ToList();
                    if (md.Count > 0)
                        return md[0].SeoTagListTitle;
                    return null;
                   // return Base.Configs.ContentSet.ConfigsControl.Instance.SeoTagListTitle;
                }
            }
            set
            {
                _SeoTitle = value;
            }
        }
        public string SeoKeyWord
        {
            get
            {
                if (!string.IsNullOrEmpty(_SeoKeyWord))
                {
                    return _SeoKeyWord;
                }
                else
                {
                    List<EbSite.Base.EntityCustom.SeoSite> ls = BLL.SeoSites.Instance.FillList();
                    int siteid = SiteID;
                    List<EbSite.Base.EntityCustom.SeoSite> md = (from i in ls where i.SiteID == siteid select i).ToList();
                    if (md.Count > 0)
                        return md[0].SeoTagListKeyWord;
                    return null;
                   // return Base.Configs.ContentSet.ConfigsControl.Instance.SeoTagListKeyWord;
                }
            }
            set
            {
                _SeoKeyWord = value;
            }
        }
        public string SeoDescription
        {
            get
            {
                if (!string.IsNullOrEmpty(_SeoDescription))
                {
                    return _SeoDescription;
                }
                else
                {
                    List<EbSite.Base.EntityCustom.SeoSite> ls = BLL.SeoSites.Instance.FillList();
                    int siteid = SiteID;
                    List<EbSite.Base.EntityCustom.SeoSite> md = (from i in ls where i.SiteID == siteid select i).ToList();
                    if (md.Count > 0)
                        return md[0].SeoTagListDes;
                    return null;
                   // return Base.Configs.ContentSet.ConfigsControl.Instance.SeoTagListDes;
                }
            }
            set
            {
                _SeoDescription = value;
            }
        }

        public int SiteID
        {
            get
            {
                return _siteid;
            }
            set
            {
                _siteid = value;
            }
        }

		/// <summary>
		/// 标签ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 标签名称
		/// </summary>
		public string TagName
		{
			set{ _tagname=value;}
			get{return _tagname;}
		}
		/// <summary>
		/// 标签统计总量
		/// </summary>
		public int Num
		{
			set{ _num=value;}
			get{return _num;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string RelateClassIDs
        {
            set
            {
                _relateclassids = value;
            }
            get
            {
                return _relateclassids;
            }
        }
		#endregion Model

	}
}

