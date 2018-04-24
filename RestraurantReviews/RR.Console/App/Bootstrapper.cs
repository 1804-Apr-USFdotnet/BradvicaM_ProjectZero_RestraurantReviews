using Autofac;
using AutoMapper;
using RR.Console.Actions;
using RR.Console.Controllers;
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
            builder.RegisterType<FileLoggingService>().As<ILoggingService>();

            //Repositories
            builder.RegisterType<RestaurantRepository>().As<IRestaurantRepository>();
            builder.RegisterType<ReviewRepository>().As<IReviewRepository>();

            //Services
            builder.RegisterType<RestaurantService>().As<IRestaurantService>();
            builder.RegisterType<ReviewService>().As<IReviewService>();

            //Console
            builder.RegisterType<InputOutput>().As<IInputOutput>();

            //Console
            builder.RegisterType<Application>().As<IApplication>();

            //Controllers
            builder.RegisterType<RestaurantController>().AsSelf();
            builder.RegisterType<ReviewController>().AsSelf();
            builder.RegisterType<HomeController>().AsSelf();

            //Application Actions
            builder.RegisterType<AddRestaurantAction>().AsSelf();
            builder.RegisterType<AllReviewsOfRestaurantAction>().AsSelf();
            builder.RegisterType<DefaultAction>().AsSelf();
            builder.RegisterType<ReviewRestaurantAction>().AsSelf();
            builder.RegisterType<SearchAction>().AsSelf();
            builder.RegisterType<TopThreeRatedRestaurantsAction>().AsSelf();
            builder.RegisterType<ViewAllRestaurantsAction>().AsSelf();
            builder.RegisterType<ViewRestaurantDetailsAction>().AsSelf();

            _container = builder.Build();

            return _container;
        }
    }
}
