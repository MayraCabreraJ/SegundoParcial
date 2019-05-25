using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

using Xamarin.Forms;
using App.Services;
using Mayparcabrera2.Models;
using Mayparcabrera2.ViewModels;
using App.ViewModels;

namespace Mayraparcabrera2.ViewModels
{
   

    public class ApiViewModel :BaseViewModel
    {
        #region Attributes
        string content;
       
       
        ApiServices apiService;
        #endregion

        #region Properties
        public string Note
        {
            get
            {
                return this.content;
            }
            set
            {
                SetValue(ref this.content, value);

            }
        }
        
        

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
            if (String.IsNullOrEmpty(content))
            {
                await App.Current.MainPage.DisplayAlert(
                                "Ingrese su Nota",
                                "Accept");
                return;
            }
           

          
            TokenResponse token = await this.apiService.
                   "https://notesplc.azurewebsites.net",
                    this.Note);




            MainViewModel mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token.AccessToken;
            mainViewModel.TokenType = token.TokenType;

     
        }
        #endregion

        public ApiViewModel()
        {

        }
    }
}