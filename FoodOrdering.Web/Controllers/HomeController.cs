using FoodOrdering.Web.Models;
using FoodOrdering.Web.Models.Restaurant;
using FoodOrdering.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace FoodOrdering.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRestaurantService _restaurantService;

        public HomeController(ILogger<HomeController> logger, IRestaurantService restaurantService)
        {
            _logger = logger;
            _restaurantService = restaurantService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SearchRestaurant(SearchParameterModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.SearchString))
            {
                //process and manipulate string
                //if string parameters exist in json file then do something else return error 
                //var restaurants = _restaurantService.GetRestaurants();
            }
            else
            {
                //return error message
            }
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
