using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.BLL.ModelBll;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Model
{
    public partial class AddModel : UserControlBaseSave
    {

        protected void BindData()
        {
            ListTemID.DataTextField = "Title";
            ListTemID.DataValueField = "id";
            ListTemID.DataSource = EbSite.BLL.ContentTem.Instance.FillList();
            ListTemID.DataBind();
            ListTemID.Items.Insert(0, new ListItem("默认模板", Guid.Empty.ToString()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int iMt = int.Parse(Request["mt"]);
                ModelType mt = (ModelType)iMt;
                if (mt == ModelType.NRMX)
                {
                    panTb.Visible = true;
                }
                else
                {
                    panTb.Visible = false;
                }
                if (string.IsNullOrEmpty(SID))
                    BindData();
            }

        }
        public ModelInterface bllModel
        {
            get
            {
                int iMt = int.Parse(Request["mt"]);

                ModelType mt = (ModelType)iMt;

                if (mt == ModelType.NRMX)
                {
                    return new WebModel(GetSiteID);
                }
                else if (mt == ModelType.FLMX)
                {
                    return new ClassModel(GetSiteID);
                }
                else if (mt == ModelType.YHMX)
                {
                    return new UserModel(GetSiteID);
                }
                //else if (mt == ModelType.表单模型)
                //{
                //    return new FormModel();
                //}
                return null;

            }
        }

        public override string Permission
        {
            get
            {
                return "102";
            }
        }
        /// <summary>
        /// 获取模型ID
        /// </summary>
        private Guid ModelID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return new Guid(Request["id"]);
                }
                return Guid.Empty;
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
            ModelClass mc = bllModel.GeModelByID(ModelID);
            txtModelName.Text = mc.ModelName;
            txtTableName.Text = mc.TableName;
            txtTableName.Enabled = false;
            BindData();
            if (string.IsNullOrEmpty(mc.ListTemID.ToString()))
                mc.ListTemID = Guid.Empty;
            ListTemID.SelectedValue = mc.ListTemID.ToString();

        }

        override protected void SaveModel()
        {

            ModelClass mc = new ModelClass();
            if (ModelID != Guid.Empty)
            {
                mc = bllModel.GeModelByID(ModelID);

            }
            else
            {
                mc.ID = Guid.NewGuid();
                mc.Configs = bllModel.GetDefaultColumList();
            }

            mc.ModelName = txtModelName.Text;

            mc.ListTemID = new Guid(this.ListTemID.SelectedValue);
            if (ModelID == Guid.Empty)
            {
                if (!string.IsNullOrEmpty(txtTableName.Text.Trim()))
                {
                    mc.TableName = string.Concat("nc_", txtTableName.Text.Trim());
                    if (IsCreateTb(mc.TableName))
                    {
                        if (BLL.NewsContent.NewTb_Create(mc.TableName))
                        {
                            bllModel.AddModel(mc);
                        }
                        else
                        {
                            base.TipsAlert("数据库中 创建表失败，请联系管理员!");
                        }
                    }
                    else
                    {
                        base.TipsAlert("库中已存在此表!");
                    }
                }
                else
                {
                    mc.TableName = "newscontent";
                    bllModel.AddModel(mc);
                }
            }
            else
            {
                bllModel.Save();

            }
            Core.Utils.AppRestart();
            //base.ColseGreyBox(true);
        }
        /// <summary>
        /// 是否 允许创建 自定义扩展表
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        private bool IsCreateTb(string tbName)
        {
            bool key = false;
            if (!string.IsNullOrEmpty(tbName))
            {
                if (!BLL.NewsContent.NewTb_Exists(tbName))
                {
                    key = true;
                }
            }

            return key;
        }
    }
}