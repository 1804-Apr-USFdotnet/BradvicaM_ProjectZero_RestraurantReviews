using System.Collections.Generic;
using RR.ViewModels;

namespace RR.Console.Views.Review
{
    public class RestaurantReviewsView : ActionResult
    {
        private readonly IEnumerable<ReviewViewModel> _viewModel;

        public RestaurantReviewsView(IEnumerable<ReviewViewModel> viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Render()
        {
            System.Console.Clear();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("\t\t\t\tReviews:");
            System.Console.WriteLine();
            foreach (var i in _viewModel)
            {
                System.Console.WriteLine($"\t\t\t\tName:\t\t{i.ReviewerName}");
                System.Console.WriteLine($"\t\t\t\tRating:\t\t{i.Rating}");
                System.Console.WriteLine($"\t\t\t\tComment:\t{i.Comment}");
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
            System.Console.WriteLine();
        }
    }
}
