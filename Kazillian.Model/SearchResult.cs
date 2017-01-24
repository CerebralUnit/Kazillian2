using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazillian.Model
{
    public class Facet
    { 
        public Facet()
        {
            Buckets = new List<FacetBucket>();
        }
        public string Term { get; set; } 
        public List<FacetBucket> Buckets { get; set; }
    }

    public class FacetBucket
    {
        public string Name { get; set; }
        public int DocumentCount { get; set; }
    }

    public class SearchResult<T> 
    { 
        public List<Facet> Facets { get; set; }
        public List<T> Results { get; set; }

        public SearchResult(List<T> results)
        {
            Results = results;
        } 
    }
}
