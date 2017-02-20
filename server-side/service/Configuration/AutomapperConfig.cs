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
                cfg.AddProfile(new ToDepartmentProfile());
                cfg.AddProfile(new FromDepartmentProfile());
                cfg.AddProfile(new ToEmployeeProfile());
                cfg.AddProfile(new FromEmployeeProfile());
            });
        }
    }
}
