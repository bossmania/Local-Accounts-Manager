using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Diagnostics;
using System.Threading;

namespace Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class sendAccounts : ContentPage
    { 
        //create a password manger class
        Password_Manger.Password_Manger passwordManager = new Password_Manger.Password_Manger();
        string ip = null;
        public sendAccounts()
        {
            InitializeComponent();
        }

        void sendAccountsThread()
        {
            //set up the endpoint and the socket conneection
            MainThread.BeginInvokeOnMainThread(() =>
            {
                status.Text = "Status: Attempting to connect to the server.";
            });
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), 5678);
            Trace.WriteLine("ENDPOINT");
            Socket client = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Trace.WriteLine("GOT THE SOCKET READY");

            try
            {
                //connect to the server and tell the user
                Trace.WriteLine("BEFORE CONNECT");
                client.Connect(endPoint);
                Trace.WriteLine("AFTER CONNECT");
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    status.Text = "Status: Connected to the server.";
                });

                //encode the message and send it to the server
                string ListOfAccounts = "";
                foreach (Password_Manger.accountClass account in passwordManager.ListOfAccounts)
                {
                    ListOfAccounts += $"{account.account} | {account.username} | {account.password}\n";
                }
                Tuple<byte[], byte[], byte[]> encryptInfo = passwordManager.encrypt.encrypt(ListOfAccounts);
                string encryptedMessage = Convert.ToBase64String(encryptInfo.Item1);
                string encryptedKey = Convert.ToBase64String(encryptInfo.Item2);
                string encryptedIV = Convert.ToBase64String(encryptInfo.Item3);
                byte[] accountsInfo = Encoding.UTF8.GetBytes($"{encryptedMessage}†{encryptedKey}†{encryptedIV}");
                client.Send(accountsInfo);
                Trace.WriteLine("SENT THE INFO");

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    status.Text = "Status: Sent the accounts to the server.";
                });

                //shutdown the server, no mater what happens
                try
                {
                    client.Shutdown(SocketShutdown.Both);
                }
                catch { }
                client.Close();
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    status.Text = "Status: Closed the connection to the server.";
                });
                Navigation.PushAsync(new MainPage());

            }
            catch (SocketException)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("Ivalid IP", "Error: Invalid IP. Please try again.", "Ok");
                    status.Text = "Status: Waiting for the IP.";
                });
            }
            catch (Exception error)
            {
                //log the error message
                string path = "log.txt";
                string exceptionStr = error.Message;
                DateTime utcDate = DateTime.UtcNow;
                if (File.Exists(path))
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(exceptionStr + $" at {utcDate.ToString(new CultureInfo("en-US"))} {utcDate.Kind}\n");
                    }
                }
                else
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(exceptionStr + $" at {utcDate.ToString(new CultureInfo("en-US"))} {utcDate.Kind}\n");
                    }
                }

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    status.Text = "Status: Something went wrong. Please try again";
                });
            }
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
            ip = IPBox.Text;

            Thread t = new Thread(new ThreadStart(sendAccountsThread));
            t.Start();
            Thread.Sleep(3);

        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}