using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using System.Configuration;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Infrastructure.Concrete;

namespace SportsStore.WebUI.Infrastructure
{
    public static class Environment
    {
        public static bool IsLive => Convert.ToBoolean(ConfigurationManager.AppSettings.Get("IsLive"));
        public static string Email => IsLive ? ConfigurationManager.AppSettings.Get("Email") : ConfigurationManager.AppSettings.Get("TestEmail");
    }
   
}
