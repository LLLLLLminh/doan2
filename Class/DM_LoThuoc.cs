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
    public class DM_LoThuoc
    {
        public int LoThuoc_ID { get; set; }
        public string? SoLo { get; set; }
        public int Thuoc_ID { get; set; }
        public string? Ten_Thuoc { get; set; }
        public DateTime HanDung { get; set; }
        public string? GhiChu { get; set; }
        public int Add()
        {
            var p1 = new SqlParameter("@Action", "Add");
            var p2 = new SqlParameter("@SoLo", SoLo);
            var p3 = new SqlParameter("@Thuoc_ID", Thuoc_ID);
            var p4 = new SqlParameter("@HanDung", HanDung);
            var p5 = new SqlParameter("@GhiChu", GhiChu);
            return DatabaseHelper.ExecuteNonQuery(
                "sp_DM_LoThuoc",
                CommandType.StoredProcedure,
                p1, p2, p3, p4, p5
            );
        }
        public int Update()
        {
            var p1 = new SqlParameter("@Action", "Update");
            var p2 = new SqlParameter("@SoLo", SoLo);
            var p3 = new SqlParameter("@Thuoc_ID", Thuoc_ID);
            var p4 = new SqlParameter("@HanDung", HanDung);
            var p5 = new SqlParameter("@GhiChu", GhiChu);
            var p6 = new SqlParameter("@LoThuoc_ID", LoThuoc_ID);
            return DatabaseHelper.ExecuteNonQuery(
                "sp_DM_LoThuoc",
                CommandType.StoredProcedure,
                p1, p2, p3, p4, p5, p6
            );
        }
        public int Delete()
        {
            var p1 = new SqlParameter("@Action", "Delete");
            var p2 = new SqlParameter("@LoThuoc_ID", LoThuoc_ID);
            return DatabaseHelper.ExecuteNonQuery(
                "sp_DM_LoThuoc",
                CommandType.StoredProcedure,
                p1, p2
            );
        }
        public DataTable GetDataTable(string? filterValue)
        {
            var p1 = new SqlParameter("@Action", "GetDataTable");
            var p3 = new SqlParameter("@SoLo", filterValue);
            DataTable dt = DatabaseHelper.ExecuteDataTable(
                "sp_DM_LoThuoc",
                CommandType.StoredProcedure,
                p1, p3
            );
            return dt;
        } 
    }
}
