using System;
namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
	/// <summary>
	/// ������ҳ �Ҳ����������Դ
	/// </summary>
	[Serializable]
	public class AskCache: Base.Entity.EntityBase<AskCache,int>
	{
		public AskCache()
		{
			
		}

		#region Model
		private int? _keyid;
		private int? _keytype=1;//��Ĭ��Ϊ1
		private string _randomids;
		private int? _dateline;
		private DateTime? _addtime;
		/// <summary>
		/// ���ʵ�ID
		/// </summary>
		public int? keyid
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
        ///  ���� û�����á��Ժ� ������ط� ���� ���Դʱ �������÷��ࡣ
		/// </summary>
		public int? keytype
		{
			set{ _keytype=value;}
			get{return _keytype;}
		}
		/// <summary>
        /// ��� ����RandNum ΪNewsContent �е��ֶ�. ��λ�����
		/// </summary>
		public string randomids
		{
			set{ _randomids=value;}
			get{return _randomids;}
		}
		/// <summary>
		/// ʱ�����Int
		/// </summary>
		public int? dateline
		{
			set{ _dateline=value;}
			get{return _dateline;}
		}
		/// <summary>
		/// ʱ�����
		/// </summary>
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

