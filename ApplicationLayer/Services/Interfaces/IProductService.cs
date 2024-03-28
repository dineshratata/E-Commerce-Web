using ApplicationLayer.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Interfaces
{
    public interface IProductService 
    {

        Task<ProductDto> CreateAsync(CreateProductDto createProductDto);


        Task<IEnumerable<ProductDto>> GetAllAsync();

        Task<ProductDto>GetByIdAsync(int id);

        Task DeleteAsync(int id);   

        Task UpdateAsync(UpdateProductDto updateProductDto);
       


    }
}
