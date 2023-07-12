using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using PathOfHideout.MVVM.View;
using System;
using PathOfHideout.Core;
using PathOfHideout.MVVM.ViewModel;
using PathOfHideout.Services.Navigation;

namespace PathOfHideout
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ServiceProvider _serviceProvider = null!;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddSingleton(provider => new MainWindow()
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<HelpViewModel>();
            services.AddSingleton<Func<Type, ViewModel>>(
                serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        public static ViewModel GetStartupView()
        {
            return _serviceProvider.GetRequiredService<HomeViewModel>();
        }
    }
}
