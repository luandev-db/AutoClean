using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Win32;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace AutoClean.App.ViewModels
{
    public class ToggleSwitchViewModel : ObservableObject
    {
#pragma warning disable CS0649 // Campo "ToggleSwitchViewModel._snackbarService" nunca é atribuído e sempre terá seu valor padrão null
        private readonly ISnackbarService _snackbarService;
#pragma warning restore CS0649 // Campo "ToggleSwitchViewModel._snackbarService" nunca é atribuído e sempre terá seu valor padrão null

#pragma warning disable CS0169 // O campo "ToggleSwitchViewModel._dialogControl" nunca é usado
        private readonly IDialogControl _dialogControl;
#pragma warning restore CS0169 // O campo "ToggleSwitchViewModel._dialogControl" nunca é usado



        public void ToggleSwitch(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            string checkState;
            var Search = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search", true);
            var WindowsSearch = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", true);

            if (!toggleSwitch.IsChecked.HasValue)
                checkState = "Indeterminate";
            else
            {
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


                }

                _snackbarService.Show(string.Format(checkState, SymbolRegular.FoodCake24, ControlAppearance.Primary));
            }
        }
    }
}
