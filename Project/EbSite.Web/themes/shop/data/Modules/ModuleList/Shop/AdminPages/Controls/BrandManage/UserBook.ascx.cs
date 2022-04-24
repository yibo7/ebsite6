using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using System.Xml;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.BrandManage
{
    public partial class UserBook : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "使用指南";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("0c5d8d33-a774-4f05-98ab-266e5573f8fd");
            }
        }

        override protected object LoadList(out int iCount)
        {

           

            iCount = 0;
            return null;
        }

        override protected object SearchList(out int iCount)
        {

            iCount = 0;
            return null;

        }

        override protected void Delete(object iID)
        {

        }

       
        protected string GetTitle
        {
            get { return Request["title"]; }
        }
        private int InationID
        {
            get
            {
                
                return EbSite.Core.Utils.StrToInt( Request["iid"],0);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        private void Bind()
        {
            if (InationID > 0)
            {
                List<ModuleCore.Entity.P_UserBook> ls =
                    ModuleCore.BLL.P_UserBook.Instance.GetListArray(string.Format("productid={0}", InationID));
                if (ls != null && ls.Count > 0)
                {
                    this.DataList.DataSource = ls;
                    this.DataList.DataBind();
                }
            }
        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            EditData(InationID);
        }
        //EB_P_UserBook
       
       
        ///// <summary>
        ///// 当内容页面更新内容时触发
        ///// </summary>
        ///// <param name="dataid"></param>
        //public override void Update(Entity.NewsContent mdContent)
        //{
        //    EditData(mdContent.ID);
        //}
        ///// <summary>
        ///// 当内容页面添加内容时触发
        ///// </summary>
        ///// <param name="dataid"></param>
        //public override void Add(Entity.NewsContent mdContent)
        //{
        //    EditData(mdContent.ID);
        //}

        private void EditData(int productID)
        {
            string strXml = this.hidXml.Value;
            if (!string.IsNullOrEmpty(strXml))
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(strXml);
                XmlNodeList itemList = xml.SelectNodes("items/item");
                if (itemList != null && itemList.Count > 0)
                {
                    foreach (XmlNode xn in itemList)
                    {
                        string strFlag = GetXmlNodeAttr(xn, "flag").ToLower();
                        if (strFlag.Equals("u"))
                        {
                            //修改
                            string strID = GetXmlNodeAttr(xn, "rid");
                            ModuleCore.Entity.P_UserBook md = new ModuleCore.Entity.P_UserBook();
                            md.id = Core.Utils.StrToInt(strID);
                            md.Title = GetXmlNodeAttr(xn, "title");
                            md.Url = GetXmlNodeAttr(xn, "url");
                            md.ProductID = productID;
                            md.OrderID = 1;
                            ModuleCore.BLL.P_UserBook.Instance.Update(md);
                        }
                        else if (strFlag.Equals("a"))
                        {
                            //添加
                            ModuleCore.Entity.P_UserBook md = new ModuleCore.Entity.P_UserBook();
                            md.Title = GetXmlNodeAttr(xn, "title");
                            md.Url = GetXmlNodeAttr(xn, "url");
                            md.ProductID = productID;
                            md.OrderID = 0;
                            ModuleCore.BLL.P_UserBook.Instance.Add(md);
                        }
                    }
                }
            }
            Bind();
        }
        private string GetXmlNodeAttr(XmlNode xn, string attrName)
        {
            if (xn != null && xn.Attributes[attrName] != null)
            {
                return xn.Attributes[attrName].Value;
            }
            return "";
        }
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}
        //public override string OnClientClick
        //{
        //    get
        //    {
        //        return "CreateXml()";
        //    }
        //}
    }
}