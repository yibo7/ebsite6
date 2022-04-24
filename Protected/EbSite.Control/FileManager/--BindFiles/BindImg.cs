//using System;

//using System.Web.UI;

//namespace EbSite.Control.FileManager
//{
//    public class BindImg:BindBase
//    {
//        public override void BindFiles(string ImageFile)
//        {
//            string ImageFileName = "";
//            string ImageFileLocation = "";

//            int thumbWidth = 94;
//            int thumbHeight = 94;
//            try
//            {
//                ImageFileName = ImageFile.ToString();
//                ImageFileName = ImageFileName.Substring(ImageFileName.LastIndexOf("\\") + 1);
//                //ImageFileLocation = AppUrl;
//                ImageFileLocation = ImageFileLocation.Substring(ImageFileLocation.LastIndexOf("\\") + 1);
//                ImageFileLocation += CurrentFullFolder;
//                ImageFileLocation += "/";
//                ImageFileLocation += ImageFileName;
//                System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
//                string sImsgPath = ImageFileLocation;//Base.AppStartInit.IISPath+ ImageFileLocation;
//                myHtmlImage.Src = sImsgPath;
//                myHtmlImage.Alt = sImsgPath;
//                System.Drawing.Image myImage = System.Drawing.Image.FromFile(ImageFile.ToString());
//                myHtmlImage.Attributes["unselectable"] = "on";

//                if (myImage.Width > myImage.Height)
//                {
//                    if (myImage.Width > thumbWidth)
//                    {
//                        myHtmlImage.Width = thumbWidth;
//                        myHtmlImage.Height = Convert.ToInt32(myImage.Height * thumbWidth / myImage.Width);
//                    }
//                    else
//                    {
//                        myHtmlImage.Width = myImage.Width;
//                        myHtmlImage.Height = myImage.Height;
//                    }
//                }
//                else
//                {
//                    if (myImage.Height > thumbHeight)
//                    {
//                        myHtmlImage.Height = thumbHeight;
//                        myHtmlImage.Width = Convert.ToInt32(myImage.Width * thumbHeight / myImage.Height);
//                    }
//                    else
//                    {
//                        myHtmlImage.Width = myImage.Width;
//                        myHtmlImage.Height = myImage.Height;
//                    }
//                }

//                if (myHtmlImage.Height < thumbHeight)
//                {
//                    myHtmlImage.Attributes["vspace"] =
//                        Convert.ToInt32((thumbHeight / 2) - (myHtmlImage.Height / 2)).ToString();
//                }

//                System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();
//                myImageHolder.CssClass = "imageholder";
//                myImageHolder.Attributes["onclick"] = "divClick(this,'" + ImageFileName + "');";
//                myImageHolder.Attributes["ondblclick"] = "returnImage('" + ImageFileLocation.Replace("\\", "/") +
//                                                         "','" + myImage.Width.ToString() + "','" +
//                                                         myImage.Height.ToString() + "');";
//                myImageHolder.Controls.Add(myHtmlImage);

//                System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
//                myMainHolder.CssClass = "imagespacer";
//                myMainHolder.Controls.Add(myImageHolder);

//                System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
//                myTitleHolder.CssClass = "titleHolder";
//                myTitleHolder.Controls.Add(
//                    new LiteralControl(ImageFileName + "<BR>" + myImage.Width.ToString() + "x" +
//                                       myImage.Height.ToString()));
//                myMainHolder.Controls.Add(myTitleHolder);

//                GalleryPanel.Controls.Add(myMainHolder);

//                myImage.Dispose();
//            }
//            catch
//            {
//            }
//        }
//    }
//}
