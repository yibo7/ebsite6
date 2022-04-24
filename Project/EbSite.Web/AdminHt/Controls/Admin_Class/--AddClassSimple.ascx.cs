//using System;
//using System.Collections.Generic;
//using System.Web.UI.WebControls;
//using EbSite.BLL;
//using EbSite.Entity;
//using NewsClass = EbSite.Entity.NewsClass;

//namespace EbSite.Web.AdminHt.Controls.Admin_Class
//{
//    //已经不使用此页面，保留只为参考
//    public partial class AddClassSimple : BaseAddClass
//    {
        
//        protected void Page_Load(object sender, EventArgs e)
//        {
           
//              BindData();
             
//             if(!IsPostBack)
//             { 
 
//                 InitModify();
 
//            }

             

//              drpClassList.DataValueField = "id";
 
//             drpClassList.DataTextField = "classname";
//              drpClassList.DataSource = BLL.NewsClass.GetContentClassesTree(0,base.GetSiteID);
 
//            drpClassList.DataBind();
 
 
//            drpClassList.SelectedValue = pid.ToString();
 

//        }

      

//        override protected void SaveModel()
//        {

//            Entity.NewsClass cm = new NewsClass();
//            int iParentID = int.Parse(drpClassList.SelectedValue);
//            string OldClassName = "";
//            if (cid > 0)
//            {
//                cm = BLL.NewsClass.GetModel(cid);
//                OldClassName = cm.ClassName;
//            }
//            cm.ParentID = iParentID;

//            cm.ClassHtmlNameRule = rnHtmlName.Text.Trim();
//            cm.HtmlName = HtmlReNameRule.GetName(rnHtmlName.Text.Trim(), cm.ClassName);//从当前规则转换文件名

//            cm.ContentHtmlName = rnHtmlContent.Text.Trim();

//            //2012-01-13 yhl operate
//            cm.SeoTitle = this.SeoTitle.Text.Trim();
//            cm.SeoKeyWord = this.SeoKeyWord.Text.Trim();
//            cm.SeoDescription = this.SeoDescription.Text.Trim();
//            cm.PageSize = int.Parse(this.PageSize.Text.Trim());

//            cm.ListTemID =new Guid(this.ListTemID.SelectedValue);
//            cm.ClassModelID = new Guid(this.ClassModelID.SelectedValue);
//            cm.ClassTemID = new Guid(this.ClassTemID.SelectedValue);
//            cm.ContentTemID = new Guid(this.ContentTemID.SelectedValue);
//            cm.ContentModelID = new Guid(this.ContentModelID.SelectedValue);

//            cm.IsCanAddSub = this.IsCanAddSub.Checked;
//            cm.IsCanAddContent = this.IsCanAddContent.Checked;

//            cm.hits =int.Parse(this.hits.Text.Trim());
//            cm.dayHits = int.Parse(this.dayHits.Text.Trim());
//            cm.weekHits = int.Parse(this.weekHits.Text.Trim());
//            cm.monthhits = int.Parse(this.monthhits.Text.Trim());
//            cm.OutLike = this.OutLike.Text.Trim();

//            cm.SubClassAddName = this.SubClassAddName.Text.Trim();
//            cm.SubClassTemID =new Guid(SubClassTemID.SelectedValue);
//            cm.SubClassModelID = new Guid(SubClassModelID.SelectedValue);
//            cm.SubIsCanAddSub = SubIsCanAddSub.Checked;
//            cm.SubIsCanAddContent = SubIsCanAddContent.Checked;
//            cm.ModuleID = new Guid(BingModule.SelectedValue);

           
//            //获取自定义字段的值
//            cm.ID = cid;
//            //BLL.ClassModel.Instance.InitSaveCtr(phCustomControls, ref cm);
//            foreach (PlaceHolder ph in lstPlaceHolder)
//            {
//                BLL.ClassModel.Instance.InitSaveCtr(ph, ref cm);
//            }

//            int newid = BLL.NewsClass.AddBLL(cm, cbConfigsToSub.Checked, OldClassName, base.GetSiteID);


//            //if (cid > 0) //修改分类
//            //{
//            //    if (cm.ID == cm.ParentID)
//            //    {
//            //        TipsAlert("父分类为能为其本身!");
//            //        return;
//            //    }
                
//            //    BLL.NewsClass.Update(cm);

//            //    if (!Equals(OldClassName,cm.ClassName)) //如果修改了分类名称，那么要同时更新内容表的ClassName字段
//            //    {
//            //        //未完成
//            //    }

//            //    if (cbConfigsToSub.Checked)//将相关配置更新到子分类
//            //    {
//            //        //模板
//            //        BLL.NewsClass.UpdateTemToSubClass_Class(cm);
//            //        BLL.NewsClass.UpdateTemToSubClass_Content(cm);

//            //        //静态页面的命名规则
//            //        BLL.NewsClass.UpdateRuleToSub_Class(cm);
//            //        BLL.NewsClass.UpdateRuleToSub_Content(cm);
//            //        //模型
//            //        BLL.NewsClass.UpdateModelToSubClass(cm);
                    
//            //    }
//            //}

//            //else    //添加一级分类
//            //{
//            //    cm.OrderID = BLL.NewsClass.GetMaxOrderID(cm.ParentID)+1;
//            //    BLL.NewsClass.Add(cm);
//            //}

//            if(cbIsContinu.Checked)
//            {
//                Response.Redirect(GetMenuLink(2));
//            }
                

//        }
//    }
//}