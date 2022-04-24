using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace EbSite.Core.Strings
{
    public class StringEncrypt
    {
        /// <summary>
        /// 对字符串进行适应 ServU 的 MD5 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string strServUPWD(string str)
        {
            string strResult = "";
            strResult = GetString.RandomSTR(2);
            str = strResult + str;
            str = NoneEncrypt(str, 1);
            str = strResult + str;

            return str;
        }

        /// <summary>
        /// 对字符串进行加密（不可逆）
        /// </summary>
        /// <param name="Password">要加密的字符串</param>
        /// <param name="Format">加密方式,0 is SHA1,1 is MD5</param>
        /// <returns></returns>
        public static string NoneEncrypt(string Password, int Format)
        {
            string strResult = "";
            switch (Format)
            {
                case 0:
                    strResult = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "SHA1");
                    break;
                case 1:
                    strResult = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "MD5");
                    break;
                default:
                    strResult = Password;
                    break;
            }

            return strResult;
        }

        /// <summary>
        /// 对字符串进行加密
        /// </summary>
        /// <param name="Passowrd">待加密的字符串</param>
        /// <returns>string</returns>
        public static string Encrypt(string Passowrd)
        {
            string strResult = "";

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(Passowrd, true, 2);
            strResult = FormsAuthentication.Encrypt(ticket).ToString();

            return strResult;
        }


        /// <summary>
        /// 对字符串进行解密
        /// </summary>
        /// <param name="Passowrd">已加密的字符串</param>
        /// <returns></returns>
        public static string Decrypt(string Passowrd)
        {
            string strResult = "";

            strResult = FormsAuthentication.Decrypt(Passowrd).Name.ToString();

            return strResult;
        }

        /// <summary>
        /// 字符串加密  进行位移操作
        /// </summary>
        /// <param name="str">待加密数据</param>
        /// <returns>加密后的数据</returns>
        public static string EncryptString(string Input)
        {
            string _temp = "";
            int _inttemp;
            char[] _chartemp = Input.ToCharArray();
            for (int i = 0; i < _chartemp.Length; i++)
            {
                _inttemp = _chartemp[i] + 1;
                _chartemp[i] = (char)_inttemp;
                _temp += _chartemp[i];
            }
            return _temp;
        }

        /// <summary>
        /// 字符串解密
        /// </summary>
        /// <param name="str">待解密数据</param>
        /// <returns>解密成功后的数据</returns>
        public static string NcyString(string Input)
        {
            string _temp = "";
            int _inttemp;
            char[] _chartemp = Input.ToCharArray();
            for (int i = 0; i < _chartemp.Length; i++)
            {
                _inttemp = _chartemp[i] - 1;
                _chartemp[i] = (char)_inttemp;
                _temp += _chartemp[i];
            }
            return _temp;
        }

        /// <summary>
        /// MD5函数
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>MD5结果</returns>
        public static string MD5(string str)
        {
            byte[] b = Encoding.Default.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');
            return ret;
        }

        /// <summary>
        /// SHA256函数
        /// </summary>
        /// /// <param name="str">原始字符串</param>
        /// <returns>SHA256结果</returns>
        public static string SHA256(string str)
        {
            byte[] SHA256Data = Encoding.UTF8.GetBytes(str);
            SHA256Managed Sha256 = new SHA256Managed();
            byte[] Result = Sha256.ComputeHash(SHA256Data);
            return Convert.ToBase64String(Result);  //返回长度为44字节的字符串
        }

        public static string SHA1(string text)
        {
            byte[] cleanBytes = Encoding.Default.GetBytes(text);
            byte[] hashedBytes = System.Security.Cryptography.SHA1.Create().ComputeHash(cleanBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }
    }
}
