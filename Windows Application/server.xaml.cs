using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Globalization;
using System.Net;
using System.Net.Sockets;

namespace Windows_Application
{
    /// <summary>
    /// Interaction logic for server.xaml
    /// </summary>
    public partial class server : Window
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

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    status.Text = "Status: Receive a connection.";
                }));

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

                //decode the message
                string[] accountsInfo = msg.Split("†");
                byte[] encryptedMessage = Convert.FromBase64String(accountsInfo[0]);
                byte[] encryptedKey = Convert.FromBase64String(accountsInfo[1]);
                byte[] encryptedIV = Convert.FromBase64String(accountsInfo[2]);
                string accounts = passwordManager.encrypt.decrypt(encryptedMessage, encryptedKey, encryptedIV);

                //add the accounts into the system
                List<Password_Manger.accountClass> NewListOfAccount = new List<Password_Manger.accountClass>();
                string[] ListOfAccounts = accounts.Split("\n");
                foreach (string account in ListOfAccounts)
                {
                    string[] info = account.Split(" | ");
                    if (info.Length == 3)
                    {
                        Password_Manger.accountClass temp = new Password_Manger.accountClass(info[0], info[1], info[2]);
                        NewListOfAccount.Add(temp);
                    }
                }
                passwordManager.ListOfAccounts = NewListOfAccount;
                passwordManager.SaveAccounts();
                passwordManager.LoadAccounts();

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    status.Text = "Status: Obtain the message.";

                }));

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

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    status.Text = "Status: Something has gone wrong. Please try again.";
                }));
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
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                status.Text = "Status: The accounts have been transfer. The server will now shutdown.";
            }));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                this.DialogResult = true;
            }));
        }

        public server(string ip)
        {
            InitializeComponent();
            IpTextblock.Text = $"The IP is {ip}";
            Task.Run(() => startServer(ip));
        }
    }
}
