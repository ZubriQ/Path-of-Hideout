using System.Text.RegularExpressions;

namespace PathOfHideout.Validation;

public static class FilePathValidator
{
    private static readonly Regex _regex = new(@"^[A-Za-z]:\\(?:[^\\/:*?""<>|\r\n]+\\)*[^\\/:*?""<>|\r\n]+\.hideout$");

    public static bool IsValid(string path) => _regex.IsMatch(path);
}
