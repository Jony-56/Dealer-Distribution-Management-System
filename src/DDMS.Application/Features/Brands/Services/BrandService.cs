using AutoMapper;
using DDMS.Application.Features.Brands.DTOs;
using DDMS.Application.Features.Brands.Interfaces;
using DDMS.Domian.Entities;

namespace DDMS.Application.Features.Brands.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(
            IBrandRepository brandRepository,
            IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<List<BrandResponse>> GetAllAsync()
        {
            var brands = await _brandRepository.GetAllAsync();

            return _mapper.Map<List<BrandResponse>>(brands);
        }

        public async Task<BrandResponse?> GetByIdAsync(Guid id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);

            if (brand == null)
            {
                return null;
            }

            return _mapper.Map<BrandResponse>(brand);
        }

        public async Task<Guid> CreateAsync(CreateBrandRequest request)
        {
            var isExists = await _brandRepository.ExistsAsync(request.Code);

            if (isExists)
            {
                throw new Exception("Brand code already exists.");
            }

            var brand = DDMS.Domian.Entities.Brand.Create(
                request.Name,
                request.Code,
                request.Description);

            await _brandRepository.AddAsync(brand);
            await _brandRepository.SaveChangesAsync();

            return brand.Id;
        }

        public async Task UpdateAsync(UpdateBrandRequest request)
        {
            var brand = await _brandRepository.GetByIdAsync(request.Id);

            if (brand == null)
            {
                throw new Exception("Brand not found.");
            }

            brand.Update(
                request.Name,
                request.Code,
                request.Description);

            _brandRepository.Update(brand);

            await _brandRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);

            if (brand == null)
            {
                throw new Exception("Brand not found.");
            }

            _brandRepository.Delete(brand);

            await _brandRepository.SaveChangesAsync();
        }
    }
}