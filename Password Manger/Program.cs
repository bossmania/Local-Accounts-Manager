using System;

namespace temp
{
    class Program
    {
        static void Main(string[] args)
        {
            Password_Manger.Password_Manger passwordManger = new Password_Manger.Password_Manger();

            //passwordManger.CreateAccount("google", "google@gmail.com");
            //passwordManger.CreateAccount("facebook", "facebook@gmail.com");
            //passwordManger.CreateAccount("twitter", "twitter@gmail.com");
            //passwordManger.CreateAccount("instagram", "instagram@gmail.com");

            passwordManger.ReadAccounts();
            
        }
    }
}
