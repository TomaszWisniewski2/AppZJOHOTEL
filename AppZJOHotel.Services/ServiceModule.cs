using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AppZJOHotel.Services.GuestService;

namespace AppZJOHotel.Services
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GuestService.GuestService>().As<IGuestService>();
        }
    }
}
