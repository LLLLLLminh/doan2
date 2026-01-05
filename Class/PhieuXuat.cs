using DataAccess_System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Class
{
    public class PhieuXuat : Phieu
    {
        public int LoaiPhieu { get; set; }
        public int DonViXuat_ID { get; set; }
        public int NguoiXuat_ID { get; set; }
        public string? DienGiai { get; set; }
        public int TrangThai { get; set; }
        public PhieuXuat()
        {
            SP_Name = "sp_PhieuXuat";
        }
        public override int Add()
        {
            para.Clear();
            para.Add(new SqlParameter("@LoaiPhieu", LoaiPhieu));
            para.Add(new SqlParameter("@DonViXuat_ID", DonViXuat_ID));
            para.Add(new SqlParameter("@NguoiXuat_ID", NguoiXuat_ID));
            para.Add(new SqlParameter("@DienGiai", DienGiai));
            para.Add(new SqlParameter("@TrangThai", TrangThai));

            return base.Add();
        }
        public override int Update(int phieu_id)
        {
            para.Clear();
            para.Add(new SqlParameter("@LoaiPhieu", LoaiPhieu));
            para.Add(new SqlParameter("@DonViXuat_ID", DonViXuat_ID));
            para.Add(new SqlParameter("@NguoiXuat_ID", NguoiXuat_ID));
            para.Add(new SqlParameter("@DienGiai", DienGiai));
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

        public override void ExtractDataRow(DataRow dr)
        {
            if (dr == null) return;
            LoaiPhieu = (int)dr["LoaiPhieu"];
            DonViXuat_ID = (int)dr["DonViXuat_ID"];
            NguoiXuat_ID = (int)dr["NguoiXuat_ID"];
            DienGiai = dr["DienGiai"].ToString();
            TrangThai = (int)dr["TrangThai"];

            base.ExtractDataRow(dr);
        }
    }
}
