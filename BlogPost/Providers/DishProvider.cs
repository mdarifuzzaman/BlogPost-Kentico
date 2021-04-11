using BlogPost.Models.Dish;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.HouseRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Providers
{
    public class DishProvider
    {
        public static List<DishCategoryViewModel> GetDishCategories()
        {
            var items = DocumentHelper.GetDocuments<DishCategory>()
                .Columns("Title", "Url", "NodeID", "CssClass", "ElementId")
                .Select(x => new DishCategoryViewModel()
                {
                    Title = x.Title,
                    Path = x.Url,
                    CssClass = x.CssClass,
                    ElementId = x.ElementId,
                    Dishes = GetDishes(x),
                    DishSubCategories = GetSubCategories(x),
                }).ToList();

            return items;
        }

        private static List<DishViewModel> GetDishes(DishCategory x)
        {

            return DocumentHelper.GetDocuments<Dish>()
                    .WhereEquals("NodeParentID", x.NodeID).Select(y => new DishViewModel()
                        {
                            Title = y.Title,
                            Discount = y.Discount,
                            Image = y.Image,
                            Price = y.OriginalPrice,
                            Summary = y.Summary
                        }).ToList();
        }

        private static List<DishViewModel> GetSubCategoryDishes(DishSubCategory x)
        {
            return DocumentHelper.GetDocuments<Dish>()
                    .WhereEquals("NodeParentID", x.NodeID).Select(y => new DishViewModel()
                        {
                            Title = y.Title,
                            Discount = y.Discount,
                            Image = y.Image,
                            Price = y.OriginalPrice,
                            Summary = y.Summary
                        }).ToList();
        }

        private static List<DishSubCategoryViewModel> GetSubCategories(DishCategory x)
        {
            return DocumentHelper.GetDocuments<DishSubCategory>()
                    .WhereEquals("NodeParentID", x.NodeID).Select(y => new DishSubCategoryViewModel()
                        {
                            Title = y.Title,
                            Path = y.Url,
                            CssClass = y.CssClass,
                            ElementId = y.ElementId,
                            Dishes = GetSubCategoryDishes(y)
                        }).ToList();
        }
    }
}
