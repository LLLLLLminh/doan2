using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Class;
using DataAccess_System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Dynamic;

namespace Windows
{
    public partial class QLDanhMucKho : Window
    {
        int curSelectedID;
        DataTable dt;
        public ObservableCollection<dynamic> Rows { get; set; } = new();
        public ObservableCollection<string?> ComboBoxItems { get; } = new ObservableCollection<string?>();
        public QLDanhMucKho()
        {
            InitializeComponent();
            DataContext = this;
            dt = new DataTable();
            LoadComboData();
        }
        public void LoadComboData()
        {
            DataTable dt = ComboBoxLoader.LoadComboBox("DM_Kho_LoaiKho");
            foreach (DataRow dr in dt.Rows)
            {
                ComboBoxItems.Add(dr["DViTinh"].ToString());
            }
        }
        public void LoadFromDataTableKho(object? sender, RoutedEventArgs e)
        {
            string? filterValue = Loc.Text;
            dt = new DM_Kho().GetDataTable(filterValue);
            grdDMThuoc.IsVisible = true;
            Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                var obj = new DM_Kho()
                {
                    Kho_ID = (int)dr["Kho_ID"],
                    TenKho = dr["TenKho"].ToString(),
                    QuanLyNguon = (bool)dr["QuanLyNguon"],
                    LoaiKho = dr["LoaiKho"].ToString()
                };

                Rows.Add(obj);
            }

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
                    TenKho.Text = selectedItem.TenKho;
                    QuanLyNguon.IsChecked = selectedItem.QuanLyNguon;
                    LoaiKho.SelectedItem = selectedItem.LoaiKho;
                }
            }
            
                
        }

    }
}
