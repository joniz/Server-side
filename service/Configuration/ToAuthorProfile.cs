using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using repository;

namespace service.Configuration
{
    public class ToAuthorProfile : Profile
    {
        public ToAuthorProfile()
        {
            
            CreateMap<Models.Author, AUTHOR>();
        }
    }
}
