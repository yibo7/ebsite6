using System;
using System.Web.UI.WebControls;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Entity;
using EbSite.Web.AdminHt.Controls.Admin_Component;

namespace EbSite.Web.AdminHt.Controls.Admin_Plugins
{
    public partial class PluginSetting : PluginSettingsBase
    {
        override public ManagerExtBase ExtManager 
        { 
            get
            {
                 return EbSite.Base.Plugin.PluginManager.Instance;
            } 
        }

       
        private string gDataID
        {
            get
            {
                return Request["id"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            //PluginInfo md = BLL.Plugins.Plugin.Instance.GetEntity(gDataID);
            
            //----------------------------------------------------------------
            //_extensionName = this.ID;//此处ID在路由载入时读取,请参考路由
            _extensionName = gDataID;
            _settings = ExtManager.GetSettings(_extensionName);

            
            //--cqs---
            lbPluginName.Text = _settings.Name;// md.Name;
            lbTypeName.Text = _extensionName;// md.TypeName;

            lbHelp.Text = _settings.Help;

            BuilBntText(ExtManager.GetManagedExtension(_extensionName).Enabled);
            //BuilBntText(md.Enabled);
            //--end--

            //是否显示删除按钮
            GenerateDeleteButton = _settings.ShowDelete;
            //是否显示修改按钮
            GenerateEditButton = _settings.ShowEdit;

            if (_settings.ShowAdd) //显示修改或添加参数选项
                ExtManager.AddCtrToPH(_settings, phAddForm);

            if (!Page.IsPostBack)
            {
                //数据初始化
                if (_settings.IsScalar)
                {
                    rzInfo.Visible = true;
                    ExtManager.BindScalarToPh(_settings.Parameters, phAddForm, 0);
                }
                else
                {
                    //生成表头
                    CreateTemplatedGridView();
                    //绑定列表数据
                    BindGrid();
                    

                }
            }



            btnAdd.Click += new EventHandler(btnAdd_Click);
            //ctbTag.EndLiteral = llTagEnd;
            //ctbTag.Items = string.Format("插件设置#tg1|数据列表#tg2|使用帮助#tg3");
            if (_settings.IsScalar)
            {
                btnAdd.Text = " 保 存 ";//Resources.labels.save;
            }
            else
            {
                if (_settings.ShowAdd)
                {
                    grid.RowEditing += new GridViewEditEventHandler(grid_RowEditing);
                    //grid.RowUpdating += new GridViewUpdateEventHandler(grid_RowUpdating);
                    //grid.RowCancelingEdit += delegate { Response.Redirect(Request.RawUrl); };
                    grid.RowDeleting += new GridViewDeleteEventHandler(grid_RowDeleting);
                    btnAdd.Text = " 添 加 ";
                }
                else
                    btnAdd.Visible = false;
            }
            if (iModifyRowIndex > -1)
            {
                //_settings.Parameters
                ExtManager.BindScalarToPh(_settings.Parameters, phAddForm, iModifyRowIndex);//[iModifyID]
                btnAdd.Text = " 修 改 ";
                lbAddLink.Text = string.Format("<a href='?t=1&ext={0}' >返回添加</a>", Request["ext"]);
            }
        }
        public override string Permission
        {
            get
            {
                return "138";
            }
        }
    
        private void BuilBntText(bool Enabled)
        {
            if (Enabled)
            {
                bntEnabledPlugin.Text = " 禁 用 ";
                bntDelPlugin.Enabled = false;//启用状态下不能删除插件
            }
            else
            {
                bntEnabledPlugin.Text = " 启 用 ";
                bntDelPlugin.Enabled = true;//启用状态下不能删除插件
                
            }
        }
        protected void bntEnabledPlugin_OnClick(object sender, EventArgs e)
        {
            //PluginInfo md = BLL.Plugins.Plugin.Instance.GetEntity(gDataID);

            if (!bntDelPlugin.Enabled)
            {
                
                //BLL.Plugins.Plugin.Instance.DisableProvider(lbTypeName.Text);
                ExtManager.ChangeStatus(lbTypeName.Text, false);
                BuilBntText(false);
            }
            else
            {
                //BLL.Plugins.Plugin.Instance.EnableProvider(lbTypeName.Text);
                ExtManager.ChangeStatus(lbTypeName.Text, true);
                BuilBntText(true);
            }
            
            
        }
        protected void bntDelPlugin_OnClick(object sender, EventArgs e)
        {
            //BLL.Plugins.Plugin.Instance.DeletePlugin(gDataID);
            
            //base.ColseGreyBox(true);
        }


    }
}

 