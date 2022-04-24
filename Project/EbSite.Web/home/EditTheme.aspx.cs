using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.Web.home
{
    public partial class EditTheme : UserPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ctbTag.EndLiteral = llTagEnd;
                ctbTag.Items = string.Format("编辑样式#tg1|编辑模板#tg2");
                GetFileName();
            }
        }
        private void GetFileName()
        {
            string fn = BLL.SpaceSetting.Instance.GetThemePathByUserID(UserID);

            string CSSUrl = HttpContext.Current.Server.MapPath(IISPath+"home/themes/" + fn + "/css.css");
            txtCSS.Text = EbSite.Core.FSO.FObject.ReadFile(CSSUrl);

            string uHomeUrl = HttpContext.Current.Server.MapPath(IISPath+"home/themes/" + fn + "/uhome.aspx");
            txtMaster.Text = EbSite.Core.FSO.FObject.ReadFile(uHomeUrl);
            txtMaster.ReadOnly = true;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            GetAdd();
            base.Tips("提示", "保存成功");
        }
        protected void btnSaveApp_Click(object sender, EventArgs e)
        {
            int txtSelItemID=  GetAdd();
            string FileName = ChineseToPYAbbreviation(txtThemeName.Text) + UserID;
            string sThemeID = txtSelItemID.ToString();
            string sThemePath = FileName;
            if (!string.IsNullOrEmpty(sThemeID) && !string.IsNullOrEmpty(sThemePath))
            {
                EbSite.BLL.SpaceSetting.Instance.UpdateTheme(UserID, int.Parse(sThemeID), sThemePath);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "RefeshParent();", true);
            }
            base.Tips("提示", "保存成功");
        }
        /// <summary>
        /// btnSaveApp_Click+btnSaveApp_Click 公用添加方法
        /// </summary>
        /// <returns></returns>
        private int GetAdd()
        {
            string sSafeCoder = txtSafeCoder.Text.Trim();
            if (!BLL.User.UserIdentity.ValidateSafeCode(sSafeCoder))
            {
                base.Tips("错误提示", "所填写的验证码与所给的不符");
                return 0;
            }

            int txtSelItemID = 0;
            string FileName = ChineseToPYAbbreviation(txtThemeName.Text)+UserID;
            string url = HttpContext.Current.Server.MapPath(IISPath + "home/themes/" + FileName);

            bool key = EbSite.Core.FSO.FObject.IsExist(url, FsoMethod.Folder);//检测此文件夹是否存在

            if (key)
            {
                //加上提示
                base.Tips("错误提示", "已经存在" + FileName + "这个皮肤");
            }
            else
            {

                EbSite.Entity.SpaceThemes md = new SpaceThemes();
                md.ThemeName = txtThemeName.Text;
                md.ThemePath = FileName;
                md.Author = UserName;
                md.UserID = UserID;
                md.AddTime = DateTime.Now;
                md.ThemeClassID = 1;
                md.UserGroupID = BLL.User.UserGroupProfile.GetRoleIDByUserName(UserName); //得到用户的组ID

                txtSelItemID = BLL.SpaceThemes.Instance.Add(md);
                #region 开始写文件
                EbSite.Core.FSO.FObject.Create(url, FsoMethod.Folder);//创建文件夹
                string oldFile = HttpContext.Current.Server.MapPath(IISPath + "home/themes/" + BLL.SpaceSetting.Instance.GetThemePathByUserID(UserID));
                EbSite.Core.FSO.FObject.CopyDirectory(oldFile, url);
                //开始修改 css.css + uhome.aspx
                string CSSUrl = HttpContext.Current.Server.MapPath(IISPath + "home/themes/" + FileName + "/css.css");
                EbSite.Core.FSO.FObject.WriteFile(CSSUrl, this.txtCSS.Text, false);

                string uHomeUrl = HttpContext.Current.Server.MapPath(IISPath + "home/themes/" + FileName + "/uhome.aspx");
                EbSite.Core.FSO.FObject.WriteFile(uHomeUrl, this.txtMaster.Text, false);


                #endregion
                //缩略图如何修改
               
            }
            return txtSelItemID;
        }
        public static string getSpell(string cn)
        {
            #region
            byte[] arrCN = Encoding.Default.GetBytes(cn);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return cn;
            }
            else return cn;
            #endregion
        }

        /// <summary>
        /// 获取汉字字符串的首写英文字母
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ChineseToPYAbbreviation(string str)
        {
            char[] chars = str.ToCharArray();
            string result = "";
            if (chars.Length > 1)
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    result += getSpell(chars[i].ToString());
                }
            }
            else if (chars.Length == 1)
            {
                result = getSpell(str);
            }
            return result.ToLower();

        }
    }
}