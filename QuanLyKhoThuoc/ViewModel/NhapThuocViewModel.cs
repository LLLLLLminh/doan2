using Class;
using DataAccess_System;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Xml.Linq;
using Windows;

namespace Windows.ViewModel
{
    public class NhapThuocViewModel : INotifyPropertyChanged
    {
        // Combo sources
        public ObservableCollection<ComboItem> ComboBoxSoPhieuItems { get; } = new();
        public ObservableCollection<ComboItem> ComboBoxKhoItems { get; } = new();
        public ObservableCollection<ComboItem> ComboBoxNguoiNhanItems { get; } = new();
        public ObservableCollection<ComboItem> ComboBoxLoThuocItems { get; } = new();

        // Grid rows
        public ObservableCollection<NhapThuocRowViewModel> GridRows { get; } = new();

        // Selected items / properties shown in view
        private ComboItem? _selectedSoPhieu;
        public ComboItem? SelectedSoPhieu
        {
            get => _selectedSoPhieu;
            set
            {
                if (_selectedSoPhieu != value)
                {
                    _selectedSoPhieu = value;
                    OnPropertyChanged();

                    // notify commands that depend on SelectedSoPhieu
                    (UpdateCommand as RelayCommand)?.RaiseCanExecuteChanged();
                    (DeleteCommand as RelayCommand)?.RaiseCanExecuteChanged();
                    (ConfirmCommand as RelayCommand)?.RaiseCanExecuteChanged();
                    (PrintReportCommand as RelayCommand)?.RaiseCanExecuteChanged();

                    // only update details if we actually have a selection
                    if (_selectedSoPhieu != null)
                        UpdateDetailsFromSelectedPhieu();
                    else
                    {
                        // clear view fields
                        SelectedDonViGiao = null;
                        SelectedDonViNhan = null;
                        SelectedNguoiNhan = null;
                        DonViGiao = DonViNhan = NguoiNhan = DienGiai = string.Empty;
                        GridRows.Clear();
                    }
                }
            }
        }

        private ComboItem? _selectedDonViGiao;
        public ComboItem? SelectedDonViGiao
        {
            get => _selectedDonViGiao;
            set
            {
                if (_selectedDonViGiao != value)
                {
                    _selectedDonViGiao = value;
                    OnPropertyChanged();
                    if (_selectedDonViGiao != null) UpdateDetailsFromSelectedKho();
                }
            }
        }

        private ComboItem? _selectedDonViNhan;
        public ComboItem? SelectedDonViNhan
        {
            get => _selectedDonViNhan;
            set
            {
                if (_selectedDonViNhan != value)
                {
                    _selectedDonViNhan = value;
                    OnPropertyChanged();
                }
            }
        }

