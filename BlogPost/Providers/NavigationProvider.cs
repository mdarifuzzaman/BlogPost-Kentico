using BlogPost.Models.Menu;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.HouseRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Providers
{
    public class NavigationProvider
    {
        public static List<PrimaryMenuItemViewModel> GetMenuItems()
        {
            var items = DocumentHelper.GetDocuments<MenuItem>()
                .Columns("Title", "Url")
                .Select(x => new PrimaryMenuItemViewModel()
                {
                    Url = x.Url,
                    Title = x.Title,
                    SecondaryMenuItemViewModels = GetSecondaryMenuItems(x)
                }).ToList();
            return items;
        }

        private static List<SecondaryMenuItemViewModel> GetSecondaryMenuItems(MenuItem x)
        {
            return DocumentHelper.GetDocuments<SecondaryMenuItem>()
                        .Path(x.Url, PathTypeEnum.Children).Select(y => new SecondaryMenuItemViewModel()
                        {
                            Title = y.Title,
                            Url = y.Url
                        }).ToList();
        }
    }
}
