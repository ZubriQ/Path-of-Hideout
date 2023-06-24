using Newtonsoft.Json;
using PathOfHideout.HideoutMover.Models;
using PathOfHideout.HideoutMover.Utilities;
using System.Collections.Generic;
using System.IO;

namespace PathOfHideout.HideoutMover.Services;

public class DecorationMover
{
    private InitialParameters _initialParameters = null!;
    private Hideout? _hideout;

    public MoverStatus MoveDecorations(string source, int xChange, int yChange, string? destination = "")
    {
        _initialParameters = new InitialParameters(source, xChange, yChange, destination);

        var response = ReadHideoutFileAndUpdateDecorationsCoordinates();
        SaveUpdatedHideout();

        return response;
    }

    private MoverStatus ReadHideoutFileAndUpdateDecorationsCoordinates()
    {
        string hideoutJson;

        if (!File.Exists(_initialParameters.Source))
        {
            return MoverStatus.FileNotFound;
        }

        hideoutJson = File.ReadAllText(_initialParameters.Source);
        if (string.IsNullOrEmpty(hideoutJson))
        {
            return MoverStatus.FileEmpty;
        }

        try
        {
            _hideout = JsonConvert.DeserializeObject<Hideout>(hideoutJson);
        }
        catch
        {
            return MoverStatus.FileParseFailed;
        }

        UpdateDecorations();
        return MoverStatus.Success;
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
        decoration.Value.X = xValue is < Constants.XLimitMax and > Constants.XLimitMin ?
            xValue : decoration.Value.X;

        var yValue = decoration.Value.Y + _initialParameters.YCoordinate;
        decoration.Value.Y = yValue is < Constants.YLimitMax and > Constants.YLimitMin ?
            yValue : decoration.Value.Y;
    }

    private void SaveUpdatedHideout()
    {
        var updatedHideoutJson = JsonConvert.SerializeObject(_hideout);
        File.WriteAllText(_initialParameters.Destination, updatedHideoutJson);
    }
}
