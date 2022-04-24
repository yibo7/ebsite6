using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类SpaceThemeClass 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SpaceThemeClass: Base.Entity.EntityBase<SpaceThemeClass,int>
	{
		public SpaceThemeClass()
		{
			base.CurrentModel = this;
		}
		public SpaceThemeClass(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override Base.BLL.BllBase<SpaceThemeClass, int> Bll
        //{
        //    get
        //    {
        //        return BLL.SpaceThemeClass.Instance;
        //    }
        //}
		#region Model
		private string _classname;
		private DateTime? _addtime;
	    protected int _UserGroupID;
		/// <summary>
		/// 
		/// </summary>
		public string ClassName
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
        /// <summary>
        /// 皮肤对应的用户组ID
        /// </summary>
	    public int UserGroupID
	    {
	        get
	        {
	            return _UserGroupID;
	        }
            set
            {
                _UserGroupID = value;
            }
	    }

		#endregion Model

	}
}

