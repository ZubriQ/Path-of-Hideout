using PathOfHideout.HideoutMover.Utilities;

namespace PathOfHideout.Helpers;

public static class StatusTextHelper
{
    public static string GetStatusMessage(HideoutMoveStatus status)
    {
        return status switch
        {
            HideoutMoveStatus.Success => "decorations moved",
            HideoutMoveStatus.Fail => "decorations were not moved",
            HideoutMoveStatus.FileNotFound => "hideout file not found",
            HideoutMoveStatus.FileParseFailed => "could not load hideout file",
            HideoutMoveStatus.FileEmpty => "hideout file was empty",
            _ => string.Empty
        };
    }
}
