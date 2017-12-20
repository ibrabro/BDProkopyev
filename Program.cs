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

                // Insert some data
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    
                    cmd.CommandText = "INSERT INTO students (name, phone, address) VALUES ('Иванов Иван Иванович', 2432323, 'DU, 3/1, 201')";
                    // cmd.Parameters.AddWithValue("p", "Hello world");
                    cmd.ExecuteNonQuery();
                }

                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT name FROM students", conn))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        Console.WriteLine(reader.GetString(0));
            }
        }
    }
}
