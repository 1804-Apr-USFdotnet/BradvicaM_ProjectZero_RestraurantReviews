using RR.ViewModels;

namespace RR.Console.Views.Restaurant
{
    class RestaurantDetailsView : ActionResult
    {
        private readonly RestaurantViewModel _vm;

        public RestaurantDetailsView(RestaurantViewModel vm)
        {
            _vm = vm;
        }

        public override void Render()
        {
            System.Console.Clear();
            System.Console.WriteLine("****************************************************************");
            System.Console.WriteLine("*                     Restaurant Details:                      *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine("*                                                              *");
            System.Console.WriteLine($"*     Name:           {_vm.Name}            ");
            System.Console.WriteLine($"*     Street:         {_vm.Street}            ");
            System.Console.WriteLine($"*     City:           {_vm.City}            ");
            System.Console.WriteLine($"*     State:          {_vm.State}            ");
            System.Console.WriteLine($"*     Zip Code:       {_vm.ZipCode}            ");
            System.Console.WriteLine($"*     Phone Number:   {_vm.PhoneNumber}            ");
            System.Console.WriteLine($"*     Average Rating: {_vm.AverageRating}            ");
            System.Console.WriteLine($"*     Website:        {_vm.Website}            ");
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
