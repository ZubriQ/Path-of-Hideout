using PathOfHideout.Core;

namespace PathOfHideout.Services.Navigation;

public interface INavigationService
{
    ViewModel CurrentView { get; }
    void NavigateTo<T>() where T : ViewModel;
}
