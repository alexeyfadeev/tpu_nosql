using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tpu.NoSql.CatalogImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = new string[] { "div_beauty_offers.json", "div_bs_offers.json", "div_food_offers.json", "mobile_offers.json" };

            using (var context = new NoSql.Sql.TestContext("Server=192.168.0.103;Port=5432;Database=test;User Id=alexey;Password=fktrc;DbLinqProvider=PostgreSql;DbLinqConnectionType=Npgsql.NpgsqlConnection, Npgsql"))
            {
                foreach (var file in files)
                {
                    string path = @"F:\exper\nosql\db_sources\" + file;
                    string json = null;

                    using (var streamReader = new StreamReader(path, Encoding.UTF8))
                    {
                        json = streamReader.ReadToEnd();
                    }

                    var offers = JsonConvert.DeserializeObject<List<Offer>>(json);

                    var mapper = new CommonMapper();

                    var offerEntities = offers.Select(x => (NoSql.Sql.Offer)mapper.Map(x, typeof(Offer), typeof(NoSql.Sql.Offer))).ToList();

                    int portionSize = 1000;
                    var buffer = new List<NoSql.Sql.Offer>();

                    foreach (var item in offerEntities)
                    {
                        buffer.Add(item);

                        if (item.ID == 28994227)
                        {
                            string sql = item.InsertSql;
                        }

                        if (buffer.Count >= portionSize)
                        {
                            context.Offer.ExecuteFastInsert<NoSql.Sql.Offer>(buffer);
                            buffer.Clear();
                        }
                    }

                    if (buffer.Any())
                    {
                        context.Offer.ExecuteFastInsert<NoSql.Sql.Offer>(buffer);
                    }
                }
            }
        }
    }
}
