using BlogPost.Controllers;
using BlogPost.Models.About;
using BlogPost.Providers;
using CMS.DocumentEngine;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

[assembly: RegisterPageRoute(AboutUs.CLASS_NAME, typeof(AboutController))]

namespace BlogPost.Controllers
{
    public class AboutController: Controller
    {
        public readonly Guid NodeGuid = Guid.Parse("6c619796-a603-4e13-958b-dbb208fed432");
        public const int PageID = 94;

        private readonly IPageDataContextRetriever _dataRetriever;
        private readonly IPageRetriever _pageRetriever;
        private readonly IPageDataContextInitializer _pageDataContextInitializer;

        public AboutController(IPageDataContextRetriever dataRetriever,
            IPageRetriever pageRetriever, IPageDataContextInitializer pageDataContextInitializer)
        {
            _dataRetriever = dataRetriever;
            _pageRetriever = pageRetriever;
            _pageDataContextInitializer = pageDataContextInitializer;
        }

        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var pages = _pageRetriever.Retrieve<TreeNode>(query => query
                                .Path("/", PathTypeEnum.Children));

            var aboutUsPage = pages.FirstOrDefault(e=> DocumentURLProvider.GetAbsoluteUrl(e).ToLower().Contains("/myblog/about"));

            _pageDataContextInitializer.Initialize(aboutUsPage);
            //var aboutUs = _dataRetriever.Retrieve<AboutUs>().Page;

            //var sideStories = await aboutUsRepository.GetSideStoriesAsync(aboutUs.NodeAliasPath, cancellationToken);

            //var reference = (await referenceRepository.GetReferencesAsync($"{aboutUs.NodeAliasPath}/References", cancellationToken, 1)).FirstOrDefault();
            var sideStories = new List<AboutUsSection> ();

            var documentQueryHome = AboutUsProvider.GetAboutUs(NodeGuid, "en-US", "BlogPost");
            var data = documentQueryHome.FirstOrDefault();

            AboutUsViewModel mode = new AboutUsViewModel()
            {
                ID = data.AboutUsID,
                Title = data.AboutUsText,
                Desc = data.AboutUsDesc
            };

            return View(mode);
        }
    }
}
