using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Essentials;
using Password_Manger;
using System.IO;
using System.Windows.Input;
using System.Net.Sockets;
using System.Net;

namespace Mobile
{
    public partial class MainPage : ContentPage
    {
        //add a reference to the password manager
        Password_Manger.Password_Manger passwordManager = new Password_Manger.Password_Manger();
        public MainPage()
        {
            //load the .xaml and assign the accounts to the table
            InitializeComponent();
            passwordTable.ItemsSource = passwordManager.ListOfAccounts;
        }

        private void NewAccount_Clicked(object sender, EventArgs e)
        {
            //change the page to the add account page
            addAccount page = new addAccount();
            Navigation.PushAsync(page);
        }

        private void SendAccount_Clicked(object sender, EventArgs e)
        {
            sendAccounts page = new sendAccounts();
            Navigation.PushAsync(page);
        }
        
        private void ReciveAccount_Clicked(object sender, EventArgs e)
        {
            string ip;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                //grab the local ip of this device
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                ip = endPoint.Address.ToString();
            }
            receiveAccounts page = new receiveAccounts(ip);
            Navigation.PushAsync(page);
        }

        private async void CopyPassword_Clicked(object sender, EventArgs e)
        {
            //reference the row that the button is in
            ImageButton button = (ImageButton)sender;
            Password_Manger.accountClass rowInfo = (Password_Manger.accountClass)button.CommandParameter;
            //copy the password to the clipboard and notify the user
            await Clipboard.SetTextAsync(rowInfo.password);
            await DisplayAlert("Password copied", "The password has been copied.", "Ok");
        }

        private void ModifyAccount_Clicked(object sender, EventArgs e)
        {
            //reference the row that the button is in
            ImageButton button = (ImageButton)sender;
            Password_Manger.accountClass rowInfo = (Password_Manger.accountClass)button.CommandParameter;
            //change the page to the modify account page
            modifyAccount page = new modifyAccount(rowInfo.account, rowInfo.username, rowInfo.password);
            Navigation.PushAsync(page);
        }

        private async void DeleteAccount_Clicked(object sender, EventArgs e)
        {
            //ask the user if they want to delete the account and do it if the user reply with yes
            bool answer = await DisplayAlert("Delete account", "Are you sure that you want to delete the account?", "Yes", "No");
            if (answer)
            {
                //reference the row that the button is in and delete the account
                ImageButton button = (ImageButton)sender;
                Password_Manger.accountClass rowInfo = (Password_Manger.accountClass)button.CommandParameter;
                passwordManager.DeleteAccount(rowInfo.account, rowInfo.username);

                //update the table with the new info and tell the user that the account has been deleted
                passwordTable.ItemsSource = null;
                passwordTable.ItemsSource = passwordManager.ListOfAccounts;
                await DisplayAlert("Account deleted", "The account has been deleted.", "Ok");
            }
        }
    }


}
