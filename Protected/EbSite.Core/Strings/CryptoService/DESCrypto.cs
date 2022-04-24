using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using EbSite.Core.Strings;

namespace EbSite.Core
{
    /// <summary>
    /// DESCrypto : 采用DES对称加密方式的加密/解密。
    /// </summary>
    public class DESCrypto
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DESCrypto()
        {
        }


        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        #region 常用8位密钥DES加密解密字符串

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串,失败返回源串</returns>
        public static string Encode(string encryptString, string encryptKey)
        {
            encryptKey = Utils.GetSubString(encryptKey, 8, "");
            encryptKey = encryptKey.PadRight(8, ' ');
            byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
            byte[] rgbIV = Keys;
            byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());

        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串,失败返源串</returns>
        public static string Decode(string decryptString, string decryptKey)
        {
            decryptKey = GetString.GetSubString(decryptKey, 8, "");
            decryptKey = decryptKey.PadRight(8, ' ');
            byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
            byte[] rgbIV = Keys;
            byte[] inputByteArray = Convert.FromBase64String(decryptString);
            DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();

            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(mStream.ToArray());

        }

        #endregion


        #region 加密方法
        /// <summary>
		/// 加密方法
		/// </summary>
		/// <param name="inputByteArray">要加密的byte[]内容</param>
		/// <param name="sKey">加密使用的密钥</param>
		/// <param name="sIV">加密使用的密钥初始化向量</param>
		/// <returns>string</returns>
 		public string EncryptString(byte[] inputByteArray, string sKey, string sIV)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            //建立加密对象的密钥和偏移量  
            des.Key = Encoding.UTF8.GetBytes(sKey);
            des.IV = Encoding.UTF8.GetBytes(sKey);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            string strResult = Convert.ToBase64String(ms.ToArray());

            return strResult;
        }


        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="pToEncrypt">要加密的文本内容</param>
        /// <param name="sKey">加密使用的密钥</param>
        /// <param name="sIV">加密使用的密钥初始化向量</param>
        /// <returns>string</returns>
        public string EncryptString(string pToEncrypt, string sKey, string sIV)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //把字符串放到byte数组中  
            byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);

            //建立加密对象的密钥和偏移量  
            des.Key = Encoding.UTF8.GetBytes(sKey);
            des.IV = Encoding.UTF8.GetBytes(sIV);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            string strResult = Convert.ToBase64String(ms.ToArray());

            return strResult;
        }


        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="inputByteArray">要加密的byte[]内容</param>
        /// <param name="sKey">加密使用的密钥</param>
        /// <param name="sIV">加密使用的密钥初始化向量</param>
        /// <returns>byte[]</returns>
        public byte[] EncryptBytes(byte[] inputByteArray, string sKey, string sIV)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            //建立加密对象的密钥和偏移量  
            des.Key = Encoding.UTF8.GetBytes(sKey);
            des.IV = Encoding.UTF8.GetBytes(sKey);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            return ms.ToArray();
        }


        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="pToEncrypt">要加密的文本内容</param>
        /// <param name="sKey">加密使用的密钥</param>
        /// <param name="sIV">加密使用的密钥初始化向量</param>
        /// <returns>byte[]</returns>
        public byte[] EncryptBytes(string pToEncrypt, string sKey, string sIV)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //把字符串放到byte数组中  
            byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);

            //建立加密对象的密钥和偏移量  
            des.Key = Encoding.UTF8.GetBytes(sKey);
            des.IV = Encoding.UTF8.GetBytes(sIV);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            return ms.ToArray();
        }

        #endregion



        #region 解密方法
        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="pToDecrypt">要解密的文本内容</param>
        /// <param name="sKey">解密使用的密钥</param>
        /// <returns>string</returns>
        public string DecryptString(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();


            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);

            //建立加密对象的密钥和偏移量
            des.Key = Encoding.UTF8.GetBytes(sKey);
            des.IV = Encoding.UTF8.GetBytes(sKey);


            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  streamn
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            ms.Close();
            cs.Close();


            return Encoding.UTF8.GetString(ms.ToArray());
        }


        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="pToDecrypt">要解密的文本内容</param>
        /// <param name="sKey">解密使用的密钥</param>
        /// <param name="sIV">解密使用的密钥初始化向量</param>
        /// <returns>string</returns>
        public string DecryptString(string pToDecrypt, string sKey, string sIV)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();


            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);


            //建立加密对象的密钥和偏移量，此值重要，不能修改
            des.Key = Encoding.UTF8.GetBytes(sKey);
            des.IV = Encoding.UTF8.GetBytes(sIV);


            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  streamn
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            ms.Close();
            cs.Close();


            return Encoding.UTF8.GetString(ms.ToArray());
        }


        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="pToDecrypt">要解密的文本内容</param>
        /// <param name="sKey">解密使用的密钥</param>
        /// <returns>byte[]</returns>
        public byte[] DecryptBytes(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();


            byte[] inputByteArray = Encoding.UTF8.GetBytes(pToDecrypt);

            //建立加密对象的密钥和偏移量
            des.Key = Encoding.UTF8.GetBytes(sKey);
            des.IV = Encoding.UTF8.GetBytes(sKey);


            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  streamn
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            ms.Close();
            cs.Close();

            return ms.ToArray();
        }

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="pToDecrypt">要解密的文本内容</param>
        /// <param name="sKey">解密使用的密钥</param>
        /// <param name="sIV">解密使用的密钥初始化向量</param>
        /// <returns>byte[]</returns>
        public byte[] DecryptBytes(string pToDecrypt, string sKey, string sIV)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();


            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);


            //建立加密对象的密钥和偏移量，此值重要，不能修改
            des.Key = Encoding.UTF8.GetBytes(sKey);
            des.IV = Encoding.UTF8.GetBytes(sIV);


            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  streamn
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            ms.Close();
            cs.Close();

            return ms.ToArray();
        }
        #endregion

    }
}
