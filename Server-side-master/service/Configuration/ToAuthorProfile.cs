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

            CreateMap<AUTHOR, Models.Author>().ForMember(dest => dest.bookList, opt => opt.MapFrom(AUTHOR => AUTHOR.BOOKs)).MaxDepth(2);
        }
    }
    public class FromAuthorProfile : Profile
    {
        public FromAuthorProfile()
        {
            CreateMap<Models.Author, AUTHOR>().ForMember(dest => dest.BOOKs, opt => opt.MapFrom(Author => Author.bookList)).MaxDepth(2);



        }


    }
}
