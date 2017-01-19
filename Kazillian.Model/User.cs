using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazillian.Model
{
    public class User : Person
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Image { get; set; } 
        public bool IsLoggedIn { get; set; } 
        public DateTime LastLoggedIn { get; set; }
        public DateTime SignedUpDate { get; set; }
        public List<string> Connections { get; set; }
        [JsonIgnore]
        public List<string> Languages { get; set; }
    }
}
