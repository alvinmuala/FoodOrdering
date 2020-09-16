using FoodOrdering.Web.Utilities;
using System.Collections.Generic;

namespace FoodOrdering.Web.Models.Restaurant
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string LogoPath { get; set; }
        public int Rank { get; set; }
        public List<RestaurantCategory> Categories { get; set; }
    }
}
