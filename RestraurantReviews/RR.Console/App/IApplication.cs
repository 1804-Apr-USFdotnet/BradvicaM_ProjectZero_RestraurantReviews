using Autofac;

namespace RR.Console
{
    public interface IApplication
    {
        void Run();
        void RegisterActions(IContainer container);
    }
}
