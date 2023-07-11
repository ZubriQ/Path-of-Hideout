using PathOfHideout.Helpers;
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
    private readonly DecorationMover _mover = new();
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
        (FileStatus status, var newFileName) = _fileHandler.SelectHideoutFile();
        TxtStatus.Text = FileStatusResponseHelper.GetStatusMessage(status);
        UpdateSourceAndDestinationPaths(newFileName);
    }

    private void UpdateSourceAndDestinationPaths(string path)
    {
        if (!string.IsNullOrEmpty(path))
        {
            TxtHideoutSourceFilePath.Text = path;
            TxtHideoutDestinationPath.Text = path;
        }
    }

    private void BtnSaveAs_Click(object sender, RoutedEventArgs e)
    {
        (FileStatus status, var newFileName) = _fileHandler.SelectDestinationPath();
        TxtStatus.Text = FileStatusResponseHelper.GetStatusMessage(status);
        UpdateDestinationPath(newFileName);
    }

    private void UpdateDestinationPath(string path)
    {
        if (!string.IsNullOrEmpty(path))
        {
            TxtHideoutDestinationPath.Text = path;
        }
    }

    private void BtnMoveDecorations_Click(object sender, RoutedEventArgs e)
    {
        string sourceFilePath = TxtHideoutSourceFilePath.Text;
        int xCoordinate = int.Parse(TxtXCoordinate.Text);
        int yCoordinate = int.Parse(TxtYCoordinate.Text);
        string destinationPath = TxtHideoutDestinationPath.Text;

        var response = _mover.MoveDecorations(sourceFilePath, xCoordinate, yCoordinate, destinationPath);
        TxtStatus.Text = FileStatusResponseHelper.GetStatusMessage(response);
    }

    private void MoveDecorationsValidation_TextChanged(object sender, TextChangedEventArgs e)
    {
        BtnMoveDecorations.IsEnabled = ValidateMoveDecorationsInput();
    }

    private bool ValidateMoveDecorationsInput()
    {
        string xCoordinate = TxtXCoordinate.Text;
        string yCoordinate = TxtYCoordinate.Text;
        string sourceFilePath = TxtHideoutSourceFilePath.Text;
        string destinationPath = TxtHideoutDestinationPath.Text;

        bool isXyCoordinateValid = XyCoordinateValidator.IsValid(xCoordinate, yCoordinate);
        bool isSourceFilePathValid = FilePathValidator.IsValid(sourceFilePath);
        bool isDestinationPathValid = FilePathValidator.IsValid(destinationPath);

        return isXyCoordinateValid && isSourceFilePathValid && isDestinationPathValid;
    }

    #region Default UI behaviour

    private void BrdTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }

    #endregion
}
