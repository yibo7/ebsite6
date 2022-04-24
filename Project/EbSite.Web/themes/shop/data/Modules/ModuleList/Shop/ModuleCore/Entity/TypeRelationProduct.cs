using System;
using System.Collections.Generic;

namespace EbSite.Modules.Shop.ModuleCore.Entity
{
    /// <summary>
    /// 实体类TypeRelationProduct 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class TypeRelationProduct : Base.Entity.EntityBase<TypeRelationProduct, int>
    {
        public TypeRelationProduct()
        {
            base.CurrentModel = this;
        }
        public TypeRelationProduct(int ID)
        {
            base.id = ID;
            base.InitData(this);
            base.CurrentModel = this;
        }
        protected override EbSite.Base.BLL.BllBase<TypeRelationProduct, int> Bll()
        {
            
                return BLL.TypeRelationProduct.Instance;
            
        }
        #region Model
        private string _attributeId;
        private int? _usageMode;

        private long _productid;
        private int? _item;
        /// <summary>
        /// 属性ID
        /// </summary>
        public string AttributeId
        {
            set { _attributeId = value; }
            get { return _attributeId; }
        }
        /// <summary>
        /// 1:多选   0:单选 
        /// </summary>
        public int? UsageMode
        {
            set { _usageMode = value; }
            get { return _usageMode; }
        }

        /// <summary>
        /// 
        /// </summary>
        public long ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 属性values 
        /// </summary>
        public int? Item
        {
            set { _item = value; }
            get { return _item; }
        }
        #endregion Model
        /// <summary>
        /// 属性 名称
        /// </summary>
        public string SXName
        {
            get
            {
                ModuleCore.Entity.TypeNameValue md = ModuleCore.BLL.TypeNameValue.Instance.GetEntity(EbSite.Core.Utils.StrToInt(AttributeId, 0));
                if (!Equals(md, null))
                {
                    return md.ValueName;
                }
                return "";
            }
        }
        /// <summary>
        /// 属性的value
        /// </summary>
        public string SXValues
        {
            get
            {
                string str = "";
                if (Item>0)
                {
                    if (UsageMode==1) //多选
                    {
                        List<Entity.TypeRelationProduct> ls =ModuleCore.BLL.TypeRelationProduct.Instance.GetListArrayCache(0, string.Concat("ProductID= ", ProductID, " and AttributeId=",AttributeId), "");

                        if(ls.Count>0)
                        {
                            foreach (var typeRelationProduct in ls)
                            {
                                ModuleCore.Entity.TypeNameValues tnvMd= ModuleCore.BLL.TypeNameValues.Instance.GetEntity(int.Parse(typeRelationProduct.Item.ToString()));
                                if(tnvMd!=null)
                                {
                                    str += tnvMd.TValues + " ";
                                }
                            }
                        }
                    }
                    else
                    {
                        ModuleCore.Entity.TypeNameValues tnvMd =ModuleCore.BLL.TypeNameValues.Instance.GetEntity(int.Parse(Item.ToString()));
                        if (tnvMd != null)
                        {
                            str = tnvMd.TValues + " ";
                        }
                    }
                   
                    
                }
                return str;
            }
        }

    }
}

