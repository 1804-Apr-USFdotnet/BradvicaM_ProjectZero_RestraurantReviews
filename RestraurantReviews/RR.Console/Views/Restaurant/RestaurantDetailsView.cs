using RR.ViewModels;

namespace RR.Console.Views.Restaurant
{
    public class RestaurantDetailsView : ActionResult
    {
        private readonly RestaurantViewModel _viewModel;

        public RestaurantDetailsView(RestaurantViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Render()
        {
            System.Console.Clear();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("\t\t\t\tRestaurant Details:");
            System.Console.WriteLine();
            System.Console.WriteLine($"\t\t\t\tName:\t\t\t{_viewModel.Name}");
            System.Console.WriteLine($"\t\t\t\tStreet:\t\t\t{_viewModel.Street}");
            System.Console.WriteLine($"\t\t\t\tCity:\t\t\t{_viewModel.City}");
            System.Console.WriteLine($"\t\t\t\tState:\t\t\t{_viewModel.State}");
            System.Console.WriteLine($"\t\t\t\tZip Code:\t\t{_viewModel.ZipCode}");
            System.Console.WriteLine($"\t\t\t\tPhone Number:\t\t{_viewModel.PhoneNumber}");
            System.Console.WriteLine($"\t\t\t\tAverage Rating:\t\t{_viewModel.AverageRating}");
            System.Console.WriteLine($"\t\t\t\tWebsite:\t\t{_viewModel.Website}");
            System.Console.WriteLine();
            System.Console.WriteLine();
        }
    }
}
