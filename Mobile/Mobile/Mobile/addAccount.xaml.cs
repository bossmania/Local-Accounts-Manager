using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addAccount : ContentPage
    {
        public string blank = null;
        public addAccount()
        {
            //load up the .xaml file and define the blank to the blank on the entry
            InitializeComponent();
            blank = accountText.Text;
        }

        private void passwordCheckbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            //allow the user to type in the password if they don't check off the box and vise versa
            if (e.Value == true)
            {
                passwordText.IsEnabled = false;
                passwordText.BackgroundColor = Color.FromHex("#FFE7E7E7");
            }
            else
            {
                passwordText.IsEnabled = true;
                passwordText.BackgroundColor = Color.FromHex("#FFFFFFFF");
            }
        }

        private async void Submit_Clicked(object sender, EventArgs e)
        {
            Password_Manger.Password_Manger passwordManager = new Password_Manger.Password_Manger();
            
            //check if the user have any blank fields
            if (accountText.Text == blank || usernameText.Text == blank ||
                (passwordCheckbox.IsChecked == false && passwordText.Text == blank))
            {
                await DisplayAlert("Error", "Please fill in the blank fields.", "Ok");
            }
            else
            {
                //check if the user wants to have a random password
                string password = "";
                if (passwordCheckbox.IsChecked == false)
                {
                    password = passwordText.Text;
                }
                else
                {
                    password = passwordManager.Randomizer();
                }
                //add the account and change page to the main page
                passwordManager.AddAccount(accountText.Text, usernameText.Text, password);
                await Navigation.PushAsync(new MainPage());
            }
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}