// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Collections.Generic;
using AutoClean.App.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Wpf.Ui.Common.Interfaces;

namespace AutoClean.App.ViewModels;

public class DebugViewModel : ObservableObject, INavigationAware
{
    private bool _dataInitialized = false;

    private IEnumerable<Hardware> _hardwareCollection = new Hardware[] { };

    public IEnumerable<Hardware> HardwareCollection
    {
        get => _hardwareCollection;
        set => SetProperty(ref _hardwareCollection, value);
    }

    public void OnNavigatedTo()
    {
        if (!_dataInitialized)
            InitializeData();
    }

    public void OnNavigatedFrom()
    {
    }

    private void InitializeData()
    {
        var hardwareCollection = new List<Hardware>();

        hardwareCollection.Add(new Hardware()
        {
            Name = "CPU",
            Value = 89,
            Min = 29,
            Max = 92
        });

        hardwareCollection.Add(new Hardware()
        {
            Name = "GPU",
            Value = 59,
            Min = 22,
            Max = 78
        });

        HardwareCollection = hardwareCollection;

        _dataInitialized = true;
    }
}
