﻿// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using AutoClean.App.Models;
using AutoClean.App.Services;
using AutoClean.App.Services.Contracts;
using AutoClean.App.ViewModels;
using AutoClean.App.Views.Pages;
using AutoClean.App.Views.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wpf.Ui.Mvvm.Contracts;
using Wpf.Ui.Mvvm.Services;

namespace AutoClean.App;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    private static readonly IHost _host = Host
        .CreateDefaultBuilder()
        .ConfigureAppConfiguration(c => { c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)); })
        .ConfigureServices((context, services) =>
        
        {
            // App Host
            services.AddHostedService<ApplicationHostService>();

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

            services.AddScoped<WindowsPage>();
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

            // Configuration
            services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
        }).Build();

    /// <summary>
    /// Gets registered service.
    /// </summary>
    /// <typeparam name="T">Type of the service to get.</typeparam>
    /// <returns>Instance of the service or <see langword="null"/>.</returns>
    public static T GetService<T>()
        where T : class
    {
        return _host.Services.GetService(typeof(T)) as T;
    }

    /// <summary>
    /// Occurs when the application is loading.
    /// </summary>
    private async void OnStartup(object sender, StartupEventArgs e)
    {
        await _host.StartAsync();
    }

    /// <summary>
    /// Occurs when the application is closing.
    /// </summary>
    private async void OnExit(object sender, ExitEventArgs e)
    {
        await _host.StopAsync();

        _host.Dispose();
    }

    /// <summary>
    /// Occurs when an exception is thrown by an application but not handled.
    /// </summary>
    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
    }
}
