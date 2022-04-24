using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.BLL.ModelBll;

namespace EbSite.BLL
{
    public class ClassModel : ModelBase<EbSite.Entity.NewsClass>
    {
        public ClassModel(int _SiteID)
            : base(_SiteID)
        {
            
        }
        public static ClassModel InstanceObj(int _SiteID)
        {
            return new ClassModel(_SiteID);
        }

        public override string WebModelName
        {
            get
            {
                return "ModelClass";
            }
        }

        public static  ClassModel Instance
        {
            get
            {
                return new ClassModel(EbSite.Base.Host.Instance.GetSiteID);
            }

        }
        public override string[] aColums
        {

            get
            {
                string[] aC = {  
                                        "ClassName|分类名称|true|ead114fc-9c70-4837-be41-cbc294ec5ecb",
                                       "Info|分类简介|false|d5ff6180-0bb8-4665-99e1-83df57760746", 
                                        "TitleStyle|标题样式|false|32088a7e-13c4-49da-af02-f18caf92b7ca",
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

                                        "Annex11|附加字段11|false|d5ff6180-0bb8-4665-99e1-83df57760746",
                                       "Annex12|附加字段12|false|d5ff6180-0bb8-4665-99e1-83df57760746", 
                                       "Annex13|附加字段13|false|d5ff6180-0bb8-4665-99e1-83df57760746", 
                                       "Annex14|附加字段14|false|d5ff6180-0bb8-4665-99e1-83df57760746",
                                       "Annex15|附加字段15|false|d5ff6180-0bb8-4665-99e1-83df57760746", 
                                        "Annex16|附加字段16|false|d5ff6180-0bb8-4665-99e1-83df57760746",
                                       "Annex17|附加字段17|false|d5ff6180-0bb8-4665-99e1-83df57760746"
                                   };

                return aC;
            }

        }
        public override void InitSaveCtr(PlaceHolder ph, ref EbSite.Entity.NewsClass ModifyModel)
        {
            InitSaveCtrPT( ph, ref  ModifyModel);
        }

        private  void InitSaveCtrPT(PlaceHolder ph, ref EbSite.Entity.NewsClass ModifyModel)
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

                        if (uc.ID == "ClassName")
                        {
                            ModifyModel.ClassName = sValue;
                        }
                        else if (uc.ID == "Info")
                        {
                            ModifyModel.Info = sValue;
                        }
                        else if (uc.ID == "TitleStyle")
                        {
                            ModifyModel.TitleStyle = sValue;
                        }
                        else if (uc.ID == "SeoTitle")
                        {
                            ModifyModel.SeoTitle = sValue;
                        }
                        else if (uc.ID == "hits")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.hits = int.Parse(sValue);
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
                        else if (uc.ID == "SeoKeyWord")
                        {
                            ModifyModel.SeoKeyWord = sValue;
                        }
                        else if (uc.ID == "SeoDescription")
                        {
                            ModifyModel.SeoDescription = sValue;
                        }
                        else if (uc.ID == "OutLike")
                        {
                            ModifyModel.OutLike = sValue;
                        }
                        //else if (uc.ID == "IsCanAddContent")
                        //{
                        //    if (!string.IsNullOrEmpty(sValue))
                        //        ModifyModel.IsCanAddContent = bool.Parse(sValue);
                        //}



