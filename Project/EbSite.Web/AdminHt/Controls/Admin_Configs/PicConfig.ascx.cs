using System;
using EbSite.Base.Configs.PicConfigs;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Configs
{
    public partial class PicConfig : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "154";
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
            ConfigsControl.Instance.OpenWatermark = int.Parse(this.OpenWatermark.SelectedValue);
            ConfigsControl.Instance.PicPath = PicPath.Text;
            ConfigsControl.Instance.WatermarkPlace = WatermarkPlace;
            //ConfigsControl.Instance.OpenMiniature = (OpenMiniature.SelectedValue=="0"?false:true);
            //ConfigsControl.Instance.MiniatureHeight = int.Parse(MiniatureHeight.Text);
            //ConfigsControl.Instance.MiniatureWidth = int.Parse(MiniatureWidth.Text);


            //ConfigsControl.Instance.MidiatureHeight = int.Parse(MidiatureHeight.Text);
            //ConfigsControl.Instance.MidiatureWidth = int.Parse(MidiatureWidth.Text);

            //ConfigsControl.Instance.MaxiatureHeight = int.Parse(MaxiatureHeight.Text);
            //ConfigsControl.Instance.MaxiatureWidth = int.Parse(MaxiatureWidth.Text);




            ConfigsControl.Instance.Watermarktransparency = int.Parse(Watermarktransparency.Text);
            ConfigsControl.Instance.Imgquality = int.Parse(Imgquality.Text);
            //ConfigsControl.Instance.DYCImgSize = dycImgSize.Text.Trim();



            ConfigsControl.SaveConfig();
        }

        private int WatermarkPlace
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["rdwp"]))
                {
                  return  int.Parse(Request["rdwp"]);
                }
                return 1;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.OpenWatermark.SelectedValue = ConfigsControl.Instance.OpenWatermark.ToString();
                this.PicPath.Text = ConfigsControl.Instance.PicPath;
                ;
                //this.OpenMiniature.SelectedValue = ConfigsControl.Instance.OpenMiniature?"1":"0";
                //this.MiniatureHeight.Text = ConfigsControl.Instance.MiniatureHeight.ToString();
                //this.MiniatureWidth.Text = ConfigsControl.Instance.MiniatureWidth.ToString();


                //this.MidiatureHeight.Text = ConfigsControl.Instance.MidiatureHeight.ToString();
                //this.MidiatureWidth.Text = ConfigsControl.Instance.MidiatureWidth.ToString();

                //this.MaxiatureHeight.Text = ConfigsControl.Instance.MaxiatureHeight.ToString();
                //this.MaxiatureWidth.Text = ConfigsControl.Instance.MaxiatureWidth.ToString();


                Watermarktransparency.Text = ConfigsControl.Instance.Watermarktransparency.ToString();
                Imgquality.Text = ConfigsControl.Instance.Imgquality.ToString();

                //dycImgSize.Text = ConfigsControl.Instance.DYCImgSize;

                LoadPosition(ConfigsControl.Instance.WatermarkPlace);
            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    ConfigsControl.Instance.OpenWatermark = int.Parse(this.OpenWatermark.SelectedValue);
        //    ConfigsControl.Instance.PicPath = PicPath.Text;
        //    ConfigsControl.Instance.WatermarkPlace = WatermarkPlace;
        //    ConfigsControl.Instance.OpenMiniature = OpenMiniature.SelectedValue;
        //    ConfigsControl.Instance.MiniatureHeight = int.Parse(MiniatureHeight.Text);
        //    ConfigsControl.Instance.MiniatureWidth = int.Parse(MiniatureWidth.Text);

        //    ConfigsControl.Instance.Watermarktransparency =  int.Parse(Watermarktransparency.Text);
        //    ConfigsControl.Instance.Imgquality = int.Parse(Imgquality.Text);


        //    ConfigsControl.SaveConfig();
        //}
        public void LoadPosition(int selectid)
        {
            #region 加载水印设置界面

            llPosition.Text = string.Format("<table width=\"256\" height=\"207\" border=\"0\" background=\"{0}images/markbj.jpg\">",Base.AppStartInit.IISPath);
            for (int i = 1; i < 10; i++)
            {
                if (i % 3 == 1)
                    llPosition.Text += "<tr>";
                llPosition.Text += (selectid == i ?
                    "<td width=\"33%\" align=\"center\" style=\"vertical-align:middle; text-align:center\"><input type=\"radio\" id=\"rdwp\" name=\"rdwp\" value=\"" + i + "\" checked><b>" + i + "</b></td>" :
                    "<td width=\"33%\" align=\"center\" style=\"vertical-align:middle; text-align:center\"><input type=\"radio\" id=\"rdwp\" name=\"rdwp\" value=\"" + i + "\" ><b>" + i + "</b></td>");
                if (i % 3 == 0)
                    llPosition.Text += "</tr>";
            }

            llPosition.Text += "</table>";
            

            #endregion
        }

    }
}