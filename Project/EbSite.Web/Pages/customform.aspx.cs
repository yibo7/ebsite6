using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;
using EbSite.BLL;
using EbSite.BLL.ModelBll;
using EbSite.Entity;

namespace EbSite.Web.Pages
{
    public partial class customform : EbSite.Base.Page.BasePage
    {
        private Guid ModelID
        {
            get
            {
                if(!string.IsNullOrEmpty(Request["mid"]))
                {
                    return new Guid(Request["mid"]);
                }
                else
                {
                   
                    return Guid.Empty;
                }
            }
        }
        /// <summary>
        /// 修改时用
        /// </summary>
        private Guid DataID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return new Guid(Request["id"]);
                }
                else
                {

                    return Guid.Empty;
                }
            }
        }
        public ModelInterface bllModel
        {
            get
            {
                return new FormModel(GetSiteID);

            }
        }
        private CusttomFiledsBLL<StringDictionary> CFB
        {
            get
            {
                return EbSite.BLL.ModelBll.CusstomFileds.HrefFactory.GetInstance(ModelID, ModelType.BDMX,GetSiteID);
            }
        }

        protected override void AddHeaderPram()
        {
            ModelInterface bllModel = new FormModel(GetSiteID);
            ModelClass mc = bllModel.GeModelByID(ModelID);

            if (!mc.IsSystem)
            {
                AddHeaderPramPC();
            }
            else
            {
                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/init.js"));
                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/inc.js"));
            }
             
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSaveData.Click += new EventHandler(btnSaveData_Click);
            if(!IsPostBack)
            {
                if (DataID != Guid.Empty)
                {
                    StringDictionary md = CFB.GetEntity(DataID);
                    BLL.FormModel.Instance.InitModifyCtr(phFileds, md);
                     
                }
            }
            
        }

        // protected override void OnPreRender(EventArgs e)
        //{
        //    if (!Page.ClientScript.IsClientScriptBlockRegistered("customform"))
        //    {
        //        string sCssAndJs = "<script>In.ready('dialog'); In.ready('jqui'); </script>";

        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "customform", sCssAndJs);
        //    }

            
        //    base.OnPreRender(e);
        //}
        protected void btnSaveData_Click(object sender, EventArgs e)
        {
            if(ModelID!=Guid.Empty)
            {
                
                Guid did = Guid.NewGuid();
                StringDictionary ThisModel = new StringDictionary();
                if (DataID != Guid.Empty)
                {
                    did = DataID;

                    //ThisModel = CFB.GetEntity(DataID);

                    
                }
                BLL.FormModel.Instance.InitSaveCtr(phFileds, ref ThisModel);

                CFB.Save(did, ThisModel);
                Core.Strings.cJavascripts.MessageShowBack("提交成功！");

               // Tips("操作提示", "提交成功！","");
            }
            else
            {
                Tips("操作提示", "提交失败，找不到对应的表单模型！","");
                
            }
            
        }


    }
}