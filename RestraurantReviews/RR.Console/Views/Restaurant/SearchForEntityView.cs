using System;
using System.Collections.Generic;
using RR.ViewModels;

namespace RR.Console.Views.Restaurant
{
    class SearchForEntityView : ActionResult
    {
        private readonly IEnumerable<RestaurantViewModel> _vm;

        public SearchForEntityView(IEnumerable<RestaurantViewModel> vm)
        {
            _vm = vm;
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }
}
