using Avalonia.Controls;
using Class;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataAccess_System;

namespace Windows;

public class NhapThuocViewMocel : ViewModelBase
{
    public ObservableCollection<PhieuNhap_Detail> GridRows { get; set; } = new();
    public ObservableCollection<ComboItem> ComboBoxSoPhieuItems { get; } = new ObservableCollection<ComboItem>();
    public ObservableCollection<ComboItem> ComboBoxNguoiNhanItems { get; } = new ObservableCollection<ComboItem>();
    public ObservableCollection<ComboItem> ComboBoxKhoItems { get; } = new ObservableCollection<ComboItem>();
    public ObservableCollection<ComboItem> ComboBoxThuocItems { get; } = new ObservableCollection<ComboItem>();

    // Constructor
    public NhapThuocViewMocel()
    {

    }

    
}