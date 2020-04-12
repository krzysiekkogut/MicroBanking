using MicroBanking.Domain.Core.Events;
using System.Threading.Tasks;

namespace MicroBanking.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> where TEvent : Event
    {
        Task Handle(TEvent ev);
    }
}