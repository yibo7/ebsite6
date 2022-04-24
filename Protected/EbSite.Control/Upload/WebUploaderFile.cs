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
    public enum UploadFileType:int
    {
        单文件上传 = 1,
        多文件上传 = 2
        
    }

    [DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:WebUploaderFile runat=server></{0}:WebUploaderFile>")]
    public class WebUploaderFile : System.Web.UI.WebControls.HiddenField, IUserContrlBase
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
        ///// <summary>
        ///// 为了兼容之前的
        ///// </summary>
        //public string ValSavePath
        //{
        //    get
        //    {
        //        return this.Value;
        //    }
        //    set
        //    {
        //        this.Value = value;
        //    }
        //}
        
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

            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("WebUploaderFile"))
            {
                this.Page.ClientScript.RegisterClientScriptInclude("webuploaderfile", string.Format("{0}js/webuploader/webuploaderfile.js", Base.AppStartInit.IISPath));

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
                    return "files";
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
            string fileListName = string.Concat("filelist", this.ID);
            string filedataName = string.Concat("filedata", this.ID);


            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(@"<div id='bduploader'>
                                    <div id='{0}' class='uploader-filelist'></div>
                                    <div  id='{1}'>选择文件</div>
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
                "<script>InitFileUpload('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}',{8});</script>",
                ext, sEnFolder, sUID, size, ValStr, filedataName, fileListName, this.ClientID,  this.UploadType == UploadFileType.多文件上传 ? "true" : "false");

            output.Write(stringBuilder);

        }

        
         

        public UploadFileType UploadType
        {
            get
            {
                object objA = this.ViewState["UploadType"];
                if (!object.Equals(objA, null))
                {
                    return (UploadFileType)objA;
                }
                return UploadFileType.单文件上传;
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
                return "rar,zip,png,gif,jpe,jpeg,pdf,txt";
            }
            set
            {
                this.ViewState["ImgExt"] = value;
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
    }
}
