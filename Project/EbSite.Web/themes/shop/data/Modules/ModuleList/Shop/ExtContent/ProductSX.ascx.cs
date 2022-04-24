using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using EbSite.Base.ControlPage;
using EbSite.Entity;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.ExtContent
{
    public partial class ProductSX : ContentExtBase
    {
        override public int OrderID
        {
            get
            {
                return 2;
            }
        }
        /// <summary>
        /// 相关表 TypeNameValue,TypeRelationProduct
        /// </summary>
        override public string PageName
        {
            get
            {
                return "扩展属性";
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
            {
                string strJson = "";
                List<ModuleCore.Entity.TypeRelationProduct> ls = ModuleCore.BLL.TypeRelationProduct.Instance.
                    GetListArray(
                        0, "ProductID=" + mdContent.ID, "");

                var q = ( from c in ls select c.AttributeId) .Distinct();//先过滤重复 得到商品类型对应的 属性ID
               
                if(q.Count()>0)
                {
                    SID = q.Count();
                    DataId = mdContent.ID;
                    strJson += "[";
                    foreach (var x in q) //遍历属性
                    {
                        List<ModuleCore.Entity.TypeRelationProduct> nls =
                            (from i in ls where i.AttributeId == x select i).ToList(); //得到属性 对应的值。

                        strJson += "{\"attributeId\":\"" + nls[0].AttributeId + "\",";
                        strJson += "\"usageMode\":\"" + nls[0].UsageMode + "\",";
                        strJson += "\"item\":[";
                        foreach (var typeRelationProduct in nls)           //多选这里可以合并前台 所需要的样式
                        {
                            // STemp += string.Format(temp, cellFild, md.NormsName);
                            strJson += "{\"valueId\":\"" + typeRelationProduct.Item + "\"";
                            strJson += "},";
                        }
                        
                        if (nls.Count > 0)
                        {
                            strJson = strJson.Remove(strJson.Length - 1, 1);
                        }
                        strJson += "]},";
                    }
                    strJson = strJson.Remove(strJson.Length - 1, 1);
                    strJson += "]";
                    ctl00_contentHolder_txtAttributes.Value = strJson; //content;

                }
                #region 旧版
                //if (ls.Count > 0)
                //{
                //    SID = ls.Count;
                //    DataId = mdContent.ID;
                //    strJson += "[";
                //    foreach (ModuleCore.Entity.TypeRelationProduct i in ls)
                //    {
                //        strJson += "{\"attributeId\":\"" + i.AttributeId + "\",";
                //        strJson += "\"usageMode\":\"" + i.UsageMode + "\",";
                //        strJson += "\"item\":[";

                //        string[] ary = i.Item.Split(new char[1] { '|' });

                //        for (int j = 0; j < ary.Length; j++)
                //        {

                //            // STemp += string.Format(temp, cellFild, md.NormsName);
                //            strJson += "{\"valueId\":\"" + ary[j] + "\"";
                //            strJson += "},";

                //        }
                //        if (ary.Length > 0)
                //        {
                //            strJson = strJson.Remove(strJson.Length - 1, 1);
                //        }
                //        strJson += "]},";
                //    }
                //    strJson = strJson.Remove(strJson.Length - 1, 1);
                //    strJson += "]";
                //    ctl00_contentHolder_txtAttributes.Value = strJson; //content;
                //}
                #endregion
            }
        }
        /// <summary>
        /// 当内容页面更新内容时触发
        /// </summary>
        /// <param name="dataid"></param>
        public override void Update(Entity.NewsContent mdContent)
        {
            //先删除 
            List<ModuleCore.Entity.TypeRelationProduct> ls = ModuleCore.BLL.TypeRelationProduct.Instance.GetListArray(
                0, "ProductID=" + mdContent.ID, "");
            foreach (var i in ls)
            {
                ModuleCore.BLL.TypeRelationProduct.Instance.Delete(i.id);
            }
            //再添加
            Add(mdContent);
        }
        /// <summary>
        /// 当内容页面添加内容时触发
        /// </summary>
        /// <param name="dataid"></param>
        public override void Add(Entity.NewsContent mdContent)
        {

            string content = this.ctl00_contentHolder_txtAttributes.Value;

            if (!string.IsNullOrEmpty(content))
            {
                AddNorm(content, mdContent.ID);
            }
        }
        protected void AddNorm(string content, long dataid)
        {
            if (!string.IsNullOrEmpty(content))
            {
                ModuleCore.Entity.TypeRelationProduct md = new TypeRelationProduct();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(content);
                XmlNodeList xnl = xmlDoc.SelectSingleNode("xml/attributes").ChildNodes;
                foreach (XmlNode xn in xnl)
                {
                    XmlElement xe = (XmlElement)xn;
                    string byAttri = xe.GetAttribute("attributeId");
                    string byModel = xe.GetAttribute("usageMode");
                    md.AttributeId = byAttri;
                    md.UsageMode = Convert.ToInt32(byModel);
                    string valueId = "";
                    XmlNodeList xel = xe.ChildNodes;
                    string istm = "";
                    #region
                    //foreach (XmlNode xn1 in xel) //遍历 
                    //{
                    //    XmlElement xe2 = (XmlElement)xn1; //转换类型
                    //    valueId = xe2.GetAttribute("valueId");
                    //    istm += valueId + "|";
                    //}
                    //if (istm.Length > 0)
                    //{
                    //    istm = istm.Remove(istm.Length - 1, 1);
                    //}
                    //md.Item = istm;
                    //md.ProductID = dataid; 
                    //ModuleCore.BLL.TypeRelationProduct.Instance.Add(md);
                    #endregion

                    foreach (XmlNode xn1 in xel) //遍历 
                    {
                        XmlElement xe2 = (XmlElement)xn1; //转换类型
                        valueId = xe2.GetAttribute("valueId");

                        md.Item =Core.Utils.StrToInt(valueId,0);
                        md.ProductID = dataid;
                        ModuleCore.BLL.TypeRelationProduct.Instance.Add(md);
                    }


                }

                //yhl 2013-08-08 修改或 添加后 还停留在此页面，此时 属性上 都没有选上。或 在修改其他地方时，属性就清空了。

                Entity.NewsContent mdContent = new NewsContent();
                mdContent.ID = dataid;
                DataInit( mdContent, new NewsClass());
                
                //this.ctl00_contentHolder_txtAttributes.Value = "";

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

    }

    public class Person
    {
        public int attributeId { set; get; }
        public int usageMode { set; get; }
        public List<item> item { set; get; }
    }
    public class item
    {
        public int valueId { get; set; }
    }
}