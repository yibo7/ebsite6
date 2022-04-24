using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_PeiSong
{
    public partial class TemAdd : UserControlBaseSave
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
            Entity.PsFreight md = BLL.PsFreight.Instance.GetEntity(int.Parse(SID));
            this.TemplateName.Text = md.TemplateName;
            this.StartWeight.Text = md.StartWeight.ToString();
            this.AddWeight.Text = md.AddWeight.ToString();
            this.StartPrice.Text = md.StartPrice.ToString();
            this.AddPrice.Text = md.AddPrice.ToString();
            this.HiddenField1.Value = SID;
         

        }
           public void Page_Load(Object sender, EventArgs e)
           {

               if (!IsPostBack)
               {
                   if (!Equals(SID, null))
                   {
                       //List<EbSite.Entity.PsAreaPrice> modelList = EbSite.BLL.PsAreaPrice.Instance.FillList();
                       //List<EbSite.Entity.PsAreaPrice> ns =
                       //    (from i in modelList where i.ParentID == int.Parse(SID) select i).ToList();
                       this.DataList.DataSource = BLL.PsAreaPrice.Instance.GetListByTempID(int.Parse(SID));
                       this.DataList.DataBind();
                   }
               }
           }

        override protected void SaveModel()
        {
            
        }
    }
}