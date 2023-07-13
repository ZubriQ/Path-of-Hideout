﻿namespace PathOfHideout.MVVM.ViewModel;

public class HomeViewModel : Core.ViewModel
{
    public string SourcePath { get; set; } = string.Empty;
    public string DestinationPath { get; set; } = string.Empty;
    public string XValue { get; set; } = "15";
    public string YValue { get; set; } = "-15";
}
