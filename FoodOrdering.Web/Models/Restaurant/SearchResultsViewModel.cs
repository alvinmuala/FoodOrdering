using System.Collections.Generic;

namespace FoodOrdering.Web.Models.Restaurant
{
    public class SearchResultsViewModel
    {
        public List<RestaurantModel> Restaurants { get; set; }
        public string City { get; set; }
        public string MenuItemName { get; set; }
        public string SearchString { get; set; }
    }
}