        private ComboItem? _selectedNguoiNhan;
        public ComboItem? SelectedNguoiNhan
        {
            get => _selectedNguoiNhan;
            set
            {
                if (_selectedNguoiNhan != value)
                {
                    _selectedNguoiNhan = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _donViGiao = string.Empty;
        public string DonViGiao { get => _donViGiao; set { _donViGiao = value; OnPropertyChanged(); } }

        private string _donViNhan = string.Empty;
        public string DonViNhan { get => _donViNhan; set { _donViNhan = value; OnPropertyChanged(); } }

        private string _nguoiNhan = string.Empty;
        public string NguoiNhan { get => _nguoiNhan; set { _nguoiNhan = value; OnPropertyChanged(); } }

        private string _dienGiai = string.Empty;
        public string DienGiai { get => _dienGiai; set { _dienGiai = value; OnPropertyChanged(); } }

        private bool _isTrangThaiConfirmed;
        public bool IsTrangThaiConfirmed { get => _isTrangThaiConfirmed; set { _isTrangThaiConfirmed = value; OnPropertyChanged(); } }

        private bool _isLoaiPhieu2;
        public bool IsLoaiPhieu2 { get => _isLoaiPhieu2; set { _isLoaiPhieu2 = value; OnPropertyChanged(); } }

        private int _selectedTabIndex;
        public int SelectedTabIndex { get => _selectedTabIndex; set { _selectedTabIndex = value; OnPropertyChanged(); } }

        // Commands
        public ICommand AddRowCommand { get; }
        public ICommand DeleteRowCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ConfirmCommand { get; }
        public ICommand PrintReportCommand { get; }
        public ICommand TabCommand { get; }

        public NhapThuocViewModel()
        {
            // Sample data initialization (keep or replace with real data load)
            DataTable dt = ComboBoxLoader.LoadComboBox("DangNhap");
            foreach (DataRow dr in dt.Rows)
            {
                ComboBoxNguoiNhanItems.Add(new ComboItem((int)dr["User_ID"], dr["Username"].ToString()));
            }
            dt = ComboBoxLoader.LoadComboBox("DM_Kho");
            foreach (DataRow dr in dt.Rows)
            {
                ComboBoxKhoItems.Add(new ComboItem((int)dr["Kho_ID"], dr["TenKho"].ToString()));
            }
            

            LoadComboSoPhieu();

            // default row
            GridRows.Add(new NhapThuocRowViewModel { LoThuocDaChon = ComboBoxLoThuocItems.FirstOrDefault(), DonGia = 0m, SoLuong = 0 });

            // commands
            AddRowCommand = new RelayCommand(_ => GridRows.Add(new NhapThuocRowViewModel { LoThuocDaChon = ComboBoxLoThuocItems.FirstOrDefault(), DonGia = 0m, SoLuong = 1 }));
            DeleteRowCommand = new RelayCommand(param =>
            {
                if (param is NhapThuocRowViewModel row && GridRows.Contains(row))
                    GridRows.Remove(row);
                else if (GridRows.Any())
                    GridRows.RemoveAt(GridRows.Count - 1);
            });

            AddCommand = new RelayCommand(_ => AddNewPhieu());
            UpdateCommand = new RelayCommand(_ => UpdatePhieu(), _ => SelectedSoPhieu != null);
            DeleteCommand = new RelayCommand(_ => DeletePhieu(), _ => SelectedSoPhieu != null);
            TabCommand = new RelayCommand(_ => Tab());

            ConfirmCommand = new RelayCommand(_ => ConfirmSelectedPhieu(), _ => SelectedSoPhieu != null && !IsTrangThaiConfirmed);
            PrintReportCommand = new RelayCommand(_ => PrintReport(), _ => SelectedSoPhieu != null);
        }
        private void UpdateDetailsFromSelectedKho()
        {
            ComboBoxLoThuocItems.Clear();
            DataTable dt = ComboBoxLoader.LoadComboBox("DM_LoThuoc_TheoKho", SelectedDonViGiao.Id.ToString());
            foreach (DataRow dr in dt.Rows)
            {
                ComboBoxLoThuocItems.Add(new ComboItem((int)dr["LoThuoc_ID"], dr["SoLo"].ToString(), (int)dr["SoLuongTon"], dr["TenThuoc"].ToString()));
            }
        }
        public void LoadComboSoPhieu()
        {
            ComboBoxSoPhieuItems.Clear();
            DataTable dt = ComboBoxLoader.LoadComboBox("PhieuNhap");
            foreach (DataRow dr in dt.Rows)
            {
                ComboBoxSoPhieuItems.Add(new ComboItem((int)dr["Phieu_ID"], dr["SoPhieu"].ToString()));
            }
        }

        private void UpdateDetailsFromSelectedPhieu()
        {
            if (SelectedSoPhieu == null)
                return;

            var phieuNhap = new PhieuNhap();
            phieuNhap.GetByPhieu_ID(SelectedSoPhieu.Id);

            // Find matching ComboItem objects (may be null)
            SelectedDonViGiao = ComboBoxKhoItems.FirstOrDefault(x => x.Id == phieuNhap.DonViGiao_ID);
            SelectedDonViNhan = ComboBoxKhoItems.FirstOrDefault(x => x.Id == phieuNhap.DonViNhan_ID);
            SelectedNguoiNhan = ComboBoxNguoiNhanItems.FirstOrDefault(x => x.Id == phieuNhap.NguoiNhan_ID);

            // Populate display strings (fallback to id -> string)
            DonViGiao = SelectedDonViGiao?.Name ?? phieuNhap.DonViGiao_ID.ToString();
            DonViNhan = SelectedDonViNhan?.Name ?? phieuNhap.DonViNhan_ID.ToString();
            NguoiNhan = SelectedNguoiNhan?.Name ?? phieuNhap.NguoiNhan_ID.ToString();

            DienGiai = phieuNhap.DienGiai ?? string.Empty;
            IsTrangThaiConfirmed = (phieuNhap.TrangThai == 1);

            // load details using the selected SO PHIEU id (safer than depending on phieuNhap.Phieu_ID)
            LoadGrid(SelectedSoPhieu.Id);
        }

        public void LoadGrid(int PhieuNhap_ID)
        {
            GridRows.Clear();

            if (PhieuNhap_ID <= 0)
                return;

            DataTable dt = new PhieuNhap_Detail().GetByPhieu_ID(PhieuNhap_ID);
            foreach (DataRow dr in dt.Rows)
            {
                var row = new NhapThuocRowViewModel
                {
                    LoThuocDaChon = ComboBoxLoThuocItems.FirstOrDefault(x => x.Id == Convert.ToInt32(dr["LoThuoc_ID"])),
                    SoLuong = Convert.ToInt32(dr["SoLuong"]),
                    DonGia = Convert.ToDecimal(dr["DonGia"])
                };
                GridRows.Add(row);
            }
        }

        private void AddNewPhieu()
        {
            var phieuNhap = new PhieuNhap();
            phieuNhap.SoPhieu = "Nhap " + DateTime.Now.ToString();
            phieuNhap.LoaiPhieu = IsLoaiPhieu2 ? 0 : 1;
            phieuNhap.DonViGiao_ID = SelectedDonViGiao?.Id ?? -1;
            phieuNhap.DonViNhan_ID = SelectedDonViNhan?.Id ?? -1;
            phieuNhap.NguoiNhan_ID = SelectedNguoiNhan?.Id ?? -1;
            phieuNhap.DienGiai = DienGiai;
            int newPhieuID = phieuNhap.Add();
            if (newPhieuID > 0)
            {
                foreach (var row in GridRows)
                {
                    var detail = new PhieuNhap_Detail
                    {
                        LoThuoc_ID = row.LoThuocDaChon?.Id ?? -1,
                        SoLuong = row.SoLuong,
                        DonGia = (int)row.DonGia
                    };
                    detail.Add(newPhieuID, SelectedDonViGiao?.Id ?? -1, SelectedDonViNhan?.Id ?? -1);
                }

                // refresh list and select the new item so the DataGrid and Delete command update
                LoadComboSoPhieu();
                SelectedSoPhieu = ComboBoxSoPhieuItems.FirstOrDefault(x => x.Id == newPhieuID);

                // raise can execute for commands depending on selection
                (UpdateCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (DeleteCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (ConfirmCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (PrintReportCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
            var thongBao = new ThongBao("Taọ phiếu thành công!");
            thongBao.Show();
        }

        private void UpdatePhieu()
        {
            // placeholder update logic
            if (SelectedSoPhieu == null)
                return;
            var phieuNhap = new PhieuNhap();
            phieuNhap.SoPhieu = "Nhap " + DateTime.Now.ToString();
            phieuNhap.LoaiPhieu = IsLoaiPhieu2 ? 0 : 1;
            phieuNhap.DonViGiao_ID = SelectedDonViGiao?.Id ?? -1;
            phieuNhap.DonViNhan_ID = SelectedDonViNhan?.Id ?? -1;
            phieuNhap.NguoiNhan_ID = SelectedNguoiNhan?.Id ?? -1;
            phieuNhap.DienGiai = DienGiai;
            int newPhieuID = phieuNhap.Update(SelectedSoPhieu.Id);

            var thongBao = new ThongBao("Cập nhật phiếu thành công!");
            thongBao.Show();
        }

        private void DeletePhieu()
        {
            if (SelectedSoPhieu != null)
            {
                var phieuNhap = new PhieuNhap();
                phieuNhap.Delete(SelectedSoPhieu.Id);
                var phieuNhapDetail = new PhieuNhap_Detail();
                phieuNhapDetail.DeleteByPhieu_ID(SelectedSoPhieu.Id, SelectedDonViGiao?.Id ?? -1, SelectedDonViNhan?.Id ?? -1);
                LoadComboSoPhieu();
                SelectedSoPhieu = null;
                var thongBao = new ThongBao("Xóa phiếu thành công!");
                thongBao.Show();
            }
            else
            {
                var thongBao = new ThongBao("Hãy chọn số phiếu!");
                thongBao.Show();
            }
        }

        private void ConfirmSelectedPhieu()
        {
            if (SelectedSoPhieu != null)
            {
                var phieuNhap = new PhieuNhap();
                phieuNhap.Confirm(SelectedSoPhieu.Id);

                var thongBao = new ThongBao("Xác nhận phiếu thành công!");
                thongBao.Show();
                IsTrangThaiConfirmed = true;
            }
            else 
            {
                var thongBao = new ThongBao("Hãy chọn số phiếu!");
                thongBao.Show();
            }
        }

        private async void PrintReport()
        {
            try
            {
                string reportName = (SelectedSoPhieu?.Name ?? "Unknown").Replace("/", "").Replace(":", "");
                await ReportSaver.DownloadReportPdf(
                    phieuId: SelectedSoPhieu?.Id ?? -1,
                    reportPath: "/PhieuNhap",
                    savePath: $"{DatabaseHelper.GetReportFolder()}//PhieuNhap_{reportName}.pdf");

                var thongBao = new ThongBao("In phiếu thành công!");
                thongBao.Show();
            }
            catch (Exception ex)
            {
                var thongBao = new ThongBao("Lỗi khi in phiếu: " + ex.Message);
                thongBao.Show();
            }

        }
        private void Tab()
        {
            SelectedTabIndex = (SelectedTabIndex + 1) % 2;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}