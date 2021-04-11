using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Models.Menu
{
    public class PrimaryMenuItemViewModel: MenuItemViewModel
    {
        public List<SecondaryMenuItemViewModel> SecondaryMenuItemViewModels { get; set; }
    }
}
