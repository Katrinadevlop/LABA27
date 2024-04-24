using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA27
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string connectionString = "Server=DYWKAT\\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            //string sqlExpression = "INSERT INTO Users (Name, Age) VALUES ('Tom', 36)";
            //string sqlExpression = "INSERT INTO Users (Name, Age) VALUES ('Alice', 32), ('Bob', 28)";
            //string sqlExpression = "UPDATE Users SET Age=20 WHERE Name='Tom'";
            //string sqlExpression = "DELETE  FROM Users WHERE Name='Tom'";
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();

            Console.WriteLine("Введите возраст:");
            int age = Int32.Parse(Console.ReadLine());
            string sqlExpression = $"INSERT INTO Users (Name, Age) VALUES ('{name}', {age})";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                /*SqlCommand command = new SqlCommand();
                command.CommandText = "CREATE DATABASE mydb";
                command.Connection = connection;
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("База данных создана");*/

                /*SqlCommand command = new SqlCommand();
                command.CommandText = "CREATE TABLE Users (Id INT PRIMARY KEY IDENTITY, Age INT NOT NULL, Name NVARCHAR(100) NOT NULL)";
                command.Connection = connection;
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Таблица Users создана");*/

                /*SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Добавлено объектов: {number}");*/

                /*SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Обновлено объектов: {number}");*/

                /*SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Удалено объектов: {number}");*/

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Добавлено объектов: {number}");

                Console.WriteLine("Введите новое имя:");
                name = Console.ReadLine();
                sqlExpression = $"UPDATE Users SET Name='{name}' WHERE Age={age}";
                command.CommandText = sqlExpression;
                number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Обновлено объектов: {number}");
            }
            Console.Read();
        }
    }
}
