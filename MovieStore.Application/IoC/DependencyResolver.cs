using Autofac;
using AutoMapper;
using MovieStore.Application.Mapping;
using MovieStore.Application.Services.AppUserServices;
using MovieStore.Application.Services.CategoryServices;
using MovieStore.Application.Services.DirectorServices;
using MovieStore.Application.Services.LanguageService;
using MovieStore.Application.Services.MovieServices;
using MovieStore.Application.Services.StarringServices;
using MovieStore.Domain.Repositories;
using MovieStore.Infrastructure.Repositories;

namespace MovieStore.Application.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mapper>().As<IMapper>().InstancePerLifetimeScope();
            builder.RegisterType<MovieService>().As<IMovieService>().InstancePerLifetimeScope();
            builder.RegisterType<LanguageService>().As<ILanguageService>().InstancePerLifetimeScope();
            builder.RegisterType<DirectorService>().As<IDirectorService>().InstancePerLifetimeScope();
            builder.RegisterType<StarringService>().As<IStarringService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();


            builder.RegisterType<MovieRepository>().As<IMovieRepository>().InstancePerLifetimeScope();
            builder.RegisterType<LanguageRepository>().As<ILanguageRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DirectorRepository>().As<IDirectorRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StarringRepository>().As<IStarringRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserRepository>().As<IAppUserRepository>().InstancePerLifetimeScope();


            #region AutoMapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<MappingProfile>(); /// AutoMapper klasörünün altına eklediğimiz Mapping classını bağlıyoruz.
            }
            )).AsSelf().SingleInstance();



            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
            #endregion

            base.Load(builder);
        }


    }
}
