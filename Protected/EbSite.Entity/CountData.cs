using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类CountData 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [Serializable]
    public class CountData
	{
		public CountData()
		{}
		#region Model
		private int _id;
		private int _special;
		private int _music;
		private int _musicword;
		private int _addmusicword;
		private int _archives;
		private DateTime? _adddate;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int special
		{
			set{ _special=value;}
			get{return _special;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int music
		{
			set{ _music=value;}
			get{return _music;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int musicword
		{
			set{ _musicword=value;}
			get{return _musicword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int addmusicword
		{
			set{ _addmusicword=value;}
			get{return _addmusicword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int archives
		{
			set{ _archives=value;}
			get{return _archives;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? adddate
		{
			set{ _adddate=value;}
			get{return _adddate;}
		}
		#endregion Model

	}
}

