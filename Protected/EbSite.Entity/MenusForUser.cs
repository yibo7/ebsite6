using System;
using EbSite.BLL.GetLink;
using EbSite.Base;

namespace EbSite.Entity
{
	/// <summary>
	/// 实体类MenusForUser 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public class MenusForUser : Base.Entity.EntityBase<MenusForUser, Guid>
	{
		public MenusForUser()
		{
			base.CurrentModel = this;
		}
        public MenusForUser(Guid ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        protected override Base.BLL.BllBase<MenusForUser, Guid> Bll()
        {
            
                return BLL.MenusForUser.Instance;
             
        }
		#region Model
		private string _menuname;
		private string _imageurl;
		private int _orderid;
        private Guid _parentid;
		private string _target;
        private Guid _ModuleMenuID;
		private string _pageurl;
		private bool _isleftparent;
        private Guid _modulesid;
		private DateTime? _addtime;
        private ThemeType _menutype;
		/// <summary>
		/// 
		/// </summary>
		public string MenuName
		{
			set
			{
                _menuname = value;
			}
			get{return _menuname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImageUrl
		{
			set
			{
                _imageurl = value;
			}
			get{return _imageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OrderID
		{
			set
			{
                _orderid = value;
			}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
        public Guid ParentID
		{
			set
			{
                _parentid = value;
			}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Target
		{
			set
			{
                _target = value;
			}
			get
			{
                if (string.IsNullOrEmpty(_target))
                    return id.ToString();
			    return _target;
			}
		}
		/// <summary>
		/// 
		/// </summary>
        public Guid ModuleMenuID
		{
			set
			{
                _ModuleMenuID = value;
			}
            get { return _ModuleMenuID; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string PageUrl
		{
			set
			{
                _pageurl = value;
			}
			get{return _pageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsLeftParent
		{
			set
			{
                _isleftparent = value;
			}
			get{return _isleftparent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid ModulesID
		{
			set
			{
                _modulesid = value;
			}
			get{return _modulesid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			set
			{
                _addtime = value;
			}
			get{return _addtime;}
		}
        /// <summary>
        /// 
        /// </summary>
        public ThemeType MenuType
        {
            set { _menutype = value; }
            get { return _menutype; }
        }
        public string Url
        {
            get
            {
                
                //return  HrefFactory.GetMainInstance.GetModulePathRw(_target);
                //EbSite.Base.PageLink.GetBaseLinks.Get(1)
                return Base.PageLink.GetBaseLinks.GetDefault.GetModulePathRw(_target);
            }
        }
		#endregion Model

	}
}

