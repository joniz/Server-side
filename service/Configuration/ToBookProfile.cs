using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using repository;
using service.Models;

namespace service.Configuration
{
    public class ToBookProfile : Profile
    {
        public ToBookProfile(){

        CreateMap<BOOK,Models.Books >().ForMember(dest => dest.AUTHORs, opt => opt.MapFrom(BOOK => BOOK.AUTHORs)).MaxDepth(2);
            
        }
       
    }
    public class FromBookProfile : Profile
    {
        public FromBookProfile()
        {
            CreateMap<Models.Books, BOOK>().ForMember(dest => dest.AUTHORs, opt => opt.MapFrom(Books => Books.AUTHORs)).MaxDepth(2);
        }



    }
}
