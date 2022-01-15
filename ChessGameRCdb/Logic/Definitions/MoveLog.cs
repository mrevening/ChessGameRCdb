using System.Collections;
using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class MoveLog : IEnumerable
    {
        private List<MoveLog> _items = new List<MoveLog>();

        public MoveLog(Coordinate startPoint, Coordinate endPoint, int @event)
        {
            var count = _items.Count;
            Counter = count++;

            StartPoint = startPoint;
            EndPoint = endPoint;
            WhatHappened = @event;
        }

        public int Counter { get; private set; }
        public Coordinate StartPoint { get; private set; }
        public Coordinate EndPoint { get; private set; }
        public int WhatHappened { get; private set; }

        public void Add(MoveLog log) => _items.Add(log);
        public IEnumerator GetEnumerator() => _items.GetEnumerator();
  }
}
