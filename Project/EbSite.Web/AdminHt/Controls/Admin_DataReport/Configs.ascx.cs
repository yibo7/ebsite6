using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.BLL.ModulesBll;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_DataReport
{
    public partial class Configs : UserControlBaseSave
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
               
            }
        }
        public override string Permission
        {
            get
            {
                return "322";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
            throw new NotImplementedException();
        }
        override protected void SaveModel()
        {
            //this.SaveConfig();
        }

        protected void bntMakeMenu_Click(object sender, EventArgs e)
        {
            Guid sParentId = new Guid("00da063f-37b2-4c8c-ac3c-2e41152a6542");



            //清空之前数据
            List<Entity.Menus> lstDels = BLL.Menus.Instance.GetMenusByParentID(sParentId);
            foreach (Entity.Menus delMenu in lstDels)
            {
                if (!Equals(delMenu.id, Guid.Parse("66c2f457-06e3-464f-b618-4e6e05548ae9")))//报表配置不能删除
                {
                    BLL.Menus.Instance.Delete(delMenu.id);
                }
                
            }


            ReportConfigBll bll = new ReportConfigBll();
            List<EbSite.Core.JsonFile<Entity.ReportConfig>> Configs = bll.configsJsonFiles;

            foreach (EbSite.Core.JsonFile<Entity.ReportConfig> cf in Configs)
            {
                Entity.Menus menu = new Entity.Menus();
                menu.ParentID = sParentId;
                menu.MenuName = cf.Model.ReportName;
                menu.ImageUrl = cf.Model.IcoPath;
                menu.OrderID = cf.Model.OrderId;
                menu.Target = "mainbody";
                menu.PageUrl = string.Concat("Admin_DataReport.aspx?key=", cf.Id) ;
                menu.CtrPath = "Reports.ascx";
                BLL.Menus.Instance.Add(menu);
            }

            if (Configs.Count > 0)
            {
                lbInfo.Text = string.Format("生成成功,共生成菜单{0}个", Configs.Count);
                Core.Utils.AppRestart();
            }
            else
            {
                lbInfo.Text = "没有可生成的报表菜单";
            }

            


        }

    }
}