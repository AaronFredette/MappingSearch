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
            using (ReviewsDataContext context = new ReviewsDataContext  ())
            {

                var allUsersWithName = (from u in context.Users
                                 where u.UserName.Equals(userName)
                                 select u);

                return allUsersWithName.ToList().Count() > 0;
            }
        }

        public static void CreateUser(User dbUserModel)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            {
                context.Users.InsertOnSubmit(dbUserModel); //.InsertAllOnSubmit(dbUserModel);
                context.SubmitChanges();
            }
          
        }

        public static Data.User GetUser(string userName)
        {
            using (ReviewsDataContext context = new ReviewsDataContext())
            { 
               Data.User user = (from u in context.Users
                                 where u.UserName.Equals(userName)
                                 select u).FirstOrDefault();

               return user;
            }
        }
    }
}
