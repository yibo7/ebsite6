using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using EbSite.Core.FSO;

namespace EbSite.Core
{
    public class  ImagesMake
    { 
        
        /// <summary>
      /// 加图片水印
      /// </summary>
      /// <param name="filename">文件名</param>
      /// <param name="watermarkFilename">水印文件名</param>
      /// <param name="watermarkStatus">图片水印位置 图片附件添加水印 0=不使用 1=左上 2=中上 3=右上 4=左中 ... 9=右下</param>
      /// <param name="quality">附件图片质量　取值范围 0-100</param>
      /// <param name="watermarkTransparency">图片水印透明度 取值范围1--10 (10为不透明)</param>
        public static bool AddImageSignPic(string picurl, string filename, string watermarkFilename, int watermarkStatus, int quality, int watermarkTransparency)
        {

            string imgpath = picurl;

            HttpWebRequest wrequest;
            HttpWebResponse wresponse;
            Stream s;
            System.Drawing.Image img;
            try
            {
                wrequest = (HttpWebRequest)HttpWebRequest.Create(imgpath);
                //wrequest.Timeout = 60000;
                //wrequest.KeepAlive = false;
                //wrequest.AllowAutoRedirect = true;

                wresponse = (HttpWebResponse)wrequest.GetResponse();
                s = wresponse.GetResponseStream();
                img = System.Drawing.Image.FromStream(s);
            }
            catch (Exception e)
            {
                return false;
                //throw new Exception(string.Concat(e.Message, "请确认此地址是否可以访问:", imgpath));
            }


            Graphics g;
            if (IsPixelFormatIndexed(img.PixelFormat))
            {
                Bitmap bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);
                using (Graphics g2 = Graphics.FromImage(bmp))
                {
                    g2.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g2.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g2.DrawImage(img, 0, 0);
                }
                g = Graphics.FromImage(bmp);
            }
            else
            {
                g = Graphics.FromImage(img);
            }

            //设置高质量插值法
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if (!FSO.FObject.IsExist(watermarkFilename, FsoMethod.File))
            {
                throw new Exception("找不到水印图片，请到系统设置里重新设置");
            }
            Image watermark = new Bitmap(watermarkFilename);

            FSO.FObject.ExistsDirectory(filename);
            if (watermark.Height >= img.Height || watermark.Width >= img.Width)
            {
                img.Save(filename);

                g.Dispose();
                img.Dispose();
                watermark.Dispose();
                if (!Equals(s, null))
                {
                    s.Close();
                    s.Dispose();
                }
                wresponse.Close();
                wrequest.Abort();

                wrequest = null;

                return true;
            }

            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();

            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            float transparency = 0.5F;
            if (watermarkTransparency >= 1 && watermarkTransparency <= 10)
            {
                transparency = (watermarkTransparency / 10.0F);
            }

            float[][] colorMatrixElements = {
                        new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                        new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                        new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                        new float[] {0.0f,  0.0f,  0.0f,  transparency, 0.0f},
                        new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                    };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            int xpos = 0;
            int ypos = 0;

            switch (watermarkStatus)
            {
                case 1:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 2:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 3:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 4:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 5:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 6:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 7:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
                case 8:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
                case 9:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
            }

