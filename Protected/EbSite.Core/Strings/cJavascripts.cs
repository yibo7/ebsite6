using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI; 

namespace EbSite.Core.Strings
{
    public class cJavascripts
    {

        //public static string PackJs(string str)
        //{

        //    //stCommon.PacksJs.ECMAScriptPacker pjs = new ECMAScriptPacker();
        //    ECMAScriptPacker p = new ECMAScriptPacker(ECMAScriptPacker.PackerEncoding.Mid, true, false);

        //    return p.Pack(str);

        //}

        #region Javascript 弹出框消息处理
        /// <summary>
        /// 弹出消息框，继续执行下去
        /// </summary>
        /// <param name="Content">消息内容</param>
        public static void MessageShowNext(string Content)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');</" + "script>";


            System.Web.HttpResponse Response = HttpContext.Current.Response;

            Response.Write(script);

        }
        /// <summary>
        /// 弹出消息框，继续执行下去
        /// </summary>
        /// <param name="Content">消息内容</param>
        public static void MessageShowNext(string Content, Page cPage)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');</" + "script>";

            ClientScriptManager cs = cPage.ClientScript;
            cs.RegisterStartupScript(cPage.GetType(), "message", script);
        }
        /// <summary>
        /// 弹出消息框，并截至输出到当前位置
        /// </summary>
        /// <param name="Content">消息内容</param>
        public static void MessageShow(string Content)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');</" + "script>";
            System.Web.HttpResponse Response = HttpContext.Current.Response;

            Response.Write(script);
            Response.End();
        }

        /// <summary>
        /// 弹出消息对话框，并在点击确定后返回指定页
        /// </summary>
        /// <param name="Content">消息内容</param>
        public static void MessageShowMyreturn(string Content, string strUrl)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');location.href='" + strUrl + "';</" + "script>";
            System.Web.HttpResponse Response = HttpContext.Current.Response;

            Response.Write(script);
            Response.End();
        }


        /// <summary>
        /// 弹出消息框，并支持执行弹出后的Javascript教本，同时截至输出到当前位置
        /// </summary>
        /// <param name="Content">消息内容</param>
        /// <param name="CustomScript">自定义Javascript教本</param>
        public static void MessageShow(string Content, string CustomScript)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');" + CustomScript + "</" + "script>";
            System.Web.HttpResponse Response = HttpContext.Current.Response;

            Response.Write(script);
            Response.End();
        }


        /// <summary>
        /// 弹出消息对话框，并在点击确定后返回上一页，同时截至输出到当前位置
        /// </summary>
        /// <param name="Content">消息内容</param>
        public static void MessageShowBack(string Content)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');window.history.back();</" + "script>";
            System.Web.HttpResponse Response = HttpContext.Current.Response;

            Response.Write(script);
            Response.End();
        }

        /// <summary>
        /// 弹出消息对话框，并在点击确定后返回上一页，同时截至输出到当前位置
        /// </summary>
        /// <param name="Content">消息内容</param>
        public static void MessageClose(string Content)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');window.close();</" + "script>";
            System.Web.HttpResponse Response = HttpContext.Current.Response;

            Response.Write(script);
            Response.End();
        }
        public static void RunClientJs(string Content)
        {
            string script = "<script language=\"javascript\">" + Content + "</" + "script>";
            System.Web.HttpResponse Response = HttpContext.Current.Response;

            Response.Write(script);
            //Response.End();
        }

        //public static void RunClientJs(string sJs)
        //{

        //    //Strings.cJavascripts.RunClientJs(sJs);
        //    //ctr.Page.ClientScript.RegisterStartupScript(ctr.GetType(), "okjs", sJs, true);

        //    ScriptManager.RegisterClientScriptBlock(ctr, ctr.GetType(), "okjs", sJs, true);
        //}
        public static void RunClientJs(System.Web.UI.Control ctr, string sJs)
        {
            ctr.Page.ClientScript.RegisterClientScriptBlock(ctr.GetType(), "okjs", string.Format("<script>{0}</script>", sJs));
        }
        /// <summary>
        /// 弹出消息对话框，并在点击确定后重定向到上一页，同时截至输出到当前位置
        /// </summary>
        /// <param name="Content">消息内容</param>
        public static void MessageShowRBack(string Content)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');window.location.href=window.location.href;</" + "script>";
            System.Web.HttpResponse Response = HttpContext.Current.Response;

            Response.Write(script);
            Response.End();
        }


        /// <summary>
        /// 在输出到客户端内容的末尾追加一个弹出消息对话框
        /// </summary>
        /// <param name="Content">消息内容</param>
        /// <param name="page">当前 Page 对象</param>
        public static void MessageShow(string Content, Page page)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');</" + "script>";

            page.RegisterStartupScript("message", script);
        }


        /// <summary>
        /// 在输出到客户端内容的末尾追加一个弹出消息对话框
        /// </summary>
        /// <param name="Content">消息内容</param>
        /// <param name="CustomScript">自定义Javascript教本</param>
        /// <param name="page">当前 Page 对象</param>
        public static void MessageShow(string Content, string CustomScript, Page page)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');" + CustomScript + "</" + "script>";

            page.RegisterStartupScript("message", script);

        }


        /// <summary>
        /// 弹出消息对话框，并在点击确定后返回上一页
        /// </summary>
        /// <param name="Content">消息内容</param>
        /// <param name="page">当前 Page 对象</param>
        public static void MessageShowBack(string Content, Page page)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');window.history.back();</" + "script>";

            page.RegisterStartupScript("message", script);
        }
        #endregion

        #region "提取数据转化成客户端脚本格式"


        /// <summary>
        /// 根据指定条件生成信息列表脚本
        /// </summary>
        /// <param name="dt">提取的数据集合</param>
        /// <param name="formatTableList">需要进行脚本代码处理的字段集合，字段与字段之间用“,”隔开</param>
        /// <returns>string</returns>
        public static string ConvertDataTableToClientScript(DataTable dt, string formatTableList)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("var my" + dt.TableName + " = new My" + dt.TableName + "();\n");
            sb.Append("function My" + dt.TableName + "(){");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append("this." + dt.Columns[i] + " = new Array();");
            }
            sb.Append("}\n");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (formatTableList == "")
                    {
                        sb.AppendFormat("my" + dt.TableName + "." + dt.Columns[j] + "[{0}]=\"{1}\";", i, dt.Rows[i][dt.Columns[j]].ToString());
                    }
                    else
                    {
                        if (Validate.InArray(dt.Columns[j].ToString(), formatTableList, ','))
                        {
                            sb.AppendFormat("my" + dt.TableName + "." + dt.Columns[j] + "[{0}]=\"{1}\";", i, cConvert.convertScript(dt.Rows[i][dt.Columns[j]].ToString()));
                        }
                        else
                        {
                            sb.AppendFormat("my" + dt.TableName + "." + dt.Columns[j] + "[{0}]=\"{1}\";", i, dt.Rows[i][dt.Columns[j]].ToString());
                        }
                    }
                }
            }
            // 释放 DataTable 所占用的资源
            dt.Clear();
            dt.Dispose();

            return sb.ToString();
        }
        #endregion
    }
}
