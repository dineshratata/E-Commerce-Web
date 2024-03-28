using ApplicationLayer.Dto.Category;
using ApplicationLayer.Services.Interfaces;
using AutoMapper;
using DomainLayer.Common.Contracts;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class CategoryService : ICategoryService

    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mappper;


        public CategoryService( ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mappper = mapper;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto createCategoryDto)
        {

             var  categoryfrmModel   = _mappper.Map<Category>(createCategoryDto);
             var createEnttiy  = await _categoryRepository.CreateAsync(categoryfrmModel);

               var entityFrommodel =   _mappper.Map<CategoryDto>(createEnttiy);

              return entityFrommodel;


        }

        public async Task DeleteAsync(int id)
        {
          var idForRemove  = await _categoryRepository.GetByIdAsync(x => x.Id == id);

           await _categoryRepository.DeleteAsync(idForRemove);



        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var catgories =    await _categoryRepository.GetAllAsync();

            return _mappper.Map<IEnumerable<CategoryDto>>(catgories);

        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
              var detailedCategory  = await _categoryRepository.GetByIdAsync(x=>x.Id == id);

             return _mappper.Map<CategoryDto>(detailedCategory);


        }

        public async Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
         var categoryUP  = _mappper.Map<Category>(updateCategoryDto);

            await _categoryRepository.UpdateAsync(categoryUP);



        }
    }
}
