using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Entity;
using NewsClass = EbSite.Entity.NewsClass;

namespace EbSite.Web.AdminHt.Controls.Admin_Class
{
    public partial class AddClass : BaseAddClass
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            BindData();
           
            if (!IsPostBack)
            {

                InitModify();
                
                if(!string.IsNullOrEmpty(SID))
                {
                    
                    divsteptips.InnerHtml = string.Format("<div class=\"col-lg-12\"><div class=\"card-box\">{0}</div></div>", "编辑分类 [<a onclick=\"javascript:history.go(-1);\">返回</a>]"); 
                }
            }
            //drpClassList.DataValueField = "id";

            //drpClassList.DataTextField = "classname";
            //drpClassList.DataSource = BLL.NewsClass.GetContentClassesTree(0, base.GetSiteID);

            //drpClassList.DataBind();


            //drpClassList.SelectedValue = pid.ToString();
            //分类内容化下暂时不启用，有点小问题
            //cbIsContinu.Visible = false;
            //cbIsContinu.Checked = false;



            //trSeoTitle.Visible = false;

        }

        //private int iParentID
        //{
        //    get
        //    {
        //        return Core.Utils.StrToInt(Request["pid"],0);
        //    }
        //}

        override protected void SaveModel()
        {

            Entity.NewsClass cm = new NewsClass();
            //int iParentID = int.Parse(drpClassList.SelectedValue);

            if (pid > 0)
            {
                lbClassName.Text = BLL.NewsClass.GetModel(pid).ClassName;
            }
            else
            {
                lbClassName.Text = "一级分类";
            }

            string OldClassName = "";
            if (cid > 0)
            {
                cm = BLL.NewsClass.GetModel(cid);
                OldClassName = cm.ClassName;
            }

            cm.ParentID = pid;
            
            //BLL.NewsClass.InitDefaultConfigs(ref cm);

            
            cm.SeoTitle = this.SeoTitle.Text.Trim();
            cm.SeoKeyWord = this.SeoKeyWord.Text.Trim();
            cm.SeoDescription = this.SeoDescription.Text.Trim();
           

            cm.hits = int.Parse(this.hits.Text.Trim());
            cm.dayHits = int.Parse(this.dayHits.Text.Trim());
            cm.weekHits = int.Parse(this.weekHits.Text.Trim());
            cm.monthhits = int.Parse(this.monthhits.Text.Trim());
            cm.HtmlName = this.HtmlName.Text.Trim();

            cm.OutLike = this.OutLike.Text.Trim();

            cm.IsHtmlNameReWrite = IsHtmlNameReWrite.Checked;

            cm.ContentHtmlPath = ContentHtmlPath.Text.Trim();
            cm.IsHtmlNameReWriteContent = IsHtmlNameReWriteContent.Checked;
            //cm.ClassModelID = Modelid;
             
            if (cm.IsHtmlNameReWrite) //不可以添加重复的key
            {
                //if (Base.AppStartInit.AllRewriteKey.ContainsKey(cm.HtmlName))
                //{
                //    Tips("自定义重写的地址与其他发生重复,请换一个再重试！");
                //    return;

                //}

                if (cm.HtmlName.StartsWith("/") || cm.HtmlName.EndsWith("/"))
                {
                    Tips("自定义重写的地址前缀与后缀不能加/！");
                    return;
                }


            }
            

            //获取自定义字段的值
                cm.ID = cid;
            foreach (PlaceHolder ph in lstPlaceHolder)
            {
                BLL.ClassModel.Instance.InitSaveCtr(ph, ref cm);
            }
            int ParentConfigId = 0;
            if (pid > 0)
            {
                Entity.NewsClass pmd = BLL.NewsClass.GetModel(pid);
                ParentConfigId = pmd.ConfigId;
            }
            

            if (!cbMore.Checked) //正常添加或修改
            {
                int newid = BLL.NewsClass.AddBLL(cm, ParentConfigId, OldClassName, base.GetSiteID, Modelid);
                
                //是不是还要更新子分类配置

            }
            else //批量添加
            {
                string ClassNames = txtClassNames.Text.Trim();
                //StringBuilder sbNewIds = new StringBuilder();
                if(!string.IsNullOrEmpty(ClassNames))
                {
                    string[] aClassName = HostApi.HuiCheSplit(ClassNames);// Core.Strings.GetString.SplitString(ClassNames,"\r\n");//ClassNames.Split('#');
                    foreach (string sClassName in aClassName)
                    {
                        if (!string.IsNullOrEmpty(sClassName))
                        {
                            cm.ID = 0;
                            cm.ClassName = sClassName;
                            
                            int newid = BLL.NewsClass.AddBLL(cm, ParentConfigId, OldClassName, base.GetSiteID, Modelid);
                            //sbNewIds.Append(newid);
                            //sbNewIds.Append(",");
                        }
                        
                    }
                }

                //if (sbNewIds.Length > 0)
                //{
                //    sbNewIds.Remove(sbNewIds.Length - 1, 1);

                //    if (cm.ParentID == 0)
                //    {
                //        BLL.ClassConfigs.Instance.AddClassListToDefault(sbNewIds.ToString(), Modelid);
                //    }
                //    else
                //    {
                //        BLL.ClassConfigs.Instance.AddSubClassListToParentConfig(cm.ParentID, sbNewIds.ToString());
                //    }
                //}
            }
            
            


            //if (cbIsContinu.Checked)
            //{
            //    Response.Redirect(GetMenuLink(2));
            //}


        }
    }

}