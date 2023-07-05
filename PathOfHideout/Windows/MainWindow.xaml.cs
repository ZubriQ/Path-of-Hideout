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

    #region Button Find File

    private void BtnFindFile_Click(object sender, RoutedEventArgs e)
    {
        var response = SelectHideoutFile();
        UpdateStatusText(response);
    }

    private void UpdateStatusText(FileStatus status)
    {
        if (status == FileStatus.SourceSelected)
        {
            TxtStatus.Text = "hideout file found successfully";
        }
        else
        {
            TxtStatus.Text = "hideout file path not set";
        }
    }

    private FileStatus SelectHideoutFile()
    {
        OpenFileDialog openDialog = GetOpenFileDialog();
        var result = openDialog.ShowDialog();
        if (result == true)
        {
            UpdateTextBoxesPaths(openDialog.FileName);
            return FileStatus.SourceSelected;
        }
        else
        {
            return FileStatus.SourceSelected;
        }
    }

    private OpenFileDialog GetOpenFileDialog()
    {
        return new OpenFileDialog()
        {
            Title = "Choose Hideout File Path",
            Filter = "Hideout Files (*.hideout)|*.hideout"
        };
    }

    private void UpdateTextBoxesPaths(string filePath)
    {
        TxtHideoutSourceFilePath.Text = filePath;
        TxtHideoutDestinationPath.Text = filePath;
    }

    #endregion

    private void BtnSaveAs_Click(object sender, RoutedEventArgs e)
    {
        // TODO: if source is empty, select source first
        var response = SelectSaveAsPath();

        if (response == FileStatus.DestinationSelected)
        {
            TxtStatus.Text = "destination selected successfully";
        }
    }

    private FileStatus SelectSaveAsPath()
    {
        SaveFileDialog destinationDialog = new SaveFileDialog();
        destinationDialog.Filter = "Hideout Files (*.hideout)|*.hideout";
        destinationDialog.Title = "Choose Hideout File Path Destination";

        var result = destinationDialog.ShowDialog();
        if (result == true)
        {
            TxtHideoutDestinationPath.Text = destinationDialog.FileName;
            return FileStatus.DestinationSelected;
        }
        else
        {
            return FileStatus.DestinationNotSelected;
        }
    }

    private void BtnMoveDecorations_Click(object sender, RoutedEventArgs e)
    {
        // TODO: Validation

        var response = _hideoutMover.MoveDecorations(
            TxtHideoutSourceFilePath.Text,
            int.Parse(TxtXCoordinate.Text),
            int.Parse(TxtYCoordinate.Text),
            TxtHideoutDestinationPath.Text);

        UpdateStatusText(response);
    }

    private void UpdateStatusText(HideoutMoveStatus status)
    {
        TxtStatus.Text = StatusTextHelper.GetStatusMessage(status);
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
