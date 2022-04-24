
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.BLL.User;

namespace EbSite.Base.Page
{
    public class CustomPage : BasePage
    {
        
        /// <summary>
        /// LOAD事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomPage_Load(object sender, EventArgs e)
        {
            if (!Page.IsCallback)
            {
                
            }
        }

        virtual protected void MobileMeta()
        {

        }

        /// <summary>
        /// LOAD事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomPage_LoadComplete(object sender, EventArgs e)
        {
            MobileMeta();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomPage()
        {
            this.Load += new EventHandler(CustomPage_Load);
            this.LoadComplete += new EventHandler(CustomPage_LoadComplete);
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
