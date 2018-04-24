namespace RR.Console.Views.Home
{
    public class IndexView : ActionResult
    {
        public override void Render()
        {
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("\t\t\t\tOptions Available:");
            System.Console.WriteLine();
            System.Console.WriteLine("\t\t\t\t1 - Add A Restaurant");
            System.Console.WriteLine("\t\t\t\t2 - View All Restaurants");
            System.Console.WriteLine("\t\t\t\t3 - Review A Restaurant");
            System.Console.WriteLine("\t\t\t\t4 - Top Three Rated Restaurants");
            System.Console.WriteLine("\t\t\t\t5 - View Restaurant Details");
            System.Console.WriteLine("\t\t\t\t6 - Find Restaurant Reviews");
            System.Console.WriteLine("\t\t\t\t7 - Search By Keyword");
            System.Console.WriteLine("\t\t\t\t8 - Quit Application");
            System.Console.WriteLine();
            System.Console.WriteLine();
        }
    }
}
