using System;
using System.Threading.Tasks;
using Entrio.Common.Commands;
using Entrio.Common.Events;
using Entrio.Common.Exceptions;
using Entrio.Services.Activities.Services;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace Actio.Services.Activities.Handlers
{
    public class CreateEnytryHandler : ICommandHandler<CreateEntry>
    {
        private readonly ILogger _logger;
        private readonly IBusClient _busClient;
        private readonly IEntryService _entryService;

        public CreateEnytryHandler(IBusClient busClient,
            IEntryService entryService,
            ILogger<CreateEnytryHandler> logger)
        {
            _busClient = busClient;
            _entryService = entryService;
            _logger = logger;
        }

        public async Task HandleAsync(CreateEntry command)
        {
            _logger.LogInformation($"Creating entry: '{command.Id}' for user: '{command.UserId}'.");
            try
            {
                await _entryService.AddAsync(command.Id, command.UserId,
                    command.Currency, command.Timeframe, command.Indicators,
                    command.Name, command.Description, command.CreatedAt);
                await _busClient.PublishAsync(new EntryCreated(command.Id, command.UserId,
                    command.Currency, command.Timeframe, command.Indicators,
                    command.Name, command.Description, command.CreatedAt));
                _logger.LogInformation($"Activity: '{command.Id}' was created for user: '{command.UserId}'.");

                return;
            }
            catch (EntrioException ex)
            {
                _logger.LogError(ex, ex.Message);
                await _busClient.PublishAsync(new CreateEntryRejected(command.Id,
                   ex.Message, ex.Code));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await _busClient.PublishAsync(new CreateEntryRejected(command.Id,
                   ex.Message, "error"));
            }
        }
    }
}