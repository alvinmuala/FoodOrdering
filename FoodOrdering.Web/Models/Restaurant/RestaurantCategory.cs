using System.Collections.Generic;

namespace FoodOrdering.Web.Models.Restaurant
{
    public class RestaurantCategory
    {
        public string Name { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
