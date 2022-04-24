using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace EbSite.Base.Modules
{
    /// <summary>
    /// 需要在模块里添加启动触发入口，可重写此接口，会在每次request判断是否已启动，如果没有启动，执行启动,方便webform作为ebsite扩展事件入口
    /// </summary>
    public interface ModuleStartInit
    {
        void Start();


        ///// <summary>
        ///// 模块安装时执行(安装后) 向动态组件生成事件监听类  执行安装sql脚本
        ///// </summary>
        ///// <param name="ModuleID">传来已经安装好的模块ID</param>
        ///// <param name="SetupPath">传来已经安装好的模块目录 格式是这样:/Modules/Order/</param>
        //void __Module_Setuped(Guid ModuleID, string SetupPath);
        ///// <summary>
        ///// 模块准备卸载前执行 删除动态组件监听事件类 执行删除sql脚本
        ///// </summary>
        ///// <param name="ModuleID">传来已经安装好的模块ID</param>
        ///// <param name="SetupPath">传来已经安装好的模块目录 格式是这样:/Modules/Order/</param>
        //void __Module_Uninstalling(Guid ModuleID, string SetupPath);
    }

    public class ModuleStartInitBll
    {
        public static void ModuleStart(HttpContext context)
        {
            try
            {
                //有没有必要从安装目录获取,以确保模块已经安装
                DirectoryInfo info = new DirectoryInfo(context.Server.MapPath(string.Concat(Core.Utils.GetIISPath, "bin")));

                FileInfo[] fs = info.GetFiles("EbSite.Modules.*.dll");
                foreach (var file in fs)
                {
                    byte[] btsBytes = File.ReadAllBytes(file.FullName);
                    Assembly asm = Assembly.Load(btsBytes);
                    Type[] types = asm.GetTypes();
                    for (int i = 0; i < types.Length; i++)
                    {
                        // 避免加载到抽象类，它们不能被实例化
                        if (types[i].IsAbstract)
                            continue;
                        Type[] interfaces = types[i].GetInterfaces();
                        foreach (Type iface in interfaces)
                        {
                            if (iface == typeof(ModuleStartInit))
                            {
                                ModuleStartInit tmpf = ModuleStartInitBll.CreateInstance<ModuleStartInit>(asm, types[i]);
                                tmpf.Start();
                                
                                break;
                            }
                        }
                    }
                }







                //EbSite.Base.ModuleStartInit _instance = (EbSite.Base.ModuleStartInit)Activator.CreateInstance(Type.GetType(string.Format("EbSite.Data.User.{0}.DataProviderUser, EbSite.Data.User.{0}", Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerTypeUser), false, true));
            }
            catch (Exception e)
            {
                Log.Factory.GetInstance().ErrorLog(string.Format("加载模块ModuleStartInit启动失败:{0}", e.Message));
            }
        }
        /// <summary>
        /// 创建一个提供者的实例
        /// </summary>
        /// <typeparam name="T">提供者接口类型</typeparam>
        /// <param name="asm">包含指定类型的程序集</param>
        /// <param name="type">要创建的实例类型</param>
        /// <returns>创建的实例，或者 <c>null</c>.</returns>
        public static T CreateInstance<T>(Assembly asm, Type type) where T : class, ModuleStartInit
        {
            T instance;
            try
            {
                instance = asm.CreateInstance(type.ToString()) as T;
                return instance;
            }
            catch
            {
                throw;
            }
        }

    }
}
