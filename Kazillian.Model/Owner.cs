using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazillian.Model
{
    public class Owner : User
    {
        public string Industry { get; set; }
        public float Rating { get; set; }
        public decimal AveragePay { get; set; }
        public decimal TotalMoneyGrossed { get; set; }
        public decimal TotalMoneyEarned { get; set; }
        public List<string> CompanyNames { get; set; }
        public List<string> RequiredSkills { get; set; } 
        public List<string> OpenJobs { get; set; }
        public List<string> CompletedJobs { get; set; } 
    }
}
