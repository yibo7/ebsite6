using System;
namespace EbSite.Modules.BBS.ModuleCore.Entity
{
	/// <summary>
	/// 实体类imitateuser 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class imitateuser: Base.Entity.EntityBase<imitateuser,int>
	{
		public imitateuser()
		{
			base.CurrentModel = this;
		}
		public imitateuser(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<imitateuser, int> Bll()
		{
			 
				return BLL.imitateuser.Instance;
			 
		}
		#region Model
		private int _userid;
		private int _imitateuserid;
		private string _imitateusername;
		private string _imitateuserrealname;
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
		public int ImitateUserID
		{
			set{ _imitateuserid=value;}
			get{return _imitateuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImitateUserName
		{
			set{ _imitateusername=value;}
			get{return _imitateusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImitateUserRealName
		{
			set{ _imitateuserrealname=value;}
			get{return _imitateuserrealname;}
		}
		#endregion Model

        public string UserNiName { get; set; }

        //public int RandNum { get; set; }

	}
}

