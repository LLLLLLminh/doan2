using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DataAccess_System
{
    public static class DatabaseHelper
    {
        private static string? connectionString;
        private static string? reportFolder;

        static DatabaseHelper()
        {
            GetConnectionString();
        }
        public static void GetConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            connectionString = config.GetConnectionString("conn");
            reportFolder = config.GetConnectionString("reportFolder");
        }
        public static void UpdateConnectionString(string? newConnectionString)
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

            string json = File.ReadAllText(filePath);

            var root = JsonNode.Parse(json);


            if (root["ConnectionStrings"] == null)
            {
                root["ConnectionStrings"] = new JsonObject();
            }
            root["ConnectionStrings"]["conn"] = newConnectionString;


            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(filePath, root.ToJsonString(options));
        }
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối SQL Server:{ex.ToString()}");
                return false;
            }
        }

        public static int ExecuteNonQuery(string commandText, CommandType type, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = type;

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối SQL Server:{ex.ToString()}");
                return -1;
            }
            
        }

        public static DataTable ExecuteDataTable(string commandText, CommandType type, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = type;

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối SQL Server:{ex.ToString()}");
            }

            return dt;
        }

        public static object ExecuteScalar(string commandText, CommandType type, params SqlParameter[] parameters)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = type;

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối SQL Server:{ex.ToString()}");
                return false;
            }
        }
        public static string? GetReportFolder() { return reportFolder; }
    }
}
