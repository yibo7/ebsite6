using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
    /// <summary>
    /// 提问的 补充内容
    /// </summary>
    public class ExpandContent : Base.Entity.EntityBase<ExpandContent, int>
    {
        public ExpandContent()
		{
			base.CurrentModel = this;
		}
        public ExpandContent(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}
        protected override EbSite.Base.BLL.BllBase<ExpandContent, int> Bll()
        {
             
                return BLL.ExpandContent.Instance;
            
        }
		#region Model
		private int? _cid;
        private int? _classid;
		private DateTime? _tdate;
        private string _ctent;
		
		/// <summary>
		/// 问题id
		/// </summary>
		public int? Cid
		{
            set { _cid = value; }
            get { return _cid; }
		}
        /// <summary>
        /// 分类 id  1.用来确定 表。2.路径地址
        /// </summary>
        public int? ClassID
        {
            get { return _classid; }
            set { _classid = value; }
        }
		/// <summary>
		/// 补充问题时间
		/// </summary>
        public DateTime? TDate
		{
            set { _tdate = value; }
            get { return _tdate; }
		}
		/// <summary>
		/// 补充内容
		/// </summary>
        public string Ctent
		{
            set { _ctent = value; }
            get { return _ctent; }
		}
		
		#endregion Model
    }
}