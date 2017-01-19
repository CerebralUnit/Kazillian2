using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazillian.Model
{
    public class Job
    { 
        public string Owner { get; set; }
        public string PeopleNeeded { get; set; } 
        public string ContactList { get; set; }
        public string Description { get; set; }
        public string Title { get; set; } 
        public string AdditionalInformation { get; set; }
        public string RequiredHours { get; set; } 
        public string ItemForSale { get; set; } 
        public string CompanyName { get; set; }
        public string RelatedWebsite { get; set; } 
        public string Instructions { get; set; } 
        public string Industry { get; set; }
        public decimal PayPerHour { get; set; }
        public decimal PayPerCall { get; set; }
        public decimal Commission { get; set; }
        public decimal Budget { get; set; }
        public ItemType Type { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 
        public List<string> Demographics { get; set; }
        public List<string> Applications { get; set; }
        public List<string> HiredUsers { get; set; }
        public List<string> Scripts { get; set; }
        public List<string> RequiredSkills { get; set; }
        public List<string> RequiredLanguages { get; set; }
        public List<string> Locations { get; set; }
        public List<Lead> Leads { get; set; }
    }
}
