using System.Collections.Generic;
using RR.ViewModels;

namespace RR.Console.Views.Review
{
    public class InputAddReviewView : ActionResult
    {
        private readonly IEnumerable<RestaurantNameViewModel> _viewModel;

        public InputAddReviewView(IEnumerable<RestaurantNameViewModel> viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Render()
        {
            System.Console.Clear();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("\t\t\t\tRestaurants Available For Review:");
            System.Console.WriteLine();
            foreach (var i in _viewModel)
            {
                System.Console.WriteLine($"\t\t\t\tName: {i.Name}");
            }
            System.Console.WriteLine("\t\t\t\tInput The Following:");
            System.Console.WriteLine();
            System.Console.WriteLine("\t\t\t\tRestaurant Name:");
            System.Console.WriteLine("\t\t\t\tYour Name:");
            System.Console.WriteLine("\t\t\t\tRating:");
            System.Console.WriteLine("\t\t\t\tComment:");
            System.Console.WriteLine();
            System.Console.WriteLine();
        }
    }
}
