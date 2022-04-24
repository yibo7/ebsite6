using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using EbSite.Base.Page;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mproductphotobox : BasePageM
    {

       // protected global::System.Web.UI.WebControls.Label LbCName;

        //protected global::System.Web.UI.WebControls.Label LbTName;

        protected global::System.Web.UI.WebControls.Repeater rpListProductPic;

        protected  int ProductID
        {
            get
            {
                return EbSite.Core.Utils.StrToInt(Request.QueryString["pid"], 0);
            }
        }

        protected int iPicCount;
     //   protected string cname;
        protected EbSite.Entity.NewsContent model;
     //   protected string tname;
       // protected int id;
        protected void Page_Load(object sender, EventArgs e)
        {


            EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModel(ProductID,GetSiteID);
            //tname = md.NewsTitle;
            //cid = md.ClassID;
            model = md;

            //EbSite.Entity.NewsClass mdc = EbSite.BLL.NewsClass.GetModel(md.ClassID);
            //cname = mdc.ClassName;

            List<ModuleCore.Entity.ProductsImg> lsit=ModuleCore.BLL.ProductsImg.Instance.GetListArrayCache(0,"productid="+ProductID,"");
            rpListProductPic.DataSource = lsit;
            iPicCount = lsit.Count;
            rpListProductPic.DataBind();

            //id = ProductID;
            Page.Title = md.NewsTitle+"图片";
        }



        #region 解决重写url后，保持postback地址不改变的问题

        //// <summary>
        ///  重写默认的HtmlTextWriter方法，修改form标记中的value属性，使其值为重写的URL而不是真实URL。
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (writer is System.Web.UI.Html32TextWriter)
            {
                writer = new FormFixerHtml32TextWriter(writer.InnerWriter);
            }
            else
            {
                writer = new FormFixerHtmlTextWriter(writer.InnerWriter);
            }

            base.Render(writer);
        }
        #endregion
    }
}