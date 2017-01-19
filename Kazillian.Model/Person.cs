using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazillian.Model
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string CountryOfOrigin { get; set; }
        public ContactInfo ContactInfo { get; set; } 
        public DateTime Birthday { get; set; } 
    }
}
