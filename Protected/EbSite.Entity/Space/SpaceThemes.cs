using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类SpaceThemes 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SpaceThemes: Base.Entity.EntityBase<SpaceThemes,int>
	{
		public SpaceThemes()
		{
			base.CurrentModel = this;
		}
		public SpaceThemes(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override Base.BLL.BllBase<SpaceThemes, int> Bll
        //{
        //    get
        //    {
        //        return BLL.SpaceThemes.Instance;
        //    }
        //}
		#region Model
		private string _themename;
		private string _themepath;
		private string _author;
		private int _userid;
		private DateTime _addtime;
        private int _ThemeClassID;
        private int _UserGroupID;
		/// <summary>
		/// 
		/// </summary>
		public string ThemeName
		{
			set{ _themename=value;}
			get{return _themename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ThemePath
		{
			set{ _themepath=value;}
			get{return _themepath.Trim();}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}

        public int ThemeClassID
        {
            set { _ThemeClassID = value; }
            get { return _ThemeClassID; }
        }

        public int UserGroupID
        {
            set { _UserGroupID = value; }
            get { return _UserGroupID; }
        }

	    public string ThemeRlPath
	    {
            get { return string.Concat(IISPath(), "home/themes/", ThemePath, "/"); }
	    }
        public string ImgUrl
	    {
            get { return string.Concat(ThemeRlPath, "preview.png"); }
	    }
        
		#endregion Model

	}
}

