using System;
namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
	/// <summary>
	/// 存内容页 右侧随机的数据源
	/// </summary>
	[Serializable]
	public class AskCache: Base.Entity.EntityBase<AskCache,int>
	{
		public AskCache()
		{
			
		}

		#region Model
		private int? _keyid;
		private int? _keytype=1;//先默认为1
		private string _randomids;
		private int? _dateline;
		private DateTime? _addtime;
		/// <summary>
		/// 提问的ID
		/// </summary>
		public int? keyid
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
        ///  现在 没有启用。以后 若多个地方 调用 随机源时 可以启用分类。
		/// </summary>
		public int? keytype
		{
			set{ _keytype=value;}
			get{return _keytype;}
		}
		/// <summary>
        /// 随机 数据RandNum 为NewsContent 中的字段. 两位随机数
		/// </summary>
		public string randomids
		{
			set{ _randomids=value;}
			get{return _randomids;}
		}
		/// <summary>
		/// 时间结束Int
		/// </summary>
		public int? dateline
		{
			set{ _dateline=value;}
			get{return _dateline;}
		}
		/// <summary>
		/// 时间结束
		/// </summary>
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

