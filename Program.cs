using System;
using Npgsql;

namespace BDProkopyev
{
    class Program
    {
        static void Main(string[] args)
        {
            var connString = "Host=localhost;Username=ibrabro;Password=qwerty;Database=timetable";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                for(int i = 0; i < 10; i++)
                {
                    

                    // Insert some data
                    using (var cmd = new NpgsqlCommand())
                    {
                        string n,a;
                        int p;
                        cmd.Connection = conn;
                        
                            // Console.WriteLine("Введите имя:");
                            // n = Console.ReadLine();
                            // Console.WriteLine("Введите телефон:");
                            // p = Convert.ToInt32(Console.ReadLine());
                            // Console.WriteLine("Введите адрес:");
                            // a = Console.ReadLine();
                            n = String.Format("teacher{0}", i);
                            // a = String.Format("Department{0}", i);
                            p = 255353 + i;
                            cmd.CommandText = "INSERT INTO teachers (name, phone) VALUES (@n, @p)";

                            cmd.Parameters.AddWithValue("n", n);
                            cmd.Parameters.AddWithValue("p", p);
                            // cmd.Parameters.AddWithValue("a", a);
                            cmd.ExecuteNonQuery();
                        
                    }
                }

                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT * FROM teachers", conn))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        Console.WriteLine("{0}  {1}",reader.GetString(0), reader.GetString(1));//, reader.GetInt32(2));
            }
        }
    }
}
