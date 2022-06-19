using DddStore.Core.Messages;
using MediatR;

namespace DddStore.Core.Messages.CommonMessages.DomainEvents
{
    public class DomainEvent : Message, INotification
    {
        public DateTime TimeStamp { get; private set; }

        protected DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
            TimeStamp = DateTime.UtcNow;
        }
    }
}
