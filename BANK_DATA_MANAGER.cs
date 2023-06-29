using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BANK_DATABASE
{
    public class BANK
    {
        private string BANK_NAME = "THE KALYAN JANTA";
        public string Bank_Name
        {
            get { return BANK_NAME; }

        }
        public long ACCOUNT_NO { get; set; }
        public string IFSC_CODE { get; set; }
        public string FULL_NAME { get; set; }
        public string ADDRESS { get; set; }
    }

    internal class Program
    {
        private static string connectionString = "Data Source=DESKTOP-56G3R6M\\SQLEXPRESS;Initial Catalog=MYDB;Integrated Security=True";

        static void Main(string[] args)
        {
            int CHOICE;
            do
            {
                Console.WriteLine("1. Get All The Records:");
                Console.WriteLine("2. Insert Data:");
                Console.WriteLine("3. Find data by Account Number:");
                Console.WriteLine("4. Delete data by Account Number:");
                Console.WriteLine("5. To Exit:");
                Console.WriteLine("Enter Your Choice (1-5):");

                CHOICE = Convert.ToInt32(Console.ReadLine());

                switch (CHOICE)
                {
                    case 1:
                        GetAllRecords();
                        break;

                    case 2:
                        InsertData();
                        break;

                    case 3:
                        FindDataByAccountNumber();
                        break;

                    case 4:
                        DeleteDataByAccountNumber();
                        break;
                }
            } while (CHOICE != 5);

            Console.WriteLine("Exit");
        }

        static void GetAllRecords()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string Query = "SELECT * FROM BANK";
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        foreach (DataRow row in table.Rows)
                        {
                            foreach (DataColumn column in table.Columns)
                            {
                                Console.Write(row[column] + "\n");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        static void InsertData()
        {
            Console.WriteLine("Enter the no of records you want to add:");
            int record = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < record; i++)
            {
                BANK bank = new BANK();
                Console.WriteLine("Enter the Bank name:");
                string BAK_NAME = bank.Bank_Name; /*= Console.ReadLine();*/
                Console.WriteLine("Enter the Account no.");
                bank.ACCOUNT_NO = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter the Ifsc Code");
                bank.IFSC_CODE = Console.ReadLine();
                Console.WriteLine("Enter the Full name:");
                bank.FULL_NAME = Console.ReadLine();
                Console.WriteLine("Enter the Address:");
                bank.ADDRESS = Console.ReadLine();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string Query = "INSERT INTO BANK(BANK_NAME, ACCOUNT_NO, IFSC_CODE, FULL_NAME, ADDRESS) VALUES(@BANK_NAME, @ACCOUNT_NO, @IFSC_CODE, @FULL_NAME, @ADDRESS)";
                    using (SqlCommand cmd = new SqlCommand(Query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BANK_NAME", bank.Bank_Name);
                        cmd.Parameters.AddWithValue("@ACCOUNT_NO", bank.ACCOUNT_NO);
                        cmd.Parameters.AddWithValue("@IFSC_CODE", bank.IFSC_CODE);
                        cmd.Parameters.AddWithValue("@FULL_NAME", bank.FULL_NAME);
                        cmd.Parameters.AddWithValue("@ADDRESS", bank.ADDRESS);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        static void FindDataByAccountNumber()
        {
            Console.WriteLine("Enter Account number to search:");
            long num = Convert.ToInt64(Console.ReadLine());
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string Query = "SELECT * FROM BANK WHERE ACCOUNT_NO = @ACCOUNT_NO";
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@ACCOUNT_NO", num);
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);

                        foreach (DataRow row in table.Rows)
                        {
                            foreach (DataColumn column in table.Columns)
                            {
                                Console.Write(column.ColumnName + ": ");
                                Console.WriteLine(row[column.ColumnName]);
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
        static void DeleteDataByAccountNumber()
        {
            Console.WriteLine("Enter Account number to Delete:");
            long num = Convert.ToInt64(Console.ReadLine());
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string Query = "DELETE FROM BANK WHERE ACCOUNT_NO = @ACCOUNT_NO";
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@ACCOUNT_NO", num);
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);

                        foreach (DataRow row in table.Rows)
                        {
                            foreach (DataColumn column in table.Columns)
                            {
                                Console.Write(column.ColumnName + ": ");
                                Console.WriteLine(row[column.ColumnName]);
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
