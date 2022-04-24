
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.Control
{


    [DefaultProperty("Text"), ToolboxData("<{0}:SWFUploadMore runat=server></{0}:SWFUploadMore>"), DefaultEvent("Click")]
    public class SWFUploadMore : SWFUpload
    {
        private HiddenField _BatchValueID = new HiddenField();

        public SWFUploadMore()
        {
            base.Width = 250;
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            this._BatchValueID.ID = "Bat" + this.ID;
            this.Controls.Add(this._BatchValueID);
        }

        public override string GetBatchObID()
        {
            return ("Batch" + this.ClientID);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("BatchUpload"))
            {
                this.Page.ClientScript.RegisterClientScriptInclude("BatchUpload", string.Format("{0}Batch.js", base.PluginPath));
            }
            base.OnPreRender(e);
        }

        protected override void Render(HtmlTextWriter output)
        {
            if (!this.IsRead)
            {
                output.Write("<table  cellpadding=\"0\"  ><tr><td>");
                base.Render(output);
            }
            string sTitleName = "名称";
            //if (base.IsMakeSmallImg)
            //{
            //    sTitleName = "缩略图";
            //}
            output.Write("<table class=\"UploadBatchTable\" cellspacing=\"0\"  border=\"1\" id=\"" + this.ClientID + "\" style=\"border-collapse:collapse;\">");
            output.Write("<tr class=\"UploadBatchHeader\"><th scope=\"col\">" + sTitleName + "</th><th scope=\"col\">类型</th><th scope=\"col\">操作</th></tr>");
            if (this._ValueItems.Count > 0)
            {
                for (int i = 0; i < this._ValueItems.Count; i++)
                {
                    UploadFileInfo info = _ValueItems[i];
                    string str = "";
                    if (!this.IsRead)
                    {
                        str = "<span class='batchdel' >删除</span>";
                    }
                    string sAddBtnNameHtml = "";
                    string sRowInputID = string.Concat("buploadrow", this.ID, i);
                    if (!string.IsNullOrEmpty(AddBtnName))
                    {
                        sAddBtnNameHtml = string.Format("<span onclick=\"AddBtnName('{1}')\">{0}</span>", AddBtnName, sRowInputID);
                    }

                    output.Write(string.Format("<tr><td><input id=\"{3}\" type=\"hidden\" newname=\"{0}\" value=\"{1}\" oldname=\"{2}\"  /></td><td></td><td>" + str + "<span class='batchdown'>打开</span>{4}</td></tr>", info.FileNewName, info.id, info.FileOldName, sRowInputID, sAddBtnNameHtml));
                }
                //foreach (UploadFileInfo info in this._ValueItems)
                //{

                //}
            }
            output.Write("</table>");
            if (!this.IsRead)
            {
                output.Write("</td></tr></table>");
            }
            this._BatchValueID.RenderControl(output);
            output.Write("<script type=\"text/javascript\">");
            output.Write("var " + this.GetBatchObID() + " = new BatchUpload();");
            output.Write(this.GetBatchObID() + ".BatchID = \"" + this.ClientID + "\";");
            output.Write(this.GetBatchObID() + ".BatchValueID = \"" + this._BatchValueID.ClientID + "\";");
            //if(base.IsMakeSmallImg)
            //{
            //    output.Write(this.GetBatchObID() + ".IsSmallImg = true;");
            //}
            if (!string.IsNullOrEmpty(AddBtnName))
            {
                output.Write(this.GetBatchObID() + ".AddBtnName = \"" + AddBtnName + "\";");
            }

            output.Write(this.GetBatchObID() + ".Init();");

            output.Write("</script>");
        }
        public string AddBtnName
        {
            get
            {
                object objA = ViewState["AddBtnName"];
                if (!object.Equals(objA, null))
                {
                    return objA.ToString();
                }
                return "";
            }
            set
            {
                ViewState["AddBtnName"] = value;
            }
        }
        public List<UploadFileInfo> _ValueItems
        {
            get
            {
                string[] strArray = this._BatchValueID.Value.Split(new char[] { '*' });
                List<UploadFileInfo> list = new List<UploadFileInfo>();
                foreach (string str2 in strArray)
                {
                    if (!string.IsNullOrEmpty(str2))
                    {
                        string[] strArray2 = str2.Split(new char[] { ':' });
                        UploadFileInfo item = new UploadFileInfo();
                        item.id = int.Parse(strArray2[0]); // new Guid(strArray2[0]);
                        item.FileNewName = strArray2[1];
                        item.FileOldName = strArray2[2];
                        list.Add(item);
                    }
                }
                return list;
            }
        }

        public string BatchFileID
        {
            get
            {
                object objA = this.ViewState["BatchFileID"];
                if (!object.Equals(objA, null))
                {
                    return objA.ToString();
                }
                string randomFileName = Path.GetRandomFileName();
                this.ViewState["BatchFileID"] = randomFileName;
                return randomFileName;
            }
            set
            {
                this.ViewState[this.ClientID + "FileID"] = value;
            }
        }

        private List<UploadFileInfo> InitValue
        {
            get
            {
                object objA = this.ViewState["InitValue"];
                if (!object.Equals(objA, null))
                {
                    return (objA as List<UploadFileInfo>);
                }
                return new List<UploadFileInfo>();
            }
            set
            {
                this.ViewState["InitValue"] = value;
            }
        }

        public bool IsRead
        {
            get
            {
                object obj2 = this.ViewState["IsRead"];
                return ((obj2 != null) && ((bool)obj2));
            }
            set
            {
                this.ViewState["IsRead"] = value;
            }
        }

        private string _CtrValueSplit = ",";
        public string CtrValueSplit
        {
            get { return _CtrValueSplit; }
            set { _CtrValueSplit = value; }

        }

        override public string CtrValue
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                //foreach (UploadFileInfo valueItem in ValueItems)
                //{
                //    sb.Append(valueItem.FileNewName);
                //    sb.Append(CtrValueSplit);
                //}
                if (ValueItems.Count > 0)
                {
                    for (int i = ValueItems.Count - 1; i >= 0; i--)
                    {
                        UploadFileInfo valueItem = ValueItems[i];
                        sb.Append(valueItem.FileNewName);
                        sb.Append(CtrValueSplit);
                    }
                }


                if (sb.Length > CtrValueSplit.Length) sb.Remove(sb.Length - CtrValueSplit.Length, CtrValueSplit.Length);
                return sb.ToString();
            }
            set
            {

                string[] arr = Core.Strings.GetString.SplitString(value, CtrValueSplit);
                List<UploadFileInfo> lst = new List<UploadFileInfo>();
                foreach (string s in arr)
                {
                    UploadFileInfo md = new UploadFileInfo();
                    md.FileNewName = s;
                    lst.Add(md);
                }
                ValueItems = lst;

            }
        }

        public List<UploadFileInfo> ValueItems
        {
            get
            {
                List<UploadFileInfo> list = this._ValueItems;
                // UploadFileInfoBLL obll = new UploadFileInfoBLL();
                List<UploadFileInfo> list2 = new List<UploadFileInfo>();
                foreach (UploadFileInfo info in list)
                {
                    if (!this.InitValue.Contains(info))
                    {
                        BLL.UploadFileInfoBLL.Instance.UpdataToSave(info.id);
                    }
                    else
                    {
                        list2.Add(info);
                    }
                }
                foreach (UploadFileInfo info in this.InitValue)
                {
                    if (!list2.Contains(info))
                    {
                        string file = HttpContext.Current.Server.MapPath(info.FileNewName);
                        if (FObject.IsExist(file, FsoMethod.File))
                        {
                            FObject.Delete(file, FsoMethod.File);
                        }
                    }
                }
                return list;
            }
            set
            {
                this.InitValue = value;
                List<UploadFileInfo> list = value;
                StringBuilder builder = new StringBuilder();
                foreach (UploadFileInfo info in list)
                {
                    builder.AppendFormat("{0}:{1}:{2}*", info.id, info.FileNewName, info.FileOldName);
                }
                if (builder.Length > 0)
                {
                    builder.Remove(builder.Length - 1, 1);
                }
                this._BatchValueID.Value = builder.ToString();
            }
        }
    }
}

