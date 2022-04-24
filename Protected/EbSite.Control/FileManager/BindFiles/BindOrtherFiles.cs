
using System.Web.UI;

namespace EbSite.Control.FileManager
{
    public class BindOrtherFiles:BindBase
    {
        public override void BindFiles(string sFileUrl)
        {
            string sFileName = "";
            string FileLocation="";

            try
            {
                sFileName = sFileUrl.ToString();
                sFileName = sFileName.Substring(sFileName.LastIndexOf("\\") + 1);

                //FileLocation = AppUrl;
                FileLocation = FileLocation.Substring(FileLocation.LastIndexOf("\\") + 1);
                FileLocation += CurrentFullFolder;
                FileLocation += "/";
                FileLocation += sFileName;

                System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
                myHtmlImage.Src = GetFileIco(sFileName); //显示图标
                myHtmlImage.Attributes["unselectable"] = "on";
                myHtmlImage.Attributes["align"] = "absmiddle";
                myHtmlImage.Attributes["vspace"] = "28";



                System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();
                myImageHolder.CssClass = "imageholder";
                myImageHolder.Attributes["unselectable"] = "on";
                myImageHolder.Attributes["onclick"] = "divClick(this,'" + sFileName + "');";
                myImageHolder.Attributes["ondblclick"] = "ReturnFile('" + FileLocation.Replace("\\", "/") + "');";
                myImageHolder.Controls.Add(myHtmlImage);

                System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
                myMainHolder.CssClass = "imagespacer";
                myMainHolder.Controls.Add(myImageHolder);

                System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
                myTitleHolder.CssClass = "titleHolder";
                myTitleHolder.Controls.Add(
                    new LiteralControl(sFileName + "<BR>"));
                myMainHolder.Controls.Add(myTitleHolder);

                GalleryPanel.Controls.Add(myMainHolder);

            }
            catch
            {
            }
        }
    }
}
