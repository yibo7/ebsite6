using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Tem
{
    public partial class IncList : BaseList
    {
         

        public override string Permission
        {
            get
            {
                return "94";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "99";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "205";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "204";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return string.Format("t=7&tt={0}&theme={1}", ThemesType, CurrentThemeName);
            }
        }
        override protected object LoadList(out int iCount)
        { 
            //Log.Factory.GetInstance().InfoLog("来到LoadList");
            iCount = 0;
            //BLL.TemplateInc.RefeshInc();

            TemBll.IncBll.RefeshInc();

            //return BLL.TemplateInc.IncsList;

            return TemBll.IncBll.IncsList;

        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            List<Entity.Templates> lstRz = new List<Entity.Templates>();
            //List<Entity.Templates> lst = BLL.TemplateInc.IncsList;
            List<Entity.Templates> lst = TemBll.IncBll.IncsList;

            string sKeyTitle = ucToolBar.GetItemVal(txtOne).Trim();
            string searchType = ucToolBar.GetItemVal(drpSearchTp);


            if (!string.IsNullOrEmpty(sKeyTitle))
            {
                foreach (Entity.Templates temp in lst)
                {
                    if (searchType.Equals("0"))
                    {
                        if (temp.TemName.IndexOf(sKeyTitle) > -1) //Equals(sKeyTitle)
                        {
                            lstRz.Add(temp);
                        }
                    }
                    else if (searchType.Equals("1"))
                    {
                        if (temp.ID.ToString().IndexOf(sKeyTitle) > -1) //Equals(sKeyTitle)
                        {
                            lstRz.Add(temp);
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
            //string sPath = BLL.TemplateInc.GetModel(gID).TemPath;
            string sPath = TemBll.IncBll.GetModel(gID).TemPath;
            
            sPath = Server.MapPath(sPath);
            Core.FSO.FObject.Delete(sPath, FsoMethod.File);
            //删除数据文件
            //BLL.TemplateInc.Delete(gID);

            TemBll.IncBll.Delete(gID);

        }

        protected Control.TextBox txtOne = new Control.TextBox();
        protected Control.DropDownList drpSearchTp = new Control.DropDownList();
        protected override void BindToolBar()
        {
            base.BindToolBar();

            ucToolBar.AddLine();

            txtOne.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtOne);

            drpSearchTp.ID = "drpSearchTp";
            ucToolBar.AddCtr(drpSearchTp);
            ListItem item= new ListItem("文件名称","0");
            ListItem item2 = new ListItem("模块ID","1");
            drpSearchTp.Items.Add(item);
            drpSearchTp.Items.Add(item2);

            base.ShowCustomSearch("查询");

        }
        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (Equals(e.CommandName, "CopyClass"))
            {
                string id = e.CommandArgument.ToString();
                //先要查出要复制的模板
                //Entity.Templates cm = BLL.TemplateInc.GetModel(new Guid(id));

                Entity.Templates cm = TemBll.IncBll.GetModel(new Guid(id));

                string sThemes  = CurrentThemeName ;// EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.PageStyle;
                Entity.Templates mdNC = new Templates(ThemesFolder);

                mdNC.TemName = "复制" + cm.TemName;
                mdNC.TemType = cm.TemType; ;
                mdNC.IsNoSysTem = false;
                mdNC.Themes = sThemes;



                //生成模板文件
                string sfName = Path.GetRandomFileName();


                //模板前缀
                //string sPre = BLL.TemplatesPC.GetTemClass(cm.TemType).PrefixName;
                string sPre = TemBll.GetTemClass(cm.TemType).PrefixName;
                

                string sFileName = string.Concat(sPre, sfName, ".aspx");
                sfName = string.Concat(IISPath, TemBll.ThemesFolder,"/", sThemes, "/pages/", sFileName);

                string sTemPath = Server.MapPath(sfName);

                if (!Core.FSO.FObject.IsExist(sTemPath, FsoMethod.File))
                {
                    string sTemHtml = Core.FSO.FObject.ReadFile(Server.MapPath(cm.TemPath));//把aspx中的内容给读出来

                    Core.FSO.FObject.WriteFile(sTemPath, sTemHtml);

                    //mdNC.TemPath = sfName;
                    mdNC.Themes = sThemes;
                    mdNC.TempFileName = sFileName;
                    mdNC.ID = Guid.NewGuid();
                    //BLL.TemplateInc.Add(mdNC);

                    TemBll.IncBll.Add(mdNC);

                }
                ////这里要刷新GridView
                base.gdList_Bind();

            }
        }
    }
}