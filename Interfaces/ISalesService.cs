using SalesEscord.Models.Persistance;

namespace SalesEscord.Interfaces
{
    public interface ISalesService
    {
        Task<IEnumerable<SalesModel>> FindAsync(int page, int limit);
        Task<IEnumerable<SalesModel>> FindAsync();
        Task CreateAsync();
        Task EditAsync();
    }
}
