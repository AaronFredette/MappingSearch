using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingSearch.Data.Accessors
{
    public static class UsersAccessor
    {
        //private static UsersDataContext _context;
        //private static UsersDataContext Context
        //{
        //    get
        //    {
        //        if (_context == null)
        //        {
        //            _context = new UsersDataContext();
        //        }
        //        return _context;
        //    }
        //}
        public static bool UserExists(string userName)
        {
            using (UsersDataContext context = new UsersDataContext())
            {

                var allUsersWithName = (from u in context.Users
                                 where u.UserName.Equals(userName)
                                 select u);

                return allUsersWithName.ToList().Count() > 0;
            }
        }

        public static void CreateUser(User dbUserModel)
        {
            using (UsersDataContext context = new UsersDataContext())
            {
                context.Users.InsertOnSubmit(dbUserModel); //.InsertAllOnSubmit(dbUserModel);
                context.SubmitChanges();
            }
          
        }

        public static Data.User GetUser(string userName)
        {
            using (UsersDataContext context = new UsersDataContext())
            { 
               Data.User user = (from u in context.Users
                                 where u.UserName.Equals(userName)
                                 select u).FirstOrDefault();

               return user;
            }
        }
    }
}
