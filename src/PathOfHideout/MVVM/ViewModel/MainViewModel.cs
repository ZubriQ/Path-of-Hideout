using PathOfHideout.Core;
using PathOfHideout.Services.Navigation;

namespace PathOfHideout.MVVM.ViewModel;

public sealed class MainViewModel : Core.ViewModel
{
    private INavigationService _navigation = null!;
    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand NavigateToHomeCommand { get; set; }
    public RelayCommand NavigateToSettingsCommand { get; set; }
    public RelayCommand NavigateToHelpCommand { get; set; }

    public MainViewModel(INavigationService service)
    {
        Navigation = service;

        NavigateToHomeCommand = new RelayCommand(
            execute: _ => Navigation.NavigateTo<HomeViewModel>(),
            canExecute: _ => true);
        NavigateToSettingsCommand = new RelayCommand(
            execute: _ => Navigation.NavigateTo<SettingsViewModel>(),
            canExecute: _ => true);
        NavigateToHelpCommand = new RelayCommand(
            execute: _ => Navigation.NavigateTo<HelpViewModel>(),
            canExecute: _ => true);
    }
}
