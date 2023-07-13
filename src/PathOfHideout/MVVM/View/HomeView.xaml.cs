using PathOfHideout.Helpers;
using PathOfHideout.HideoutMover.Services;
using PathOfHideout.Validation;
using System.Windows;
using System.Windows.Controls;

namespace PathOfHideout.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private readonly DecorationMover _mover = new();
        private readonly FileHandler _fileHandler = new();

        public HomeView()
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
            UpdateDestinationPath(newFileName);
        }

        private void UpdateDestinationPath(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                TxtHideoutDestinationPath.Text = path;
            }
        }

        private void BtnProceedDecorations_Click(object sender, RoutedEventArgs e)
        {
            string sourceFilePath = TxtHideoutSourceFilePath.Text;
            int xCoordinate = int.Parse(TxtXCoordinate.Text);
            int yCoordinate = int.Parse(TxtYCoordinate.Text);
            string destinationPath = TxtHideoutDestinationPath.Text;

            var response = _mover.MoveDecorations(sourceFilePath, xCoordinate, yCoordinate, destinationPath);
        }

        private void MoveDecorationsValidation_TextChanged(object sender, TextChangedEventArgs e)
        {
            BtnProceedDecorations.IsEnabled = ValidateMoveDecorationsInput();
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
    }
}
