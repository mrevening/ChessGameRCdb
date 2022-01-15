using ChessGame.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Logic
{
    public class OrderStartedIntegrationEvent : Event
    {
        public string UserId { get; }

        public OrderStartedIntegrationEvent(string userId) => UserId = userId;
    }
}
