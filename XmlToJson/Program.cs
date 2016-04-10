using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

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
                string json = JsonConvert.SerializeXmlNode(doc);

                string fileJson = file.ToLower().Replace(".xml", ".json");
                using (var streamWriter = new StreamWriter(fileJson, false, Encoding.UTF8))
                {
                    streamWriter.Write(json);
                }
            }
        }
    }
}
