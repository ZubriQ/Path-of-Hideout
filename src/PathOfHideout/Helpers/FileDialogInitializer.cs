using Microsoft.Win32;

namespace PathOfHideout.Helpers;

internal static class FileDialogInitializer
{
    internal static OpenFileDialog GetOpenFileDialog()
    {
        return new OpenFileDialog()
        {
            Title = "Choose Hideout File Path",
            Filter = "Hideout Files (*.hideout)|*.hideout"
        };
    }

    internal static SaveFileDialog GetSaveFileDialog()
    {
        return new SaveFileDialog()
        {
            Title = "Choose Hideout File Path Destination",
            Filter = "Hideout Files (*.hideout)|*.hideout"
        };
    }
}
