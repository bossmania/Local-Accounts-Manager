using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using System.Data;

namespace Windows_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Password_Manger.Password_Manger passwordManager = new Password_Manger.Password_Manger();
        public MainWindow()
        {
            InitializeComponent();

            foreach (Password_Manger.accountClass Account in passwordManager.ListOfAccounts)
            {
                PasswordTable.Items.Add(Account);
            }

        }

        private void PasswordTable_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()+1).ToString();
        }
        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {
            string account = Microsoft.VisualBasic.Interaction.InputBox("What service is this account for?", "Service", "", -1, -1);
            string username = Microsoft.VisualBasic.Interaction.InputBox("What is the username of the account?", "Username", "", 
                -1, -1);

            if (MessageBox.Show("Do you want a randomly generated password for the account?", "Randomly generated password", 
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                passwordManager.CreateAccount(account, username);
            } else
            {
                string password = Microsoft.VisualBasic.Interaction.InputBox("What is the password of the account?", "Password", "",
                -1, -1);
                passwordManager.AddAccount(account, username, password);
            }

            PasswordTable.Items.Clear();
            foreach (Password_Manger.accountClass Account in passwordManager.ListOfAccounts)
            {
                PasswordTable.Items.Add(Account);
            }
        }

        private void CopyPassword_Click(object sender, RoutedEventArgs e)
        {
            Password_Manger.accountClass RowInfo = (Password_Manger.accountClass)((Button)e.Source).DataContext;
            Clipboard.SetText(RowInfo.password);
            MessageBox.Show("The password has been copied to the clipboard.", "Success");

        }

        private void ModifyAccount_Click(object sender, RoutedEventArgs e)
        {
            Password_Manger.accountClass RowInfo = (Password_Manger.accountClass)((Button)e.Source).DataContext;

            MessageBoxResult result = MessageBox.Show("Do you want to modify the serivce?", "Modify the service", 
                MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                string service = Microsoft.VisualBasic.Interaction.InputBox("What service do you want to chage it to?", "Service", 
                    "", -1, -1);
                passwordManager.UpdateAccount(RowInfo.account, RowInfo.username, service);
            } else if (result == MessageBoxResult.No)
            {
                if (MessageBox.Show("Do you want to modify the username/email?", "Modify the username/email",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    string username = Microsoft.VisualBasic.Interaction.InputBox("What username/email do you want to chage it to?", 
                        "Username/email", "", -1, -1);
                    passwordManager.UpdateUsername(RowInfo.account, RowInfo.username, username);
                } else
                {
                    if (MessageBox.Show("Do you want to modify the password?", "Modify the password",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        if (MessageBox.Show("Do you want to have a randomly generated password?", "Randomly generated password",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            string password = passwordManager.Randomizer();
                            passwordManager.UpdatePassword(RowInfo.account, RowInfo.username, password);
                        } else
                        {
                            string password = Microsoft.VisualBasic.Interaction.InputBox("What password do you want to chage it to?",
                            "Password", "", -1, -1);
                            passwordManager.UpdatePassword(RowInfo.account, RowInfo.username, password);
                        }

                    }
                }
            } else
            {

            }

            PasswordTable.Items.Clear();
            foreach (Password_Manger.accountClass Account in passwordManager.ListOfAccounts)
            {
                PasswordTable.Items.Add(Account);
            }
        }

        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            Password_Manger.accountClass RowInfo = (Password_Manger.accountClass)((Button)e.Source).DataContext;

            if (MessageBox.Show("Are you sure that you want to delete this account?", "Confirmation", MessageBoxButton.YesNo) == 
                MessageBoxResult.Yes)
            {
                
                passwordManager.DeleteAccount(RowInfo.account, RowInfo.username);
                PasswordTable.Items.Clear();
                foreach (Password_Manger.accountClass Account in passwordManager.ListOfAccounts)
                {
                    PasswordTable.Items.Add(Account);
                }
            }
        }

        private void ReciveAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SendAccount_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
