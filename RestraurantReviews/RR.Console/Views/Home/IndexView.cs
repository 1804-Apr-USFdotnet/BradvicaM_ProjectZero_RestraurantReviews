namespace RR.Console.Views.Home
{
    internal class IndexView : ActionResult
    {
        public override void Render()
        {
            System.Console.WriteLine("****************************************************************");
            System.Console.WriteLine("*                   Options Available:                         *");
            System.Console.WriteLine("*     1 - Add Restaurant                                       *");
            System.Console.WriteLine("*     2 - View All Restaurants                                 *");
            System.Console.WriteLine("*     3 - Review Restaurants                                   *");
            System.Console.WriteLine("*     4 - Top Three Rated Restaurants                          *");
            System.Console.WriteLine("*     5 - View Restaurant Details                              *");
            System.Console.WriteLine("*     6 - Find Restaurant Reviews                              *");
            System.Console.WriteLine("*     7 - Search By Keyword                                    *");
            System.Console.WriteLine("*     8 - Quit Application                                     *");
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
