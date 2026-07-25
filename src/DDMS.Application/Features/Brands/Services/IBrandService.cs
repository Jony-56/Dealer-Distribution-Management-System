using DDMS.Application.Features.Brands.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Application.Features.Brands.Services
{
    public interface IBrandService
    {
        Task<List<BrandResponse>>  GetAllAsync ();
        Task <List<BrandResponse?>> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync (CreateBrandRequest request);
        Task UpdateAsync (UpdateBrandRequest request);
        Task DeleteAsync (Guid id);

    }
}
