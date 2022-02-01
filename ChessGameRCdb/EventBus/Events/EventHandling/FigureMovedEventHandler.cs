using ChessGame.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Logic
{
    public class FigureMovedEventHandler : EventBus.EventHandler<OrderStartedIntegrationEvent>
    {
        public FigureMovedEventHandler()
        {
        }

        public async Task Handle(OrderStartedIntegrationEvent @event)
        {
        }
    }
}
