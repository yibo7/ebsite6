using System;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
	/// <summary>
	/// 实体类Website 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public class LayoutPaneInfo : XmlEntityBase<Guid>
    {

        private string _LayoutName;
        private string _FileName;
        /// <summary>
        /// 版式名称
        /// </summary>
        public string LayoutName
        {
            set { _LayoutName = value; }
            get { return _LayoutName; }
        }
        /// <summary>
        /// 文件名称，不带后缀，组成版式文件名(level_33_33_33.ascx) 与版式图片名(level_33_33_33.jpg)
        /// </summary>
        public string FileName
        {
            set { _FileName = value; }
            get { return _FileName; }
        }
        //public string ThemeRlPath
        //{
        //    get { return string.Concat(IISPath, "home/themes/layoutpanes/"); }
        //}
        //public string ImgUrl
        //{
        //    get { return string.Concat(ThemeRlPath, FileName, ".jpg"); }
        //}

	}
}

