using Autofac;

namespace RR.Console
{
    class Program
    {
        static void Main()
        {
            var container = Bootstrapper.RegisterTypes();
            
            var application = new Application(container.Resolve<IInputOutput>(), container);

            application.Run();
        }
    }
}
