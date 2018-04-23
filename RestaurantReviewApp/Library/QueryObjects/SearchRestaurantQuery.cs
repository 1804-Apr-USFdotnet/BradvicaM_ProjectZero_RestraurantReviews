using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Library.Models;

namespace Library.QueryObjects
{
    public class SearchRestaurantQuery
    {
        private readonly string _value;

        public SearchRestaurantQuery(string value)
        {
            _value = value;
        }

        public List<Restaurant> AsExpression(IEnumerable<Restaurant> restaurants)
        {
            return (from x in restaurants
                where Regex.IsMatch(x.Name, _value)
                      || Regex.IsMatch(x.PhoneNumber, _value)
                      || Regex.IsMatch(x.Website, _value)
                      || Regex.IsMatch(x.City, _value)
                      || Regex.IsMatch(x.State, _value)
                      || Regex.IsMatch(x.Street, _value)
                      || Regex.IsMatch(x.ZipCode.ToString(), _value)
                      || Regex.IsMatch(x.AverageRating.ToString(CultureInfo.CurrentCulture), _value)
                select x).ToList();
        }
    }
}
