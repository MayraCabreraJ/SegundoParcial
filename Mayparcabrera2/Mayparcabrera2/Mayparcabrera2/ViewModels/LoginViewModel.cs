using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

using Xamarin.Forms;
using App.Services;
using Mayparcabrera2.Models;

using App.ViewModels;

namespace Mayraparcabrera2.ViewModels
{


    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        string note;
        bool isrunning;
        bool isenabled;
       ApiServices apiService;


        #endregion

        #region Properties
        public bool IsRunning
        {
            get
            {
                return this.isrunning;
            }
            set
            {
                SetValue(ref this.isrunning, value);
            }

        }
        public bool IsEnabled
        {
            get
            {
                return this.isenabled;
            }
            set
            {
                SetValue(ref this.isenabled, value);
            }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(cmdLogin);
            }
        }

        private async void cmdLogin()
        {
            if (String.IsNullOrEmpty(note))
            {
                await App.Current.MainPage.DisplayAlert("note empty",
                                "Please enter your note",
                                "Accept");
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var conexion = await this.apiService.CheckConnection();
            if (!conexion.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                   "ERROR",
                   conexion.Message,
                   "Accept");
                return;
            }



            Response response = await apiService.Post<Response>(
                  "https://api.azurewebsites.net/",
                 "api/",
                 "Notes"
                 );
            MainViewModel mainViewModel = MainViewModel.GetInstance();

            IsRunning = false;
            IsEnabled = true;
        }
        #endregion

        public LoginViewModel()
        {

        }
    }
}