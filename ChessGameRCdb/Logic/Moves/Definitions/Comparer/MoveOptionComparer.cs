using System;
using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class MoveOptionComparer : EqualityComparer<MoveOption>
    {
        public override bool Equals(MoveOption one, MoveOption two) => StringComparer.InvariantCultureIgnoreCase.Equals(one.ToString(), two.ToString());
        public override int GetHashCode(MoveOption item) => StringComparer.InvariantCultureIgnoreCase.GetHashCode(item.ToString());
    }
}
