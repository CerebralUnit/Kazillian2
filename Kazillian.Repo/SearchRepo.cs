using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j;
using Neo4jClient;
using Nest;
using Kazillian.Model;

namespace Kazillian.Repo
{
    public class SearchRepo
    {
        private const string SearchEndpoint = "http://localhost:9200/";

        public List<SalesPerson> SearchSalespersons(string query, int page, int count)
        {
            var local    = new Uri(SearchEndpoint);
            var settings = new ConnectionSettings(local);
            settings.DefaultIndex("neo4j-index-node");

            var elastic  = new ElasticClient(settings);

            var Results = elastic.Search<SalesPerson>(g => g 
                               .AllIndices( )
                               .Type("SalesPerson")
                               .Query( q => q
                                     .QueryString( qs =>  qs 
                                        //.Fields( f => f
                                        //        .Field(p => p.FirstName)
                                        //        .Field(p => p.LastName)
                                        //        .Field(p => p.Bio)
                                        //        .Field(p => p.AdditionalInfo)  
                                        //        .Field(p => p.JobTitle)
                                        //       )
                                        .Query(query)    
                                        .Lenient() 
                                     )
                                )
                        ); 

            var Hits = Results.Hits.ToList();
            var SalesPeople = new List<SalesPerson>();

            foreach(var Hit in Hits)
            {
                SalesPeople.Add((SalesPerson)Hit.Source);
            }

            return SalesPeople; 
        }
    }
}
