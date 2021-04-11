using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Models.Dish
{
    public class DishSubCategoryViewModel: DishViewModelBase
    {
        public List<DishViewModel> Dishes { get; set; }
    }
}
