using DataAccess_System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Class
{
    public class KiemKe : Phieu
    {
        public int Kho_ID { get; set; }
        public int TrangThai { get; set; }
        public KiemKe()
        {
            SP_Name = "sp_KiemKe";
        }
        public override int Add()
        {
            para.Clear();
            para.Add(new SqlParameter("@Kho_ID", Kho_ID));
            para.Add(new SqlParameter("@TrangThai", TrangThai));

            return base.Add();
        }
        public override int Update(int phieu_id)
        {
            para.Clear();
            para.Add(new SqlParameter("@Kho_ID", Kho_ID));
            para.Add(new SqlParameter("@TrangThai", TrangThai));

            return base.Update(phieu_id);
        }
        public override bool GetByPhieu_ID(int phieu_id)
        {
            var p1 = new SqlParameter("@Action", "GetByPhieu_ID");
            var p3 = new SqlParameter("@Phieu_ID", phieu_id);
            DataTable dt = DatabaseHelper.ExecuteDataTable(
                SP_Name,
                CommandType.StoredProcedure,
                p1, p3
            );
            if (dt.Rows.Count == 0) return false;

            ExtractDataRow(dt.Rows[0]);

            return true;
        }

        public DataTable GetByKho_ID(int kho_id)
        {
            var p1 = new SqlParameter("@Action", "GetByKho_ID");
            var p3 = new SqlParameter("@Kho_ID", kho_id);
            DataTable dt = DatabaseHelper.ExecuteDataTable(
                SP_Name,
                CommandType.StoredProcedure,
                p1, p3
            );
            return dt;
        }

        public override void ExtractDataRow(DataRow dr)
        {
            if (dr == null) return;
            Kho_ID = (int)dr["Kho_ID"];
            TrangThai = (int)dr["TrangThai"];

            base.ExtractDataRow(dr);
        }
    }
}
