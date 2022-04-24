using System;
using EbSite.Base.ControlPage;
using EbSite.Core.FSO;
namespace EbSite.Web.AdminHt.Controls.Admin_Comment
{
    public partial class EditTem : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "1";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        private int itype
        {
            get
            {
               return Core.Utils.StrToInt(Request["type"], 1);
            }
        }
        override protected void InitModifyCtr()
        {

            //读取模板信息
            string sPath = "";
            if(itype==1)
            {
                sPath = BLL.RemarkClass.GetNewPath(int.Parse(SID));
                
            }
            else
            {
                sPath = BLL.RemarkClass.GetNewPath(int.Parse(SID), itype);
            }
            string sTemHtml = FObject.ReadFile(Server.MapPath(sPath));
            txtTem.Text = sTemHtml;
           
        }

        override protected void SaveModel()
        {
            FObject.WriteFile(Server.MapPath(BLL.RemarkClass.GetNewPath(int.Parse(SID))), txtTem.Text.Trim());
        }

        //private int ID
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(Request["id"]))
        //        {
        //            return int.Parse(Request["id"]);
        //        }

        //        return 0;
        //    }
        //}
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if(!IsPostBack)
        //    {
        //        if (ID>0)
        //        {
                    
                   
        //            //读取模板信息
        //            string sTemHtml = FObject.ReadFile(Server.MapPath(BLL.RemarkClass.GetNewPath(ID)));
        //            txtTem.Text = sTemHtml;

        //        }
        //    }
           
            
        //}
       
        //protected void btnSave_Click(object sender, EventArgs e)
        //{

        //    FObject.WriteFile(Server.MapPath(BLL.RemarkClass.GetNewPath(ID)), txtTem.Text.Trim());

        //}
    }
}