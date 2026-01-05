using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using System;

namespace Windows.Controls;

public partial class MenuPanel : UserControl
{
    public MenuPanel()
    {
        InitializeComponent();
        MenuPanelViewModel model = new MenuPanelViewModel();
        model.Owner = TopLevel.GetTopLevel(this) as Window;
        DataContext = model;
    }
}