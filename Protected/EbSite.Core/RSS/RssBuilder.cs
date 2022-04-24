using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;

namespace EbSite.Core.RSS
{
    public class RssBuilder
    {
        XmlDocument rssDoc;
 
        public RssChannel channel;
        public RssBuilder()
        {
            rssDoc = new XmlDocument();
            rssDoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><rss version=\"2.0\"><channel></channel></rss>");
            channel = new RssChannel();
        }
        /// <summary>
        /// 创建生成RSS--反射实体创建xml元素。
        /// </summary>
        private void BuildRss()
        {
            XmlNode cNode = rssDoc.DocumentElement.ChildNodes[0];//取得channel元素
            ForeachCreateChild(cNode, channel);//Channel处理
            if (channel.RssImage != null)
            {
                ForeachCreateChild(Create("image", null, cNode), channel.RssImage);//Channel-Image处理
            }
            if (channel.Items.Count > 0)
            {
                foreach (RssItem item in channel.Items)
                {
                    ForeachCreateChild(Create("item", null, cNode), item);//Channel-Items处理
                }
            }
        }
        /// <summary>
        /// 创建节点元素
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private XmlNode Create(string name, string value, XmlNode parent)
        {
            XmlElement xNode = rssDoc.CreateElement(name);
            if (!string.IsNullOrEmpty(value))
            {
                xNode.InnerXml = Utils.HtmlEncode(value);
            }
            parent.AppendChild(xNode as XmlNode);
            return xNode as XmlNode;
        }
        /// <summary>
        /// 反射循环创建子节点
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="obj"></param>
        private void ForeachCreateChild(XmlNode parent, object obj)
        {
            object propValue = null;
            PropertyInfo[] pis = obj.GetType().GetProperties();
            for (int i = 0; i < pis.Length; i++)
            {
                if (pis[i].Name == "Items" || pis[i].Name == "Image")
                {
                    continue;
                }
                propValue = pis[i].GetValue(obj, null);
                if (propValue == null || propValue == DBNull.Value)
                {
                    continue;
                }
                if (pis[i].Name == "Description")
                {
                    propValue = "<![CDATA[" + Utils.HtmlEncode(propValue.ToString()) + "]]>";//是不是要Encode一下~

                }
                Create(pis[i].Name.Substring(0, 1).ToLower() + pis[i].Name.Substring(1), propValue.ToString(), parent);
            }
        }
        /// <summary>
        /// 输出RSS
        /// </summary>
        public string OutXml
        {
            get
            {
                BuildRss();
                return rssDoc.OuterXml;
            }
        }

    }
}
