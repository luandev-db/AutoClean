// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using Wpf.Ui.Appearance;
using Wpf.Ui.Interop;

namespace AutoClean.App.Views.Windows;

/// <summary>
/// Interaction logic for SettingsWindow.xaml
/// </summary>
public partial class SettingsWindow
{
    public SettingsWindow()
    {
        InitializeComponent();

        Wpf.Ui.Appearance.Background.Apply(
            this,
            BackgroundType.Mica);

        // You can use native methods, but remember that their use is not safe.
        
    }
}
