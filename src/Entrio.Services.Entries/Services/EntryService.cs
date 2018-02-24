using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entrio.Common.Exceptions;
using Entrio.Services.Entries.Domain.Models;
using Entrio.Services.Entries.Domain.Repositories;

namespace Entrio.Services.Activities.Services
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _entryRepository;

        public EntryService(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public async Task AddAsync(Guid id, Guid userId,
            string currency, string timeframe, IEnumerable<string> indicators,
            string name, string description, DateTime createdAt)
        {
            var activity = new Entry(id, userId, 
                    currency, timeframe, indicators, 
                    name, description, createdAt);
            await _entryRepository.AddAsync(activity);
        }
    }
}