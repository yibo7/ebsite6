using System;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Configs
{
    public partial class BaseConfig : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "152";
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
            throw new NotImplementedException();
        }
        override protected void SaveModel()
        {
            Configs.BaseCinfigs.ConfigsControl.Instance.FounderuID = this.FounderuID.Text;
            Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType = this.DataLayerType.Text;
            Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCms = this.ConnectionStringSysCms.Text;
            Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix = this.TablePrefix.Text;

            Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerTypeUser = DataLayerTypeUser.Text;
            Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysUser = ConnectionStringUser.Text;

            Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefixUser = TablePrefixUser.Text;

            Configs.BaseCinfigs.ConfigsControl.SaveConfig();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.FounderuID.Text = Configs.BaseCinfigs.ConfigsControl.Instance.FounderuID.ToString();
                this.DataLayerType.Text = Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType;
                this.ConnectionStringSysCms.Text =
                    Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCms;
                this.TablePrefix.Text = Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;
                DataLayerTypeUser.Text = Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerTypeUser;
                ConnectionStringUser.Text = Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysUser;

                TablePrefixUser.Text = Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefixUser;

            }
        }

        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    Configs.BaseCinfigs.ConfigsControl.Instance.FounderuID = this.FounderuID.Text;
        //    Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType = this.DataLayerType.Text;
        //    Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCms = this.ConnectionStringSysCms.Text;
        //    Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix = this.TablePrefix.Text;

        //    Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerTypeUser = DataLayerTypeUser.Text;
        //    Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysUser = ConnectionStringUser.Text;

        //    Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefixUser = TablePrefixUser.Text;

        //    Configs.BaseCinfigs.ConfigsControl.SaveConfig();
        //}
    }
}