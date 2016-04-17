using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Globalization;
using System.Text;

namespace Tpu.NoSql.OsmImporter
{
    class Program
    {
        static double _latMin = 40.6;
        static double _latMax = 77.8;

        static double _lonMin = 27.2;
        static double _lonMax = 179.99;
        //static double _lonMax = 39.99;
        static double _lonStep = 0.4;
        static NumberFormatInfo _formatPoint = new NumberFormatInfo() { NumberDecimalSeparator = "." };

        static void Main(string[] args)
        {
            string jsonFinalPg = "";
            string jsonFinalMongo = "";
            string path = @"..\..\..\..\json\osm_notes";

            for(double lon = _lonMin; lon < _lonMax; lon += _lonStep)
            {
                double lonRight = lon + _lonStep;
                if (lonRight > _lonMax)
                {
                    lonRight = _lonMax;
                }

                string url = string.Format(_formatPoint, "http://api.openstreetmap.org/api/0.6/notes.json?bbox={0},{1},{2},{3}",
                    lon, _latMin, lonRight, _latMax);

                using(var webClient = new WebClient())
                {
                    webClient.Encoding = Encoding.UTF8;
                    string json = webClient.DownloadString(url);
                    json = json.Replace("{\"type\":\"FeatureCollection\",\"features\":[", "");
                    json = json.Substring(0, json.Length - 2);                        

                    if (json.Contains("Feature"))
                    {
                        json = json.Replace(",{\"type\":\"Feature\",", Environment.NewLine + "{\"type\":\"Feature\",");
                        var lines = json.Split('\n');
                        foreach (string ln in lines)
                        {
                            string line = ln.Trim();

                            string marker = "\"properties\":{\"id\":";
                            int ind1 = line.IndexOf(marker) + marker.Length;
                            int ind2 = line.IndexOf(",", ind1);
                            
                            string idStr = line.Substring(ind1, ind2 - ind1);
                            string idStrMongo = idStr;
                            while (idStrMongo.Length < 24)
                            {
                                idStrMongo = "0" + idStrMongo;
                            }

                            string lineMongo = "{\"_id\": {\"$oid\": \"" + idStrMongo + "\"}, " + line.Substring(1);

                            if (jsonFinalMongo != "")
                            {
                                jsonFinalMongo += Environment.NewLine;
                            }
                            jsonFinalMongo += lineMongo;


                            if (jsonFinalPg != "")
                            {
                                jsonFinalPg += "," + Environment.NewLine;
                            }
                            else
                            {
                                jsonFinalPg = "INSERT INTO notes (id, data) VALUES" + Environment.NewLine;
                            }

                            string linePg = string.Format("({0}, '{1}')", idStr, line.Replace("'", "''"));
                            jsonFinalPg += linePg;
                        }

                        if (jsonFinalPg != "")
                        {
                            jsonFinalPg += Environment.NewLine;
                        }
                    }
                }
            }

            File.WriteAllText(path + "_pg.sql", jsonFinalPg, Encoding.UTF8);
            File.WriteAllText(path + "_mongo.json", jsonFinalMongo, Encoding.UTF8);
        }
    }
}
