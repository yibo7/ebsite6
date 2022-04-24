using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Configs.ConfigsBase;

namespace EbSite.Base.Configs.ClassDefault
{
    public class ConfigsInfo : IConfigInfo
    {

        #region Model
        private string _contenthtmlname;
        private string _classhtmlnamerule;
        private bool _iscanaddcontent;
        private string _subclassaddname;
        private bool _subiscanaddsub;
        private bool _subiscanaddcontent;
        private bool _iscanaddsub;
        private int _pagesize;
        private Guid _moduleid;
        private Guid _classtemidmobile;
        private Guid _contenttemidmobile;
        private Guid _contentmodelid;
        private Guid _contenttemid;
        private Guid _classtemid;
        private Guid _classmodelid;
        private Guid _subclasstemid;
        private Guid _subclassmodelid;
        private Guid _subdefaultcontentmodelid;
        private Guid _subdefaultcontenttemid;
        private Guid _listtemid;
        /// <summary>
        /// 
        /// </summary>
        public string ContentHtmlName
        {
            set { _contenthtmlname = value; }
            get { return _contenthtmlname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassHtmlNameRule
        {
            set { _classhtmlnamerule = value; }
            get { return _classhtmlnamerule; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsCanAddContent
        {
            set { _iscanaddcontent = value; }
            get { return _iscanaddcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ContentModelID
        {
            set { _contentmodelid = value; }
            get { return _contentmodelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ContentTemID
        {
            set { _contenttemid = value; }
            get { return _contenttemid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ClassTemID
        {
            set { _classtemid = value; }
            get { return _classtemid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ClassModelID
        {
            set { _classmodelid = value; }
            get { return _classmodelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubClassAddName
        {
            set { _subclassaddname = value; }
            get { return _subclassaddname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid SubClassTemID
        {
            set { _subclasstemid = value; }
            get { return _subclasstemid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid SubClassModelID
        {
            set { _subclassmodelid = value; }
            get { return _subclassmodelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid SubDefaultContentModelID
        {
            set { _subdefaultcontentmodelid = value; }
            get { return _subdefaultcontentmodelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid SubDefaultContentTemID
        {
            set { _subdefaultcontenttemid = value; }
            get { return _subdefaultcontenttemid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool SubIsCanAddSub
        {
            set { _subiscanaddsub = value; }
            get { return _subiscanaddsub; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool SubIsCanAddContent
        {
            set { _subiscanaddcontent = value; }
            get { return _subiscanaddcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsCanAddSub
        {
            set { _iscanaddsub = value; }
            get { return _iscanaddsub; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ListTemID
        {
            set { _listtemid = value; }
            get { return _listtemid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PageSize
        {
            set { _pagesize = value; }
            get { return _pagesize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ModuleID
        {
            set { _moduleid = value; }
            get { return _moduleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ClassTemIdMobile
        {
            set { _classtemidmobile = value; }
            get { return _classtemidmobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ContentTemIdMobile
        {
            set { _contenttemidmobile = value; }
            get { return _contenttemidmobile; }
        }
        #endregion Model


    }
}
