using Microsoft.Win32;
using PathOfHideout.Helpers;
using PathOfHideout.HideoutMover.Services;
using PathOfHideout.HideoutMover.Utilities;
using PathOfHideout.Validation;
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

namespace PathOfHideout.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly DecorationMover _hideoutMover = new();
    private readonly FileHandler _fileHandler = new();

    public MainWindow()
    {
        InitializeComponent();
        InitializeSettings();
    }

    private void InitializeSettings()
    {
        TxtHideoutSourceFilePath.Text = @"F:\hideout.hideout";
        TxtHideoutDestinationPath.Text = @"F:\hideout.hideout";
        TxtXCoordinate.Text = "10";
        TxtYCoordinate.Text = "-10";
    }

    private void BtnFindFile_Click(object sender, RoutedEventArgs e)
    {
        var response = _fileHandler.SelectHideoutFile();
        TxtStatus.Text = FileStatusResponseHelper.GetStatusMessage(response);
    }

    private void BtnSaveAs_Click(object sender, RoutedEventArgs e)
    {
        (FileStatus status, var newFileName) = _fileHandler.SelectDestinationPath();
        TxtStatus.Text = FileStatusResponseHelper.GetStatusMessage(status);

        if (!string.IsNullOrEmpty(newFileName))
        {
            TxtHideoutDestinationPath.Text = newFileName;
        }
    }

    private void BtnMoveDecorations_Click(object sender, RoutedEventArgs e)
    {
        var response = _hideoutMover.MoveDecorations(
            TxtHideoutSourceFilePath.Text,
            int.Parse(TxtXCoordinate.Text),
            int.Parse(TxtYCoordinate.Text),
            TxtHideoutDestinationPath.Text);

        TxtStatus.Text = FileStatusResponseHelper.GetStatusMessage(response);
    }

    private void MoveDecorationsValidation_TextChanged(object sender, TextChangedEventArgs e)
    {
        BtnMoveDecorations.IsEnabled =
            XyCoordinateValidator.IsValid(TxtXCoordinate.Text, TxtYCoordinate.Text)
            && !string.IsNullOrWhiteSpace(TxtHideoutSourceFilePath.Text)
            && !string.IsNullOrWhiteSpace(TxtHideoutDestinationPath.Text);
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
