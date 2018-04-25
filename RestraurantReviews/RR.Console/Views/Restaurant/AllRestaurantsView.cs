using System.Collections.Generic;
using RR.ViewModels;

namespace RR.Console.Views.Restaurant
{
    public class AllRestaurantsView : ActionResult
    {
        private readonly IEnumerable<RestaurantNameViewModel> _viewModel;

        public AllRestaurantsView(IEnumerable<RestaurantNameViewModel> viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Render()
        {
            System.Console.Clear();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("\t\t\t\tRestaurants:");
            System.Console.WriteLine();
            foreach (var i in _viewModel)
            {
                System.Console.WriteLine($"\t\t\t\tName: {i.Name}");
            }
            System.Console.WriteLine();
            System.Console.WriteLine();
        }
    }
}
