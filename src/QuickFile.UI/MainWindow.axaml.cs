using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace QuickFile.UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void ButtonOnClick(object? sender, RoutedEventArgs e)
    {
        string filename = name.Text;
        string fileExtension = extension.Text;
    }
}
