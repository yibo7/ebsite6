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

    public class FastMenusOrder : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(context.Request.QueryString["sort"]))
            {

                string[] aFields = context.Request.QueryString["sort"].Split('|');
                //Hashtable ht = new Hashtable();
                int AllLength = aFields.Length;
                for (int i = 0; i < AllLength; i++)
                {
                    //ht.Add(aFields[i], AllLength - i);
                    EbSite.Entity.FastMenu md = BLL.FastMenu.Instance.GetEntity(int.Parse(aFields[i]));
                    md.OrderID = i + 1;
                    md.id = int.Parse(aFields[i]);
                    EbSite.BLL.FastMenu.Instance.Update(md);

                }
                context.Response.Write("ok");
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