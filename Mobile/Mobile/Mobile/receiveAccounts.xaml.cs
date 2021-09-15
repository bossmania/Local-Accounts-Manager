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
using System.Threading;

namespace Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class receiveAccounts : ContentPage
    {

        void startServer(string ip)
        {

            //create a password manger class
            Password_Manger.Password_Manger passwordManager = new Password_Manger.Password_Manger();

            //define the msg string and the buffer
            string msg = null;
            byte[] buffer = new byte[1024];

            //set up the endpoint and the socket
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), 5678);
            Socket socketServer = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            //bind the endpoint to the server socket
            socketServer.Bind(endPoint);
            socketServer.Listen(10);


            //wait for a connection
            Socket client = socketServer.Accept();
            msg = null;

            try
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    status.Text = "Status: Receive a connection.";
                });
                while (true)
                {

                    //read in the msg sent
                    int byteRec = client.Receive(buffer);
                    msg += Encoding.UTF8.GetString(buffer, 0, byteRec);

                    //if their is no msg, then stop trying to read it
                    if (byteRec == 0)
                    {
                        break;
                    }
                }
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    status.Text = "Status: Decoded the accounts.";
                });
                //decode the message
                string[] accountsInfo = msg.Split(char.Parse("†"));
                byte[] encryptedMessage = Convert.FromBase64String(accountsInfo[0]);
                byte[] encryptedKey = Convert.FromBase64String(accountsInfo[1]);
                byte[] encryptedIV = Convert.FromBase64String(accountsInfo[2]);
                string accounts = passwordManager.encrypt.decrypt(encryptedMessage, encryptedKey, encryptedIV);

                //add the accounts into the system
                List<Password_Manger.accountClass> NewListOfAccount = new List<Password_Manger.accountClass>();
                string[] ListOfAccounts = accounts.Split(char.Parse("\n"));
                foreach (string account in ListOfAccounts)
                {
                    string[] info = account.Split(char.Parse("|"));
                    if (info.Length == 3)
                    {
                        Password_Manger.accountClass temp = new Password_Manger.accountClass(info[0], info[1], info[2]);
                        NewListOfAccount.Add(temp);
                    }
                }
                passwordManager.ListOfAccounts = NewListOfAccount;
                passwordManager.SaveAccounts();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    status.Text = "Status: Added the accounts into the system.";
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
                    status.Text = "Status: Something has gone wrong. Please try again.";
                });
            }
            finally
            {
                //shutdown and close the connection to the client
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }

            //shutdown the server
            try
            {
                client.Shutdown(SocketShutdown.Both);
            }
            catch { }
            socketServer.Close();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                status.Text = "Status: The accounts have been transfer. The server will now shutdown.";
            });
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Navigation.PushAsync(new MainPage());
        }

        public receiveAccounts(string ip)
        {
            InitializeComponent();
            IPLabel.Text = $"The IP is {ip}";

            Thread t = new Thread(new ThreadStart(() => startServer(ip)));
            t.Start();
            Thread.Sleep(3);
        }
    }
}