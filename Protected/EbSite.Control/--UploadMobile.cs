
//using System;
//using System.Collections.Specialized;
//using System.ComponentModel;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using EbSite.BLL; 
//using EbSite.Core;
//using EbSite.Core.FSO;

//namespace EbSite.Control
//{


//    [DefaultEvent("Click"), ToolboxData("<{0}:UploadMobile runat=server></{0}:UploadMobile>"), DefaultProperty("Text")]
//    public class UploadMobile : EbSite.Control.WebControl, INamingContainer, IPostBackDataHandler, IUserContrlBase
//    {
//        public HiddenField _FileID = new HiddenField();
//        public HiddenField _OldName = new HiddenField();
//        public HiddenField _Value = new HiddenField();
//        public System.Web.UI.WebControls.TextBox txtBox = new System.Web.UI.WebControls.TextBox();

//        protected override void CreateChildControls()
//        {
            
//            this.Controls.Clear();
//            this.txtBox.ID = "fl" + this.ClientID;
//            //this.txtBox.HintInfo = base.HintInfo;
//            this.txtBox.ReadOnly = true;

//            this._Value.ID = "sp" + this.ClientID;
//            this._OldName.ID = "ol" + this.ClientID;
//            this._FileID.ID = "fid" + this.ClientID;
//            if (!string.IsNullOrEmpty(this.LoadPath))
//            {
//                this.txtBox.Text = this.LoadPath;
//            }
//            this.Controls.Add(this._FileID);
//            this.Controls.Add(this._OldName);
//            this.Controls.Add(this._Value);
//            this.Controls.Add(this.txtBox);
//        }

//        public virtual string GetBatchObID()
//        {
//            return "";
//        }
       
//        public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
//        {
//            string str = this._Value.Value;
//            string str2 = postCollection[postDataKey];
//            if (!str.Equals(str2))
//            {
//                this._Value.Value = str2;
//                return true;
//            }
//            return false;
//        }

//        protected override void OnPreRender(EventArgs e)
//        {
//            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("UploadMobilePublic"))
//            {
//                this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "ploaSWFUdPublic", string.Format("<script type=\"text/javascript\">var UploadPluginPath='{0}';</script>", this.PluginPath));
//            } if (!this.Page.ClientScript.IsClientScriptBlockRegistered("UploadMobile"))
//            {
//                this.Page.ClientScript.RegisterClientScriptInclude("UploadMobile", string.Format("{0}UploadMobile.js", this.PluginPath));
//            }
//            //if (!this.Page.ClientScript.IsClientScriptBlockRegistered("UploadMobileCSS"))
//            //{
//            //    this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "UploadMobileCSS", string.Format("<link type=\"text/css\" href=\"{0}sikn/css.css\" rel=\"stylesheet\" />", this.PluginPath));
//            //}
//            base.OnPreRender(e);
//        }

//        public void RaisePostDataChangedEvent()
//        {
//        }

//        protected override void Render(HtmlTextWriter output)
//        {
//            string sAddBtn = string.Format("Add{0}", this.ClientID);//添加按钮
//            string sRroc = string.Format("Proc{0}", this.ClientID);//进度显示

//            output.Write("<table class=\"UploadMobile\"><tr><td>");
//            //output.Write("<table class='SWFUP' cellpadding=\"0\" cellspacing=\"0\">");
//            //output.Write("<tr>");
//            //output.Write("<td>");
//            this.txtBox.CssClass = "txtvaluecss";
//            this.txtBox.Width = base.Width;
//            this.txtBox.Height = base.Height;
            
//            this.txtBox.RenderControl(output);
//            this._Value.RenderControl(output);
//            this._OldName.RenderControl(output);
//            this._FileID.RenderControl(output);
//            //output.Write("</td><td class=\"SWFUPbtn\">");
//            output.Write("<span id=\"{0}\" ></span>", sAddBtn);
//            //output.Write("</td></tr>");
//            //output.Write("<tr>");
//            //output.Write("<td colspan=\"2\">");
//            //output.Write("<div   id=\"" + str2 + "\"></div>");
//            //output.Write("</td></tr></table>");
//            output.Write("</td></tr></table>");
//            output.Write("<div id=\"{0}\"></div>", sRroc);

