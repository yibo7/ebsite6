using System;
using System.Collections.Generic;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
    /// <summary>
    /// 实体类Website 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class SpaceTabDefaultWidgetInfo : XmlEntityBase<Guid>
    {

        private Guid _TabId;//标签ID
        /// <summary>
        /// 标签ID
        /// </summary>
        public Guid TabId
        {
            get
            {
                return _TabId;
            }
            set
            {
                _TabId = value;
            }
        }
        //private int _id;
        //public int id
        //{
        //    get { return _id; }
        //    set { _id = value; }
        //}
        //布局名称
        private string _LayoutPane;
        public string LayoutPane
        {
            get
            {
                return _LayoutPane;
            }
            set
            {
                _LayoutPane = value;
            }
        }
        //部件ID
        private Guid _WidgetsID;
        public Guid WidgetsID
        {
            get
            {
                return _WidgetsID;
            }
            set
            {
                _WidgetsID = value;
            }
        }

        //部件名称
        private string _WidgetsName;
        public string WidgetsName
        {
            get
            {
                return _WidgetsName;
            }
            set
            {
                _WidgetsName = value;
            }
        }


    }
}

