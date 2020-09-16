using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Web.Models.Restaurant
{
    public class RestaurantCategory
    {
        public string Name { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
