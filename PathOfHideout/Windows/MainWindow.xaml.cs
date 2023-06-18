using PathOfHideout.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PathOfHideout.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly HideoutMover _hideoutMover = new();

    public MainWindow()
    {
        InitializeComponent();

        // Simply stub test data
        TxtHideoutFilePath.Text = @"F:\hideout.hideout";
        TxtXCoordinate.Text = "10";
        TxtYCoordinate.Text = "10";
    }

    private void BtnMoveDecorations_Click(object sender, RoutedEventArgs e)
    {
        _hideoutMover.MoveDecorations(
            TxtHideoutFilePath.Text, 
            int.Parse(TxtXCoordinate.Text), 
            int.Parse(TxtYCoordinate.Text));
    }
}
