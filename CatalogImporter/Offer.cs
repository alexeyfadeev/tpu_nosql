using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tpu.NoSql.CatalogImporter
{
    class Offer
    {
        public int id { get; set; }
        public bool available { get; set; }
        public float price { get; set; }
        public int categoryId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string vendor { get; set; }        

        public object param
        {
            set
            {
                if (value is JArray)
                {
                    var list = ((JArray)value).ToObject<List<Param>>();
                    Parameters = list.ToDictionary(x => x.name, x => x.text);
                }
                else if (value is JObject)
                {
                    var prm = ((JObject)value).ToObject<Param>();
                    Parameters = new Dictionary<string, string>() { { prm.name, prm.text } };
                }
            }
        }

        public object barcode
        {
            set
            {
                if (value is JArray)
                {
                    var list = ((JArray)value).ToObject<List<long>>();
                    BarCode = list[0];
                }
                else if (value is JObject)
                {
                    var prm = ((JObject)value).ToObject<long>();
                    BarCode = prm;
                }
            }
        }

        [JsonIgnore]
        public Dictionary<string, string> Parameters { get; set; }

        [JsonIgnore]
        public long BarCode { get; set; }
    }
}
