using ApplicationLayer.Dto.Product;
using ApplicationLayer.Services.Interfaces;
using AutoMapper;
using DomainLayer.Common.Contracts;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepositry _productRepository;
        private IMapper _mapper;
        public ProductService(IProductRepositry productRepository, IMapper mapper)
        {
            _productRepository = productRepository;          
                
                _mapper = mapper;   
        }


        public async Task<ProductDto> CreateAsync(CreateProductDto createProductDto)
        {                    
               var products = _mapper.Map<Product>(createProductDto);

             var addedProd  = await _productRepository.CreateAsync(products);

               var  entityFrmDto = _mapper.Map<ProductDto>(addedProd);


            return entityFrmDto;
            
             

        
        }

        public async Task DeleteAsync(int id)
        {
          var IdForRemove = await _productRepository.GetByIdAsync(x => x.Id == id);

            await   _productRepository.DeleteAsync(IdForRemove);  

        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
          var ProductsAll    =  await  _productRepository.GetAllProductAsync();

           return _mapper.Map<IEnumerable<ProductDto>>(ProductsAll);

         
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {

            var detailedData  =await _productRepository.GetByIdAsync(x=>x.Id == id);       

            return _mapper.Map<ProductDto>(detailedData);

        }

        public async Task UpdateAsync(UpdateProductDto updateProductDto)
        {
             var productForUp  = _mapper.Map<Product>(updateProductDto);

                   await _productRepository.UpdateAsync(productForUp);


        }
    }
}
