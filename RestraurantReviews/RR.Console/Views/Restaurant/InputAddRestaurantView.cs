namespace RR.Console.Views.Restaurant
{
    public class InputAddRestaurantView : ActionResult
    {
        public override void Render()
        {
            System.Console.Clear();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("\t\t\t\tInput The Following:");
            System.Console.WriteLine();
            System.Console.WriteLine("\t\t\t\tRestaurant Name:");
            System.Console.WriteLine("\t\t\t\tStreet Address:");
            System.Console.WriteLine("\t\t\t\tCity:");
            System.Console.WriteLine("\t\t\t\tState Initials:");
            System.Console.WriteLine("\t\t\t\tZip Code:");
            System.Console.WriteLine("\t\t\t\tPhone Number:");
            System.Console.WriteLine("\t\t\t\tWebsite:");
            System.Console.WriteLine();
            System.Console.WriteLine();
        }
    }
}
