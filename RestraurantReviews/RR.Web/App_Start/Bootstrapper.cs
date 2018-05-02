using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using RR.DomainContracts;
using RR.DomainServices;
using RR.Logging;
using RR.Mapping;
using RR.Repositories;
using RR.RepositoryContracts;

namespace RR.Web
{
    public class Bootstrapper
    {
        private static IContainer _container;

        public static IContainer RegisterTypes()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            var mapper = mapperConfiguration.CreateMapper();

            //EntityFramework Context
            builder.RegisterType<RestaurantReviewsContext>().AsSelf().InstancePerLifetimeScope();

            //Automapper
            builder.RegisterInstance(mapper).As<IMapper>();

            builder.RegisterType<FileLoggingService>().As<ILoggingService>();

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