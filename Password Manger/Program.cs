using System;
using Password_Manger;

namespace temp
{
    class Program
    {
        static void Main(string[] args)
        {
            Password_Manger.Password_Manger temp = new Password_Manger.Password_Manger();
            temp.CreateAccount("google", "wdawjdawd@gmail.com");
            temp.CreateAccount("youtube", "grdg3wjk@gmail.com");
            temp.CreateAccount("discord", "bossmnaia#0001");

            temp.SaveAccounts();
        }
    }
}
