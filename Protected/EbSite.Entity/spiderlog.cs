using System;
namespace EbSite.Entity
{
	/// <summary>
	/// 实体类spiderlog 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class spiderlog 
	{
		 
		#region Model
        public long Id { get; set; }
		private string _spidername;
		private int _spiderid;
		private string _url;
		private DateTime _addDateTime;
		private long _addDateTimeint;
		private string _useragent;
		private int _httpstate;
		private string _urlpath;
		private string _domain;
		/// <summary>
		/// 蜘蛛名称
		/// </summary>
		public string SpiderName
		{
			set{ _spidername=value;}
			get{return _spidername;}
		}
		/// <summary>
		/// 蜘蛛IDDateTime
		/// </summary>
		public int SpiderId
		{
			set{ _spiderid=value;}
			get{return _spiderid;}
		}
		/// <summary>
		/// 受访地址
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime AddDateTime
		{
			set{ _addDateTime=value;}
			get{return _addDateTime;}
		}
		/// <summary>
		/// 添加时间整数型
		/// </summary>
		public long AddDateTimeInt
		{
			set{ _addDateTimeint=value;}
			get{return _addDateTimeint;}
		}
		/// <summary>
		/// 来访参数
		/// </summary>
		public string UserAgent
		{
			set{ _useragent=value;}
			get{return _useragent;}
		}
		/// <summary>
		/// Http状态
		/// </summary>
		public int HttpState
		{
			set{ _httpstate=value;}
			get{return _httpstate;}
		}
		/// <summary>
		/// 相对目录
		/// </summary>
		public string UrlPath
		{
			set{ _urlpath=value;}
			get{return _urlpath;}
		}
		/// <summary>
		/// 域名
		/// </summary>
		public string Domain
		{
			set{ _domain=value;}
			get{return _domain;}
		}
		#endregion Model

	}
}

