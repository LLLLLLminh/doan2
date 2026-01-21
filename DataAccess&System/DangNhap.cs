using DataAccess_System;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace Class
{
    public static class DangNhap
    {
        public static int User_ID { get; set; }
        public static string? Username { get; set; }
        public static string? Password { get; set; }
        public static bool? IsAdmin { get; set; }

        public static bool LogIn(string? username, string? password)
        {

            var p1 = new SqlParameter("@Action", "LogIn");
            var p3 = new SqlParameter("@Username", username);

            DataTable dt = DatabaseHelper.ExecuteDataTable(
                "sp_DangNhap",
                CommandType.StoredProcedure,
                p1, p3
            );
            if (dt.Rows.Count == 0)
                return false;
            DataRow row = dt.Rows[0];
            User_ID = (int)row["User_Id"];
            IsAdmin = (bool)row["IsAdmin"];
            byte[] salt = (byte[])row["PasswordSalt"];
            byte[] hash = (byte[])row["PasswordHash"];
            byte[] hashCheck = HashPassword(password, salt);
            if (hash.SequenceEqual(hashCheck)) 
                return true;
            return false;
               

        }
        public static byte[] GenerateSalt(int saltSize = 16)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] salt = new byte[saltSize];
                rng.GetBytes(salt);
                return salt;
            }
        }
        public static byte[] HashPassword(string password, byte[] salt, int iterations = 10000)
        {
            if (password == "")
                return null;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(32); 
            }
        }
        public static bool AddNew() 
        {
            byte[] salt = GenerateSalt();
            var p1 = new SqlParameter("@Action", "Add");
            var p2 = new SqlParameter("@Username", Username);
            var p3 = new SqlParameter("@PasswordSalt", salt);
            var p4 = new SqlParameter("@PasswordHash", HashPassword(Password, salt));
            var p5 = new SqlParameter("@IsAdmin", IsAdmin);
            var p6 = new SqlParameter("@User_ID", User_ID);
            DatabaseHelper.ExecuteScalar(
                "sp_DangNhap",
                CommandType.StoredProcedure,
                p1,p2,p3,p4,p5,p6
            );
            if (User_ID > 0)
                return true;
            else return false;
        }
        public static bool Update()
        {
            byte[] salt = GenerateSalt();
            var p1 = new SqlParameter("@Action", "Update");
            var p2 = new SqlParameter("@Username", Username);
            var p3 = new SqlParameter("@PasswordSalt", salt);
            var p4 = new SqlParameter("@PasswordHash", HashPassword(Password, salt));
            var p5 = new SqlParameter("@IsAdmin", IsAdmin);
            var p6 = new SqlParameter("@User_ID", User_ID);
            try
            {
                DatabaseHelper.ExecuteScalar(
                    "sp_DangNhap",
                    CommandType.StoredProcedure,
                    p1, p2, p3, p4, p5, p6
                );
            }
            catch ( Exception ex )
            {
                return false;
            }
            return true;
        }
        public static bool Delete()
        {
            var p1 = new SqlParameter("@Action", "Delete");
            var p6 = new SqlParameter("@User_ID", User_ID);
            try
            {
                DatabaseHelper.ExecuteScalar(
                    "sp_DangNhap",
                    CommandType.StoredProcedure,
                    p1, p6
                );
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public static DataTable GetDataTable(string? filterValue)
        {
            var p1 = new SqlParameter("@Action", "GetDataTable");
            var p3 = new SqlParameter("@Username", filterValue);
            DataTable dt = DatabaseHelper.ExecuteDataTable(
                "sp_DangNhap",
                CommandType.StoredProcedure,
                p1, p3
            );
            return dt;
        }
    }
    public class DM_DangNhap
    {
        public int User_ID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
