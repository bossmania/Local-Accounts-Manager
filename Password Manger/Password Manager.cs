using System;
using System.IO;
using System.Collections.Generic;
using Encryption;

namespace Password_Manger
{
    public class accountClass
    {
        public string account { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string censorPassword { get; set; }

        //a function that will return the censord version of the password
        string CensorPassword()
        {
            string censorPassword = "";
            for (int i = 0; i < password.Length; i++)
            {
                censorPassword += "*";
            }
            return censorPassword;
        }

        public accountClass(string account, string username, string password)
        {
            this.account = account;
            this.username = username;
            this.password = password;
            this.censorPassword = CensorPassword();
        }
    }

    public class Password_Manger
    {

        public List<accountClass> ListOfAccounts = new List<accountClass>();

        //make the random class
        Random rand = new Random();

        //make the encrypt class
        encryption encrypt = new encryption();

        //store the path of the file that will save the accounts
        string directory = String.Format("C:/Users/{0}/AppData/Local/PasswordSaver/", Environment.UserName);
        string FileName = "Accounts.txt";

        //make the list of character to randomly pick a character
        string[] characters = {"a", "b", "c", "d", "e", "f", "g", "h", "i",
                                    "j","k", "l", "m", "n", "o", "p", "q", "r",
                                    "s", "t", "u", "v", "w", "x", "y", "z"};
        string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        string[] symbols = { ",", "<", ".", ">", "/", "?", "'", ";", ":", "`", "~",
                                 "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-",
                                 "_", "=", "+", "[", "{", "}", "]", "\""};

        //created a dictionary with accounts and passwords
        //Dictionary<string, string> accounts = new Dictionary<string, string>();

        //a function that will randomly make a password
        public string Randomizer(int length = 10, bool useNumbers = true, bool useSymbols = true)
        {
            string password = "";
            for (int i = 0; i < length + 1; i++)
            {
                switch (rand.Next(3))
                {
                    case 0:
                        //randomly decide to uppercase the random letter or not to
                        if (rand.Next(2) == 0)
                        {
                            password += characters[rand.Next(characters.Length)].ToUpper();
                        }
                        else
                        {
                            password += characters[rand.Next(characters.Length)];
                        }
                        break;

                    case 1:
                        //radomly pick a number if allow. if not, then random pick a letter and randomly decide to uppercare it
                        if (useNumbers)
                        {
                            password += numbers[rand.Next(numbers.Length)];
                        }
                        else
                        {
                            if (rand.Next(2) == 0)
                            {
                                password += characters[rand.Next(characters.Length)].ToUpper();
                            }
                            else
                            {
                                password += characters[rand.Next(characters.Length)];
                            }
                        }
                        break;

                    case 2:
                        if (useSymbols)
                        {
                            password += symbols[rand.Next(symbols.Length)];
                        }
                        else
                        {
                            if (rand.Next(2) == 0)
                            {
                                password += characters[rand.Next(characters.Length)].ToUpper();
                            }
                            else
                            {
                                password += characters[rand.Next(characters.Length)];
                            }
                        }
                        break;
                }
            }
            return password;
        }


        //a function that will create a new password with an account, and will reutrn if it succesfully created the account with the given
        //username and account.
        public bool CreateAccount(string account, string username)
        {
            foreach (accountClass Account in ListOfAccounts)
            {
                if (Account.username == username && Account.account == account)
                {
                    return false;
                }
            }

            string password = Randomizer();
            accountClass tempAccount = new accountClass(account, username, password);
            ListOfAccounts.Add(tempAccount);
            return true;
        }

        //a function that will add an existing account to the system if the account and username is not already in it
        public bool AddAccount(string account, string username, string password)
        {
            // check if the account does not exists.
            foreach (accountClass Account in ListOfAccounts)
            {
                if (Account.username == username && Account.account == account)
                {
                    return false;
                }
            }

            accountClass tempAccount = new accountClass(account, username, password);
            ListOfAccounts.Add(tempAccount);
            SaveAccounts();
            return true;
        }

        //a function that will update the account's name with a new account's name
        public bool UpdateAccount(string account, string username, string newAccount)
        {
            bool success = false;

            foreach (accountClass Account in ListOfAccounts)
            {
                //Console.WriteLine($"Account: {Account.account}. Username {Account.username}");
                if (Account.account == account && Account.username == username)
                {
                    Account.account = newAccount;
                    success = true;
                }

            }

            SaveAccounts();
            return success;
        }

        //a function that will update the username with a new one
        public bool UpdateUsername(string account, string username, string newUsername)
        {
            bool success = false;

            foreach (accountClass Account in ListOfAccounts)
            {
                if (Account.account == account && Account.username == username)
                {
                    Account.username = newUsername;
                    success = true;
                }
            }

            SaveAccounts();
            return success;
        }

        //a function that will updte the password of an account and username
        public bool UpdatePassword(string account, string username, string password = null)
        {
            bool success = false;

            if (password == null)
            {
                password = Randomizer();
            }
            foreach (accountClass Account in ListOfAccounts)
            {
                if (Account.account == account && Account.username == username)
                {
                    Account.password = password;
                    success = true;
                }
            }

            SaveAccounts();
            return success;
        }

        //a function that will delete an account
        public bool DeleteAccount(string account, string username)
        {
            bool success = false;
            for (int i = 0; i < ListOfAccounts.Count; i++)
            {
                if (ListOfAccounts[i].account == account && ListOfAccounts[i].username == username)
                {
                    ListOfAccounts.RemoveAt(i);
                    success = true;
                }
            }
            SaveAccounts();
            return success;
        }

        // a function that will read the list of accounts
        public void ReadAccounts()
        {
            foreach (accountClass Account in ListOfAccounts)
            {
                Console.WriteLine($"account: {Account.account} username: {Account.username} password: {Account.password}");
            }
        }

        //save the accounts
        public void SaveAccounts()
        {

            //create a directory
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            //save the accounts in the string
            string Password = "";
            foreach (accountClass Account in ListOfAccounts)
            {
                Password += $"{Account.account} | {Account.username} | {Account.password}\n";

            }
            //encrypt the string and save it to a file
            encrypt.Encrypt($"{directory}/{FileName}", Password);
        }

        //load the accounts
        public void LoadAccounts()
        {
            //create a temp dictionary
            List<accountClass> NewListOfAccount = new List<accountClass>();

            //check if the file exists. if it does not, then set the list to an empty one
            if (File.Exists(string.Format("{0}/{1}", directory, FileName)))
            {
                //load in the file and decrypt it
                string AllAccounts = encrypt.Decrypt(string.Format("{0}/{1}", directory, FileName));

                //split the string by new line
                string[] ListOfAccountsString = AllAccounts.Split("\n");

                //add each account in the array into the temp dictionary
                foreach (string account in ListOfAccountsString)
                {

                    string[] info = account.Split(" | ");
                    if (info.Length == 3)
                    {
                        accountClass temp = new accountClass(info[0], info[1], info[2]);
                        NewListOfAccount.Add(temp);
                    }
                }
            }

            ListOfAccounts = NewListOfAccount;
        }

        public Password_Manger()
        {
            LoadAccounts();
            Console.WriteLine("The accounts have been loaded.");
        }
    }
}
