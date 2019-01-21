using Flunt.Notifications;
using MediatR;

namespace Quotation.Domain.Seedwork {
    public abstract class Command<T> : Notifiable, IRequest<T> {

    }
}
