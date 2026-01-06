using DataAccess_System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Class
{
    public class PhieuNhap_Detail 
    {
        private int ID { get; set; }
        public int LoThuoc_ID { get; set; }
        public int DonGia { get; set; }
        public int SoLuong { get; set; }

        private ComboItem LoThuocDaChon
        {
            set
            {
                LoThuoc_ID = value.Id;
            }
        }
        private string SP_Name = "sp_PhieuNhap_Detail";
        private List<SqlParameter> para = new List<SqlParameter>();

        public int Add(int phieu_id)
        {
            para.Clear();
            para.Add(new SqlParameter("@Action", "Add"));
            para.Add(new SqlParameter("@PhieuNhap_ID", phieu_id));
            para.Add(new SqlParameter("@LoThuoc_ID", LoThuoc_ID));
            para.Add(new SqlParameter("@DonGia", DonGia));
            para.Add(new SqlParameter("@SoLuong", SoLuong));

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
            para.Add(new SqlParameter("@DonGia", DonGia));
            para.Add(new SqlParameter("@SoLuong", SoLuong));


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
            para.Add(new SqlParameter("@PhieuNhap_ID", phieu_id));
            return DatabaseHelper.ExecuteNonQuery(
                SP_Name,
                CommandType.StoredProcedure,
                para.ToArray()
            );
        }
        public DataTable GetByPhieu_ID(int phieu_id)
        {
            var p1 = new SqlParameter("@Action", "GetByPhieu_ID");
            var p3 = new SqlParameter("@PhieuNhap_ID", phieu_id);
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
            SoLuong = (int)dr["SoLuong"];
            DonGia = (int)dr["DonGia"];

        }
    }
}
