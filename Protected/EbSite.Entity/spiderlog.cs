using System;
namespace EbSite.Entity
{
	/// <summary>
	/// ʵ����spiderlog ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ֩������
		/// </summary>
		public string SpiderName
		{
			set{ _spidername=value;}
			get{return _spidername;}
		}
		/// <summary>
		/// ֩��IDDateTime
		/// </summary>
		public int SpiderId
		{
			set{ _spiderid=value;}
			get{return _spiderid;}
		}
		/// <summary>
		/// �ܷõ�ַ
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public DateTime AddDateTime
		{
			set{ _addDateTime=value;}
			get{return _addDateTime;}
		}
		/// <summary>
		/// ���ʱ��������
		/// </summary>
		public long AddDateTimeInt
		{
			set{ _addDateTimeint=value;}
			get{return _addDateTimeint;}
		}
		/// <summary>
		/// ���ò���
		/// </summary>
		public string UserAgent
		{
			set{ _useragent=value;}
			get{return _useragent;}
		}
		/// <summary>
		/// Http״̬
		/// </summary>
		public int HttpState
		{
			set{ _httpstate=value;}
			get{return _httpstate;}
		}
		/// <summary>
		/// ���Ŀ¼
		/// </summary>
		public string UrlPath
		{
			set{ _urlpath=value;}
			get{return _urlpath;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Domain
		{
			set{ _domain=value;}
			get{return _domain;}
		}
		#endregion Model

	}
}

