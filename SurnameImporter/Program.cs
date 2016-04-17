using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Tpu.NoSql.Sql;

namespace Tpu.NoSql.SurnameImporter
{
    class Program
    {
        static Random _rnd = new Random();

        static char GetLetter(List<char> letters)
        {
            return letters[_rnd.Next(letters.Count)];
        }

        static void Main(string[] args)
        {
            string path = @"..\..\..\..\db_sources\surname.txt";
            var lines = File.ReadAllLines(path).ToList();
            var initialLetters = lines.Select(x => x[0]).Distinct().Where(c => !(new char[] {'Ч', 'Щ', 'Ц'}).Contains(c)).ToList();

            var customers = new List<Customer>();
            var birthMin = DateTime.Today.AddYears(-18);

            while(lines.Any())
            {
                int i = _rnd.Next(lines.Count);
                customers.Add(new Customer()
                {
                    Name = string.Format("{0} {1}.{2}.", lines[i], GetLetter(initialLetters), GetLetter(initialLetters)),
                    Birth = birthMin.AddDays(- _rnd.Next(11111))
                });

                lines.RemoveAt(i);
            }

            using (var context = new TestContext("Server=192.168.0.103;Port=5432;Database=test;User Id=alexey;Password=fktrc;DbLinqProvider=PostgreSql;DbLinqConnectionType=Npgsql.NpgsqlConnection, Npgsql"))
            {
                if (context.Customer.Any()) return;
                context.Customer.ExecuteFastInsert<Customer>(customers);
            }
        }
    }
}
