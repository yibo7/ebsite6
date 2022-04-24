using System;
using System.Collections.Generic;
using System.Text;
using EbSite.Base;
using EbSite.Base.Modules;
using EbSite.Entity.Module;

namespace EbSite.BLL.ModulesBll
{
    public class MenusForUser : ModuleMenu
    {
        public MenusForUser(Guid ModuleID)
            : base(ModuleID)
        {

        }

        //override protected string DataBaseFile
        //{
        //    get
        //    {
        //        return "DataStore/Menus_User.txt";
        //    }
        //}
        override protected string PagePath
        {
            get
            {
                return "UserPages";
            }
        }
        override public string MenuPath
        {
            get
            {
                return string.Concat(_sModulePath, "/DataStore/Menus/UserPage/");
            }
        }

        //override public List<MPage> GetMPages()
        //{
        //    List<MPage> lst = new List<MPage>();

        //    Modules.Instance.GetAllModules[0].
        //}

        //override public void ResetMenu()
        //{
        //    EbSite.BLL.MenusForUser.Instance.DeleteByModulID(base.Id);
        //}

        //override public void AddModuleNameToSysMemu(Guid menuid, string sMunuName, string ImageUrl, Guid ModulesID, Guid ParentID)
        //{
        //    AddMenuToSysMemu(menuid, sMunuName, ImageUrl, ModulesID, ParentID, "");
        //}

        override public void AddMenuToSysMemu(Guid menuid, string sMunuName, string ImageUrl, Guid ModulesID, Guid ParentID, string PageUrl, string ParentUrl, ThemeType tt)
        {
            List<ModulePageInfo> mds = GetSubMenu(menuid);
           if (mds.Count > 0)
           {
               EbSite.Entity.MenusForUser mdMenu = new Entity.MenusForUser();
               mdMenu.id = menuid;
               mdMenu.PageUrl = ParentUrl;
               mdMenu.MenuName = sMunuName;
               mdMenu.ModulesID = ModulesID;
               mdMenu.ModuleMenuID = mds[0].id;//这里有点难理解，只是为了默认打开父菜单是定向到第一个菜单
               mdMenu.ParentID = Guid.Empty;
               
               mdMenu.AddTime = DateTime.Now;
               mdMenu.ImageUrl = ImageUrl;//先加一个默认图标
               mdMenu.MenuType = tt;
               if (mdMenu.MenuType == ThemeType.PC)
               {
                   mdMenu.Target = Core.Strings.cConvert.GetQuanPing(sMunuName).Trim().ToLower();
               }
               else
               {
                   mdMenu.Target = string.Concat(Core.Strings.cConvert.GetQuanPing(sMunuName).Trim().ToLower(),"m");
               }

               BLL.MenusForUser.Instance.Add(mdMenu);
           }

           

        }
        override public void DeleteByModuleID(Guid ModuleID)
        {
            EbSite.BLL.MenusForUser.Instance.DeleteByModulID(base.Id);
        }

    }
}
