using System;
using RR.Console.Views;

namespace RR.Console.Controllers
{
    public abstract class Controller : IController
    {
        protected ViewEngine ViewEngine { get; }

        protected Controller()
        {
            ViewEngine = new ViewEngine();
        }

        public void Execute(string request)
        {
            throw new NotImplementedException();
        }
    }
}
