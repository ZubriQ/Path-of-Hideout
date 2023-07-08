using Microsoft.Win32;

namespace PathOfHideout.Helpers;

public class FileHandler
{
    public FileStatus SelectHideoutFile()
    {
        OpenFileDialog openDialog = GetOpenFileDialog();
        var result = openDialog.ShowDialog();

        if (result == true)
        {
            return FileStatus.SourceSelected;
        }
        return FileStatus.SourceSelectionCancelled;
    }

    private static OpenFileDialog GetOpenFileDialog()
    {
        return new OpenFileDialog()
        {
            Title = "Choose Hideout File Path",
            Filter = "Hideout Files (*.hideout)|*.hideout"
        };
    }

    public (FileStatus, string) SelectDestinationPath()
    {
        SaveFileDialog destinationDialog = GetSaveFileDialog();
        var result = destinationDialog.ShowDialog();

        if (result == true)
        {
            return (FileStatus.DestinationSelected, destinationDialog.FileName);
        }
        return (FileStatus.DestinationSelectionCancelled, string.Empty);
    }

    private static SaveFileDialog GetSaveFileDialog()
    {
        return new SaveFileDialog()
        {
            Title = "Choose Hideout File Path Destination",
            Filter = "Hideout Files (*.hideout)|*.hideout"
        };
    }
}
