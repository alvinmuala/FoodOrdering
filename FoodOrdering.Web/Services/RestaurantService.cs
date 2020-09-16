using FoodOrdering.Web.Models.Restaurant;
using FoodOrdering.Web.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FoodOrdering.Web.Services
{
    public class RestaurantService : IRestaurantService
    {
        public List<RestaurantModel> GetRestaurants()
        {
            try
            {
                var jsonHelper = new JsonHelper();

                var restaurantsJson = jsonHelper.ReadFromFile("SampleData.json", "data");

                var restaurants = JsonConvert.DeserializeObject<List<RestaurantModel>>(restaurantsJson);

                return restaurants;
            }
            catch (Exception ex)
            {
                //todo: log exception 
                throw new Exception(ex.Message);
            }
        }
    }
}
