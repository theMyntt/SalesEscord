using SalesEscord.Models;
using SalesEscord.Models.Persistance;

namespace SalesEscord.Interfaces
{
    public interface ISalesService
    {
        Task<SalesViewModel> FindAsync(int page, int limit);
        Task<IEnumerable<SalesModel>> FindAsync();
        Task CreateAsync(SalesModel sale);
        Task EditAsync(SalesModel sale);
    }
}
