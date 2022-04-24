using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Entity;
using System.Collections;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.Address
{
    public partial class Add : MPUCBaseSaveForUser
    {

        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("2517cc88-cbb5-4b00-ac5c-32285c9b9889");
            }
        }
        public override string PageName
        {
            get
            {
                return "添加地址";
            }
        }

        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return false;
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
            if (UserID < 1)
            {
                Tips("请先登录", "本页面需要登录内能访问!");
            }
       
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(SID))
                {
                    EbSite.Entity.Address uModel =EbSite.BLL.Address.Instance.GetEntity(int.Parse(Request.Params["id"].ToString()));
                    this.txtUserName.Text = uModel.UserRealName;

                    //this.hfValue.Value = uModel.AreaID.ToString();
                    //this.hfValueP.Value = uModel.CountryName;
                    //string strPri = "";
                    //string strCity = "";
                    //string strCounty = "";

                    //反向绑定地区值
                    //if (uModel.CityID>0)
                    //{
                    //    this.ddl_address.Value = uModel.CityID.ToString();

                    //    Hashtable ht = EbSite.BLL.AreaInfo.Instance.GetAddressListByID(Core.Utils.StrToInt(uModel.CityID.ToString()));
                    //    if (ht != null)
                    //    {
                    //        System.Collections.Generic.Dictionary<int, string> dic;
                    //        foreach (DictionaryEntry de in ht)
                    //        {
                    //            dic = new System.Collections.Generic.Dictionary<int, string>();
                    //            if (de.Key.Equals(4))
                    //            {
                    //                dic = (System.Collections.Generic.Dictionary<int, string>)de.Value;
                    //                foreach (int key in dic.Keys)
                    //                {
                    //                    this.hidCounty.Value= dic[key].ToString();
                    //                    break;
                    //                }
                    //            }
                    //            if (de.Key.Equals(3))
                    //            {
                    //                dic = (System.Collections.Generic.Dictionary<int, string>)de.Value;
                    //                foreach (int key in dic.Keys)
                    //                {
                    //                    this.hidCity.Value = dic[key].ToString();
                    //                    break;
                    //                }
                    //            }
                    //            if (de.Key.Equals(2))
                    //            {
                    //                dic = (System.Collections.Generic.Dictionary<int, string>)de.Value;
                    //                foreach (int key in dic.Keys)
                    //                {
                    //                    this.hidProvince.Value = dic[key].ToString();
                    //                    break;
                    //                }
                    //            }
                    //        }
                    //    }

                    //}
                    this.ddl_address.Value = uModel.AreaID.ToString();
                    this.txtAddress.Text =uModel.AddressInfo;
                    this.txtPhone.Text = uModel.Mobile;
                    this.txtTelnum.Text = uModel.Phone;
                    this.txtZipCode.Text = uModel.PostCode;
                }
                else
                {
                    this.txtUserName.Text = base.UserName;
                }

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
            EbSite.Entity.Address uModel = EbSite.BLL.Address.Instance.GetEntity(int.Parse(SID));
            this.txtUserName.Text = uModel.UserRealName;

            //this.hfValue.Value = uModel.AreaID.ToString();
            //this.hfValueP.Value = uModel.CountryName;

            this.txtAddress.Text = uModel.AddressInfo;
            this.txtPhone.Text = uModel.Mobile;
            this.txtTelnum.Text = uModel.Phone;
            this.txtZipCode.Text = uModel.PostCode;
        }

        override protected void SaveModel()
        {
            int id = 0;
            if (!string.IsNullOrEmpty(SID))
            {
                id = Core.Utils.StrToInt(SID, 0);
            }
            EbSite.BLL.Address.Instance.Add(this.txtUserName.Text, this.txtTelnum.Text, this.txtPhone.Text,
                                            this.txtZipCode.Text, Core.Utils.StrToInt(this.ddl_address.Value, 0), "",
                                            this.txtAddress.Text, this.txtMail.Text, id);
            
            //EbSite.Entity.Address md = new Entity.Address();
            //md.UserID = base.UserID;
            //md.UserRealName = this.txtUserName.Text;
            //md.AddressInfo = this.txtAddress.Text;
            ////省市地区处理
            //string id = this.ddl_address.Value;
            //md.CityID=Core.Utils.StrToInt(id);
            //md.PostCode = this.txtZipCode.Text;
            //md.Mobile = this.txtTelnum.Text;
            //md.Phone = this.txtPhone.Text;
            //md.AddDateime = DateTime.Now;
            //if (Request.Params["tid"] != null)
            //{
            //    md.id = Core.Utils.StrToInt(Request.Params["tid"].ToString());
            //    EbSite.BLL.Address.Instance.Update(md);
            //    base.ShowTipsPop("修改成功");
            //}
            //else
            //{

            //    EbSite.BLL.Address.Instance.Add(md);
            //    base.ShowTipsPop("添加成功");
            //}
           // base.RunJs("BackPage();");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveModel();
        }
    }
}