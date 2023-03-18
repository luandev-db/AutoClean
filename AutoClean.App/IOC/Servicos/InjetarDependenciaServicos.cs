using AutoClean.App.Services.Contracts;
using AutoClean.App.Services;
using AutoClean.App.ViewModels;
using AutoClean.App.Views.Pages;
using AutoClean.App.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using Wpf.Ui.Mvvm.Contracts;
using Wpf.Ui.Mvvm.Services;

namespace AutoClean.App.IOC.Servicos
{
    public static class InjetarDependenciaServicos
    {
        public static void RegistrarServicos(this IServiceCollection services)
        {
            // Theme manipulation
            services.AddSingleton<IThemeService, ThemeService>();

            // Taskbar manipulation
            services.AddSingleton<ITaskBarService, TaskBarService>();

            // Snackbar service
            services.AddSingleton<ISnackbarService, SnackbarService>();

            // Dialog service
            services.AddSingleton<IDialogService, DialogService>();

            // Tray icon
            services.AddSingleton<INotifyIconService, CustomNotifyIconService>();

            // Page resolver service
            services.AddSingleton<IPageService, PageService>();

            // Page resolver service
            services.AddSingleton<ITestWindowService, TestWindowService>();

            // Service containing navigation, same as INavigationWindow... but without window
            services.AddSingleton<INavigationService, NavigationService>();

            // Main window container with navigation
            services.AddScoped<INavigationWindow, Views.Container>();
            services.AddScoped<ContainerViewModel>();

            // Views and ViewModels
            services.AddScoped<Dashboard>();
            services.AddScoped<DashboardViewModel>();

            services.AddScoped<ExperimentalDashboard>();
            services.AddScoped<ExperimentalViewModel>();

            services.AddScoped<Controls>();
            services.AddScoped<ToggleSwitchViewModel>();

            services.AddScoped<Menus>();

            services.AddScoped<Colors>();
            services.AddScoped<ColorsViewModel>();

            services.AddScoped<Debug>();
            services.AddScoped<DebugViewModel>();

            services.AddScoped<Buttons>();
            services.AddScoped<ButtonsViewModel>();

            services.AddScoped<Data>();
            services.AddScoped<DataViewModel>();

            services.AddScoped<Input>();
            services.AddScoped<InputViewModel>();

            services.AddScoped<Icons>();
            services.AddScoped<IconsViewModel>();

            // Test windows
            services.AddTransient<TaskManagerWindow>();
            services.AddTransient<TaskManagerViewModel>();

            services.AddTransient<EditorWindow>();
            services.AddTransient<SettingsWindow>();
            services.AddTransient<StoreWindow>();
            services.AddTransient<ExperimentalWindow>();
        }
    }
}
