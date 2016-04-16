using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tpu.NoSql.XmlToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() < 1) return;
            var files = Directory.GetFiles(args[0], "*.xml");

            foreach (string file in files)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);

                var obj = JObject.Parse(JsonConvert.SerializeXmlNode(doc));
                foreach (var value in obj.Descendants().OfType<JValue>().Where(v => v.Type == JTokenType.String))
                {
                    long lVal;
                    if (long.TryParse((string)value, out lVal))
                    {
                        value.Value = lVal;
                        continue;
                    }
                    double dVal;
                    if (double.TryParse((string)value, out dVal))
                    {
                        value.Value = dVal;
                        continue;
                    }
                    decimal dcVal;
                    if (decimal.TryParse((string)value, out dcVal))
                    {
                        value.Value = dcVal;
                        continue;
                    }
                    bool bVal;
                    if (bool.TryParse((string)value, out bVal))
                    {
                        value.Value = bVal;
                        continue;
                    }
                }

                string json = obj.ToString(Newtonsoft.Json.Formatting.Indented);

                string fileJson = file.ToLower().Replace(".xml", ".json");
                using (var streamWriter = new StreamWriter(fileJson, false, Encoding.UTF8))
                {
                    streamWriter.Write(json);
                }
            }
        }
    }
}
