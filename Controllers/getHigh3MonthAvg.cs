using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Net;
using System.Xml.Linq;

namespace getHigh3MonthAvgData
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=master;Integrated Security=True";
            string query = "SELECT TOP 1 [Given Name] + ' ' + [Surname] + ' (' + CAST(ROUND(([Expense (Month 1)] + [Expense (Month 2)] + [Expense (Month 3)])/3.0, 2) AS VARCHAR(10)) + ')' " +
                                "AS [Highest 3 Months Average Expenses] " +
                                "FROM Table1 JOIN Table2 ON Table1.Userid = Table2.Userid " +
                                "JOIN Table3 ON Table2.Col_1 = Table3.Col_1" +
                                "ORDER BY([Expense(Month 1)] + [Expense(Month 2)] + [Expense(Month 3)])/ 3.0 DESC";

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
    public class getHigh3MonthAvg : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
