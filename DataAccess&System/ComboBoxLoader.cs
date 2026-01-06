using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using Avalonia;
using Avalonia.Controls;

namespace DataAccess_System
{
    public static class ComboBoxLoader
    {
        public static DataTable LoadComboBox(string? DataGroup, string? AdditionalPara = "")
        {
            SqlParameter p1 = new SqlParameter("@DataGroup", DataGroup);
            SqlParameter p2 = new SqlParameter("@AdditionalPara", AdditionalPara);
            DataTable dt = DatabaseHelper.ExecuteDataTable(
                    "sp_ComboData",
                    CommandType.StoredProcedure,
                    p1, p2
                );
            return dt;
        }
        public static int GetComboData(ComboBox cbo)
        {
            if (cbo.SelectedItem is ComboItem)
            {
                ComboItem selectedItem = (ComboItem)cbo.SelectedItem;
                return selectedItem.Id;
            }
            return -1;
        }
        public static void SetComboData(ComboBox cbo, ObservableCollection<ComboItem> comboItems, int ID)
        {
            ComboItem selectedItem;
            foreach (ComboItem item in comboItems)
            {
                if (item.Id == ID)
                {
                    selectedItem = item;
                    cbo.SelectedItem = selectedItem;
                    return;
                }
            }
            cbo.SelectedItem = null;
        }
    }
}
