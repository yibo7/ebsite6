using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Shop.Core.Entity
{
    public class Buy_CreditCartItem : Base.Entity.EntityBase<Buy_CreditCartItem, int>
    {
        public Buy_CreditCartItem()
		{
			base.CurrentModel = this;
		}
        public Buy_CreditCartItem(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
		}


        public Buy_CreditCartItem(creditproduct md)
        {
            if (md != null)
            {
                this.CreditProductID = md.id;
                this.Quantity = 1;
                this.AddTime = DateTime.Now;
                this.Credit = md.Credit;
                this.SmallPic = md.SmallImg;
                this.ProductName = md.ProductName;
                
            }
        }
        protected override EbSite.Base.BLL.BllBase<Buy_CreditCartItem, int> Bll()
		{
			 
                return BLL.Buy_CreditCartItem.Instance;
			 
		}
        #region Model
        private long _orderid;
        private int _creditproductid;
        private int? _userid;
        private int _quantity;
        private DateTime? _addtime;
        private int _credit;
        private string _smallpic;
        private string _productname;
        //protected int _stock;
        /// <summary>
        /// 订单ID
        /// </summary>
        public long OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 积分商品 id
        /// </summary>
        public int CreditProductID
        {
            set { _creditproductid = value; }
            get { return _creditproductid; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 兑换积分
        /// </summary>
        public int Credit
        {
            set { _credit = value; }
            get { return _credit; }
        }
        /// <summary>
        /// 小图片路径
        /// </summary>
        public string SmallPic
        {
            set { _smallpic = value; }
            get { return _smallpic; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }

        /// <summary>
        /// 货存量
        /// </summary>
        public int Stock
        {
            get
            {
                Entity.creditproduct md = ModuleCore.BLL.creditproduct.Instance.GetEntity(CreditProductID);
                if (!Equals(md, null))
                {
                    return md.Stock;
                }
                return 0;
            }

        }
        #endregion Model

       
      
      
    }
}