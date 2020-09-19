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
                //todo: future improvements- some .NET Logging tools such as Elmah should be used here for exceptions and errors logging here 
                throw new Exception(ex.Message);
            }
        }
    }
}
