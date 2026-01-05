using DataAccess_System;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class DM_Kho
    {
        public int Kho_ID { get; set; }
        public string? TenKho { get; set; }
        public bool QuanLyNguon { get; set; }
        public string? LoaiKho { get; set; }
        public int Add()
        {
            var p1 = new SqlParameter("@Action", "Add");
            var p3 = new SqlParameter("@TenKho", TenKho);
            var p4 = new SqlParameter("@QuanLyNguon", QuanLyNguon);
            var p5 = new SqlParameter("@LoaiKho", LoaiKho);
            return DatabaseHelper.ExecuteNonQuery(
                "sp_DM_Kho",
                CommandType.StoredProcedure,
                p1, p3, p4, p5
            );
        }
        public int Update()
        {
            var p1 = new SqlParameter("@Action", "Update");
            var p2 = new SqlParameter("@Kho_ID", Kho_ID);
            var p3 = new SqlParameter("@TenKho", TenKho);
            var p4 = new SqlParameter("@QuanLyNguon", QuanLyNguon);
            var p5 = new SqlParameter("@LoaiKho", LoaiKho);
            return DatabaseHelper.ExecuteNonQuery(
                "sp_DM_Kho",
                CommandType.StoredProcedure,
                p1,p2,p3,p4,p5
            );
        }
        public int Delete()
        {
            var p1 = new SqlParameter("@Action", "Delete");
            var p2 = new SqlParameter("@Kho_ID", Kho_ID);
            return DatabaseHelper.ExecuteNonQuery(
                "sp_DM_Kho",
                CommandType.StoredProcedure,
                p1, p2
            );
        }
        public DataTable GetDataTable(string? filterValue)
        {
            var p1 = new SqlParameter("@Action", "GetDataTable");
            var p3 = new SqlParameter("@TenKho", filterValue);
            DataTable dt = DatabaseHelper.ExecuteDataTable(
                "sp_DM_Kho",
                CommandType.StoredProcedure,
                p1, p3
            );
            return dt;
        } 
    }
}
