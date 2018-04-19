using Autofac;
using RR.DomainContracts;

namespace RR.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Bootstrapper.RegisterTypes();

            var service = container.Resolve<IRestaurantService>();

            var allRestaurants = service.AllRestaurants();

            foreach (var i in allRestaurants)
            {
                System.Console.WriteLine(i);
            }

            System.Console.ReadLine();
        }
    }
}
