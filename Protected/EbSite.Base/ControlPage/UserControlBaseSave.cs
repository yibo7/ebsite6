
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Datastore;
using EbSite.Pages;

namespace EbSite.Base.ControlPage
{
    abstract public class UserControlBaseSave: UserControlBase
    {
       
        #region 属性

        protected global::System.Web.UI.HtmlControls.HtmlGenericControl divsteptips;
        protected EbSite.Control.Button bntSave;
        protected PlaceHolder phCtrList;
        abstract protected string KeyColumnName{ get;}
        private string _SID;
        protected string SID  //有时可能要手动给ID赋值
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                    return Request["id"];
                else
                {
                    return _SID;
                }
            }
            set
            {
                _SID = value;
            }
        }
        protected List<OtherColumn> lstOtherColumn = new List<OtherColumn>();
        #endregion

        public UserControlBaseSave()
        {
           
            this.Load += new EventHandler(BasePage_Load);
        }
        virtual protected void InitDivsteptips()
        {
            if (!Equals(divsteptips, null))
            {
                divsteptips.InnerHtml = "编辑数据 [<a onclick=\"javascript:history.go(-1);\">返回</a>]";
                //divsteptips.InnerHtml = string.Format("<div class=\"col-lg-12\"><div class=\"card-box\">{0}</div></div>", "编辑数据 [<a onclick=\"javascript:history.go(-1);\">返回</a>]");
            }
                
        }
        private void BasePage_Load(object sender, EventArgs e)
        {
            OnBasePageLoading();
            
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(SID))
                {
                    InitModifyCtr();
                    InitModifyCtred();
                }
                //else
                //{
                //    if (!Equals(btnOutPutExcel, null))
                //        btnOutPutExcel.Visible = false;
                //    if (!Equals(btnOutPutWord, null))
                //        btnOutPutWord.Visible = false;
                   
                //}
                InitDivsteptips();
                
            }
            if (!string.IsNullOrEmpty(SID))
            {
                if(!Equals(phCtrList,null))
                {
                    HiddenField hf = new HiddenField();
                    hf.ID = KeyColumnName;
                    hf.Value = SID;
                    phCtrList.Controls.Add(hf); //修改记录时，添加ID这个字段   
                }
               
            }
            //if (!Equals(btnColseGreyBox, null))
            //{
            //    btnColseGreyBox.OnClientClick = "ColseGreyBox();return false;";
            //}
            if (!Equals(bntSave, null))
            {
                bntSave.Click += new EventHandler(bntSave_Click);
                bntSave.Tips_Msg = "正在执行...";
               
            }
           
        }
        //protected EbSite.Control.Button btnColseGreyBox; 
        protected abstract void InitModifyCtr();
        protected virtual void InitModifyCtred(){}
        protected abstract void SaveModel();
        protected virtual void OnBasePageLoading()
        {
            
        }
        protected virtual void ShowSaveTips()
        {
            base.ShowTipsPop("操作完成");
        }
        //override protected void OutPutWord()
        //{
        //    if (!Equals(phCtrList,null))
        //        Core.Utils.OutPutWord(phCtrList);
        //}
        //override protected void OutPutExcel()
        //{
        //    if (!Equals(phCtrList, null))
        //        Core.Utils.OutPutExcel(phCtrList);
        //}
        /// <summary>
        /// 控制保存后是否关闭窗口
        /// </summary>
        virtual protected bool IsSaveCloseWinBox
        {
            get
            {
                return true;
            }
        }
        virtual protected void bntSave_Click(object sender, EventArgs e)
        {
            SaveModel();
            ShowSaveTips();
            if (IsSaveCloseWinBox)
                base.CloseWinBox();
        }
       
    }
}