//            output.Write("<script type=\"text/javascript\">");
//            output.Write("Zepto(function ($) {");
//            string str3 = "AspNetUpload";

//            output.Write(string.Format("var EBUP{0} = new " + str3 + "();EBUP{0}.FileTextBoxID = \"{1}\";EBUP{0}.AddBntID = \"{2}\";EBUP{0}.ProgressID = \"{3}\"; EBUP{0}.FileidCtrID = \"{4}\";", new object[] { this.ClientID, this.txtBox.ClientID, sAddBtn, sRroc, this._FileID.ClientID }));
//            if (!string.IsNullOrEmpty(this.SaveFolder))
//            {
//                output.Write(string.Format(" EBUP{0}.SaveFolder = \"{1}\";", this.ClientID, this.SaveFolder));
//            }
//            if (this.AllowSize > 0)
//            {
//                output.Write(string.Format(" EBUP{0}.AllSize = \"{1} KB\";", this.ClientID, this.AllowSize));
//            }
//            if (!string.IsNullOrEmpty(this.AllowExt))
//            {
//                output.Write(string.Format(" EBUP{0}.Ext = \"{1} ({2})\";", this.ClientID, this.ExtDes, this.AllowExt));
//            }
//            if (!string.IsNullOrEmpty(this.PostDataBntID))
//            {
//                output.Write(string.Format(" EBUP{0}.PostDataBntID = \"{1}\";", this.ClientID, this.PostDataBntID));
//            }
//            output.Write(string.Format(" EBUP{0}.SavePathCtrID = \"{1}\";", this.ClientID, this._Value.ClientID));
//            output.Write(string.Format(" EBUP{0}.OldNameCtrID = \"{1}\";", this.ClientID, this._OldName.ClientID));
//            if (!string.IsNullOrEmpty(this.GetBatchObID()))
//            {
//                output.Write(string.Format(" EBUP{0}.BatchOB = {1};", this.ClientID, this.GetBatchObID()));
//            }
//            if (IsMakeSmallImg)
//            {
//                output.Write(string.Format(" EBUP{0}.IsSmallImg = {1};", this.ClientID, IsMakeSmallImg?1:0));
//            }

//            if (!string.IsNullOrEmpty(OnUploadComplete))
//            {
//                output.Write(string.Concat(" EBUP", this.ClientID, ".onUploadComplete =function(){ ", OnUploadComplete, "();};"));
//            }

//            output.Write(string.Format(" EBUP{0}.Init();", this.ClientID));
//            output.Write("});");
//            output.Write("</script>");
//        }

//        public bool IsMakeSmallImg
//        {
//            get
//            {
//                object objA = this.ViewState["IsMakeSmallImg"];
//                return (object.Equals(objA, null) ?false : bool.Parse(objA.ToString())) ;
//            }
//            set
//            {
//                this.ViewState["IsMakeSmallImg"] = value;
//            }
//        }

//        /// <summary>
//        /// 允许上传文件的格式,rar,zip,dll
//        /// </summary>
//        public string AllowExt
//        {
//            get
//            {
//                object objA = this.ViewState["AllowExt"];
//                return (object.Equals(objA, null) ? "" : objA.ToString());
//            }
//            set
//            {
//                this.ViewState["AllowExt"] = value;
//            }
//        }
//        public string OnUploadComplete
//        {
//            get
//            {
//                object objA = this.ViewState["OnUploadComplete"];
//                return (object.Equals(objA, null) ? "" : objA.ToString());
//            }
//            set
//            {
//                this.ViewState["OnUploadComplete"] = value;
//            }
//        }
        
//        /// <summary>
//        /// 允许上传文件的大小 单位为k
//        /// </summary>
//        public int AllowSize
//        {
//            get
//            {
//                object objA = this.ViewState["AllowSize"];
//                if (!object.Equals(objA, null))
//                {
//                    return int.Parse(objA.ToString());
//                }
//                return 0;
//            }
//            set
//            {
//                this.ViewState["AllowSize"] = value;
//            }
//        }