            g.DrawImage(watermark, new Rectangle(xpos, ypos, watermark.Width, watermark.Height), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);
            //g.DrawImage(watermark, new System.Drawing.Rectangle(xpos, ypos, watermark.Width, watermark.Height), 0, 0, watermark.Width, watermark.Height, System.Drawing.GraphicsUnit.Pixel);

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo ici = null;
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType.IndexOf("jpeg") > -1)
                {
                    ici = codec;
                }
            }
            EncoderParameters encoderParams = new EncoderParameters();
            long[] qualityParam = new long[1];
            if (quality < 0 || quality > 100)
            {
                quality = 80;
            }
            qualityParam[0] = quality;

            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qualityParam);
            encoderParams.Param[0] = encoderParam;

            if (ici != null)
            {
                img.Save(filename, ici, encoderParams);
            }
            else
            {
                img.Save(filename);
            }

            g.Dispose();
            img.Dispose();
            watermark.Dispose();
            imageAttributes.Dispose();
            if (!Equals(s, null))
            {
                s.Close();
                s.Dispose();
            }

            wresponse.Close();

            wrequest.Abort();
            wrequest = null;
            return true;
        }


        /// <summary>
        /// 给图片加水印
        /// </summary>
        /// <param name="img"></param>
        /// <param name="filename">保存目录及文件名</param>
        /// <param name="watermarkFilename">水印图片路径</param>
        /// <param name="watermarkStatus">图片附件添加水印 0=不使用 1=左上 2=中上 3=右上 4=左中 ... 9=右下</param>
        /// <param name="quality">附件图片质量　取值范围 1是　0不是</param>
        /// <param name="watermarkTransparency">图片水印透明度 取值范围1--10 (10为不透明)</param>
        public static void AddImageSignPic(Image img, string filename, string watermarkFilename, int watermarkStatus, int quality, int watermarkTransparency)
        {
            Graphics g = Graphics.FromImage(img);
            //设置高质量插值法
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Image watermark = new Bitmap(watermarkFilename);

            if (watermark.Height >= img.Height || watermark.Width >= img.Width)
                return;

            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();

            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            float transparency = 0.5F;
            if (watermarkTransparency >= 1 && watermarkTransparency <= 10)
                transparency = (watermarkTransparency / 10.0F);


            float[][] colorMatrixElements = {
                        new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                        new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                        new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                        new float[] {0.0f,  0.0f,  0.0f,  transparency, 0.0f},
                        new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                    };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            int xpos = 0;
            int ypos = 0;

            switch (watermarkStatus)
            {
                case 1:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 2:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 3:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 4:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 5:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 6:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 7:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
                case 8:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
                case 9:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
            }

            g.DrawImage(watermark, new Rectangle(xpos, ypos, watermark.Width, watermark.Height), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo ici = null;
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType.IndexOf("jpeg") > -1)
                    ici = codec;
            }
            EncoderParameters encoderParams = new EncoderParameters();
            long[] qualityParam = new long[1];
            if (quality < 0 || quality > 100)
                quality = 80;

            qualityParam[0] = quality;

            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qualityParam);
            encoderParams.Param[0] = encoderParam;

            if (ici != null)
                img.Save(filename, ici, encoderParams);
            else
                img.Save(filename);

            g.Dispose();
            img.Dispose();
            watermark.Dispose();
            imageAttributes.Dispose();
        }



        /// <summary>
        /// 会产生graphics异常的PixelFormat
        /// </summary>
        private static PixelFormat[] indexedPixelFormats = { PixelFormat.Undefined, PixelFormat.DontCare, PixelFormat.Format16bppArgb1555, PixelFormat.Format1bppIndexed, PixelFormat.Format4bppIndexed, PixelFormat.Format8bppIndexed };

        /// <summary>
        /// 判断图片的PixelFormat 是否在 引发异常的 PixelFormat 之中
        /// 无法从带有索引像素格式的图像创建graphics对象
        /// </summary>
        /// <param name="imgPixelFormat">原图片的PixelFormat</param>
        /// <returns></returns>
        private static bool IsPixelFormatIndexed(PixelFormat imgPixelFormat)
        {
            foreach (PixelFormat pf in indexedPixelFormats)
            {
                if (pf.Equals(imgPixelFormat)) return true;
            }

            return false;
        }
        /// <summary>创建规定大小的图像    /// 源图像只能是JPG格式   
        /// </summary>   
        /// <param name="oPath">源图像绝对路径</param>   
        /// <param name="tPath">生成图像绝对路径</param>   
        /// <param name="width">生成图像的宽度</param>   
        /// <param name="height">生成图像的高度</param>   
        static public void CreateImage(string oPath, string tPath, int width, int height)
        {
            Bitmap originalBmp = new Bitmap(oPath);
            // 源图像在新图像中的位置   
            int left, top;


            if (originalBmp.Width <= width && originalBmp.Height <= height)
            {
                // 原图像的宽度和高度都小于生成的图片大小   
                left = (int)Math.Round((decimal)(width - originalBmp.Width) / 2);
                top = (int)Math.Round((decimal)(height - originalBmp.Height) / 2);


                // 最终生成的图像   
                Bitmap bmpOut = new Bitmap(width, height);
                using (Graphics graphics = Graphics.FromImage(bmpOut))
                {
                    // 设置高质量插值法   
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    // 清空画布并以白色背景色填充   
                    graphics.Clear(Color.White);
                    // 把源图画到新的画布上   
                    graphics.DrawImage(originalBmp, left, top);
                }
                bmpOut.Save(tPath);
                bmpOut.Dispose();


                return;
            }


            // 新图片的宽度和高度，如400*200的图像，想要生成160*120的图且不变形，   
            // 那么生成的图像应该是160*80，然后再把160*80的图像画到160*120的画布上   
            int newWidth, newHeight;
            if (width * originalBmp.Height < height * originalBmp.Width)
            {
                newWidth = width;
                newHeight = (int)Math.Round((decimal)originalBmp.Height * width / originalBmp.Width);
                // 缩放成宽度跟预定义的宽度相同的，即left=0，计算top   
                left = 0;
                top = (int)Math.Round((decimal)(height - newHeight) / 2);
            }
            else
            {
                newWidth = (int)Math.Round((decimal)originalBmp.Width * height / originalBmp.Height);
                newHeight = height;
                // 缩放成高度跟预定义的高度相同的，即top=0，计算left   
                left = (int)Math.Round((decimal)(width - newWidth) / 2);
                top = 0;
            }


            // 生成按比例缩放的图，如：160*80的图   
            Bitmap bmpOut2 = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(bmpOut2))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.FillRectangle(Brushes.White, 0, 0, newWidth, newHeight);
                graphics.DrawImage(originalBmp, 0, 0, newWidth, newHeight);
            }
            // 再把该图画到预先定义的宽高的画布上，如160*120   
            Bitmap lastbmp = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(lastbmp))
            {
                // 设置高质量插值法   
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // 清空画布并以白色背景色填充   
                graphics.Clear(Color.White);
                // 把源图画到新的画布上   
                graphics.DrawImage(bmpOut2, left, top);
            }
            lastbmp.Save(tPath);
            lastbmp.Dispose();
        }  

        /// <summary> 
        /// 生成缩略图 静态方法 
        /// </summary> 
        /// <param name="pathImageFrom"> 源图的路径(含文件名及扩展名) </param> 
        /// <param name="pathImageTo"> 生成的缩略图所保存的路径(含文件名及扩展名) 
        /// 注意：扩展名一定要与生成的缩略图格式相对应 </param> 
        /// <param name="width"> 欲生成的缩略图 "画布" 的宽度(像素值) </param> 
        /// <param name="height"> 欲生成的缩略图 "画布" 的高度(像素值) </param> 
        public static bool GenThumbnail(string pathImageFrom, string pathImageTo, int width, int height)
        {
            Image imageFrom = null;
            bool isok = false;
            try
            {
                imageFrom = Image.FromFile(pathImageFrom);
            }
            catch
            {
                //throw; 
            }

            if (imageFrom == null)
            {
                return false;
            }

            // 源图宽度及高度 
            int imageFromWidth = imageFrom.Width;
            int imageFromHeight = imageFrom.Height;

            // 生成的缩略图实际宽度及高度 
            int bitmapWidth = width;
            int bitmapHeight = height;

            // 生成的缩略图在上述"画布"上的位置 
            int X = 0;
            int Y = 0;

            // 根据源图及欲生成的缩略图尺寸,计算缩略图的实际尺寸及其在"画布"上的位置 
            if (bitmapHeight * imageFromWidth > bitmapWidth * imageFromHeight)
            {
                bitmapHeight = imageFromHeight * width / imageFromWidth;
                Y = (height - bitmapHeight) / 2;
            }
            else
            {
                bitmapWidth = imageFromWidth * height / imageFromHeight;
                X = (width - bitmapWidth) / 2;
            }

            // 创建画布 
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);

            // 用白色清空 
            g.Clear(Color.White);

            // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。 
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // 指定高质量、低速度呈现。 
            g.SmoothingMode = SmoothingMode.HighQuality;

            // 在指定位置并且按指定大小绘制指定的 Image 的指定部分。 
            g.DrawImage(imageFrom, new Rectangle(X, Y, bitmapWidth, bitmapHeight), new Rectangle(0, 0, imageFromWidth, imageFromHeight), GraphicsUnit.Pixel);

            try
            {
                //经测试 .jpg 格式缩略图大小与质量等最优 
                bmp.Save(pathImageTo, ImageFormat.Jpeg);
                isok =  true;
            }
            catch(Exception e)
            {
                Log.Factory.GetInstance().ErrorLog(string.Format("缩略图生成失败，源图路径:{0},缩略图路径:{1},原因:{2}", pathImageFrom, pathImageTo,e.Message));
                isok = false;
            }
            finally
            {
                //显示释放资源 
                imageFrom.Dispose();
                bmp.Dispose();
                g.Dispose();
            }
            return isok;
        } 


    }
}
