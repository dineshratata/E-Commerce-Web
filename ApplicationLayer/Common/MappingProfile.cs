using ApplicationLayer.Dto.Category;
using AutoMapper;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Common
{
    public class MappingProfile : Profile
    {
       public MappingProfile()
        {

            CreateMap<Category,CreateBrandDto>().ReverseMap();
            CreateMap<Category, UpdateBrandDto>().ReverseMap();
            CreateMap<Category, BrandDto>().ReverseMap();





            CreateMap<Category, CreateBrandDto>().ReverseMap();
            CreateMap<Category, UpdateBrandDto>().ReverseMap();
            CreateMap<Category, BrandDto>().ReverseMap();



        }

    }
}
