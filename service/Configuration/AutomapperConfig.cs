using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using service.Models;
using repository;
namespace service.Configuration
{
    public class AutomapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new ToAuthorProfile());
                cfg.AddProfile(new FromAuthorProfile());
                cfg.AddProfile(new ToBookProfile());
                cfg.AddProfile(new FromBookProfile());
                cfg.AddProfile(new ToClassificationProfile());
                cfg.AddProfile(new FromClassificationProfile());
                //cfg.AddProfile(new FromEmployeeProfile());
                cfg.AddProfile(new ToAccountProfile());
                cfg.AddProfile(new FromAccountProfile());
            });
        }
    }
}
