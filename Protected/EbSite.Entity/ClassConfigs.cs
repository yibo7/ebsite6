using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{
	/// <summary>
	/// 实体类classconfigs 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ClassConfigs: Base.Entity.EntityBase<ClassConfigs,int>
	{
		public ClassConfigs()
		{
			base.CurrentModel = this;
		}
        public ClassConfigs(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<classconfigs, int> Bll
        //{
        //    get
        //    {
        //        return BLL.classconfigs.Instance;
        //    }
        //}
		#region Model
		private string _contenthtmlname;
		private string _classhtmlnamerule;
		private bool _iscanaddcontent;
		private string _subclassaddname;
		private bool _subiscanaddsub;
		private bool _subiscanaddcontent;
		private bool _iscanaddsub;
		private int _pagesize;
		//private string _classid;
		private DateTime _addtime;
        private int _siteid;
        //private bool _isdefault;

        private Guid _classtemidmobile;
        private Guid _contenttemidmobile;
        private Guid _moduleid;//-----------------
        private Guid _listtemid;
        private Guid _subclasstemid;
        private Guid _subclassmodelid;
        private Guid _subdefaultcontentmodelid;
        private Guid _subdefaultcontenttemid;
        private Guid _contentmodelid;
        private Guid _contenttemid;
        private Guid _classtemid;
        private Guid _classmodelid;

		/// <summary>
        /// 内容静态面页规则
		/// </summary>
		public string ContentHtmlName
		{
			set{ _contenthtmlname=value;}
			get{return _contenthtmlname;}
		}
		/// <summary>
        /// 分类静态面页规则
		/// </summary>
		public string ClassHtmlNameRule
		{
			set{ _classhtmlnamerule=value;}
			get{return _classhtmlnamerule;}
		}
		/// <summary>
        /// 是否可以添加内容
		/// </summary>
		public bool IsCanAddContent
		{
			set{ _iscanaddcontent=value;}
			get{return _iscanaddcontent;}
		}
		/// <summary>
		/// 内容模型
		/// </summary>
        public Guid ContentModelID
		{
			set{ _contentmodelid=value;}
			get{return _contentmodelid;}
		}
		/// <summary>
		/// 内容模板
		/// </summary>
        public Guid ContentTemID
		{
			set{ _contenttemid=value;}
			get{return _contenttemid;}
		}
		/// <summary>
        /// 分类模板
		/// </summary>
        public Guid ClassTemID
		{
			set{ _classtemid=value;}
			get{return _classtemid;}
		}
		/// <summary>
        /// 分类模型
		/// </summary>
        public Guid ClassModelID
		{
			set{ _classmodelid=value;}
			get{return _classmodelid;}
		}
		/// <summary>
        /// 子分类添加名字
		/// </summary>
		public string SubClassAddName
		{
			set{ _subclassaddname=value;}
			get{return _subclassaddname;}
		}
		/// <summary>
        /// 子分类模板
		/// </summary>
        public Guid SubClassTemID
		{
			set{ _subclasstemid=value;}
			get{return _subclasstemid;}
		}
		/// <summary>
		/// 子类分类 模型
		/// </summary>
        public Guid SubClassModelID
		{
			set{ _subclassmodelid=value;}
			get{return _subclassmodelid;}
		}
		/// <summary>
        /// 子分类内容模型
		/// </summary>
        public Guid SubDefaultContentModelID
		{
			set{ _subdefaultcontentmodelid=value;}
			get{return _subdefaultcontentmodelid;}
		}
		/// <summary>
        /// 子分类内容模板
		/// </summary>
        public Guid SubDefaultContentTemID
		{
			set{ _subdefaultcontenttemid=value;}
			get{return _subdefaultcontenttemid;}
		}
		/// <summary>
        /// 子分类是否可添加子分类
		/// </summary>
		public bool SubIsCanAddSub
		{
			set{ _subiscanaddsub=value;}
			get{return _subiscanaddsub;}
		}
		/// <summary>
        /// 子分类是否可以添加内容
		/// </summary>
		public bool SubIsCanAddContent
		{
			set{ _subiscanaddcontent=value;}
			get{return _subiscanaddcontent;}
		}
		/// <summary>
        /// 是否可以添加子分类
		/// </summary>
		public bool IsCanAddSub
		{
			set{ _iscanaddsub=value;}
			get{return _iscanaddsub;}
		}
		/// <summary>
        /// 内容管理模板 可以自定义后台内容管理模板  
		/// </summary>
        public Guid ListTemID
		{
			set{ _listtemid=value;}
			get{return _listtemid;}
		}
		/// <summary>
        /// 一页显示数量(前台)
		/// </summary>
		public int PageSize
		{
			set{ _pagesize=value;}
			get{return _pagesize;}
		}
		/// <summary>
        /// 内容扩展(模块选择)
		/// </summary>
        public Guid ModuleID
		{
			set{ _moduleid=value;}
			get{return _moduleid;}
		}
        ///// <summary>
        ///// 分类id,多个用逗号分开
        ///// </summary>
        //public string ClassID
        //{
        //    set { _classid = value; }
        //    get { return _classid; }
        //}
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
        /// 移动设备 分类模板
		/// </summary>
        public Guid ClassTemIdMobile
		{
			set{ _classtemidmobile=value;}
			get{return _classtemidmobile;}
		}
		/// <summary>
        /// 移动设备 内容模板
		/// </summary>
        public Guid ContentTemIdMobile
		{
			set{ _contenttemidmobile=value;}
			get{return _contenttemidmobile;}
		}
        /// <summary>
        /// 站点 ID
        /// </summary>
        public int SiteID
        {
            set { _siteid = value; }
            get { return _siteid; }
        }
        ///// <summary>
        ///// 
        ///// </summary>
        //public bool IsDefault
        //{
        //    set { _isdefault = value; }
        //    get { return _isdefault; }
        //}
		#endregion Model

	}
}

