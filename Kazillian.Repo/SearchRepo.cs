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

        public SearchResult<SalesPerson> SearchSalespersons(string query, int page, int count)
        {
            var local    = new Uri(SearchEndpoint);
            var settings = new ConnectionSettings(local);
            settings.DefaultIndex("neo4j-index-node");

            var elastic  = new ElasticClient(settings);

            var Results = elastic.Search<SalesPerson>(g => g 
                               .AllIndices( )
                               .Type("SalesPerson") 
                               .Aggregations(a => a
                                    .Terms("Country", st => st
                                        .Field("CountryOfOrigin.keyword") 
                                    )
                                    .Terms("Language", st => st
                                        .Field("Languages.keyword")
                                    )
                                    .Range("AverageCost", st => st
                                        .Field("AverageCost")
                                        .Ranges(r => r.To(10),
                                         r => r.From(10).To(20),
                                                r => r.From(20).To(30),
                                                r => r.From(30).To(50),
                                                r => r.From(50).To(75),
                                                r => r.From(75).To(100),
                                                r => r.From(100) 
                                                )
                                    )
                               )
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

            var SearchResults = new SearchResult<SalesPerson>(SalesPeople);

            var Facets = new List<Facet>();

            var Countries = Results.Aggs.Terms<string>("Country");
            var Languages = Results.Aggs.Terms<string>("Language");
            var AverageCost = Results.Aggs.Range("AverageCost");


            var CountryFacet = new Facet();

            CountryFacet.Term = "Country";
            foreach(var Bucket in Countries.Buckets)
            {
                var FacetBucket = new FacetBucket();
                FacetBucket.Name = Bucket.Key;
                FacetBucket.DocumentCount = (int)Bucket.DocCount;
                CountryFacet.Buckets.Add(FacetBucket);
            }

            var LanguageFacet = new Facet();
            LanguageFacet.Term = "Language";
            foreach (var Bucket in Languages.Buckets)
            {
                var FacetBucket = new FacetBucket();
                FacetBucket.Name = Bucket.Key;
                FacetBucket.DocumentCount = (int)Bucket.DocCount;
                LanguageFacet.Buckets.Add(FacetBucket);
            }

            var AverageCostFacet = new Facet();
            AverageCostFacet.Term = "AverageCost";
            foreach (var Bucket in AverageCost.Buckets)
            {
                var FacetBucket = new FacetBucket();
                FacetBucket.Name = Bucket.Key;
                FacetBucket.DocumentCount = (int)Bucket.DocCount;
                AverageCostFacet.Buckets.Add(FacetBucket);
            }
            Facets.Add(AverageCostFacet);

            Facets.Add(CountryFacet);
            Facets.Add(LanguageFacet);
          
            SearchResults.Facets = Facets;
            return SearchResults; 
        }
    }
}
