using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Text;

namespace grupa_net_pk_binance_client.Helpers
{
    public static class StringOperations
    {
        public static string ToQueryString(this object data)
        {
            var type = data.GetType();
            var props = type.GetProperties();
            var pairs = props.Select(x => x.Name + "=" + x.GetValue(data, null)).ToArray();
            return string.Join("&", pairs);
        }
        public static StringContent GetPayload(this object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var result = new StringContent(json, Encoding.UTF8, "application/json");
            return result;
        }
    }
}
