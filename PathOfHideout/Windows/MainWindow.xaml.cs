using PathOfHideout.HideoutMover.Services;
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
    private readonly DecorationMover _hideoutMover = new();

    public MainWindow()
    {
        InitializeComponent();
        InitializeSettings();
    }

    private void InitializeSettings()
    {
        // Right now it's a stub.
        // TODO: Proper initial settings

        TxtHideoutSourceFilePath.Text = @"F:\hideout.hideout";
        TxtHideoutDestinationPath.Text = @"F:\hideout.hideout";
        TxtXCoordinate.Text = "10";
        TxtYCoordinate.Text = "-10";
    }

    private void BtnFindFile_Click(object sender, RoutedEventArgs e)
    {

    }

    private void BtnSaveAs_Click(object sender, RoutedEventArgs e)
    {

    }

    private void BtnMoveDecorations_Click(object sender, RoutedEventArgs e)
    {
        // TODO: Validation

        _hideoutMover.MoveDecorations(
            TxtHideoutSourceFilePath.Text,
            int.Parse(TxtXCoordinate.Text),
            int.Parse(TxtYCoordinate.Text),
            TxtHideoutDestinationPath.Text);
    }

    #region Default UI behaviour

    private void BrdTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }

    private void BtnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void BtnClose_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    #endregion
}
