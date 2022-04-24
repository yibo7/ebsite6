
using EbSite.Base.Configs.ConfigsBase;

namespace EbSite.Base.Configs.PicConfigs
{
    /// <summary>
    /// 生成静态页面 配置文件实体类
    /// </summary>
    public class ConfigsInfo : IConfigInfo
    {
      
        private int _OpenWatermark;  //是否开启水印/缩图功能
        //private string _WatermarkType; //水印类型
        private string _PicPath;  //水印图片地址
        //private string _PicArea = "100|100"; //水印图片高、宽
        private int _WatermarkPlace  = 1; //水印位置
        private bool _OpenMiniature; //是否开启缩图功能
        private int _MiniatureWidth = 80; //缩图的宽
        private int _MiniatureHeight = 80;  //缩图的高



        private int _MidiatureWidth = 160; //缩图的宽
        private int _MidiatureHeight = 160;  //缩图的高


        private int _MaxiatureWidth = 320; //缩图的宽
        private int _MaxiatureHeight = 320;  //缩图的高

        private int _Imgquality = 100;
        private int _Watermarktransparency = 10;

        /// <summary>
        /// 上传图片质量 0-100
        /// </summary>
        public int Imgquality
        {
            get
            {
                return _Imgquality;
            }
            set
            {
                _Imgquality = value;
            }
        }

        /// <summary>
        /// 水印图透明度0-10
        /// </summary>
        public int Watermarktransparency
        {
            get
            {
                return _Watermarktransparency;
            }
            set
            {
                _Watermarktransparency = value;
            }
        }
        /// <summary>
        /// 是否开启水印/缩图功能 0 不开启，1开户
        /// </summary>
        public int OpenWatermark
        {
            get
            {
                return _OpenWatermark;
            }
            set
            {
                _OpenWatermark = value;
            }
        }
        /// <summary>
        /// 水印类型
        /// </summary>
        //public string WatermarkType
        //{
        //    get
        //    {
        //        return _WatermarkType;
        //    }
        //    set
        //    {
        //        _WatermarkType = value;
        //    }
        //}
        /// <summary>
        /// 水印图片地址
        /// </summary>
        public string PicPath
        {
            get
            {
                return _PicPath;
            }
            set
            {
                _PicPath = value;
            }
        }
        /// <summary>
        /// 水印图片高、宽
        /// </summary>
        //public string PicArea
        //{
        //    get
        //    {
        //        return _PicArea;
        //    }
        //    set
        //    {
        //        _PicArea = value;
        //    }
        //}
        /// <summary>
        /// 图片水印位置 图片附件添加水印 0=不使用 1=左上 2=中上 3=右上 4=左中 ... 9=右下
        /// </summary>
        public int WatermarkPlace
        {
            get
            {
                return _WatermarkPlace;
            }
            set
            {
                _WatermarkPlace = value;
            }
        }
        ///// <summary>
        ///// 是否开启缩图功能
        ///// </summary>
        //public bool OpenMiniature
        //{
        //    get
        //    {
        //        return _OpenMiniature;
        //    }
        //    set
        //    {
        //        _OpenMiniature = value;
        //    }
        //}
        ///// <summary>
        ///// 动态缩略图尺寸允许设置
        ///// </summary>
        //public string DYCImgSize { get; set; }
        ///// <summary>
        ///// 缩图的宽
        ///// </summary>
        //public int MiniatureWidth
        //{
        //    get
        //    {
        //        return _MiniatureWidth;
        //    }
        //    set
        //    {
        //        _MiniatureWidth = value;
        //    }
        //}
        ///// <summary>
        ///// 缩略图的高
        ///// </summary>
        //public int MiniatureHeight
        //{
        //    get
        //    {
        //        return _MiniatureHeight;
        //    }
        //    set
        //    {
        //        _MiniatureHeight = value;
        //    }
        //}


        ///// <summary>
        ///// 中缩图的宽
        ///// </summary>
        //public int MidiatureWidth
        //{
        //    get
        //    {
        //        return _MidiatureWidth;
        //    }
        //    set
        //    {
        //        _MidiatureWidth = value;
        //    }
        //}
        ///// <summary>
        ///// 中缩略图的高
        ///// </summary>
        //public int MidiatureHeight
        //{
        //    get
        //    {
        //        return _MidiatureHeight;
        //    }
        //    set
        //    {
        //        _MidiatureHeight = value;
        //    }
        //}


        ///// <summary>
        ///// 大缩图的宽
        ///// </summary>
        //public int MaxiatureWidth
        //{
        //    get
        //    {
        //        return _MaxiatureWidth;
        //    }
        //    set
        //    {
        //        _MaxiatureWidth = value;
        //    }
        //}
        ///// <summary>
        ///// 大缩略图的高
        ///// </summary>
        //public int MaxiatureHeight
        //{
        //    get
        //    {
        //        return _MaxiatureHeight;
        //    }
        //    set
        //    {
        //        _MaxiatureHeight = value;
        //    }
        //}
    }
}
