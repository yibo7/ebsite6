
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Base.ControlPage
{
    abstract public class UserControlBaseShow<ObType> : UserControlBase
    {
       
        #region 属性
        protected string GetKeyID
        {
            get
            {
                return Request["id"];
            }
        }
        protected ObType Model
        {
            get
            {
                return LoadModel();
            }
        }
        //作为导出数据用
        protected PlaceHolder phCtrList;
        #endregion

        public UserControlBaseShow()
        {
            this.Load += new EventHandler(BasePage_Load);
        }
        private void BasePage_Load(object sender, EventArgs e)
        {
            if (!Page.IsCallback)
            {
                Page.Title = "查看明细";
                    
            }
            if (!Equals(btnDelete, null))
            {
                btnDelete.Click += new EventHandler(btnDelete_Click);
                btnDelete.Confirm = true;
                
            }
            if (!Equals(btnColseGreyBox, null))
            {
                btnColseGreyBox.OnClientClick = "ColseGreyBox();return false";
            }
             
            
        }
        protected EbSite.Control.Button btnDelete;
        protected EbSite.Control.Button btnColseGreyBox;
        protected virtual void Delete()
        {
            
        }
        protected abstract ObType LoadModel();
        virtual protected void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
            //base.ColseGreyBox(true);
        }
        //override protected void OutPutWord()
        //{
        //    if (!Equals(phCtrList, null))
        //        Core.Utils.OutPutWord(phCtrList);
        //}
        //override protected void OutPutExcel()
        //{
        //    if (!Equals(phCtrList, null))
        //        Core.Utils.OutPutExcel(phCtrList);
        //}
    }
}
