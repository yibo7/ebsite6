using System;
namespace EbSite.Modules.Shop.ModuleCore.Entity
{
    /// <summary>
    /// 实体类TypeRelationProduct 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class TypeNameValues : Base.Entity.EntityBase<TypeNameValues, int>
    {
        public TypeNameValues()
        {
            base.CurrentModel = this;
        }
        public TypeNameValues(int ID)
        {
            base.id = ID;
            base.InitData(this);
            base.CurrentModel = this;
        }
        protected override EbSite.Base.BLL.BllBase<TypeNameValues, int> Bll()
        {
            
                return BLL.TypeNameValues.Instance;
           
        }
        #region Model
        private string _typevaluename;
        private int? _orderid;
        private string _tvalues;
        private int? _typenamevalueid;
        private int? _productid;
        /// <summary>
        /// 
        /// </summary>
        public string TypeValueName
        {
            set { _typevaluename = value; }
            get { return _typevaluename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TValues
        {
            set { _tvalues = value; }
            get { return _tvalues; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TypeNameValueID
        {
            set { _typenamevalueid = value; }
            get { return _typenamevalueid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        #endregion Model

    }
}

