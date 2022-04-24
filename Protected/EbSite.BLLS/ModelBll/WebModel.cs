using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Xml;
using EbSite.Base.EntityAPI;
using EbSite.BLL.ModelBll;
using EbSite.Entity;

namespace EbSite.BLL
{
    public class WebModel : ModelBase<EbSite.Entity.NewsContent>
    {
        public WebModel(int _SiteID)
            : base(_SiteID)
        {

        }
        public override string WebModelName
        {
            get
            {
                return "ModelContent";
            }
        }
        /// <summary>
        /// 添加或修改字段时会触发这个方法,可以在这里向表添加字段
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="cfc"></param>
        override protected void OnSaved(ModelClass mc, ColumFiledConfigs cfc)
        {
            if (cfc.IsOutFiled)
            {
                if (Equals(mc.TableName, null) || string.IsNullOrEmpty(mc.TableName))
                    mc.TableName = "newscontent";
                NewsContent.AddColumnName(mc.TableName, cfc.ColumFiledName, (EDataFiledType)cfc.DataType, cfc.DataTypeLen);

            }
        }
        protected override void OnFiledDeleted(ModelClass mc, ColumFiledConfigs cfc)
        {
            if (cfc.IsOutFiled)
            {
                if (Equals(mc.TableName, null) || string.IsNullOrEmpty(mc.TableName))
                    mc.TableName = "newscontent";
                NewsContent.DelColumnName(mc.TableName, cfc.ColumFiledName);
            }
        }
        public static WebModel InstanceObj(int _SiteID)
        {
            return new WebModel(_SiteID);
        }

        public static WebModel Instance
        {
            get
            {
                return InstanceObj(EbSite.Base.Host.Instance.GetSiteID);
            }

        }
        public override string[] aColums
        {

            get
            {
                string[] aC = {
                                       "NewsTitle|标题|true|ead114fc-9c70-4837-be41-cbc294ec5ecb",
                                       "SmallPic|缩略图|false|f8edab0f-fb25-4d82-ad7d-b84d94ef0434", 
                                       "TitleStyle|标题样式|false|32088a7e-13c4-49da-af02-f18caf92b7ca",
                                       "ContentInfo|内容|false|d5ff6180-0bb8-4665-99e1-83df57760746", 
                                         "Annex1|附加字段1|false|d5ff6180-0bb8-4665-99e1-83df57760746", 
                                         "Annex2|附加字段2|false|d5ff6180-0bb8-4665-99e1-83df57760746", 
                                         "Annex3|附加字段3|false|d5ff6180-0bb8-4665-99e1-83df57760746",
                                       "Annex4|附加字段4|false|d5ff6180-0bb8-4665-99e1-83df57760746", 
                                       "Annex5|附加字段5|false|d5ff6180-0bb8-4665-99e1-83df57760746", 
                                       "Annex6|附加字段6|false|d5ff6180-0bb8-4665-99e1-83df57760746", 
                                       "Annex7|附加字段7|false|d5ff6180-0bb8-4665-99e1-83df57760746", 
                                       "Annex8|附加字段8|false|d5ff6180-0bb8-4665-99e1-83df57760746", 
                                       "Annex9|附加字段9|false|d5ff6180-0bb8-4665-99e1-83df57760746",
                                       "Annex10|附加字段10|false|d5ff6180-0bb8-4665-99e1-83df57760746",

                                        "Annex11|附加字段11|false|32088a7e-13c4-49da-af02-f18caf92b7ca", 
                                        "Annex12|附加字段12|false|32088a7e-13c4-49da-af02-f18caf92b7ca", 
                                       "Annex13|附加字段13|false|32088a7e-13c4-49da-af02-f18caf92b7ca",
                                       "Annex14|附加字段14|false|32088a7e-13c4-49da-af02-f18caf92b7ca", 
                                       "Annex15|附加字段15|false|32088a7e-13c4-49da-af02-f18caf92b7ca", 
                                       "Annex16|附加字段16|false|32088a7e-13c4-49da-af02-f18caf92b7ca", 
                                       "Annex17|附加字段17|false|32088a7e-13c4-49da-af02-f18caf92b7ca", 
                                       "Annex18|附加字段18|false|32088a7e-13c4-49da-af02-f18caf92b7ca", 
                                         "Annex19|附加字段19|false|32088a7e-13c4-49da-af02-f18caf92b7ca", 
                                       "Annex20|附加字段20|false|32088a7e-13c4-49da-af02-f18caf92b7ca",

                                        "Annex21|附加字段21|false|32088a7e-13c4-49da-af02-f18caf92b7ca", 
                                        "Annex22|附加字段22|false|32088a7e-13c4-49da-af02-f18caf92b7ca", 
                                       "Annex23|附加字段23|false|32088a7e-13c4-49da-af02-f18caf92b7ca",
                                       "Annex24|附加字段24|false|32088a7e-13c4-49da-af02-f18caf92b7ca", 
                                       "Annex25|附加字段25|false|32088a7e-13c4-49da-af02-f18caf92b7ca", 
                                   };



                return aC;
            }

        }
        public override void InitSaveCtr(PlaceHolder ph, ref EbSite.Entity.NewsContent ModifyModel)
        {
            InitSaveCtrPT(ph, ref ModifyModel);

        }

