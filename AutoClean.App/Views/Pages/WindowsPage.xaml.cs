// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AutoClean.App.ViewModels;
using Microsoft.Win32;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;
using AutoClean.App.Services;
using System.IO;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Mvvm.Services;

namespace AutoClean.App.Views.Pages;

/// <summary>
/// Interaction logic for Input.xaml
/// </summary>
public partial class WindowsPage
{
    private readonly ISnackbarService _snackbarService;
    public WindowsPage(ISnackbarService snackbarService)
    {
        InitializeComponent();
        DataContext = new ToggleSwitchViewModel(snackbarService);
        _snackbarService = snackbarService;
    }

    public void ToggleSwitch_Checked(object sender, RoutedEventArgs e)
    {
    }
}
