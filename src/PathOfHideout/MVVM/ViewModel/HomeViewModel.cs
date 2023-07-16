using PathOfHideout.Core.Settings;

namespace PathOfHideout.MVVM.ViewModel;

public class HomeViewModel : Core.ViewModel
{
    #region Properties

    private string _sourcePathPlaceholder = ViewSettings.SourcePathPlaceholder;
    public string SourcePathPlaceholder
    {
        get => _sourcePathPlaceholder;
        set
        {
            _sourcePathPlaceholder = value;
            OnPropertyChanged();
        }
    }

    private string _sourcePath = string.Empty;
    public string SourcePath
    {
        get => _sourcePath;
        set
        {
            _sourcePath = value;
            OnPropertyChanged();
            UpdateSourcePathPlaceholder();
        }
    }

    private string _destinationPathPlaceholder = ViewSettings.DestinationPathPlaceholder;
    public string DestinationPathPlaceholder
    {
        get => _destinationPathPlaceholder;
        set
        {
            _destinationPathPlaceholder = value;
            OnPropertyChanged();
        }
    }

    private string _destinationPath = string.Empty;
    public string DestinationPath
    {
        get => _destinationPath;
        set
        {
            _destinationPath = value;
            OnPropertyChanged();
            UpdateDestinationPathPlaceholder();
        }
    }

    private string _xValuePlaceholder = ViewSettings.XValuePlaceholder;
    public string XValuePlaceholder
    {
        get => _xValuePlaceholder;
        set
        {
            _xValuePlaceholder = value;
            OnPropertyChanged();
        }
    }

    private string _xValue = string.Empty;
    public string XValue
    {
        get => _xValue;
        set
        {
            if (_xValue != value)
            {
                _xValue = value;
                OnPropertyChanged();
                UpdateXValuePlaceholder();
            }
        }
    }

    private string _yValuePlaceholder = ViewSettings.YValuePlaceholder;
    public string YValuePlaceholder
    {
        get => _yValuePlaceholder;
        set
        {
            _yValuePlaceholder = value;
            OnPropertyChanged();
        }
    }

    private string _yValue = string.Empty;
    public string YValue
    {
        get => _yValue;
        set
        {
            if (_yValue != value)
            {
                _yValue = value;
                OnPropertyChanged();
                UpdateYValuePlaceholder();
            }
        }
    }

    private string _statusText = string.Empty;
    public string StatusText
    {
        get => _statusText;
        set
        {
            _statusText = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region Additional methods

    private void UpdateSourcePathPlaceholder()
    {
        SourcePathPlaceholder = string.IsNullOrEmpty(SourcePath)
            ? ViewSettings.SourcePathPlaceholder
            : string.Empty;
    }

    private void UpdateDestinationPathPlaceholder()
    {
        DestinationPathPlaceholder = string.IsNullOrEmpty(DestinationPath)
            ? ViewSettings.DestinationPathPlaceholder
            : string.Empty;
    }

    private void UpdateXValuePlaceholder()
    {
        XValuePlaceholder = string.IsNullOrEmpty(XValue)
            ? ViewSettings.XValuePlaceholder
            : string.Empty;
    }

    private void UpdateYValuePlaceholder()
    {
        YValuePlaceholder = string.IsNullOrEmpty(YValue)
            ? ViewSettings.YValuePlaceholder
            : string.Empty;
    }

    #endregion
}
