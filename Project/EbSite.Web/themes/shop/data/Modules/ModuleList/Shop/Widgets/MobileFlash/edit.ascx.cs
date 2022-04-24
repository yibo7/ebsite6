using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.Widgets.MobileFlash
{
    public partial class edit : WidgetEditBase
    {
        public int GetModifyID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["did"]))
                {
                    return Convert.ToInt32(Request["did"]) ;
                }
                return 0;
            }
        }

        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                BinData();
                StringDictionary settings = GetSettings();
                if (GetModifyID > 0)
                {

                    ModuleCore.Entity.MFlash md = ModuleCore.BLL.MFlashInfo.Instance.GetEntity(GetModifyID);
                    txtPath.CtrValue = md.PicUrl;
                    txtUrl.Text = md.Url;
                    txtTitle.Text = md.Name;
                    bntAddOne.Text = "修改记录";
                }

            }
        }

        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();



            SaveSettings(settings);
        }

        public void BinData()
        {
            rpList.DataSource = ModuleCore.BLL.MFlashInfo.Instance.FillList();
            rpList.DataBind();
        }

        protected void bntAddOne_Click(object sender, EventArgs e)
        {
            ModuleCore.Entity.MFlash md = new MFlash();
            md.PicUrl = txtPath.CtrValue.Trim();
            md.Name = txtTitle.Text.Trim();
            md.Url = txtUrl.Text.Trim();

            if (!string.IsNullOrEmpty(md.PicUrl) && !string.IsNullOrEmpty(md.Name) && !string.IsNullOrEmpty(md.Url))
            {
                if (GetModifyID > 0)
                {
                    md.id = GetModifyID;
                    ModuleCore.BLL.MFlashInfo.Instance.Update(md);
                }
                else
                {
                    ModuleCore.BLL.MFlashInfo.Instance.Add(md);
                }
                Response.Redirect(sUrlToAdd);
            }
            else
            {
                Response.Write("<script>alert('请添写完整')</script>");
            }
            
        }

        protected void gdList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                if (e.CommandName == "DeleteModel") 
                {
                    string id = e.CommandArgument.ToString();
                
                  
                  
                    ModuleCore.BLL.MFlashInfo.Instance.Delete(Convert.ToInt32(id) );

                    Response.Redirect(sUrlToAdd);
                }
                else if (Equals(e.CommandName, "EditModel"))
                {
                    string sID = e.CommandArgument.ToString();
                    string sUrl = string.Concat(sUrlToAdd, "&did=", sID);

                    Response.Redirect(sUrl);
                    

                }
            }
        }
    }
}