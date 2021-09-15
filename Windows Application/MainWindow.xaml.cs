using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Windows_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //a function that will log the error message and the time
        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string path = "log.txt";
            string exceptionStr = e.ExceptionObject.ToString();
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
        }

        //a function that will update the table
        void updateTable()
        {
            PasswordTable.Items.Clear();
            foreach (Password_Manger.accountClass Account in passwordManager.ListOfAccounts)
            {
                PasswordTable.Items.Add(Account);
            }
            Trace.WriteLine("i've also also been run");
        }

        Password_Manger.Password_Manger passwordManager = new Password_Manger.Password_Manger();
        public MainWindow()
        {
            //setup the logger that will run a function then the app crash
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);

            //load in the .xaml file
            InitializeComponent();

            //add the accounts to the table
            foreach (Password_Manger.accountClass Account in passwordManager.ListOfAccounts)
            {
                PasswordTable.Items.Add(Account);
            }

        }

        //update the number next to the row at the table
        private void PasswordTable_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()+1).ToString();
        }

        //gives the user a popup to add an account
        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {
            addAccount addAccountWindow = new addAccount();
            if (addAccountWindow.ShowDialog() == true)
            {
                passwordManager.LoadAccounts();
                updateTable();
            }
        }

        //copy the password to the clipboard
        private void CopyPassword_Click(object sender, RoutedEventArgs e)
        {
            Password_Manger.accountClass RowInfo = (Password_Manger.accountClass)((Button)e.Source).DataContext;
            Clipboard.SetText(RowInfo.password);
            MessageBox.Show("The password has been copied to the clipboard.", "Success");

        }

        //gives a user a popup to modify an account
        private void ModifyAccount_Click(object sender, RoutedEventArgs e)
        {
            Password_Manger.accountClass RowInfo = (Password_Manger.accountClass)((Button)e.Source).DataContext;

            modifyAccount modifyAccountWindow = new modifyAccount(RowInfo.account, RowInfo.username, RowInfo.password);
            if (modifyAccountWindow.ShowDialog() == true)
            {
                passwordManager.UpdateAccount(RowInfo.account, RowInfo.username ,modifyAccountWindow.account);
                passwordManager.UpdateUsername(RowInfo.account, RowInfo.username, modifyAccountWindow.username);
                passwordManager.UpdatePassword(RowInfo.account, RowInfo.username, modifyAccountWindow.password);
            }

            updateTable();
        }

        //ask the user if they want to delete the account, and do it if said yes
        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            Password_Manger.accountClass RowInfo = (Password_Manger.accountClass)((Button)e.Source).DataContext;

            if (MessageBox.Show("Are you sure that you want to delete this account?", "Confirmation", 
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                
                passwordManager.DeleteAccount(RowInfo.account, RowInfo.username);
                updateTable();
            }
        }


        //starts a server that will wait for an list of accounts to be sent and will replace the table with that
        private void ReceiveAccount_Click(object sender, RoutedEventArgs e)
        {
            string ip;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                //grab the local ip of this device
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                ip = endPoint.Address.ToString();
            }

            //pass the ip to the server window
            server serverWindow = new server(ip);

            //update the table when the server window is closed
            if (serverWindow.ShowDialog() == true)
            {
                //Trace.WriteLine("ive been run");
                passwordManager.LoadAccounts();
                updateTable();
                MainWindow newWindow = new MainWindow();
                Application.Current.MainWindow = newWindow;
                newWindow.Show();
                this.Close();
            }
        }


        //send the current list of accounts to an server
        private void SendAccount_Click(object sender, RoutedEventArgs e)
        {
            client clientWindow = new client();
            clientWindow.ShowDialog();
        }
    }
}
