using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using EbSite.Base.ControlPage;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.ExtContent
{
    /// <summary>
    /// 相关表 Norms,NormsValue,NormRelationProduct
    /// </summary>
    public partial class ProductGG : ContentExtBase
    {
        override public int OrderID
        {
            get
            {
                return 1;
            }
        }
        /// <summary>
        /// 页面名称，将显示在tab里
        /// </summary>
        override public string PageName
        {
            get
            {
                return "商品规格";
            }
        }
        public int SID = 0;
        public long DataId = 0;
        /// <summary>
        /// 页面载入时执行,如果dataid大于0，说明是修改，如果dataid=0说明是新添加
        /// </summary>
        /// <param name="dataid"></param>
        public override void DataInit(Entity.NewsContent mdContent, Entity.NewsClass mdClass)
        {
            if (!Equals(mdContent, null) && mdContent.ID > 0)
                ctl00_contentHolder_txtSkus.Value = JsonBind(mdContent.ID);
        }
        public string JsonBind(long dataid)
        {

            string strJson = "";
            List<ModuleCore.Entity.NormRelationProduct> ls = ModuleCore.BLL.NormRelationProduct.Instance.GetListArray(
                0, "ProductID=" + dataid, "");
            if (ls.Count > 0)
            {
                SID = ls.Count;
                DataId = dataid;
                strJson += "[";
                foreach (ModuleCore.Entity.NormRelationProduct i in ls)
                {
                    strJson += "{\"skuCode\":\"" + i.PNumber + "\",";
                    strJson += "\"salePrice\":\"" + i.SalePrice + "\",";
                    strJson += "\"costPrice\":\"" + i.CostPrice + "\",";
                    strJson += "\"qty\":\"" + i.Stocks + "\",";
                    strJson += "\"weight\":\"" + i.Weight + "\",";
                    // string[] ary = i.NormsValues.Split(new char[4] { '#', '-', '-', '#' });
                    string[] aryAll = i.NormsValues.Split('_');
                    if (!string.IsNullOrEmpty(aryAll[1]))
                    {
                        //string[] ary = aryAll[1].Split(new char[2] {'-', '-'});
                        string[] ary = Core.Strings.GetString.SplitString(aryAll[1], "--");
                        strJson += "\"skuFields\":[ ";
                        for (int j = 0; j < ary.Length; j++)
                        {
                            string[] arry2 = ary[j].Split('-');
                            string cellFild = arry2[0];

                            // STemp += string.Format(temp, cellFild, md.NormsName);
                            strJson += "{\"attributeId\":\"" + cellFild + "\",";
                            strJson += "\"valueId\":\"" + arry2[1] + "\"";
                            strJson += "},";

                        }
                        strJson = strJson.Remove(strJson.Length - 1, 1);

                        strJson += "]},";
                    }

                }
                strJson = strJson.Remove(strJson.Length - 1, 1);

                strJson += "]";
            }
            return strJson;
        }
        /// <summary>
        /// 当内容页面更新内容时触发
        /// </summary>
        /// <param name="dataid"></param>
        public override void Update(Entity.NewsContent mdContent)
        {
            //  Label1.Text = "更新了";
            //先删除 
            List<ModuleCore.Entity.NormRelationProduct> ls = ModuleCore.BLL.NormRelationProduct.Instance.GetListArray(
                0, "ProductID=" + mdContent.ID, "");

            //更新 Annex21


            mdContent.Annex22 = 0;//不开启规格 
            Base.AppStartInit.NewsContentInstDefault.Update(mdContent);

            foreach (var i in ls)
            {
                ModuleCore.BLL.NormRelationProduct.Instance.Delete(i.id);
            }
            //再添加
            GgAdd(mdContent);

            ctl00_contentHolder_txtSkus.Value = JsonBind(mdContent.ID);
        }

        public List<SkuInfo> lsNorms = new List<SkuInfo>();

        private void xmlAdd(string content, Entity.NewsContent mdContent)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(content);
            XmlNodeList xnl = xmlDoc.SelectSingleNode("xml/productSkus").ChildNodes;
            foreach (XmlNode xn in xnl)
            {
                XmlElement xe = (XmlElement)xn;
                string code = xe.GetAttribute("skuCode");
                string salePrice = xe.GetAttribute("salePrice");
                string costPrice = xe.GetAttribute("costPrice");
                string qty = xe.GetAttribute("qty");
                string weight = xe.GetAttribute("weight");
                string valueId = "";

                string values = mdContent.ID + "_";
                string pid = "";
                XmlNodeList xel = xe.ChildNodes;
                foreach (XmlNode xn1 in xel) //遍历 
                {
                    XmlElement xe2 = (XmlElement)xn1; //转换类型 
                    XmlNodeList xe2l = xe2.ChildNodes;
                    foreach (XmlNode xn2 in xe2l)
                    {
                        XmlElement xe3 = (XmlElement)xn2;
                        valueId = xe3.GetAttribute("valueId");
                        pid = xe3.GetAttribute("attributeId");

                        //ModuleCore.Entity.NormsValue md =
                        //    ModuleCore.BLL.NormsValue.Instance.GetEntity(Core.Utils.StrToInt(valueId, 0));
                        values += pid + "-" + valueId + "--";
                    }
                    if (values.Length > 0)
                        values = values.Remove(values.Length - 2, 2);
                    //id#-#规格名称或图标#--#id#-#规格名称或图标
                    // textBox1.Text += code + "," + salePrice + "," + costPrice + "," + qty + "," + weight + "," + valueId + "|";
                    AddNorm(code, qty, salePrice, costPrice, weight, mdContent.ID, values);

                }

            }

            if (lsNorms.Count > 0)
            {
                SkuInfo mx = (from i in lsNorms orderby i.SalePrice ascending select i).ToList()[0];
                //EbSite.Entity.NewsContent model = EbSite.BLL.NewsContent.GetModel(dataid);
                mdContent.Annex16 = mx.SalePrice;//销售价
                mdContent.Annex5 = mx.StrInfo;//规格key
                mdContent.Annex1 = mx.PNumber; //商品编号
                //mdContent.Annex2 = mx.MarketPrice.ToString(); //市场价格,规格暂时不启用此字段
                mdContent.Annex17 = mx.CostPrice;// 成本价格
                mdContent.Annex18 = mx.Weight;// 商品重量
                mdContent.Annex12 = mx.Stocks;// 库存量

                mdContent.Annex22 = 1;//开启规格 
                Base.AppStartInit.NewsContentInstDefault.Update(mdContent);
            }
        }

        private void GgAdd(Entity.NewsContent mdContent)
        {
            string content = this.ctl00_contentHolder_txtSkus.Value;
            if (!string.IsNullOrEmpty(content) && content != "<xml><productSkus></productSkus></xml>")
            {
                xmlAdd(content, mdContent);
            }
            else
            {

                #region yhl 2013-09-9 没有开启规格 开启规格的日志 在数据层 NormRelationProduct中
                ModuleCore.Entity.productlog mProductlog = new productlog();
                mProductlog.ProductId = mdContent.ID;
                mProductlog.PNumber = mdContent.Annex1;//商品编号
                mProductlog.UserID = EbSite.Base.Host.Instance.UserID;
                mProductlog.UserName = EbSite.Base.Host.Instance.UserName;
                mProductlog.AddDate = DateTime.Now;
                mProductlog.Content = string.Concat("于", DateTime.Now, EbSite.Base.Host.Instance.UserName, "【修改】 ", mdContent.Annex12);
                mProductlog.Number = mdContent.Annex12;
                ModuleCore.BLL.productlog.Instance.Add(mProductlog);

                #endregion
            }

        }
        /// <summary>
        /// 当内容页面添加内容时触发
        /// </summary>
        /// <param name="dataid"></param>
        public override void Add(Entity.NewsContent mdContent)
        {

            string content = this.ctl00_contentHolder_txtSkus.Value;
            if (!string.IsNullOrEmpty(content) && content != "<xml><productSkus></productSkus></xml>")
            {
                xmlAdd(content, mdContent);
            }
            else
            {
                #region yhl 2013-09-9 没有开启规格 开启规格的日志 在数据层 NormRelationProduct中
                ModuleCore.Entity.productlog mProductlog = new productlog();
                mProductlog.ProductId = mdContent.ID;
                mProductlog.PNumber = mdContent.Annex1;//商品编号
                mProductlog.UserID = EbSite.Base.Host.Instance.UserID;
                mProductlog.UserName = EbSite.Base.Host.Instance.UserName;
                mProductlog.AddDate = DateTime.Now;
                mProductlog.Content = string.Concat("于", DateTime.Now, EbSite.Base.Host.Instance.UserName, "【入库】", mdContent.Annex12);
                mProductlog.Number = mdContent.Annex12;
                ModuleCore.BLL.productlog.Instance.Add(mProductlog);

                #endregion
            }

        }
        //a.[PNumber]货号(string 30)
        //        b.[Stocks]库存(int)
        //        c.[SalePrice]销售价(decimal)
        //        e.[CostPrice]成本价(decimal)
        //        f.[MarketPrice]市场价(decimal)
        //        g.[Weight]重量(decimal)
        //        i.[ProductID]商品ID(int)
        //        j.[NormsValues]规格名称集合，用逗号分开（通过多个属性值交叉计算,所以这里显示多个属性名称,格式为 id#-#规格名称或图标#--#id#-#规格名称或图标）(string 300)

        protected void AddNorm(string PNumber, string Stocks, string SalePrice, string CostPrice, string Weight, long ProductID, string NormsValues)
        {
            ModuleCore.Entity.NormRelationProduct md = new NormRelationProduct();
            md.PNumber = PNumber;
            md.Stocks = Core.Utils.StrToInt(Stocks, 0);
            md.SalePrice = Convert.ToDecimal(SalePrice);
            md.CostPrice = Convert.ToDecimal(CostPrice);
            md.Weight = Convert.ToDecimal(Weight);
            md.ProductID = ProductID;
            md.NormsValues = NormsValues;
            ModuleCore.BLL.NormRelationProduct.Instance.Add(md);

            //存到 集合中 ，查销售价最小值 
            SkuInfo mx = new SkuInfo();
            mx.PNumber = md.PNumber;
            mx.SalePrice = Convert.ToDecimal(SalePrice);
            mx.StrInfo = NormsValues;
            mx.CostPrice = md.CostPrice;
            mx.MarketPrice = md.MarketPrice;
            mx.Stocks = md.Stocks;
            mx.Weight = md.Weight;

            lsNorms.Add(mx);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        public override string OnClientClick
        {
            get
            {
                return "doCheck()";
            }
        }
    }
    public class SkuInfo
    {
        public string PNumber { get; set; }
        public decimal SalePrice { get; set; }
        public string StrInfo { get; set; }
        public int Stocks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal CostPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal MarketPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Weight { get; set; }
    }
}