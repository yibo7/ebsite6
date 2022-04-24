//using System;
//using System.Collections.Generic;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using EbSite.Core.Strings;
////using EbSite.Pages;

//namespace EbSite.Control.FileManager
//{
//    public partial class FileList : FilePageBase
//    {
//        private string NoImagesMessage = "无文件";
       
//        /// <summary>
//        /// 当前浏览的根目录
//        /// </summary>
//        private string RootFolder
//        {
//            get
//            {
//                if(!string.IsNullOrEmpty(Request["rif"]))
//                {
//                    return Request["rif"];
//                }
//                else
//                {
//                    return DefaultFolder;
//                }
//            }
//        }
//        /// <summary>
//        /// 上传的文件参数,已经加密
//        /// </summary>
//        protected string UploadPram
//        {
//            get
//            {
//                if(!string.IsNullOrEmpty(Request["uppram"]))
//                {
//                    return Request["uppram"];
//                }
//                return "";
//            }
//        }
//        /// <summary>
//        /// 当前浏览的根目录+子目录 ,如 upload\sub
//        /// </summary>
//        private string CurrentFullFolder
//        {
//            get
//            {
//                if (!string.IsNullOrEmpty(Request["cif"]))
//                {
//                    return Request["cif"];
//                }
//                else
//                {
//                    return DefaultFolder;
//                }
//            }
//        }
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (string.IsNullOrEmpty(UploadPram)) ToolBar.Visible = false;
//            string isframe = "" + Request["frame"];
//            if (isframe != "")
//            {
//                MainPage.Visible = true;
//                iframePanel.Visible = false;


//                //RootFolder = RootFolder;
//                //CurrentFullFolder = CurrentFullFolder;
                
//                //UploadPanel.Visible = UploadIsEnabled;
//                //DeleteImage.Visible = DeleteIsEnabled;

//                string FileErrorMessage = "";
//                string ValidationString = ".*(";
//                //[\.jpg]|[\.jpeg]|[\.jpe]|[\.gif]|[\.bmp]|[\.png])$"
//                //for (int i = 0; i < AcceptedFileTypes.Length; i++)
//                //{
//                //    ValidationString += "[\\." + AcceptedFileTypes[i] + "]";
//                //    if (i < (AcceptedFileTypes.Length - 1)) ValidationString += "|";
//                //    FileErrorMessage += AcceptedFileTypes[i];
//                //    if (i < (AcceptedFileTypes.Length - 1)) FileErrorMessage += ", ";
//                //}
//                //FileValidator.ValidationExpression = ValidationString + ")$";
//                //FileValidator.ErrorMessage = FileErrorMessage;

//                if (!IsPostBack)
//                {
//                    DisplayFiles();
//                }
//            }
//            else
//            {

//            }
//        }

//        #region 获取当前文件列表与目录列表

//        /// <summary>
//        /// 获取当前目录的所有文件
//        /// </summary>
//        /// <returns></returns>
//        private string[] ReturnFilesArray()
//        {
//            if (CurrentFullFolder != "")
//            {
//                try
//                {
//                    string ImageFolderPath = AppPath + CurrentFullFolder;
//                    string[] FilesArray = System.IO.Directory.GetFiles(ImageFolderPath, "*");
//                    return FilesArray;
//                }
//                catch
//                {
//                    return null;
//                }
//            }
//            else
//            {
//                return null;
//            }

//        }
//        /// <summary>
//        /// 当前上当的所有文件夹
//        /// </summary>
//        /// <returns></returns>
//        private string[] ReturnDirectoriesArray()
//        {
//            if (CurrentFullFolder != "")
//            {
//                try
//                {
                    
//                    string CurrentFolderPath = AppPath + CurrentFullFolder;
//                    string[] DirectoriesArray = System.IO.Directory.GetDirectories(CurrentFolderPath, "*");
//                    return DirectoriesArray;
//                }
//                catch
//                {
//                    return null;
//                }
//            }
//            else
//            {
//                return null;
//            }
//        }

//        #endregion

//        /// <summary>
//        /// 显示文件与目录
//        /// </summary>
//        public void DisplayFiles()
//        {
//            string[] FilesArray = ReturnFilesArray();//所有文件
//            string[] DirectoriesArray = ReturnDirectoriesArray();//所有目录
           
//            GalleryPanel.Controls.Clear();

//            if ((FilesArray == null || FilesArray.Length == 0) &&
//                (DirectoriesArray == null || DirectoriesArray.Length == 0))
//            {
//                gallerymessage.Text = NoImagesMessage + ": " + RootFolder;
//            }
//            else
//            {
               
//                #region 如果当前目录不是一级目录，将显示 返回上一级目录按钮
//                if (CurrentFullFolder != RootFolder)
//                {

//                    System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
//                    myHtmlImage.Src = ImgPath + "folder.up.gif";
//                    myHtmlImage.Attributes["unselectable"] = "on";
//                    myHtmlImage.Attributes["align"] = "absmiddle";
//                    myHtmlImage.Attributes["vspace"] = "28";

//                    string ParentFolder = CurrentFullFolder.Substring(0,
//                                                                              CurrentFullFolder.LastIndexOf("\\"));

//                    System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();
//                    myImageHolder.CssClass = "imageholder";
//                    myImageHolder.Attributes["unselectable"] = "on";
//                    myImageHolder.Attributes["onclick"] = "divClick(this,'');";
//                    myImageHolder.Attributes["ondblclick"] = "gotoFolder('" + RootFolder + "','" +
//                                                             ParentFolder.Replace("\\", "\\\\") + "',"+(int)lstType+");";
//                    myImageHolder.Controls.Add(myHtmlImage);

//                    System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
//                    myMainHolder.CssClass = "imagespacer";
//                    myMainHolder.Controls.Add(myImageHolder);

