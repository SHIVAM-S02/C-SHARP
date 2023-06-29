using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATABASE_CONNECTION
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connstring;
            connstring = "Data Source=DESKTOP-VD7TOTR\\MSSQLSERVER01;Initial Catalog=mydb1;Integrated Security=True";

            SqlConnection sqlConnection = new SqlConnection(connstring);

            Console.WriteLine("enter the first name");
            string fname = Console.ReadLine();

            Console.WriteLine("enter the second name");
            string lname = Console.ReadLine();

            Console.WriteLine("Enter the salary of employee");
            int salar = Convert.ToInt32(Console.ReadLine());

            sqlConnection.Open();
            String query = $"insert into empl(Firstname,Secondname,Salary) values('{fname}' ,'{lname}','{salar}')";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            Console.ReadLine();
        }
    }
}
