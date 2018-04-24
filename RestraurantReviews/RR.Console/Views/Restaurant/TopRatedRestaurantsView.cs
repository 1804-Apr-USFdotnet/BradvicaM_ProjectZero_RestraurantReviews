using System.Collections.Generic;
using RR.ViewModels;

namespace RR.Console.Views.Restaurant
{
    internal class TopRatedRestaurantsView : ActionResult
    {
        private readonly IEnumerable<TopRatedRestaurantViewModel> _vm;

        public TopRatedRestaurantsView(IEnumerable<TopRatedRestaurantViewModel> vm)
        {
            _vm = vm;
        }

        public override void Render()
        {
            System.Console.Clear();
            System.Console.WriteLine("****************************************************************");
            System.Console.WriteLine("*                     Top Rated Restaurants:                   *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            foreach (var i in _vm)
            {
                System.Console.WriteLine($"*  Name: {i.Name}     Rating: {i.AverageRating}    ");
            }
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("****************************************************************");
        }
    }
}
