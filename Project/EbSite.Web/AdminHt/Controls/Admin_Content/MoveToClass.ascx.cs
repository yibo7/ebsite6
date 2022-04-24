using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.Web.AdminHt.Controls.Admin_Class;

namespace EbSite.Web.AdminHt.Controls.Admin_Content
{
    public partial class MoveToClass : EbSite.Base.ControlPage.UserControlBaseSave 
    {
        public override string Permission
        {
            get
            {
                return "61";
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
        }

         override protected void SaveModel()
         {
             int newClassID = Core.Utils.StrToInt(selClass.Value,0);
             string titleNames = "";
             string scontentids = Request["ids"];
             string mid = Request["modelid"];//YHL 2014-2-11 
             string[] aContentID = scontentids.Split(',');
             //int iClassID = Core.Utils.StrToInt(selClass.Value, 0);
             
             if (newClassID > 0)
             {
                 string sClassName = EbSite.BLL.NewsClass.GetModel(newClassID).ClassName;
                 foreach (string sID in aContentID)
                 {
                     int ContentID = Convert.ToInt32(sID);
                     if (IsContentModelSame(Guid.Parse(mid) , ContentID, newClassID))
                     {
                         UpdateClass(Guid.Parse(mid),ContentID, newClassID, sClassName);
                     }
                     else
                     {
                         NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(Guid.Parse(mid),GetSiteID);

                         titleNames += NewsContentInst.GetModel(ContentID, GetSiteID).NewsTitle + ",";
                     }
                 }
             }
             else
             {
                 Tips("请选择分类", "请选择分类后再做操作!");
             }


             //foreach (GridViewRow row in gdList.Rows)
             //{
             //    System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)row.FindControl("Selector");
             //    if (cb != null && cb.Checked)
             //    {
             //        //IsCheck = true;
             //        int ContentID = Convert.ToInt32(gdList.DataKeys[row.RowIndex].Value);
             //        if (IsContentModelSame(ContentID, int.Parse(newClassID)))
             //        {
             //            UpdateClass(ContentID);
             //        }
             //        else
             //        {
             //            titleNames += BLL.NewsContent.GetModel(ContentID).NewsTitle + ",";
             //        }
             //    }
             //}
             if (titleNames != "")
             {
                 titleNames = titleNames.Remove(titleNames.Length - 1, 1);
                 Tips(titleNames + "选择对应的分类的模型不一致，不能移动。", "", GetMenuLink(0));

             }
             else
             {
                 Response.Redirect(GetMenuLink(0));
             }
         }

         #region 内容移动
        
         /// <summary>
         /// 判断 两个类型的模型 是否相同
         /// </summary>
         /// <param name="contentID"></param>
         /// <param name="classID"></param>
         /// <returns></returns>
         protected bool IsContentModelSame(Guid mid, int contentID, int classID)
         {
             bool isKey = false;
             NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(mid, GetSiteID);//YHL 2014-2-11
             Entity.NewsContent md = NewsContentInst.GetModel(contentID, GetSiteID);
             string ModelID1 = "";
             string ModelID2 = "";
             if (md.ClassID > 0)
             {

                 ModelID1 = BLL.ClassConfigs.Instance.GetContentModelID(md.ClassID).ToString(); // BLL.NewsClass.GetModel(md.ClassID).ContentModelID.ToString();
             }
             if (classID > 0)
             {
                 ModelID2 = BLL.ClassConfigs.Instance.GetContentModelID(classID).ToString(); ;// BLL.NewsClass.GetModel(classID).ContentModelID.ToString();
             }
             if ((ModelID2 != "" && ModelID1 != "") && ModelID2 == ModelID1)
             {
                 isKey = true;
             }

             return isKey;
         }
         /// <summary>
         /// 更改类别ID
         /// </summary>
         /// <param name="contentID"></param>
         protected void UpdateClass(Guid mid,int contentID,int iClassID,string ClassName)
         {
             NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(mid, GetSiteID);//YHL 2014-2-11
             Entity.NewsContent md = NewsContentInst.GetModel(contentID, GetSiteID);
             md.ClassID = iClassID;
             md.ClassName = ClassName;
             NewsContentInst.Update(md);
         }
         #endregion
    }
}