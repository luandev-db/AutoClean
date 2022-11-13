// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Windows.Input;
using AutoClean.App.Services.Contracts;
using AutoClean.App.Views.Pages;
using AutoClean.App.Views.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace AutoClean.App.ViewModels;

public class DashboardViewModel : ObservableObject, INavigationAware
{
    private readonly INavigationService _navigationService;

    private readonly ITestWindowService _testWindowService;

    private ICommand _navigateCommand;

    private ICommand _openWindowCommand;

    public ICommand NavigateCommand => _navigateCommand ??= new RelayCommand<string>(OnNavigate);

    public ICommand OpenWindowCommand => _openWindowCommand ??= new RelayCommand<string>(OnOpenWindow);

    public DashboardViewModel(INavigationService navigationService, ITestWindowService testWindowService)
    {
        _navigationService = navigationService;
        _testWindowService = testWindowService;
    }

    public void OnNavigatedTo()
    {
        System.Diagnostics.Debug.WriteLine($"INFO | {typeof(DashboardViewModel)} navigated", "AutoClean.App");
    }

    public void OnNavigatedFrom()
    {
        System.Diagnostics.Debug.WriteLine($"INFO | {typeof(DashboardViewModel)} navigated", "AutoClean.App");
    }

    private void OnNavigate(string parameter)
    {
        switch (parameter)
        {
            case "navigate_to_input":
                _navigationService.Navigate(typeof(Input));
                return;

            case "navigate_to_controls":
                _navigationService.Navigate(typeof(Controls));
                return;

            case "navigate_to_colors":
                _navigationService.Navigate(typeof(Colors));
                return;

            case "navigate_to_icons":
                _navigationService.Navigate(typeof(Icons));
                return;
        }
    }

    private void OnOpenWindow(string parameter)
    {
        switch (parameter)
        {
            case "open_window_store":
                _testWindowService.Show<StoreWindow>();
                return;

            case "open_window_manager":
                _testWindowService.Show<TaskManagerWindow>();
                return;

            case "open_window_editor":
                _testWindowService.Show<EditorWindow>();
                return;

            case "open_window_settings":
                _testWindowService.Show<SettingsWindow>();
                return;

            case "open_window_experimental":
                _testWindowService.Show<ExperimentalWindow>();
                return;
        }
    }
}

