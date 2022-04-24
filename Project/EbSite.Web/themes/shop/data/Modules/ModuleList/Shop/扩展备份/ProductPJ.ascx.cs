using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.ExtContent
{
    public partial class ProductPJ : ContentExtBase
    {
        /// <summary>
        /// 相关表 ProductParts
        /// </summary>
        override public string PageName
        {
            get
            {
                return "推荐配件";
            }
        }
        /// <param name="dataid"></param>
        public override void DataInit(Entity.NewsContent mdContent, Entity.NewsClass mdClass)
        {

        }
        /// <summary>
        /// 当内容页面更新内容时触发
        /// </summary>
        /// <param name="dataid"></param>
        public override void Update(Entity.NewsContent mdContent)
        {
            // 先删除
            List<ModuleCore.Entity.P_BestGroup> ls = ModuleCore.BLL.P_BestGroup.Instance.GetListArray("TypeID=2 and ProductID=" + mdContent.ID);
            foreach (var productsImg in ls)
            {
                ModuleCore.BLL.P_BestGroup.Instance.Delete(productsImg.id);
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
            List<InfoProduct> ls = this.BestParts.ProductInfo;
            if (ls.Count > 0)
            {
                foreach (var infoProduct in ls)
                {
                    ModuleCore.Entity.P_BestGroup md = new P_BestGroup();
                    md.ProductID = mdContent.ID;
                    md.GoodsID = infoProduct.ID;
                    md.GoodsAvatarSmall = infoProduct.PicUrl;
                    md.GoodsName = infoProduct.Title;
                    md.OrderiD = 1;
                    md.TypeID = 2;

                    md.Add();
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}