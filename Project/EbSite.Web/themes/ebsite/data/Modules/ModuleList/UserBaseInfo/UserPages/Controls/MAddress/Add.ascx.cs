using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Entity;
using System.Collections;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.MAddress
{
    public partial class Add : MPUCBaseSaveForUserMobile
    {
       
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("08e54c45-f5ea-4c19-9a1a-e7e4afde3910");
            }
        }
        public override string PageName
        {
            get
            {
                return "添加地址";
            }
        }

        public override int OrderID
        {
            get
            {
                return 2;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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
            EbSite.Entity.Address md = EbSite.BLL.Address.Instance.GetEntity(Core.Utils.StrToInt(SID));
            this.UserRealName.Text = md.UserRealName;
            this.AddressInfo.Text = md.AddressInfo;
            this.PostCode.Text = md.PostCode;
            this.Mobile.Text = md.Mobile;
            this.Phone.Text = md.Phone;
        }

        override protected void SaveModel()
        {
            EbSite.Entity.Address md = new Entity.Address();
            md.UserID = base.UserID;
            md.UserRealName = this.UserRealName.Text;
            md.AddressInfo = this.AddressInfo.Text;
            //省市地区处理
            //string id = this.ddl_address.Value;
            //md.CityID = Core.Utils.StrToInt(id);
            md.PostCode = this.PostCode.Text;
            md.Mobile = this.Mobile.Text;
            md.Phone = this.Phone.Text;
            //如果数据ID不为空，说明是修改数据，否则为新添加数据
            if (!string.IsNullOrEmpty(SID))
            {
                md.id = Core.Utils.StrToInt(SID);
                EbSite.BLL.Address.Instance.Update(md);
            }
            else
            {
                EbSite.BLL.Address.Instance.Add(md);
            }
        }
    }
}