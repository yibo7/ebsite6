using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Entity;


namespace EbSite.Web.AdminHt.Controls.Admin_PeiSong
{
    public partial class StoreHouseAdd : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "159";
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
            //Entity.StoreHouse md = BLL.StoreHouse.Instance.GetEntity(int.Parse(SID));
            //this.CompanyName.Text = md.CompanyName;
            //this.CompanyCode.Text = md.CompanyCode;
        
        }
        override protected void SaveModel()
        {
            BLL.StoreHouse.Instance.SaveEntityFromCtr(phCtrList, null);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
       
    }
}