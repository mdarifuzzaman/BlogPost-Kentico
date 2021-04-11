using BlogPost.Models;
using BlogPost.Models.Home;
using BlogPost.Providers;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.HouseRestaurant;
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
                                .Path("/Home", PathTypeEnum.Single))
                                .FirstOrDefault();

            // Responds with the HTTP 404 error when the page is not found
            if (page == null)
            {
                return NotFound();
            }

            // Initializes the page data context (and the page builder) using the retrieved page
            _pageDataContextInitializer.Initialize(page);

            var homeSource = HomeProvider.GetHome(Guid.Parse(Home.NodeGuidId), "en-US", "HouseRestaurant");

            var menus = NavigationProvider.GetMenuItems();
            var dishes = DishProvider.GetDishCategories();

            var vm = new HomeViewModel()
            {
                Id = homeSource.First().HomeID,
                Description = homeSource.First().Description,
                Title = homeSource.First().Title,
                MenuItems = menus,
                Dishes = dishes
            };


            return View(vm);
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
