
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Core;
using EbSite.Core.FSO;

namespace EbSite.Control
{
    public enum EbUploadModel
    {
        Net默认组件 = 2,
        SWFUpload组件 = 1
    }

    [DefaultEvent("Click"), ToolboxData("<{0}:SWFUpload runat=server></{0}:SWFUpload>"), DefaultProperty("Text")]
    public class SWFUpload : EbSite.Control.WebControl, INamingContainer, IPostBackDataHandler, IUserContrlBase
    {
        public HiddenField _FileID = new HiddenField();
        public HiddenField _OldName = new HiddenField();
        public HiddenField _Value = new HiddenField();
        public TextBox txtBox = new TextBox();

        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            this.txtBox.ID = "fl" + this.ClientID;
            this.txtBox.HintInfo = base.HintInfo;
            this.txtBox.ReadOnly = true;

            this._Value.ID = "sp" + this.ClientID;
            this._OldName.ID = "ol" + this.ClientID;
            this._FileID.ID = "fid" + this.ClientID;
            if (!string.IsNullOrEmpty(this.LoadPath))
            {
                this.txtBox.Text = this.LoadPath;
            }
            this.Controls.Add(this._FileID);
            this.Controls.Add(this._OldName);
            this.Controls.Add(this._Value);
            this.Controls.Add(this.txtBox);
        }

        public virtual string GetBatchObID()
        {
            return "";
        }

