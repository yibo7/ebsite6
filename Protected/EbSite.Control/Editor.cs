using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL; 
using EbSite.Core;
using EbSite.Core.Strings;
using EbSite.Entity;

namespace EbSite.Control
{
    public enum EditorToolsType:int
    {
        简单模式 = 1,
        标准模式 = 2,
        全功能模式 = 3,
        
    }

    [DefaultEvent("Click"), DefaultProperty("Text"), ToolboxData("<{0}:Editor runat=server></{0}:Editor>")]
    public class Editor : System.Web.UI.WebControls.TextBox, IUserContrlBase
    {
        public string CtrValue
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }
        public Editor()
        {
            this.TextMode = TextBoxMode.MultiLine;
            base.Load += new EventHandler(this.Page_Load);
            this.Width = 500;
            this.Height = 300;
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("Editor"))
            {
                this.Page.ClientScript.RegisterClientScriptInclude("Editor", string.Format("{0}js/plugin/editbox/xheditor.js", Base.AppStartInit.IISPath));
                this.Page.ClientScript.RegisterClientScriptInclude("EditorPlugin", string.Format("{0}js/plugin/editbox/box.js", Base.AppStartInit.IISPath));
                
            }
            if (this.IsUBB && !this.Page.ClientScript.IsClientScriptBlockRegistered("EditorUBB"))
            {
                this.Page.ClientScript.RegisterClientScriptInclude("EditorUBB", string.Format("{0}js/plugin/editbox/xheditor_plugins/ubb.min.js", Base.AppStartInit.IISPath));
            }
            base.OnPreRender(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                this.ViewState["UpFiles"] = HttpContext.Current.Request["fsEditor"];
            }
            //else
            //{
            //    base.Width = 600;
            //    base.Height = 250;
            //}
        }
        /// <summary>
        /// 要保存的文件夹,如果文件夹名称前加上 /，表示不使用系统默认根目录保存路径
        /// </summary>
        public string SaveFolder
        {

            get
            {
                return "editebox";
            }
            //get
            //{
            //    object objA = this.ViewState["SaveFolder"];
            //    return (object.Equals(objA, null) ? string.Concat(EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.UploadPath,"") : objA.ToString());
            //}
            //set
            //{
            //    this.ViewState["SaveFolder"] = value;
            //}
        }
        protected override void Render(HtmlTextWriter output)
        {
            base.Render(output);
            output.Write("<input type=\"hidden\" name=\"fsEditor\" id=\"fsEditor\" />");
            string str = "Eb" + this.UniqueID;
            string str2 = "full";
            string sPluginPram = ", plugins: plugins";
            //string sUpFilePram = "";
            //string sUpFlashPram = "";
            //string sUpImgPram = "";
            //string sUpMediaPram = "";
            string sUBBPram = "";
            if (this.EditorTools == EditorToolsType.标准模式)
            {
                str2 = "simple";
            }
            else if (this.EditorTools == EditorToolsType.简单模式)
            {
                str2 = "mini";
                sPluginPram = "";
            }
             

            if (this.IsUBB)
            {
                sUBBPram = ",showBlocktag:false,forcePtag:false,beforeSetSource:ubb2html,beforeGetSource:html2ubb";
            }

            string str9 = string.Concat("OnUp" , this.ClientID);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<script> var ");
            stringBuilder.Append(this.ClientOB);
            stringBuilder.Append("; $(");
            stringBuilder.Append(str);
            stringBuilder.Append("Init);function ");
            stringBuilder.Append(str);
            stringBuilder.Append("Init(){");
            stringBuilder.Append(this.ClientOB);
            stringBuilder.Append("=$('#");
            stringBuilder.Append(this.ClientID);
            stringBuilder.Append("').xheditor({ onUpload:");
            stringBuilder.Append(str9);
            stringBuilder.Append(",emots:emots,emotMark:true,tools: '");
            stringBuilder.Append(str2);
            stringBuilder.Append("'");
            //stringBuilder.Append(string.Concat(sPluginPram, sUBBPram, sUpFlashPram, sUpFilePram, sUpImgPram, sUpMediaPram));
            stringBuilder.Append(string.Concat(sPluginPram, sUBBPram));
            stringBuilder.Append(" });");

            //string reg = "/^https?:\\/\\/[^\\/]*?(xheditor\\.com)\\//i";//不好处理，暂时放下

            //string valstrExtImg = "";

            //string valstrExtLink = "";
            //string valstrExtFlash = "";
            //string valstrExtMedia = "";
            //if (!string.IsNullOrEmpty(ExtImg))
            //{
            //    valstrExtImg = EbSite.Base.Host.Instance.EncodeByMD5(string.Concat(this.SaveFolder, this.Size, this.ExtImg, EbSite.Base.Host.Instance.OnlineID, EbSite.Base.Host.Instance.UserID));
            //}

            //if (!string.IsNullOrEmpty(ExtLink))
            //{
            //    valstrExtImg = EbSite.Base.Host.Instance.EncodeByMD5(string.Concat(this.SaveFolder, this.Size, this.ExtLink, EbSite.Base.Host.Instance.OnlineID, EbSite.Base.Host.Instance.UserID));
            //}

            //if (!string.IsNullOrEmpty(ExtFlash))
            //{
            //    valstrExtFlash = EbSite.Base.Host.Instance.EncodeByMD5(string.Concat(this.SaveFolder, this.Size, this.ExtFlash, EbSite.Base.Host.Instance.OnlineID, EbSite.Base.Host.Instance.UserID));
            //}

            stringBuilder.AppendFormat("InitUpload({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}');",
                this.ClientOB, this.ExtImg, this.ExtLink, this.ExtFlash, this.ExtMedia, GetValStr(this.ExtImg), GetValStr(ExtLink), GetValStr(ExtFlash), GetValStr(ExtMedia), UploadPram, "");
            stringBuilder.Append("};");
            output.Write(stringBuilder);
            //output.Write("<script> var " + this.ClientOB + "; $(" + str + "Init);function " + str + "Init(){" + this.ClientOB + "=$('#" + this.ClientID + "').xheditor({ onUpload:" + str9 + ",emots:emots,emotMark:true,tools: '" + str2 + "'" + str3 + str8 + str5 + str4 + str6 + str7 + " });};");
            output.Write(" function " + str9 + "(arrMsg){OnFileUpload(arrMsg,'fsEditor')}");
            output.Write("</script>");
        }

        private string GetValStr(string ext)
        {
            if (!string.IsNullOrEmpty(ext))
            {
                string sextKey = EbSite.Base.Host.Instance.EncodeByKey(ext);
                //Core.Utils.TestDebug(string.Concat("path:", this.SaveFolder));
                return EbSite.Base.Host.Instance.EncodeByMD5(string.Concat(this.SaveFolder, this.Size, sextKey, EbSite.Base.Host.Instance.OnlineID, EbSite.Base.Host.Instance.UserID));

            }
            
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 获取客户端的操作对像
        /// </summary>
        public string ClientOB
        {
            get
            {
                return ("edb" + this.ClientID);
            }
        }

        public EditorToolsType EditorTools
        {
            get
            {
                object objA = this.ViewState["EditorTools"];
                if (!object.Equals(objA, null))
                {
                    return (EditorToolsType)objA;
                }
                return EditorToolsType.全功能模式;
            }
            set
            {
                this.ViewState["EditorTools"] = value;
            }
        }
        /// <summary>
        /// 上传flash的后缀
        /// </summary>
        public string ExtFlash
        {
            get
            {
                object objA = this.ViewState["FlashExt"];
                if (!object.Equals(objA, null))
                {
                    return objA.ToString();
                }
                return "";
            }
            set
            {
                this.ViewState["FlashExt"] = value;
            }
        }
        /// <summary>
        /// 图片文件的后缀
        /// </summary>
        public string ExtImg
        {
            get
            {
                object objA = this.ViewState["ImgExt"];
                if (!object.Equals(objA, null))
                {
                    return objA.ToString();
                }
                return "";
            }
            set
            {
                this.ViewState["ImgExt"] = value;
            }
        }
        /// <summary>
        /// 文件连接的后缀
        /// </summary>
        public string ExtLink
        {
            get
            {
                object objA = this.ViewState["LinkExt"];
                if (!object.Equals(objA, null))
                {
                    return objA.ToString();
                }
                return "";
            }
            set
            {
                this.ViewState["LinkExt"] = value;
            }
        }
        /// <summary>
        /// 视频文件的后缀
        /// </summary>
        public string ExtMedia
        {
            get
            {
                object objA = this.ViewState["MediaExt"];
                if (!object.Equals(objA, null))
                {
                    return objA.ToString();
                }
                return "";
            }
            set
            {
                this.ViewState["MediaExt"] = value;
            }
        }

        public List<UploadFileInfo> GetUploadFiles
        {
            get
            {
                string strSplit = "}*{";
                string strContent = this.ViewState["UpFiles"] as string;
                string[] strArray = GetString.SplitString(strContent, strSplit);
                List<UploadFileInfo> list = new List<UploadFileInfo>();
                foreach (string str4 in strArray)
                {
                    string[] strArray2 = str4.Split(new char[] { '*' });
                    if (strArray2.Length == 3)
                    {
                        UploadFileInfo item = new UploadFileInfo();
                        item.id = int.Parse(strArray2[0]); //new Guid(strArray2[0]);
                        item.FileNewName = strArray2[1];
                        item.FileOldName = strArray2[2];
                        list.Add(item);
                    }
                }
                return list;
            }
        }

        public string GetValue
        {
            get
            {
                //UploadFileInfoBLL obll = new UploadFileInfoBLL();
                foreach (UploadFileInfo info in this.GetUploadFiles)
                {
                  BLL.UploadFileInfoBLL.Instance.UpdataToSave(info.id);
                }
                return this.Text;
            }
        }

        public bool IsQuickUp
        {
            get
            {
                object objA = this.ViewState["IsQuickUp"];
                if (!object.Equals(objA, null))
                {
                    return bool.Parse(objA.ToString());
                }
                return true;
            }
            set
            {
                this.ViewState["IsQuickUp"] = value;
            }
        }

        public bool IsUBB
        {
            get
            {
                object objA = this.ViewState["IsUBB"];
                return (!object.Equals(objA, null) && bool.Parse(objA.ToString()));
            }
            set
            {
                this.ViewState["IsUBB"] = value;
            }
        }
        /// <summary>
        /// 大小 kb
        /// </summary>
        public int Size
        {
            get
            {
                object objA = this.ViewState["Size"];
                if (!object.Equals(objA, null))
                {
                    return int.Parse(objA.ToString());
                }
                return 100;
            }
            set
            {
                this.ViewState["Size"] = value;
            }
        }
        public bool IsMakeSmallImg
        {
            get
            {
                object objA = this.ViewState["IsMakeSmallImg"];
                return (object.Equals(objA, null) ? false : bool.Parse(objA.ToString()));
            }
            set
            {
                this.ViewState["IsMakeSmallImg"] = value;
            }
        }
        public string UploadPram
        {
            get
            {
                object objA = this.ViewState["PluginPath"];
                if (!object.Equals(objA, null))
                {
                    return objA.ToString();
                }
                string strPramSize = "";
                if (this.Size > 0)
                {
                    strPramSize = "&sz=" + this.Size;
                }
                string strPramIsQuickUp = "";
                if (this.IsQuickUp)
                {
                    strPramIsQuickUp = "&im=1";
                }
                string sSaveFolder = "";
                if (!string.IsNullOrEmpty(SaveFolder))
                {
                    sSaveFolder = string.Concat("&folder=", HttpContext.Current.Server.UrlEncode(Base.Host.Instance.EncodeByKey(SaveFolder)));
                }
                //string ValStr = EbSite.Base.Host.Instance.EncodeByMD5(string.Concat(this.SaveFolder, this.Size,  EbSite.Base.Host.Instance.OnlineID));
                string sUserIDKey = HttpContext.Current.Server.UrlEncode(EbSite.Base.Host.Instance.EncodeByKey(string.Concat(EbSite.Base.Host.Instance.UserID, ",", EbSite.Base.Host.Instance.OnlineID)));

                //return string.Format("tp=1{0}{1}{2}&valstr={3}&userid={4}", strPramSize, strPramIsQuickUp, sSaveFolder, ValStr, sUserIDKey);
                string IsMakeSmallImgPram = "";
                if (IsMakeSmallImg)
                {
                    IsMakeSmallImgPram = "&issmallimg=1";
                }
                string sPram =  string.Format("tp=1{0}{1}{2}&userid={3}{4}", strPramSize, strPramIsQuickUp, sSaveFolder, sUserIDKey, IsMakeSmallImgPram);
                //sPram = HttpContext.Current.Server.UrlEncode(sPram);
                return sPram;
            }
        }

        //public string UploadPluginPath
        //{
        //    get
        //    {
        //        object objA = this.ViewState["PluginPath"];
        //        if (!object.Equals(objA, null))
        //        {
        //            return objA.ToString();
        //        }
        //        string str = "";
        //        if (this.Size > 0)
        //        {
        //            str = "&sz=" + this.Size;
        //        }
        //        string str2 = "";
        //        if (this.IsQuickUp)
        //        {
        //            str2 = "&im=1";
        //        }
        //        string sSaveFolder = "";
        //        if (!string.IsNullOrEmpty(SaveFolder))
        //        {
        //            sSaveFolder = "&folder=" + SaveFolder;
        //        }
        //        return string.Format("{0}js/plugin/swfupload/UpSingleFile.ashx?tp=1{1}{2}{3}", Base.AppStartInit.IISPath, str, str2, sSaveFolder);
        //    }
        //    set
        //    {
        //        this.ViewState["PluginPath"] = value;
        //    }
        //}
    }
}
