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
    public partial class SendAreaAdd : UserControlBaseSave
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
            Entity.SendArea md = BLL.SendArea.Instance.GetEntity(int.Parse(SID));
            AreaName.Text = md.AreaName;
            CityIDs.CtrValue = md.CityIDs;
            CityIDs.Text = md.CityNames;
        }
        override protected void SaveModel()
        {
            Entity.SendArea md = new Entity.SendArea();
            md.AreaName = AreaName.Text;
            md.CityIDs = CityIDs.CtrValue;
            md.CityNames = CityIDs.Text;
            if(string.IsNullOrEmpty(SID))
            {
                EbSite.BLL.SendArea.Instance.Add(md);
            }
            else
            {
                md.id = int.Parse(SID);
                EbSite.BLL.SendArea.Instance.Update(md);
            }
            //Response.Redirect(Request.UrlReferrer.AbsoluteUri);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
       
    }
}