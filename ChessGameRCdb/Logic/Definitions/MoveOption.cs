using System;
using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class MoveOption
    {
        public Coordinate Coordinate { get; }
        public List<ActionType> Actions { get; private set; }
        public MoveOption(Coordinate c, ActionType action)
        {
            Coordinate = c;
            Actions = new List<ActionType>() { action };
        }
        public MoveOption(Coordinate c, List<ActionType> actionTypes)
        {
            Coordinate = c;
            Actions = actionTypes;
        }
        public void AddAction(ActionType action)
        {
            Actions.Add(action);
        }
    }
}
