using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Base.ControlPage; 

namespace EbSite.Web.AdminHt.Controls.Admin_Configs
{
    abstract public class UploadFilesBase : UserControlListBase
    {
        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }

        private UploadFileInfoBLL ubll = BLL.UploadFileInfoBLL.Instance; // new UploadFileInfoBLL();
        override protected object LoadList(out int iCount)
        {

            return ubll.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount, IsUsedFile);
        }

        protected abstract bool IsUsedFile{ get;}
        override protected object SearchList(out int iCount)
        {
            int iType = int.Parse(ucToolBar.GetItemVal(drpSearchTp));
            string sFileName = ucToolBar.GetItemVal(txtKeyWord).Trim();
            return ubll.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount, iType, sFileName, IsUsedFile);
        }
        override protected void Delete(object iID)
        {
            //同时删除文件
            
            ubll.DeleteDataAndFile(int.Parse(iID.ToString()));

        }
        protected  Control.DropDownList drpSearchTp = new Control.DropDownList();
        protected Control.TextBox txtKeyWord = new Control.TextBox();
        override protected void BindToolBar()
        {

            base.BindToolBar(true, false, false, false, false);
            ucToolBar.AddLine();
            txtKeyWord.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtKeyWord);
            drpSearchTp.ID = "drpSearchTp";
            ListItem liIt = new ListItem("所有文件", "0");
            drpSearchTp.Items.Add(liIt);
            liIt = new ListItem("最近一天", "1");
            drpSearchTp.Items.Add(liIt);
            liIt = new ListItem("最近7天", "2");
            drpSearchTp.Items.Add(liIt);
            liIt = new ListItem("最近30天", "3");
            drpSearchTp.Items.Add(liIt);
            ucToolBar.AddCtr(drpSearchTp);
            base.ShowCustomSearch("查询");



        }
    }
}