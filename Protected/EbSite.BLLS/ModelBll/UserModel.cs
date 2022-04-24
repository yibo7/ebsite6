using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Static;
using EbSite.BLL.ModelBll;
using EbSite.Entity;

namespace EbSite.BLL
{
    public class UserModel : ModelBase<BLL.User.UserProfile> 
    {
        public UserModel(int _SiteID)
            : base(_SiteID)
        {
            
        }
        public override string WebModelName
        {
            get
            {
                return "ModelUser";
            }
        }
        public static  UserModel Instance
        {
            get
            {
                return new UserModel(EbSite.Base.Host.Instance.GetSiteID);
            }

        }
        public static UserModel InstanceObj(int _SiteID)
        {
            return new UserModel(_SiteID);
        }
        public override string[] aColums
        {

            get
            {
               string [] aC = {
                                        "QQ|QQ|false", 
                                        "MSN|MSN|false",  
                                        "ICO|ICO|false", 
                                        "Sex|性别|false",
                                       "BirthDay|生日|false", 
                                       "Photo|相片|false",  
                                       "Bloodtype|血型|false", 
                                        "Country|所在国家|false", 
                                        "Province|所在省分|false", 
                                        "City|所在城市|false",
                                       "Phone|电话|false", 
                                       "Postcode|邮编|false", 
                                       "Address|地址|false", 
                                       "Job|工作|false", 
                                       "Edu|教育程度|false", 
                                       "School|毕业学校|false", 
                                       "Introduction|备注|false",
                                       "Annex1|附加字段1|false", 
                                         "Annex2|附加字段2|false", 
                                         "Annex3|附加字段3|false",
                                       "Annex4|附加字段4|false", 
                                       "Annex5|附加字段5|false"
                               };

                return aC;
            }

        }
        public override void InitSaveCtr(PlaceHolder ph, ref BLL.User.UserProfile ModifyModel)
        {
            InitSaveCtrPT(ph, ref ModifyModel);
        }

