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
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Mvvm.Services;

namespace AutoClean.App.ViewModels
{
    public partial class ToggleSwitchViewModel : ObservableObject
    {
         
        public ToggleSwitchViewModel(ISnackbarService snackbarService)
        {
            _snackbarService = snackbarService;
        }
        #region Cortana
        private readonly ISnackbarService _snackbarService;
        private bool _cortanaCommand;
        public bool CortanaCommand
        {
            get { return _cortanaCommand; }
            set
            {
                SetProperty(ref _cortanaCommand, value);
                if (value)
                {
                    CortanaSnackbar();
                }
                else
                {
                    CortanaSnackbar();

                }
            }
        }
        
        private async Task CortanaSnackbar()
        {
            if (CortanaCommand == true)
            {
                await _snackbarService.ShowAsync("Cortana desativada", "Cortana desativada com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Cortana Ativada", "Serviços em segundo plano podem prejudicar o desempenho.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }
        }
        #endregion

        #region Xbox
        private bool _xboxCommand;
        public bool XboxCommand
        {
            get { return _xboxCommand; }
            set
            {
                SetProperty(ref _xboxCommand, value);
                if (value)
                {
                    XboxSnackbar();
                }
                else
                {
                    XboxSnackbar();

                }


            }
        }

        private async Task XboxSnackbar()
        {
            if (XboxCommand == true)
            {
                await _snackbarService.ShowAsync("Xbox desativada", "Xbox desativada com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Xbox Ativada", "Serviços em segundo plano podem prejudicar o desempenho.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
    }

}
