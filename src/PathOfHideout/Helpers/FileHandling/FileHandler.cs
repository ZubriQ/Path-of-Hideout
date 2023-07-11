using Microsoft.Win32;

namespace PathOfHideout.Helpers;

internal sealed class FileHandler
{
    private readonly OpenFileDialog _openDialog;
    private readonly SaveFileDialog _saveDialog;

    public FileHandler()
    {
        _openDialog = FileDialogInitializer.GetOpenFileDialog();
        _saveDialog = FileDialogInitializer.GetSaveFileDialog();
    }

    public (FileStatus, string) SelectHideoutFile()
    {
        var result = _openDialog.ShowDialog();
        if (result == true)
        {
            return (FileStatus.SourceSelected, _openDialog.FileName);
        }
        return (FileStatus.SourceSelectionCancelled, string.Empty);
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
