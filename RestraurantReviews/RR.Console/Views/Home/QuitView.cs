namespace RR.Console.Views.Home
{
    public class QuitView : ActionResult
    {
        public override void Render()
        {
            System.Console.Clear();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine($"\t\t\t\tGoodbye!");
            System.Console.WriteLine();
            System.Console.WriteLine();
        }
    }
}
