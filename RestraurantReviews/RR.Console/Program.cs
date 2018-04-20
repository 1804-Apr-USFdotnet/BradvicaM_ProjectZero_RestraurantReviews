using Autofac;

namespace RR.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Bootstrapper.RegisterTypes();
            var application = container.Resolve<IApplication>();

            application.Run();
        }
    }
}
