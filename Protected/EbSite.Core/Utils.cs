using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EbSite.Base.Static;
using EbSite.Control;
using EbSite.Entity;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using DropDownList = System.Web.UI.WebControls.DropDownList;
using RadioButtonList = System.Web.UI.WebControls.RadioButtonList;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace EbSite.Core
{
    public class Utils
    {

        /// <summary>
        /// 获取来路
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>System.String.</returns>
        public static string GetReferer(HttpContext context)
        {
            string url = context.Request["referer"];
            
            if (string.IsNullOrEmpty(url))
                url = context.Request.ServerVariables["Http_Referer"];
            if (string.IsNullOrEmpty(url)&&!Equals(context.Request.UrlReferrer,null))
                url = context.Request.UrlReferrer.AbsolutePath;
            if (string.IsNullOrEmpty(url))
                url = context.Request.Url.ToString();

            return url;
        }
        public static bool IsGuid(string strSrc)
        {
            Guid g = Guid.Empty;
            return Guid.TryParse(strSrc, out g);
        }
        public static void AppRestart()
        {
            string ConfigPath = HttpContext.Current.Request.PhysicalApplicationPath + "web.config";
            File.SetLastWriteTimeUtc(ConfigPath, DateTime.UtcNow);
        }
        public static string CreatUpload(string UpBtnID, string Ext, int AllowSize, string SaveFolder)
        {
            return CreatUpload(UpBtnID, Ext, AllowSize, SaveFolder, false, null, true, false);
        }
        public static string CreatUpload(string UpBtnID, string Ext, int AllowSize, string SaveFolder, bool isLocal)
        {
            return CreatUpload(UpBtnID, Ext, AllowSize, SaveFolder, false, null, true, false, isLocal);
        }
        /// <summary>
        /// 生成前端上传js
        /// </summary>
        /// <param name="UpBtnID">触发上传按钮</param>
        /// <param name="Ext">允许上传的文件类型，以逗号分开，如jpg,gif,png,zip</param>
        /// <param name="AllowSize">允许上传的大小最大值，单位为kb,如1024，代表上传的文件大小不能超过1兆</param>
        /// <param name="SaveFolder">文件的保存目录，是一个文件夹的名字，如 img,可以为空</param>
        /// <param name="IsSmallimg">是否开启缩略图，前提条件是:上传的文件类型必要是图片</param>
        /// <param name="SmallImgSizes">如果IsSmallimg为true时，你还可以通过此参数设置缩略图的数量与规格，格式为ew []{"50*50","80*80","90*90","120*200"},上传后将生成4组不同规格的缩略图</param>
        /// <returns></returns>
        static public string CreatUpload(string UpBtnID, string Ext, int AllowSize, string SaveFolder, bool IsSmallimg, string[] SmallImgSizes, bool isinit, bool isjs)
        {
            return CreatUpload(UpBtnID, Ext, AllowSize, SaveFolder, IsSmallimg, SmallImgSizes, isinit, isjs, false);
        }
        /// <summary>
        /// 生成前端上传js
        /// </summary>
        /// <param name="UpBtnID">触发上传按钮</param>
        /// <param name="Ext">允许上传的文件类型，以逗号分开，如jpg,gif,png,zip</param>
        /// <param name="AllowSize">允许上传的大小最大值，单位为kb,如1024，代表上传的文件大小不能超过1兆</param>
        /// <param name="SaveFolder">文件的保存目录，是一个文件夹的名字，如 img,可以为空</param>
        /// <param name="IsSmallimg">是否开启缩略图，前提条件是:上传的文件类型必要是图片</param>
        /// <param name="SmallImgSizes">如果IsSmallimg为true时，你还可以通过此参数设置缩略图的数量与规格，格式为ew []{"50*50","80*80","90*90","120*200"},上传后将生成4组不同规格的缩略图</param>
        /// <returns></returns>
        static public string CreatUpload(string UpBtnID, string Ext, int AllowSize, string SaveFolder, bool IsSmallimg, string[] SmallImgSizes, bool isinit, bool isjs, bool isLocal)
        {
            //document.domain = 'bm.com';
            StringBuilder sbBuilder = new StringBuilder("<script>");

            //sbBuilder.Append("document.domain = 'beimai.com';");

            string sUploadID = "objAspNetUpload";//string.Concat("objAspNetUpload", UpBtnID);
            sbBuilder.AppendFormat("var {0};", sUploadID);
            sbBuilder.Append("In.ready('upload', function () {");
            sbBuilder.AppendFormat("{0} = new AspNetUpload();", sUploadID);
            sbBuilder.AppendFormat("{0}.UpBtnID = '{1}';", sUploadID, UpBtnID);
            sbBuilder.AppendFormat("{0}.Ext = '{1}';", sUploadID, Ext);
            sbBuilder.AppendFormat("{0}.AllowSize = '{1}';", sUploadID, AllowSize);
            sbBuilder.AppendFormat("{0}.SaveFolder = '{1}';", sUploadID, HttpContext.Current.Server.UrlEncode(Base.Host.Instance.EncodeByKey(SaveFolder)));
            sbBuilder.AppendFormat("{0}.ValStr = '{1}';", sUploadID, Base.Host.Instance.EncodeByMD5(string.Concat(SaveFolder, AllowSize, Base.Host.Instance.EncodeByKey(Ext), Base.Host.Instance.OnlineID, Base.Host.Instance.UserID)));
            if (IsSmallimg)
            {
                sbBuilder.AppendFormat("{0}.IsSmallimg = {1};", sUploadID, IsSmallimg ? "true" : "false");
                if (!Equals(SmallImgSizes, null))
                    sbBuilder.AppendFormat("{0}.SmallImgSizes = '{1}';", sUploadID, string.Join("_", SmallImgSizes));
            }
            if (isLocal)
                sbBuilder.AppendFormat("{0}.IsLocal=true;", sUploadID);
            if (isinit)
                sbBuilder.AppendFormat("{0}.Init();", sUploadID);

            if (isjs)
                sbBuilder.Append("});<\\/script>");
            else
                sbBuilder.Append("});</script>");

            return sbBuilder.ToString();
        }

        public  static int GetPageCount(int iTotalCount, int iPageSize)
        {

            if (iTotalCount <= 0 || iPageSize <= 0)
                return 1;
            else
                return ((iTotalCount + iPageSize) - 1) / iPageSize;
           
        }

        /// <summary>
        /// 获取当前样式
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <param name="CustomClassName"></param>
        /// <param name="CurrentClassName"></param>
        /// <returns></returns>
        static public string GetCurrentClass(object id1,object id2,string CustomClassName, string CurrentClassName)
        {
           
            if (Equals(id1.ToString().ToLower(), id2.ToString().ToLower()))
            {
                return CurrentClassName;
            }

            return CustomClassName;
        }

        static public bool IsMatchReWrite(string sUrl, string rg)
        {
            Match mc = Regex.Match(sUrl, rg);
            return mc.Success;
        }
        public static T JsonToObj<T>(string jsonString)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(ms);
            }
        }
        public static CultureInfo GetDefaultCulture(string sCulture)
        {

            if (Strings.Validate.StringIsNullOrWhitespace(sCulture) ||
                sCulture.Equals("Auto", StringComparison.OrdinalIgnoreCase))
            {
                return CultureInfo.InstalledUICulture;
            }

            return CultureInfo.CreateSpecificCulture(sCulture);
        }
        static public void SetValueFromControl(System.Web.UI.Control uc, string Value)
        {
            Type tp = uc.GetType();
            if (uc is IUserContrlBase)
            {
                IUserContrlBase vl = (IUserContrlBase)uc;

                vl.CtrValue = Value;
            }
            else if (Equals(tp, typeof(EbSite.Control.TextBox)))
            {
                EbSite.Control.TextBox myuc = (EbSite.Control.TextBox)uc;
                myuc.Text = Value;
            }
            else if (Equals(tp, typeof(System.Web.UI.WebControls.TextBox)))
            {
                System.Web.UI.WebControls.TextBox myuc = (System.Web.UI.WebControls.TextBox)uc;
                myuc.Text = Value;
            }
            else if (Equals(tp, typeof(DropDownList)))
            {
                DropDownList myuc = (DropDownList)uc;
                myuc.SelectedValue = Value;
            }
            else if (Equals(tp, typeof(EbSite.Control.DropDownList)))
            {
                EbSite.Control.DropDownList myuc = (EbSite.Control.DropDownList)uc;
                myuc.SelectedValue = Value;
            }
            else if (Equals(tp, typeof(DropDownList)))
            {
                DropDownList myuc = (DropDownList)uc;
                myuc.SelectedValue = Value;
            }
            else if (Equals(tp, typeof(EbSite.Control.RadioButtonList)))
            {
                EbSite.Control.RadioButtonList myuc = (EbSite.Control.RadioButtonList)uc;
                myuc.SelectedValue = Value;
            }
            else if (Equals(tp, typeof(RadioButtonList)))
            {
                RadioButtonList myuc = (RadioButtonList)uc;
                myuc.SelectedValue = Value;
            }
            else if (Equals(tp, typeof(System.Web.UI.WebControls.HiddenField)))
            {
                System.Web.UI.WebControls.HiddenField myuc = (System.Web.UI.WebControls.HiddenField)uc;
                myuc.Value = Value;
            }
            else if (Equals(tp, typeof(EbSite.Control.Editor)))
            {
                EbSite.Control.Editor myuc = (EbSite.Control.Editor)uc;
                myuc.Text = Value;
            }
            else if (Equals(tp, typeof(EbSite.Control.DatePicker)))
            {
                EbSite.Control.DatePicker myuc = (EbSite.Control.DatePicker)uc;
                myuc.Value = Value;
            }
            else if (Equals(tp, typeof(EbSite.Control.WebUploaderFile))) //SWFUpload
            {
                //EbSite.Control.SWFUpload myuc = (EbSite.Control.SWFUpload)uc;
                //myuc.ValSavePath = Value;
                EbSite.Control.WebUploaderFile myuc = (EbSite.Control.WebUploaderFile)uc;
                myuc.CtrValue = Value;
            }
            else if (Equals(tp, typeof(EbSite.Control.CheckBox)))
            {
                EbSite.Control.CheckBox cuc = (EbSite.Control.CheckBox)uc;
                if (!string.IsNullOrEmpty(Value))
                {
                    cuc.Checked = bool.Parse(Value);
                }
                
            }
            else if (Equals(tp, typeof(System.Web.UI.WebControls.CheckBox)))
            {
                System.Web.UI.WebControls.CheckBox cuc = (System.Web.UI.WebControls.CheckBox)uc;
                if (!string.IsNullOrEmpty(Value))
                {
                    cuc.Checked = bool.Parse(Value);
                }
            }

        }
        static public string GetValueFromControl(System.Web.UI.Control uc)
        {
            string sValue = string.Empty;
            Type tp = uc.GetType();
            if (uc is IUserContrlBase)
            {
                IUserContrlBase vl = (IUserContrlBase)uc;

                sValue = vl.CtrValue;
            }
            else if (Equals(tp, typeof(EbSite.Control.TextBox)))
            {
                EbSite.Control.TextBox cuc = (EbSite.Control.TextBox)uc;
                sValue = cuc.Text;
            }
            else if (Equals(tp, typeof(TextBox)))
            {
                TextBox cuc = (TextBox)uc;
                sValue = cuc.Text;
            }
            else if (Equals(tp, typeof(EbSite.Control.DropDownList)))
            {
                EbSite.Control.DropDownList cuc = (EbSite.Control.DropDownList)uc;
                sValue = cuc.SelectedValue;
            }
            else if (Equals(tp, typeof(DropDownList)))
            {
                DropDownList cuc = (DropDownList)uc;
                sValue = cuc.SelectedValue;
            }
            else if (Equals(tp, typeof(EbSite.Control.RadioButtonList)))
            {
                EbSite.Control.RadioButtonList cuc = (EbSite.Control.RadioButtonList)uc;
                sValue = cuc.SelectedValue;
            }
            else if (Equals(tp, typeof(RadioButtonList)))
            {
                RadioButtonList cuc = (RadioButtonList)uc;
                sValue = cuc.SelectedValue;
            }
            else if (Equals(tp, typeof(System.Web.UI.WebControls.HiddenField)))
            {
                System.Web.UI.WebControls.HiddenField cuc = (System.Web.UI.WebControls.HiddenField)uc;
                sValue = cuc.Value;
            }
            else if (Equals(tp, typeof(EbSite.Control.Editor)))
            {
                EbSite.Control.Editor cuc = (EbSite.Control.Editor)uc;
                sValue = cuc.Text;
            }

            else if (Equals(tp, typeof(EbSite.Control.DatePicker)))
            {
                EbSite.Control.DatePicker cuc = (EbSite.Control.DatePicker)uc;
                sValue = cuc.Value;
            }
            else if (Equals(tp, typeof(EbSite.Control.WebUploaderFile)))
            {
                EbSite.Control.WebUploaderFile cuc = (EbSite.Control.WebUploaderFile)uc;
                sValue = cuc.CtrValue;
            }
            else if (Equals(tp, typeof(EbSite.Control.CheckBox)))
            {
                EbSite.Control.CheckBox cuc = (EbSite.Control.CheckBox)uc;
                sValue = cuc.Checked.ToString();
            }
            else if (Equals(tp, typeof(System.Web.UI.WebControls.CheckBox)))
            {
                System.Web.UI.WebControls.CheckBox cuc = (System.Web.UI.WebControls.CheckBox)uc;
                sValue = cuc.Checked.ToString();
            }



            return sValue;
        }

        public static void OutPutExcel(System.Web.UI.Control ctl, string FileName, string Type)
        {

            //HttpContext.Current.Response.Charset = "UTF-8";
            //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
            //HttpContext.Current.Response.ContentType = Type;
            //HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + "" + FileName);
            //ctl.Page.EnableViewState = false;
            //System.IO.StringWriter tw = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            //ctl.RenderControl(hw);
            //HttpContext.Current.Response.Write(tw.ToString());
            //HttpContext.Current.Response.End();

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            System.Web.UI.Page page = new System.Web.UI.Page();
            HtmlForm form = new HtmlForm();
            ctl.EnableViewState = false;
            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;
            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(ctl);
            page.RenderControl(htw);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = Type;
            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", FileName));
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = Encoding.Default;
            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.Response.End();
        }//导入
        public static void OutPutExcel(System.Web.UI.Control ctl)
        {
            OutPutExcel(ctl, string.Concat(DateTime.Now.ToString("yyyyMMddHHmmss"), ".xls"), "application/vnd.ms-excel");
        }//导入excel
        public static void OutPutWord(System.Web.UI.Control ctl)
        {
            OutPutExcel(ctl, string.Concat(DateTime.Now.ToString("yyyyMMddHHmmss"), ".doc"), "application/ms-word");
        }//导入word
        public static void RunClientJs(System.Web.UI.Control ctr, string sJs)
        {

            //Strings.cJavascripts.RunClientJs(sJs);
            ctr.Page.ClientScript.RegisterStartupScript(ctr.GetType(), "okjs", sJs, true);

            //ScriptManager.RegisterClientScriptBlock(ctr, ctr.GetType(), "okjs", sJs, true);
        }
        /// <summary>
        /// 获取一个cookie的值 
        /// </summary>
        /// <param name="cHeader"></param>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static string GetSingleVlue(string cHeader, string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[cHeader] != null && HttpContext.Current.Request.Cookies[cHeader][strName] != null)
            {
                return HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[cHeader][strName].ToString());
            }

            return "";
        }

        /// <summary>
        /// Strips all illegal characters from the specified title.
        /// </summary>
        public static string RemoveIllegalCharacters(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            text = text.Replace(":", string.Empty);
            text = text.Replace("/", string.Empty);
            text = text.Replace("?", string.Empty);
            text = text.Replace("#", string.Empty);
            text = text.Replace("[", string.Empty);
            text = text.Replace("]", string.Empty);
            text = text.Replace("@", string.Empty);
            text = text.Replace("*", string.Empty);
            text = text.Replace(".", string.Empty);
            text = text.Replace(",", string.Empty);
            text = text.Replace("\"", string.Empty);
            text = text.Replace("&", string.Empty);
            text = text.Replace("'", string.Empty);
            text = text.Replace(" ", "-");
            text = RemoveDiacritics(text);
            text = RemoveExtraHyphen(text);

            return HttpUtility.UrlEncode(text).Replace("%", string.Empty);
        }
        private static string RemoveExtraHyphen(string text)
        {
            if (text.Contains("--"))
            {
                text = text.Replace("--", "-");
                return RemoveExtraHyphen(text);
            }

            return text;
        }

        private static String RemoveDiacritics(string text)
        {
            String normalized = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < normalized.Length; i++)
            {
                Char c = normalized[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString();
        }
        /// <summary>
        /// 绑定a-z到DropDownList的选项
        /// </summary>
        /// <param name="droList"></param>
        public static void bind_drpabc(DropDownList droList)
        {
            for (int i = 65; i <= 90; i++)
            {
                ListItem li = new ListItem(((char)i).ToString(), ((char)i).ToString());
                if (i == 65) li.Selected = true;
                droList.Items.Add(li);
            }
        }

        //public static string cutstring(string str, int ilen)
        //{
        //    return Strings.GetString.CutLen(str, ilen);
        //}
        public static string strEncode(string str)
        {
            return Strings.cConvert.strEncode(str);
        }
        public static string strDecode(string str)
        {
            return Strings.cConvert.strDecode(str);
        }
        /// <summary>
        /// 验证码生成的取值范围
        /// </summary>
        private static string[] verifycodeRange = { "1","2","3","4","5","6","7","8","9",
                                                    "a","b","c","d","e","f","g",
                                                    "h",    "j","k",    "m","n",
                                                        "p","q",    "r","s","t",
                                                    "u","v","w",    "x","y"
                                                  };
        /// <summary>
        /// 生成验证码所使用的随机数发生器
        /// </summary>
        private static Random verifycodeRandom = new Random();

        /// <summary>
        /// 产生验证码
        /// </summary>
        /// <param name="len">长度</param>
        /// <param name="OnlyNum">是否仅为数字</param>
        /// <returns>string</returns>
        public static string CreateAuthStr(int len, bool OnlyNum)
        {
            int number;
            StringBuilder checkCode = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                if (!OnlyNum)
                    number = verifycodeRandom.Next(0, verifycodeRange.Length);
                else
                    number = verifycodeRandom.Next(0, 10);

                checkCode.Append(verifycodeRange[number]);
            }
            return checkCode.ToString();
        }
        private static string CurrentDomain
        {
            get
            {
                return Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName;
            }
        }
        //下载网页
        public static string GetData(string strWebUrl)
        {
            string text1 = "";
           // string name = "gb2312";
            //name = "Big5";
            try
            {
                text1 = Core.WebUtility.LoadURLString(string.Concat(CurrentDomain, strWebUrl));
                
            }
            catch (Exception exc)
            {
                text1 = string.Concat(Base.Configs.HtmlConfigs.ConfigsControl.Instance.GetHtmlErr, ":源URL-", strWebUrl, "原因-", exc.Message);

            }
            return text1;
        }
        //解密
        private static Stream Gzip(HttpWebResponse HWResp)
        {
            Stream stream1 = null;
            if (HWResp.ContentEncoding == "gzip")
            {
                stream1 = new GZipInputStream(HWResp.GetResponseStream());
            }
            else
            {
                if (HWResp.ContentEncoding == "deflate")
                {
                    stream1 = new InflaterInputStream(HWResp.GetResponseStream());
                }
            }
            if (stream1 == null)
            {
                return HWResp.GetResponseStream();
            }
            MemoryStream stream2 = new MemoryStream();
            int count = 0x800;
            byte[] buffer = new byte[0x800];
            goto A;
        A:
            count = stream1.Read(buffer, 0, count);
            if (count > 0)
            {
                stream2.Write(buffer, 0, count);
                goto A;
            }
            stream2.Seek((long)0, SeekOrigin.Begin);
            return stream2;
        }

        #region Code Assemblies
        /// <summary>
        /// This method returns all code assemblies in app_code
        /// If app_code has subdirectories for c#, vb.net etc
        /// Each one will come back as a separate assembly
        /// So we can support extensions in multiple languages
        /// </summary>
        /// <returns>List of code assemblies</returns>
        public static ArrayList CodeAssemblies()
        {
            ArrayList codeAssemblies = new ArrayList();
            CompilationSection s = null;
            try
            {
                string assemblyName = "__code";
                try
                {
                    s = (CompilationSection)WebConfigurationManager.GetSection("system.web/compilation");
                }
                catch (System.Security.SecurityException)
                {
                    // No read permissions on web.config due to the trust level (must be High or Full)
                }

                if (s != null && s.CodeSubDirectories != null && s.CodeSubDirectories.Count > 0)
                {
                    for (int i = 0; i < s.CodeSubDirectories.Count; i++)
                    {
                        assemblyName = "App_SubCode_" + s.CodeSubDirectories[i].DirectoryName;
                        codeAssemblies.Add(Assembly.Load(assemblyName));
                    }
                }
                else
                {
                    Type t = Type.GetType("Mono.Runtime");
                    if (t != null) assemblyName = "App_Code";
                    codeAssemblies.Add(Assembly.Load(assemblyName));
                }
                //获取dll里的插件,目前只用app_code的,所以不调用以下方法
                //GetCompiledExtensions(codeAssemblies);
            }
            catch (System.IO.FileNotFoundException) {/*ignore - code directory has no files*/}

            return codeAssemblies;
        }

        /// <summary>
        /// To support compiled extensions
        /// This methed looks for DLLs in the "/bin" folder
        /// and if assembly compiled with configuration
        /// attributed set to "BlogEngineExtension" it will
        /// be added to the list of code assemlies
        /// </summary>
        /// <param name="assemblies">List of code assemblies</param>
        //public static void GetCompiledExtensions(ArrayList assemblies)
        //{
        //string s = Path.Combine(HttpContext.Current.Server.MapPath("~/"), "bin");
        //string[] fileEntries = Directory.GetFiles(s);
        //foreach (string fileName in fileEntries)
        //{
        //    if (fileName.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
        //    {
        //        Assembly asm = Assembly.LoadFrom(fileName);
        //        object[] attr = asm.GetCustomAttributes(typeof(AssemblyConfigurationAttribute), false);
        //        if (attr != null && attr.Length > 0)
        //        {
        //            AssemblyConfigurationAttribute aca = (AssemblyConfigurationAttribute)attr[0];
        //            if (aca != null && aca.Configuration == "BlogEngineExtension")
        //            {
        //                assemblies.Add(asm);
        //            }
        //        }
        //    }
        //}
        //}

        /// <summary>
        /// 网站安装目录,返回格式 网站 "/" ;虚拟子目录下  "/sub/"
        /// </summary>
        public static string GetIISPath
        {
            get
            {
                

                string AppPath = "";
                HttpContext HttpCurrent = HttpContext.Current;
                HttpRequest Req;
                if (HttpCurrent != null)
                {
                    Req = HttpCurrent.Request;

                    //string UrlAuthority = Req.Url.GetLeftPart(UriPartial.Authority);
                    //UrlAuthority 如 http://www.ebsite.net:8088
                    if (Req.ApplicationPath == null || Req.ApplicationPath == "/")
                    {
                        //直接安装在   Web   站点   

                        AppPath = "/";
                    }
                    else
                    {
                        //安装在虚拟子目录下   
                        AppPath = string.Concat(Req.ApplicationPath, "/");
                    }

                }
                return AppPath;
            }
        }
        /// <summary>
        /// 获取某个目录的文件夹名称
        /// </summary>
        /// <param name="Path">目录绝对路径</param>
        /// <returns></returns>
        public static List<string> GetFolder(string Path)
        {
            List<string> lst = new List<string>();
            DirectoryInfo di = new DirectoryInfo(Path);
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                lst.Add(dir.Name);
            }
            return lst;
        }
        #endregion

        private static Regex RegexBr = new Regex(@"(\r\n)", RegexOptions.IgnoreCase);

        public static Regex RegexFont = new Regex(@"<font color=" + "\".*?\"" + @">([\s\S]+?)</font>", Utils.GetRegexCompiledOptions());

        private static FileVersionInfo AssemblyFileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

        private static string TemplateCookieName = string.Format("dnttemplateid_{0}_{1}_{2}", AssemblyFileVersion.FileMajorPart, AssemblyFileVersion.FileMinorPart, AssemblyFileVersion.FileBuildPart);

        /// <summary>
        /// 得到正则编译参数设置
        /// </summary>
        /// <returns>参数设置</returns>
        public static RegexOptions GetRegexCompiledOptions()
        {
            return RegexOptions.None;
        }

        /// <summary>
        /// 返回字符串真实长度, 1个汉字长度为2
        /// </summary>
        /// <returns>字符长度</returns>
        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }

        public static bool IsCompriseStr(string str, string stringarray, string strsplit)
        {
            if (Utils.StrIsNullOrEmpty(stringarray))
                return false;

            str = str.ToLower();
            string[] stringArray = Utils.SplitString(stringarray.ToLower(), strsplit);
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (str.IndexOf(stringArray[i]) > -1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断指定字符串在指定字符串数组中的位置
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>
        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (caseInsensetive)
                {
                    if (strSearch.ToLower() == stringArray[i].ToLower())
                        return i;
                }
                else if (strSearch == stringArray[i])
                    return i;
            }
            return -1;
        }


        /// <summary>
        /// 判断指定字符串在指定字符串数组中的位置
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>		
        public static int GetInArrayID(string strSearch, string[] stringArray)
        {
            return GetInArrayID(strSearch, stringArray, true);
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            return GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0;
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">字符串数组</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string[] stringarray)
        {
            return InArray(str, stringarray, false);
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray)
        {
            return InArray(str, SplitString(stringarray, ","), false);
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <param name="strsplit">分割字符串</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray, string strsplit)
        {
            return InArray(str, SplitString(stringarray, strsplit), false);
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <param name="strsplit">分割字符串</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray, string strsplit, bool caseInsensetive)
        {
            return InArray(str, SplitString(stringarray, strsplit), caseInsensetive);
        }


        /// <summary>
        /// 删除字符串尾部的回车/换行/空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RTrim(string str)
        {
            for (int i = str.Length; i >= 0; i--)
            {
                if (str[i].Equals(" ") || str[i].Equals("\r") || str[i].Equals("\n"))
                {
                    str.Remove(i, 1);
                }
            }
            return str;
        }


        /// <summary>
        /// 清除给定字符串中的回车及换行符
        /// </summary>
        /// <param name="str">要清除的字符串</param>
        /// <returns>清除后返回的字符串</returns>
        public static string ClearBR(string str)
        {
            Match m = null;

            for (m = RegexBr.Match(str); m.Success; m = m.NextMatch())
            {
                str = str.Replace(m.Groups[0].ToString(), "");
            }
            return str;
        }

        /// <summary>
        /// 从字符串的指定位置截取指定长度的子字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="startIndex">子字符串的起始位置</param>
        /// <param name="length">子字符串的长度</param>
        /// <returns>子字符串</returns>
        public static string CutString(string str, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length = length * -1;
                    if (startIndex - length < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                        startIndex = startIndex - length;
                }

                if (startIndex > str.Length)
                    return "";
            }
            else
            {
                if (length < 0)
                    return "";
                else
                {
                    if (length + startIndex > 0)
                    {
                        length = length + startIndex;
                        startIndex = 0;
                    }
                    else
                        return "";
                }
            }

            if (str.Length - startIndex < length)
                length = str.Length - startIndex;

            return str.Substring(startIndex, length);
        }

        /// <summary>
        /// 从字符串的指定位置开始截取到字符串结尾的了符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="startIndex">子字符串的起始位置</param>
        /// <returns>子字符串</returns>
        public static string CutString(string str, int startIndex)
        {
            return CutString(str, startIndex, str.Length);
        }



        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }



        /// <summary>
        /// 返回文件是否存在
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>是否存在</returns>
        public static bool FileExists(string filename)
        {
            return System.IO.File.Exists(filename);
        }



        /// <summary>
        /// 以指定的ContentType输出指定文件文件
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <param name="filename">输出的文件名</param>
        /// <param name="filetype">将文件输出时设置的ContentType</param>
        public static void ResponseFile(string filepath, string filename, string filetype)
        {
            Stream iStream = null;

            // 缓冲区为10k
            byte[] buffer = new Byte[10000];
            // 文件长度
            int length;
            // 需要读的数据长度
            long dataToRead;

            try
            {
                // 打开文件
                iStream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                // 需要读的数据长度
                dataToRead = iStream.Length;

                HttpContext.Current.Response.ContentType = filetype;
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + Utils.UrlEncode(filename.Trim()).Replace("+", " "));

                while (dataToRead > 0)
                {
                    // 检查客户端是否还处于连接状态
                    if (HttpContext.Current.Response.IsClientConnected)
                    {
                        length = iStream.Read(buffer, 0, 10000);
                        HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);
                        HttpContext.Current.Response.Flush();
                        buffer = new Byte[10000];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        // 如果不再连接则跳出死循环
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Error : " + ex.Message);
            }
            finally
            {
                if (iStream != null)
                {
                    // 关闭文件
                    iStream.Close();
                }
            }
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 判断文件名是否为浏览器可以直接显示的图片文件名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>是否可以直接显示</returns>
        public static bool IsImgFilename(string filename)
        {
            filename = filename.Trim();
            if (filename.EndsWith(".") || filename.IndexOf(".") == -1)
                return false;

            string extname = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
            return (extname == "jpg" || extname == "jpeg" || extname == "png" || extname == "bmp" || extname == "gif");
        }


        /// <summary>
        /// int型转换为string型
        /// </summary>
        /// <returns>转换后的string类型结果</returns>
        public static string IntToStr(int intValue)
        {
            return Convert.ToString(intValue);
        }
        /// <summary>
        /// MD5函数
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>MD5结果</returns>
        public static string MD5(string str)
        {
            byte[] b = Encoding.Default.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');

            return ret;
        }

        /// <summary>
        /// SHA256函数
        /// </summary>
        /// /// <param name="str">原始字符串</param>
        /// <returns>SHA256结果</returns>
        public static string SHA256(string str)
        {
            byte[] SHA256Data = Encoding.UTF8.GetBytes(str);
            SHA256Managed Sha256 = new SHA256Managed();
            byte[] Result = Sha256.ComputeHash(SHA256Data);
            return Convert.ToBase64String(Result);  //返回长度为44字节的字符串
        }

        /// <summary>
        /// 字符串如果操过指定长度则将超出的部分用指定字符串代替
        /// </summary>
        /// <param name="p_SrcString">要检查的字符串</param>
        /// <param name="p_Length">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
        {
            return GetSubString(p_SrcString, 0, p_Length, p_TailString);
        }

        public static string GetUnicodeSubString(string str, int len, string p_TailString)
        {
            string result = string.Empty;// 最终返回的结果
            int byteLen = System.Text.Encoding.Default.GetByteCount(str);// 单字节字符长度
            int charLen = str.Length;// 把字符平等对待时的字符串长度
            int byteCount = 0;// 记录读取进度
            int pos = 0;// 记录截取位置
            if (byteLen > len)
            {
                for (int i = 0; i < charLen; i++)
                {
                    if (Convert.ToInt32(str.ToCharArray()[i]) > 255)// 按中文字符计算加2
                        byteCount += 2;
                    else// 按英文字符计算加1
                        byteCount += 1;
                    if (byteCount > len)// 超出时只记下上一个有效位置
                    {
                        pos = i;
                        break;
                    }
                    else if (byteCount == len)// 记下当前位置
                    {
                        pos = i + 1;
                        break;
                    }
                }

                if (pos >= 0)
                    result = str.Substring(0, pos) + p_TailString;
            }
            else
                result = str;

            return result;
        }

        /// <summary>
        /// 取指定长度的字符串
        /// </summary>
        /// <param name="p_SrcString">要检查的字符串</param>
        /// <param name="p_StartIndex">起始位置</param>
        /// <param name="p_Length">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
        {
            string myResult = p_SrcString;

            Byte[] bComments = Encoding.UTF8.GetBytes(p_SrcString);
            foreach (char c in Encoding.UTF8.GetChars(bComments))
            {    //当是日文或韩文时(注:中文的范围:\u4e00 - \u9fa5, 日文在\u0800 - \u4e00, 韩文为\xAC00-\xD7A3)
                if ((c > '\u0800' && c < '\u4e00') || (c > '\xAC00' && c < '\xD7A3'))
                {
                    //if (System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\u0800-\u4e00]+") || System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\xAC00-\xD7A3]+"))
                    //当截取的起始位置超出字段串长度时
                    if (p_StartIndex >= p_SrcString.Length)
                        return "";
                    else
                        return p_SrcString.Substring(p_StartIndex,
                                                       ((p_Length + p_StartIndex) > p_SrcString.Length) ? (p_SrcString.Length - p_StartIndex) : p_Length);
                }
            }

            if (p_Length >= 0)
            {
                byte[] bsSrcString = Encoding.Default.GetBytes(p_SrcString);

                //当字符串长度大于起始位置
                if (bsSrcString.Length > p_StartIndex)
                {
                    int p_EndIndex = bsSrcString.Length;

                    //当要截取的长度在字符串的有效长度范围内
                    if (bsSrcString.Length > (p_StartIndex + p_Length))
                    {
                        p_EndIndex = p_Length + p_StartIndex;
                    }
                    else
                    {   //当不在有效范围内时,只取到字符串的结尾

                        p_Length = bsSrcString.Length - p_StartIndex;
                        p_TailString = "";
                    }

                    int nRealLength = p_Length;
                    int[] anResultFlag = new int[p_Length];
                    byte[] bsResult = null;

                    int nFlag = 0;
                    for (int i = p_StartIndex; i < p_EndIndex; i++)
                    {
                        if (bsSrcString[i] > 127)
                        {
                            nFlag++;
                            if (nFlag == 3)
                                nFlag = 1;
                        }
                        else
                            nFlag = 0;

                        anResultFlag[i] = nFlag;
                    }

                    if ((bsSrcString[p_EndIndex - 1] > 127) && (anResultFlag[p_Length - 1] == 1))
                        nRealLength = p_Length + 1;

                    bsResult = new byte[nRealLength];

                    Array.Copy(bsSrcString, p_StartIndex, bsResult, 0, nRealLength);

                    myResult = Encoding.Default.GetString(bsResult);
                    myResult = myResult + p_TailString;
                }
            }

            return myResult;
        }

        /// <summary>
        /// 自定义的替换字符串函数
        /// </summary>
        public static string ReplaceString(string SourceString, string SearchString, string ReplaceString, bool IsCaseInsensetive)
        {
            return Regex.Replace(SourceString, Regex.Escape(SearchString), ReplaceString, IsCaseInsensetive ? RegexOptions.IgnoreCase : RegexOptions.None);
        }

        /// <summary>
        /// 生成指定数量的html空格符号
        /// </summary>
        public static string GetSpacesString(int spacesCount)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < spacesCount; i++)
            {
                sb.Append(" &nbsp;&nbsp;");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 检测是否符合email格式
        /// </summary>
        /// <param name="strEmail">要判断的email字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsValidEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^[\w\.]+([-]\w+)*@[A-Za-z0-9-_]+[\.][A-Za-z0-9-_]");
        }

        public static bool IsValidDoEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// 检测是否是正确的Url
        /// </summary>
        /// <param name="strUrl">要验证的Url</param>
        /// <returns>判断结果</returns>
        public static bool IsURL(string strUrl)
        {
            return Regex.IsMatch(strUrl, @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$");
        }

        public static string GetEmailHostName(string strEmail)
        {
            if (strEmail.IndexOf("@") < 0)
            {
                return "";
            }
            return strEmail.Substring(strEmail.LastIndexOf("@")).ToLower();
        }

        /// <summary>
        /// 判断是否为base64字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBase64String(string str)
        {
            //A-Z, a-z, 0-9, +, /, =
            return Regex.IsMatch(str, @"[A-Za-z0-9\+\/\=]");
        }
        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        /// <summary>
        /// 检测是否有危险的可能用于链接的字符串
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeUserInfoString(string str)
        {
            return !Regex.IsMatch(str, @"^\s*$|^c:\\con\\con$|[%,\*" + "\"" + @"\s\t\<\>\&]|游客|^Guest");
        }

        public static string InputFormat(string content)
        {
           return RemoveUnsafeHtml(ChkSQL(content));
        }
        /// <summary>
        /// 清理字符串
        /// </summary>
        public static string CleanInput(string strIn)
        {
            if(!string.IsNullOrEmpty(strIn))
                return Regex.Replace(strIn.Trim(), @"[^\w\.@-]", "");
            return string.Empty;
        }

        /// <summary>
        /// 返回URL中结尾的文件名
        /// </summary>		
        public static string GetFilename(string url)
        {
            if (url == null)
            {
                return "";
            }
            string[] strs1 = url.Split(new char[] { '/' });
            return strs1[strs1.Length - 1].Split(new char[] { '?' })[0];
        }

        /// <summary>
        /// 根据阿拉伯数字返回月份的名称(可更改为某种语言)
        /// </summary>	
        public static string[] Monthes
        {
            get
            {
                return new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            }
        }

        /// <summary>
        /// 替换回车换行符为html换行符
        /// </summary>
        public static string StrFormat(string str)
        {
            string str2;

            if (str == null)
            {
                str2 = "";
            }
            else
            {
                str = str.Replace("\r\n", "<br />");
                str = str.Replace("\n", "<br />");
                str2 = str;
            }
            return str2;
        }

        /// <summary>
        /// 返回标准日期格式string
        /// </summary>
        public static string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 返回指定日期格式
        /// </summary>
        public static string GetDate(string datetimestr, string replacestr)
        {
            if (datetimestr == null)
                return replacestr;

            if (datetimestr.Equals(""))
                return replacestr;

            try
            {
                datetimestr = Convert.ToDateTime(datetimestr).ToString("yyyy-MM-dd").Replace("1900-01-01", replacestr);
            }
            catch
            {
                return replacestr;
            }
            return datetimestr;
        }


        /// <summary>
        /// 返回标准时间格式string
        /// </summary>
        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        /// <summary>
        /// 返回标准时间格式string
        /// </summary>
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 返回相对于当前时间的相对天数
        /// </summary>
        public static string GetDateTime(int relativeday)
        {
            return DateTime.Now.AddDays(relativeday).ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 返回标准时间格式string
        /// </summary>
        public static string GetDateTimeF()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }

        /// <summary>
        /// 返回标准时间 
        /// </sumary>
        public static string GetStandardDateTime(string fDateTime, string formatStr)
        {
            if (fDateTime == "0000-0-0 0:00:00")
                return fDateTime;

            return Convert.ToDateTime(fDateTime).ToString(formatStr);
        }

        /// <summary>
        /// 返回标准时间 yyyy-MM-dd HH:mm:ss
        /// </sumary>
        public static string GetStandardDateTime(string fDateTime)
        {
            return GetStandardDateTime(fDateTime, "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 返回标准时间 yyyy-MM-dd
        /// </sumary>
        public static string GetStandardDate(string fDate)
        {
            return GetStandardDateTime(fDate, "yyyy-MM-dd");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsTime(string timeval)
        {
            return Regex.IsMatch(timeval, @"^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$");
        }
       
        /// <summary>
        /// 获得当前页面客户端的IP
        /// </summary>
        /// <returns>当前页面客户端的IP</returns>
        public static string GetClientIP()
        {
            if(!Equals(HttpContext.Current,null))
                return GetClientIP(HttpContext.Current);
            return "";
            //var ip = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
            //        ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
            //        : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            //if (ip.Contains(","))
            //    ip = ip.Split(',').Last().Trim();
            //return ip;
        }

        public static string GetClientIP(HttpContext _httpContext)
        {
            string result = _httpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
                result = _httpContext.Request.ServerVariables["REMOTE_ADDR"];

            if (string.IsNullOrEmpty(result))
                result = _httpContext.Request.UserHostAddress;

            if (string.IsNullOrEmpty(result) || !Utils.IsIP(result))
                return "127.0.0.1";

            return result;
            //var ip = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]: HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            //if (ip.Contains(","))
            //{
            //    ip = ip.Split(',').First().Trim();
            //}
            //return ip;
        }

        public static string GetServerIP()
        {
            return HttpContext.Current.Request.ServerVariables.Get("Local_Addr");

        }

        //public static string GetRealIP()
        //{
        //    return GetIP();
        //}

        /// <summary>
        /// 改正sql语句中的转义字符
        /// </summary>
        public static string mashSQL(string str)
        {
            return (str == null) ? "" : str.Replace("\'", "'");
        }

        /// <summary>
        /// 替换sql语句中的有问题符号
        /// </summary>
        public static string ChkSQL(string str)
        {
            return (str == null) ? "" : str.Replace("'", "''");
        }


        /// <summary>
        /// 转换为静态html
        /// </summary>
        public void transHtml(string path, string outpath)
        {
            Page page = new Page();
            StringWriter writer = new StringWriter();
            page.Server.Execute(path, writer);
            FileStream fs;
            if (File.Exists(page.Server.MapPath("") + "\\" + outpath))
            {
                File.Delete(page.Server.MapPath("") + "\\" + outpath);
                fs = File.Create(page.Server.MapPath("") + "\\" + outpath);
            }
            else
            {
                fs = File.Create(page.Server.MapPath("") + "\\" + outpath);
            }
            byte[] bt = Encoding.Default.GetBytes(writer.ToString());
            fs.Write(bt, 0, bt.Length);
            fs.Close();
        }




        /// <summary>
        /// 分割字符串
        /// </summary>
        public static string[] SplitString(string strContent, string strSplit)
        {
            if (!Utils.StrIsNullOrEmpty(strContent))
            {
                if (strContent.IndexOf(strSplit) < 0)
                    return new string[] { strContent };

                return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
            }
            else
                return new string[0] { };
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <returns></returns>
        public static string[] SplitString(string strContent, string strSplit, int count)
        {
            string[] result = new string[count];
            string[] splited = SplitString(strContent, strSplit);

            for (int i = 0; i < count; i++)
            {
                if (i < splited.Length)
                    result[i] = splited[i];
                else
                    result[i] = string.Empty;
            }

            return result;
        }

        /// <summary>
        /// 过滤字符串数组中每个元素为合适的大小
        /// 当长度小于minLength时，忽略掉,-1为不限制最小长度
        /// 当长度大于maxLength时，取其前maxLength位
        /// 如果数组中有null元素，会被忽略掉
        /// </summary>
        /// <param name="minLength">单个元素最小长度</param>
        /// <param name="maxLength">单个元素最大长度</param>
        /// <returns></returns>
        public static string[] PadStringArray(string[] strArray, int minLength, int maxLength)
        {
            if (minLength > maxLength)
            {
                int t = maxLength;
                maxLength = minLength;
                minLength = t;
            }

            int iMiniStringCount = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (minLength > -1 && strArray[i].Length < minLength)
                {
                    strArray[i] = null;
                    continue;
                }
                if (strArray[i].Length > maxLength)
                    strArray[i] = strArray[i].Substring(0, maxLength);

                iMiniStringCount++;
            }

            string[] result = new string[iMiniStringCount];
            for (int i = 0, j = 0; i < strArray.Length && j < result.Length; i++)
            {
                if (strArray[i] != null && strArray[i] != string.Empty)
                {
                    result[j] = strArray[i];
                    j++;
                }
            }
            return result;
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">忽略重复项</param>
        /// <param name="maxElementLength">单个元素最大长度</param>
        /// <returns></returns>
        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem, int maxElementLength)
        {
            string[] result = SplitString(strContent, strSplit);

            return ignoreRepeatItem ? DistinctStringArray(result, maxElementLength) : result;
        }

        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem, int minElementLength, int maxElementLength)
        {
            string[] result = SplitString(strContent, strSplit);

            if (ignoreRepeatItem)
            {
                result = DistinctStringArray(result);
            }
            return PadStringArray(result, minElementLength, maxElementLength);
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">忽略重复项</param>
        /// <returns></returns>
        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem)
        {
            return SplitString(strContent, strSplit, ignoreRepeatItem, 0);
        }

        /// <summary>
        /// 清除字符串数组中的重复项
        /// </summary>
        /// <param name="strArray">字符串数组</param>
        /// <param name="maxElementLength">字符串数组中单个元素的最大长度</param>
        /// <returns></returns>
        public static string[] DistinctStringArray(string[] strArray, int maxElementLength)
        {
            Hashtable h = new Hashtable();

            foreach (string s in strArray)
            {
                string k = s;
                if (maxElementLength > 0 && k.Length > maxElementLength)
                {
                    k = k.Substring(0, maxElementLength);
                }
                h[k.Trim()] = s;
            }

            string[] result = new string[h.Count];

            h.Keys.CopyTo(result, 0);

            return result;
        }

        /// <summary>
        /// 清除字符串数组中的重复项
        /// </summary>
        /// <param name="strArray">字符串数组</param>
        /// <returns></returns>
        public static string[] DistinctStringArray(string[] strArray)
        {
            return DistinctStringArray(strArray, 0);
        }

        /// <summary>
        /// 替换html字符
        /// </summary>
        public static string EncodeHtml(string strHtml)
        {
            if (strHtml != "")
            {
                strHtml = strHtml.Replace(",", "&def");
                strHtml = strHtml.Replace("'", "&dot");
                strHtml = strHtml.Replace(";", "&dec");
                return strHtml;
            }
            return "";
        }

        /// <summary>
        /// 进行指定的替换(脏字过滤)
        /// </summary>
        public static string StrFilter(string str, string bantext)
        {
            string text1 = "", text2 = "";
            string[] textArray1 = SplitString(bantext, "\r\n");
            for (int num1 = 0; num1 < textArray1.Length; num1++)
            {
                text1 = textArray1[num1].Substring(0, textArray1[num1].IndexOf("="));
                text2 = textArray1[num1].Substring(textArray1[num1].IndexOf("=") + 1);
                str = str.Replace(text1, text2);
            }
            return str;
        }

        /// <summary>
        /// 获得伪静态页码显示链接
        /// </summary>
        /// <param name="curPage">当前页数</param>
        /// <param name="countPage">总页数</param>
        /// <param name="url">超级链接地址</param>
        /// <param name="extendPage">周边页码显示个数上限</param>
        /// <returns>页码html</returns>
        public static string GetStaticPageNumbers(int curPage, int countPage, string url, string expname, int extendPage)
        {
            return GetStaticPageNumbers(curPage, countPage, url, expname, extendPage, 0);
        }


        /// <summary>
        /// 获得伪静态页码显示链接
        /// </summary>
        /// <param name="curPage">当前页数</param>
        /// <param name="countPage">总页数</param>
        /// <param name="url">超级链接地址</param>
        /// <param name="extendPage">周边页码显示个数上限</param>
        /// <param name="forumrewrite">当前版块是否使用URL重写</param>
        /// <returns>页码html</returns>
        public static string GetStaticPageNumbers(int curPage, int countPage, string url, string expname, int extendPage, int forumrewrite)
        {
            int startPage = 1;
            int endPage = 1;

            string t1 = "<a href=\"" + url + "-1" + expname + "\">&laquo;</a>";
            string t2 = "<a href=\"" + url + "-" + countPage + expname + "\">&raquo;</a>";

            if (forumrewrite == 1)
            {
                t1 = "<a href=\"" + url + "/1/list" + expname + "\">&laquo;</a>";
                t2 = "<a href=\"" + url + "/" + countPage + "/list" + expname + "\">&raquo;</a>";
            }

            if (forumrewrite == 2)
            {
                t1 = "<a href=\"" + url + "/\">&laquo;</a>";
                t2 = "<a href=\"" + url + "/" + countPage + "/\">&raquo;</a>";
            }

            if (countPage < 1) countPage = 1;
            if (extendPage < 3) extendPage = 2;

            if (countPage > extendPage)
            {
                if (curPage - (extendPage / 2) > 0)
                {
                    if (curPage + (extendPage / 2) < countPage)
                    {
                        startPage = curPage - (extendPage / 2);
                        endPage = startPage + extendPage - 1;
                    }
                    else
                    {
                        endPage = countPage;
                        startPage = endPage - extendPage + 1;
                        t2 = "";
                    }
                }
                else
                {
                    endPage = extendPage;
                    t1 = "";
                }
            }
            else
            {
                startPage = 1;
                endPage = countPage;
                t1 = "";
                t2 = "";
            }

            StringBuilder s = new StringBuilder("");

            s.Append(t1);
            for (int i = startPage; i <= endPage; i++)
            {
                if (i == curPage)
                {
                    s.Append("<span>");
                    s.Append(i);
                    s.Append("</span>");
                }
                else
                {
                    s.Append("<a href=\"");
                    if (forumrewrite == 1)
                    {
                        s.Append(url);
                        if (i != 1)
                        {
                            s.Append("/");
                            s.Append(i);
                        }
                        s.Append("/list");
                        s.Append(expname);
                    }
                    else if (forumrewrite == 2)
                    {
                        s.Append(url);
                        s.Append("/");
                        if (i != 1)
                        {
                            s.Append(i);
                            s.Append("/");
                        }
                    }
                    else
                    {
                        s.Append(url);
                        if (i != 1)
                        {
                            s.Append("-");
                            s.Append(i);
                        }
                        s.Append(expname);
                    }
                    s.Append("\">");
                    s.Append(i);
                    s.Append("</a>");
                }
            }
            s.Append(t2);

            return s.ToString();
        }


        /// <summary>
        /// 获得帖子的伪静态页码显示链接
        /// </summary>
        /// <param name="expname"></param>
        /// <param name="countPage">总页数</param>
        /// <param name="url">超级链接地址</param>
        /// <param name="extendPage">周边页码显示个数上限</param>
        /// <returns>页码html</returns>
        public static string GetPostPageNumbers(int countPage, string url, string expname, int extendPage)
        {
            int startPage = 1;
            int endPage = 1;
            int curPage = 1;

            string t1 = "<a href=\"" + url + "-1" + expname + "\">&laquo;</a>";
            string t2 = "<a href=\"" + url + "-" + countPage + expname + "\">&raquo;</a>";

            if (countPage < 1) countPage = 1;
            if (extendPage < 3) extendPage = 2;

            if (countPage > extendPage)
            {
                if (curPage - (extendPage / 2) > 0)
                {
                    if (curPage + (extendPage / 2) < countPage)
                    {
                        startPage = curPage - (extendPage / 2);
                        endPage = startPage + extendPage - 1;
                    }
                    else
                    {
                        endPage = countPage;
                        startPage = endPage - extendPage + 1;
                        t2 = "";
                    }
                }
                else
                {
                    endPage = extendPage;
                    t1 = "";
                }
            }
            else
            {
                startPage = 1;
                endPage = countPage;
                t1 = "";
                t2 = "";
            }

            StringBuilder s = new StringBuilder("");

            s.Append(t1);
            for (int i = startPage; i <= endPage; i++)
            {
                s.Append("<a href=\"");
                s.Append(url);
                s.Append("-");
                s.Append(i);
                s.Append(expname);
                s.Append("\">");
                s.Append(i);
                s.Append("</a>");
            }
            s.Append(t2);

            return s.ToString();
        }



        /// <summary>
        /// 获得页码显示链接
        /// </summary>
        /// <param name="curPage">当前页数</param>
        /// <param name="countPage">总页数</param>
        /// <param name="url">超级链接地址</param>
        /// <param name="extendPage">周边页码显示个数上限</param>
        /// <returns>页码html</returns>
        public static string GetPageNumbers(int curPage, int countPage, string url, int extendPage)
        {
            return GetPageNumbers(curPage, countPage, url, extendPage, "page");
        }

        /// <summary>
        /// 获得页码显示链接
        /// </summary>
        /// <param name="curPage">当前页数</param>
        /// <param name="countPage">总页数</param>
        /// <param name="url">超级链接地址</param>
        /// <param name="extendPage">周边页码显示个数上限</param>
        /// <param name="pagetag">页码标记</param>
        /// <returns>页码html</returns>
        public static string GetPageNumbers(int curPage, int countPage, string url, int extendPage, string pagetag)
        {
            return GetPageNumbers(curPage, countPage, url, extendPage, pagetag, null);
        }

        /// <summary>
        /// 获得页码显示链接
        /// </summary>
        /// <param name="curPage">当前页数</param>
        /// <param name="countPage">总页数</param>
        /// <param name="url">超级链接地址</param>
        /// <param name="extendPage">周边页码显示个数上限</param>
        /// <param name="pagetag">页码标记</param>
        /// <param name="anchor">锚点</param>
        /// <returns>页码html</returns>
        public static string GetPageNumbers(int curPage, int countPage, string url, int extendPage, string pagetag, string anchor)
        {
            if (pagetag == "")
                pagetag = "page";
            int startPage = 1;
            int endPage = 1;

            if (url.IndexOf("?") > 0)
                url = url + "&";
            else
                url = url + "?";

            string t1 = "<a href=\"" + url + "&" + pagetag + "=1";
            string t2 = "<a href=\"" + url + "&" + pagetag + "=" + countPage;
            if (anchor != null)
            {
                t1 += anchor;
                t2 += anchor;
            }
            t1 += "\">&laquo;</a>";
            t2 += "\">&raquo;</a>";

            if (countPage < 1)
                countPage = 1;
            if (extendPage < 3)
                extendPage = 2;

            if (countPage > extendPage)
            {
                if (curPage - (extendPage / 2) > 0)
                {
                    if (curPage + (extendPage / 2) < countPage)
                    {
                        startPage = curPage - (extendPage / 2);
                        endPage = startPage + extendPage - 1;
                    }
                    else
                    {
                        endPage = countPage;
                        startPage = endPage - extendPage + 1;
                        t2 = "";
                    }
                }
                else
                {
                    endPage = extendPage;
                    t1 = "";
                }
            }
            else
            {
                startPage = 1;
                endPage = countPage;
                t1 = "";
                t2 = "";
            }

            StringBuilder s = new StringBuilder("");

            s.Append(t1);
            for (int i = startPage; i <= endPage; i++)
            {
                if (i == curPage)
                {
                    s.Append("<span>");
                    s.Append(i);
                    s.Append("</span>");
                }
                else
                {
                    s.Append("<a href=\"");
                    s.Append(url);
                    s.Append(pagetag);
                    s.Append("=");
                    s.Append(i);
                    if (anchor != null)
                    {
                        s.Append(anchor);
                    }
                    s.Append("\">");
                    s.Append(i);
                    s.Append("</a>");
                }
            }
            s.Append(t2);

            return s.ToString();
        }

        /// <summary>
        /// 返回 HTML 字符串的编码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>编码结果</returns>
        public static string HtmlEncode(string str)
        {
            return HttpUtility.HtmlEncode(str);
        }

        /// <summary>
        /// 返回 HTML 字符串的解码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>解码结果</returns>
        public static string HtmlDecode(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        /// <summary>
        /// 返回 URL 字符串的编码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>编码结果</returns>
        public static string UrlEncode(string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        /// <summary>
        /// 返回 URL 字符串的编码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>解码结果</returns>
        public static string UrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }


        /// <summary>
        /// 返回指定目录下的非 UTF8 字符集文件
        /// </summary>
        /// <param name="Path">路径</param>
        /// <returns>文件名的字符串数组</returns>
        public static string[] FindNoUTF8File(string Path)
        {
            StringBuilder filelist = new StringBuilder();
            DirectoryInfo Folder = new DirectoryInfo(Path);
            FileInfo[] subFiles = Folder.GetFiles();

            for (int j = 0; j < subFiles.Length; j++)
            {
                if (subFiles[j].Extension.ToLower().Equals(".htm"))
                {
                    FileStream fs = new FileStream(subFiles[j].FullName, FileMode.Open, FileAccess.Read);
                    bool bUtf8 = IsUTF8(fs);
                    fs.Close();
                    if (!bUtf8)
                    {
                        filelist.Append(subFiles[j].FullName);
                        filelist.Append("\r\n");
                    }
                }
            }
            return Utils.SplitString(filelist.ToString(), "\r\n");

        }

        //0000 0000-0000 007F - 0xxxxxxx  (ascii converts to 1 octet!)
        //0000 0080-0000 07FF - 110xxxxx 10xxxxxx    ( 2 octet format)
        //0000 0800-0000 FFFF - 1110xxxx 10xxxxxx 10xxxxxx (3 octet format)

        /// <summary>
        /// 判断文件流是否为UTF8字符集
        /// </summary>
        /// <param name="sbInputStream">文件流</param>
        /// <returns>判断结果</returns>
        private static bool IsUTF8(FileStream sbInputStream)
        {
            int i;
            byte cOctets;  // octets to go in this UTF-8 encoded character 
            byte chr;
            bool bAllAscii = true;
            long iLen = sbInputStream.Length;

            cOctets = 0;
            for (i = 0; i < iLen; i++)
            {
                chr = (byte)sbInputStream.ReadByte();

                if ((chr & 0x80) != 0) bAllAscii = false;

                if (cOctets == 0)
                {
                    if (chr >= 0x80)
                    {
                        do
                        {
                            chr <<= 1;
                            cOctets++;
                        }
                        while ((chr & 0x80) != 0);

                        cOctets--;
                        if (cOctets == 0)
                            return false;
                    }
                }
                else
                {
                    if ((chr & 0xC0) != 0x80)
                        return false;

                    cOctets--;
                }
            }

            if (cOctets > 0)
                return false;

            if (bAllAscii)
                return false;

            return true;
        }

        /// <summary>
        /// 格式化字节数字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string FormatBytesStr(int bytes)
        {
            if (bytes > 1073741824)
                return ((double)(bytes / 1073741824)).ToString("0") + "G";

            if (bytes > 1048576)
                return ((double)(bytes / 1048576)).ToString("0") + "M";

            if (bytes > 1024)
                return ((double)(bytes / 1024)).ToString("0") + "K";

            return bytes.ToString() + "Bytes";
        }

        /// <summary>
        /// 将long型数值转换为Int32类型
        /// </summary>
        /// <param name="objNum"></param>
        /// <returns></returns>
        public static int SafeInt32(object objNum)
        {
            if (objNum == null)
                return 0;

            string strNum = objNum.ToString();
            if (IsNumeric(strNum))
            {

                if (strNum.ToString().Length > 9)
                {
                    if (strNum.StartsWith("-"))
                        return int.MinValue;
                    else
                        return int.MaxValue;
                }
                return Int32.Parse(strNum);
            }
            else
                return 0;
        }

        /// <summary>
        /// 返回相差的秒数
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="Sec"></param>
        /// <returns></returns>
        public static int StrDateDiffSeconds(string Time, int Sec)
        {
            TimeSpan ts = DateTime.Now - DateTime.Parse(Time).AddSeconds(Sec);
            if (ts.TotalSeconds > int.MaxValue)
                return int.MaxValue;

            else if (ts.TotalSeconds < int.MinValue)
                return int.MinValue;

            return (int)ts.TotalSeconds;
        }

        /// <summary>
        /// 返回相差的分钟数
        /// </summary>
        /// <param name="time"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static int StrDateDiffMinutes(string time, int minutes)
        {
            if (Utils.StrIsNullOrEmpty(time))
                return 1;

            TimeSpan ts = DateTime.Now - DateTime.Parse(time).AddMinutes(minutes);
            if (ts.TotalMinutes > int.MaxValue)
                return int.MaxValue;
            else if (ts.TotalMinutes < int.MinValue)
                return int.MinValue;

            return (int)ts.TotalMinutes;
        }

        /// <summary>
        /// 返回相差的小时数
        /// </summary>
        /// <param name="time"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static int StrDateDiffHours(string time, int hours)
        {
            if (Utils.StrIsNullOrEmpty(time))
                return 1;

            TimeSpan ts = DateTime.Now - DateTime.Parse(time).AddHours(hours);
            if (ts.TotalHours > int.MaxValue)
                return int.MaxValue;
            else if (ts.TotalHours < int.MinValue)
                return int.MinValue;

            return (int)ts.TotalHours;
        }

        /// <summary>
        /// 建立文件夹
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CreateDir(string name)
        {
            return Utils.MakeSureDirectoryPathExists(name);
        }

        /// <summary>
        /// 为脚本替换特殊字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceStrToScript(string str)
        {
            return str.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\"", "\\\"");
        }

        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        public static bool IsIPSect(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){2}((2[0-4]\d|25[0-5]|[01]?\d\d?|\*)\.)(2[0-4]\d|25[0-5]|[01]?\d\d?|\*)$");
        }


        /// <summary>
        /// 返回指定IP是否在指定的IP数组所限定的范围内, IP数组内的IP地址可以使用*表示该IP段任意, 例如192.168.1.*
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="iparray"></param>
        /// <returns></returns>
        public static bool InIPArray(string ip, string[] iparray)
        {
            string[] userip = Utils.SplitString(ip, @".");

            for (int ipIndex = 0; ipIndex < iparray.Length; ipIndex++)
            {
                string[] tmpip = Utils.SplitString(iparray[ipIndex], @".");
                int r = 0;
                for (int i = 0; i < tmpip.Length; i++)
                {
                    if (tmpip[i] == "*")
                        return true;

                    if (userip.Length > i)
                    {
                        if (tmpip[i] == userip[i])
                            r++;
                        else
                            break;
                    }
                    else
                        break;
                }

                if (r == 4)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 获得Assembly版本号
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyVersion()
        {
            return string.Format("{0}.{1}.{2}", AssemblyFileVersion.FileMajorPart, AssemblyFileVersion.FileMinorPart, AssemblyFileVersion.FileBuildPart);
        }

        [DllImport("wininet")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);

        /**/
        /// <summary>
        /// 检测本机是否联网
        /// </summary>
        /// <returns></returns>
        public static bool IsConnectedInternet()
        {
            int i = 0;
            if (InternetGetConnectedState(out i, 0))
            {
                //已联网
                return true;
            }
            else
            {
                //未联网
                return false;
            }

        }

        /// <summary>
        /// 获得Assembly产品名称
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyProductName()
        {
            return AssemblyFileVersion.ProductName;
        }

        /// <summary>
        /// 获得Assembly产品版权
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyCopyright()
        {
            return AssemblyFileVersion.LegalCopyright;
        }
        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>创建是否成功</returns>
        [DllImport("dbgHelp", SetLastError = true)]
        private static extern bool MakeSureDirectoryPathExists(string name);


        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string key, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void WriteCookie(string strName, string strValue, int expires, ETimeSpanModel etsm)
        {
            WriteCookie(strName, strValue, expires, etsm, HttpContext.Current);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="strValue">过期时间(分钟)</param>
        public static void WriteCookie(string strName, string strValue, int expires,ETimeSpanModel etsm, HttpContext _HttpContext)
        {
            HttpCookie cookie = _HttpContext.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            if (etsm == ETimeSpanModel.FZ)
            {
                cookie.Expires = DateTime.Now.AddMinutes(expires);
            }
            else if (etsm == ETimeSpanModel.T)
            {
                cookie.Expires = DateTime.Now.AddDays(expires);
            }
            else if (etsm == ETimeSpanModel.XS)
            {
                cookie.Expires = DateTime.Now.AddHours(expires);
            }
            else if (etsm == ETimeSpanModel.M)
            {
                cookie.Expires = DateTime.Now.AddSeconds(expires);
            }

            _HttpContext.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="strValue">过期时间(分钟)</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
           return  GetCookie(strName, HttpContext.Current);
            //if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
            //    return HttpContext.Current.Request.Cookies[strName].Value.ToString();

            //return "";
        }
        public static string GetCookie(string strName, HttpContext _HttpContext)
        {
            if (_HttpContext.Request.Cookies != null && _HttpContext.Request.Cookies[strName] != null)
                return _HttpContext.Request.Cookies[strName].Value.ToString();

            return "";
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName, string key)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[strName][key] != null)
                return HttpContext.Current.Request.Cookies[strName][key].ToString();

            return "";
        }

        /// <summary>
        /// 得到论坛的真实路径
        /// </summary>
        /// <returns></returns>
        public static string GetTrueForumPath()
        {
            string forumPath = HttpContext.Current.Request.Path;
            if (forumPath.LastIndexOf("/") != forumPath.IndexOf("/"))
                forumPath = forumPath.Substring(forumPath.IndexOf("/"), forumPath.LastIndexOf("/") + 1);
            else
                forumPath = "/";

            return forumPath;
        }

        /// <summary>
        /// 判断字符串是否是yy-mm-dd字符串
        /// </summary>
        /// <param name="str">待判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsDateString(string str)
        {
            return Regex.IsMatch(str, @"(\d{4})-(\d{1,2})-(\d{1,2})");
        }

        /// <summary>
        /// 移除Html标记
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RemoveHtml(string content)
        {
            return Regex.Replace(content, @"<[^>]*>", string.Empty, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 过滤HTML中的不安全标签
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RemoveUnsafeHtml(string content)
        {
            content = Regex.Replace(content, @"(\<|\s+)o([a-z]+\s?=)", "$1$2", RegexOptions.IgnoreCase);
            content = Regex.Replace(content, @"(script|frame|form|meta|behavior|style)([\s|:|>])+", "$1.$2", RegexOptions.IgnoreCase);
            return content;
        }

        /// <summary>
        /// 将用户组Title中的font标签去掉
        /// </summary>
        /// <param name="title">用户组Title</param>
        /// <returns></returns>
        public static string RemoveFontTag(string title)
        {
            Match m = RegexFont.Match(title);
            if (m.Success)
                return m.Groups[1].Value;

            return title;
        }

        /// <summary>
        /// 判断对象是否为Int32类型的数字
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static bool IsNumeric(object Expression)
        {
            return IsNumeric(Expression);
        }

        /// <summary>
        /// 从HTML中获取文本,保留br,p,img
        /// </summary>
        /// <param name="HTML"></param>
        /// <returns></returns>
        public static string GetTextFromHTML(string HTML)
        {
            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(@"</?(?!br|/?p|img)[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            return regEx.Replace(HTML, "");
        }

        /// <summary>
        /// 判断是否是跨站提交
        /// </summary>
        /// <param name="urlReferrer">上个页面地址</param>
        /// <param name="host">本站url</param>
        /// <returns>bool</returns>
        public static bool IsCrossSitePost(string urlReferrer, string host)
        {
            Uri u = new Uri(urlReferrer);
            return u.Host != host;
        }

        /// <summary>
        /// 判断对象是否为Int32类型的数字
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static bool IsNumeric(string expression)
        {
            if (expression != null)
            {
                string str = expression;
                if (str.Length > 0 && str.Length <= 11 && Regex.IsMatch(str, @"^[-]?[0-9]*[.]?[0-9]*$"))
                {
                    if ((str.Length < 10) || (str.Length == 10 && str[0] == '1') || (str.Length == 11 && str[0] == '-' && str[1] == '1'))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否为Double类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsDouble(object expression)
        {
            if (expression != null)
                return Regex.IsMatch(expression.ToString(), @"^([0-9])[0-9]*(\.\w*)?$");

            return false;
        }

        /// <summary>
        /// 判断给定的字符串数组(strNumber)中的数据是不是都为数值型
        /// </summary>
        /// <param name="strNumber">要确认的字符串数组</param>
        /// <returns>是则返加true 不是则返回 false</returns>
        public static bool IsNumericArray(string[] strNumber)
        {
            if (strNumber == null)
                return false;

            if (strNumber.Length < 1)
                return false;

            foreach (string id in strNumber)
            {
                if (!IsNumeric(id))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// string型转换为bool型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool StrToBool(object expression, bool defValue)
        {
            if (expression != null)
                return StrToBool(expression, defValue);

            return defValue;
        }

        /// <summary>
        /// string型转换为bool型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool StrToBool(string expression, bool defValue)
        {
            if (expression != null)
            {
                if (string.Compare(expression, "true", true) == 0)
                    return true;
                else if (string.Compare(expression, "false", true) == 0)
                    return false;
            }
            return defValue;
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ObjectToInt(object expression)
        {
            return ObjectToInt(expression, 0);
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ObjectToInt(object expression, int defValue)
        {
            if (expression != null)
                return StrToInt(expression.ToString(), defValue);

            return defValue;
        }
        public static long ObjectToLong(object expression, long defValue)
        {
            if (expression != null)
                return StrToLong(expression.ToString(), defValue);

            return defValue;
        }

        /// <summary>
        /// 将对象转换为Int32类型,转换失败返回0
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(string str)
        {
            return StrToInt(str, 0);
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(string str, int defValue)
        {
            if (string.IsNullOrEmpty(str) || str.Trim().Length >= 11 || !Regex.IsMatch(str.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
                return defValue;

            int rv;
            if (Int32.TryParse(str, out rv))
                return rv;
            
            return Convert.ToInt32(StrToFloat(str, defValue));
        }

        public static DateTime StrToDate(string str)
        {
            DateTime dt = DateTime.Now;
            DateTime.TryParse(str, out dt);

            return dt;
        }

        public static long StrToLong(string str, long defValue)
        {
            if (string.IsNullOrEmpty(str) || str.Trim().Length >= 11 || !Regex.IsMatch(str.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
                return defValue;

            long rv = 0;
            if (long.TryParse(str, out rv))
                return rv;

            return Convert.ToInt64(StrToFloat(str, defValue));
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(object strValue, float defValue)
        {
            if ((strValue == null))
                return defValue;

            return StrToFloat(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float ObjectToFloat(object strValue, float defValue)
        {
            if ((strValue == null))
                return defValue;

            return StrToFloat(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float ObjectToFloat(object strValue)
        {
            return ObjectToFloat(strValue.ToString(), 0);
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(object strValue)
        {
            if ((strValue == null))
                return 0;

            return StrToFloat(strValue.ToString(), 0);
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(string strValue, float defValue)
        {
            if ((strValue == null) || (strValue.Length > 10))
                return defValue;

            float intValue = defValue;
            if (strValue != null)
            {
                bool IsFloat = Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
                if (IsFloat)
                    float.TryParse(strValue, out intValue);
            }
            return intValue;
        }

        public static decimal StrToDecimal(string strValue, decimal defValue)
        {
            if ((strValue == null) || (strValue.Length > 10))
                return defValue;

            decimal intValue = defValue;
            bool IsFloat = Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
            if (IsFloat)
                decimal.TryParse(strValue, out intValue);
            return intValue;
        }

        public static string AdDeTime(int times)
        {
            return (DateTime.Now).AddMinutes(times).ToString();
        }

        /// <summary>
        /// 验证是否为正整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt(string str)
        {
            return Regex.IsMatch(str, @"^[0-9]*$");
        }

        public static bool IsRuleTip(Hashtable NewHash, string ruletype, out string key)
        {
            key = "";
            foreach (DictionaryEntry str in NewHash)
            {

                try
                {
                    string[] single = SplitString(str.Value.ToString(), "\r\n");

                    foreach (string strs in single)
                    {
                        if (strs != "")


                            switch (ruletype.Trim().ToLower())
                            {
                                case "email":
                                    if (IsValidDoEmail(strs.ToString()) == false)
                                        throw new Exception();
                                    break;

                                case "ip":
                                    if (IsIPSect(strs.ToString()) == false)
                                        throw new Exception();
                                    break;

                                case "timesect":
                                    string[] splitetime = strs.Split('-');
                                    if (Utils.IsTime(splitetime[1].ToString()) == false || Utils.IsTime(splitetime[0].ToString()) == false)
                                        throw new Exception();
                                    break;
                            }
                    }
                }
                catch
                {
                    key = str.Key.ToString();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 删除最后一个字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ClearLastChar(string str)
        {
            return (str == "") ? "" : str.Substring(0, str.Length - 1);
        }

        /// <summary>
        /// 备份文件
        /// </summary>
        /// <param name="sourceFileName">源文件名</param>
        /// <param name="destFileName">目标文件名</param>
        /// <param name="overwrite">当目标文件存在时是否覆盖</param>
        /// <returns>操作是否成功</returns>
        public static bool BackupFile(string sourceFileName, string destFileName, bool overwrite)
        {
            if (!System.IO.File.Exists(sourceFileName))
                throw new FileNotFoundException(sourceFileName + "文件不存在！");

            if (!overwrite && System.IO.File.Exists(destFileName))
                return false;

            try
            {
                System.IO.File.Copy(sourceFileName, destFileName, true);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// 备份文件,当目标文件存在时覆盖
        /// </summary>
        /// <param name="sourceFileName">源文件名</param>
        /// <param name="destFileName">目标文件名</param>
        /// <returns>操作是否成功</returns>
        public static bool BackupFile(string sourceFileName, string destFileName)
        {
            return BackupFile(sourceFileName, destFileName, true);
        }


        /// <summary>
        /// 恢复文件
        /// </summary>
        /// <param name="backupFileName">备份文件名</param>
        /// <param name="targetFileName">要恢复的文件名</param>
        /// <param name="backupTargetFileName">要恢复文件再次备份的名称,如果为null,则不再备份恢复文件</param>
        /// <returns>操作是否成功</returns>
        public static bool RestoreFile(string backupFileName, string targetFileName, string backupTargetFileName)
        {
            try
            {
                if (!System.IO.File.Exists(backupFileName))
                    throw new FileNotFoundException(backupFileName + "文件不存在！");

                if (backupTargetFileName != null)
                {
                    if (!System.IO.File.Exists(targetFileName))
                        throw new FileNotFoundException(targetFileName + "文件不存在！无法备份此文件！");
                    else
                        System.IO.File.Copy(targetFileName, backupTargetFileName, true);
                }
                System.IO.File.Delete(targetFileName);
                System.IO.File.Copy(backupFileName, targetFileName);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public static bool RestoreFile(string backupFileName, string targetFileName)
        {
            return RestoreFile(backupFileName, targetFileName, null);
        }

        /// <summary>
        /// 获取记录模板id的cookie名称
        /// </summary>
        /// <returns></returns>
        public static string GetTemplateCookieName()
        {
            return TemplateCookieName;
        }

        /// <summary>
        /// 将全角数字转换为数字
        /// </summary>
        /// <param name="SBCCase"></param>
        /// <returns></returns>
        public static string SBCCaseToNumberic(string SBCCase)
        {
            char[] c = SBCCase.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 255)
                    {
                        b[0] = (byte)(b[0] + 32);
                        b[1] = 0;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }
            return new string(c);
        }



        /// <summary>
        /// 转换长文件名为短文件名
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="repstring"></param>
        /// <param name="leftnum"></param>
        /// <param name="rightnum"></param>
        /// <param name="charnum"></param>
        /// <returns></returns>
        public static string ConvertSimpleFileName(string fullname, string repstring, int leftnum, int rightnum, int charnum)
        {
            string simplefilename = "", leftstring = "", rightstring = "", filename = "";
            string extname = GetFileExtName(fullname);

            if (Utils.StrIsNullOrEmpty(extname))
                throw new Exception("字符串不含有扩展名信息");

            int filelength = 0, dotindex = 0;

            dotindex = fullname.LastIndexOf('.');
            filename = fullname.Substring(0, dotindex);
            filelength = filename.Length;
            if (dotindex > charnum)
            {
                leftstring = filename.Substring(0, leftnum);
                rightstring = filename.Substring(filelength - rightnum, rightnum);
                if (repstring == "" || repstring == null)
                    simplefilename = leftstring + rightstring + "." + extname;
                else
                    simplefilename = leftstring + repstring + rightstring + "." + extname;
            }
            else
                simplefilename = fullname;

            return simplefilename;
        }

        //public static string GetFileExtName(string filename)
        //{
        //    string[] array = filename.Trim().Split('.');
        //    Array.Reverse(array);
        //    return array[0].ToString();
        //}


        /// <summary>
        /// 将数据表转换成JSON类型串
        /// </summary>
        /// <param name="dt">要转换的数据表</param>
        /// <returns></returns>
        public static StringBuilder DataTableToJSON(System.Data.DataTable dt)
        {
            return DataTableToJson(dt, true);
        }

        /// <summary>
        /// 将数据表转换成JSON类型串
        /// </summary>
        /// <param name="dt">要转换的数据表</param>
        /// <param name="dispose">数据表转换结束后是否dispose掉</param>
        /// <returns></returns>
        public static StringBuilder DataTableToJson(System.Data.DataTable dt, bool dt_dispose)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[\r\n");

            //数据表字段名和类型数组
            string[] dt_field = new string[dt.Columns.Count];
            int i = 0;
            string formatStr = "{{";
            string fieldtype = "";
            foreach (System.Data.DataColumn dc in dt.Columns)
            {
                dt_field[i] = dc.Caption.ToLower().Trim();
                formatStr += "'" + dc.Caption.ToLower().Trim() + "':";
                fieldtype = dc.DataType.ToString().Trim().ToLower();
                if (fieldtype.IndexOf("int") > 0 || fieldtype.IndexOf("deci") > 0 ||
                    fieldtype.IndexOf("floa") > 0 || fieldtype.IndexOf("doub") > 0 ||
                    fieldtype.IndexOf("bool") > 0)
                {
                    formatStr += "{" + i + "}";
                }
                else
                {
                    formatStr += "'{" + i + "}'";
                }
                formatStr += ",";
                i++;
            }

            if (formatStr.EndsWith(","))
                formatStr = formatStr.Substring(0, formatStr.Length - 1);//去掉尾部","号

            formatStr += "}},";

            i = 0;
            object[] objectArray = new object[dt_field.Length];
            foreach (System.Data.DataRow dr in dt.Rows)
            {

                foreach (string fieldname in dt_field)
                {   //对 \ , ' 符号进行转换 
                    objectArray[i] = dr[dt_field[i]].ToString().Trim().Replace("\\", "\\\\").Replace("'", "\\'");
                    switch (objectArray[i].ToString())
                    {
                        case "True":
                            {
                                objectArray[i] = "true"; break;
                            }
                        case "False":
                            {
                                objectArray[i] = "false"; break;
                            }
                        default: break;
                    }
                    i++;
                }
                i = 0;
                stringBuilder.Append(string.Format(formatStr, objectArray));
            }
            if (stringBuilder.ToString().EndsWith(","))
                stringBuilder.Remove(stringBuilder.Length - 1, 1);//去掉尾部","号

            if (dt_dispose)
                dt.Dispose();

            return stringBuilder.Append("\r\n];");
        }

        /// <summary>
        /// 字段串是否为Null或为""(空)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool StrIsNullOrEmpty(string str)
        {
            if (str == null || str.Trim() == string.Empty)
                return true;

            return false;
        }

        /// <summary>
        /// 是否为数值串列表，各数值间用","间隔
        /// </summary>
        /// <param name="numList"></param>
        /// <returns></returns>
        public static bool IsNumericList(string numList)
        {
            if (StrIsNullOrEmpty(numList))
                return false;

            return IsNumericArray(numList.Split(','));
        }

        /// <summary>
        /// 检查颜色值是否为3/6位的合法颜色
        /// </summary>
        /// <param name="color">待检查的颜色</param>
        /// <returns></returns>
        public static bool CheckColorValue(string color)
        {
            if (StrIsNullOrEmpty(color))
                return false;

            color = color.Trim().Trim('#');

            if (color.Length != 3 && color.Length != 6)
                return false;

            //不包含0-9  a-f以外的字符
            if (!Regex.IsMatch(color, "[^0-9a-f]", RegexOptions.IgnoreCase))
                return true;

            return false;
        }

        /// <summary>
        /// 获取ajax形式的分页链接
        /// </summary>
        /// <param name="curPage">当前页数</param>
        /// <param name="countPage">总页数</param>
        /// <param name="callback">回调函数</param>
        /// <param name="extendPage">周边页码显示个数上限</param>
        /// <returns></returns>
        public static string GetAjaxPageNumbers(int curPage, int countPage, string callback, int extendPage)
        {
            string pagetag = "page";
            int startPage = 1;
            int endPage = 1;

            string t1 = "<a href=\"###\" onclick=\"" + string.Format(callback, "&" + pagetag + "=1");
            string t2 = "<a href=\"###\" onclick=\"" + string.Format(callback, "&" + pagetag + "=" + countPage);

            t1 += "\">&laquo;</a>";
            t2 += "\">&raquo;</a>";

            if (countPage < 1)
                countPage = 1;
            if (extendPage < 3)
                extendPage = 2;

            if (countPage > extendPage)
            {
                if (curPage - (extendPage / 2) > 0)
                {
                    if (curPage + (extendPage / 2) < countPage)
                    {
                        startPage = curPage - (extendPage / 2);
                        endPage = startPage + extendPage - 1;
                    }
                    else
                    {
                        endPage = countPage;
                        startPage = endPage - extendPage + 1;
                        t2 = "";
                    }
                }
                else
                {
                    endPage = extendPage;
                    t1 = "";
                }
            }
            else
            {
                startPage = 1;
                endPage = countPage;
                t1 = "";
                t2 = "";
            }

            StringBuilder s = new StringBuilder("");

            s.Append(t1);
            for (int i = startPage; i <= endPage; i++)
            {
                if (i == curPage)
                {
                    s.Append("<span>");
                    s.Append(i);
                    s.Append("</span>");
                }
                else
                {
                    s.Append("<a href=\"###\" onclick=\"");
                    s.Append(string.Format(callback, pagetag + "=" + i));
                    s.Append("\">");
                    s.Append(i);
                    s.Append("</a>");
                }
            }
            s.Append(t2);

            return s.ToString();
        }

        /// <summary>
        /// 根据Url获得源文件内容
        /// </summary>
        /// <param name="url">合法的Url地址</param>
        /// <returns></returns>
        public static string GetSourceTextByUrl(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Timeout = 20000;//20秒超时
            WebResponse response = request.GetResponse();

            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(resStream);
            return sr.ReadToEnd();
        }

        /// <summary>
        /// 转换时间为unix时间戳
        /// </summary>
        /// <param name="date">需要传递UTC时间,避免时区误差,例:DataTime.UTCNow</param>
        /// <returns></returns>
        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            return Math.Floor(diff.TotalSeconds);
        }


        /// <summary>
        /// Json特符字符过滤，参见http://www.json.org/
        /// </summary>
        /// <param name="sourceStr">要过滤的源字符串</param>
        /// <returns>返回过滤的字符串</returns>
        public static string JsonCharFilter(string sourceStr)
        {
            sourceStr = sourceStr.Replace("\\", "\\\\");
            sourceStr = sourceStr.Replace("\b", "\\\b");
            sourceStr = sourceStr.Replace("\t", "\\\t");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\f", "\\\f");
            sourceStr = sourceStr.Replace("\r", "\\\r");
            return sourceStr.Replace("\"", "\\\"");
        }


        /// <summary>
        /// 合并字符
        /// </summary>
        /// <param name="source">要合并的源字符串</param>
        /// <param name="target">要被合并到的目的字符串</param>
        /// <param name="mergechar">合并符</param>
        /// <returns>合并到的目的字符串</returns>
        public static string MergeString(string source, string target)
        {
            return MergeString(source, target, ",");
        }

        /// <summary>
        /// 合并字符
        /// </summary>
        /// <param name="source">要合并的源字符串</param>
        /// <param name="target">要被合并到的目的字符串</param>
        /// <param name="mergechar">合并符</param>
        /// <returns>并到字符串</returns>
        public static string MergeString(string source, string target, string mergechar)
        {
            if (Utils.StrIsNullOrEmpty(target))
                target = source;
            else
                target += mergechar + source;

            return target;
        }


        /// <summary>
        /// 清除UBB标签
        /// </summary>
        /// <param name="sDetail">帖子内容</param>
        /// <returns>帖子内容</returns>
        public static string ClearUBB(string sDetail)
        {
            return Regex.Replace(sDetail, @"\[[^\]]*?\]", string.Empty, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 获取站点根目录URL
        /// </summary>
        /// <returns></returns>
        public static string GetRootUrl(string forumPath)
        {
            int port = HttpContext.Current.Request.Url.Port;
            return string.Format("{0}://{1}{2}{3}",
                                 HttpContext.Current.Request.Url.Scheme,
                                 HttpContext.Current.Request.Url.Host.ToString(),
                                 (port == 80 || port == 0) ? "" : ":" + port,
                                 forumPath);
        }


        /// <summary>
        /// 获取指定文件的扩展名
        /// </summary>
        /// <param name="fileName">指定文件名</param>
        /// <returns>扩展名</returns>
        public static string GetFileExtName(string fileName)
        {
            if (Utils.StrIsNullOrEmpty(fileName) || fileName.IndexOf('.') <= 0)
                return "";

            fileName = fileName.ToLower().Trim();

            return fileName.Substring(fileName.LastIndexOf('.'), fileName.Length - fileName.LastIndexOf('.'));
        }


        /// <summary>
        /// 判断当前页面是否接收到了Post请求
        /// </summary>
        /// <returns>是否接收到了Post请求</returns>
        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }

        /// <summary>
        /// 判断当前页面是否接收到了Get请求
        /// </summary>
        /// <returns>是否接收到了Get请求</returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }

        /// <summary>
        /// 返回指定的服务器变量信息
        /// </summary>
        /// <param name="strName">服务器变量名</param>
        /// <returns>服务器变量信息</returns>
        public static string GetServerString(string strName)
        {
            if (HttpContext.Current.Request.ServerVariables[strName] == null)
                return "";

            return HttpContext.Current.Request.ServerVariables[strName].ToString();
        }

        /// <summary>
        /// 返回上一个页面的地址
        /// </summary>
        /// <returns>上一个页面的地址</returns>
        public static string GetUrlReferrer()
        {
            //string retVal = null;

            //try
            //{
            //    retVal = HttpContext.Current.Request.UrlReferrer.ToString();
            //}
            //catch { }

            //if (retVal == null)
            //    return "";

            //return retVal;
            return GetUrlReferrer(HttpContext.Current);
        }

        public static string GetUrlReferrer(HttpContext _httpContext)
        {
            string retVal = null;

            try
            {
                retVal = _httpContext.Request.UrlReferrer.ToString();
            }
            catch { }

            if (retVal == null)
                return "";

            return retVal;
        }

        /// <summary>
        /// 得到当前完整主机头
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentFullHost()
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;
            if (!request.Url.IsDefaultPort)
                return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());

            return request.Url.Host;
        }

        /// <summary>
        /// 得到主机头
        /// </summary>
        /// <returns></returns>
        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }


        /// <summary>
        /// 获取当前请求的原始 URL(URL 中域信息之后的部分,包括查询字符串(如果存在))
        /// </summary>
        /// <returns>原始 URL</returns>
        public static string GetRawUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }

        /// <summary>
        /// 判断当前访问是否来自浏览器软件
        /// </summary>
        /// <returns>当前访问是否来自浏览器软件</returns>
        public static bool IsBrowserGet()
        {
            string[] BrowserName = { "ie", "opera", "netscape", "mozilla", "konqueror", "firefox" };
            string curBrowser = HttpContext.Current.Request.Browser.Type.ToLower();
            for (int i = 0; i < BrowserName.Length; i++)
            {
                if (curBrowser.IndexOf(BrowserName[i]) >= 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否来自搜索引擎链接
        /// </summary>
        /// <returns>是否来自搜索引擎链接</returns>
        public static bool IsSearchEnginesGet()
        {
            if (HttpContext.Current.Request.UrlReferrer == null)
                return false;

            string[] SearchEngine = { "google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom", "yisou", "iask", "soso", "gougou", "zhongsou" };
            string tmpReferrer = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
            for (int i = 0; i < SearchEngine.Length; i++)
            {
                if (tmpReferrer.IndexOf(SearchEngine[i]) >= 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 获得当前完整Url地址
        /// </summary>
        /// <returns>当前完整Url地址</returns>
        public static string GetUrl()
        {
            //return HttpContext.Current.Request.Url.ToString();
            return GetUrl(HttpContext.Current);
        }
        public static string GetUrl(HttpContext _HttpContext)
        {
            if (!Equals(_HttpContext,null))
            _HttpContext.Request.Url.ToString();
            return string.Empty;
        }

        /// <summary>
        /// 获得指定Url参数的值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <returns>Url参数的值</returns>
        public static string GetQueryString(string strName)
        {
            return GetQueryString(strName, false);
        }

        /// <summary>
        /// 获得指定Url参数的值
        /// </summary> 
        /// <param name="strName">Url参数</param>
        /// <param name="sqlSafeCheck">是否进行SQL安全检查</param>
        /// <returns>Url参数的值</returns>
        public static string GetQueryString(string strName, bool sqlSafeCheck)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
                return "";

            if (sqlSafeCheck && !Utils.IsSafeSqlString(HttpContext.Current.Request.QueryString[strName]))
                return "unsafe string";

            return HttpContext.Current.Request.QueryString[strName];
        }

        /// <summary>
        /// 获得当前页面的名称
        /// </summary>
        /// <returns>当前页面的名称</returns>
        public static string GetPageName()
        {
            string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return urlArr[urlArr.Length - 1].ToLower();
        }

        /// <summary>
        /// 返回表单或Url参数的总个数
        /// </summary>
        /// <returns></returns>
        public static int GetParamCount()
        {
            return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
        }


        /// <summary>
        /// 获得指定表单参数的值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <returns>表单参数的值</returns>
        public static string GetFormString(string strName)
        {
            return GetFormString(strName, false);
        }

        /// <summary>
        /// 获得指定表单参数的值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <param name="sqlSafeCheck">是否进行SQL安全检查</param>
        /// <returns>表单参数的值</returns>
        public static string GetFormString(string strName, bool sqlSafeCheck)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
                return "";

            if (sqlSafeCheck && !Utils.IsSafeSqlString(HttpContext.Current.Request.Form[strName]))
                return "unsafe string";

            return HttpContext.Current.Request.Form[strName];
        }

        /// <summary>
        /// 获得Url或表单参数的值, 先判断Url参数是否为空字符串, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">参数</param>
        /// <returns>Url或表单参数的值</returns>
        public static string GetString(string strName)
        {
            //return HttpContext.Current.Request.QueryString[strName];
            return GetString(strName, false);
        }

        /// <summary>
        /// 获得Url或表单参数的值, 先判断Url参数是否为空字符串, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">参数</param>
        /// <param name="sqlSafeCheck">是否进行SQL安全检查</param>
        /// <returns>Url或表单参数的值</returns>
        public static string GetString(string strName, bool sqlSafeCheck)
        {
            if ("".Equals(GetQueryString(strName)))
                return GetFormString(strName, sqlSafeCheck);
            else
                return GetQueryString(strName, sqlSafeCheck);
        }

        /// <summary>
        /// 获得指定Url参数的int类型值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <returns>Url参数的int类型值</returns>
        public static int GetQueryInt(string strName)
        {
            return Utils.StrToInt(HttpContext.Current.Request.QueryString[strName], 0);
        }


        /// <summary>
        /// 获得指定Url参数的int类型值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url参数的int类型值</returns>
        public static int GetQueryInt(string strName, int defValue)
        {
            return Utils.StrToInt(HttpContext.Current.Request.QueryString[strName], defValue);
        }


        /// <summary>
        /// 获得指定表单参数的int类型值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>表单参数的int类型值</returns>
        public static int GetFormInt(string strName, int defValue)
        {
            return Utils.StrToInt(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// 获得指定Url或表单参数的int类型值, 先判断Url参数是否为缺省值, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">Url或表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url或表单参数的int类型值</returns>
        public static int GetInt(string strName, int defValue)
        {
            if (GetQueryInt(strName, defValue) == defValue)
                return GetFormInt(strName, defValue);
            else
                return GetQueryInt(strName, defValue);
        }

        /// <summary>
        /// 获得指定Url参数的float类型值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url参数的int类型值</returns>
        public static float GetQueryFloat(string strName, float defValue)
        {
            return Utils.StrToFloat(HttpContext.Current.Request.QueryString[strName], defValue);
        }


        /// <summary>
        /// 获得指定表单参数的float类型值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>表单参数的float类型值</returns>
        public static float GetFormFloat(string strName, float defValue)
        {
            return Utils.StrToFloat(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// 获得指定Url或表单参数的float类型值, 先判断Url参数是否为缺省值, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">Url或表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url或表单参数的int类型值</returns>
        public static float GetFloat(string strName, float defValue)
        {
            if (GetQueryFloat(strName, defValue) == defValue)
                return GetFormFloat(strName, defValue);
            else
                return GetQueryFloat(strName, defValue);
        }

       
        /// <summary>
        /// 格式化Uid为9位标准格式
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string FormatUid(string uid)
        {
            return String.Format("{0,9}", uid.Trim()).Replace(" ", "0");
        }
        /// <summary>
        /// 保存用户上传的文件
        /// </summary>
        /// <param name="path">保存路径</param>
        public static void SaveRequestFile(string path)
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                HttpContext.Current.Request.Files[0].SaveAs(path);
            }
        }
        ///// <summary>
        ///// 往根目录debug.txt 写日志。
        ///// </summary>
        ///// <param name="msg"></param>
        public static void TestDebug(string msg)
        {
            string sPath = HttpContext.Current.Server.MapPath("/debug.txt");

            FSO.FObject.WriteFile(sPath, string.Concat("\r\n----------"+DateTime.Now+"------------\r\n", msg), true);
        }
        /// <summary>
        /// 整型 1和0 转成 true false
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool ConvertBool(string key)
        {
            bool result = false;
            if (key == "1")
            {
                result = true;
            }
            else if (key == "0")
            {
                result = false;
            }
            else if (key == "true")
            {
                result = true;
            }
            else if (key == "True")
            {
                result = true;
            }
            else if (key == "false")
            {
                result = false;
            }
            else if (key == "False")
            {
                result = false;
            }
           
            return result;
        }


        /// <summary>
        /// 获取IP地址信息
        /// </summary>
        /// <param name="strIP">IP地址</param>
        /// <returns>区域ID</returns>
        public static Entity.ClientIpInfo GetAreaIDByIP(string strIP)
        {
            Entity.ClientIpInfo ipModel = new ClientIpInfo();
            ipModel = null;
            if (!string.IsNullOrEmpty(strIP))
            {
                try
                {
                    string strURL = string.Format("http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=js&ip={0}", strIP);
                    string strJson = EbSite.Core.WebUtility.LoadURLStringUTF8(strURL).Replace("var", "").Replace("remote_ip_info", "").Replace("=", "").Replace(";", "").Trim();
                    ipModel = JsonHelper.Deserialize<Entity.ClientIpInfo>(strJson); 
                    // ipModel = ModuleCore.BLL.orderhelp.Instance.BeiMaiDeserialize<ModuleCore.Entity.ClientIpInfo>(strJson);
                    //信息返回成功
                }
                catch
                {
                    ipModel = null;
                }
            }
            return ipModel;
        }
        /// <summary>
        /// 随机数从1-100
        /// </summary>
        /// <returns></returns>
        static public int GetRandNum()
        {
            int min = 1;
            int max = 100;
            Random a = new Random();
            int result = a.Next(min, max);

            return result;

        }
        static public int GetRandNum1000()
        {
            int min = 1;
            int max = 1000;
            Random a = new Random();
            int result = a.Next(min, max);

            return result;

        }
        static public int GetRandNum(int iMax,int iMin=1)
        {
            int min = iMin;
            int max = iMax;
            Random a = new Random();
            int result = a.Next(min, max);

            return result;

        }
        static  public bool IsMobileDevice(HttpContext httpContext)
        {
            string u = httpContext.Request.ServerVariables["HTTP_USER_AGENT"];
            Regex b = new Regex(@"android.+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino|ucweb|mqqbrowser", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(di|rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (string.IsNullOrEmpty(u))
            {
                return false;
            }
            else
            {
                if (b.IsMatch(u))
                {
                    return true;
                }
                return v.IsMatch(u.Substring(0, 4));
            }
        }

    }

}
