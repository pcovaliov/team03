using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
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

            builder.RegisterType<UserDALImpl>().SingleInstance();
            builder.RegisterType<TweetDALImpl>();
            builder.RegisterType<UserServiceImpl>().SingleInstance();
            builder.RegisterType<TweetServiceImpl>();
            builder.Register<IUserDAL>(UserDAL => UserDAL.Resolve<UserDALImpl>()).SingleInstance();
            builder.Register<ITweetDAL>(TweetDAL => TweetDAL.Resolve<TweetDALImpl>());
            builder.Register<IUserService>(UserService => UserService.Resolve<UserServiceImpl>()).SingleInstance();
            builder.Register<ITweetService>(TweetService => TweetService.Resolve<TweetServiceImpl>());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}