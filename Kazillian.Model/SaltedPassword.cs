using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazillian.Model
{
    public class SaltedPassword
    {
        public SaltedPassword() { }

        public SaltedPassword(string salt, string password) {
            Salt = salt;
            Password = password;
        }

        public string Salt { get; set; }
        public string Password { get; set; }
    }
}
