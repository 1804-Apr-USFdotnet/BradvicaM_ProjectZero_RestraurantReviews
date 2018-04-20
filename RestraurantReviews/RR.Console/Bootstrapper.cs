using Autofac;
using AutoMapper;
using RR.DomainContracts;
using RR.DomainServices;
using RR.Logging;
using RR.Mapping;
using RR.Repositories;
using RR.RepositoryContracts;

namespace RR.Console
{
    public class Bootstrapper
    {
        private static IContainer _container;

        public static IContainer RegisterTypes()
        {
            var builder = new ContainerBuilder();

            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            var mapper = mapperConfiguration.CreateMapper();

            //EntityFramework Context
            builder.RegisterType<RestaurantReviewsContext>().AsSelf().InstancePerLifetimeScope();

            //Automapper
            builder.RegisterInstance(mapper).As<IMapper>();

            //Logging
            builder.RegisterType<LoggingService>().As<ILoggingService>();

            //Repositories
            builder.RegisterType<RestaurantRepository>().As<IRestaurantRepository>();
            builder.RegisterType<ReviewRepository>().As<IReviewRepository>();

            //Services
            builder.RegisterType<RestaurantService>().As<IRestaurantService>();
            builder.RegisterType<ReviewService>().As<IReviewService>();

            //Console
            builder.RegisterType<InputOutput>().As<IInputOutput>();
            builder.RegisterType<Application>().As<IApplication>();

            _container = builder.Build();

            return _container;
        }
    }
}
