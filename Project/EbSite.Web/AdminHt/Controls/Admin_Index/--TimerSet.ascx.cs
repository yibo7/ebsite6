//using System;

//namespace EbSite.Web.AdminHt.Controls.Admin_Index
//{
//    public partial class TimerSet : Base.ControlPage.UserControlBaseSave
//    {
//        public override string Permission
//        {
//            get
//            {
//                return "52";
//            }
//        }
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if(!IsPostBack)
//            {
//                //txtTimeLen.Text = Base.Configs.SchedulTask.ConfigsControl.Instance.Index_TimerLength.ToString();
//                //cbIsOpenIndexTimerUpdate.Checked = Base.Configs.SchedulTask.ConfigsControl.Instance.IsOpenIndexTimerUpdate;
//            }
//        }
       
//        override protected string KeyColumnName
//        {
//            get
//            {
//                throw new NotImplementedException();
//            }
//        }
//        override protected void InitModifyCtr()
//        {
//            throw new NotImplementedException();
//        }
//        override protected void SaveModel() 
//        {
//            //Base.Configs.SchedulTask.ConfigsControl.Instance.Index_TimerLength = int.Parse(txtTimeLen.Text);
//            //Base.Configs.SchedulTask.ConfigsControl.Instance.IsOpenIndexTimerUpdate = cbIsOpenIndexTimerUpdate.Checked;
//            Base.Configs.SchedulTask.ConfigsControl.SaveConfig();
//            //重新启动网站
//           EbSite.Base.Host.CacheApp.Clear();// EbSite.Core.CacheManager.RemoveAllCache();
//            //Core.Timers.TimersMakeIndex.Dispose();
//        }
//    }
//}