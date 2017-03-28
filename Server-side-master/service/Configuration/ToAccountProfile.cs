using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using repository;
namespace service.Configuration
{
    public class ToAccountProfile : Profile
    {
        public ToAccountProfile()
        {
            CreateMap<ACCOUNT, Models.Account>();
            
        }
       
    }
    public class FromAccountProfile : Profile
    {
       
        public FromAccountProfile()
        {
            CreateMap<Models.Account, ACCOUNT>();
        }
    }
}
