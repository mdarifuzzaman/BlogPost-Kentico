using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Models.Dish
{
    public class DishViewModel: DishViewModelBase
    {
        public string Summary { get; set; }
        public string Image { get; set; }

        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
