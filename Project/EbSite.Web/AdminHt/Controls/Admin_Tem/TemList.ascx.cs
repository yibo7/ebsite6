using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.Core.FSO;
using EbSite.Entity;
using Templates = EbSite.Entity.Templates;

namespace EbSite.Web.AdminHt.Controls.Admin_Tem
{
    public partial class TemList : BaseList
    {

        #region 权限

        public override string Permission
        {
            get
            {
                return "93";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "96";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "97";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "206";
            }
        }
  
        #endregion

        /// <summary>
        /// 模板类型的ID，如首页，分类
        /// </summary>
        public int iTemClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["tc"]))
                    return Convert.ToInt32(Request.QueryString["tc"]);
                else
                    return -1;
            }

        }
        override protected string AddUrl
        {
            get
            {
                return string.Format("t=6&tt={0}&theme={1}", ThemesType, CurrentThemeName);
            }
        }


 
        override protected object LoadList(out int iCount)
        {

            iCount = 0;

            //TempFactory.Instance.RefeshTemp();
            TemBll.RefeshTemp();
            List<Templates> rs = new List<Templates>();
            //List<Templates> list = TempFactory.Instance.TemplatesList();
            List<Templates> list = TemBll.TemplatesList();
            

            if (iTemClassID != -1)
            {
                foreach (var templatese in list)
                {
                    if (templatese.TemType == iTemClassID)
                        rs.Add(templatese);

                }
            }
            else
            {
                //rs = TempFactory.Instance.TemplatesList();
                rs = TemBll.TemplatesList();

                
            }
            if(rs.Count>0)
            {
                btnInit.Visible = false;
            }
            return rs;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            List<Templates> lstRz = new List<Templates>();
            
            //List<Templates> lst = TempFactory.Instance.TemplatesList();

            List<Templates> lst = TemBll.TemplatesList();

            string sKeyTitle = ucToolBar.GetItemVal(txtOne).Trim();
            string searchType = ucToolBar.GetItemVal(drpSearchTp);


            if (!string.IsNullOrEmpty(sKeyTitle))
            {
                foreach (Templates template in lst)
                {
                    if (searchType.Equals("0"))
                    {
                        if (template.TemName.IndexOf(sKeyTitle) > -1)
                        {
                            lstRz.Add(template);
                        }
                    }
                    else if (searchType.Equals("1"))
                    {
                        if (template.ID.ToString().IndexOf(sKeyTitle) > -1)
                        {
                            lstRz.Add(template);
                        }
                    }
                }
            }
            else
            {
                lstRz = lst;
            }

            return lstRz;
        }
        override protected void Delete(object iID)
        {
            Guid gID = new Guid(iID.ToString());
            //删除模板文件
            //string sPath = TempFactory.Instance.GetModel(gID).TemPath;

            string sPath = TemBll.GetModel(gID).TemPath;
            
            sPath = Server.MapPath(sPath);
            Core.FSO.FObject.Delete(sPath, FsoMethod.File);
            //删除数据文件

            TemBll.Delete(gID);

            //TempFactory.Instance.Delete(gID);

        }
        /// <summary>
        /// 可视化工具 指向TempDesign模块中
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetDesignUrl(object id)
        {
            string url = base.HostApi.GetModuleUrlForAdmin(new Guid("72f28130-d8d2-458f-ab78-8cadf0899c2d"),
                                                           new Guid("4802dc4c-a478-49ac-9e5f-9ecadaa216d3"));
            if (url.Equals(EbSite.Base.Host.Instance.GetTipsUrl(6)))

                return string.Format(url);
            return string.Format(url + "&id={0}", id);
        }
        protected string GetEditUrl(object id)
        {
            return string.Concat(GetTabUrl,"&t=4&id=", id);
        }
        protected string GetTemClass(object id)
        {
            string typeName = "";
            List<TemClass> temClasses = TemBll.GetTemClass();

            foreach (var temClass in temClasses)
            {
                if (temClass.ClassID.Equals(id))
                {
                    typeName = temClass.ClassName;
                    break;
                }
            }
            return typeName;
        }

        protected Control.TextBox txtOne = new Control.TextBox();
        protected Control.DropDownList drpSearchTp = new Control.DropDownList();
        //protected DropDownList drpTemTp = new DropDownList();
        protected Control.DropDownList drpTemClass = new Control.DropDownList();

        //protected override string GetUrl
        //{
        //    get
        //    {

        //        return string.Format("Admin_Tem.aspx?t={0}", PageType);
        //    }
        //}

        protected override void BindToolBar()
        {
            base.BindToolBar(false, false, true, true, false);
            //ucToolBar.AddBox("divPutin", "导入模板", "putin", IISPath + "images/menus/Doc-Previous.gif");
            //ucToolBar.AddBnt("导出模板", IISPath + "images/menus/Doc-Next.gif", "putout");

            ucToolBar.AddLine();

            txtOne.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtOne);

            drpSearchTp.ID = "drpSearchTp";
            ucToolBar.AddCtr(drpSearchTp);
            ListItem li = new ListItem("模板名称", "0");
            ListItem li2 = new ListItem("模板ID", "1");
            drpSearchTp.Items.Add(li);
            drpSearchTp.Items.Add(li2);

            base.ShowCustomSearch("查询");

            ucToolBar.AddLine();

            //drpTemTp.ID = "drpTemTp";
            //ucToolBar.AddCtr(drpTemTp);
            //drpTemTp.AppendDataBoundItems = true;
            //ListItem temItem = new ListItem("模板类别", "");
            //drpTemTp.Items.Add(temItem);
            //drpTemTp.DataTextField = "Title";
            //drpTemTp.DataValueField = "ID";
            //drpTemTp.Attributes.Add("onchange", "OnTemTpChange(this)");
            //drpTemTp.DataSource = BLL.ClassCustom.Provider.Factory.PageTemp().Fills();
            //drpTemTp.DataBind();

            drpTemClass.ID = "drpTemClass";
            ucToolBar.AddCtr(drpTemClass);
            drpTemClass.AppendDataBoundItems = true;
            ListItem tcItem = new ListItem("适用类型", "");
            drpTemClass.Items.Add(tcItem);
            drpTemClass.Attributes.Add("onchange", "OnTemClassChange(this)");
            drpTemClass.DataTextField = "ClassName";
            drpTemClass.DataValueField = "ClassID";
            drpTemClass.DataSource = TemBll.GetTemClass();
            drpTemClass.DataBind();

        }
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {

                #region 放弃
                 //case "putout":
                //    List<string> lstPaths = new List<string>();
                //    //先创建文件夹
                //    string fileurl = string.Format("{0}UploadFile/temp/Templates", IISPath);
                //    Core.FSO.FObject.Create(HttpContext.Current.Server.MapPath(fileurl), FsoMethod.Folder);
                //    string fileurlXml = string.Format("{0}UploadFile/temp/Templates/templates", IISPath);
                //    Core.FSO.FObject.Create(HttpContext.Current.Server.MapPath(fileurlXml), FsoMethod.Folder);
                //    string fileurlAspx = string.Format("{0}UploadFile/temp/Templates/PageTemps", IISPath);
                //    string fileurlAspxS = string.Format("{0}UploadFile/temp/Templates", IISPath);
                //    Core.FSO.FObject.Create(HttpContext.Current.Server.MapPath(fileurlAspx), FsoMethod.Folder);

                //    foreach (string selKey in GetSelKeys)
                //    {
                //        Entity.Templates md = BLL.Templates.GetModel(new Guid(selKey));
                //        string oldsp = Server.MapPath(string.Format("{0}Datastore/templates/{1}.xml", IISPath, selKey));
                //        Core.FSO.FObject.CopyFile(oldsp, HttpContext.Current.Server.MapPath(string.Format(fileurlXml + "/{0}.xml", selKey)));
                //        ///////////////
                //        string oldaspx = Server.MapPath(md.TemPath);
                //        Core.FSO.FObject.CopyFile(oldaspx, HttpContext.Current.Server.MapPath(fileurlAspxS + "/" + md.TemPath));
                //    }
                //    string sUrl = string.Format("{0}UploadFile/temp/{1}.zip", IISPath, Path.GetRandomFileName());
                //    string sSavePath = Server.MapPath(sUrl);

                //   // Core.FSO.FObject.ZipFilesList(lstPaths, sSavePath);
                //    Core.FSO.FObject.ZipFile(HttpContext.Current.Server.MapPath(fileurl), sSavePath);
                //    //删除临时文件夹Templates
                //    Core.FSO.FObject.Delete(HttpContext.Current.Server.MapPath(fileurl), FsoMethod.Folder);


                //    Response.Redirect(Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName + sUrl);
                //    //删除压缩包 这里变灰色了，不执行

                //    Core.FSO.FObject.Delete(HttpContext.Current.Server.MapPath(sUrl), FsoMethod.Folder);

                //    //Core.Utils.RunClientJs(this, string.Format("window.open('{0}')", sSavePath)););););););
                //    break;
                //case "putin":
                //    if (this.txtMdPath.ValSavePath == "")
                //    {
                //        base.ShowTipsPop(" 请先上传模板的Zip压缩包!");
                //    }
                //    else
                //    {
                //        string zipUrl = HttpContext.Current.Server.MapPath("/" + this.txtMdPath.ValSavePath);
                //       // string unzipUrl = HttpContext.Current.Server.MapPath("/" + this.SetPathUrl.Text);
                //        string unzipUrl = HttpContext.Current.Server.MapPath(string.Format("{0}UploadFile/temp/Templates", IISPath));
                //        //思路：先上传到临时文件再解压，然后复制文件
                //        bool tag = Core.FSO.FObject.UnZipFile(zipUrl, unzipUrl);
                //        if(tag)
                //        {
                //            //复制文件
                //           // Core.FSO.FObject.Create(HttpContext.Current.Server.MapPath(url), FsoMethod.Folder);
                //            //复制文件夹 Templates\ASPX\PageTemps 到PageTemps
                //            string oldurl = HttpContext.Current.Server.MapPath(string.Format("{0}UploadFile/temp/Templates/PageTemps", IISPath));
                //            string newurl = HttpContext.Current.Server.MapPath(string.Format("{0}PageTemps", IISPath));
                //            Core.FSO.FObject.CopyDirectory(oldurl, newurl);

                //            //复制文件夹 Templates\templates 到Datastore\templates
                //            string oldurl2 = HttpContext.Current.Server.MapPath(string.Format("{0}UploadFile/temp/Templates/templates", IISPath));
                //            string newurl2 = HttpContext.Current.Server.MapPath(string.Format("{0}Datastore/templates", IISPath));
                //            Core.FSO.FObject.CopyDirectory(oldurl2, newurl2);
                //            //删除文件
                //            Core.FSO.FObject.Delete(unzipUrl, FsoMethod.Folder);
                //            base.ShowTipsPop(" 页面模板导入成功！");

                //        }

                //    }



                //    break;
                #endregion
               
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Base.Host.Instance.CurrentSite.PageTheme != null)
                //{
                //    thememName.InnerHtml = "当前操作模板所在皮肤:<font color=red>" + Base.Host.Instance.CurrentSite.PageTheme + "</font>";
                //}

                ucToolBar.SetItemVal(drpTemClass, iTemClassID.ToString());

                if(TempFactory.Instance.GetCountNoInCurrent()>0)
                {
                    btnResetThemeName.Text = "当前包含有(" + TemBll.GetCountNoInCurrent() +")个非当前皮肤下的数据，可能由于复制过来的皮肤没有调整过来，点击这里调整过来";
                    btnResetThemeName.Visible = true;
                }
            }
        }



        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (Equals(e.CommandName, "CopyClass"))
            {
                string id = e.CommandArgument.ToString();
                //先要查出要复制的模板

                Entity.Templates cm = TemBll.GetModel(new Guid(id));
                string sThemes = CurrentThemeName;// CurrentSite.PageTheme;
                Entity.Templates mdNC = new Templates(ThemesFolder);

                mdNC.TemName = "复制-" + cm.TemName;
                mdNC.TemType = cm.TemType;
                mdNC.IsNoSysTem = true;

                mdNC.Themes = sThemes;
                mdNC.AddDate = DateTime.Now;



                //生成模板文件
                string sfName = Path.GetRandomFileName();


                //模板前缀
                string sPre = TemBll.GetTemClass(cm.TemType).PrefixName;
                

                string sFileName = string.Concat(sPre, sfName, ".aspx");
                sfName = string.Concat(IISPath,TemBll.ThemesFolder, "/", sThemes, "/pages/", sFileName);

                string sTemPath = Server.MapPath(sfName);

                if (!Core.FSO.FObject.IsExist(sTemPath, FsoMethod.File))
                {
                    string sTemHtml = Core.FSO.FObject.ReadFile(Server.MapPath(cm.TemPath));//把aspx中的内容给读出来

                    Core.FSO.FObject.WriteFile(sTemPath, sTemHtml);

                    mdNC.Themes = sThemes;
                    mdNC.TempFileName = sFileName;
                    mdNC.IsNoSysTem = true;
                    mdNC.ID = Guid.NewGuid();
                    TemBll.Add(mdNC);
                    

                }
                ////这里要刷新GridView
                base.gdList_Bind();

            }
        }

        protected void btnInit_Click(object sender, EventArgs e)
        {
            //BLL.ThemesPC.Instance.MakeDefaultTemData(CurrentSite.PageTheme);
            BLL.ThemesPC.Instance.MakeDefaultTemData(CurrentThemeName);
            
        }
        protected void btnResetThemeName_Click(object sender, EventArgs e)
        {
            //TempFactory.Instance.ResetNoInCurrent();
            TemBll.ResetNoInCurrent();
            
        }
        
    }
}