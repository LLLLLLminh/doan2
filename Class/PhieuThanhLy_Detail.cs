using DataAccess_System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Class
{
    public class PhieuThanhLy_Detail 
    {
        private int ID { get; set; }
        public int LoThuoc_ID { get; set; }
        public string? LyDoThanhLy { get; set; }

        private ComboItem LoThuocDaChon
        {
            set
            {
                LoThuoc_ID = value.Id;
            }
        }
        private string SP_Name = "sp_PhieuThanhLy_Detail";
        private List<SqlParameter> para = new List<SqlParameter>();

        public int Add(int phieu_id, int KhoThanhLy_ID)
        {
            para.Clear();
            para.Add(new SqlParameter("@Action", "Add"));
            para.Add(new SqlParameter("@PhieuThanhLy_ID", phieu_id));
            para.Add(new SqlParameter("@LoThuoc_ID", LoThuoc_ID));
            para.Add(new SqlParameter("@LyDoThanhLy", LyDoThanhLy));

            para.Add(new SqlParameter("@Kho_ID", KhoThanhLy_ID));
            para.Add(new SqlParameter("@User_ID", DangNhap.User_ID));

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
            para.Add(new SqlParameter("@LyDoThanhLy", LyDoThanhLy));


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
            para.Add(new SqlParameter("@PhieuThanhLy_ID", phieu_id));
            return DatabaseHelper.ExecuteNonQuery(
                SP_Name,
                CommandType.StoredProcedure,
                para.ToArray()
            );
        }
        public DataTable GetByPhieu_ID(int phieu_id)
        {
            var p1 = new SqlParameter("@Action", "GetByPhieu_ID");
            var p3 = new SqlParameter("@PhieuThanhLy_ID", phieu_id);
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
            LyDoThanhLy = dr["LyDoThanhLy"].ToString();

        }
    }
}
