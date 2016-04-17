using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Tpu.NoSql.Sql;

namespace Tpu.NoSql.PurchaseGenerator
{
    class Program
    {
        static Random _rnd = new Random();

        static void Main(string[] args)
        {
            var dtMin = new DateTime(2015, 1, 1);

            using (var context = new TestContext("Server=192.168.0.103;Port=5432;Database=test;User Id=alexey;Password=fktrc;DbLinqProvider=PostgreSql;DbLinqConnectionType=Npgsql.NpgsqlConnection, Npgsql"))
            {
                var offers = context.Connection.Query<KeyValuePair<int, decimal>>("SELECT id AS Key, price AS Value FROM offer").ToArray();
                var customerIds = context.Connection.Query<int>("SELECT id FROM customer").ToArray();

                var purchases = new List<Purchase>();

                int monthPrev = dtMin.Month;
                for (var dt = dtMin; dt <= DateTime.Today; dt = dt.AddDays(1))
                {
                    int purchaseCnt = _rnd.Next(500) + 50;
                    var dtTodayMin = dt.AddHours(9);                    

                    for (int i = 0; i < purchaseCnt; i++)
                    {
                        var purchase = new Purchase()
                        {
                            CustomerID = customerIds[_rnd.Next(customerIds.Count())],
                            DateTime = dtTodayMin.AddSeconds(_rnd.Next(43200))
                        };

                        int offersCnt = _rnd.Next(35) + 1;
                        var offerIdsCurrent = new List<int>();

                        decimal sum = 0;

                        for (int j = 0; j < offersCnt; j++)
                        {
                            int offerIndex = _rnd.Next(offers.Count());
                            int offerId = offers[offerIndex].Key;                            

                            offerIdsCurrent.Add(offerId);
                            sum += offers[offerIndex].Value;

                            if (_rnd.Next(100) > 80)
                            {
                                for (int k = 0; k < _rnd.Next(10); k++)
                                {
                                    offerIdsCurrent.Add(offerId);
                                    sum += offers[offerIndex].Value;
                                }
                            }
                        }                        

                        purchase.Offers = offerIdsCurrent.ToArray();

                        if (_rnd.Next(100) > 60)
                        {
                            sum *= (100 - _rnd.Next(7));
                            sum /= 100;
                        }

                        purchase.Total = sum;

                        purchases.Add(purchase);
                    }

                    if (monthPrev != dt.Month)
                    {
                        context.Purchase.ExecuteFastInsert<Purchase>(purchases);
                        purchases.Clear();
                        monthPrev = dt.Month;
                    }                    
                }
                if (purchases.Any())
                {
                    context.Purchase.ExecuteFastInsert<Purchase>(purchases);
                }
            }
        }
    }
}
