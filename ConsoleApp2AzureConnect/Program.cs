
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp2AzureConnect
{
    class Program
    {

        static void Main(string[] args)
        {
            SqlCommand cnnCommand;
            SqlDataReader cnnReader;
            var connectionString = ConfigurationManager.ConnectionStrings["EPWebServices"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    Console.WriteLine("Connection Open ! ");
                    cnn.Open();
                    cnnCommand = new SqlCommand("SELECT *  FROM [dbo].[UserAnswers] ",cnn);
                    cnnReader = cnnCommand.ExecuteReader();
                    while (cnnReader.Read())
                    {
                        
                        Console.WriteLine(cnnReader[1].ToString());
                    }

                  
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! ");
                }
            }

        }
    }
}
