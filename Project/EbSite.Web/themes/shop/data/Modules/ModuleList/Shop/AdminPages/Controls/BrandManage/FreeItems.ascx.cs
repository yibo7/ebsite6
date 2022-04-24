using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.AdminPages.Controls.BrandManage
{
    /// <summary>
    /// ProductOptions,ProductOptionItems,ProductOptionValue
    /// </summary>
    public partial class FreeItems : MPUCBaseList
    {
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
                return new Guid("ad96751e-8010-42f7-b2e4-4f30d10583fb");
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

                return EbSite.Core.Utils.StrToInt(Request["iid"], 0);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (InationID > 0)
            {
                FreeSID = InationID;
            }
        }
       
        //EB_P_RecommedParts
        public override string PageName
        {
            get
            {
                return "商品费用选项";
            }
        }
        public int FreeSID = 0;
        ///// <param name="dataid"></param>
        //public override void DataInit(Entity.NewsContent mdContent, Entity.NewsClass mdClass)
        //{

        //    if (!Equals(mdContent, null) && mdContent.ID > 0)
        //        FreeSID = mdContent.ID;
        //}
        ///// <summary>
        ///// 当内容页面更新内容时触发
        ///// </summary>
        ///// <param name="dataid"></param>
        //public override void Update(Entity.NewsContent mdContent)
        //{
           
        //}
        ///// <summary>
        ///// 当内容页面添加内容时触发
        ///// </summary>
        ///// <param name="dataid"></param>
        //public override void Add(Entity.NewsContent mdContent)
        //{
           
        //}

       
      
    }
}