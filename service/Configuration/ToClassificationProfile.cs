using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using repository;

namespace service.Configuration
{
    class ToClassificationProfile : Profile
    {
        public ToClassificationProfile()
        {

            CreateMap<CLASSIFICATION, Models.Classification>();
        }
    }
    class FromClassificationProfile : Profile
    {
        public FromClassificationProfile()
        {
            CreateMap<Models.Classification, CLASSIFICATION>();


        }


    }
}