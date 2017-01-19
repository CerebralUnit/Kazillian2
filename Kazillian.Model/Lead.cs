using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazillian.Model
{ 
    public class Lead : Person
    { 
        public string Details { get; set; }
        public string Availability { get; set; }
        public string FollowedUp { get; set; } 
        public string Salesperson { get; set; }
        public string MethodOfContact { get; set; }
        public string NumberOfTimesContacted { get; set; }
        public int CallLength { get; set; } //seconds 
        public bool SaleIsComplete { get; set; }
        public decimal MoneyEarned { get; set; }
        public DateTime DateAcquired { get; set; }
        public DateTime DateClosed { get; set; }
    }
}
