using DataAccess_System;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Windows.ViewModel
{
    public class NhapThuocRowViewModel : INotifyPropertyChanged
    {
        private ComboItem? _loThuocDaChon;
        public ComboItem? LoThuocDaChon
        {
            get => _loThuocDaChon;
            set { _loThuocDaChon = value; OnPropertyChanged(); }
        }

        private decimal _donGia;
        public decimal DonGia
        {
            get => _donGia;
            set { _donGia = value; OnPropertyChanged(); }
        }

        private int _soLuong;
        public int SoLuong
        {
            get => _soLuong;
            set { _soLuong = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    public class XuatThuocRowViewModel : INotifyPropertyChanged
    {
        private ComboItem? _loThuocDaChon;
        public ComboItem? LoThuocDaChon
        {
            get => _loThuocDaChon;
            set { _loThuocDaChon = value; OnPropertyChanged(); }
        }

        private decimal _donGia;
        public decimal DonGia
        {
            get => _donGia;
            set { _donGia = value; OnPropertyChanged(); }
        }

        private int _soLuong;
        public int SoLuong
        {
            get => _soLuong;
            set { _soLuong = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    public class ThanhLyThuocRowViewModel : INotifyPropertyChanged
    {
        private ComboItem? _loThuocDaChon;
        public ComboItem? LoThuocDaChon
        {
            get => _loThuocDaChon;
            set { _loThuocDaChon = value; OnPropertyChanged(); }
        }

        private string? _lyDoThanhLy;
        public string? LyDoThanhLy
        {
            get => _lyDoThanhLy;
            set { _lyDoThanhLy = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    public class NhapThuocNhaCCRowViewModel : INotifyPropertyChanged
    {
        private ComboItem? _thuocDaChon;
        public ComboItem? ThuocDaChon
        {
            get => _thuocDaChon;
            set { _thuocDaChon = value; OnPropertyChanged(); }
        }

        private string? _soLo;
        public string? SoLo
        {
            get => _soLo;
            set { _soLo = value; OnPropertyChanged(); }
        }

        private DateTime? _hanDung;
        public DateTime? HanDung
        {
            get => _hanDung;
            set { _hanDung = value; OnPropertyChanged(); }
        }

        private decimal _donGia;
        public decimal DonGia
        {
            get => _donGia;
            set { _donGia = value; OnPropertyChanged(); }
        }

        private int _soLuong;
        public int SoLuong
        {
            get => _soLuong;
            set { _soLuong = value; OnPropertyChanged(); }
        }

        private decimal _soTienPhatSinh;
        public decimal SoTienPhatSinh
        {
            get => _soTienPhatSinh;
            set { _soTienPhatSinh = value; OnPropertyChanged(); }
        }

        private string? _ghiChu;
        public string? GhiChu
        {
            get => _ghiChu;
            set { _ghiChu = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? n = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
    public class PhieuDuTruRowViewModel : INotifyPropertyChanged
    {
        private ComboItem? _thuocDaChon;
        public ComboItem? ThuocDaChon { get => _thuocDaChon; set { _thuocDaChon = value; OnPropertyChanged(); } }

        private int _soLuong;
        public int SoLuong { get => _soLuong; set { _soLuong = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? n = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
    public class KiemKeRowViewModel : INotifyPropertyChanged
    {
        private ComboItem? _loThuocDaChon;
        public ComboItem? LoThuocDaChon { get => _loThuocDaChon; set { _loThuocDaChon = value; OnPropertyChanged(); } }

        private DateTime? _hanDung;
        public DateTime? HanDung { get => _hanDung; set { _hanDung = value; OnPropertyChanged(); } }

        private int _soLuongTruoc;
        public int SoLuongTruoc { get => _soLuongTruoc; set { _soLuongTruoc = value; OnPropertyChanged(); } }

        private int _soLuongThucTe;
        public int SoLuongThucTe { get => _soLuongThucTe; set { _soLuongThucTe = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? n = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }

}
