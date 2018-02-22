using System;
using System.Collections.Generic;

namespace Entrio.Common.Commands
{
    public class CreateEntry : IAuthenticatedCommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Currency { get; set; }
        public string Timeframe { get; set; }
        public IEnumerable<string> Indicators { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}