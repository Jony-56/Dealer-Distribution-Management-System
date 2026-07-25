using DDMS.Domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Application.Features.Brands.Interfaces
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAllAsync();
        Task<Brand?> GetByIdAsync (Guid id);

        Task<Brand?> GetByCodeAsync(string code);

        Task AddAsync (Brand brand);

        void Update (Brand brand);
        void Delete (Brand brand);
        Task<bool> ExistsAsync(string code);
        Task SaveChangesAsync();

    }
}
