using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MappingSearch.Classes
{
    public static class CurrentUser
    {
        #region Properties
        private static Data.User _currentUser;
        private static Data.User Current
        {
            get
            {
                if (_currentUser == null || String.IsNullOrEmpty(_currentUser.UserName))
                {
                    string userId = System.Web.HttpContext.Current.User.Identity.Name;
                    Data.User current = Data.Accessors.UsersAccessor.GetUser(userId);
                    if (current != null)
                        _currentUser = current;
                    else
                        _currentUser = new Data.User();
                }
                return _currentUser;
            }
        }
        #endregion Properties


        public static int AdminLevel()
        {
            return Current.AdminLevel;
        }

        public static void LogOut()
        {
            _currentUser = null;
        }
    }
}
