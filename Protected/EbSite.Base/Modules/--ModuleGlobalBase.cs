//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Web;
//using System.Web.Profile;
//using EbSite.Base.DataProfile;
//using EbSite.Core.FSO;

//namespace EbSite.Base.Modules
//{
//    public class ModuleGlobalBase
//    {

//        #region 安装或卸载执行事件

//       //virtual public DbHelperBase ModuleDBHelper
//       // {
//       //     get
//       //     {
//       //         return null;
//       //     }
//       // }
       
//        /// <summary>
//        /// 模块安装时执行(安装后) 向动态组件生成事件监听类  执行安装sql脚本
//        /// </summary>
//        /// <param name="ModuleID">传来已经安装好的模块ID</param>
//        /// <param name="SetupPath">传来已经安装好的模块目录 格式是这样:/Modules/Order/</param>
//        public void __Module_Setuped(Guid ModuleID, string SetupPath, string sGlobalClassFullName)
//        {

//            AddToApp_Code(sGlobalClassFullName, ModuleID);


//            Module_Setuped(ModuleID, SetupPath);
//        }
//        /// <summary>
//        /// 模块准备卸载前执行 删除动态组件监听事件类 执行删除sql脚本
//        /// </summary>
//        /// <param name="ModuleID">传来已经安装好的模块ID</param>
//        /// <param name="SetupPath">传来已经安装好的模块目录 格式是这样:/Modules/Order/</param>
//        public void __Module_Uninstalling(Guid ModuleID, string SetupPath, string sGlobalClassFullName)
//        {
//            DelToApp_Code(sGlobalClassFullName);
//            Module_Uninstalling(ModuleID, SetupPath);
//        }

//        /// <summary>
//        /// 对外开发 模块准备卸载前执行接口
//        /// </summary>
//        /// <param name="ModuleID"></param>
//        /// <param name="SetupPath"></param>
//        virtual public void Module_Uninstalling(Guid ModuleID, string SetupPath)
//        {

//        }
//        /// <summary>
//        /// 对外开发 模块安装时执行(安装后)
//        /// </summary>
//        /// <param name="ModuleID"></param>
//        /// <param name="SetupPath"></param>
//        virtual public void Module_Setuped(Guid ModuleID, string SetupPath)
//        {

//        }

//        #endregion

//        #region 主系统全局事件监听
//       virtual public void Application_Start(object sender, EventArgs e)
//       {

//       }
//       virtual public void Application_End(object sender, EventArgs e)
//       {

//       }
//       virtual public void Application_Error(object sender, EventArgs e)
//       {

//       }
//       virtual public void Application_BeginRequest(object sender, EventArgs e)
//       {

//       }

//       virtual public void Session_Start(object sender, EventArgs e)
//       {

//       }
//       virtual public void Session_End(object sender, EventArgs e)
//       {

//       }
//       // Carry over profile property values from an anonymous to an authenticated state 
//       virtual public void Profile_MigrateAnonymous(Object sender, ProfileMigrateEventArgs e)
//       {

//       }
//       #endregion


//        #region 安装后生成动态组件


//       private string sAppCodeTem = @"

//using System;
//using System.Web.Profile;
//using EbSite.Base.Extension;
//using EbSite.Base.Extension.Manager;

//[Extension(""【模块#ModuleID#】事件监听"", ""1.0"", ""<a href=\""http://www.ebsite.net\"">EbSite</a>"")]
//public class #ClassName#
//{
//    static protected ExtensionSettings _settings = null;
//    static #ClassName#()
//    {
//        #GlobalFullName# inst = new #GlobalFullName#();
//        EbSite.Web.Global.ProfileMigrateAnonymous += new EventHandler<ProfileMigrateEventArgs>(inst.Profile_MigrateAnonymous);
//        EbSite.Web.Global.ApplicationStart += new EventHandler<EventArgs>(inst.Application_Start);
//        EbSite.Web.Global.ApplicationEnd += new EventHandler<EventArgs>(inst.Application_End);
//        EbSite.Web.Global.ApplicationError += new EventHandler<EventArgs>(inst.Application_Error);
//        EbSite.Web.Global.ApplicationBeginRequest += new EventHandler<EventArgs>(inst.Application_BeginRequest);
//        EbSite.Web.Global.SessionStart += new EventHandler<EventArgs>(inst.Session_Start);
//        EbSite.Web.Global.SessionEnd += new EventHandler<EventArgs>(inst.Session_End);
       
//    }

//}

//";

//       private string GetApp_CodePath(string sClassName)
//       {
//           return string.Concat(EbSite.Base.Host.Instance.sMapPath, "\\App_Code\\Plugins\\", sClassName, ".cs");
//       }

//       /// <summary>
//       /// 生成事件监听动态组件
//       /// </summary>
//       /// <param name="sClassName">类名称，如 EbSite.Modules.FriendLik.ModuleGlobal</param>
//       private void AddToApp_Code(string sModuleGlobalFullName, Guid mid)
//       {
//           string sClassName = sModuleGlobalFullName.Replace(".", "_");
//           string sContent = sAppCodeTem.Replace("#ModuleID#", mid.ToString()).Replace("#ClassName#", sClassName).Replace("#GlobalFullName#", sModuleGlobalFullName);//string.Format(sAppCodeTem, mid, sClassName, sModuleGlobalFullName);

//           EbSite.Core.FSO.FObject.WriteFile(GetApp_CodePath(sClassName), sContent);

//       }
//       /// <summary>
//       /// 删除事件监听组件
//       /// </summary>
//       /// <param name="sClassName"></param>
//       private void DelToApp_Code(string sClassName)
//       {
//           string sPath = GetApp_CodePath(sClassName.Replace(".", "_"));
//           if (FObject.IsExist(sPath, FsoMethod.File))
//               FObject.Delete(sPath, FsoMethod.File);
//       }

//       #endregion





//    }
//}
