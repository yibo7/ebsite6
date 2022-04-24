﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for ValidateCode1
    /// </summary>
    public class ValidateCode : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/Jpeg";

            string checkCode = GetRandomCode(4);
            context.Session["CheckCode"] = checkCode;

            #region 设置页面不被缓存
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";
            context.Response.AppendHeader("Pragma", "No-Cache");
            #endregion

            int iwidth = (int)(checkCode.Length * 14);
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 20);
            Graphics g = Graphics.FromImage(image);
            Font f = new System.Drawing.Font("Arial ", 10);//, System.Drawing.FontStyle.Bold);
            Brush b = new System.Drawing.SolidBrush(Color.Black);
            Brush r = new System.Drawing.SolidBrush(Color.FromArgb(166, 8, 8));

            //g.FillRectangle(new System.Drawing.SolidBrush(Color.Blue),0,0,image.Width, image.Height);
            //			g.Clear(Color.AliceBlue);//背景色
            g.Clear(System.Drawing.ColorTranslator.FromHtml("#D9D9D9"));//背景色

            char[] ch = checkCode.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i] >= '0' && ch[i] <= '9')
                {
                    //数字用红色显示
                    g.DrawString(ch[i].ToString(), f, r, 3 + (i * 12), 3);
                }
                else
                {   //字母用黑色显示
                    g.DrawString(ch[i].ToString(), f, b, 3 + (i * 12), 3);
                }
            }

            //for循环用来生成一些随机的水平线
            Pen blackPen = new Pen(Color.Black, 0);
            Random rand = new Random();
            for (int i = 0; i < 2; i++)
            {
                int y = rand.Next(image.Height);
                g.DrawLine(blackPen, 0, y, image.Width, y);
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //history back 不重复 
            context.Response.Cache.SetNoStore();//这一句 		
            context.Response.ClearContent();
            context.Response.ContentType = "image/Jpeg";
            context.Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            image.Dispose();

        }


        private string CreateRandomCode(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,M,N,P,Q,R,S,T,U,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(35);
                if (temp == t)
                {
                    return CreateRandomCode(codeCount);//性能问题
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }
        private string GetRandomCode(int CodeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,M,N,P,Q,R,S,T,U,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(33);

                while (temp == t)
                {
                    t = rand.Next(33);
                }

                temp = t;
                RandomCode += allCharArray[t];
            }

            return RandomCode;
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
