using System.Windows;
using System.Windows.Media;

namespace Windows_Application
{
    /// <summary>
    /// Interaction logic for addAccount.xaml
    /// </summary>
    public partial class addAccount : Window
    {

        public addAccount()
        {

            //load the .xaml file
            InitializeComponent();
        }

        //dont allow the user to type in the password text box if checked
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PasswordTextbox.IsEnabled = false;
            PasswordTextbox.Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE7E7E7"));
        }

        //allow the user to type in the password text box if unchecked
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordTextbox.IsEnabled = true;
            PasswordTextbox.Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF")); 
        }

        //submit the account and close the window
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if (AccountTextbox.Text == "" || UsernameTextbox.Text == "" ||
                (RandomPasswordCheckbox.IsChecked == false && PasswordTextbox.Password == ""))
            {
                MessageBox.Show("Please fill in the blank fields.", "Error");
            }
            else
            {
                string password = null;
                Password_Manger.Password_Manger passwordMangaer = new Password_Manger.Password_Manger();
                if (RandomPasswordCheckbox.IsChecked == false)
                {
                    password = PasswordTextbox.Password;
                }
                else
                {
                    password = passwordMangaer.Randomizer();
                }
                passwordMangaer.AddAccount(AccountTextbox.Text, UsernameTextbox.Text, password);
                this.DialogResult = true;
            }
        }
    }
}
