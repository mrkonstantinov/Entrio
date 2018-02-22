using System;
using System.Collections.Generic;

namespace Entrio.Common.Events
{
    public class EntryCreated : IAuthenticatedEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Currency { get; set; }
        public string Timeframe { get; set; }
        public IEnumerable<string> Indicators { get; set; }
        public string Name { get; }
        public string Description { get; }
        public DateTime CreatedAt { get; }

        protected EntryCreated()
        {
        }

        public EntryCreated(Guid id, Guid userId,
            string currency, string timeframe, IEnumerable<string> indicators,
            string name,
            string description, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            Currency = currency;
            Timeframe = timeframe;
            Indicators = indicators;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}