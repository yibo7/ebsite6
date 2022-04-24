using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Control;

namespace EbSite.Base.Modules
{
    using EbSite.Base.Page;
    using System;

    public abstract class MPUCBaseListForUser : MPUCBaseList
    {
        /// <summary>
        /// 获取当前模块所在的相对路径
        /// </summary>
        protected string GetCurrentModulePath
        {
            get
            {
                return EbSite.BLL.ModulesBll.Modules.Instance.GetModelPath(ModuleID);
            }
        }
        /// <summary>
        /// 检测当前用户是否具有某个权限ID
        /// </summary>
        /// <param name="LimitID">权限Id</param>
        /// <returns></returns>
       override protected bool IsHaveLimit(string LimitID)
        {
            if (!string.IsNullOrEmpty(LimitID))
            return HostApi.IsHaveLimitForUser(EbSite.Base.AppStartInit.UserID, int.Parse(LimitID), ModuleID);
            return true;
        }

       protected override void gdList_RowCreated(object sender, GridViewRowEventArgs e)
       {
           if (e.Row.RowType == DataControlRowType.DataRow)
           {
               //检测是否有权限显示删除数据的按钮
               GridViewRow row = e.Row;
               EbSite.Control.LinkButton lbDelete = (EbSite.Control.LinkButton)row.FindControl("lbDelete");
               if (!Equals(lbDelete, null))
               {
                   lbDelete.confirm = true;
               }
               //检测是否有权限显示修改数据的按钮
               EasyuiDialog wbModify = (EasyuiDialog)row.FindControl("wbModify");
               if (!object.Equals(wbModify, null))
               {
                   string sID = gdList.DataKeys[e.Row.RowIndex].Value.ToString();
                   wbModify.Href = string.Concat(AddUrl, "&box=1&id=", sID);
                   
               }

               //检测是否有权限显示数据的按钮
               EasyuiDialog wbShow = (EasyuiDialog)row.FindControl("wbShow");
               if (!object.Equals(wbShow, null))
               {
                   string sID = gdList.DataKeys[e.Row.RowIndex].Value.ToString();
                   wbShow.Href = string.Concat(ShowUrl, "&box=1&id=", sID);
               }



           }
       }
    }
}

