using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.Web.Models.Restaurant
{
    public class SearchParameterModel
    {
        [Required]
        public string SearchString { get; set; }
    }
}
