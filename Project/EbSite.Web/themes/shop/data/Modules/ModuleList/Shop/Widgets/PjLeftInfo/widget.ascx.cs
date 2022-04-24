using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Core;
using EbSite.Modules.Shop.ModuleCore.Entity;
using ListItemModel = EbSite.Base.EntityAPI.ListItemModel;

namespace EbSite.Modules.Shop.Widgets.PjLeftInfo
{
    public partial class widget : WidgetBase
    {
        /// <summary>
        /// 自动适应分类ID
        /// </summary>
        public int GetProductId
        {
            get
            {
                if (Request.Params["mk"] != null)
                {
                    int id = Core.Utils.StrToInt(Request.Params["mk"], 0);
                    return id;
                }
                else
                {
                    return 0;
                }
            }
        }

        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                if (GetProductId > 0)
                {
                    List<EbSite.Entity.NewsContent> ls = Base.AppStartInit.NewsContentInstDefault.GetListArray(string.Format("id={0}", GetProductId), 0, "", "", GetSiteID);
                    this.rpList.DataSource = ls;
                    this.rpList.DataBind();
                }
            }
        }
     
        public override string Name
        {
            get { return "PjLeftInfo"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
    }
}