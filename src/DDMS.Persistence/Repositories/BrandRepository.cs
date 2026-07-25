using DDMS.Application.Features.Brands.Interfaces;
using DDMS.Domian.Entities;
using DDMS.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Persistence.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;

        public BrandRepository (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Brand brand)
        {
           await  _context.Brands.AddAsync(brand);
        }

        public void Delete(Brand brand)
        {
            _context.Brands.Remove(brand);
        }

        public async Task<bool> ExistsAsync(string code)
        {
            return await _context.Brands.AnyAsync(x=>x.Code == code);
        }

        public async Task<List<Brand>> GetAllAsync()
        {
           return await _context.Brands.OrderBy(x=>x.Name).ToListAsync();
        }

        public async Task<Brand?> GetByCodeAsync(string code)
        {
            return await _context.Brands.FirstOrDefaultAsync(x => x.Code == code);
        }

        public Task<Brand?> GetByIdAsync(Guid id)
        {
            return _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync()
        {
           await  _context.SaveChangesAsync();
        }

        public void Update(Brand brand)
        {
            _context.Brands.Update(brand);
        }
    }
}
