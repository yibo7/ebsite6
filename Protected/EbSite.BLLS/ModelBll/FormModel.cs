using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL.ModelBll;
using EbSite.Entity;

namespace EbSite.BLL
{
    public class FormModel : ModelBase<StringDictionary> 
    {
        public FormModel(int _SiteID)
            : base(_SiteID)
        {
            
        }
        public override string WebModelName
        {
            get
            {
                return "FormModel";
            }
        }
        public static  FormModel Instance
        {
            get
            {
                return new FormModel(EbSite.Base.Host.Instance.GetSiteID);
            }

        }
        public static FormModel InstanceObj(int _SiteID)
        {
            return new FormModel(_SiteID);
        }

        public override string[] aColums
        {

            get
            {
               string [] aC = {};

                return aC;
            }

        }
        public override void InitSaveCtr(PlaceHolder ph, ref StringDictionary ModifyModel)
        {
            InitSaveCtrPT(ph, ref ModifyModel);
        }

        private void InitSaveCtrPT(PlaceHolder ph, ref StringDictionary ModifyModel)
        {
            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                string sValue = "";
                sValue = GetValueFromControl(uc);
                ModifyModel.Add(uc.ID, sValue);

               

            }
        }
        public override void InitModifyCtr(PlaceHolder ph, StringDictionary ModifyModel)
        {
            InitModifyCtrPT(ph, ModifyModel);
        }

        private void InitModifyCtrPT(PlaceHolder ph, StringDictionary ModifyModel)
        {
            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                string sValue = "";
                if (ModifyModel.ContainsKey(uc.ID))
                {
                    sValue = ModifyModel[uc.ID];
                    SetValueFromControl(uc, sValue);
                }
                    

            }
        }
    
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

        //override protected void OnSaved(ModelClass mc, ColumFiledConfigs cfcCurrent)
        //{
        //    List<ColumFiledConfigs> cfcs = mc.GetUsedFileds;
        //    StringBuilder sb = new StringBuilder();
        //    foreach (ColumFiledConfigs cfc in cfcs)
        //    {
        //        sb.AppendFormat("<XS:ExtensionsCtrls ID=\"{0}\" ModelCtrlID=\"{1}\" ShowName=\"{2}\" runat=\"server\"/> \n\t<br><br>\n\t", cfc.ColumFiledName, cfc.FieldControlTypeID, cfc.ColumShowName);
        //    }
        //    string html = mc.GetTemHtml();
        //    string tem = Core.Strings.GetString.CutMiddleStr(html, "<asp:PlaceHolder ID=\"phFileds\" runat=\"server\">",
        //                                                     "</asp:PlaceHolder>");
        //    html = html.Replace(tem, sb.ToString());
        //    mc.UpdateFormTem(html);
        //}
        

    }
   
}
