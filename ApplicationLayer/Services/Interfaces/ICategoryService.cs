using ApplicationLayer.Dto.Category;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateAsync(CreateCategoryDto createCategoryDto);

        Task<IEnumerable<CategoryDto>> GetAllAsync();

        Task<CategoryDto> GetByAsync(int Id);

        Task UpdateAsync(UpdateCategoryDto updateCategoryDto);

        Task DeleteAsync(int Id);



    }
}
