using PathOfHideout.HideoutMover.Utilities;
using System;

namespace PathOfHideout.Helpers;

internal static class FileStatusResponseHelper
{
    internal static string GetStatusMessage(HideoutMoveStatus status)
    {
        return status switch
        {
            HideoutMoveStatus.Success => "decorations moved (" + DateTime.Now.ToString("HH:mm:ss:fff") + ")",
            HideoutMoveStatus.Fail => "decorations were not moved",
            HideoutMoveStatus.FileNotFound => "hideout file not found",
            HideoutMoveStatus.FileParseFailed => "could not load hideout file",
            HideoutMoveStatus.FileEmpty => "hideout file was empty",
            HideoutMoveStatus.FileWriteAccessDenied => "write access to the path denied",
            _ => string.Empty
        };
    }

    internal static string GetStatusMessage(FileStatus status)
    {
        return status switch
        {
            FileStatus.SourceSelected => "hideout file found",
            FileStatus.SourceSelectionCancelled => "file selection cancelled",
            FileStatus.DestinationSelected => "hideout file destination selected",
            FileStatus.DestinationSelectionCancelled => "destination selection cancelled",
            _ => string.Empty
        };
    }
}
