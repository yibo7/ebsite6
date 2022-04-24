using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Core.DataBase.Interface;
using EbSite.ModulesGenerate.Core;

namespace EbSite.ModulesGenerate
{
    public partial class FieldSearch : EbSite.Base.ControlPage.UserControlBase
    {
        public override string Permission
        {
            get
            {
                return "1";
            }
        }
        public string tableName
        {
            get { return Request.QueryString["tbn"]; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbName = Request.QueryString["dbn"];
            IDbObject dbobj = Session["dbobj"] as IDbObject;
            if (!Equals(dbobj, null))
            {
                this.gdList.DataSource = dbobj.GetColumnList(dbName, tableName);
                this.gdList.DataBind();
            }

        }
        List<FieldInfo> lsit = System.Web.HttpContext.Current.Session["FieldSearch"] as List<FieldInfo>;
        protected bool GetCheckColum(string columName)
        {
            bool isCheck = false;
            if (!Equals(lsit, null))
            {
                List<FieldInfo> NewList = (from li in lsit
                                           where (li.FieldName == columName) &&
                                               (li.TableName == tableName)
                                           select li
                                       ).ToList();
                if (NewList.Count > 0)
                {
                    isCheck = true;
                }
            }
            return isCheck;
        }
        protected string GetCheckControl(string columName,int? typeId)
        {
            string tag = "";
            if (!Equals(lsit, null))
            {
                List<FieldInfo> NewList =
                    (from li in lsit where li.TableName == tableName && li.FieldName == columName select li).ToList();

                if (NewList.Count>0)
                {
                    if(typeId==1)
                    {
                        tag = NewList[0].Matching;
                    }
                    else
                    {
                        tag = NewList[0].Relevance;
                    }
                    
                }
            }
            return tag;
        }

        protected void gdList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList dpMatch = (DropDownList)e.Row.FindControl("SelectMatch");
           // DropDownList dpAssociated = (DropDownList)e.Row.FindControl("SelectAssociated");
            Label Lb = (Label)e.Row.FindControl("columID");
            if (!Equals(Lb, null))
            {
                dpMatch.SelectedValue = GetCheckControl(Lb.Text, 1);
               // dpAssociated.SelectedValue = GetCheckControl(Lb.Text, 2);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RadioButton rb = (RadioButton)e.Row.FindControl("Selector");
                if (rb != null)
                {
                    rb.Attributes.Add("onclick", "single(this)");  //single(obj)为js函数  
                }
            } 



        }
        protected void bntOK_Click(object sender, EventArgs e)
        {

            List<FieldInfo> lsitALL = new List<FieldInfo>();
            List<FieldInfo> lsit = new List<FieldInfo>();
            if (!Equals(Session["FieldSearch"], null))
            {
                lsitALL = Session["FieldSearch"] as List<FieldInfo>;
                //为了修改时，不重复添加数据的字段，先删除当前的所有session记录,然后再添加.
                //删除 相当于查这个表之外的所有表
                lsitALL = (from li in lsitALL where li.TableName != tableName select li).ToList();

                foreach (GridViewRow row in gdList.Rows)
                {
                    RadioButton cb = (RadioButton)row.FindControl("Selector");
                    if (cb != null && cb.Checked)
                    {
                        EbSite.ModulesGenerate.Core.FieldInfo model = new FieldInfo();
                        Label columName = (Label)row.FindControl("columID");
                        model.FieldName = columName.Text;
                        model.TypeId = 4;//1:List 2:Add 3:Show 4：Search
                        //相等匹配 0. 模糊匹配 1.大于 2 .小于 3.两个值之间 4.
                        DropDownList dp = (DropDownList)row.FindControl("SelectMatch"); //匹配模式
                        model.Matching = dp.SelectedValue;
                        //或者 or 与连 And 忽略 null.
                      //  DropDownList dpAs = (DropDownList)row.FindControl("SelectAssociated"); //关连模式
                       // model.Relevance = dpAs.SelectedValue;
                        //DropDownList dpControl = (DropDownList)row.FindControl("SelectControlID");
                        Label columType = (Label) row.FindControl("columType");//作为选查询条件选控件的标志。
                        model.ControlId = columType.Text;
                        model.TableName = Request.QueryString["tbn"];

                        lsitALL.Add(model);
                    }
                }


                Session["FieldSearch"] = lsitALL;

            }
            else
            {
                foreach (GridViewRow row in gdList.Rows)
                {
                    RadioButton cb = (RadioButton)row.FindControl("Selector");
                    if (cb != null && cb.Checked)
                    {
                        EbSite.ModulesGenerate.Core.FieldInfo model = new FieldInfo();
                        Label columName = (Label)row.FindControl("columID");
                        model.FieldName = columName.Text;
                        model.TypeId = 4;//1:List 2:Add 3:Show 4：Search
                        //相等匹配 0. 模糊匹配 1.大于 2 .小于 3.两个值之间 4.
                        DropDownList dp = (DropDownList)row.FindControl("SelectMatch"); //匹配模式
                        model.Matching = dp.SelectedValue;
                        //或者 or 与连 And 忽略 null.
                       // DropDownList dpAs = (DropDownList)row.FindControl("SelectAssociated"); //关连模式
                       // model.Relevance = dpAs.SelectedValue;
                        //理由是匹配模式的时候，选两个值之间的，默认是时间控件，否则为文本框控件
                        //DropDownList dpControl = (DropDownList)row.FindControl("SelectControlID");
                        Label columType = (Label)row.FindControl("columType");//作为选查询条件选控件的标志。
                        model.ControlId = columType.Text;

                        model.TableName = Request.QueryString["tbn"];

                        lsit.Add(model);
                    }
                }


                Session["FieldSearch"] = lsit;

            }
            EbSite.Core.Strings.cJavascripts.RunClientJs(this, "ColseGreyBox();");
        }
    }
}