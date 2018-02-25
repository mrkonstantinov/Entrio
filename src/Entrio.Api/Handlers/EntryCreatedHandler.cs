using System;
using System.Threading.Tasks;
using Entrio.Api.Models;
using Entrio.Api.Repositories;
using Entrio.Common.Events;

namespace Entrio.Api.Handlers
{
    public class EntryCreatedHandler : IEventHandler<EntryCreated>
    {
        private readonly IEntryRepository _repository;

        public EntryCreatedHandler(IEntryRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(EntryCreated @event)
        {
            await _repository.AddAsync(new Entry
            {
                Id = @event.Id,
                UserId = @event.UserId,
                Currency = @event.Currency,
                Timeframe = @event.Timeframe,
                Indicators = @event.Indicators,
                Name = @event.Name,
                CreatedAt = @event.CreatedAt,
                Description = @event.Description
            });
            Console.WriteLine($"Entry created: {@event.Name}");
        }
    }
}