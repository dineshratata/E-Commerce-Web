using ApplicationLayer.Dto.Category;
using AutoMapper;
using DomainLayer.Common.Contracts;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Interfaces
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository,IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;

        }
        public async Task<BrandDto> CreateAsync(CreateBrandDto createBrandDto)
        {
            var entityFromDto     =  _mapper.Map<Brand>(createBrandDto);
            var addedEntity   = await  _brandRepository.CreateAsync(entityFromDto);
            var entityCreated   =  _mapper.Map<BrandDto>(addedEntity);
            return entityCreated;
        }

        public async Task DeleteAsync(int id)
        {
          var idForDelete  =  await  _brandRepository.GetByIdAsync(x=>x.Id==id);
              
          await  _brandRepository.DeleteAsync(idForDelete);
        }

        public async Task<IEnumerable<BrandDto>> GetAllAsync()
        {
            var brands   =  await  _brandRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<BrandDto>>(brands);

        }

        public async Task<BrandDto> GetByIdAsync(int id)
        {
             var detailedBrand  =await _brandRepository.GetByIdAsync(x => x.Id==id);
              
          return   _mapper.Map<BrandDto>(detailedBrand);
             
                
                }

        public async Task UpdateAsync(UpdateBrandDto updateBrandDto)
        {
           var brandForUp  = _mapper.Map<Brand>(updateBrandDto);

               await _brandRepository.UpdateAsync(brandForUp);


        }

       
    }
}
