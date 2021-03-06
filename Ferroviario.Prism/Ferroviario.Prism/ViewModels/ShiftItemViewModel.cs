﻿using Ferroviario.Common.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ferroviario.Prism.ViewModels
{
    public class ShiftItemViewModel : ShiftResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectShiftCommand;
        private DelegateCommand _selectChangeCommand;

        public ShiftItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectShiftCommand => _selectShiftCommand ?? (_selectShiftCommand = new DelegateCommand(SelectShiftAsync));

        public DelegateCommand SelectChangeCommand => _selectChangeCommand ?? (_selectChangeCommand = new DelegateCommand(SelectChangeAsync));

        private async void SelectShiftAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { "shift", this }
            };

            await _navigationService.NavigateAsync("ShiftDetailPage", parameters);
        }

        private async void SelectChangeAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { "shift", this }
            };

            await _navigationService.NavigateAsync("CreateChangePage", parameters);
        }

    }

}
