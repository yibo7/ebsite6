using System;
using System.Web;

namespace EbSite.Core.URLRewriterBase
{
	/// <summary>
	/// The base class for module rewriting.  This class is abstract, and therefore must be derived from.
	/// </summary>
	/// <remarks>Provides the essential base functionality for a rewriter using the HttpModule approach.</remarks>
	public abstract class BaseModuleRewriter : IHttpModule
	{
		/// <summary>
		/// Executes when the module is initialized.
		/// </summary>
		/// <param name="app">A reference to the HttpApplication object processing this request.</param>
		/// <remarks>Wires up the HttpApplication's AuthorizeRequest event to the
		/// <see cref="BaseModuleRewriter_AuthorizeRequest"/> event handler.</remarks>
		public virtual void Init(HttpApplication app)
		{
            // WARNING!  This does not work with Windows authentication!
			// If you are using Windows authentication, change to app.BeginRequest
			app.AuthorizeRequest += new EventHandler(this.BaseModuleRewriter_AuthorizeRequest);
            //app.Error += new EventHandler(context_Error);

		}
        private void context_Error(object sender, EventArgs e)
        {
            //此处处理异常
            HttpContext ctx = HttpContext.Current;
            //HttpResponse response = ctx.Response;
            //HttpRequest request = ctx.Request;

            //获取到HttpUnhandledException异常，这个异常包含一个实际出现的异常
            Exception ex = ctx.Server.GetLastError();
            //实际发生的异常
            Exception iex = ex.InnerException;

            //response.Write("来自ErrorModule的错误处理<br />");
            //response.Write(iex.Message);


            //string info = "未知错误";
            //string title = string.Empty;
            if (Base.Configs.SysConfigs.ConfigsControl.Instance.IsOpenAppLog)
            {
                string hostIP = "";
                string path = "";
                string referer = "";
                string useragent = string.Empty;
                if (HttpContext.Current != null)
                {
                    path = HttpContext.Current.Request.RawUrl;
                    hostIP = HttpContext.Current.Request.UserHostAddress;
                    referer = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
                    useragent = HttpContext.Current.Request.ServerVariables["http_user_agent"];
                    //GetLastError(HttpContext.Current.Server.GetLastError(), ref title, ref info);
                }

                Entity.Logs mdLogs = new Entity.Logs();
                mdLogs.Title = string.Concat("来自ErrorModule的异常处理:", path, " 来路:", referer);
                mdLogs.Description = string.Concat(path, "详细:\n", iex.Message, "\nUserAgent:", useragent);
                mdLogs.IP = hostIP;
                mdLogs.AddDate = DateTime.Now;
                BLL.AppErrLog.InsertLogs(mdLogs);

                ctx.Server.ClearError();
                //response.StatusCode = 404;
                //response.End();
            }
            //if (Base.Configs.SysConfigs.ConfigsControl.Instance.IsErrFriend)
            //{

            //    Base.Host.Instance.Tips("访问出错了", "抱歉,此页面无法访问!", "");
            //}

            
            //response.Redirect(string.Concat(EbSite.Base.AppStartInit.IISPath, "ebtips.aspx?info=", "来自ErrorModule的异常处理,具体原因请查看错误日志"));

            //HttpContext.Current.Response.Write("来自Global的错误处理<br />");


           
        }
		/// <summary>
		/// 
		/// </summary>
		public virtual void Dispose() {}

		/// <summary>
		/// Called when the module's AuthorizeRequest event fires.
		/// </summary>
		/// <remarks>This event handler calls the <see cref="Rewrite"/> method, passing in the
		/// <b>RawUrl</b> and HttpApplication passed in via the <b>sender</b> parameter.</remarks>
		protected virtual void BaseModuleRewriter_AuthorizeRequest(object sender, EventArgs e)
		{
			HttpApplication app = (HttpApplication) sender;
			Rewrite(app.Request.Path, app);
		}

		/// <summary>
		/// The <b>Rewrite</b> method must be overriden.  It is where the logic for rewriting an incoming
		/// URL is performed.
		/// </summary>
		/// <param name="requestedPath">The requested RawUrl.  (Includes full path and querystring.)</param>
		/// <param name="app">The HttpApplication instance.</param>
		protected abstract void Rewrite(string requestedPath, HttpApplication app);
	}
}
