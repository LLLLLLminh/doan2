using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.NETCore;


namespace DataAccess_System
{
    public static class ReportSaver
    {
        public static async Task DownloadReportPdf(int phieuId, string reportPath, string savePath)
        {
            // 1. Cấu hình các thông số Server
            string serverUrl = "http://ADMIN:80/ReportServer"; 

            // 2. Xây dựng URL với tham số
            // rs:Format=PDF : Yêu cầu Server xuất định dạng PDF
            // PhieuID : Tên tham số bạn đã đặt trong SQL lúc đầu
            string url = $"{serverUrl}?{reportPath}&PhieuID={phieuId}&rs:Command=Render&rs:Format=PDF";

            // 3. Sử dụng HttpClient để tải file
            using var handler = new HttpClientHandler { UseDefaultCredentials = true }; // Dùng Windows Authentication
            using var client = new HttpClient(handler);


            byte[] pdfBytes = await client.GetByteArrayAsync(url);
            await File.WriteAllBytesAsync(savePath, pdfBytes);

        }
    }
}
