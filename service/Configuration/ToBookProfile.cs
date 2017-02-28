using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using repository;

namespace service.Configuration
{
    public class ToBookProfile : Profile
    {
        public ToBookProfile(){

        CreateMap<BOOK,Models.Books >();
            
        }
       
    }
    public class FromBookProfile : Profile
    {
        public FromBookProfile()
        {
            CreateMap<Models.Books, BOOK>();
        }



    }
}
