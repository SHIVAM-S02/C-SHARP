using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCSVUpload
{
    class Program
    {
        static void Main(string[] args)
        {


            string connectionString = "Data Source=DESKTOP-56G3R6M\\SQLEXPRESS;Initial Catalog=MYDB;Integrated Security=True";
            string filePath = "C:\\Users\\TALocal\\Desktop\\industry.csv";
            string tableName = "STUDENT"; // Replace with your actual table name

            // Read the CSV file
            DataTable dataTable = ReadCsvFile(filePath);

            if (dataTable != null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Use SqlBulkCopy to upload the data from the CSV file to the target table
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                    {
                        bulkCopy.DestinationTableName = tableName;
                        bulkCopy.WriteToServer(dataTable);
                    }

                    Console.WriteLine("Data uploaded successfully.");

                    connection.Close();
                }
            }
            else
            {
                Console.WriteLine("No data found in the CSV file.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static DataTable ReadCsvFile(string filePath)
        {
            DataTable dataTable = new DataTable();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string[] headers = reader.ReadLine().Split(',');

                if (headers != null)
                {
                    foreach (string header in headers)
                    {
                        dataTable.Columns.Add(header);
                    }

                    while (!reader.EndOfStream)
                    {
                        string[] rows = reader.ReadLine()?.Split(',');

                        if (rows != null && rows.Length == headers.Length)
                        {
                            DataRow dataRow = dataTable.NewRow();
                            dataRow.ItemArray = rows;
                            dataTable.Rows.Add(dataRow);
                        }
                    }
                }
            }

            return dataTable.Rows.Count > 0 ? dataTable : null;
        }
    }
}
