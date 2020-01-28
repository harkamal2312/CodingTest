using System;
using System.Collections.Generic;

namespace Question2
{
    class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                var user = new User();
                Console.WriteLine("please enter the username, or q to exit");
                var userName = Console.ReadLine();
                if (userName == "q")
                {
                    break;
                }

                user.Add(userName);
                Console.WriteLine($"number of addedUser {user.GetUsersCount()}");
            }
        }
        /// <summary>
        /// User class 
        /// </summary>
        private class User
        {
            public static List<string> users = new List<string>();
            public int GetUsersCount()
            {
                return users.Count;
            }
            public void Add(string userName)
            {
                users.Add(userName);
            }
        }
    }
}
