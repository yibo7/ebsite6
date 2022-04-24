using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.BLL;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.Core.FSO;
using Sites = EbSite.Entity.Sites;

namespace EbSite.Web.AdminHt.Controls.Admin_Quartz
{
    public partial class Add : UserControlBaseSave
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected override void OnBasePageLoading()
        {
            if(!IsPostBack)
            {
                 
            }

            
        }
         
        public override string Permission
        {
            get
            {
                return "318";
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
            BLL.JobTask.Instance.InitModifyCtr(new Guid(SID), phCtrList);
        }
        
        override protected void SaveModel()
        {
            
            Base.BLL.OtherColumn cRealname;
             

            if (string.IsNullOrEmpty(SID))
            {
                cRealname = new OtherColumn("CreatedTime", DateTime.Now.ToLongTimeString());
                lstOtherColumn.Add(cRealname);
                cRealname = new OtherColumn("IsNoSys", true.ToString());
                lstOtherColumn.Add(cRealname);

                Core.Utils.AppRestart();
            }
            cRealname = new OtherColumn("ModifyTime", DateTime.Now.ToLongTimeString());
            lstOtherColumn.Add(cRealname);

          

              BLL.JobTask.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
           
            
            

        }
         

    }
}