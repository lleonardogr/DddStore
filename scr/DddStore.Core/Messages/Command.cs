using MediatR;
using FluentValidation.Results;

namespace DddStore.Core.Messages
{
    public class Command : Message,IRequest<bool>
    {
        public DateTime Timestamp { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
