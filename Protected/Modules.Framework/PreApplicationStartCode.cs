using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting; 

[assembly: PreApplicationStartMethod(typeof(Modules.Framework.PreApplicationStartCode), "Start")]
namespace Modules.Framework
{

    public class PreApplicationStartCode
    {
           private static bool _startWasCalled;
          public static void Start()
          {

              if (_startWasCalled)
              {

                  return;

              }

            _startWasCalled = true;
  
            //EbSite.Log.Factory.GetInstance().InfoLog("模块初始化");

            //Register virtual paths
             //HostingEnvironment.RegisterVirtualPathProvider(new CompiledVirtualPathProvider());


            //Load Plugin Folder, 
             ModuleLoader.Initialize();

         }
    }
}