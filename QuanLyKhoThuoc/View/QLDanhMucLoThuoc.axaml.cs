using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Class;
using DataAccess_System;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Dynamic;

namespace Windows
{
    public partial class QLDanhMucLoThuoc : Window
    {
        int curSelectedID;
        DataTable dt;
        public ObservableCollection<dynamic> Rows { get; set; } = new();
        public ObservableCollection<string?> ComboBoxItems { get; } = new ObservableCollection<string?>();
        public QLDanhMucLoThuoc()
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
            dt = new DM_LoThuoc().GetDataTable(filterValue);
            grdDMThuoc.IsVisible = true;
            Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                var obj = new DM_LoThuoc()
                {
                    LoThuoc_ID = (int)dr["LoThuoc_ID"],
                    SoLo = dr["SoLo"].ToString(),
                    Thuoc_ID = (int)dr["Thuoc_ID"],
                    Ten_Thuoc = dr["Ten_Thuoc"].ToString(),
                    HanDung = (DateTime)dr["HanDung"],
                    GhiChu = dr["GhiChu"].ToString()
                };

                Rows.Add(obj);
            }

        }

    }
}
