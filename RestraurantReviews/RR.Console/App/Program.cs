﻿using Autofac;

namespace RR.Console
{
    class Program
    {
        static void Main()
        {
            var container = Bootstrapper.RegisterTypes();
            var application = container.Resolve<IApplication>();
            application.RegisterActions(container);
            application.Run();
        }
    }
}
