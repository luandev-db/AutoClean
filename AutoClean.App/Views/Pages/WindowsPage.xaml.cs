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

namespace AutoClean.App.Views.Pages;

/// <summary>
/// Interaction logic for Input.xaml
/// </summary>
public partial class WindowsPage
{
    private readonly ISnackbarService _snackbarService;

    private readonly IDialogControl _dialogControl;


    public WindowsPage(ISnackbarService snackbarService, IDialogService dialogService)
    {
        InitializeComponent();

        _snackbarService = snackbarService;
        _dialogControl = dialogService.GetDialogControl();
    }
    public void DisableCortana(object sender, RoutedEventArgs e)
    {
        
        ToggleSwitch toggleSwitch = sender as ToggleSwitch;
        string checkState;
        var Search = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search", true);
        var WindowsSearch = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", true);


        if (toggleSwitch.IsChecked == true)
        {
            checkState = "Cortana Desativada";
            Search.SetValue("AllowCortana", 0);
            Search.SetValue("BingSearchEnabled", 0);
            Search.SetValue("CortanaConsent", 0);
            WindowsSearch.SetValue("AllowCloudSearch", 0);
           
            
        }
        else
        {
            checkState = "Cortana Ativada";
            Search.SetValue("AllowCortana", 1);
            Search.SetValue("BingSearchEnabled", 1);
            Search.SetValue("CortanaConsent", 1);
            WindowsSearch.SetValue("AllowCloudSearch", 1);
          

        }

        _snackbarService.Show(string.Format(checkState, SymbolRegular.FoodCake24, ControlAppearance.Success));
    }



    public void ToggleSwitch_Checked(object sender, RoutedEventArgs e)
    {
       
        
        
    }
}
       

     
