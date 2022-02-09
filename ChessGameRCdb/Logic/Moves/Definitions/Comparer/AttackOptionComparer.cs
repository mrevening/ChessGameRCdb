using System;
using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class AttackOptionComparer : EqualityComparer<AttackOption>
    {
        public override bool Equals(AttackOption one, AttackOption two) => StringComparer.InvariantCultureIgnoreCase.Equals(one.ToString(), two.ToString());
        public override int GetHashCode(AttackOption item) => StringComparer.InvariantCultureIgnoreCase.GetHashCode(item.ToString());
    }
}
