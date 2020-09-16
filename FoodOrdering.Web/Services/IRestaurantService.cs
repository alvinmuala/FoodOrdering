using FoodOrdering.Web.Models.Restaurant;
using System.Collections.Generic;

namespace FoodOrdering.Web.Services
{
    public interface IRestaurantService
    {
        List<RestaurantModel> GetRestaurants();
    }
}
