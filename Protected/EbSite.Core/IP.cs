using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace EbSite.Core
{
    public class IP
    {
        /// <summary>
        /// 将IP地址转为整数形式
        /// </summary>
        /// <returns>整数</returns>
        public static long IPToInt(IPAddress ip)
        {
            int x = 3;
            long o = 0;
            foreach (byte f in ip.GetAddressBytes())
            {

                o += (long)f << 8 * x--;

            }
            return o;

        }

        /// <summary>
        /// 将整数转为IP地址
        /// </summary>
        /// <returns>IP地址</returns>
        public static IPAddress IntToIP(long iIP)
        {

            var b = new byte[4];

            for (int i = 0; i < 4; i++)
            {

                b[3 - i] = (byte)(iIP >> 8 * i & 255);

            }

            return new IPAddress(b);

        }

        /// <summary>
        /// 验证传入IP地址是否应被屏蔽。
        /// </summary>
        /// <param name="IP地址">待验证的IP</param>
        /// <returns>是否应被屏蔽</returns>
        public static bool IsAllowIP(IPAddress CurrentIP, IPAddress StarIP, IPAddress EndIP, DateTime dtEnd)
        {

            long ipCurrent = IPToInt(CurrentIP);
            long iStarIP = IPToInt(StarIP);
            long iEndIP = IPToInt(EndIP);
            return !(dtEnd > DateTime.Now && iStarIP <= ipCurrent && iEndIP >= ipCurrent);

        }

        /// <summary>
        /// 检测指定IP地址是否已受到屏蔽
        /// </summary>
        /// <param name="IP地址">要检测的IP地址</param>
        /// <returns>是否属于已屏蔽的IP</returns>
        public static bool IsAllowIP(string CurrentIP, string StarIP, string EndIP, DateTime dtEnd)
        {

            return IsAllowIP(IPAddress.Parse(CurrentIP), IPAddress.Parse(StarIP), IPAddress.Parse(EndIP), dtEnd);

        }
    }
}
