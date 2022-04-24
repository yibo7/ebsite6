using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using EbSite.BLL;

namespace EbSite.Web.AdminHt.Controls.Admin_Special
{
    public partial class AddSpecial : EbSite.Base.ControlPage.UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "67";
            }
        }
        private int sid
        {
            get
            {
                if (!string.IsNullOrEmpty(SID))
                {
                    return int.Parse(SID);
                }
                return -1;
            }
        }
        private int pid
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["pid"]))
                {
                    return int.Parse(Request["pid"]);
                }
                return 0;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //drpParent.DataTextField = "SpecialName";
            //drpParent.DataValueField = "id";
            //drpParent.DataSource = BLL.SpecialClass.GetTree(base.GetSiteID);
            //drpParent.DataBind();

            if (pid > 0)
            {
                //drpParent.SelectedValue = pid.ToString();
                lbClassName.Text = BLL.SpecialClass.GetModel(pid).SpecialName;
            }
            else
            {
                divsteptips.InnerHtml = "添加一级专题";
            }

            drpTem.DataValueField = "ID";
            drpTem.DataTextField = "TemName";
            drpTem.DataSource = TempFactory.Instance.GetListByType(3);
            drpTem.DataBind();

            if (!IsPostBack)
            {
                //  BindClass(); yhl 2014-1-23注释
                InitModify();
               
            }

        }

        private void InitModify()
        {
            if (sid > 0)
            {
                divsteptips.InnerHtml = "编辑专题 [<a onclick=\"javascript:history.go(-1);\">返回</a>]";
                Entity.SpecialClass cm = BLL.SpecialClass.GetModel(sid);

                txtClassName.Text = cm.SpecialName;

                tbuUploadImg.CtrValue = cm.Titletype;

                Orderid.Text = cm.Orderid.ToString();

                rnHtmlName.Text = cm.ClassHtmlNameRule;

                drpTem.SelectedValue = cm.SpecialTemID.ToString();

                txtSeoSpecialDes.Text = cm.SeoDescription;
                txtSeoSpecialTitle.Text = cm.SeoTitle;
                txtSeoSpecialKeyWord.Text = cm.SeoKeyWord;
                drpTemMobile.SelectedValue = cm.SpecialTemIDMobile.ToString();

                txtInfo.Text = cm.Info;

                cbIsCusttomRw.Checked = cm.IsCusttomRw;

                //drpParent.SelectedValue = cm.ParentID.ToString();

                //yhl 2014-1-23注释
                //string[] arry = Core.Strings.GetString.SplitString(cm.RelateClassIDs, ",");
                //for (int i = 0; i < arry.Length; i++)
                //{
                //    foreach (ListItem li in cblClass.Items)
                //    {
                //        if(li.Value.ToString()==arry[i])
                //        {
                //            li.Selected = true;
                //        }
                //    }
                //}



                //btnAdd.Text = "修改专题";

            }
            else
            {
                rnHtmlName.Text = Base.Configs.HtmlConfigs.ConfigsControl.Instance.SpecialHtmlRule;
                //txtSeoSpecialDes.Text = Base.Configs.ContentSet.ConfigsControl.Instance.SeoSpecialDes;
                //txtSeoSpecialTitle.Text = Base.Configs.ContentSet.ConfigsControl.Instance.SeoSpecialTitle;
                //txtSeoSpecialKeyWord.Text = Base.Configs.ContentSet.ConfigsControl.Instance.SeoSpecialKeyWord;

                //YHL 2013-05-07 每个站点的描述
                List<EbSite.Base.EntityCustom.SeoSite> ls = EbSite.BLL.SeoSites.Instance.FillList();
                int siteid = GetSiteID;
                List<EbSite.Base.EntityCustom.SeoSite> mds = (from i in ls where i.SiteID == siteid select i).ToList();
                if (mds.Count > 0)
                {
                    EbSite.Base.EntityCustom.SeoSite mdSeoSite = mds[0];

                    txtSeoSpecialDes.Text = mdSeoSite.SeoSpecialDes;
                    txtSeoSpecialTitle.Text = mdSeoSite.SeoSpecialTitle;
                    txtSeoSpecialKeyWord.Text = mdSeoSite.SeoSpecialKeyWord;
                }
                   
                
             
            }
        }

        private void AddOne(string sSpecialName)
        {
            if (!string.IsNullOrEmpty(sSpecialName))
            {
                Entity.SpecialClass mdTC = new Entity.SpecialClass();
                if (sid > 0)
                {
                    mdTC = BLL.SpecialClass.GetModel(sid);
                }
                mdTC.SpecialName = sSpecialName;
                mdTC.Titletype = tbuUploadImg.CtrValue;
                mdTC.Orderid = int.Parse(Orderid.Text);
                mdTC.ClassHtmlNameRule = rnHtmlName.Text.Trim();

                mdTC.HtmlName = HtmlReNameRule.GetName(mdTC.ClassHtmlNameRule, mdTC.SpecialName, "");//从当前规则转换文件名

                mdTC.SpecialTemID = new Guid(drpTem.SelectedValue);

                mdTC.SeoDescription = txtSeoSpecialDes.Text.Trim();
                mdTC.SeoTitle = txtSeoSpecialTitle.Text.Trim();
                mdTC.SeoKeyWord = txtSeoSpecialKeyWord.Text.Trim();

                //  mdTC.RelateClassIDs = GetItems();//分类IDs   yhl 2014-1-23注释
                mdTC.SpecialTemIDMobile = new Guid(drpTemMobile.SelectedValue);

                //mdTC.ParentID = int.Parse(drpParent.SelectedValue);
                mdTC.ParentID = pid;

                mdTC.Info = txtInfo.Text;
                if (cbMore.Checked) //批量添加不能自定义重写
                    mdTC.IsCusttomRw = false;
                else
                {
                    mdTC.IsCusttomRw = cbIsCusttomRw.Checked;
                }
               

                if (mdTC.IsCusttomRw) //不可以添加重复的key
                {
                    //if (Base.AppStartInit.AllRewriteKey.ContainsKey(mdTC.HtmlName))
                    //{
                    //    Tips("自定义重写的地址与其他发生重复,请换一个再重试！");
                    //    return;

                    //}

                    if (mdTC.HtmlName.StartsWith("/") || mdTC.HtmlName.EndsWith("/"))
                    {
                        Tips("自定义重写的地址前缀与后缀不能加/！");
                        return;
                    }


                }

                if (sid > 0)
                {
                    mdTC.id = sid;
                    if (mdTC.id == mdTC.ParentID)
                    {
                        TipsAlert("父专题为能为本身!");
                        return;
                    }
                    BLL.SpecialClass.Update(mdTC);
                }
                else
                {
                    BLL.SpecialClass.Add(mdTC, base.GetSiteID);
                }
            }

        }
        override protected void SaveModel()
        {
            string sName = txtClassName.Text.Trim();
            if (cbMore.Checked)
            {
                string sp = txtSpilt.Text;
                string[] aNames = Core.Strings.GetString.SplitString(sName, sp);
                foreach (string name in aNames)
                {
                    AddOne(name);
                }
            }
            else
            {
                AddOne(sName);
            }

            if (cbIsContinu.Checked)
            {
                Response.Redirect(GetMenuLink(4));
            }
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
        //protected void btnAdd_Click(object sender, EventArgs e)
        //{


        //}

        protected void cbMore_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMore.Checked)
            {
                txtClassName.TextMode = TextBoxMode.MultiLine;
                txtClassName.Width = 300;
                txtClassName.Height = 50;
                txtSpilt.Visible = true;
            }
            else
            {
                txtClassName.TextMode = TextBoxMode.SingleLine;
                txtSpilt.Visible = false;
            }
        }

        //protected void IsAptID_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (IsAptID.Checked)
        //    {
        //        cblClass.Enabled = false;
        //    }
        //    else
        //    {
        //        cblClass.Enabled = true;
        //    }
        //}
        #region YHL 2014-1-23 注释
        //private void BindClass()
        //{
        //    cblClass.DataValueField = "ID";
        //    cblClass.DataTextField = "ClassName";
        //    cblClass.DataSource = BLL.NewsClass.GetContentClassesTree(base.GetSiteID);
        //    cblClass.DataBind();

        //}
        //private string GetItems()
        //{
        //    if (cblClass.Items.Count>0)
        //    {
        //        StringBuilder sb = new StringBuilder();

        //        foreach (ListItem li in cblClass.Items)
        //        {
        //            if (li.Selected)
        //            {
        //                sb.Append(li.Value);
        //                sb.Append(",");
        //            }
        //        }
        //        if (sb.Length > 1) sb.Remove(sb.Length - 1, 1);
        //        return sb.ToString();
        //    }
        //    else
        //    {
        //        return "";
        //    }


        //}

        #endregion
    }
}