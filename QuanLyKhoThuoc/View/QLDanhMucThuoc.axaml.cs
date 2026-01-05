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
    public partial class QLDanhMucThuoc : Window
    {
        int curSelectedID;
        DataTable dt;
        public ObservableCollection<dynamic> Rows { get; set; } = new();
        public ObservableCollection<string?> ComboBoxItems { get; } = new ObservableCollection<string?>();
        public QLDanhMucThuoc()
        {
            InitializeComponent();
            DataContext = this;
            dt = new DataTable();
            LoadComboData();
        }
        public void LoadComboData()
        {
            DataTable dt = ComboBoxLoader.LoadComboBox("DM_Thuoc_DViTinh");
            foreach (DataRow dr in dt.Rows)
            {
                ComboBoxItems.Add(dr["DViTinh"].ToString());
            }
        }
        public void LoadFromDataTableThuoc(object? sender, RoutedEventArgs e)
        {
            string? filterValue = Loc.Text;
            dt = new DM_Thuoc().GetDataTable(filterValue);
            grdDMThuoc.IsVisible = true;
            Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                var obj = new DM_Thuoc()
                {
                    Thuoc_ID = (int)dr["Thuoc_ID"],
                    TenDuoc = dr["TenDuoc"].ToString(),
                    DonViTinh = dr["DonViTinh"].ToString()
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
                    curSelectedID = selectedItem.Thuoc_ID;
                    TenDuoc.Text = selectedItem.TenDuoc;
                    DonViTinh.SelectedItem = selectedItem.DonViTinh;
                }
            }
            
                
        }

    }
}
