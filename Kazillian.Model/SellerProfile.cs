using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazillian.Model
{ 
    public class SellerProfile 
    { 
        public string Id { get; set; }
        public string JobTitle { get; set; }
        public string Bio { get; set; }
        public string Resume { get; set; } 
        public string Availability { get; set; }
        public string AdditionalInfo  { get; set; }
        public decimal AverageCost { get; set; } 
        public decimal TotalMoneyEarned { get; set; }
        [JsonIgnore]
        public List<string> Skills { get; set; }
        public List<string> CompletedJobs { get; set; }
        public List<string> AbandonedJobs { get; set; }
        public List<string> Reviews { get; set; }
        public List<string> ActiveJobs { get; set; }
    }
}
