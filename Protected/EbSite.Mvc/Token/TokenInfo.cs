using System;

namespace EbSite.Mvc.Token
{
    public class TokenInfo
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserNiname { get; set; }
        public string Pass { get; set; }
        public int GroupId { get; set; }
        public DateTime LastTime { get; set; }
    }
}