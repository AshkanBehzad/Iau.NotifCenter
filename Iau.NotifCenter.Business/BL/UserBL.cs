using Iau.NotifCenter.DataAccess.DAL;
using Iau.NotifCenter.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography;
namespace Iau.NotifCenter.Business.BL
{
    public class UserBL
    {

        private static UserDA userDA = new UserDA();
        public static int CreateUser(string firstName,string lastName,string username,string password,bool gender)
        {
            return userDA.Insert(new User
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Password = Crypto.Encrypt(password),
                Gender = gender                
            });
        }
        public static User GetUserByUserNameAndPassword(string username,string password)
        {
            try
            {
               return  userDA.GetAll().FirstOrDefault(u => u.Username == username && u.Password == password);
            }
            catch (Exception exc)
            {
                return null;
                throw exc;
            }
        }
    }
}
