using LocadoraDDD.Application;
using LocadoraDDD.Application.Interface;
using LocadoraDDD.Domain.Interfaces.Repositories;
using LocadoraDDD.Domain.Interfaces.Services;
using LocadoraDDD.Domain.Services;
using LocadoraDDD.Infra.Data.Repositories;
using LocadoraDDD.MVC.App_Start;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using System;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace LocadoraDDD.MVC.App_Start
{

    //Arquivo para mapear as interfaces, para os seus respectivos services/repositories.
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Bind<IRepo>().ToMethod(ctx => new Repo("Ninject Rocks!"));
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IFilmeAppService>().To<FilmeAppService>();
            kernel.Bind<IGeneroAppService>().To<GeneroAppService>();
            kernel.Bind<ILocacaoAppService>().To<LocacaoAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IFilmeService>().To<FilmeService>();
            kernel.Bind<IGeneroService>().To<GeneroService>();
            kernel.Bind<ILocacaoService>().To<LocacaoService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IFilmeRepository>().To<FilmeRepository>();
            kernel.Bind<IGeneroRepository>().To<GeneroRepository>();
            kernel.Bind<ILocacaoRepository>().To<LocacaoRepository>();
        }
    }
}