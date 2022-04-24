using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.ajaxget
{
    /// <summary>
    /// Summary description for ModuleFieldsOrder
    /// </summary>
    public class ModuleFieldsOrder : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(context.Request.QueryString["mid"]) && !string.IsNullOrEmpty(context.Request.QueryString["sort"]))
            {
                
                // 模型类别 0 内容 1分类 2用户
                int ModuleType = Core.Utils.StrToInt(context.Request["mt"], -1);

                string[] aFields = context.Request.QueryString["sort"].Split('|');
                Hashtable ht = new Hashtable();
                int AllLength = aFields.Length;
                for (int i = 0; i < AllLength; i++)
                {
                    ht.Add(aFields[i], AllLength-i);
                }

                Guid gModuleID = new Guid(context.Request.QueryString["mid"]);

                ModelClass mc = null;

                if (ModuleType==0)
                {
                    mc = BLL.WebModel.Instance.GeModelByID(gModuleID);
                }
                else if (ModuleType==1)
                {
                    mc = BLL.ClassModel.Instance.GeModelByID(gModuleID);
                    
                }
                else if (ModuleType == 2)
                {
                    mc = BLL.UserModel.Instance.GeModelByID(gModuleID);

                } 
               if(mc!=null)
               {
                   List<ColumFiledConfigs> cfOrder = mc.Configs;

                   foreach (ColumFiledConfigs columFiledConfigs in cfOrder)
                   {
                       if (ht.ContainsKey(columFiledConfigs.ColumFiledName))
                       {
                           columFiledConfigs.OrderNum = int.Parse(ht[columFiledConfigs.ColumFiledName].ToString());
                       }

                   }
                   mc.Configs = cfOrder;

                   if (ModuleType == 0)
                   {
                       BLL.WebModel.Instance.Save();
                   }
                   else if (ModuleType == 1)
                   {
                       BLL.ClassModel.Instance.Save();
                   }
                   else if (ModuleType == 2)
                   {
                       BLL.UserModel.Instance.Save();
                   } 
                   context.Response.Write("ok");
               }
                


                
            }
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}