using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Class;
using DataAccess_System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Dynamic;

namespace Windows
{
    public partial class HoanTraThuoc : Window
    {
        int curSelectedID;
        DataTable dt;
        public ObservableCollection<dynamic> Rows { get; set; } = new();
        public ObservableCollection<ComboItem> ComboBoxSoPhieuItems { get; } = new ObservableCollection<ComboItem>();
        public ObservableCollection<ComboItem> ComboBoxNguoiNhanItems { get; } = new ObservableCollection<ComboItem>();
        public ObservableCollection<ComboItem> ComboBoxPhieuNhapItems { get; } = new ObservableCollection<ComboItem>();
        public HoanTraThuoc()
        {
            InitializeComponent();
            DataContext = this;
            dt = new DataTable();
            LoadComboData();
            LoadComboSoPhieu();
        }
        public void LoadComboData()
        {
            DataTable dt = ComboBoxLoader.LoadComboBox("DangNhap");
            foreach (DataRow dr in dt.Rows)
            {
                ComboBoxNguoiNhanItems.Add(new ComboItem((int)dr["User_ID"], dr["Username"].ToString()));
            }
        }
        public void LoadComboSoPhieu()
        {
            ComboBoxSoPhieuItems.Clear();
            DataTable dt = ComboBoxLoader.LoadComboBox("PhieuHoanTra");
            foreach (DataRow dr in dt.Rows)
            {
                ComboBoxSoPhieuItems.Add(new ComboItem((int)dr["Phieu_ID"], dr["SoPhieu"].ToString()));
            }
        }
        public void LoadComboSoPhieuNhap(object? sender, RoutedEventArgs e)
        {
            ComboBoxPhieuNhapItems.Clear();
            if (rdoLoaiPhieu1.IsChecked == true)
            {
                DataTable dt = ComboBoxLoader.LoadComboBox("PhieuNhapNhaCC");
            }
            else
            {
                DataTable dt = ComboBoxLoader.LoadComboBox("PhieuNhap");
            }
            
            foreach (DataRow dr in dt.Rows)
            {
                ComboBoxPhieuNhapItems.Add(new ComboItem((int)dr["Phieu_ID"], dr["SoPhieu"].ToString()));
            }
        }
        public int GetComboData(ComboBox cbo)
        {
            if (cbo.SelectedItem is ComboItem)
            {
                ComboItem selectedItem = (ComboItem)cbo.SelectedItem;
                return selectedItem.ID;
            }
            return -1;
        }
        public void SetComboData(ComboBox cbo, ObservableCollection<ComboItem> comboItems, int ID)
        {
            ComboItem selectedItem;
            foreach (ComboItem item in comboItems)
            {
                if (item.ID == ID)
                {
                    selectedItem = item;
                    cbo.SelectedItem = selectedItem;
                    return;
                }
            }
            cbo.SelectedItem = null;
        }
        public void Delete(object? sender, RoutedEventArgs e)
        {
            PhieuHoanTra phieuHoanTra = new PhieuHoanTra();
            phieuHoanTra.Delete(GetComboData(cboSoPhieu));
            LoadComboSoPhieu();
        }
        public void Add(object? sender, RoutedEventArgs e)
        {
            PhieuHoanTra phieuHoanTra = new PhieuHoanTra();
            GetData(phieuHoanTra);
            phieuHoanTra.NgayTao = DateTime.Now;
            phieuHoanTra.Add();
            LoadComboSoPhieu();
        }
        public void Update(object? sender, RoutedEventArgs e)
        {
            PhieuHoanTra phieuHoanTra = new PhieuHoanTra();
            GetData(phieuHoanTra);
            phieuHoanTra.NgayCapNhat = DateTime.Now;
            phieuHoanTra.Update(GetComboData(cboSoPhieu));
            LoadComboSoPhieu();
        }
        public void GetData(PhieuHoanTra phieuHoanTra)
        {
            phieuHoanTra.SoPhieu = "HoanTra " + DateTime.Now.ToString();

            if (rdoLoaiPhieu1.IsChecked == true) phieuHoanTra.LoaiPhieu = 1;
            else if (rdoLoaiPhieu2.IsChecked == true) phieuHoanTra.LoaiPhieu = 2;


            phieuHoanTra.PhieuNhap_ID = GetComboData(cboSoPhieuNhap);

            phieuHoanTra.DienGiai = txtDienGiai.Text;

        }
        public void cboSoPhieu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PhieuHoanTra phieuHoanTra = new PhieuHoanTra();
            phieuHoanTra.GetByPhieu_ID(GetComboData(cboSoPhieu));

            if (phieuHoanTra.LoaiPhieu == 1) rdoLoaiPhieu1.IsChecked = true;
            else if (phieuHoanTra.LoaiPhieu == 2) rdoLoaiPhieu2.IsChecked = true;


            SetComboData(cboSoPhieuNhap, ComboBoxPhieuNhapItems,  phieuHoanTra.PhieuNhap_ID);

            txtDienGiai.Text = phieuHoanTra.DienGiai;
        }
        public void GridSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid != null)
            {
                dynamic selectedItem = dataGrid.SelectedItem;
                if (selectedItem != null)
                {
                    curSelectedID = selectedItem.Kho_ID;
                }
            }
            
                
        }

    }
}
