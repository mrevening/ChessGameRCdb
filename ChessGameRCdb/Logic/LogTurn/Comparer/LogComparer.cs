using System;
using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class LogComparer : EqualityComparer<Log>
    {
        public override bool Equals(Log one, Log two) => StringComparer.InvariantCultureIgnoreCase.Equals(one.ToString(), two.ToString());
        public override int GetHashCode(Log item) => StringComparer.InvariantCultureIgnoreCase.GetHashCode(item.ToString());
    }
}
