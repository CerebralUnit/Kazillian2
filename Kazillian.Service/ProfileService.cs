using Kazillian.Model;
using Kazillian.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazillian.Service
{
    public static class ProfileService
    {
        public static SalesPerson GetSalesperson(string username)
        {
            var Repo = new UserRepo();
            var Result = Repo.GetSalesperson(username);

            return Result;
        }

        public static User Authenticate(string username, string password)
        {
            var Repo   = new UserRepo();
            var Result = Repo.AuthenticateUser(username, password);

            return Result;
        }
    }
}
