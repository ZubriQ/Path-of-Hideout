using Microsoft.Extensions.DependencyInjection;
using PathOfHideout.Core;
using PathOfHideout.MVVM.ViewModel;
using System;

namespace PathOfHideout.Services.Navigation;

public class NavigationService : ObservableObject, INavigationService
{
    public readonly Func<Type, ViewModel> _viewModelFactory;
    private ViewModel _currentView;

    public ViewModel CurrentView
    {
        get => _currentView;
        private set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public NavigationService(Func<Type, ViewModel> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
        _currentView = App.GetStartupView();
    }

    public void NavigateTo<TViewModel>() where TViewModel : ViewModel
    {
        CurrentView = _viewModelFactory.Invoke(typeof(TViewModel));
    }
}
