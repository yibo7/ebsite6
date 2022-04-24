using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL.IISLOG;
using EbSite.Core.FSO;

namespace EbSite.Web.AdminHt.Controls.Admin_SEO
{
    public partial class IISLog : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "280";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "280";
            }
        }
        /// <summary>
        /// 添加数据的权限ID
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "280";
            }
        }
        /// <summary>
        /// 修改数据权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "280";
            }
        }
        #endregion

        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }
        override protected object LoadList(out int iCount)
        {
            BLL.IISLOG.IISLOGBll.Instance.LodingLog();
            iCount = 0;
            return IISLOGBll.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount);
        }
        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {

            BLL.IISLOG.IISLOGBll.Instance.DeleteLog(int.Parse(iID.ToString()));


        }
        override protected void BindToolBar()
        {
            base.BindToolBar(true, false, false, false, false);

        }
        protected override void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (object.Equals(e.CommandName, "SetCount"))
            {
                string iD = e.CommandArgument.ToString();
                BLL.IISLOG.IISLOGBll.Instance.CountInfo(int.Parse(iD));

                base.gdList_Bind();
            }
            else if(object.Equals(e.CommandName, "Down"))
            {
                string iD = e.CommandArgument.ToString();
                IISLOGEntity md = IISLOGBll.Instance.GetEntity(int.Parse(iD));
                string sPath = IISLOGBll.Instance.GetLogPath(md.LogName);
                if (Core.FSO.FObject.IsExist(sPath, FsoMethod.File))
                {
                    string sFileName = sPath;
                    // FileStream fileStream = new FileStream(sFileName, FileMode.Open);
                    FileStream fileStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    //StreamReader sReader = new StreamReader(fStream, Encoding.Default);
                    long fileSize = fileStream.Length;
                    byte[] fileBuffer = new byte[fileSize];
                    fileStream.Read(fileBuffer, 0, (int)fileSize);
                    //如果不写fileStream.Close()语句，用户在下载过程中选择取消，将不能再次下载
                    fileStream.Close();

                    Context.Response.ContentType = "application/octet-stream";
                    //Context.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(sFileName, Encoding.UTF8));
                    Context.Response.AppendHeader("Content-Disposition", "attachment;filename=log"+ iD + ".zip");
                    Context.Response.AddHeader("Content-Length", fileSize.ToString());

                    Context.Response.BinaryWrite(fileBuffer);
                    Context.Response.End();
                    Context.Response.Close();
                }

            }

        }
    }
}