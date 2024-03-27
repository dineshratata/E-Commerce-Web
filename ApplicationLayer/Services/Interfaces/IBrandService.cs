using ApplicationLayer.Dto.Category;
using DomainLayer.Common.Contracts;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Interfaces
{
    public interface IBrandService 
    {
       Task <BrandDto> CreateAsync(CreateBrandDto createBrandDto);

        Task<IEnumerable<BrandDto>> GetAllAsync();


        Task UpdateAsync(UpdateBrandDto updateBrandDto);


        Task <BrandDto> GetByIdAsync(int id);

        Task DeleteAsync(int id);   


       

    


    }
}
