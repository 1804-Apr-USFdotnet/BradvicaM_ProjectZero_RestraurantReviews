using Autofac;
using AutoMapper;
using RR.DomainContracts;
using RR.DomainServices;
using RR.Mapping;
using RR.Repositories;
using RR.RepositoryContracts;
using IRestaurantService = RR.DomainContracts.IRestaurantService;
using RestaurantService = RR.DomainServices.RestaurantService;

namespace RR.Console
{
    public class Bootstrapper
    {
        public static IContainer Container;

        public static IContainer RegisterTypes()
        {
            var builder = new ContainerBuilder();

            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            var mapper = mapperConfiguration.CreateMapper();

            //EntityFramework Context
            builder.RegisterType<RestaurantReviewsContext>().AsSelf().InstancePerLifetimeScope();

            //Automapper
            builder.RegisterInstance(mapper).As<IMapper>();

            //Repositories
            builder.RegisterType<Repositories.RestaurantRepository>().As<RepositoryContracts.IRestaurantRepository>();
            builder.RegisterType<ReviewRepository>().As<ReviewRepository>();

            //Services
            builder.RegisterType<RestaurantService>().As<IRestaurantService>();

            Container = builder.Build();

            return Container;
        }
    }
}
