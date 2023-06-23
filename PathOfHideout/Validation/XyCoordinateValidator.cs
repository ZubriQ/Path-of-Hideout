using System.Text.RegularExpressions;

namespace PathOfHideout.Validation;

public static class XyCoordinateValidator
{
    private static readonly Regex _regex = new(@"^-?\d+(\.\d+)?$");

    public static bool IsValid(string inputX, string inputY) => _regex.IsMatch(inputX) && _regex.IsMatch(inputY);
}
