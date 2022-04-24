using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Core;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for barcode
    /// </summary>
    public class barcode : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //c为内容，t为生成类型 0为二维码，1为条码
            if (!string.IsNullOrEmpty(context.Request.QueryString["c"]) && !string.IsNullOrEmpty(context.Request.QueryString["t"]))
            {
                string UrlReferrer = Utils.GetUrlReferrer();
                if (string.IsNullOrEmpty(UrlReferrer) || Utils.IsCrossSitePost(UrlReferrer, Utils.GetHost())) //禁止跨站
                {
                    return;
                }

                string q = context.Request.Url.Query;

                System.Collections.Specialized.NameValueCollection nv = System.Web.HttpUtility.ParseQueryString(q, System.Text.Encoding.UTF8);

                string code = nv["c"];

                string t = nv["t"];

                //将图片保存到内存流中
              
                if (t == "1")
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    System.Drawing.Bitmap bitmap;
                    Code128 c128 = new Code128();
                    bitmap = c128.GetCodeImage(code, Code128.Encode.Code128C);
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    context.Response.Clear();
                    context.Response.ContentType = "image/jpeg";
                    context.Response.BinaryWrite(stream.ToArray());
                    stream.Close();
                    stream.Dispose();
                    bitmap.Dispose();
                }
                else
                {
                    //bitmap = new System.Drawing.Bitmap(270, 270);

                    //System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
                    //DotNetBarcode db = new DotNetBarcode(DotNetBarcode.Types.QRCode);
                    //db.QRWriteBar(code, 0, 0, 6, graphics);

                    //bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                    QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    qrCodeEncoder.QRCodeScale = 4;
                    qrCodeEncoder.QRCodeVersion = 8;
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                    //System.Drawing.Image image = qrCodeEncoder.Encode("4408810820 深圳－广州 小江");
                    System.Drawing.Image image = qrCodeEncoder.Encode(code);
                    

                    System.IO.MemoryStream stream = new System.IO.MemoryStream();

                    image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    context.Response.Clear();
                    context.Response.ContentType = "image/jpeg";
                    context.Response.BinaryWrite(stream.ToArray());
                    stream.Close();
                    stream.Dispose();
                    image.Dispose();
                }


                //在页面上输出
                //context.Response.Clear();
                //context.Response.ContentType = "image/jpeg";
                //context.Response.BinaryWrite(stream.ToArray());
                //stream.Close();
                //stream.Dispose();
                //bitmap.Dispose();
            }
        }
        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
