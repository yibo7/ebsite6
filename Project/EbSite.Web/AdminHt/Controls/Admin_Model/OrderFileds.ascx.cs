using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Json;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Model
{
    public partial class OrderFileds : UserControlBase
    {
        /// <summary>
        /// 模型类别 0 内容 1分类 2用户
        /// </summary>
        protected int ModuleType
        {
            get
            {
               return Core.Utils.StrToInt(Request["mt"], -1);
            }
        }
        protected Guid ModelID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return new Guid(Request["id"]);
                    
                }
                return Guid.Empty;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ModelClass mc = null;
                if(ModuleType==0)
                {
                    mc = BLL.WebModel.Instance.GeModelByID(ModelID);
                }
                else if (ModuleType == 1)
                {
                    mc = BLL.ClassModel.Instance.GeModelByID(ModelID);
                }
                else if (ModuleType == 2)
                {
                    mc = BLL.UserModel.Instance.GeModelByID(ModelID);
                }
                else if (ModuleType == 3)
                {
                    mc = BLL.FormModel.Instance.GeModelByID(ModelID);
                }
                else if(ModuleType==4) //快捷菜单
                {
                    
                }
                    
                if (mc!=null)
                {
                    rpList.DataSource = mc.GetUsedFileds();
                    rpList.DataBind();
                }
                
            }
        }
        

    }
}