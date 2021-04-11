using BlogPost.Models.Dish;
using BlogPost.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Models.Home
{
    public class HomeViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public List<PrimaryMenuItemViewModel> MenuItems { get; set; }

        public List<DishCategoryViewModel> Dishes { get; set; }
    }
}
