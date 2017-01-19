using Kazillian.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kazillian.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Sellers(string q, int page = 0)
        {
            var SearchResults = SearchService.SearchSalespersons(q, page);

            return View(SearchResults);
        }
    }
}