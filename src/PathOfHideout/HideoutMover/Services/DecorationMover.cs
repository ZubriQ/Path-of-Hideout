﻿using Newtonsoft.Json;
using PathOfHideout.HideoutMover.Models;
using PathOfHideout.HideoutMover.Utilities;
using System.Collections.Generic;
using System.IO;

namespace PathOfHideout.HideoutMover.Services;

public sealed class DecorationMover
{
    private InitialParameters _parameters = null!;
    private Hideout? _hideout;

    public HideoutMoveStatus MoveDecorations(
        string source,
        int xChange,
        int yChange,
        string? destination = "")
    {
        _parameters = new InitialParameters(source, xChange, yChange, destination);

        var response = ReadHideoutFileAndUpdateDecorationsCoordinates();
        SaveUpdatedHideout();

        return response;
    }

    private HideoutMoveStatus ReadHideoutFileAndUpdateDecorationsCoordinates()
    {
        string hideoutJson;

        if (!File.Exists(_parameters.Source))
        {
            return HideoutMoveStatus.FileNotFound;
        }

        hideoutJson = File.ReadAllText(_parameters.Source);
        if (string.IsNullOrEmpty(hideoutJson))
        {
            return HideoutMoveStatus.FileEmpty;
        }

        try
        {
            _hideout = JsonConvert.DeserializeObject<Hideout>(hideoutJson);
        }
        catch
        {
            return HideoutMoveStatus.FileParseFailed;
        }

        UpdateDecorations();
        return HideoutMoveStatus.Success;
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
        var xValue = decoration.Value.X + _parameters.XCoordinate;
        decoration.Value.X = xValue is < Constants.XLimitMax and > Constants.XLimitMin ?
            xValue : decoration.Value.X;

        var yValue = decoration.Value.Y + _parameters.YCoordinate;
        decoration.Value.Y = yValue is < Constants.YLimitMax and > Constants.YLimitMin ?
            yValue : decoration.Value.Y;
    }

    private void SaveUpdatedHideout()
    {
        var updatedHideoutJson = JsonConvert.SerializeObject(_hideout);
        File.WriteAllText(_parameters.Destination, updatedHideoutJson);
    }
}
