using System;

namespace FoodOrdering.Web.Helpers
{
    public static class CurrencyHelper
    {
        public static string TruncatedCurrency(decimal value, string currencySymbol)
        {
            var result = (int)Decimal.Truncate(value);
            return string.Format(currencySymbol + result.ToString());
        }
    }
}
