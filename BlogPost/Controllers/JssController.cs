using BlogPost.Models.BlogHome;
using BlogPost.Providers;
using CMS.DocumentEngine;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Controllers
{
    public class JssController:Controller
    {
        public readonly Guid NodeGuid = Guid.Parse("ad214fd3-1ca4-4629-ab36-53917b1eea49");
        public const int PageID = 96;
        private readonly IPageRetriever _pagesRetriever;
        private readonly IPageDataContextInitializer _pageDataContextInitializer;
        private readonly IPageDataContextRetriever _dataRetriever;

        private readonly ILogger<JssController> _logger;

        public JssController(ILogger<JssController> logger, IPageRetriever pagesRetriever,
                                        IPageDataContextInitializer pageDataContextInitializer,
                                        IPageDataContextRetriever dataRetriever)
        {
            _logger = logger;
            _pageDataContextInitializer = pageDataContextInitializer;
            _pagesRetriever = pagesRetriever;
            _dataRetriever = dataRetriever;
        }
        public async Task<IActionResult> Home()
        {
            // Retrieves a page from the Xperience database with the '/Home' node alias path
            var jssHome = _pagesRetriever.Retrieve<TreeNode>(query => query.WithID(PageID)).FirstOrDefault();

            //var jssHome = pages.FirstOrDefault(e => DocumentURLProvider.GetAbsoluteUrl(e).ToLower().Contains("/myblog/jss/home"));

            // Responds with the HTTP 404 error when the page is not found
            if (jssHome == null)
            {
                return NotFound();
            }

            // Initializes the page data context (and the page builder) using the retrieved page
            _pageDataContextInitializer.Initialize(jssHome);

            //var blogHomePage = _dataRetriever.Retrieve<BlogHome>().Page;
            //var id = blogHomePage.Fields.ID;
            //var title = blogHomePage.Fields.Title;

            var documentQueryHome = BlogHomeProvider.GetBlogHome(NodeGuid, "en-US", "BlogPost");
            var data = documentQueryHome.FirstOrDefault();
            return View(new BlogHomeViewModel() { Title = data.BlogHomeTitle});
        }
    }
}
