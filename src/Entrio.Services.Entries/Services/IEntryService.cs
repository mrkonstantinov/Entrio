using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entrio.Services.Activities.Services
{
    public interface IEntryService
    {
        Task AddAsync(Guid id, Guid userId,
            string currency, string timeframe, IEnumerable<string> indicators,
            string name, string description, DateTime createdAt);
    }
}