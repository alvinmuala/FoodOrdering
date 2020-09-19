using FoodOrdering.Web.Models;
using FoodOrdering.Web.Models.Restaurant;
using FoodOrdering.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;

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
            var model = new SearchResultsViewModel();
            var errorMessage = TempData["ErrorMessage"];

            if (errorMessage != null)
            {
                ViewBag.ErrorMessage = errorMessage;
            }

            var displaySearchResults = TempData["SearchResults"] != null ? true : false;
            ViewBag.DisplaySearchResults = displaySearchResults;

            if (displaySearchResults)
            {
                var searchResults = TempData["SearchResults"] as string;
                model = JsonConvert.DeserializeObject<SearchResultsViewModel>(searchResults);
                return View(model);
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SearchRestaurant(SearchResultsViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.SearchString))
            {
                var searchString = model.SearchString.ToUpperInvariant();

                if (searchString.Contains("IN"))
                {
                    var stringsSplit = searchString.Split(new string[] { "IN" }, StringSplitOptions.None);

                    var menuItem = stringsSplit[0].TrimStart().TrimEnd();

                    var city = stringsSplit[1].TrimStart().TrimEnd();

                    var restaurants = _restaurantService.GetRestaurants();

                    var query = restaurants
                        .Where(r => r.City.ToUpperInvariant() == city &&
                            (r.Categories.Any(c => c.Name.ToUpperInvariant().Contains(menuItem) || c.MenuItems.Any(mi => mi.Name.ToUpperInvariant().Contains(menuItem)))))
                        .OrderBy(x => x.Rank)
                        .ToList();


                    if (query.Count == 0)
                    {
                        TempData["ErrorMessage"] = "Ooops! No restaurant is serving what you are looking for at the moment. \n Please try something else. " +
                            "\n e.g: Taco in Cape Town";

                        RedirectToAction("Index");
                    }
                    else
                    {
                        model.Restaurants = query;
                        model.City = query.First().City;
                        model.MenuItemName = menuItem;

                        TempData["SearchResults"] = JsonConvert.SerializeObject(model);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Oops! It seems like you have entered some invalid text " +
                           "\n Please try again by using the format (MenuItem) in (City)." +
                           " e.g: Taco in Cape Town";

                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Oops! Please try again by typing something into the search bar using the format (MenuItem) in (City)" +
                          "\n e.g: Taco in Cape Town";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
