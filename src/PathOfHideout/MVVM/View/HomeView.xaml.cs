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
        }

        private void BtnFindFile_Click(object sender, RoutedEventArgs e)
        {
            (FileStatus status, var newFileName) = _fileHandler.SelectHideoutFile();
            UpdateSourceAndDestinationPaths(newFileName);
            TxtStatus.Text = FileStatusResponseHelper.GetStatusMessage(status);
        }

        private void UpdateSourceAndDestinationPaths(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                TxtHideoutSourceFilePath.Text = path;
                TxtHideoutDestinationFilePath.Text = path;
            }
        }

        private void BtnSaveAs_Click(object sender, RoutedEventArgs e)
        {
            (FileStatus status, var newFileName) = _fileHandler.SelectDestinationPath();
            UpdateDestinationPath(newFileName);
            TxtStatus.Text = FileStatusResponseHelper.GetStatusMessage(status);
        }

        private void UpdateDestinationPath(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                TxtHideoutDestinationFilePath.Text = path;
            }
        }

        private void BtnProceedDecorations_Click(object sender, RoutedEventArgs e)
        {
            string sourceFilePath = TxtHideoutSourceFilePath.Text;
            int xCoordinate = int.Parse(TxtXCoordinate.Text);
            int yCoordinate = int.Parse(TxtYCoordinate.Text);
            string destinationPath = TxtHideoutDestinationFilePath.Text;

            var status = _mover.MoveDecorations(sourceFilePath, xCoordinate, yCoordinate, destinationPath);
            TxtStatus.Text = FileStatusResponseHelper.GetStatusMessage(status);
        }

        private void InputValidation_TextChanged(object sender, TextChangedEventArgs e)
        {
            string xCoordinate = TxtXCoordinate.Text;
            string yCoordinate = TxtYCoordinate.Text;
            string sourceFilePath = TxtHideoutSourceFilePath.Text;
            string destinationPath = TxtHideoutDestinationFilePath.Text;

            bool isXyCoordinatesValid = XyCoordinateValidator.IsValid(xCoordinate, yCoordinate);
            bool isSourceFilePathValid = FilePathValidator.IsValid(sourceFilePath);
            bool isDestinationPathValid = FilePathValidator.IsValid(destinationPath);

            BtnProceedDecorations.IsEnabled = isXyCoordinatesValid && isSourceFilePathValid && isDestinationPathValid;
            TxtHideoutDestinationFilePath.IsEnabled = isSourceFilePathValid;
            BtnSaveAs.IsEnabled = isSourceFilePathValid;
        }
    }
}
