using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage; 
using EbSite.Entity;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.ExtContent
{
    public partial class ProductImg : ContentExtBase
    {
        override public int OrderID
        {
            get
            {
                return 3;
            }
        }
        /// <summary>
        /// 相关表 ProductsImg
        /// </summary>
        override public string PageName
        {
            get
            {
                return "商品图片";
            }
        }
        /// <summary>
        /// 页面载入时执行,如果dataid大于0，说明是修改，如果dataid=0说明是新添加
        /// </summary>
        /// <param name="dataid"></param>
        public override void DataInit(Entity.NewsContent mdContent, Entity.NewsClass mdClass)
        {
            if (!Equals(mdContent, null) && mdContent.ID > 0)
            {
                List<ModuleCore.Entity.ProductsImg> ls = ModuleCore.BLL.ProductsImg.Instance.GetListByProductID(mdContent.ID);
                List<UploadFileInfo> ValueItems = new List<UploadFileInfo>();

                foreach (ModuleCore.Entity.ProductsImg uploadFileInfo in ls)
                {
                    UploadFileInfo md = new UploadFileInfo();
                    md.FileNewName = uploadFileInfo.BigImg;
                    md.FileOldName = uploadFileInfo.Title;
                    ValueItems.Add(md);
                }
                GoodsImgs.ValueItems = ValueItems;

                //EbSite.Entity.NewsContent mdContent = EbSite.BLL.NewsContent.GetModel(dataid);
                imgsmallimg.Src = mdContent.SmallPic;
                hiSmallimg.Value = mdContent.SmallPic;
            }
            else
            {
                imgsmallimg.Src = string.Concat(EbSite.Base.Host.Instance.IISPath, "images/nopic.gif");
            }
        }
        /// <summary>
        /// 当内容页面更新内容时触发
        /// </summary>
        /// <param name="dataid"></param>
        public override void Update(Entity.NewsContent mdContent)
        {
            // 先删除
            List<ModuleCore.Entity.ProductsImg> ls = ModuleCore.BLL.ProductsImg.Instance.GetListArray("ProductID=" + mdContent.ID);
            foreach (var productsImg in ls)
            {
                ModuleCore.BLL.ProductsImg.Instance.Delete(productsImg.id);
            }
            //再添加
            AddC(GoodsImgs.ValueItems, mdContent.ID);

            UpdataSmallImg(mdContent.ID);

        }
        private void UpdataSmallImg(long dataid)
        {
            EbSite.Entity.NewsContent mdContent =EbSite.Base.AppStartInit.NewsContentInstDefault.GetModel(dataid,GetSiteID);
            mdContent.SmallPic = hiSmallimg.Value;
            Base.AppStartInit.NewsContentInstDefault.Update(mdContent);
        }
        /// <summary>
        /// 当内容页面添加内容时触发
        /// </summary>
        /// <param name="dataid"></param>
        public override void Add(Entity.NewsContent mdContent)
        {
            AddC(GoodsImgs.ValueItems, mdContent.ID);
            UpdataSmallImg(mdContent.ID);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddC(List< UploadFileInfo> ValueItems, long dataid)
        {
            foreach (var uploadFileInfo in ValueItems)
            {
                ModuleCore.Entity.ProductsImg md = new ProductsImg();
                md.ProductID = dataid;
                md.BigImg = uploadFileInfo.FileNewName;
                md.Title = uploadFileInfo.FileOldName;
                ModuleCore.BLL.ProductsImg.Instance.Add(md);
            }
        }
    }
}