using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
	/// <summary>
	/// 实体类expandanswers  追问表
	/// </summary>
	[Serializable]
	public class expandanswers: Base.Entity.EntityBase<expandanswers,int>
	{
		public expandanswers()
		{
			base.CurrentModel = this;
		}
		public expandanswers(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}

        protected override EbSite.Base.BLL.BllBase<expandanswers, int> Bll()
        {
             
                return BLL.expandanswers.Instance;
            
        }
		#region Model
		private int? _answerid;
		private string _ctent;
		private DateTime? _tdate;
		private int? _uid;
		private int? _typeid;
		private int? _eid;
		/// <summary>
		/// 回答ID
		/// </summary>
		public int? AnswerId
		{
			set{ _answerid=value;}
			get{return _answerid;}
		}
		/// <summary>
		/// 追问内容 或 回答
		/// </summary>
		public string Ctent
		{
			set{ _ctent=value;}
			get{return _ctent;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime? TDate
		{
			set{ _tdate=value;}
			get{return _tdate;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public int? Uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 0: 追问 1： 回答
		/// </summary>
		public int? TypeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 回答追问时保存 对应的 expandanswers_id
		/// </summary>
		public int? Eid
		{
			set{ _eid=value;}
			get{return _eid;}
		}
		#endregion Model

	}
}

