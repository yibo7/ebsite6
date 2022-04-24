using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.ControlPage;
using EbSite.Base.EntityAPI;
using EbSite.BLL;
using EbSite.BLL.ModelBll;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Model
{
    public class EditFiledsBase : UserControlListBase
    {
        #region UI控件
        protected global::System.Web.UI.HtmlControls.HtmlGenericControl divsteptips;
        /// <summary>
        /// ltModelName 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::System.Web.UI.WebControls.Literal ltModelName;

        /// <summary>
        /// bntSaveFileds 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::System.Web.UI.WebControls.Button bntSaveFileds;

        ///// <summary>
        ///// ctbTag 控件。
        ///// </summary>
        ///// <remarks>
        ///// 自动生成的字段。
        ///// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        ///// </remarks>
        //protected global::EbSite.Control.CustomTagsBox ctbTag;

        /// <summary>
        /// drpFiledType 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::EbSite.Control.DropDownList drpFiledType;

        protected global::EbSite.Control.DropDownList drpFiledDataType;
        

        /// <summary>
        /// txtFiledTitle 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::EbSite.Control.TextBox txtFiledTitle;
        protected global::EbSite.Control.TextBoxVl txtDataTypeLen;

        /// <summary>
        /// drpCtrType 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::EbSite.Control.DropDownList drpCtrType;

        /// <summary>
        /// drpFiles 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::System.Web.UI.WebControls.DropDownList drpFiles;

        /// <summary>
        /// txtFileName 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::EbSite.Control.TextBox txtFileName;

        /// <summary>
        /// txtPlaceHolderID 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::EbSite.Control.TextBox txtPlaceHolderID;

        /// <summary>
        /// cbUserDis 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::EbSite.Control.CheckBox cbUserDis;

        /// <summary>
        /// hfModifyKey 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::System.Web.UI.WebControls.HiddenField hfModifyKey;

        /// <summary>
        /// llTagEnd 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::System.Web.UI.WebControls.Literal llTagEnd;
        #endregion

        #region 权限

        public override string Permission
        {
            get
            {
                return "103";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "104";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "209";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "210";
            }
        }
        //override protected string AddUrl
        //{
        //    get
        //    {
        //        return "t=0";
        //    }
        //}

        #endregion

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
                else if (mt == ModelType.BDMX)
                {
                    return new FormModel(GetSiteID);
                }
                return null;

            }
        }

        protected string GetCtrName(object id)
        {
            Guid gid = new Guid(id.ToString());
            EbSite.Entity.WidgetShow md = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetEntityByID(gid);
            if (md != null)
            {
                return md.Title;
            }
            return "<font color=red>还没选择控件</font>";
        }


        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }

        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return mc.GetUsedFileds();

        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {

            //ColumFiledConfigs cfc =  mc.DeleteFiled(iID.ToString());
            bllModel.DeleteFiled(mc, iID.ToString());
        }
        private ModelClass mc
        {
            get
            {
                return bllModel.GeModelByID(ModelID);
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

        public virtual void OnSaved(ModelClass mc)
        {

        }
        protected void bntSaveFileds_Click(object sender, EventArgs e)
        {
            if (ModelID != Guid.Empty)
            {

                ColumFiledConfigs cfc = new ColumFiledConfigs();
               
                cfc.IsOutFiled = (drpFiledType.SelectedValue == "1");
                cfc.ColumShowName = txtFiledTitle.Text.Trim();

                cfc.FieldControlTypeID = new Guid(drpCtrType.SelectedValue);

                if (!cfc.IsOutFiled) //自带字段
                {
                    cfc.ColumFiledName = drpFiles.SelectedValue;


                }
                else //自定义字段
                {
                    cfc.ColumFiledName = txtFileName.Text.Trim();
                    cfc.DataType = int.Parse(drpFiledDataType.SelectedValue);
                    cfc.DataTypeLen = Core.Utils.StrToInt(txtDataTypeLen.Text,0);

                }

                cfc.PlaceHolderID = txtPlaceHolderID.Text.Trim();

                //cfc.IsShowAdmin = true;
                cfc.IsShowUser = cbUserDis.Checked;
                //cfc.IsReadOnly = drpCtrType.Enabled;

                
                if (string.IsNullOrEmpty(hfModifyKey.Value))//新加字段
                {
                    if (!string.IsNullOrEmpty(cfc.ColumFiledName))
                    {
                        if (!mc.IsHaveFiled(cfc.ColumFiledName))
                        {
                            mc.AddFiled(cfc);
                        }
                        else
                        {
                            Tips("不能使用同名字段", "模型字段已经存在同名字段，请换一个字段名称再操作！");
                            return;
                        }


                    }
                    else
                    {
                        Tips("出错了", "没有选择字段或没有输入字段名称！");
                        return;
                    }


                }
                else //修改字段
                {
                    cfc.ColumFiledName = hfModifyKey.Value.Trim();
                    mc.UpdateFiled(cfc);
                   
                }
                OnSaved(mc);
                bllModel.Save(mc, cfc);
                
                base.gdList_Bind();

            }
        }

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    //ctbTag.EndLiteral = llTagEnd;
        //    //ctbTag.Items = "字段参数#tg1|其他参数#tg2";
        //    //if (!IsPostBack)
        //    //{
        //    //    BindData();

        //    //}


        //}
        protected void BindData()
        {
            ModelClass mc = bllModel.GeModelByID(ModelID);
            drpFiles.DataTextField = "ColumFiledName";
            drpFiles.DataValueField = "ColumFiledName";//ID
            drpFiles.DataSource = mc.GetUnUsedFileds();
            drpFiles.DataBind();

            ltModelName.Text = mc.ModelName;

            drpCtrType.DataTextField = "Title";
            drpCtrType.DataValueField = "DataID";//ID
            drpCtrType.DataSource = Base.ExtWidgets.ModelCtr.DataBLL.Instance.GetListForUser();
            drpCtrType.DataBind();

            drpFiledDataType.DataTextField = "Text";
            drpFiledDataType.DataValueField = "value";//ID
            drpFiledDataType.DataSource = Base.EntityAPI.DataFiled.GetEDataFiledTypes();
            drpFiledDataType.DataBind();

            

            divsteptips.InnerHtml = "管理模型字段- " + mc.ModelName + "[<a onclick=\"javascript:history.go(-1);\">返回</a>]";
        }
    }
}