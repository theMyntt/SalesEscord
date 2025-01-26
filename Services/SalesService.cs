using Microsoft.EntityFrameworkCore;
using SalesEscord.Context;
using SalesEscord.Interfaces;
using SalesEscord.Models.Persistance;

namespace SalesEscord.Services
{
    public class SalesService : ISalesService
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<SalesModel> _sales;

        public SalesService(DatabaseContext context)
        {
            _context = context;
            _sales = _context.Set<SalesModel>();
        }

        public async Task CreateAsync(SalesModel sale)
        {
            await _sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(SalesModel sale)
        {
            _sales.Update(sale);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SalesModel>> FindAsync(int page, int limit)
        {
            var skip = (page - 1) * limit;

            return await _sales
                .Skip(skip)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesModel>> FindAsync()
        {
            return await _sales.ToListAsync();
        }
    }
}
