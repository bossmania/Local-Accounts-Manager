using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Globalization;

namespace Windows_Application
{
    /// <summary>
    /// Interaction logic for client.xaml
    /// </summary>
    public partial class client : Window
    {
        //create a password manger class
        Password_Manger.Password_Manger passwordManager = new Password_Manger.Password_Manger();
        string ip = null;

        public client()
        {
            
            InitializeComponent();
        }

        void sendAccounts()
        {
            //set up the endpoint and the socket conneection
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                status.Text = "Status: Attempting to connect to the server.";
            }));
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), 5678);
            Socket client = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                //connect to the server and tell the user
                client.Connect(endPoint);
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    status.Text = "Status: Connected to the server.";
                }));

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

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    status.Text = "Status: Sent the accounts to the server.";
                }));

                //shutdown the server, no mater what happens
                try
                {
                    client.Shutdown(SocketShutdown.Both);
                }
                catch { }
                client.Close();
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    status.Text = "Status: Closed the connection to the server.";
                    this.DialogResult = true;
                }));

            }
            catch (SocketException)
            {
                MessageBox.Show("Error: Invalid IP. Please try again.");
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    status.Text = "Status: Waiting for the IP.";
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
                    status.Text = "Status: Something went wrong. Please try again";
                }));
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            ip = IPBox.Text;
            Task.Run(() => sendAccounts());
        }
    }
}
