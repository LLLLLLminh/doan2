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
    public class DM_Thuoc
    {
        public int Thuoc_ID { get; set; }
        public string? TenDuoc { get; set; }
        public string? DonViTinh { get; set; }
        public int Add()
        {
            var p1 = new SqlParameter("@Action", "Add");
            var p3 = new SqlParameter("@TenDuoc", TenDuoc);
            var p4 = new SqlParameter("@DonViTinh", DonViTinh);
            return DatabaseHelper.ExecuteNonQuery(
                "sp_DM_Thuoc",
                CommandType.StoredProcedure,
                p1, p3, p4
            );
        }
        public int Update()
        {
            var p1 = new SqlParameter("@Action", "Update");
            var p2 = new SqlParameter("@Thuoc_ID", Thuoc_ID);
            var p3 = new SqlParameter("@TenDuoc", TenDuoc);
            var p4 = new SqlParameter("@DonViTinh", DonViTinh);
            return DatabaseHelper.ExecuteNonQuery(
                "sp_DM_Thuoc",
                CommandType.StoredProcedure,
                p1,p2,p3,p4
            );
        }
        public int Delete()
        {
            var p1 = new SqlParameter("@Action", "Delete");
            var p2 = new SqlParameter("@Thuoc_ID", Thuoc_ID);
            return DatabaseHelper.ExecuteNonQuery(
                "sp_DM_Thuoc",
                CommandType.StoredProcedure,
                p1, p2
            );
        }
        public DataTable GetDataTable(string? filterValue)
        {
            var p1 = new SqlParameter("@Action", "GetDataTable");
            var p3 = new SqlParameter("@TenDuoc", filterValue);
            DataTable dt = DatabaseHelper.ExecuteDataTable(
                "sp_DM_Thuoc",
                CommandType.StoredProcedure,
                p1, p3
            );
            return dt;
        } 
    }
}
