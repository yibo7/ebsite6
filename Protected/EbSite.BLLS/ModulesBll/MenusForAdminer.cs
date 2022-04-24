using System;
using System.Collections.Generic;
using System.Text;
using EbSite.Base;
using EbSite.Entity.Module;

namespace EbSite.BLL.ModulesBll
{
    public class MenusForAdminer : ModuleMenu
    {
        public MenusForAdminer(Guid ModuleID):base(ModuleID) 
        {
            
        }

        //override protected  string DataBaseFile
        //{
        //    get
        //    {
        //        return "DataStore/Menus_Admin.txt";
        //    }
        //}
        override protected string PagePath
        {
            get
            {
                return "AdminPages";
            }
        }
        override public string MenuPath
        {
            get
            {
                return string.Concat(_sModulePath, "/DataStore/Menus/AdminPage/");
            }
        }
        ///// <summary>
        ///// 复位菜单－－公用　卸载模块时也要用
        ///// </summary>
        //public void ResetMenu(Guid sModuleID)
        //{
        //    List<Entity.Menus> list = BLL.Menus.Instance.GetListArray("modulesId='" + sModuleID + "'");

        //    foreach (Entity.Menus menuse in list)
        //    {
        //        BLL.Menus.Instance.Delete(menuse.id);
        //    }
        //}
        override public void AddModuleNameToSysMemu(Guid menuid, string sMunuName, string ImageUrl, Guid ModulesID, Guid ParentID)
        {
            AddMenuToSysMemu(menuid, sMunuName, ImageUrl, ModulesID, ParentID, "", "", ThemeType.PC);
        }

        override public void AddMenuToSysMemu(Guid menuid, string sMunuName, string ImageUrl, Guid ModulesID, Guid ParentID, string PageUrl, string ParentUrl, ThemeType tt)
        {
            Entity.Menus mdmu = new Entity.Menus();
            mdmu.id = menuid;
            mdmu.ImageUrl = ImageUrl;
            mdmu.MenuName = sMunuName;
            mdmu.PageUrl = PageUrl;
            mdmu.ParentID = ParentID;
            mdmu.ModulesID = ModulesID;
            EbSite.BLL.Menus.Instance.Add(mdmu);

            
        }
        override public void DeleteByModuleID(Guid ModuleID)
        {
            BLL.Menus.Instance.DeleteByModuleID(base.Id);
        }

    }
}
