using Kazillian.Model;
using Kazillian.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazillian.Service
{
    public static class SearchService
    {
        public static SearchResult<SalesPerson> SearchSalespersons(string username, int page = 0)
        {
            var Repo = new SearchRepo();
            var Result = Repo.SearchSalespersons(username, page, 10);

            return Result;
        }
    }
}
