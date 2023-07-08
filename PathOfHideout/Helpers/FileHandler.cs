using Microsoft.Win32;

namespace PathOfHideout.Helpers;

public class FileHandler
{
    private readonly OpenFileDialog _openDialog;
    private readonly SaveFileDialog _saveDialog;

    public FileHandler()
    {
        _openDialog = InitializeOpenFileDialog();
        _saveDialog = InitializeSaveFileDialog();
    }

    private static OpenFileDialog InitializeOpenFileDialog()
    {
        return new OpenFileDialog()
        {
            Title = "Choose Hideout File Path",
            Filter = "Hideout Files (*.hideout)|*.hideout"
        };
    }

    private static SaveFileDialog InitializeSaveFileDialog()
    {
        return new SaveFileDialog()
        {
            Title = "Choose Hideout File Path Destination",
            Filter = "Hideout Files (*.hideout)|*.hideout"
        };
    }

    public FileStatus SelectHideoutFile()
    {
        var result = _openDialog.ShowDialog();
        if (result == true)
        {
            return FileStatus.SourceSelected;
        }
        return FileStatus.SourceSelectionCancelled;
    }

    public (FileStatus, string) SelectDestinationPath()
    {
        var result = _saveDialog.ShowDialog();
        if (result == true)
        {
            return (FileStatus.DestinationSelected, _saveDialog.FileName);
        }
        return (FileStatus.DestinationSelectionCancelled, string.Empty);
    }
}
