using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Models.Dish
{
    public class DishViewModelBase
    {
        public string Title { get; set; }
        public string Path { get; set; }

        public string CssClass { get; set; }
        public string ElementId { get; set; }
    }
}
