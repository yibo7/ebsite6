//using System;
//using System.Collections;
//using System.Configuration;
//using System.Data;
//using System.Drawing;
//using System.IO;
//using System.Web;
//using EbSite.Core.Strings;
////using EbSite.Pages;


//namespace EbSite.Control.FileManager
//{
//    /// <summary>
//    /// 控件的调用者
//    /// </summary>
//    enum UseType
//    {
//        None = -1,
//        UserControl = 1,
//        Editor = 2,
//        Filelist = 3,
        
//        Other = 4
//    }

//    public partial class UploadSingle : FilePageBase
//    {
//        /// <summary>
//        /// 这个值不不空，说明控件的调用者是用户自定义控件,否则为编辑器
//        /// </summary>
//        private UseType ControlUseType
//        {
//            get
//            {
//                if (!string.IsNullOrEmpty(Request["ut"]))
//                {
//                    return (UseType)int.Parse(Request["ut"]);
//                }
//                return UseType.None;
//            }
//        }
        
//        /// <summary>
//        /// 获取允许上传的文件格式,用逗号分开,最后以|分开是允许上传文件的大小
//        /// 字符已经加密，必解密后再用
//        /// </summary>
//        protected string  GetPram
//        {
//            get
//            {
//                if (!string.IsNullOrEmpty(Request["pram"]))
//                {

//                    return Core.Strings.StringEncrypt.NcyString(Request["pram"]);
//                }
//                return string.Empty;
//            }
//        }
//        /// <summary>
//        /// 获取可以上传文件的大小,只允许设置整数,单位是K
//        /// </summary>
//        protected int dcSize
//        {
//            get
//            {
//                string[] arr = GetPram.Split('|');

//                if (arr.Length > 1 && Core.Strings.Validate.IsNum(arr[1]))
//                {
                    
//                    return int.Parse(arr[1]);
//                }
//                return 0;
//            }
//        }
//        /// <summary>
//        /// 获取控件允许上传文件的格式
//        /// </summary>
//        protected string GetArrowType
//        {
//            get
//            {
//                string[] arr = GetPram.Split('|');

//                if(arr.Length>1)
//                {
//                    return arr[0].ToLower().Trim();
//                }
//                return "";
//            }
//        }
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (ControlUseType==UseType.None)
//            {
//                Response.Write("出错啦，未知调用类型");
//                Response.End();
//                return;
//            }
            
//            InitPage();
//            uploadPanel.Visible = true;

//        }
        
//        private void InitPage()
//        {
//            uploadPanel.Visible = false;
//            resultPanel.Visible = false;

//            UploadType.InnerText = GetArrowType;
//            UploadSize.InnerText = dcSize.ToString()+"KB";
//        }
//        protected void btnUpload_Click(object sender, EventArgs e)
//        {
//            InitPage();
//            //是否远程获取文件
//            //bool isHttpUrl = false; 
//            string filePath = this.fileUpload.PostedFile.FileName;
            
//            int sFileSize = 0;
//            //if (filePath.IndexOf("http://") == 0) 
//            //    isHttpUrl = true;

//            //if(!isHttpUrl)
//            //{
//            //    sFileSize = this.fileUpload.PostedFile.ContentLength;
//            //}
//            //else
//            //{
//            //    sFileSize = (int)Core.WebUtility.GetFileSize(filePath);
//            //}
//            sFileSize = this.fileUpload.PostedFile.ContentLength;
//            string sFileType = GetString.getFileType(filePath);

//            bool isAllow = Core.Strings.Validate.InArray(sFileType.ToLower(), GetArrowType.Split(','));
            
//            //验证文件类型
//            if (!isAllow)
//            {
//                ShowInfo("上传文件格式不正确，只可以上传 " + GetArrowType);
                
//                return;
//            }
//            //验证文件大小
//            if (sFileSize > 1024 * dcSize)  //如果上传文件大于10  k
//            {
//                ShowInfo("上传文件大小不能大于" + dcSize + "KB");
                
//                return;
//            }
//            string sNewName = Path.GetRandomFileName();


//            string sSavePath = string.Concat(DefaultFolder,"/", sNewName, sFileType);

            

//            string[] aImsgType = { ".jpg", ".bmp", ".jpeg", ".png" }; //gif不能加水印
//            bool isImg = Core.Strings.Validate.InArray(sFileType.ToLower(), aImsgType);

//            if (isImg && Base.Configs.PicConfigs.ConfigsControl.Instance.OpenWatermark == 1) //如果是图片
//            {
//                string sImgMarkPath = Base.Configs.PicConfigs.ConfigsControl.Instance.PicPath;
//                 Image img = Image.FromStream(fileUpload.PostedFile.InputStream);

//                 Core.HtmlDown.AddImageSignPic(img, Server.MapPath(string.Concat("~/", sSavePath)), Server.MapPath(sImgMarkPath), Base.Configs.PicConfigs.ConfigsControl.Instance.WatermarkPlace, Base.Configs.PicConfigs.ConfigsControl.Instance.Imgquality,
//                                              Base.Configs.PicConfigs.ConfigsControl.Instance.Watermarktransparency);
//            }
//            else
//            {
//                this.fileUpload.PostedFile.SaveAs(Server.MapPath(string.Concat("~/", sSavePath)));
//            }
            
//            //if (!isHttpUrl) //如果上传本地文件
//            //{
//            //    this.fileUpload.PostedFile.SaveAs(Server.MapPath(string.Concat("~/",sSavePath))); 
//            //}
//            //else //如果上传的是远程文件
//            //{
               
//            //}

//            ShowInfo("文件上传成功");
//            if (ControlUseType == UseType.UserControl)
//            {
//                Response.Write("<" + "script>window.returnValue='" + sSavePath + "'; window.close();</" + "script>\n");   
                
//                //Response.Write("<" + "script>var k=window.dialogArguments;k.document.getElementById('" + GetUcID + "').value='" + sSavePath + "'; window.close();</" + "script>\n");    
//            }
//            else if (ControlUseType == UseType.Editor)
//            {
//                Response.Write("<" + "script>var str = ('" + sSavePath + "'); if(parent.document.all['url'] != null)parent.document.all['url'].value = '" + sSavePath + "';</" + "script>\n");    
//            }
//            else if(ControlUseType==UseType.Filelist)
//            {
//                Response.Write("<" + "script>parent.ReturnFile('" + sSavePath + "')</" + "script>\n");    
//            }
            
//        }
//        private void ShowInfo(string msg)
//        {

//            string ss = msg + "<a href='" + Request.RawUrl + "'>返回</a>";
//            label.Text = ss;
            
//            resultPanel.Visible = true;
//        }
       
//    }
//}
