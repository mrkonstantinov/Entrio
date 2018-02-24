using System;
using System.Threading.Tasks;
using Entrio.Services.Entries.Domain.Models;

namespace Entrio.Services.Entries.Domain.Repositories
{
    public interface IEntryRepository
    {
        Task<Entry> GetAsync(Guid id);
        Task AddAsync(Entry entry);
        Task DeleteAsync(Guid id); 
    }
}