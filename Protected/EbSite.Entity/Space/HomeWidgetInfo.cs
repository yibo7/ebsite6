using System;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
	/// <summary>
	/// 实体类Website 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public class HomeWidgetInfo : XmlEntityBase<Guid>
    {

        private string _WidgetName;
        private int _widgettypeid = 0;
        private int _UserGroupID;
        private string _ImgUrl;
	    private int _ThemeClassID;
        /// <summary>
        /// 对应皮肤的ID
        /// </summary>
	    public int ThemeClassID
	    {
	        get
	        {
	            return _ThemeClassID;
	        }
            set
            {
                _ThemeClassID = value;
            }
	    }
        /// <summary>
        /// 部件名称
        /// </summary>
        public string WidgetName
        {
            set { _WidgetName = value; }
            get { return _WidgetName; }
        }
        /// <summary>
        /// 部件显示的代表图片
        /// </summary>
        public string ImgUrl
        {
            set { _ImgUrl = value; }
            get { return _ImgUrl; }
        }
        /// <summary>
        /// 部件类别ID
        /// </summary>
        public int WidgetTypeID
        {
            set { _widgettypeid = value; }
            get { return _widgettypeid; }
        }
        /// <summary>
        /// 用户组的ID 
        /// </summary>
        public int UserGroupID
        {
            set { _UserGroupID = value; }
            get { return _UserGroupID; }
        }


	}
}

