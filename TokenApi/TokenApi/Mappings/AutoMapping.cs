using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TokenApi.Models;
using TokenApi.DTos;

using AutoMapper;

namespace TokenApi.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Productos, ProductsDto>().ReverseMap(); ;
        }

    }
}
