using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.ContentSet;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_SEO
{
    public partial class UrlReWrite : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "277";
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
        

           

            #region 电脑版页面

            ConfigsControl.Instance.IndexPath = txtIndexPath.Text;
            ConfigsControl.Instance.ListPath = txtListPath.Text;
            ConfigsControl.Instance.ContentPath = txtContentPath.Text;
            ConfigsControl.Instance.SpecialPath = txtSpecialPath.Text;
            ConfigsControl.Instance.Taglist = txtTaglist.Text;
            ConfigsControl.Instance.TagSearch = txtTagSearch.Text;

            ConfigsControl.Instance.IndexPathRw = txtIndexPathRw.Text;
            ConfigsControl.Instance.ListPathRw = txtListPathRw.Text;
            ConfigsControl.Instance.ContentPathRw = txtContentPathRw.Text;
            ConfigsControl.Instance.SpecialPathRw = txtSpecialPathRw.Text;
            ConfigsControl.Instance.TaglistRw = txtTaglistRw.Text;
            ConfigsControl.Instance.TagSearchRw = txtTagSearchRw.Text;


            ConfigsControl.Instance.Login = txtLogin.Text;
            ConfigsControl.Instance.Lostpassword = txtLostpassword.Text;
            ConfigsControl.Instance.Reg = txtReg.Text;
            ConfigsControl.Instance.Search = txtSearch.Text;
            ConfigsControl.Instance.Uhome = txtUhome.Text;
            ConfigsControl.Instance.UccIndex = txtUccIndex.Text;
            ConfigsControl.Instance.Remark = txtRemark.Text;

            ConfigsControl.Instance.LoginRw = txtLoginRw.Text;
            ConfigsControl.Instance.LostpasswordRw = txtLostpasswordRw.Text;
            ConfigsControl.Instance.RegRw = txtRegRw.Text;
            ConfigsControl.Instance.SearchRw = txtSearchRw.Text;
            ConfigsControl.Instance.UhomeRw = txtUhomeRw.Text;
            ConfigsControl.Instance.UccIndexRw = txtUccIndexRw.Text;

            //cqs2013-7-11
            ConfigsControl.Instance.Frdlink = txtFrdlink.Text;
            ConfigsControl.Instance.UserInfo = txtUserInfo.Text;
            ConfigsControl.Instance.FrdlinkPost = txtFrdlinkPost.Text;
            ConfigsControl.Instance.VotePost = txtVotePost.Text;
            ConfigsControl.Instance.VoteView = txtVoteView.Text;
            ConfigsControl.Instance.UserAlbum = txtAlbum.Text;
            ConfigsControl.Instance.Top = txtTop.Text;
            ConfigsControl.Instance.UserOnline = txtUserOnline.Text;
            ConfigsControl.Instance.LoginBind = txtLoginBind.Text;

            ConfigsControl.Instance.FrdlinkRw = txtFrdlinkRw.Text;
            ConfigsControl.Instance.UserInfoRw = txtUserInfoRw.Text;
            ConfigsControl.Instance.FrdlinkPostRw = txtFrdlinkPostRw.Text;
            ConfigsControl.Instance.VotePostRw = txtVotePostRw.Text;
            ConfigsControl.Instance.VoteViewRw = txtVoteViewRw.Text;
            ConfigsControl.Instance.UserAlbumRw = txtAlbumRw.Text;
            ConfigsControl.Instance.TopRw = txtTopRw.Text;
            ConfigsControl.Instance.UserOnlineRw = txtUserOnlineRw.Text; 
            //ConfigsControl.Instance.ContentPathRw2 = txtContentPathRw2.Text.Trim();

            ConfigsControl.Instance.LoginbindRw = txtLoginBindRw.Text;
           
            //END

            #endregion

            #region 手机版页面

            ConfigsControl.Instance.MIndexPath = txtMIndexPath.Text;
            ConfigsControl.Instance.MListPath = txtMListPath.Text;
            ConfigsControl.Instance.MContentPath = txtMContentPath.Text;
            ConfigsControl.Instance.MSpecialPath = txtMSpecialPath.Text;
            ConfigsControl.Instance.MTaglist = txtMTaglist.Text;
            ConfigsControl.Instance.MTagSearch = txtMTagSearch.Text;
            ConfigsControl.Instance.MSearch = txtMSearch.Text;
            ConfigsControl.Instance.MLogin = txtMLogin.Text;
            ConfigsControl.Instance.MLostpassword = txtMLostpassword.Text;
            ConfigsControl.Instance.MReg = txtMReg.Text;
            ConfigsControl.Instance.MUhome = txtMUhome.Text;
            ConfigsControl.Instance.MUccIndex = txtMUccIndex.Text;

            ConfigsControl.Instance.MIndexPathRw = txtMIndexPathRw.Text;
            ConfigsControl.Instance.MListPathRw = txtMListPathRw.Text;
            ConfigsControl.Instance.MContentPathRw = txtMContentPathRw.Text;
            ConfigsControl.Instance.MSpecialPathRw = txtMSpecialPathRw.Text;
            ConfigsControl.Instance.MTaglistRw = txtMTaglistRw.Text;
            ConfigsControl.Instance.MTagSearchRw = txtMTagSearchRw.Text;
            ConfigsControl.Instance.MSearchRw = txtMSearchRw.Text;

            ConfigsControl.Instance.MLoginRw = txtMLoginRw.Text;
            ConfigsControl.Instance.MLostpasswordRw = txtMLostpasswordRw.Text;
            ConfigsControl.Instance.MRegRw = txtMRegRw.Text;
            ConfigsControl.Instance.MUhomeRw = txtMUhomeRw.Text;
            ConfigsControl.Instance.MUccIndexRw = txtMUccIndexRw.Text;
            ConfigsControl.Instance.MPath = txtMPath.Text;
            //ConfigsControl.Instance.IsNoMobile = cbIsMobileSingSize.Checked;

            ConfigsControl.Instance.SiteModule = int.Parse(rblSiteModule.SelectedValue) ;


            #endregion

            //模块重写目录 和 手机目录或子域 不能相同
           if (Base.Configs.SysConfigs.ConfigsControl.Instance.UserPath.Trim() == ConfigsControl.Instance.MPath.Trim()+"/")
           {
               base.TipsAlert("模块重写目录和手机目录或子域不能相同！");
           }
           else
           {
               ConfigsControl.SaveConfig();
               EbSite.Base.AppStartInit.UpdateInitJs();
               Core.Utils.AppRestart();
           }



            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                #region 电脑版页面
                txtIndexPath.Text = ConfigsControl.Instance.IndexPath;
                txtListPath.Text = ConfigsControl.Instance.ListPath;
                txtContentPath.Text = ConfigsControl.Instance.ContentPath;
                txtSpecialPath.Text = ConfigsControl.Instance.SpecialPath;
                txtTaglist.Text = ConfigsControl.Instance.Taglist;
                txtTagSearch.Text = ConfigsControl.Instance.TagSearch;
                txtLogin.Text = ConfigsControl.Instance.Login;
                txtLostpassword.Text = ConfigsControl.Instance.Lostpassword;
                txtReg.Text = ConfigsControl.Instance.Reg;
                txtSearch.Text = ConfigsControl.Instance.Search;
                txtUhome.Text = ConfigsControl.Instance.Uhome;
                txtUccIndex.Text = ConfigsControl.Instance.UccIndex;
                txtRemark.Text = ConfigsControl.Instance.Remark;
                txtCusttomSearch.Text = ConfigsControl.Instance.CustomSearch;
                txtDelivery.Text = ConfigsControl.Instance.Delivery;
                txtPayment.Text = ConfigsControl.Instance.Payment;

                txtIndexPathRw.Text = ConfigsControl.Instance.IndexPathRw;
                txtListPathRw.Text = ConfigsControl.Instance.ListPathRw;
                txtContentPathRw.Text = ConfigsControl.Instance.ContentPathRw;
                txtSpecialPathRw.Text = ConfigsControl.Instance.SpecialPathRw;
                txtTaglistRw.Text = ConfigsControl.Instance.TaglistRw;
                txtTagSearchRw.Text = ConfigsControl.Instance.TagSearchRw;
                txtLoginRw.Text = ConfigsControl.Instance.LoginRw;
                txtLostpasswordRw.Text = ConfigsControl.Instance.LostpasswordRw;
                txtRegRw.Text = ConfigsControl.Instance.RegRw;
                txtSearchRw.Text = ConfigsControl.Instance.SearchRw;
                txtUhomeRw.Text = ConfigsControl.Instance.UhomeRw;
                txtUccIndexRw.Text = ConfigsControl.Instance.UccIndexRw;
                txtCusttomSearchRw.Text = ConfigsControl.Instance.CustomSearchRw;

                txtDeliveryRw.Text = ConfigsControl.Instance.DeliveryRw;
                txtPaymentRw.Text = ConfigsControl.Instance.PaymentRw;



                //cqs2013-7-11
                txtFrdlink.Text = ConfigsControl.Instance.Frdlink;
                txtUserInfo.Text = ConfigsControl.Instance.UserInfo;
                txtFrdlinkPost.Text = ConfigsControl.Instance.FrdlinkPost;
                txtVotePost.Text = ConfigsControl.Instance.VotePost;
                txtVoteView.Text = ConfigsControl.Instance.VoteView;
                txtAlbum.Text = ConfigsControl.Instance.UserAlbum;
                txtTop.Text = ConfigsControl.Instance.Top;
                txtUserOnline.Text = ConfigsControl.Instance.UserOnline;
                txtLoginBind.Text = ConfigsControl.Instance.LoginBind;

                txtFrdlinkRw.Text = ConfigsControl.Instance.FrdlinkRw;
                txtUserInfoRw.Text = ConfigsControl.Instance.UserInfoRw;
                txtFrdlinkPostRw.Text = ConfigsControl.Instance.FrdlinkPostRw;
                txtVotePostRw.Text = ConfigsControl.Instance.VotePostRw;
                txtVoteViewRw.Text = ConfigsControl.Instance.VoteViewRw;
                txtAlbumRw.Text = ConfigsControl.Instance.UserAlbumRw;
                txtTopRw.Text = ConfigsControl.Instance.TopRw;
                txtUserOnlineRw.Text = ConfigsControl.Instance.UserOnlineRw;
                txtLoginBindRw.Text = ConfigsControl.Instance.LoginbindRw;

                //txtContentPathRw2.Text = ConfigsControl.Instance.ContentPathRw2;
                //txtContentPath2.Text = ConfigsControl.Instance.ContentPath;

                //END

                #endregion

                #region 手机版
                txtMIndexPath.Text = ConfigsControl.Instance.MIndexPath;
                txtMListPath.Text = ConfigsControl.Instance.MListPath;
                txtMContentPath.Text = ConfigsControl.Instance.MContentPath;
                txtMSpecialPath.Text = ConfigsControl.Instance.MSpecialPath;
                txtMTaglist.Text = ConfigsControl.Instance.MTaglist;
                txtMTagSearch.Text = ConfigsControl.Instance.MTagSearch;
                txtMSearch.Text = ConfigsControl.Instance.MSearch;

                txtMLogin.Text = ConfigsControl.Instance.MLogin;
                txtMLostpassword.Text = ConfigsControl.Instance.MLostpassword;
                txtMReg.Text = ConfigsControl.Instance.MReg;
                txtMUhome.Text = ConfigsControl.Instance.MUhome;
                txtMUccIndex.Text = ConfigsControl.Instance.MUccIndex;


                txtMIndexPathRw.Text = ConfigsControl.Instance.MIndexPathRw;
                txtMListPathRw.Text = ConfigsControl.Instance.MListPathRw;
                txtMContentPathRw.Text = ConfigsControl.Instance.MContentPathRw;
                txtMSpecialPathRw.Text = ConfigsControl.Instance.MSpecialPathRw;
                txtMTaglistRw.Text = ConfigsControl.Instance.MTaglistRw;
                txtMTagSearchRw.Text = ConfigsControl.Instance.MTagSearchRw;
                txtMSearchRw.Text = ConfigsControl.Instance.MSearchRw;

                txtMLoginRw.Text = ConfigsControl.Instance.MLoginRw;
                txtMLostpasswordRw.Text = ConfigsControl.Instance.MLostpasswordRw;
                txtMRegRw.Text = ConfigsControl.Instance.MRegRw;
                txtMUhomeRw.Text = ConfigsControl.Instance.MUhomeRw;
                txtMUccIndexRw.Text = ConfigsControl.Instance.MUccIndexRw;

                txtMPath.Text = ConfigsControl.Instance.MPath;
                //cbIsMobileSingSize.Checked = ConfigsControl.Instance.IsNoMobile;

                rblSiteModule.SelectedValue = ConfigsControl.Instance.SiteModule.ToString();

                #endregion


            }
        }

    }
}