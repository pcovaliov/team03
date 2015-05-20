using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Autofac.Builder;
using Twitter.DAL;
using Twitter.Services;

namespace Twitter.WEB.App_Start
{
    public class DependecyInjectionConfig 
    {
        public static void Configure() 
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            builder.RegisterType<UserDAL>().As<IUserDAL>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<TweetDAL>().As<ITweetDAL>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<TweetService>().As<ITweetService>().SingleInstance().PropertiesAutowired();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}