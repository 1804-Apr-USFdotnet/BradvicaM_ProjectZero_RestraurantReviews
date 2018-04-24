using System.Collections.Generic;
using RR.ViewModels;

namespace RR.Console.Views.Restaurant
{
    class AllRestaurantsView : ActionResult
    {
        private readonly IEnumerable<RestaurantNameViewModel> _vm;

        public AllRestaurantsView(IEnumerable<RestaurantNameViewModel> viewModel)
        {
            _vm = viewModel;
        }

        public override void Render()
        {
            System.Console.Clear();
            System.Console.WriteLine("****************************************************************");
            System.Console.WriteLine("*                           Restaurants:                       *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            foreach (var i in _vm)
            {
                System.Console.WriteLine($"*     Name: {i.Name}                           ");
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
