using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.EventBus
{
    public interface EventHandler<in TEvent> : IEventHandler where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {
    }
}
