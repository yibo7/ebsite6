using EbSite.Base.Modules;
using Newtonsoft.Json;

namespace EbSite.Mvc.Token
{
    public class EbToken
    {
        public static string GetTokenStr(TokenInfo tkModel)
        {
            string json = JsonConvert.SerializeObject(tkModel);
           
            return EbSite.Core.DES.Encode(json, EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);


        }

        public static TokenInfo GetTokenModel(string tk)
        {
            string tkJson = Core.DES.Decode(tk, EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);
            return JsonConvert.DeserializeObject<TokenInfo>(tkJson);
        }
    }
}