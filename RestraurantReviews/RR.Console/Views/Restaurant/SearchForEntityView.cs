using System;
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
            throw new NotImplementedException();
        }
    }
}
