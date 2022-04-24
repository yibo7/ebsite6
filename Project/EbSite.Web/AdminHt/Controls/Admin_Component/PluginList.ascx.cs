using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Web.UI.WebControls;
using EbSite.Base.Extension.Manager;

namespace EbSite.Web.AdminHt.Controls.Admin_Component
{
    public partial class PluginList : EbSite.Base.ControlPage.UserControlListBase
    {
        public override string Permission
        {
            get
            {
                return "142";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }
        override protected object LoadList(out int iCount)
        {
            throw new NotImplementedException();
        }

        //override protected object SearchList(out int iCount)
        //{
        //    iCount = 0; 
        //    string key = ucToolBar.GetItemVal(txtKeyWord).Trim();

        //    List<ManagedExtension> lst =  ExtensionManager.Instance.Extensions;
        //    List<ManagedExtension> lstRZ = new List<ManagedExtension>();
        //    foreach (ManagedExtension extension in lst)
        //    {
        //        if (extension.Name.IndexOf(key)>0)
        //            lstRZ.Add(extension);
        //    }

        //    lblExtensions.Text = GetExtensions(lstRZ);

        //    return  null;
        //}
        override protected void Delete(object iID)
        {
            //BLL.NewsClass.Delete(int.Parse(iID.ToString()));

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMsg.InnerHtml = string.Empty;
            lblErrorMsg.Visible = false;
            //btnRestart.Visible = false;


            object act = Request.QueryString["act"];
            object ext = Request.QueryString["ext"];

            if (act != null && ext != null)
            {
                ChangeStatus(act.ToString(), ext.ToString());
                EbSite.Base.Host.CacheApp.Clear();//EbSite.Core.CacheManager.RemoveAllCache();
            }

            //btnRestart.Click += BtnRestartClick;
            if(!IsPostBack)
            {
                lblExtensions.Text = GetExtensions(ExtensionManager.Instance.Extensions);
            }
        }

        ///// <summary>
        ///// Test stuff - ignore for now
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void BtnRestartClick(object sender, EventArgs e)
        //{
        //    RestartApp();

        //}
        //private void RestartApp()
        //{
        //    // This short cercuits the IIS process. Need to find a better way to restart the app.
        //    //ThreadPool.QueueUserWorkItem(delegate { ForceRestart(); });
        //    ThreadStart threadStart = delegate { ForceRestart(); };
        //    Thread thread = new Thread(threadStart);
        //    thread.IsBackground = true;
        //    thread.Start();
        //    //Response.Redirect(Request.RawUrl, true);
        //}
        //private void ForceRestart()
        //{

        //    throw new ApplicationException();
        //}

        /// <summary>
        /// Get extensions data from extension manager
        /// and format data as html table
        /// </summary>
        /// <returns>Html-formated table</returns>
        private static string GetExtensions(List<ManagedExtension> extList)
        {
            //TODO: localize strings
            string confirm = "您的网站将中断运行几秒钟。您确定要继续吗？";//by Spoony
            string jsOnClick = "onclick=\"if (confirm('" + confirm + "')) { window.location.href = this.href } return false;\"";
            string clickToEnable = "点击启用 ";
            string clickToDisable = "点击禁用 ";
            string enabled = "已启用";
            string disabled = "已禁用";

            //List<ManagedExtension> extList = ExtensionManager.Instance.Extensions;
            StringBuilder sb = new StringBuilder("<table class=\"table\"  style=\"border-style:none; border-collapse:collapse; \" >");
            sb.Append("<tr >");
            sb.Append("<td>" + Resources.lang.EBName + "</td>");
            sb.Append("<td>" + Resources.lang.EBVersion + "</td>");
            sb.Append("<td>" + Resources.lang.EBPriority + "</td>");
            sb.Append("<td>" + Resources.lang.EBDescription + "</td>");
            sb.Append("<td>" + Resources.lang.EBAuthor + "</td>");
            sb.Append("<td>" + Resources.lang.EBState + "</td>");
            sb.Append("<td>"+Resources.lang.EBCode+"</td>");
            sb.Append("<td>"+Resources.lang.EBConfig+"</td>");
            sb.Append("<td><input id=\"chAll\" onclick=\"on_check(this)\" type=\"checkbox\"></td>");
            sb.Append("</tr>");

            if (extList != null)
            {
                // int alt = 0;
                extList.Sort(delegate(ManagedExtension e1, ManagedExtension e2)
                {
                    if (e1.Priority == e2.Priority)
                        return string.CompareOrdinal(e1.Name, e2.Name);
                    return e1.Priority.CompareTo(e2.Priority);
                });

                foreach (ManagedExtension x in extList)
                {
                    //if (alt % 2 == 0)
                    //    sb.Append("<tr style='background:#f9f9f9'>");
                    //else
                    sb.Append("<tr onmouseover=\"this.className='GridMouseOver'\" onmouseout=\"this.className='GridMouseOut'\">");

                    sb.Append("<td  class=\"gvfisrtTD\">" + x.Name + "</td>");
                    sb.Append("<td >" + x.Version + "</td>");
                    sb.Append("<td >" + x.Priority + "</td>");
                    sb.Append("<td >" + x.Description + "</td>");
                    sb.Append("<td >" + x.Author + "</td>");

                    if (x.Enabled)
                        sb.Append("<td align='center' style='background:#ccffcc'><a href='?t=0&act=dis&ext=" + x.Name + "' title='" + clickToDisable + x.Name + "' " + jsOnClick + ">" + enabled + "</a></td>");
                    else
                        sb.Append("<td align='center' style='background:#ffcc66'><a href='?t=0&act=enb&ext=" + x.Name + "' title='" + clickToEnable + x.Name + "' " + jsOnClick + ">" + disabled + "</a></td>");

                    sb.Append("<td align='center'><a href='?t=2&ext=" + x.Name + "'>" + "查看" + "</a></td>");//by Spoony

                    // link to settings page
                    if (!string.IsNullOrEmpty(x.AdminPage))
                    {
                        //string url = EbSite.Base.AppStartInit.AbsoluteWebRoot.AbsoluteUri;
                        //if (!url.EndsWith("/"))
                        //    url += "/";

                        //if (x.AdminPage.StartsWith("~/"))
                        //    url += x.AdminPage.Substring(2);
                        //else if (x.AdminPage.StartsWith("/"))
                        //    url += x.AdminPage.Substring(1);
                        //else
                        //    url += x.AdminPage;

                        sb.Append("<td align='center'><a href='" + x.AdminPage + "'>管理</a></td>");
                    }
                    else
                    {
                        if (x.Settings == null)
                        {
                            sb.Append("<td>&nbsp;</td>");
                        }
                        else
                        {
                            if (x.Settings.Count == 0 || (x.Settings.Count == 1 && x.Settings[0] == null) || x.ShowSettings == false)
                                sb.Append("<td>&nbsp;</td>");
                            else
                                sb.Append("<td align='center'><a href='?t=1&ext=" + x.Name + "'>编辑</a></td>");
                        }
                    }
                    sb.Append("<td><input  type=\"checkbox\"></td>");
                    sb.Append("</tr>");
                    //alt++;
                }
            }
            sb.Append("</table>");
            return sb.ToString();
        }

        /// <summary>
        /// Method to change extension status
        /// to enable or disable extension and
        /// then will restart applicaton by
        /// touching web.config file
        /// </summary>
        /// <param name="act">Enable or Disable</param>
        /// <param name="ext">Extension Name</param>
        void ChangeStatus(string act, string ext)
        {
            // UnloadAppDomain() requires full trust - touch web.config to reload app
            try
            {
                if (act == "dis")
                {
                    //关闭插件
                    ExtensionManager.Instance.ChangeStatus(ext, false);
                }
                else
                {
                    //启动插件
                    ExtensionManager.Instance.ChangeStatus(ext, true);
                }

                if (ExtensionManager.Instance.FileAccessException == null)
                {
                    //Response.Redirect("default.aspx");
                }
                else
                {
                    ShowError(ExtensionManager.Instance.FileAccessException);
                }
            }
            catch (Exception e)
            {
                ShowError(e);
            }
        }

        /// <summary>
        /// Show error message if something
        /// goes wrong
        /// </summary>
        /// <param name="e">Exception</param>
        void ShowError(Exception e)
        {
            lblErrorMsg.Visible = true;
            lblErrorMsg.InnerHtml = "尚未应用更改: " + e.Message;//by Spoony
        }
        //protected System.Web.UI.WebControls.Label lb = new Label();
        //protected System.Web.UI.WebControls.TextBox txtKeyWord = new TextBox();
        //protected override void BindToolBar()
        //{
        //    base.BindToolBar(false, false, true, true, false);
            
        //    ucToolBar.AddBnt("导出动态组件", IISPath + "images/menus/Doc-Next.gif", "putout"); 
        //}
    }
}