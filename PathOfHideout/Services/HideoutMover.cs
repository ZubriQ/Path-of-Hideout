using Newtonsoft.Json;
using PathOfHideout.Models;
using PathOfHideout.Utilities;
using System.Collections.Generic;
using System.IO;

namespace PathOfHideout.Services;

public class HideoutMover
{
    private InitialParameters _initialParameters = null!;
    
    private Hideout? _hideout;

    public void MoveDecorations(string source, int xChange, int yChange, string? destination = "")
    {
        _initialParameters = new InitialParameters(source, xChange, yChange, destination);
        ReadHideoutFileAndUpdateDecorationsCoordinates();
        SaveUpdatedHideout();
    }

    private void ReadHideoutFileAndUpdateDecorationsCoordinates()
    {
        string hideoutJson = File.ReadAllText(_initialParameters.Source);
        if (string.IsNullOrWhiteSpace(hideoutJson))
        {
            return;
        }
        
        _hideout = JsonConvert.DeserializeObject<Hideout>(hideoutJson);
        UpdateDecorations();
    }

    private void UpdateDecorations()
    {
        if (_hideout?.Decorations.Count > 0)
        {
            foreach (var decoration in _hideout.Decorations)
            {
                UpdateDecorationXyValues(decoration);
            }
        }
    }

    private void UpdateDecorationXyValues(KeyValuePair<string, Decoration> decoration)
    {
        var xValue = decoration.Value.X + _initialParameters.XCoordinate;
        decoration.Value.X = (xValue is < Constants.XLimitMax and > Constants.XLimitMin) ?
            xValue : decoration.Value.X;

        var yValue = decoration.Value.Y + _initialParameters.YCoordinate;
        decoration.Value.Y = (yValue is < Constants.YLimitMax and > Constants.YLimitMin) ?
            yValue : decoration.Value.Y;
    }

    private void SaveUpdatedHideout()
    {
        var updatedHideoutJson = JsonConvert.SerializeObject(_hideout);
        File.WriteAllText(_initialParameters.Destination, updatedHideoutJson);
    }
}