//        public string ExtDes
//        {
//            get
//            {
//                object objA = this.ViewState["ExtDes"];
//                if (!object.Equals(objA, null))
//                {
//                    return objA.ToString();
//                }
//                return "选择文件";
//            }
//            set
//            {
//                this.ViewState["ExtDes"] = value;
//            }
//        }

//        public string FileID
//        {
//            get
//            {
//                return this._FileID.Value;
//            }
//            set
//            {
//                this._FileID.Value = value;
//            }
//        }

//        private string LoadPath
//        {
//            get
//            {
//                object objA = this.ViewState["LoadPath"];
//                if (!object.Equals(objA, null))
//                {
//                    return objA.ToString();
//                }
//                return "";
//            }
//            set
//            {
//                this.ViewState["LoadPath"] = value;
//            }
//        }

//        public string PluginPath
//        {
//            get
//            {
//                object objA = this.ViewState["PluginPath"];
//                if (!object.Equals(objA, null))
//                {
//                    return objA.ToString();
//                }
//                return string.Format("{0}js/plugin/swfupload/", Base.AppStartInit.IISPath);
//            }
//            set
//            {
//                this.ViewState["PluginPath"] = value;
//            }
//        }
//        /// <summary>
//        /// 在上传的过程中，如果还没有上传完毕，不允许提交数据，这里要设置一个提交按钮的ID
//        /// </summary>
//        public string PostDataBntID
//        {
//            get
//            {
//                object objA = this.ViewState["PDBntID"];
//                return (object.Equals(objA, null) ? "" : objA.ToString());
//            }
//            set
//            {
//                this.ViewState["PDBntID"] = value;
//            }
//        }
//        /// <summary>
//        /// 你可以更新文件的保存路径，如 test,那么默认情况 下会保存在UserSavePath下的test
//        /// 但 /test将会向网站根目录创建test并保存在此目录下
//        /// </summary>
//        public string SaveFolder
//        {
//            get
//            {
//                object objA = this.ViewState["SaveFolder"];
//                if (Equals(objA, null))
//                {

//                    return "mobile";
//                    //return EbSite.Base.Host.Instance.CurrentSite.GetPathUpload();
//                }
//                else
//                {
//                    return objA.ToString();
//                }
//            }
//            set
//            {
//                this.ViewState["SaveFolder"] = value;
//            }
//        }

   

//        public string ValOldName
//        {
//            get
//            {
//                return this._OldName.Value;
//            }
//            set
//            {
//                this._OldName.Value = value;
//            }
//        }
        
//        /// <summary>
//        /// 上传的路径，也可以默认设置
//        /// </summary>
//        public string ValSavePath
//        {
//            get
//            {
//                if (!string.IsNullOrEmpty(this.LoadPath))
//                {
//                    if (!object.Equals(this.LoadPath, this._Value.Value))
//                    {
//                       // UploadFileInfoBLL obll = new UploadFileInfoBLL();
//                        BLL.UploadFileInfoBLL.Instance.UpdataToSave(int.Parse(this.FileID));//new Guid(this.FileID)
//                        string file = HttpContext.Current.Server.MapPath(this.LoadPath);
//                        if (FObject.IsExist(file, FsoMethod.File))
//                        {
//                            FObject.Delete(file, FsoMethod.File);
//                        }
//                    }
//                }
//                else if (!string.IsNullOrEmpty(this._Value.Value.Trim()))
//                {
//                    //new UploadFileInfoBLL().UpdataToSave(new Guid(this.FileID));
//                    BLL.UploadFileInfoBLL.Instance.UpdataToSave(int.Parse(this.FileID));
//                }
//                return this._Value.Value;
//            }
//            set
//            {
//                this.LoadPath = value;
//                this._Value.Value = value;
//            }
//        }

//       virtual public string CtrValue
//        {
//            get
//            {
//                return ValSavePath;
//            }
//            set
//            {
//                ValSavePath = value;
//            }
//        }

//    }
//}

