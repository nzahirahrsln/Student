using System;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace CombineData
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=master;Integrated Security=True";
            string query = "SELECT t1.Userid, t1.Surname, t1.[Given Name], t2.[Contact No], t2.Address, t3.[No of Member], t3.Expense [Month 1], t3.[Expense (Month 2)], t3.[Expense (Month 3)]\r\nFROM Table1 t1\r\nINNER JOIN Table2 t2 ON t1.Userid = t2.Userid\r\nINNER JOIN Table3 t3 ON t1.Col_1 = t3.Col_1\r\nORDER BY (t1.Userid % 2), t1.Userid\r\n";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    int userid = (int)reader["Userid"];
                    string surname = (string)reader["Surname"];
                    string givenName = (string)reader["Given Name"];
                    string contactNo = (string)reader["Contact No"];
                    string address = (string)reader["Address"];
                    string col_1 = (string)reader["Col_1"];
                    int noOfMember = (int)reader["No of Member"];
                    int expenseMonth1 = (int)reader["Expense (Month 1)"];
                    int expenseMonth2 = (int)reader["Expense (Month 2)"];
                    int expenseMonth3 = (int)reader["Expense (Month 3)"];

                    Console.WriteLine($"Userid: {userid}, Surname: {surname}, Given Name: {givenName}, Contact No: {contactNo}, Address: {address}, Col_1: {col_1}, No of Member: {noOfMember}, Expense (Month 1): {expenseMonth1}, Expense (Month 2): {expenseMonth2}, Expense (Month 3): {expenseMonth3}");
                }

                reader.Close();
            }

            Console.ReadKey();
        }
    }
}
