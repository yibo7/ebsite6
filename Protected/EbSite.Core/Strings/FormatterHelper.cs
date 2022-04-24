using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EbSite.Core.Strings
{
    /// <summary>
    /// FormatterHelper 序列化，反序列化消息的帮助类
    /// </summary>
    public class FormatterHelper
    {
        /// <summary>
        /// 将 obj 对象序列化成 byte[]
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] Serialize(object obj)
        {
            BinaryFormatter binaryF = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(1024 * 10);
            binaryF.Serialize(ms, obj);
            ms.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[(int)ms.Length];
            ms.Read(buffer, 0, buffer.Length);
            ms.Close();

            return buffer;
        }


        /// <summary>
        /// 将 byte[] 反序列化成 obj 对象
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static object Deserialize(byte[] buffer)
        {
            BinaryFormatter binaryF = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(buffer, 0, buffer.Length, false);
            object obj = binaryF.Deserialize(ms);
            ms.Close();

            return obj;
        }
    }
}
