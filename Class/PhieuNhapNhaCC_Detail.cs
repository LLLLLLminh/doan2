using DataAccess_System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Class
{
    public class PhieuNhapNhaCC_Detail 
    {
        private int ID { get; set; }
        public string? SoLo { get; set; }
        public DateTime HanDung { get; set; }
        public int Thuoc_ID { get; set; }
        public int DonGia { get; set; }
        public int SoLuong { get; set; }
        public int SoTienPhatSinh { get; set; }
        public string? GhiChu { get; set; }

        private ComboItem ThuocDaChon
        {
            set
            {
                Thuoc_ID = value.Id;
            }
        }
        private string SP_Name = "sp_PhieuNhapNhaCC_Detail";
        private List<SqlParameter> para = new List<SqlParameter>();

        public int Add(int phieu_id, int KhoNhap_ID)
        {
            para.Clear();
            para.Add(new SqlParameter("@Action", "Add"));
            para.Add(new SqlParameter("@PhieuNhap_ID", phieu_id));
            para.Add(new SqlParameter("@SoLo", SoLo));
            para.Add(new SqlParameter("@Thuoc_ID", Thuoc_ID));
            var p = new SqlParameter("@HanDung", SqlDbType.DateTime);
            p.Value = HanDung;
            para.Add(p);
            para.Add(new SqlParameter("@DonGia", DonGia));
            para.Add(new SqlParameter("@SoLuong", SoLuong));
            para.Add(new SqlParameter("@SoTienPhatSinh", SoTienPhatSinh));
            para.Add(new SqlParameter("@GhiChu", GhiChu));
            para.Add(new SqlParameter("@Kho_ID", KhoNhap_ID));
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
            para.Add(new SqlParameter("@SoLo", SoLo));
            para.Add(new SqlParameter("@Thuoc_ID", Thuoc_ID));
            var p = new SqlParameter("@HanDung", SqlDbType.DateTime);
            p.Value = HanDung;
            para.Add(p);
            para.Add(new SqlParameter("@DonGia", DonGia));
            para.Add(new SqlParameter("@SoLuong", SoLuong));
            para.Add(new SqlParameter("@SoTienPhatSinh", SoTienPhatSinh));
            para.Add(new SqlParameter("@GhiChu", GhiChu));


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
        public int DeleteByPhieuNhap_ID(int phieu_id)
        {
            para.Add(new SqlParameter("@Action", "DeleteByPhieuNhap_ID"));
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
            SoLo = dr["SoLo"].ToString();
            Thuoc_ID = (int)dr["Thuoc_ID"];
            HanDung = (DateTime)dr["HanDung"];
            SoLuong = (int)dr["SoLuong"];
            DonGia = (int)dr["DonGia"];
            SoTienPhatSinh = (int)dr["SoTienPhatSinh"];
            GhiChu = dr["GhiChu"].ToString();

        }
    }
}
