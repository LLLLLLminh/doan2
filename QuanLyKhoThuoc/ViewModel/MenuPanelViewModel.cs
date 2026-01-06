using System;
using System.Windows.Input;
using Avalonia.Controls;


namespace Windows.ViewModel;

public class MenuPanelViewModel : ViewModelBase
{
    internal Window? Owner { get; set; }
    private bool _isMenuOpen;
    public bool IsMenuOpen
    {
        get => _isMenuOpen;
        set => SetProperty(ref _isMenuOpen, value);
    }

    private bool _isNhapXuat;
    public bool IsNhapXuat
    {
        get => _isNhapXuat;
        set => SetProperty(ref _isNhapXuat, value);
    }

    private bool _isQLThuoc;
    public bool IsQLThuoc
    {
        get => _isQLThuoc;
        set => SetProperty(ref _isQLThuoc, value);
    }

    private bool _isQLDM;
    public bool IsQLDM
    {
        get => _isQLDM;
        set => SetProperty(ref _isQLDM, value);
    }

    // Constructor
    public MenuPanelViewModel()
    {
        OpenMenuCommand = new RelayCommand(_ => ToggleMenu());
        OpenSubMenuCommand = new RelayCommand(param => ToggleSubMenu(param?.ToString()));

        NhapThuocCommand = new RelayCommand(_ => OpenWindow(new NhapThuoc()));
        NhapThuocNhaCCCommand = new RelayCommand(_ => OpenWindow(new NhapThuocNhaCC()));
        XuatThuocCommand = new RelayCommand(_ => OpenWindow(new XuatThuoc()));
        ThanhLyThuocCommand = new RelayCommand(_ => OpenWindow(new ThanhLyThuoc()));
        HoanTraThuocCommand = new RelayCommand(_ => OpenWindow(new HoanTraThuoc()));
        DuTruCommand = new RelayCommand(_ => OpenWindow(new PhieuDuTru()));
        KiemKeCommand = new RelayCommand(_ => OpenWindow(new PhieuKiemKe()));
        QLDanhMucThuocCommand = new RelayCommand(_ => OpenWindow(new QLDanhMucThuoc()));
        QLDanhMucKhoCommand = new RelayCommand(_ => OpenWindow(new QLDanhMucKho()));
        QLDanhMucLoThuocCommand = new RelayCommand(_ => OpenWindow(new QLDanhMucLoThuoc()));
        QLDanhMucDangNhapCommand = new RelayCommand(_ => OpenWindow(new QLDanhMucDangNhap()));

        ExitCommand = new RelayCommand(_ => Exit());
    }

    // Commands
    public ICommand OpenMenuCommand { get; }
    public ICommand OpenSubMenuCommand { get; }

    public ICommand NhapThuocCommand { get; }
    public ICommand NhapThuocNhaCCCommand { get; }
    public ICommand XuatThuocCommand { get; }
    public ICommand ThanhLyThuocCommand { get; }
    public ICommand HoanTraThuocCommand { get; }
    public ICommand DuTruCommand { get; }
    public ICommand KiemKeCommand { get; }
    public ICommand QLDanhMucThuocCommand { get; }
    public ICommand QLDanhMucKhoCommand { get; }

    public ICommand QLDanhMucDangNhapCommand { get; }
    public ICommand QLDanhMucLoThuocCommand { get; }

    public ICommand ExitCommand { get; }

    private void ToggleMenu()
    {
        IsMenuOpen = !IsMenuOpen;
    }

    private void Exit()
    {
        Environment.Exit(0);
    }

    private void ToggleSubMenu(string? name)
    {
        switch (name)
        {
            case "NhapXuat":
                IsNhapXuat = !IsNhapXuat;
                IsQLThuoc = false;
                IsQLDM = false;
                break;

            case "QLThuoc":
                IsQLThuoc = !IsQLThuoc;
                IsNhapXuat = false;
                IsQLDM = false;
                break;

            case "QLDM":
                IsQLDM = !IsQLDM;
                IsNhapXuat = false;
                IsQLThuoc = false;
                break;
        }
    }

    private void OpenWindow(Window window)
    {
        window.Show();
        if (Owner is not null) Owner.Close();
    }
}