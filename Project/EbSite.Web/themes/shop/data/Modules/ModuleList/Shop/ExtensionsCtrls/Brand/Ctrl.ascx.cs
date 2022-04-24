using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.Modules.Shop.ExtensionsCtrls.Brand
{
    public partial class Ctrl : ModelCtrlBase
    {
        public override void LoadData()
        {
            //if (!IsPostBack)
            //{
            if (ClassID > 0)
            {
                EbSite.Entity.NewsClass md = EbSite.BLL.NewsClass.GetModel(ClassID);
                //  drpGoodsType.SelectedValue = md.Annex8;//默认 选中类型
                try
                {
                    ModuleCore.Entity.TypeNames model = ModuleCore.BLL.TypeNames.Instance.GetEntity(Convert.ToInt32(md.Annex8));
                    if (!string.IsNullOrEmpty(model.BrandIDs))
                    {
                        List<ModuleCore.Entity.GoodsBrand> ls = ModuleCore.BLL.GoodsBrand.Instance.GetListArrayCache(0, "id in(" + model.BrandIDs + ")", "");

                        //int?[] op = new int?[0]; // model.BrandIDs;
                        //string[] arry = model.BrandIDs.Split(',');
                        //int[] arri = Array.ConvertAll<string, int>(arry, delegate(string s) { return int.Parse(s); });
                        //op = new int?[arri.Length];
                        //for (int i = 0; i < arri.Length; i++)
                        //{
                        //    op[i] = arri[i];
                        //}
                        //List<ModuleCore.Entity.GoodsBrand> nls =
                        //    (from i in ls where (op).Contains(i.id) select i).ToList();
                        drpBrandList.DataSource = ls;

                        drpBrandList.DataTextField = "brandname";
                        drpBrandList.DataValueField = "id";
                        drpBrandList.DataBind();
                    }
                    else
                    {
                        drpBrandList.Items.Add(new ListItem("无", "0"));
                    }
                }
                catch
                {
                    throw new Exception("请在分类中设置商品类型 分类管理==>分类管理表格模式==>找到分类 编辑 设置品类型");
                }
            }



            // }
        }
        public override string Name
        {
            get { return "Brand"; }
        }
        public override void SetValue(string sValue)
        {
            drpBrandList.SelectedValue = sValue;
            // selClass.Value = sValue;
        }
        public override string GetValue()
        {
            return drpBrandList.SelectedValue;
            // return selClass.Value;
        }
        private int ClassID
        {
            get
            {
                int iClassID = Core.Utils.StrToInt(Request.QueryString["cid"], 0);
                if (iClassID < 1)
                {
                    if (ContentID > 0)
                    {
                        EbSite.Entity.NewsContent md = Base.AppStartInit.NewsContentInstDefault.GetModel(ContentID,GetSiteID);
                        return md.ClassID;
                    }
                }

                return iClassID;
            }
        }
        private int ContentID
        {
            get
            {
                return Core.Utils.StrToInt(Request.QueryString["id"], 0);
            }
        }
    }
}