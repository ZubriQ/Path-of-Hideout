using Newtonsoft.Json;
using PathOfHideout.Models;
using PathOfHideout.Utilities;
using System.Collections.Generic;
using System.IO;

namespace PathOfHideout.Services
{
    public class HideoutMover
    {
        private string _source = null!;
        private string _destination = null!;
        private int xCoordinate = 0;
        private int yCoordinate = 0;

        private Hideout? _hideout;

        public HideoutMover() { }

        public void MoveDecorations(string source, int xChange, int yChange, string? destination = "")
        {
            SetParameters(source, xChange, yChange, destination);
            ReadFileAndUpdateDecorationCoordinates();
            SaveUpdatedHideout();
        }

        /// <summary>
        /// Sets parameters before changes.
        /// </summary>
        /// <param name="source">Hideout file to update.</param>
        /// <param name="xChange">How much to change the x coordinate.</param>
        /// <param name="yChange">How much to change the y coordinate.</param>
        /// <param name="destination">Save to another directory, if provided.</param>
        private void SetParameters(string source, int xChange, int yChange, string? destination = "")
        {
            _source = source;
            if (string.IsNullOrWhiteSpace(destination))
            {
                _destination = _source;
            }
            else
            {
                _destination = destination;
            }

            xCoordinate = xChange;
            yCoordinate = yChange;
        }

        private void ReadFileAndUpdateDecorationCoordinates()
        {
            string hideoutJson = File.ReadAllText(_source);
            if (!string.IsNullOrWhiteSpace(hideoutJson))
            {
                _hideout = JsonConvert.DeserializeObject<Hideout>(hideoutJson);
                UpdateDecorations();
            }
        }

        private void UpdateDecorations()
        {
            if (_hideout is not null && _hideout.Decorations.Count > 0)
            {
                foreach (var decoration in _hideout.Decorations)
                {
                    MoveDecoration(decoration);
                }
            }
        }

        private void MoveDecoration(KeyValuePair<string, Decoration> decoration)
        {
            var xValue = decoration.Value.X + xCoordinate;
            decoration.Value.X = (xValue < Constants.X_LIMIT_MAX
                               && xValue > Constants.X_LIMIT_MIN) ? xValue : decoration.Value.X;

            var yValue = decoration.Value.Y + yCoordinate;
            decoration.Value.Y = (yValue < Constants.Y_LIMIT_MAX
                               && yValue > Constants.Y_LIMIT_MIN) ? yValue : decoration.Value.Y;
        }

        private void SaveUpdatedHideout()
        {
            string updatedHideoutJson = JsonConvert.SerializeObject(_hideout);
            File.WriteAllText(_destination, updatedHideoutJson);
        }
    }
}
