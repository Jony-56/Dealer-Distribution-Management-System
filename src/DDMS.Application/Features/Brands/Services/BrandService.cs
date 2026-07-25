using DDMS.Application.Features.Brands.DTOs;
using DDMS.Application.Features.Brands.Interfaces;
using DDMS.Domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Application.Features.Brands.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<Guid> CreateAsync(CreateBrandRequest request)
        {
           if (await _brandRepository.ExistsAsync(request.Code))
            {
                throw new Exception("Brand Code Already Exist");
            }

            var brand =  Brand.Create(
                request.Name,
                request.Code,
                request.Description
                
                );
             await _brandRepository.AddAsync(brand);
            await _brandRepository.SaveChangesAsync();
            return brand.Id;


        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BrandResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<BrandResponse?>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateBrandRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
