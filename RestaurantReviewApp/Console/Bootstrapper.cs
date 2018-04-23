using Autofac;
using Library.BusinessInterfaces;
using Library.BusinessLogic;
using Library.Logging;
using Library.Repositories;
using Library.RepositoryInterfaces;

namespace Console
{
    public class Bootstrapper
    {
        private static IContainer _container;

        public static IContainer RegisterTypes()
        {
            var builder = new ContainerBuilder();

            //var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            //var mapper = mapperConfiguration.CreateMapper();

            //EntityFramework Context
            builder.RegisterType<DataContext>().As<IContext>();

            //Automapper
            //builder.RegisterInstance(mapper).As<IMapper>();

            //Logging
            builder.RegisterType<LoggingService>().As<ILoggingService>();

            //Repositories
            builder.RegisterType<RestaurantRepository>().As<IRestaurantRepository>();
            builder.RegisterType<ReviewRepository>().As<IReviewRepository>();

            //Services
            builder.RegisterType<RestaurantService>().As<IRestaurantService>();
            builder.RegisterType<ReviewService>().As<IReviewService>();

            _container = builder.Build();

            return _container;
        }
    }
}
