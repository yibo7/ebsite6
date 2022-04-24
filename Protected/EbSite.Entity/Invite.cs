using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类EB_Invite 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Invite: Base.Entity.EntityBase<Invite,int>
	{
		public Invite()
		{
			base.CurrentModel = this;
		}
        public Invite(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        //protected override EbSite.Base.BLL.BllBase<Invite, int> Bll
        //{
        //    get
        //    {
        //        return BLL.Invite.Instance;
        //    }
        //}
		#region Model
		private string _userid;
		private int? _inviteuserid;
		private string _inviteinviteniname;
		private DateTime? _adddate;
		/// <summary>
		/// 
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 邀请人用户ID
		/// </summary>
		public int? InviteUserID
		{
			set{ _inviteuserid=value;}
			get{return _inviteuserid;}
		}
		/// <summary>
		/// 邀请人的用户昵称
		/// </summary>
		public string InviteInviteNiName
		{
			set{ _inviteinviteniname=value;}
			get{return _inviteinviteniname;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? AddDate
		{
			set{ _adddate=value;}
			get{return _adddate;}
		}
		#endregion Model

	}
}

