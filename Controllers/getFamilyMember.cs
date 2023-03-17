using System;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Net;
using System.Xml.Linq;

namespace FamilyMemberData
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=master;Integrated Security=True";
            string query = "SELECT t1.Userid, t1.Surname, t1.[Given Name], t2.[Address], t2.Col_1 as [Addr code], t3.[No of Member]," +
                                "t3.[Expense(Month 1)], t3.[Expense(Month 2)], t3.[Expense(Month 3)], t3.[Expense(Month 1)] + " +
                                "t3.[Expense(Month 2)] + t3.[Expense(Month 3)] as [Total expenses], (t3.[Expense(Month 1)] + " +
                                "t3.[Expense(Month 2)] + t3.[Expense(Month 3)]) / 3.0 as [Average expenses]" +
                            "FROM Table1 t1 INNER JOIN Table2 t2 ON t1.Userid = t2.Userid INNER JOIN Table3 t3 ON t2.Col_1 = t3.Col_1 " +
                            "ORDER BY t1.Userid";

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
