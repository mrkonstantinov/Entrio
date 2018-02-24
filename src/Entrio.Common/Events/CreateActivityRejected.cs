using System;

namespace Entrio.Common.Events
{
    public class CreateEntryRejected : IRejectedEvent
    {
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }

        protected CreateEntryRejected()
        {
        }

        public CreateEntryRejected(Guid id, 
            string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}