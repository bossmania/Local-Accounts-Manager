using System.Windows;
using System.Windows.Media;

namespace Windows_Application
{
    /// <summary>
    /// Interaction logic for modifyAccount.xaml
    /// </summary>
    public partial class modifyAccount : Window
    {

        public string account = "";
        public string username = "";
        public string password = "";

        public modifyAccount(string TempAccount, string TempUsername, string TempPassword)
        {
            //load the .xaml file
            InitializeComponent();

            //set the info in the window to the one given
            account = TempAccount;
            username = TempUsername;
            password = TempPassword;

            AccountTextbox.Text = account;
            UsernameTextbox.Text = username;
            PasswordTextbox.Password = password;
        }

        //dont allow to type if the checkbox is checked
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PasswordTextbox.IsEnabled = false;
            PasswordTextbox.Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE7E7E7"));
        }

        //all the user to type if the checkbox is uncheck
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordTextbox.IsEnabled = true;
            PasswordTextbox.Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
        }
        

        //update the account and close the window
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            account = AccountTextbox.Text;
            username = UsernameTextbox.Text;
            if (RandomPasswordCheckbox.IsChecked == false)
            {
                password = PasswordTextbox.Password;
            }
            else
            {
                Password_Manger.Password_Manger temp = new Password_Manger.Password_Manger();
                password = temp.Randomizer();
            }


            this.DialogResult = true;
        }
    }
}
