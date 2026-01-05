using DataAccess_System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Class
{
    public class KiemKe_Detail 
    {
        private int ID { get; set; }
        public int LoThuoc_ID { get; set; }
        public int SoLuongTruoc { get; set; }
        public int SoLuongThucTe { get; set; }

        public DateTime HanDung { get; set; }

        private ComboItem LoThuocDaChon
        {
            set
            {
                LoThuoc_ID = value.ID;
            }
        }
        private string SP_Name = "sp_KiemKe_Detail";
        private List<SqlParameter> para = new List<SqlParameter>();

        public int Add(int phieu_id)
        {
            para.Clear();
            para.Add(new SqlParameter("@Action", "Add"));
            para.Add(new SqlParameter("@PhieuKiemKe_ID", phieu_id));
            para.Add(new SqlParameter("@LoThuoc_ID", LoThuoc_ID));
            para.Add(new SqlParameter("@SoLuongTruoc", SoLuongTruoc));
            para.Add(new SqlParameter("@SoLuongThucTe", SoLuongThucTe));

            return DatabaseHelper.ExecuteNonQuery(
                SP_Name,
                CommandType.StoredProcedure,
                para.ToArray()
            );
        }
        public int Update(int ID)
        {
            para.Clear();
            para.Add(new SqlParameter("@Action", "Delete"));
            para.Add(new SqlParameter("@ID", ID));
            para.Add(new SqlParameter("@LoThuoc_ID", LoThuoc_ID));
            para.Add(new SqlParameter("@SoLuongTruoc", SoLuongTruoc));
            para.Add(new SqlParameter("@SoLuongThucTe", SoLuongThucTe));


            return DatabaseHelper.ExecuteNonQuery(
                SP_Name,
                CommandType.StoredProcedure,
                para.ToArray()
            );
        }
        public int Delete(int ID)
        {
            para.Add(new SqlParameter("@Action", "Delete"));
            para.Add(new SqlParameter("@ID", ID));
            return DatabaseHelper.ExecuteNonQuery(
                SP_Name,
                CommandType.StoredProcedure,
                para.ToArray()
            );
        }
        public int DeleteByPhieu_ID(int phieu_id)
        {
            para.Add(new SqlParameter("@Action", "DeleteByPhieu_ID"));
            para.Add(new SqlParameter("@PhieuKiemKe_ID", phieu_id));
            return DatabaseHelper.ExecuteNonQuery(
                SP_Name,
                CommandType.StoredProcedure,
                para.ToArray()
            );
        }
        public DataTable GetByPhieu_ID(int phieu_id)
        {
            var p1 = new SqlParameter("@Action", "GetByPhieu_ID");
            var p3 = new SqlParameter("@DuTru_ID", phieu_id);
            DataTable dt = DatabaseHelper.ExecuteDataTable(
                SP_Name,
                CommandType.StoredProcedure,
                p1, p3
            );
            return dt;
        }
        public void ExtractDataRow(DataRow dr)
        {
            if (dr == null) return;
            ID = (int)dr["ID"];
            LoThuoc_ID = (int)dr["LoThuoc_ID"];
            SoLuongTruoc = (int)dr["SoLuongTruoc"];
            SoLuongThucTe = (int)dr["SoLuongThucTe"];
        }
    }
}
