﻿// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoClean.App.Models.Icons;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Common.Interfaces;

namespace AutoClean.App.ViewModels;

public class IconsViewModel : ObservableObject, INavigationAware
{
    private bool _dataInitialized = false;

    private List<DisplayableIcon> _iconsCollection = new();

    private IEnumerable<DisplayableIcon> _filteredIconsCollection = new DisplayableIcon[] { };

    private IEnumerable<string> _iconNames = new string[] { };

    private Wpf.Ui.Common.SymbolRegular _selectedSymbol = Wpf.Ui.Common.SymbolRegular.Empty;

    private string _selectedSymbolName = string.Empty;

    private string _selectedSymbolCharacter = string.Empty;

    private string _codeBlock = string.Empty;

    private string _searchText = string.Empty;

    private ICommand _selectIconCommand;

    public List<DisplayableIcon> IconsCollection
    {
        get => _iconsCollection;
        set => SetProperty(ref _iconsCollection, value);
    }

    public IEnumerable<DisplayableIcon> FilteredIconsCollection
    {
        get => _filteredIconsCollection;
        set => SetProperty(ref _filteredIconsCollection, value);
    }

    public IEnumerable<string> IconNames
    {
        get => _iconNames;
        set => SetProperty(ref _iconNames, value);
    }

    public Wpf.Ui.Common.SymbolRegular SelectedSymbol
    {
        get => _selectedSymbol;
        set => SetProperty(ref _selectedSymbol, value);
    }

    public string SelectedSymbolName
    {
        get => _selectedSymbolName;
        set => SetProperty(ref _selectedSymbolName, value);
    }

    public string SelectedSymbolCharacter
    {
        get => _selectedSymbolCharacter;
        set => SetProperty(ref _selectedSymbolCharacter, value);
    }

    public string CodeBlock
    {
        get => _codeBlock;
        set => SetProperty(ref _codeBlock, value);
    }

    public string SearchText
    {
        get => _searchText;
        set
        {
            SetProperty(ref _searchText, value);
            UpdateSearchResults(SearchText);
        }
    }

    public ICommand SelectIconCommand => _selectIconCommand ??= new RelayCommand<int>(OnIconSelected);

    public void OnNavigatedTo()
    {
        if (!_dataInitialized)
            InitializeData();
    }

    public void OnNavigatedFrom()
    {
    }

    private void OnIconSelected(int iconId)
    {
        UpdateSymbolData(iconId);
    }

    private void UpdateSymbolData(int symbolId)
    {
        if (IconsCollection.Count - 1 < symbolId)
            return;

        SelectedSymbol = IconsCollection[symbolId].Icon;
        SelectedSymbolCharacter = "\\u" + IconsCollection[symbolId].Code;
        SelectedSymbolName = IconsCollection[symbolId].Name;
        CodeBlock = "<ui:SymbolIcon Symbol=\"" + IconsCollection[symbolId].Name + "\"/>";
    }

    private void UpdateSearchResults(string searchText)
    {
        Task.Run(() =>
        {
            if (string.IsNullOrEmpty(searchText))
            {
                FilteredIconsCollection = IconsCollection;

                return true;
            }

            var formattedText = searchText.ToLower().Trim();

            FilteredIconsCollection = IconsCollection
                .Where(icon => icon.Name.ToLower().Contains(formattedText)).ToArray();

            return true;
        });
    }

    private void InitializeData()
    {
        Task.Run(() =>
        {
            var id = 0;
            var names = Enum.GetNames(typeof(Wpf.Ui.Common.SymbolRegular));
            var icons = new List<DisplayableIcon>();

            names = names.OrderBy(n => n).ToArray();

            foreach (var iconName in names)
            {
                var icon = Wpf.Ui.Common.Glyph.Parse(iconName);

                icons.Add(new DisplayableIcon
                {
                    Id = id++,
                    Name = iconName,
                    Icon = icon,
                    Symbol = ((char)icon).ToString(),
                    Code = ((int)icon).ToString("X4")
                });
            }

            IconsCollection = icons;
            FilteredIconsCollection = icons;
            IconNames = icons.Select(icon => icon.Name).ToArray();

            if (icons.Count > 4)
                UpdateSymbolData(4);
        });

        _dataInitialized = true;
    }
}
