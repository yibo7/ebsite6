using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Entity;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mcompare : BasePageM
    {
        protected global::System.Web.UI.WebControls.Repeater rpListAttribute;

        protected EbSite.Entity.NewsContent Model1 = new NewsContent();
        protected EbSite.Entity.NewsContent Model2 = new NewsContent();
        protected EbSite.Entity.NewsContent Model3 = new NewsContent();
        protected EbSite.Entity.NewsContent Model4 = new NewsContent();

        /// <summary>
        /// 要对比的产品ID 把第一个作为标准
        /// </summary>
        public string ProductIDs
        {
            get
            {
                //t=0,0,0,0
                string ids = Request.QueryString["t"];
                return ids;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<AttributeValue> ls = new List<AttributeValue>();
            string[] ArryIds = EbSite.Core.Strings.GetString.SplitString(ProductIDs, ",");
            Model1 = Base.AppStartInit.NewsContentInstDefault.GetModel(EbSite.Core.Utils.StrToInt(ArryIds[0], 0),GetSiteID);
            Model2 = Base.AppStartInit.NewsContentInstDefault.GetModel(EbSite.Core.Utils.StrToInt(ArryIds[1], 0),GetSiteID);
            Model3 = Base.AppStartInit.NewsContentInstDefault.GetModel(EbSite.Core.Utils.StrToInt(ArryIds[2], 0),GetSiteID);
            Model4 = Base.AppStartInit.NewsContentInstDefault.GetModel(EbSite.Core.Utils.StrToInt(ArryIds[3], 0),GetSiteID);


            int id = EbSite.Core.Utils.StrToInt(ArryIds[0], 0);
            List<ModuleCore.Entity.TypeNameValue> AttributeNames = GetAttributeList(id);
            for (int i = 0; i < AttributeNames.Count; i++)
            {
                AttributeValue mdvalue = new AttributeValue();
                mdvalue.AttributeName = AttributeNames[i].ValueName;
                mdvalue.id = i;
                mdvalue.AttributeID = AttributeNames[i].id;

                int p_id1 = EbSite.Core.Utils.StrToInt(ArryIds[0], 0);
                int p_id2 = EbSite.Core.Utils.StrToInt(ArryIds[1], 0);
                int p_id3 = EbSite.Core.Utils.StrToInt(ArryIds[2], 0);
                int p_id4 = EbSite.Core.Utils.StrToInt(ArryIds[3], 0);
                if (p_id1 > 0)
                {
                    mdvalue.AttributeValue1 = SXValues(p_id1, mdvalue.AttributeID);
                }

                if (p_id2 > 0)
                {
                    mdvalue.AttributeValue2 = SXValues(p_id2, mdvalue.AttributeID);
                }

                if (p_id3 > 0)
                {
                    mdvalue.AttributeValue3 = SXValues(p_id3, mdvalue.AttributeID);
                }

                if (p_id4 > 0)
                {
                    mdvalue.AttributeValue4 = SXValues(p_id4, mdvalue.AttributeID);
                }

                ls.Add(mdvalue);

            }

            rpListAttribute.DataSource = ls;
            rpListAttribute.DataBind();
        }

        public string SXValues(int ProductID, int AttributeId)
        {
            string str = "";

            List<Entity.TypeRelationProduct> ls =
                ModuleCore.BLL.TypeRelationProduct.Instance.GetListArrayCache(0, string.Concat("ProductID= ", ProductID, " and AttributeId=", AttributeId), "");

            if (ls.Count > 0)
            {
                foreach (var typeRelationProduct in ls)
                {
                    ModuleCore.Entity.TypeNameValues md = ModuleCore.BLL.TypeNameValues.Instance.GetEntity(int.Parse(typeRelationProduct.Item.ToString()));
                    if (!Equals(md, null))
                    {
                        str += md.TValues + " ";
                    }
                }
            }
            if (string.IsNullOrEmpty(str))
                return "-";
            return str;

        }

        //得到属性
        protected List<ModuleCore.Entity.TypeNameValue> GetAttributeList(int productid)
        {
            List<ModuleCore.Entity.TypeNameValue> slt = new List<Entity.TypeNameValue>();
            EbSite.Entity.NewsContent model = Base.AppStartInit.NewsContentInstDefault.GetModelByFiledOfDefault("classid", "id=" + productid);
            if (!Equals(model, null))
            {
                //annex8 商品类型
                EbSite.Entity.NewsClass modelclass = EbSite.BLL.NewsClass.GetModel("annex8", "id=" + model.ClassID);
                if (!Equals(modelclass, null))
                {
                    //通过商品类型 查出商品属性
                    List<ModuleCore.Entity.TypeNameValue> AttributeNames = ModuleCore.BLL.TypeNameValue.Instance.GetListArray("TypeNameID=" + modelclass.Annex8);
                    slt = AttributeNames;
                }
            }
            return slt;
        }
    }
    public class AttributeValue
    {
        public int id { get; set; }
        public int AttributeID { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string AttributeName { get; set; }
        public string AttributeValue1 { get; set; }
        public string AttributeValue2 { get; set; }
        public string AttributeValue3 { get; set; }
        public string AttributeValue4 { get; set; }

    }
}