using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Base.Plugin;
using EbSite.Modules.Wenda.ModuleCore.BLL;
using EbSite.Modules.Wenda.ModuleCore.Entity;

namespace EbSite.Modules.Wenda.AdminPages.Controls.AskConfig
{
    public partial class AskConfig : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "系统配置";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("9dc9f8a4-0da5-4ee7-a5b3-c90e5ebc3d17");
            }
        }
        public override string Permission
        {
            get
            {
                return "12";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        public override int OrderID
        {
            get
            {
                return 6;
            }
        }
        protected void initConfig()
        {
            //this.drpTemIndex.DataValueField = "ID";
            this.AnswerNum.Text = ConfigControl.Instance.AnswerNum.ToString();
            this.CacheDays.Text = ConfigControl.Instance.CacheDays.ToString();
            //this.OkCount.Text = ConfigControl.Instance.OkCount.ToString();
            this.AnswerDays.Text = ConfigControl.Instance.AnswerDays.ToString();
            this.AnswerScore.Text = ConfigControl.Instance.AnswerScore.ToString();
           // this.IsCheck.Checked = ConfigControl.Instance.IsCheck;

            this.OutTimeScore.Text = ConfigControl.Instance.OutTimeScore.ToString();
            this.AskWordCount.Text = ConfigControl.Instance.AskWordCount.ToString();
            this.FavLevelScore.Text = ConfigControl.Instance.FavLevelScore.ToString();
            this.JuBaoScore.Text = ConfigControl.Instance.JuBaoScore.ToString();
            this.Days.Text = ConfigControl.Instance.Days.ToString();
            this.Score.Text = ConfigControl.Instance.Score.ToString();
            this.NiMingScore.Text = ConfigControl.Instance.NiMingScore.ToString();

            this.NiMingAnswer.Checked = ConfigControl.Instance.NiMingAnswer;

            this.IsUbb.Checked = ConfigControl.Instance.IsUbb;

            this.tbTimeJg.Text = ConfigControl.Instance.TimeInterval.ToString();

        }

        override protected void InitModifyCtr()
        {
            throw new NotImplementedException();
        }
        override protected void SaveModel()
        {
            ConfigControl.Instance.AnswerDays = int.Parse(this.AnswerDays.Text);
            ConfigControl.Instance.AnswerNum = int.Parse(this.AnswerNum.Text);
            ConfigControl.Instance.CacheDays = int.Parse(this.CacheDays.Text);
            //ConfigControl.Instance.OkCount = int.Parse(this.OkCount.Text);
            ConfigControl.Instance.AnswerScore = int.Parse(this.AnswerScore.Text);
           // ConfigControl.Instance.IsCheck = this.IsCheck.Checked;
            ConfigControl.Instance.OutTimeScore = int.Parse(this.OutTimeScore.Text);
            ConfigControl.Instance.AskWordCount = int.Parse(this.AskWordCount.Text);
            ConfigControl.Instance.FavLevelScore = int.Parse(this.FavLevelScore.Text);

            ConfigControl.Instance.JuBaoScore = int.Parse(this.JuBaoScore.Text);
            ConfigControl.Instance.Days = int.Parse(this.Days.Text);
            ConfigControl.Instance.Score = int.Parse(this.Score.Text);
            ConfigControl.Instance.NiMingScore = int.Parse(this.NiMingScore.Text);

            ConfigControl.Instance.NiMingAnswer = this.NiMingAnswer.Checked;
            ConfigControl.Instance.IsUbb = this.IsUbb.Checked;

            ConfigControl.Instance.TimeInterval =int.Parse( this.tbTimeJg.Text);

            ConfigControl.SaveConfig();
           
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.initConfig();

            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}