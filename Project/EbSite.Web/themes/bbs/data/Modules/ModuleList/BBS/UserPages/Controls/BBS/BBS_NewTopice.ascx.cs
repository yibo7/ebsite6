using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.BBS.UserPages.Controls.BBS
{
    public partial class BBS_NewTopice : MPUCBaseListForUser
    {
       

        public override string Permission
        {
            get
            {
                return "7";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "";// return "NetDisk.aspx?t=2&mid="+ModuleID;
            }
        }
      
       
       
        override protected object LoadList(out int iCount)
        {
           
            iCount = 0;
            return null;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                BindTopice();
            }
            
        }

     

        #region 新代码
    
        /// <summary>
        /// 绑定全站 本版置顶块 本版块帖子 
        /// </summary>
        public void BindTopice()
        {

            repNewRopice.DataSource = ModuleCore.BLL.Topics.Instance.GetListArray(20, "DeleteFlag=0","id desc");
            repNewRopice.DataBind();

        }
       


        #endregion
    }
}