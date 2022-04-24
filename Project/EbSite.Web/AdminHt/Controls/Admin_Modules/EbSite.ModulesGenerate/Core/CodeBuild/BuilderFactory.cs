using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Caching;
using EbSite.ModulesGenerate.Core.IBuilder;
using EbSite.ModulesGenerate.Core.SysPlugins;

namespace EbSite.ModulesGenerate.Core.CodeBuild
{
    public class BuilderFactory
    {
        private static Cache cache = new Cache();

        #region 程序集反射

        private static object CreateObject(string path, string TypeName)
        {
            //object obj = cache.GetObject(TypeName);
            //if (obj == null)
            //{
            //    try
            //    {
            //        obj = Assembly.Load(path).CreateInstance(TypeName);
            //        cache.SaveCache(TypeName, obj);// 写入缓存
            //    }
            //    catch (System.Exception ex)
            //    {
            //        string str = ex.Message;// 记录错误日志
            //    }
            //}
            object obj = null;
            try
            {
                obj = Assembly.Load(path).CreateInstance(TypeName);
                
            }
            catch (System.Exception ex)
            {
                string str = ex.Message;// 记录错误日志
            }

            return obj;
        }
        #endregion

        #region 加载数据访问层 代码生成对象
        public static IBuilderDALInterface CreateIDALObj(string AssemblyGuid)
        {
            return new BuilderDALInterface();
        }

        /// <summary>
        /// 创建数据访问层 代码生成对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IBuilderDAL CreateDALObj(string AssemblyGuid)
        {
            try
            {
                if (AssemblyGuid == "")
                {
                    return null;
                }
                else if (Equals(AssemblyGuid, "BuilderDAL"))
                {
                    return new BuilderDAL();
                }
                //AddIn addin = new AddIn(AssemblyGuid);
                string Assembly = "ff";
                string Classname = "ff";

                object objType = CreateObject(Assembly, Classname);
                return (IBuilderDAL)objType;
            }
            catch (SystemException ex)
            {
                string err = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 创建数据访问层 代码生成对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IBuilderDALTran CreateDALTranObj(string AssemblyGuid)
        {
            try
            {
                if (AssemblyGuid == "")
                {
                    return null;
                }
               
                //AddIn addin = new AddIn(AssemblyGuid);
                string Assembly = "ff";
                string Classname = "ff";

                object objType = CreateObject(Assembly, Classname);
                return (IBuilderDALTran)objType;
            }
            catch (SystemException ex)
            {
                string err = ex.Message;
                return null;
            }
        }

        #endregion

        #region 加载业务层 代码生成对象

        /// <summary>
        /// 创建业务层 代码生成对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IBuilderBLL CreateBLLObj(string AssemblyGuid)
        {
            try
            {
                if (AssemblyGuid == "")
                {
                    return null;
                }
                else if (Equals(AssemblyGuid, "BuilderBLL"))
                {
                    return new BuilderBLL();
                }
                //AddIn addin = new AddIn(AssemblyGuid);
                string Assembly = "ff";
                string Classname = "ff";

                object objType = CreateObject(Assembly, Classname);
                return (IBuilderBLL)objType;
            }
            catch (SystemException ex)
            {
                string err = ex.Message;
                return null;
            }
        }


        #endregion

        #region 加载Model层 代码生成对象

        /// <summary>
        /// 创建业务层 代码生成对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IBuilderModel CreateModelObj(string AssemblyGuid)
        {
            try
            {
                if (AssemblyGuid == "")
                {
                    return null;
                }
                //AddIn addin = new AddIn(AssemblyGuid);
                string Assembly = "ff";  
                string Classname = "ff";

                object objType = CreateObject(Assembly, Classname);
                return (IBuilderModel)objType;
            }
            catch (SystemException ex)
            {
                string err = ex.Message;
                return null;
            }
        }


        #endregion

        #region 加载WEB层 代码生成对象

        /// <summary>
        /// 创建业务层 代码生成对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IBuilderWeb CreateWebObj(string AssemblyGuid)
        {
            try
            {
                return new BuilderWeb();
                //if (AssemblyGuid == "")
                //{
                //    return null;
                //}
                ////AddIn addin = new AddIn(AssemblyGuid);
                //string Assembly = "ff";
                //string Classname = "ff";

                //object objType = CreateObject(Assembly, Classname);
                //return (IBuilderWeb)objType;
            }
            catch (SystemException ex)
            {
                string err = ex.Message;
                return null;
            }
        }


        #endregion
    }
}