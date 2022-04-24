using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;
using EbSite.Core.FSO;

namespace EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace
{
    public partial class LayoutPaneAdd : MPUCBaseSave
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("5c8fbe9a-b127-4ba9-aa58-1cfece2b45d4");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        public override string Permission
        {
            get
            {
                return "10";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
            BLL.LayoutPane.Instance.InitModifyCtr(new Guid(SID), phCtrList);
        }
        override protected void SaveModel()
        {
            if (this.puICOImg.ValSavePath == "")
            {
                base.ShowTipsPop("请上传缩略图。");
            }
            else
            {
                if(string .IsNullOrEmpty(SID))
                {
                    string fUrl = HttpContext.Current.Server.MapPath(IISPath + "home/layoutpanes/" + this.FileName.Text + ".ascx");
                    #region 检测此文件夹是否存在
                    bool key = EbSite.Core.FSO.FObject.IsExist(fUrl, FsoMethod.File);
                    #endregion
                    if (key)
                    {
                        base.ShowTipsPop("已经存在" + this.FileName.Text + "这个文件。");
                    }
                    else
                    {
                        #region 生成文件 home/layoutpanes
                        EbSite.Core.FSO.FObject.WriteFile(fUrl, "");
                        #endregion

                        #region 把上传的图片给复制到home/layoutpanes下

                        string oldfile = HttpContext.Current.Server.MapPath(this.puICOImg.ValSavePath);
                        string newfile =
                            HttpContext.Current.Server.MapPath(IISPath + "home/layoutpanes/" + this.FileName.Text + ".jpg");
                        EbSite.Core.FSO.FObject.CopyFile(oldfile, newfile);

                        #endregion

                        BLL.LayoutPane.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
                        base.ShowTipsPop("保存成功");
                    }
                }
                else
                {
                    BLL.LayoutPane.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
                    base.ShowTipsPop("修改成功");
                }
               
            }
        }
    }
}