using Autofac;
using AutoMapper;
using Repositories;
using RR.DomainContracts;
using RR.DomainServices;
using RR.Mapping;
using RR.RepositoryContracts;

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

            //Repositories
            builder.RegisterType<RestaurantRepository>().As<IRestaurantRepository>();
            builder.RegisterType<ReviewRepository>().As<ReviewRepository>();

            //Services
            builder.RegisterType<RestaurantService>().As<IRestaurantService>();

            Container = builder.Build();

            return Container;
        }
    }
}
