using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using repository;

namespace service.Configuration
{
    class ToBookProfile : Profile
    {
        public ToBookProfile(){

        CreateMap<Models.Books, BOOK>();
            
        }
    }
}
