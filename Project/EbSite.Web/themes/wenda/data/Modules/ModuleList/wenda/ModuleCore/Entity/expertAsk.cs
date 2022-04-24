using System;
namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
	/// <summary>
	/// ʵ����expertAsk ��ר�ҵ�����
	/// </summary>
	[Serializable]
	public class expertAsk: Base.Entity.EntityBase<expertAsk,int>
	{
		public expertAsk()
		{
			base.CurrentModel = this;
		}
		public expertAsk(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
		protected override EbSite.Base.BLL.BllBase<expertAsk, int> Bll()
		{
			 
				return BLL.expertAsk.Instance;
			 
		}
		#region Model
		private int? _qid;
	    private int? _classid;
		private int? _userid;
		private int? _state;
		private DateTime? _optime;
        private string _title;
        private DateTime? _askdate;

        /// <summary>
        /// ���� ����
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// �ش�ʱ��
        /// </summary>
        public DateTime? AskDate
        {
            get { return _askdate; }
            set { _askdate = value; }
        }

		/// <summary>
		/// ����id
		/// </summary>
		public int? Qid
		{
			set{ _qid=value;}
			get{return _qid;}
		}
        /// <summary>
        /// ����id
        /// </summary>
	    public int? ClassID
	    {
            get { return _classid; }
            set { _classid = value; }
	    }
		/// <summary>
		/// �û�ID
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// ״̬
		/// </summary>
		public int? State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime? OpTime
		{
			set{ _optime=value;}
			get{return _optime;}
		}
        
		#endregion Model

	}
}

