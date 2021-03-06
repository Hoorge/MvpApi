﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using MvpApi.Models;
using MvpApi.Uwp.Helpers;
using MvpApi.Uwp.Views;
using Template10.Common;
using Template10.Mvvm;

namespace MvpApi.Uwp.ViewModels
{
    public class ShellPageViewModel : ViewModelBase
    {
        #region Fields

        private ProfileViewModel mvp;
        private string profileImagePath;
        private bool isLoggedIn;

        #endregion

        public ShellPageViewModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                Mvp = DesignTimeHelpers.GenerateSampleMvp();
                IsLoggedIn = true;
                ProfileImagePath = "ms-appx:///Images/iSeeSharpPeople.jpg";
                return;
            }
        }

        #region Properties

        public string ProfileImagePath
        {
            get { return profileImagePath; }
            set
            {
                //enforcing propChanged
                profileImagePath = value;
                RaisePropertyChanged();
            }
        }

        public ProfileViewModel Mvp
        {
            get { return mvp; }
            set { Set(ref mvp, value); }
        }

        public bool IsLoggedIn
        {
            get { return isLoggedIn; }
            set { Set(ref isLoggedIn, value); }
        }

        #endregion

        #region Navigation

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if(!IsLoggedIn)
                BootStrapper.Current.NavigationService.Navigate(typeof(LoginPage));

            return base.OnNavigatedToAsync(parameter, mode, state);
        }

        public override Task OnNavigatedFromAsync(IDictionary<string, object> pageState, bool suspending)
        {
            return base.OnNavigatedFromAsync(pageState, suspending);
        }

        #endregion
    }
}
