using System;
using System.Collections.Generic;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class Admin_Content : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("Admin_Content");
        }
        /// <summary>
        /// 添加控件
        /// </summary>
        protected override void AddControl()
        {
            if (PageType == 0)  //添加内容
            {
                base.LoadAControl("AddSelClass.ascx");
            }
            else if (PageType == 1)
            {
                base.LoadAControl("ContentManage.ascx");
            }
            else if (PageType == 2)
            {
                base.LoadAControl("TagColor.ascx");
            }
            else if (PageType == 3)
            {
                base.LoadAControl("LabelModify.ascx");
            }
            else if (PageType == 4)
            {
                base.LoadAControl("AddContent.ascx");
            }
            else if (PageType == 5)
            {
                base.LoadAControl("MoveToClass.ascx");
            }
            else if (PageType == 6) //评论管理
            {

                int iRemarkclass = Core.Utils.StrToInt(Request["remarkclass"]);
                int iType = 0;
                if (iRemarkclass == 0) //默认
                {
                    List<Entity.RemarkClass> lst = BLL.RemarkClass.Instance.GetModelList();

                    if (lst.Count > 0)
                    {
                        iRemarkclass = lst[0].Itype;
                    }
                } 

                if (iRemarkclass == 1)
                {
                    base.LoadAControl("CommentList.ascx");
                }
                else if (iRemarkclass == 2)
                {
                    base.LoadAControl("EvaluatePg.ascx");
                }
                else if (iRemarkclass == 3)
                {
                    base.LoadAControl("AskRemarkList.ascx");
                }
                else
                {
                    Response.Write("参数有错误,或没有创建评论区!");
                    Response.End();
                }
                 
                
            }
            else if (PageType == 11) //评论无限回答模式下的回复列表查看
            {
                base.LoadAControl("EvaluateList.ascx");
            }
            else if (PageType == 13) //商家问答式的回复
            {
                base.LoadAControl("RemarkAnswer.ascx");
            }
            else
            {
                base.AddControl();
            }

        }
    }
}
