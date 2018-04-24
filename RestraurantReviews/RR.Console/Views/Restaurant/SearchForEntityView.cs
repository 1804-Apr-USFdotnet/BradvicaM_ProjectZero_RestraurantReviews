using System.Collections.Generic;
using RR.ViewModels;

namespace RR.Console.Views.Restaurant
{
    public class SearchForEntityView : ActionResult
    {
        private readonly IEnumerable<RestaurantViewModel> _viewModel;

        public SearchForEntityView(IEnumerable<RestaurantViewModel> viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Render()
        {
            System.Console.Clear();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("\t\t\t\tSearch Results:");
            System.Console.WriteLine();
            foreach (var i in _viewModel)
            {
                System.Console.WriteLine($"\t\t\t\tName:\t\t\t{i.Name}");
                System.Console.WriteLine($"\t\t\t\tStreet:\t\t\t{i.Street}");
                System.Console.WriteLine($"\t\t\t\tCity:\t\t\t{i.City}");
                System.Console.WriteLine($"\t\t\t\tState:\t\t\t{i.State}");
                System.Console.WriteLine($"\t\t\t\tZip Code:\t\t{i.ZipCode}");
                System.Console.WriteLine($"\t\t\t\tPhone Number:\t\t{i.PhoneNumber}");
                System.Console.WriteLine($"\t\t\t\tAverage Rating:\t\t{i.AverageRating}");
                System.Console.WriteLine($"\t\t\t\tWebsite:\t\t{i.Website}");
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
            System.Console.WriteLine();
        }
    }
}