        private  void InitSaveCtrPT(PlaceHolder ph, ref BLL.User.UserProfile ModifyModel)
        {
            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                string sValue = "";
                if (!string.IsNullOrEmpty(uc.SkinID))
                {
                    sValue = GetValueFromControl(uc);
                    if (!bool.Parse(uc.SkinID))
                    {

                        if (uc.ID == "Address")
                        {
                            ModifyModel.Address = sValue;
                        }
                        else if (uc.ID == "BirthDay")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.BirthDay = DateTime.Parse(sValue);
                        }
                        else if (uc.ID == "Bloodtype")
                        {
                            ModifyModel.Bloodtype = sValue;
                        }
                        else if (uc.ID == "City")
                        {
                            ModifyModel.City = sValue;
                        }
                        else if (uc.ID == "Country")
                        {
                            ModifyModel.Country = sValue;
                        }
                        //else if (uc.ID == "Credits")
                        //{
                        //    if (!string.IsNullOrEmpty(sValue))
                        //    ModifyModel.Credits = int.Parse(sValue);
                        //}
                        else if (uc.ID == "Edu")
                        {
                            ModifyModel.Edu = sValue;
                        }
                        else if (uc.ID == "ICO")
                        {
                            ModifyModel.ICO = sValue;
                        }
                        else if (uc.ID == "Introduction")
                        {
                            ModifyModel.Introduction = sValue;
                        }
                        else if (uc.ID == "Job")
                        {
                            ModifyModel.Job = sValue;
                        }
                        else if (uc.ID == "MSN")
                        {
                            ModifyModel.MSN = sValue;
                        }
                        else if (uc.ID == "Phone")
                        {
                            ModifyModel.Phone = sValue;
                        }
                        else if (uc.ID == "Photo")
                        {
                            ModifyModel.Photo = sValue;
                        }
                        else if (uc.ID == "Postcode")
                        {
                            ModifyModel.Postcode = sValue;
                        }
                        else if (uc.ID == "Province")
                        {
                            ModifyModel.Province = sValue;
                        }
                        else if (uc.ID == "QQ")
                        {
                            ModifyModel.QQ = sValue;
                        }
                        else if (uc.ID == "School")
                        {
                            ModifyModel.School = sValue;
                        }
                        else if (uc.ID == "Sex")
                        {
                            ModifyModel.Sex = sValue;
                        }
                        else if (uc.ID == "Annex1")
                        {
                            ModifyModel.Annex1 = sValue;
                        }
                        else if (uc.ID == "Annex2")
                        {
                            ModifyModel.Annex2 = sValue;
                        }
                        else if (uc.ID == "Annex3")
                        {
                            ModifyModel.Annex3 = sValue;
                        }
                        else if (uc.ID == "Annex4")
                        {
                            ModifyModel.Annex4 = sValue;
                        }
                        else if (uc.ID == "Annex5")
                        {
                            ModifyModel.Annex5 = sValue;
                        }
                    }
                    else
                    {
                        ModifyModel.AddCusttomFileds(uc.ID, sValue);
                    }
                }

               

            }
        }
        public override void InitModifyCtr(PlaceHolder ph, BLL.User.UserProfile ModifyModel)
        {
            InitModifyCtrPT(ph, ModifyModel);
        }

        private  void InitModifyCtrPT(PlaceHolder ph, BLL.User.UserProfile ModifyModel)
        {
            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                if (!string.IsNullOrEmpty(uc.SkinID))
                {
                    string sValue = "";
                    if (!bool.Parse(uc.SkinID))
                    {

                        if (uc.ID == "Address")
                        {
                            sValue = ModifyModel.Address;
                        }
                        else if (uc.ID == "BirthDay")
                        {
                            sValue = ModifyModel.BirthDay.ToString();
                        }
                        else if (uc.ID == "Bloodtype")
                        {
                            sValue = ModifyModel.Bloodtype;
                        }
                        else if (uc.ID == "City")
                        {
                            sValue = ModifyModel.City;
                        }
                        else if (uc.ID == "Country")
                        {
                            sValue = ModifyModel.Country;
                        }
                        //else if (uc.ID == "Credits")
                        //{
                        //        sValue = ModifyModel.Credits.ToString();
                        //}
                        else if (uc.ID == "Edu")
                        {
                            sValue = ModifyModel.Edu;
                        }
                        else if (uc.ID == "ICO")
                        {
                            sValue = ModifyModel.ICO;
                        }
                        else if (uc.ID == "Introduction")
                        {
                            sValue = ModifyModel.Introduction;
                        }
                        else if (uc.ID == "Job")
                        {
                            sValue = ModifyModel.Job;
                        }
                        else if (uc.ID == "MSN")
                        {
                            sValue = ModifyModel.MSN;
                        }
                        else if (uc.ID == "Phone")
                        {
                            sValue = ModifyModel.Phone;
                        }
                        else if (uc.ID == "Photo")
                        {
                            sValue = ModifyModel.Photo;
                        }
                        else if (uc.ID == "Postcode")
                        {
                            sValue = ModifyModel.Postcode;
                        }
                        else if (uc.ID == "Province")
                        {
                            sValue = ModifyModel.Province;
                        }
                        else if (uc.ID == "QQ")
                        {
                            sValue = ModifyModel.QQ;
                        }
                        else if (uc.ID == "School")
                        {
                            sValue = ModifyModel.School;
                        }
                        else if (uc.ID == "Sex")
                        {
                            sValue = ModifyModel.Sex.ToString();
                        }
                        else if (uc.ID == "Annex1")
                        {
                            sValue = ModifyModel.Annex1;
                        }
                        else if (uc.ID == "Annex2")
                        {
                            sValue = ModifyModel.Annex2;
                        }
                        else if (uc.ID == "Annex3")
                        {
                            sValue = ModifyModel.Annex3;
                        }
                        else if (uc.ID == "Annex4")
                        {
                            sValue = ModifyModel.Annex4;
                        }
                        else if (uc.ID == "Annex5")
                        {
                            sValue = ModifyModel.Annex5;
                        }
                    }
                    else
                    {
                        if (ModifyModel.Fileds.ContainsKey(uc.ID))
                            sValue = ModifyModel.Fileds[uc.ID];
                    }
                    SetValueFromControl(uc, sValue);
                }

            }
        }
        //private static object _SyncRoot = new object();
        //public static List<EbSite.Entity.ModelClass> _ModelClassList;
        //public override List<EbSite.Entity.ModelClass> ModelClassList
        //{

        //    get
        //    {
        //        if (_ModelClassList == null)
        //        {
        //            lock (_SyncRoot)
        //            {
        //                if (_ModelClassList == null)
        //                {
        //                    _ModelClassList = Base.Configs.Model.UserModel.ConfigsControl.ConfigsEntity();
        //                    //按_orderid降序来排序
        //                    //_ModelClassList.Sort();
        //                }
        //            }
        //        }

        //        return _ModelClassList;
        //    }
        //}
         
       
        //public override void Save()
        //{
        //    Base.Configs.Model.UserModel.ConfigsControl.SaveConfig(ModelClassList);
        //}

        ///////////////////////////
        public void ShowInfoByModelID(PlaceHolder ph, Page pg, ModelClass ModelConfigs, bool isAdmin)
        {
            ShowInfoByModelIDPT(ph, pg, ModelConfigs, isAdmin);
        }
        private void ShowInfoByModelIDPT(PlaceHolder ph, Page pg, ModelClass ModelConfigs, bool isAdmin)
        {
            //获取当前分类
            //Model.NewsClass ClassModel = BLL.NewsClass.GetModelByCache(cid);
            //获取当前模型的字段配置
            List<ColumFiledConfigs> lst = ModelConfigs.Configs;//GeModelByID(ClassModel.ModelID).Configs;
            foreach (ColumFiledConfigs field in lst)
            {
                if (!isAdmin)
                {
                    if (!field.IsShowUser) continue;//是否用户可见
                }
                else
                {
                    if (!field.IsShowAdmin) continue;//是否管理员可见
                }
                
                string sHtml1 = string.Concat("<tr><td>", field.ColumShowName, ":</td><td >");
                string sHtml2 = "</td></tr>";
                ph.Controls.Add(pg.ParseControl(sHtml1));
                Literal lb = new Literal();
                lb.ID = field.ColumFiledName;
                lb.SkinID = field.IsOutFiled.ToString();
                ph.Controls.Add(lb);
                ph.Controls.Add(pg.ParseControl(sHtml2));
            }
        }
        private static object _SyncRoot = new object();
        override  public List<Entity.ModelClass> ModelClassList
        {
            get
            {
                int siteid = Base.Host.Instance.GetSiteID;
                string sKey = string.Concat("WebModelList-", WebModelName, siteid);

                List<Entity.ModelClass> mdList = EbSite.Base.Host.CacheRawApp.GetCacheItem<List<Entity.ModelClass>>(sKey,"mcl");// as List<Entity.ModelClass>;

                if (mdList == null)
                {
                    lock (_SyncRoot)
                    {
                        if (mdList == null)
                        {
                            mdList = EbSite.Base.Configs.Model.ConfigsControl.GetModelList(WebModelName, siteid);
                            //按_orderid降序来排序
                            //mdList.Sort();
                            if (mdList != null)
                            {
                                //cfd5666c-0bd5-4beb-884b-75d23e7ca158
                                //yhl 2012-09-19 因为用户模型是不分站点的。是共享的。
                                mdList = (from o in mdList  select o).ToList();
                                mdList.OrderByDescending(d => d.AddDate);

                                EbSite.Base.Host.CacheRawApp.AddCacheItem(sKey, mdList, 3, ETimeSpanModel.XS, "mcl");
                            }
                        }
                    }
                }

                return mdList;
            }
        }


    }
   
}
