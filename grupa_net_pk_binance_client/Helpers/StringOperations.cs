using Newtonsoft.Json;
using System.Net.Http;
using System.Security;
using System.Text;

namespace grupa_net_pk_binance_client.Helpers
{
    public static class StringOperations
    {
        //public static SecureString ToSecureString(this string source)
        //{
        //    if (string.IsNullOrWhiteSpace(source))
        //        return null;
        //    var result = new SecureString();
        //    foreach (var c in source.ToCharArray())
        //        result.AppendChar(c);
        //    return result;
        //}
        public static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
