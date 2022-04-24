using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.ModelBinding; 
using EbSite.Base;
using EbSite.Base.DataProfile;
using EbSite.Base.EntityAPI;
using EbSite.Base.EntityCustom;
using EbSite.BLL.HttpHandlers;
using EbSite.Core;
using EbSite.Core.Strings;
using EbSite.Core.WebApiUtils;
using EbSite.Data.Interface;
using EbSite.Entity; 

namespace EbSite.Web
{
    public partial class ddd :  Base.Page.BasePage
    {
        //protected string sUID;
        //protected string sEnFolder;
        //protected string ValStr;
        //protected string ext;
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //ext = "jpg,jpeg,gif,png";
            //int UserId = EbSite.Base.Host.Instance.UserID;

            // sUID = HttpContext.Current.Server.UrlEncode(
            //    EbSite.Base.Host.Instance.EncodeByKey(string.Concat(UserId, ",",
            //            EbSite.Base.Host.Instance.OnlineID)));
            //string folder = "cqsddd";
            //int size = 1024;
            // sEnFolder = HttpContext.Current.Server.UrlEncode(EbSite.Base.Host.Instance.EncodeByKey(folder));
            //  ValStr =
            //    EbSite.Base.Host.Instance.EncodeByMD5(string.Concat(folder, size,
            //        Base.Host.Instance.EncodeByKey(ext), EbSite.Base.Host.Instance.OnlineID, UserId));
            //upImg.CtrlValue = @"\UploadFile\imgs\20220407\dkjpvpksbjy-ebbaseimg.gif";
        }

        public string GetUploadStr(string selfilebox,string ext,string folder,int size)
        {
            return Host.Instance.GetUploadStr(selfilebox, ext, folder, size);

        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            //Response.Write(UPIMG.CtrValue);
            //Literal1.Text = txtBox.CtrValue;
        }

         

    }
    


}