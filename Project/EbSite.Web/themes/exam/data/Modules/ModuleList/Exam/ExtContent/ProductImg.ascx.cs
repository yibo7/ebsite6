using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Modules.SiteTools.ExtContent
{
    public partial class ProductImg : ContentExtBase
    {
        /// <summary>
        /// 页面名称，将显示在tab里
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
        public override void DataInit(int dataid)
        {
            
        }
        /// <summary>
        /// 当内容页面更新内容时触发
        /// </summary>
        /// <param name="dataid"></param>
        public override void Update(int dataid)
        {
            
        }
        /// <summary>
        /// 当内容页面添加内容时触发
        /// </summary>
        /// <param name="dataid"></param>
        public override void Add(int dataid)
        {
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}