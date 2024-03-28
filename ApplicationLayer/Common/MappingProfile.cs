using ApplicationLayer.Dto.Category;
using ApplicationLayer.Dto.Product;
using AutoMapper;
using DomainLayer.Models;
using Microsoft.Extensions.Options;
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

            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();





            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();


            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ForMember(x => x.Category, Options => Options.MapFrom(src => src.Category.Name))
            .ForMember(x => x.Brand, Options => Options.MapFrom(src => src.Brand.Name));

         /// for Specific Memeber 

        //  ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName));

        }

    }
}
