using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MongoJsonToPg
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = new string[] { "world_bank.json", "emails.json", "stocks.json" };
            string jsonFinalPg = "";

            foreach (var file in files)
            {
                string table = file.Split('.')[0];
                string path = @"F:\exper\nosql\json\" + file;

                var lines = File.ReadAllLines(path);
                int cnt = lines.Count();

                for (int i = 0; i < cnt; i++ )
                {
                    string line = lines[i];

                    if (jsonFinalPg != "")
                    {
                        jsonFinalPg += "," + Environment.NewLine;
                    }
                    else
                    {
                        jsonFinalPg = "INSERT INTO " + table + " (data) VALUES" + Environment.NewLine;
                    }

                    jsonFinalPg += "('" + line.Replace("'", "''") + "')";
                }

                File.WriteAllText(path.Replace(".json", ".sql"), jsonFinalPg);
            }            
        }
    }
}
