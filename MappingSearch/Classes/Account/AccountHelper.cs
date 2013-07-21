using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MappingSearch.Models.Account;
using MappingSearch.Data.Accessors;
using System.Security.Cryptography;
using System.Text;
using System.Data;

namespace MappingSearch.Classes.Account
{
    public class AccountHelper
    {
        
        public static Dictionary<string, string> CreatAccount(CreateAccountModel model)
        {
            Dictionary<string, string> accountCreationErrors = new Dictionary<string, string>();

            if (!Data.Accessors.UsersAccessor.UserExists(model.UserName))
            {
                Data.User dbUserModel = new Data.User();
                dbUserModel.CurrentMotorcycle = model.CurrentMotorcycle;
                dbUserModel.UserName = model.UserName;
                dbUserModel.AdminLevel = 1;
                dbUserModel.Salt = DateTime.Now.Ticks.ToString();
                byte[] salt = Encoding.UTF8.GetBytes(dbUserModel.Salt);

                dbUserModel.Password = Hash(model.Password,salt);
                dbUserModel.EmailAddress = model.EmailAddress;

                Data.Accessors.UsersAccessor.CreateUser(dbUserModel);
            }
            else 
            {
                accountCreationErrors.Add("AccountExists", "The user name you've selected already exists. Please select another");
            }
            return accountCreationErrors;
        }


        public static string Hash(string value, byte[] salt)
        {
            byte[] x = Hash(Encoding.UTF8.GetBytes(value), salt);
            return System.Text.Encoding.Default.GetString(x);
        }

        public static byte[] Hash(byte[] value, byte[] salt)
        {
            byte[] saltedValue = value.Concat(salt).ToArray();
            // Alternatively use CopyTo.
            //var saltedValue = new byte[value.Length + salt.Length];
            //value.CopyTo(saltedValue, 0);
            //salt.CopyTo(saltedValue, value.Length);

            return new SHA256Managed().ComputeHash(saltedValue);
        }

        internal static bool LogIn(string userName, string passWord)
        {
            Data.User user = Data.Accessors.UsersAccessor.GetUser(userName);
            if (user != null)
            {
                string salted = Hash(passWord, Encoding.UTF8.GetBytes(user.Salt));
                return String.Equals(user.Password, salted);
            }
            return false;

            
        }
    }
}