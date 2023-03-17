using System;
using System.Data.SqlClient;

namespace EvenUserIdData
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=master;Integrated Security=True";
            string query = "SELECT * FROM Table1 t1 JOIN Table2 t2 ON t1.Userid = t2.Userid JOIN Table3 t3 ON t2.Col_1 = t3.Col_1 WHERE t1.Userid % 2 = 0";

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