        public string GetTableName(Guid mid)
        {
            return GeModelByID(mid).TableName;
        }
        /// <summary>
        /// 从模型展示控件获取一个内容实体数据
        /// </summary>
        /// <param name="ph">容器</param>
        /// <param name="ModifyModel">实体</param>
        private void InitSaveCtrPT(PlaceHolder ph, ref EbSite.Entity.NewsContent ModifyModel)
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

                        if (uc.ID == "NewsTitle")
                        {
                            ModifyModel.NewsTitle = sValue;
                        }
                        else if (uc.ID == "SmallPic")
                        {
                            ModifyModel.SmallPic = sValue;
                        }
                        else if (uc.ID == "TitleStyle")
                        {
                            ModifyModel.TitleStyle = sValue;
                        }
                        else if (uc.ID == "hits")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.hits = int.Parse(sValue);
                        }
                        else if (uc.ID == "ContentInfo")
                        {
                            ModifyModel.ContentInfo = sValue;
                        }
                        else if (uc.ID == "dayHits")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.dayHits = int.Parse(sValue);
                        }
                        else if (uc.ID == "weekHits")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.weekHits = int.Parse(sValue);
                        }
                        else if (uc.ID == "monthhits")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.monthhits = int.Parse(sValue);
                        }
                        ///////////////////////
                        else if (uc.ID == "TagIDs")
                        {
                            ModifyModel.TagIDs = sValue;
                        }
                        else if (uc.ID == "IsGood")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.IsGood = bool.Parse(sValue);
                        }
                        else if (uc.ID == "IsComment")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.IsComment = bool.Parse(sValue);
                        }
                        //else if (uc.ID == "ContentTemID")
                        //{
                        //    if (!string.IsNullOrEmpty(sValue))
                        //        ModifyModel.ContentTemID = new Guid(sValue);
                        //}
                        else if (uc.ID == "Advs")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.Advs = int.Parse(sValue);
                        }
                        /////////////////////////////

                        else if (uc.ID == "OrderID")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.OrderID = int.Parse(sValue);
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
                        else if (uc.ID == "Annex6")
                        {
                            ModifyModel.Annex6 = sValue;
                        }
                        else if (uc.ID == "Annex7")
                        {
                            ModifyModel.Annex7 = sValue;
                        }
                        else if (uc.ID == "Annex8")
                        {
                            ModifyModel.Annex8 = sValue;
                        }
                        else if (uc.ID == "Annex9")
                        {
                            ModifyModel.Annex9 = sValue;
                        }
                        else if (uc.ID == "Annex10")
                        {
                            ModifyModel.Annex10 = sValue;
                        }

                        else if (uc.ID == "Annex11")
                        {
                            ModifyModel.Annex11 = Core.Utils.StrToInt(sValue);
                        }
                        else if (uc.ID == "Annex12")
                        {
                            ModifyModel.Annex12 = Core.Utils.StrToInt(sValue);
                        }
                        else if (uc.ID == "Annex13")
                        {
                            ModifyModel.Annex13 = Core.Utils.StrToInt(sValue);
                        }
                        else if (uc.ID == "Annex14")
                        {
                            ModifyModel.Annex14 = Core.Utils.StrToInt(sValue);
                        }
                        else if (uc.ID == "Annex15")
                        {
                            ModifyModel.Annex15 = Core.Utils.StrToInt(sValue);
                        }

                        else if (uc.ID == "Annex16")
                        {
                            ModifyModel.Annex16 = decimal.Parse(sValue);
                        }
                        else if (uc.ID == "Annex17")
                        {
                            ModifyModel.Annex17 = decimal.Parse(sValue);
                        }
                        else if (uc.ID == "Annex18")
                        {
                            ModifyModel.Annex18 = decimal.Parse(sValue);
                        }
                        else if (uc.ID == "Annex19")
                        {
                            ModifyModel.Annex19 = float.Parse(sValue);
                        }
                        else if (uc.ID == "Annex20")
                        {
                            ModifyModel.Annex20 = float.Parse(sValue);
                        }
                        else if (uc.ID == "Annex21")
                        {
                            ModifyModel.Annex21 = long.Parse(sValue);
                        }
                        else if (uc.ID == "Annex22")
                        {
                            ModifyModel.Annex22 = long.Parse(sValue);
                        }
                        else if (uc.ID == "Annex23")
                        {
                            ModifyModel.Annex23 = long.Parse(sValue);
                        }
                        else if (uc.ID == "Annex24")
                        {
                            ModifyModel.Annex24 = long.Parse(sValue);
                        }
                        else if (uc.ID == "Annex25")
                        {
                            ModifyModel.Annex25 = long.Parse(sValue);
                        }
                        //如果用户不显示一此必要控件，这里给设置一个默认值(未完成)，还差静态页面命名规则
                    }
                    else
                    {
                        ModifyModel.AddCusttomFileds(uc.ID, sValue);
                    }
                }





            }
        }
        public override void InitModifyCtr(PlaceHolder ph, EbSite.Entity.NewsContent ModifyModel)
        {
            InitModifyCtrPT(ph, ModifyModel);
        }

        private void InitModifyCtrPT(PlaceHolder ph, EbSite.Entity.NewsContent ModifyModel)
        {
            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;

                if (!string.IsNullOrEmpty(uc.SkinID)) //SkinID在输出展示控件时记录是否为外部字段
                {
                    string sValue = "";
                    if (!bool.Parse(uc.SkinID))
                    {

                        if (uc.ID == "NewsTitle")
                        {
                            sValue = ModifyModel.NewsTitle;
                        }
                        else if (uc.ID == "SmallPic")
                        {
                            sValue = ModifyModel.SmallPic;
                        }
                        else if (uc.ID == "TitleStyle")
                        {
                            sValue = ModifyModel.TitleStyle;
                        }
                        else if (uc.ID == "hits")
                        {
                            sValue = ModifyModel.hits.ToString();
                        }
                        else if (uc.ID == "ContentInfo")
                        {
                            sValue = ModifyModel.ContentInfo;
                        }
                        else if (uc.ID == "dayHits")
                        {
                            sValue = ModifyModel.dayHits.ToString();
                        }
                        else if (uc.ID == "weekHits")
                        {
                            sValue = ModifyModel.weekHits.ToString();
                        }
                        else if (uc.ID == "monthhits")
                        {
                            sValue = ModifyModel.monthhits.ToString();
                        }
                        ///////////////////////
                        else if (uc.ID == "TagIDs")
                        {
                            //sValue = ModifyModel.TagIDs;
                            sValue = BLL.TagRelateNews.GetTagsByContentID(ModifyModel.ID);
                        }
                        else if (uc.ID == "IsGood")
                        {
                            sValue = ModifyModel.IsGood.ToString();
                        }
                        else if (uc.ID == "IsComment")
                        {
                            sValue = ModifyModel.IsComment.ToString();
                        }
                        //else if (uc.ID == "ContentTemID")
                        //{
                        //    sValue = ModifyModel.ContentTemID.ToString();
                        //}
                        else if (uc.ID == "Advs")
                        {
                            sValue = ModifyModel.Advs.ToString();
                        }
                        /// //////////////////////////

                        else if (uc.ID == "OrderID")
                        {
                            sValue = ModifyModel.OrderID.ToString();
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
                        else if (uc.ID == "Annex6")
                        {
                            sValue = ModifyModel.Annex6;
                        }
                        else if (uc.ID == "Annex7")
                        {
                            sValue = ModifyModel.Annex7;
                        }
                        else if (uc.ID == "Annex8")
                        {
                            sValue = ModifyModel.Annex8;
                        }
                        else if (uc.ID == "Annex9")
                        {
                            sValue = ModifyModel.Annex9;
                        }
                        else if (uc.ID == "Annex10")
                        {
                            sValue = ModifyModel.Annex10;
                        }


                        else if (uc.ID == "Annex11")
                        {
                            sValue = ModifyModel.Annex11.ToString();
                        }
                        else if (uc.ID == "Annex12")
                        {
                            sValue = ModifyModel.Annex12.ToString();
                        }
                        else if (uc.ID == "Annex13")
                        {
                            sValue = ModifyModel.Annex13.ToString();
                        }
                        else if (uc.ID == "Annex14")
                        {
                            sValue = ModifyModel.Annex14.ToString();
                        }
                        else if (uc.ID == "Annex15")
                        {
                            sValue = ModifyModel.Annex15.ToString();
                        }
                        else if (uc.ID == "Annex16")
                        {
                            sValue = ModifyModel.Annex16.ToString();
                        }
                        else if (uc.ID == "Annex17")
                        {
                            sValue = ModifyModel.Annex17.ToString();
                        }
                        else if (uc.ID == "Annex18")
                        {
                            sValue = ModifyModel.Annex18.ToString();
                        }

                        else if (uc.ID == "Annex19")
                        {
                            sValue = ModifyModel.Annex19.ToString();
                        }
                        else if (uc.ID == "Annex20")
                        {
                            sValue = ModifyModel.Annex20.ToString();
                        }
                        else if (uc.ID == "Annex21")
                        {
                            sValue = ModifyModel.Annex21.ToString();
                        }
                        else if (uc.ID == "Annex22")
                        {
                            sValue = ModifyModel.Annex22.ToString();
                        }
                        else if (uc.ID == "Annex23")
                        {
                            sValue = ModifyModel.Annex23.ToString();
                        }
                        else if (uc.ID == "Annex24")
                        {
                            sValue = ModifyModel.Annex24.ToString();
                        }
                        else if (uc.ID == "Annex25")
                        {
                            sValue = ModifyModel.Annex25.ToString();
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
        /// <summary>
        /// 继承与当前分类下的一些与内容相关的配置,适用于添加添加内容，如果是修改内容不必要，直接用当前记录初始化
        /// </summary>
        /// <param name="ph"></param>
        /// <param name="Entity"></param>
        public void InheritClassConfigs(PlaceHolder ph, EbSite.Entity.NewsClass Entity)
        {
            InheritClassConfigsPT(ph, Entity);
        }
        /// <summary>
        /// 继承与当前分类下的一些与内容相关的配置,适用于添加添加内容，如果是修改内容不必要，直接用当前记录初始化
        /// </summary>
        /// <param name="ph"></param>
        /// <param name="Entity"></param>
        private void InheritClassConfigsPT(PlaceHolder ph, EbSite.Entity.NewsClass Entity)
        {
            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                string sValue = "";
                if (uc.ID == "ContentTemID")
                {
                    //sValue = Entity.ContentTemID.ToString();


                    sValue = BLL.ClassConfigs.Instance.GetContentTemID(Entity.ID).ToString();

                    SetValueFromControl(uc, sValue);

                    break;
                }

            }
        }


    }
}
