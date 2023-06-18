namespace PathOfHideout.Utilities;

public class InitialParameters
{
    public string Source { get; private set; }
    public string Destination { get; private set; }
    public int XCoordinate { get; private set; }
    public int YCoordinate { get; private set; }
    
    /// <summary>
    /// Sets initial parameters before any changes.
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