//                    System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
//                    myTitleHolder.CssClass = "titleHolder";
//                    myTitleHolder.Controls.Add(new LiteralControl("返回上级目录"));
//                    myMainHolder.Controls.Add(myTitleHolder);

//                    GalleryPanel.Controls.Add(myMainHolder);

//                }
//                #endregion


//                #region 对文件夹的绑定
//                foreach (string _Directory in DirectoriesArray)
//                {

//                    try
//                    {
//                        string DirectoryName = _Directory.ToString();

//                        System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
//                        myHtmlImage.Src = ImgPath + "folder.big.gif";
//                        myHtmlImage.Attributes["unselectable"] = "on";
//                        myHtmlImage.Attributes["align"] = "absmiddle";
//                        myHtmlImage.Attributes["vspace"] = "29";

//                        System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();
//                        myImageHolder.CssClass = "imageholder";
//                        myImageHolder.Attributes["unselectable"] = "on";
//                        myImageHolder.Attributes["onclick"] = "divClick(this);";
//                        myImageHolder.Attributes["ondblclick"] = "gotoFolder('" + RootFolder + "','" +
//                                                                 DirectoryName.Replace(AppPath, "").Replace("\\", "\\\\") +
//                                                                  "'," + (int)lstType + ");";
//                        myImageHolder.Controls.Add(myHtmlImage);

//                        System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
//                        myMainHolder.CssClass = "imagespacer";
//                        myMainHolder.Controls.Add(myImageHolder);

//                        System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
//                        myTitleHolder.CssClass = "titleHolder";
//                        myTitleHolder.Controls.Add(
//                            new LiteralControl(DirectoryName.Replace(AppPath + CurrentFullFolder + "\\", "")));
//                        myMainHolder.Controls.Add(myTitleHolder);
//                        GalleryPanel.Controls.Add(myMainHolder);
//                    }
//                    catch
//                    {
//                    }
//                }

//                #endregion


//                #region 对当前文件列表的绑定

//                BindBase BindFiles = BindFactory.CreateInstance(lstType);
               
//                foreach (string OneFile in FilesArray)
//                {
//                    string sType = GetString.getFileType(OneFile);

//                    if (AcceptedFileTypes.Length>0)
//                    {
//                        if (!InArray(sType, AcceptedFileTypes)) continue;
//                    }
//                    BindFiles.GalleryPanel = GalleryPanel;
//                    BindFiles.CurrentFullFolder = CurrentFullFolder;
                    
//                    BindFiles.BindFiles(OneFile);


//                }
//                #endregion

//                gallerymessage.Text = "";
//            }
//        }

//        private string ImgPath
//        {
//            get
//            {
//                return Base.AppStartInit.IISPath+ "images/filelist/";
//            }
//        }
//        private string[] AcceptedFileTypes
//        {
//            get
//            {
//                string[] sFileTypes;
//                switch (lstType)
//                {
//                    case BindFactory.ListType.Img:   //图片
//                        sFileTypes = new string[] { ".jpg", ".jpeg", ".jpe", ".gif", ".bmp", ".png" };
//                        break;
//                    case BindFactory.ListType.Music:   //音乐视频类
//                        sFileTypes = new string[] { ".wma", ".mp3", ".rm",".mp4",".wmv",".rmvb" };
//                        //sFileIco = ImgPath+"musicico.gif";
//                        break;
//                    case BindFactory.ListType.Flash:   //flash类
//                        sFileTypes = new string[] { ".swf", ".flv" };
//                        //sFileIco = ImgPath + "flashico.gif";
//                        break;
//                    case BindFactory.ListType.Other:   //其他所有文件类
//                        sFileTypes = new string[] {};
//                        //sFileIco = ImgPath + "ortherico.gif";
//                        break;
//                    case BindFactory.ListType.Aspx:   //其他所有文件类
//                        sFileTypes = new string[] {".aspx,.ascx"};
//                        //sFileIco = ImgPath + "aspx.gif";
//                        break;

//                    default:
//                        sFileTypes = new string[] { ".jpg", ".jpeg", ".jpe", ".gif", ".bmp", ".png" };
//                        break;

//                }
//                return sFileTypes;
//            }
//        }


//        private BindFactory.ListType lstType
//        {
//            get
//            {
//                if(!string.IsNullOrEmpty(Request["t"]))
//                {
//                    int iType =  int.Parse(Request["t"]);

//                    return (BindFactory.ListType) iType;
//                }
//                return BindFactory.ListType.Other;

//            }
//        }

        

//        protected void DeleteImage_Click(object sender, EventArgs e)
//        {
//            if (FileToDelete.Value != "" && FileToDelete.Value != "undefined")
//            {
//                try
//                {
//                    System.IO.File.Delete(AppPath + CurrentFullFolder + "\\" + FileToDelete.Value);
//                    ResultsMessage.Text = "已经删除: " + FileToDelete.Value;
//                }
//                catch (Exception ex)
//                {
//                    ResultsMessage.Text = "无法删除: " + ex.Message;
//                }
//            }
//            else
//            {
//                ResultsMessage.Text = "没有此文件";
//            }
//            DisplayFiles();
//        }

//        /// <summary>
//        /// 检测一个字符串，是否存在于一个以固定分割符分割的字符串中,不区分大小写
//        /// </summary>
//        /// <param name="str">字符串</param>
//        /// <param name="array">字符串数组</param>
//        /// <returns></returns>
//        public static bool InArray(string str, string[] array)
//        {
//            bool blResult = false;

//            for (int i = 0; i < array.Length; i++)
//            {
//                if (str.ToUpper() == array[i].ToUpper())
//                {
//                    blResult = true;
//                    break;
//                }
//            }

//            return blResult;
//        }
        

//        }

//    }
