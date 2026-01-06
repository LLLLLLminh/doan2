using System.ComponentModel;
using System.Runtime.CompilerServices;
using DataAccess_System;

namespace Windows.ViewModel
{
    public class ThuocRowViewModel : INotifyPropertyChanged
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
}
