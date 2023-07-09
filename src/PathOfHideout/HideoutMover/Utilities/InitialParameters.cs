namespace PathOfHideout.HideoutMover.Utilities;

public sealed class InitialParameters
{
    public string Source { get; }
    public string Destination { get; }
    public int XCoordinate { get; }
    public int YCoordinate { get; }

    /// <summary>
    /// Sets initial parameters before updating decorations' coordinates.
    /// </summary>
    /// <param name="source">The Hideout file to update.</param>
    /// <param name="xChange">How much to change the x coordinate.</param>
    /// <param name="yChange">How much to change the y coordinate.</param>
    /// <param name="destination">Is optional. Saves to another directory, if provided.</param>
    public InitialParameters(string source, int xChange, int yChange, string? destination = "")
    {
        Source = source;
        Destination = string.IsNullOrWhiteSpace(destination) ?
            Source : Destination = destination;

        XCoordinate = xChange;
        YCoordinate = yChange;
    }
}