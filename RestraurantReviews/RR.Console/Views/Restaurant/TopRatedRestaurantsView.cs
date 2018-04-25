using System.Collections.Generic;
using RR.ViewModels;

namespace RR.Console.Views.Restaurant
{
    public class TopRatedRestaurantsView : ActionResult
    {
        private readonly IEnumerable<TopRatedRestaurantViewModel> _viewModel;

        public TopRatedRestaurantsView(IEnumerable<TopRatedRestaurantViewModel> viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Render()
        {
            System.Console.Clear();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("\t\t\t\tTop Rated Restaurants:");
            System.Console.WriteLine();
            foreach (var i in _viewModel)
            {
                System.Console.WriteLine($"\t\t\t\tName: {i.Name}\tRating: {i.AverageRating}");
            }
            System.Console.WriteLine();
            System.Console.WriteLine();
        }
    }
}
