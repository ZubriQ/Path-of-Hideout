using Microsoft.Win32;
using PathOfHideout.HideoutMover.Services;
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
        OpenFileDialog openDialog = new OpenFileDialog();
        openDialog.Filter = "Hideout Files (*.hideout)|*.hideout|All Files (*.*)|*.*";
        openDialog.Title = "Choose Hideout File Path";

        var result = openDialog.ShowDialog();
        if (result == true)
        {
            string filePath = openDialog.FileName;
            TxtHideoutSourceFilePath.Text = filePath;
            TxtHideoutDestinationPath.Text = filePath;
        }
    }

    private void BtnSaveAs_Click(object sender, RoutedEventArgs e)
    {
        // TODO: if source is empty, select source first

        SaveFileDialog destinationDialog = new SaveFileDialog();
        destinationDialog.Filter = "Hideout Files (*.hideout)|*.hideout";
        destinationDialog.Title = "Choose Hideout File Path Destination";

        var result = destinationDialog.ShowDialog();
        if (result == true)
        {
            TxtHideoutDestinationPath.Text = destinationDialog.FileName;
        }
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

    private void MoveDecorationsValidation_TextChanged(object sender, TextChangedEventArgs e)
    {
        BtnMoveDecorations.IsEnabled =
            XyCoordinateValidator.IsValid(TxtXCoordinate.Text, TxtYCoordinate.Text)
            && !string.IsNullOrWhiteSpace(TxtHideoutSourceFilePath.Text)
            && !string.IsNullOrWhiteSpace(TxtHideoutDestinationPath.Text);
    }
}