        public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            string str = this._Value.Value;
            string str2 = postCollection[postDataKey];
            if (!str.Equals(str2))
            {
                this._Value.Value = str2;
                return true;
            }
            return false;
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("SWFUploadPublic"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "SWFUploadPublic", string.Format("<script type=\"text/javascript\">var UploadPluginPath='{0}';</script>", this.PluginPath));
            }
            if (this.UploadModel == EbUploadModel.SWFUpload组件)
            {
                if (!this.Page.ClientScript.IsClientScriptBlockRegistered("SWFUpload"))
                {
                    this.Page.ClientScript.RegisterClientScriptInclude("SWFUpload", string.Format("{0}swfupload.js", this.PluginPath));
                    this.Page.ClientScript.RegisterClientScriptInclude("a", string.Format("{0}SWFUploadUp.js", this.PluginPath));
                }
            }
            else if (!this.Page.ClientScript.IsClientScriptBlockRegistered("AspNetUpload"))
            {
                this.Page.ClientScript.RegisterClientScriptInclude("AspNetUpload", string.Format("{0}AspnetUpload.js", this.PluginPath));
            }
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("SWFUploadCSS"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "SWFUploadCSS", string.Format("<link type=\"text/css\" href=\"{0}sikn/css.css\" rel=\"stylesheet\" />", this.PluginPath));
            }
            base.OnPreRender(e);
        }

        public void RaisePostDataChangedEvent()
        {
        }

        protected override void Render(HtmlTextWriter output)
        {
            string str = string.Format("Add{0}", this.ClientID);
            string str2 = string.Format("Proc{0}", this.ClientID);

            string OutBtnIDTem = "";
            if (!string.IsNullOrEmpty(OutBtnID)) //目前指定外部上传按钮模式只支持 Net默认组件
            {
                this.UploadModel = EbUploadModel.Net默认组件;

                OutBtnIDTem = string.Format(" {0}.OutBtnID = \"{1}\";", this.JsObjID, this.OutBtnID);
            }

            if (this.UploadModel == EbUploadModel.Net默认组件)
            {
                output.Write("<div class=\"AspNetUpload\">");
                //if(string.IsNullOrEmpty(OutBtnID))
                //output.Write("<div class=\"AspNetUpload\">");
                //else
                //{
                //    output.Write("<div class=\"UploadNoShow\">");
                //}


            }
            output.Write("<table class='SWFUP' cellpadding=\"0\" cellspacing=\"0\">");
            output.Write("<tr>");
            output.Write("<td>");
            this.txtBox.Width = base.Width;
            this.txtBox.Height = base.Height;

            this.txtBox.RenderControl(output);
            this._Value.RenderControl(output);
            this._OldName.RenderControl(output);
            this._FileID.RenderControl(output);
            output.Write("</td><td class=\"SWFUPbtn\">");


            if (this.UploadModel == EbUploadModel.SWFUpload组件)
            {
                //output.Write("<div class=\"SWFUPbtn\">  <span  id=\"" + str + "\"  ></span></div>");
                output.Write("<span  id=\"" + str + "\"  ></span>");
            }
            else
            {
                output.Write("<span id=\"" + str + "\" ></span>");
            }
            output.Write("</td></tr>");
            output.Write("<tr>");
            output.Write("<td colspan=\"2\">");
            if (this.UploadModel == EbUploadModel.SWFUpload组件)
            {
                output.Write("<div class='SWFUPprogressBar' id=\"" + str2 + "\"><span>0%</span><div id=\"SWFUPprogress\" style=\"width:1px;\"></div></div>");
            }
            else
            {
                output.Write("<div   id=\"" + str2 + "\"></div>");
            }
            output.Write("</td></tr></table>");
            if (this.UploadModel == EbUploadModel.Net默认组件)
            {
                output.Write("</div>");
            }
            output.Write("<script type=\"text/javascript\">");
            output.Write("jQuery(function ($) {");
            string jsObjName = "EBSWFUpload";
            if (this.UploadModel == EbUploadModel.Net默认组件)
            {
                jsObjName = "AspNetUpload";

            }
            output.Write(string.Format(" {0} = new {5}();{0}.FileTextBoxID = \"{1}\";{0}.AddBntID = \"{2}\";{0}.ProgressID = \"{3}\"; {0}.FileidCtrID = \"{4}\";", new object[] { this.JsObjID, this.txtBox.ClientID, str, str2, this._FileID.ClientID, jsObjName }));
            if (!string.IsNullOrEmpty(this.SaveFolder))
            {
                output.Write(string.Format(" {0}.SaveFolder = \"{1}\";", this.JsObjID, HttpContext.Current.Server.UrlEncode(EbSite.Base.Host.Instance.EncodeByKey(this.SaveFolder))));
            }
            if (this.AllowSize > 0)
            {
                output.Write(string.Format(" {0}.AllSize = \"{1} KB\";", this.JsObjID, this.AllowSize));
            }
            if (!string.IsNullOrEmpty(this.AllowExt))
            {
                output.Write(string.Format(" {0}.Ext = \"{1} ({2})\";", this.JsObjID, this.ExtDes, this.AllowExt));
            }
            if (!string.IsNullOrEmpty(this.PostDataBntID))
            {
                output.Write(string.Format(" {0}.PostDataBntID = \"{1}\";", this.JsObjID, this.PostDataBntID));
            }
            output.Write(string.Format(" {0}.SavePathCtrID = \"{1}\";", this.JsObjID, this._Value.ClientID));
            output.Write(string.Format(" {0}.OldNameCtrID = \"{1}\";", this.JsObjID, this._OldName.ClientID));
            if (!string.IsNullOrEmpty(this.GetBatchObID()))
            {
                output.Write(string.Format(" {0}.BatchOB = {1};", this.JsObjID, this.GetBatchObID()));
            }
            //if (IsMakeSmallImg)
            //{
            //    output.Write(string.Format(" {0}.IsSmallImg = {1};", this.JsObjID, IsMakeSmallImg ? 1 : 0));
            //}

            if (!string.IsNullOrEmpty(OnUploadComplete))
            {
                output.Write(string.Concat(this.JsObjID, ".onUploadComplete =function(){ ", OnUploadComplete, "();};"));
            }
            output.Write(string.Format(" {0}.UserID=\"{1}\";", this.JsObjID, HttpContext.Current.Server.UrlEncode(EbSite.Base.Host.Instance.EncodeByKey(string.Concat(EbSite.Base.Host.Instance.UserID, ",", EbSite.Base.Host.Instance.OnlineID)))));
            output.Write(OutBtnIDTem);

            string ValStr = EbSite.Base.Host.Instance.EncodeByMD5(string.Concat(this.SaveFolder, this.AllowSize, Base.Host.Instance.EncodeByKey(this.AllowExt), EbSite.Base.Host.Instance.OnlineID, EbSite.Base.Host.Instance.UserID));


            output.Write(string.Format(" {0}.ValStr=\"{1}\";", this.JsObjID, ValStr));
            output.Write(string.Format(" {0}.Init();", this.JsObjID));
            output.Write("});");
            output.Write("</script>");
        }
        public string OutBtnID { get; set; }

        public string JsObjID
        {
            get { return string.Concat("EBUP", this.ClientID); }
        }
        //public bool IsMakeSmallImg
        //{
        //    get
        //    {
        //        object objA = this.ViewState["IsMakeSmallImg"];
        //        return (object.Equals(objA, null) ?false : bool.Parse(objA.ToString())) ;
        //    }
        //    set
        //    {
        //        this.ViewState["IsMakeSmallImg"] = value;
        //    }
        //}

        /// <summary>
        /// 允许上传文件的格式,rar,zip,dll
        /// </summary>
        public string AllowExt
        {
            get
            {
                object objA = this.ViewState["AllowExt"];
                return (object.Equals(objA, null) ? "" : objA.ToString());
            }
            set
            {
                this.ViewState["AllowExt"] = value;
            }
        }
        public string OnUploadComplete
        {
            get
            {
                object objA = this.ViewState["OnUploadComplete"];
                return (object.Equals(objA, null) ? "" : objA.ToString());
            }
            set
            {
                this.ViewState["OnUploadComplete"] = value;
            }
        }

        /// <summary>
        /// 允许上传文件的大小 单位为k
        /// </summary>
        public int AllowSize
        {
            get
            {
                object objA = this.ViewState["AllowSize"];
                if (!object.Equals(objA, null))
                {
                    return int.Parse(objA.ToString());
                }
                return 0;
            }
            set
            {
                this.ViewState["AllowSize"] = value;
            }
        }

        public string ExtDes
        {
            get
            {
                object objA = this.ViewState["ExtDes"];
                if (!object.Equals(objA, null))
                {
                    return objA.ToString();
                }
                return "选择文件";
            }
            set
            {
                this.ViewState["ExtDes"] = value;
            }
        }

        public string FileID
        {
            get
            {
                return this._FileID.Value;
            }
            set
            {
                this._FileID.Value = value;
            }
        }

        private string LoadPath
        {
            get
            {
                object objA = this.ViewState["LoadPath"];
                if (!object.Equals(objA, null))
                {
                    return objA.ToString();
                }
                return "";
            }
            set
            {
                this.ViewState["LoadPath"] = value;
            }
        }

        public string PluginPath
        {
            get
            {
                object objA = this.ViewState["PluginPath"];
                if (!object.Equals(objA, null))
                {
                    return objA.ToString();
                }
                return string.Format("{0}js/plugin/swfupload/", Base.AppStartInit.IISPath);
            }
            set
            {
                this.ViewState["PluginPath"] = value;
            }
        }
        /// <summary>
        /// 在上传的过程中，如果还没有上传完毕，不允许提交数据，这里要设置一个提交按钮的ID
        /// </summary>
        public string PostDataBntID
        {
            get
            {
                object objA = this.ViewState["PDBntID"];
                return (object.Equals(objA, null) ? "" : objA.ToString());
            }
            set
            {
                this.ViewState["PDBntID"] = value;
            }
        }
        /// <summary>
        /// 你可以更新文件的保存路径，如 imageup,那么默认情况 下会保存在UserSavePath下的imageup
        ///  2014-3-20 为了让网站更加安全，现在起，所有上传目录都会在前面加上 UserSavePath ，UserSavePath下不会有脚本执行权限
        /// </summary>
        public string SaveFolder
        {
            get
            {
                object objA = this.ViewState["SaveFolder"];
                if (Equals(objA, null))
                {
                    return "pc";
                    //return EbSite.Base.Host.Instance.CurrentSite.GetPathUpload();
                }
                else
                {
                    return objA.ToString();
                }
            }
            set
            {
                this.ViewState["SaveFolder"] = value;
            }
        }

        public EbUploadModel UploadModel
        {
            get
            {
                object objA = this.ViewState["UploadModel"];
                if (!object.Equals(objA, null))
                {
                    return (EbUploadModel)objA;
                }
                return EbUploadModel.SWFUpload组件;
            }
            set
            {
                this.ViewState["UploadModel"] = value;
            }
        }

        public string ValOldName
        {
            get
            {
                return this._OldName.Value;
            }
            set
            {
                this._OldName.Value = value;
            }
        }

        /// <summary>
        /// 上传的路径，也可以默认设置
        /// </summary>
        public string ValSavePath
        {
            get
            {
                if (!string.IsNullOrEmpty(this.FileID))
                {
                    if (!string.IsNullOrEmpty(this.LoadPath))
                    {
                        if (!object.Equals(this.LoadPath, this._Value.Value))
                        {

                            BLL.UploadFileInfoBLL.Instance.UpdataToSave(int.Parse(this.FileID));
                            string file = HttpContext.Current.Server.MapPath(this.LoadPath);
                            if (FObject.IsExist(file, FsoMethod.File))
                            {
                                FObject.Delete(file, FsoMethod.File);
                            }
                        }
                    }
                    else if (!string.IsNullOrEmpty(this._Value.Value.Trim()))
                    {

                        BLL.UploadFileInfoBLL.Instance.UpdataToSave(int.Parse(this.FileID));
                    }
                }


                return this._Value.Value;
            }
            set
            {
                this.LoadPath = value;
                this._Value.Value = value;
            }
        }

        virtual public string CtrValue
        {
            get
            {
                return ValSavePath;
            }
            set
            {
                ValSavePath = value;
            }
        }

    }
}

