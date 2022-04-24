using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL; 
using EbSite.Core;
using EbSite.Core.Strings;
using EbSite.Entity;

namespace EbSite.Control
{
    public enum UploadImgType:int
    {
        单个图片 = 1,
        多个图片 = 2
        
    }

    [DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:UploadImg runat=server></{0}:UploadImg>")]
    public class UploadImg : System.Web.UI.WebControls.HiddenField, IUserContrlBase
    {
        public string CtrValue
        {
            get
            {
                return this.Value;
            }
            set
            {
                this.Value = value;
            }
        }
        //public UploadImg()
        //{
        //    this.TextMode = TextBoxMode.MultiLine;
        //    base.Load += new EventHandler(this.Page_Load);
        //    this.Width = 500;
        //    this.Height = 300;
        //}

        protected override void CreateChildControls()
        {
            this.Controls.Clear();
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("webuploader"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "webuploaderCSS", string.Format("<link type=\"text/css\" href=\"{0}js/webuploader/webuploader.css\" rel=\"stylesheet\" />", Base.AppStartInit.IISPath));

                this.Page.ClientScript.RegisterClientScriptInclude("webuploaderjs", string.Format("{0}js/webuploader/webuploader.min.js", Base.AppStartInit.IISPath));
               
                
            }
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("UploadImg"))
            {                
                this.Page.ClientScript.RegisterClientScriptInclude("webuploaderpic", string.Format("{0}js/webuploader/webuploaderpic.js", Base.AppStartInit.IISPath));

            }
            base.OnPreRender(e);
        }

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (this.Page.IsPostBack)
        //    {
        //        this.ViewState["UpFiles"] = HttpContext.Current.Request["fsEditor"];
        //    }
            
        //}
        /// <summary>
        /// 要保存的文件夹,如果文件夹名称前加上 /，表示不使用系统默认根目录保存路径
        /// </summary>
        public string SaveFolder
        {
            get
            {
                object objA = this.ViewState["SaveFolder"];
                if (Equals(objA, null))
                {
                    return "imgs";
                }
                else
                {
                    return objA.ToString();
                }
            }
            set
            {
                this.ViewState["SaveFolder"] = value;
            }

            //get
            //{
            //    return "bdimg";
            //}
             
        }
        protected override void Render(HtmlTextWriter output)
        {
            base.Render(output);

            //if (this.UploadType == UploadImgType.单个图片)
            //{

            //}
            //else
            //{
            //    output.Write("暂不支持多图上传");
            //}
            string fileListName = string.Concat("imglist", this.ID);
            string filedataName = string.Concat("filedata", this.ID);


            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(@"<div id='bduploader'>
                                    <div><div id='{0}' class='uploader-imglist'></div></div>
                                    <div  id='{1}'>选择图片</div>
                                </div>", fileListName, filedataName);

            string ext = Ext;
            int size = Size;
            string folder = SaveFolder;

            //bool issmallimg = false;//不再提供上传时生成缩略图，要获取缩图可安装缩略图组件 IsMakeSmallImg;

            int UserId = EbSite.Base.Host.Instance.UserID;

            string sUID =
                HttpContext.Current.Server.UrlEncode(
                    EbSite.Base.Host.Instance.EncodeByKey(string.Concat(UserId, ",",
                        EbSite.Base.Host.Instance.OnlineID)));

            string ValStr =
                EbSite.Base.Host.Instance.EncodeByMD5(string.Concat(folder, size,
                    Base.Host.Instance.EncodeByKey(ext), EbSite.Base.Host.Instance.OnlineID, UserId));

            string sEnFolder = HttpContext.Current.Server.UrlEncode(EbSite.Base.Host.Instance.EncodeByKey(folder));
            //(ext0, folder1, userid2, size3, valstr4, filedata5, fileList6, inputid7, iWidth8, iHeight9, isBatch10) 
            stringBuilder.AppendFormat(
                "<script>InitImgUpload('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}',{8},{9},{10});</script>",
                ext, sEnFolder, sUID, size, ValStr, filedataName, fileListName, this.ClientID, this.Height, this.Width, this.UploadType == UploadImgType.多个图片 ? "true" : "false");

            output.Write(stringBuilder);

        }

        
         

        public UploadImgType UploadType
        {
            get
            {
                object objA = this.ViewState["UploadType"];
                if (!object.Equals(objA, null))
                {
                    return (UploadImgType)objA;
                }
                return UploadImgType.单个图片;
            }
            set
            {
                this.ViewState["UploadType"] = value;
            }
        }
         
        /// <summary>
        /// 图片文件的后缀,用逗号分开jpeg,png,gif
        /// </summary>
        public string Ext
        {
            get
            {
                object objA = this.ViewState["ImgExt"];
                if (!object.Equals(objA, null))
                {
                    return objA.ToString();
                }
                return "jpg,jpeg,gif,png";
            }
            set
            {
                this.ViewState["ImgExt"] = value;
            }
        }
        public int Width
        {
            get
            {
                object objA = this.ViewState["Width"];
                if (!object.Equals(objA, null))
                {
                    return int.Parse(objA.ToString());
                }
                return 100;
            }
            set
            {
                this.ViewState["Width"] = value;
            }
        }
        public int Height
        {
            get
            {
                object objA = this.ViewState["Height"];
                if (!object.Equals(objA, null))
                {
                    return int.Parse(objA.ToString());
                }
                return 100;
            }
            set
            {
                this.ViewState["Height"] = value;
            }
        }
        /// <summary>
        /// 大小 kb
        /// </summary>
        public int Size
        {
            get
            {
                object objA = this.ViewState["Size"];
                if (!object.Equals(objA, null))
                {
                    return int.Parse(objA.ToString());
                }
                return 1024;
            }
            set
            {
                this.ViewState["Size"] = value;
            }
        }
        //public bool IsMakeSmallImg
        //{
        //    get
        //    {
        //        object objA = this.ViewState["IsMakeSmallImg"];
        //        return (object.Equals(objA, null) ? false : bool.Parse(objA.ToString()));
        //    }
        //    set
        //    {
        //        this.ViewState["IsMakeSmallImg"] = value;
        //    }
        //} 
    }
}
