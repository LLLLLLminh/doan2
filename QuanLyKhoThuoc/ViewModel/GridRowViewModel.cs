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
            set { _loThuocDaChon = value; _soLuongMax = _loThuocDaChon?.AdditionalValue ?? 0; TenThuoc = _loThuocDaChon?.AdditionalString; OnPropertyChanged(); }
        }

        private string? _tenThuoc;
        public string? TenThuoc
        {
            get => _tenThuoc;
            set { _tenThuoc = value; OnPropertyChanged(); }
        }

        private decimal _donGia;
        public decimal DonGia
        {
            get => _donGia;
            set
            {
                decimal newVal = value > 0 ? value : 0;
                if (_donGia != newVal)
                {
                    _donGia = newVal;
                    OnPropertyChanged();
                }
            }
        }

        private int _soLuong;
        public int SoLuong
        {
            get => _soLuong;
            set
            {
                int newVal = value > 0 ? value : 0;
                newVal = value < _soLuongMax ? newVal : _soLuongMax;
                if (_soLuong != newVal)
                {
                    _soLuong = newVal;
                    OnPropertyChanged();
                }
            }
        }

        private int _soLuongMax;
        public int SoLuongMax
        {
            get => _soLuongMax;
            set { _soLuongMax = value; OnPropertyChanged(); }
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
            set { _loThuocDaChon = value; _soLuongMax = _loThuocDaChon?.AdditionalValue ?? 0; TenThuoc = _loThuocDaChon?.AdditionalString; OnPropertyChanged(); }
        }

        private string? _tenThuoc;
        public string? TenThuoc
        {
            get => _tenThuoc;
            set { _tenThuoc = value; OnPropertyChanged(); }
        }

        private decimal _donGia;
        public decimal DonGia
        {
            get => _donGia;
            set
            {
                decimal newVal = value > 0 ? value : 0;
                if (_donGia != newVal)
                {
                    _donGia = newVal;
                    OnPropertyChanged();
                }
            }
        }

        private int _soLuong;
        public int SoLuong
        {
            get => _soLuong;
            set
            {
                int newVal = value > 0 ? value : 0;
                newVal = value < _soLuongMax ? newVal : _soLuongMax;
                if (_soLuong != newVal)
                {
                    _soLuong = newVal;
                    OnPropertyChanged();
                }
            }
        }

        private int _soLuongMax;
        public int SoLuongMax
        {
            get => _soLuongMax;
            set { _soLuongMax = value; OnPropertyChanged(); }
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
            set { _loThuocDaChon = value; _soLuongMax = _loThuocDaChon?.AdditionalValue ?? 0; TenThuoc = _loThuocDaChon?.AdditionalString; OnPropertyChanged(); }
        }

        private string? _tenThuoc;
        public string? TenThuoc
        {
            get => _tenThuoc;
            set { _tenThuoc = value; OnPropertyChanged(); }
        }

        private string? _lyDoThanhLy;
        public string? LyDoThanhLy
        {
            get => _lyDoThanhLy;
            set { _lyDoThanhLy = value; OnPropertyChanged(); }
        }

        private int _soLuongMax;
        public int SoLuongMax
        {
            get => _soLuongMax;
            set { _soLuongMax = value; OnPropertyChanged(); }
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
            set
            {
                decimal newVal = value > 0 ? value : 0;
                if (_donGia != newVal)
                {
                    _donGia = newVal;
                    OnPropertyChanged();
                }
            }
        }

        private int _soLuong;
        public int SoLuong
        {
            get => _soLuong;
            set
            {
                int newVal = value > 0 ? value : 0;
                if (_soLuong != newVal)
                {
                    _soLuong = newVal;
                    OnPropertyChanged();
                }
            }
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
        public int SoLuong 
        { 
            get => _soLuong;
            set
            {
                int newVal = value > 0 ? value : 0;
                if (_soLuong != newVal)
                {
                    _soLuong = newVal;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? n = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
    public class KiemKeRowViewModel : INotifyPropertyChanged
    {
        private ComboItem? _loThuocDaChon;
        public ComboItem? LoThuocDaChon { get => _loThuocDaChon; set { _loThuocDaChon = value; OnPropertyChanged(); } }

        private ComboItem? _thuocDaChon;
        public ComboItem? ThuocDaChon { get => _thuocDaChon; set { _thuocDaChon = value; OnPropertyChanged(); } }

        private DateTime? _hanDung;
        public DateTime? HanDung { get => _hanDung; set { _hanDung = value; OnPropertyChanged(); } }

        private int _soLuongTruoc;
        public int SoLuongTruoc { get => _soLuongTruoc; set { _soLuongTruoc = value; OnPropertyChanged(); } }

        private int _soLuongThucTe;
        public int SoLuongThucTe
        {
            get => _soLuongThucTe;
            set
            {
                int newVal = value > 0 ? value : 0;
                if (_soLuongThucTe != newVal)
                {
                    _soLuongThucTe = newVal;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? n = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }

}
