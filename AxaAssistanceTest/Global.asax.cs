using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AxaAssistanceTest.Models.Entities.Books;
using AxaAssistanceTest.Models.Repositories.Books;
using AxaAssistanceTest.Models.Repositories.Customers;
using AxaAssistanceTest.Models.Repositories.DAL.EntityFramework;
using AxaAssistanceTest.Models.Repositories.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AxaAssistanceTest
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var iocBuilder = new ContainerBuilder();

            iocBuilder.RegisterControllers(typeof(WebApiApplication).Assembly);
            iocBuilder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            iocBuilder.RegisterFilterProvider();
            iocBuilder.RegisterModule<AutofacWebTypesModule>();

            iocBuilder.RegisterType<AxaLibraryContext>().InstancePerRequest();

            iocBuilder.RegisterType<EntityFrameworkBookRepository>().As<IBookRepository>().InstancePerRequest();
            iocBuilder.RegisterType<EntityFrameworkCustomerRepository>().As<ICustomerRepository>().InstancePerRequest();
            iocBuilder.RegisterType<EntityFrameworkReservationRepository>().As<IReservationRepository>().InstancePerRequest();

            var iocContainer = iocBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(iocContainer));

            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(iocContainer);
        }
    }
}
