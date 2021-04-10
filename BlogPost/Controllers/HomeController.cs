using BlogPost.Models;
using CMS.DocumentEngine;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageRetriever _pagesRetriever;
        private readonly IPageDataContextInitializer _pageDataContextInitializer;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IPageRetriever pagesRetriever,
                                        IPageDataContextInitializer pageDataContextInitializer)
        {
            _logger = logger;
            _pageDataContextInitializer = pageDataContextInitializer;
            _pagesRetriever = pagesRetriever;
        }

        public IActionResult Index()
        {

            // Retrieves a page from the Xperience database with the '/Home' node alias path
            TreeNode page = _pagesRetriever.Retrieve<TreeNode>(query => query
                                .Path("/", PathTypeEnum.Single))
                                .FirstOrDefault();

            // Responds with the HTTP 404 error when the page is not found
            if (page == null)
            {
                return NotFound();
            }

            // Initializes the page data context (and the page builder) using the retrieved page
            _pageDataContextInitializer.Initialize(page);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
