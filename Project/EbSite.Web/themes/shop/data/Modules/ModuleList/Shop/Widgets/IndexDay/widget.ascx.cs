
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Modules.Shop.ModuleCore.Entity;
using ListItemModel = EbSite.Base.EntityAPI.ListItemModel;

namespace EbSite.Modules.Shop.Widgets.IndexDay
{
    public partial class widget : WidgetBase
    {

        public override void LoadData()
        {

            StringDictionary settings = GetSettings();
            string typeId = settings["delvalue"];
            int iTop = 6;//
            if (!string.IsNullOrEmpty(settings["CountTitle"]))
            {
                iTop = Core.Utils.StrToInt(settings["CountTitle"], 6);
            }
            //<asp:ListItem Value="1" Text="推荐"></asp:ListItem>
            //<asp:ListItem Value="2" Text="最新"></asp:ListItem>
            //<asp:ListItem Value="3" Text="排行"></asp:ListItem>
            //<asp:ListItem Value="4" Text="抢购"></asp:ListItem>
            //<asp:ListItem Value="5" Text="团购"></asp:ListItem>

            if (settings.ContainsKey("TemTitle"))
            {
                string sTem = settings["TemTitle"];

                sTem = base.TemBll.GetTemPath(sTem);
                if (!string.IsNullOrEmpty(sTem))
                {

                    this.rpList.ItemTemplate = LoadTemplate(sTem);
                }
            }
            switch (typeId)
            {
                case "1": //推荐
                    List<EbSite.Entity.NewsContent> ls1 = Base.AppStartInit.NewsContentInstDefault.GetListArray(" IsGood = 1  and annex25=1", iTop, "id desc", "",
                                                                                              SettingInfo.Instance.GetSiteID);
                    this.rpList.DataSource = ls1;
                    break;
                case "2": //最新
                    List<EbSite.Entity.NewsContent> ls2 = Base.AppStartInit.NewsContentInstDefault.GetListArray(" annex25=1", iTop, "id desc", "",
                                                                                            SettingInfo.Instance.GetSiteID);
                    this.rpList.DataSource = ls2;
                    break;
                case "3": //点击排行
                    List<EbSite.Entity.NewsContent> ls3 = Base.AppStartInit.NewsContentInstDefault.GetListArray(" annex25=1", iTop, "hits desc", "",
                                                                                            SettingInfo.Instance.GetSiteID);
                    this.rpList.DataSource = ls3;
                    break;
                case "4": //抢购
                    List<ModuleCore.Entity.CountDownBuy> ls4 = ModuleCore.BLL.CountDownBuy.Instance.GetListArray(iTop, "", "");
                    this.rpList.DataSource = ls4;
                    break;
                case "5": //团购
                    List<ModuleCore.Entity.GroupBuy> ls5 = ModuleCore.BLL.GroupBuy.Instance.GetListArray(iTop, "", "");
                    this.rpList.DataSource = ls5;
                    break;

            }

            this.rpList.DataBind();

        }




        public override string Name
        {
            get { return "IndexDay"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }


    }


}