                        //else if (uc.ID == "ContentModelID")
                        //{
                        //    if (!string.IsNullOrEmpty(sValue))
                        //        ModifyModel.ContentModelID = new Guid(sValue);
                        //}
                        //else if (uc.ID == "ContentTemID")
                        //{
                        //    if (!string.IsNullOrEmpty(sValue))
                        //        ModifyModel.ContentTemID = new Guid(sValue);
                        //}
                        //else if (uc.ID == "ClassTemID")
                        //{
                        //    if (!string.IsNullOrEmpty(sValue))
                        //        ModifyModel.ClassTemID = new Guid(sValue);
                        //}
                        //else if (uc.ID == "ClassModelID")
                        //{
                        //    if (!string.IsNullOrEmpty(sValue))
                        //        ModifyModel.ClassModelID = new Guid(sValue);
                        //}
                        //else if (uc.ID == "ListTemID")
                        //{
                        //    if (!string.IsNullOrEmpty(sValue))
                        //        ModifyModel.ListTemID = new Guid(sValue);
                        //}


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
                        else if (uc.ID == "Annex16")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.Annex16 = int.Parse(sValue);

                        }
                        else if (uc.ID == "Annex17")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.Annex17 = int.Parse(sValue);
                        }
                       
                        else if (uc.ID == "Annex11")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.Annex11 = int.Parse(sValue);
                            
                        }
                        else if (uc.ID == "Annex12")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.Annex12 = int.Parse(sValue);
                        }
                        else if (uc.ID == "Annex13")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.Annex13 = int.Parse(sValue);
                        }
                        else if (uc.ID == "Annex14")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.Annex14 = int.Parse(sValue);
                        }
                        else if (uc.ID == "Annex15")
                        {
                            if (!string.IsNullOrEmpty(sValue))
                                ModifyModel.Annex15 = float.Parse(sValue);
                        }


                        //else if (uc.ID == "SubClassAddName")
                        //{
                        //    ModifyModel.SubClassAddName = sValue;
                        //}
                        //else if (uc.ID == "SubClassTemID")
                        //{
                        //    if (!string.IsNullOrEmpty(sValue))
                        //        ModifyModel.SubClassTemID = new Guid(sValue);
                        //}
                        //else if (uc.ID == "SubClassModelID")
                        //{
                        //    if (!string.IsNullOrEmpty(sValue))
                        //        ModifyModel.SubClassModelID = new Guid(sValue);
                        //}
                        ///////////////////////////////////////
                        //else if (uc.ID == "SubDefaultContentModelID")
                        //{
                        //    if (!string.IsNullOrEmpty(sValue))
                        //        ModifyModel.SubDefaultContentModelID = new Guid(sValue);
                        //}

                        //else if (uc.ID == "SubDefaultContentTemID")
                        //{
                        //    if (!string.IsNullOrEmpty(sValue))
                        //        ModifyModel.SubDefaultContentTemID = new Guid(sValue);
                        //}

                        //else if (uc.ID == "SubIsCanAddSub")
                        //{
                        //    if (!string.IsNullOrEmpty(sValue))
                        //        ModifyModel.SubIsCanAddSub = bool.Parse(sValue);
                        //}

                        //else if (uc.ID == "SubIsCanAddContent")
                        //{
                        //    if (!string.IsNullOrEmpty(sValue))
                        //        ModifyModel.SubIsCanAddContent = bool.Parse(sValue);
                        //}

                        //else if (uc.ID == "IsCanAddSub")
                        //{
                        //    if (!string.IsNullOrEmpty(sValue))
                        //        ModifyModel.IsCanAddSub = bool.Parse(sValue);
                        //}

                        //else if (uc.ID == "PageSize")
                        //{
                        //    if (!string.IsNullOrEmpty(sValue))
                        //        ModifyModel.PageSize = int.Parse(sValue);
                        //}
                
                    }
                    else
                    {
                        ModifyModel.AddCusttomFileds(uc.ID, sValue);
                    }
                }

            }

            //如果用户不显示一此必要控件，这里给设置一个默认值(未完成)，还差静态页面命名规则
            //如果是修改的情况下不能用，只有在新添加记录时才继承
            //if (ModifyModel.ID==0&&ModifyModel.ParentID > 0)
            //{
            //    //获取父分类，继承一些默认参数
            //    Entity.NewsClass pmd = BLL.NewsClass.GetModelByCache(ModifyModel.ParentID);

            //    if (Equals(ModifyModel.ContentModelID,Guid.Empty))
            //    {
            //        ModifyModel.ContentModelID = pmd.SubDefaultContentModelID;
            //    }

            //    else if (Equals(ModifyModel.ContentTemID,Guid.Empty))
            //    {
            //        ModifyModel.ContentTemID = pmd.SubDefaultContentTemID;
            //    }
            //    ModifyModel.IsCanAddSub = pmd.SubIsCanAddSub;
            //    ModifyModel.IsCanAddContent = pmd.SubIsCanAddContent;
            //    ModifyModel.ListTemID = pmd.ListTemID;
            //}
        }
        //public void InitSubClassDefaultValue(PlaceHolder ph, int ParentClassID)
        //{
        //    InitSubClassDefaultValuept(ph, ParentClassID);
        //}

        ///// <summary>
        ///// //如果不是修改，那说明是新加，要继承一些父类的设置
        ///// </summary>
        ///// <param name="ph"></param>
        ///// <param name="ParentClassID"></param>
        //private void InitSubClassDefaultValuept(PlaceHolder ph, int ParentClassID)
        //{
        //    if(ParentClassID>0)
        //    {
        //        Entity.NewsClass ParentClass = BLL.NewsClass.GetModelByCache(ParentClassID);

        //        System.Web.UI.Control uc = ph.FindControl("ContentModelID");

        //        if (!Equals(uc, null))
        //        {
        //            SetValueFromControl(uc, ParentClass.SubDefaultContentModelID.ToString());
        //        }
        //        uc = ph.FindControl("ContentTemID");
        //        if (!Equals(uc, null))
        //        {
        //            SetValueFromControl(uc, ParentClass.SubDefaultContentTemID.ToString());
        //        }
        //        uc = ph.FindControl("IsCanAddContent");
        //        if (!Equals(uc, null))
        //        {
        //            SetValueFromControl(uc, ParentClass.SubIsCanAddContent.ToString());
        //        }
        //        uc = ph.FindControl("IsCanAddSub");
        //        if (!Equals(uc, null))
        //        {
        //            SetValueFromControl(uc, ParentClass.SubIsCanAddSub.ToString());
        //        }
        //        uc = ph.FindControl("ClassModelID");
        //        if (!Equals(uc, null))
        //        {
        //            SetValueFromControl(uc, ParentClass.SubClassModelID.ToString());
        //        }  
        //    }
            
        //}
        public override void InitModifyCtr(PlaceHolder ph, EbSite.Entity.NewsClass ModifyModel)
        {
            InitModifyCtrPT(ph, ModifyModel);
        }

        private  void InitModifyCtrPT(PlaceHolder ph, EbSite.Entity.NewsClass ModifyModel)
        {
            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                if (!string.IsNullOrEmpty(uc.SkinID))
                {
                    string sValue = "";
                    if (!bool.Parse(uc.SkinID))
                    {
                        if (uc.ID == "ClassName")
                        {
                            sValue = ModifyModel.ClassName;
                        }
                        else if (uc.ID == "Info")
                        {
                            sValue = ModifyModel.Info;
                        }
                        else if (uc.ID == "TitleStyle")
                        {
                            sValue = ModifyModel.TitleStyle;
                        }
                        else if (uc.ID == "SeoTitle")
                        {
                            sValue = ModifyModel.SeoTitle;
                        }
                        else if (uc.ID == "hits")
                        {
                            sValue = ModifyModel.hits.ToString();
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
                        else if (uc.ID == "SeoKeyWord")
                        {
                            sValue = ModifyModel.SeoKeyWord;
                        }
                        else if (uc.ID == "SeoDescription")
                        {
                            sValue = ModifyModel.SeoDescription;
                        }
                        else if (uc.ID == "OutLike")
                        {
                            sValue = ModifyModel.OutLike;
                        }
                        //else if (uc.ID == "IsCanAddContent")
                        //{
                        //    sValue = ModifyModel.IsCanAddContent.ToString();
                        //}


                        //else if (uc.ID == "ContentModelID")
                        //{
                        //    sValue = ModifyModel.ContentModelID.ToString();
                        //}
                        //else if (uc.ID == "ContentTemID")
                        //{
                        //    sValue = ModifyModel.ContentTemID.ToString();
                        //}
                        //else if (uc.ID == "ClassTemID")
                        //{
                        //    sValue = ModifyModel.ClassTemID.ToString();
                        //}
                        //else if (uc.ID == "ClassModelID")
                        //{
                        //    sValue = ModifyModel.ClassModelID.ToString();

                        //}

                        //else if (uc.ID == "ListTemID")
                        //{
                        //    sValue = ModifyModel.ListTemID.ToString();
                        //}


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
                            sValue = ModifyModel.Annex9.ToString();
                        }
                        else if (uc.ID == "Annex10")
                        {
                            sValue = ModifyModel.Annex10.ToString();
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



                        //else if (uc.ID == "SubClassAddName")
                        //{
                        //    sValue = ModifyModel.SubClassAddName;
                        //}
                        //else if (uc.ID == "SubClassTemID")
                        //{
                        //    sValue = ModifyModel.SubClassTemID.ToString();
                        //}
                        //else if (uc.ID == "SubClassModelID")
                        //{
                        //    sValue = ModifyModel.SubClassModelID.ToString();
                        //}

                           ///////////////////////////////////////
                        //else if (uc.ID == "SubDefaultContentModelID")
                        //{
                        //    sValue = ModifyModel.SubDefaultContentModelID.ToString();
                        //}

                        //else if (uc.ID == "SubDefaultContentTemID")
                        //{
                        //    sValue = ModifyModel.SubDefaultContentTemID.ToString();
                        //}

                        //else if (uc.ID == "SubIsCanAddSub")
                        //{
                        //    sValue = ModifyModel.SubIsCanAddSub.ToString();
                        //}

                        //else if (uc.ID == "SubIsCanAddContent")
                        //{
                        //    sValue = ModifyModel.SubIsCanAddContent.ToString();
                        //}

                        //else if (uc.ID == "IsCanAddSub")
                        //{
                        //    sValue = ModifyModel.IsCanAddSub.ToString();
                        //}
                        //else if (uc.ID == "PageSize")
                        //{
                        //    sValue = ModifyModel.PageSize.ToString();
                        //}

                       
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

    }
}
