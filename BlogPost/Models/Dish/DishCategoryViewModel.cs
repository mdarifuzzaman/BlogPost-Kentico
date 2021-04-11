using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Models.Dish
{
    public class DishCategoryViewModel: DishViewModelBase
    {
        public List<DishViewModel> Dishes { get; set; }
        public List<DishSubCategoryViewModel> DishSubCategories { get; set; }
    }
}
