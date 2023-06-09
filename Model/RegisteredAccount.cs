﻿namespace UTSLostAndFound.Model
{
    public class RegisteredAccount
    {
        public string StudentId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Collection to store registered accounts
        private static List<RegisteredAccount> RegisteredAccounts { get; } = new List<RegisteredAccount>();

        // Method to retrieve a registered account based on student ID
        public static RegisteredAccount GetRegisteredAccount(string studentId)
        {
            return RegisteredAccounts.Find(account => account.StudentId == studentId);
        }

        // Method to add a new registered account
        public static void AddRegisteredAccount(RegisteredAccount account)
        {
            RegisteredAccounts.Add(account);
        }

        // Static constructor to initialize default registered accounts
        static RegisteredAccount()
        {
            // Create a default registered account
            RegisteredAccount defaultAccount = new RegisteredAccount
            {
                StudentId = "admin",
                Username = "admin",
                Password = "admin"
            };

            // Add the default account to the registered accounts collection
            AddRegisteredAccount(defaultAccount);
        }
    }
}


