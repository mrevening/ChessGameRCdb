using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public static class UnitTransposition
    {
        private static readonly Dictionary<Coordinate, Diagonal> CoordinateToDiagonal = new Dictionary<Coordinate, Diagonal>()
        {
            { new Coordinate(Column.A, Row.One), new Diagonal(X.X_4, Y.Y0, C.Black) },
            { new Coordinate(Column.B, Row.One), new Diagonal(X.X_3, Y.Y_1, C.White) },
            { new Coordinate(Column.C, Row.One), new Diagonal(X.X_3, Y.Y_1, C.Black) },
            { new Coordinate(Column.D, Row.One), new Diagonal(X.X_2, Y.Y_2, C.White) },
            { new Coordinate(Column.E, Row.One), new Diagonal(X.X_2, Y.Y_2, C.Black) },
            { new Coordinate(Column.F, Row.One), new Diagonal(X.X_1, Y.Y_3, C.White) },
            { new Coordinate(Column.G, Row.One), new Diagonal(X.X_1, Y.Y_3, C.Black) },
            { new Coordinate(Column.H, Row.One), new Diagonal(X.X0, Y.Y_4, C.White) },

            { new Coordinate(Column.A, Row.Two), new Diagonal(X.X_3, Y.Y1, C.White) },
            { new Coordinate(Column.B, Row.Two), new Diagonal(X.X_3, Y.Y0, C.Black) },
            { new Coordinate(Column.C, Row.Two), new Diagonal(X.X_2, Y.Y_1, C.White) },
            { new Coordinate(Column.D, Row.Two), new Diagonal(X.X_2, Y.Y_1, C.Black) },
            { new Coordinate(Column.E, Row.Two), new Diagonal(X.X_1, Y.Y_2, C.White) },
            { new Coordinate(Column.F, Row.Two), new Diagonal(X.X_1, Y.Y_2, C.Black) },
            { new Coordinate(Column.G, Row.Two), new Diagonal(X.X0, Y.Y_3, C.White) },
            { new Coordinate(Column.H, Row.Two), new Diagonal(X.X1, Y.Y_3, C.Black) },

            { new Coordinate(Column.A, Row.Three), new Diagonal(X.X_3, Y.Y1, C.Black) },
            { new Coordinate(Column.B, Row.Three), new Diagonal(X.X_2, Y.Y1, C.White) },
            { new Coordinate(Column.C, Row.Three), new Diagonal(X.X_2, Y.Y0, C.Black) },
            { new Coordinate(Column.D, Row.Three), new Diagonal(X.X_1, Y.Y_1, C.White) },
            { new Coordinate(Column.E, Row.Three), new Diagonal(X.X_1, Y.Y_1, C.Black) },
            { new Coordinate(Column.F, Row.Three), new Diagonal(X.X0, Y.Y_2, C.White) },
            { new Coordinate(Column.G, Row.Three), new Diagonal(X.X1, Y.Y_2, C.Black) },
            { new Coordinate(Column.H, Row.Three), new Diagonal(X.X1, Y.Y_3, C.White) },

            { new Coordinate(Column.A, Row.Four), new Diagonal(X.X_2, Y.Y2, C.White) },
            { new Coordinate(Column.B, Row.Four), new Diagonal(X.X_2, Y.Y1, C.Black) },
            { new Coordinate(Column.C, Row.Four), new Diagonal(X.X_1, Y.Y1, C.White) },
            { new Coordinate(Column.D, Row.Four), new Diagonal(X.X_1, Y.Y0, C.Black) },
            { new Coordinate(Column.E, Row.Four), new Diagonal(X.X0, Y.Y_1, C.White) },
            { new Coordinate(Column.F, Row.Four), new Diagonal(X.X1, Y.Y_1, C.Black) },
            { new Coordinate(Column.G, Row.Four), new Diagonal(X.X1, Y.Y_2, C.White) },
            { new Coordinate(Column.H, Row.Four), new Diagonal(X.X2, Y.Y_2, C.Black) },

            { new Coordinate(Column.A, Row.Five), new Diagonal(X.X_2, Y.Y2, C.Black) },
            { new Coordinate(Column.B, Row.Five), new Diagonal(X.X_1, Y.Y2, C.White) },
            { new Coordinate(Column.C, Row.Five), new Diagonal(X.X_1, Y.Y1, C.Black) },
            { new Coordinate(Column.D, Row.Five), new Diagonal(X.X0, Y.Y1, C.White) },
            { new Coordinate(Column.E, Row.Five), new Diagonal(X.X1, Y.Y0, C.Black) },
            { new Coordinate(Column.F, Row.Five), new Diagonal(X.X1, Y.Y_1, C.White) },
            { new Coordinate(Column.G, Row.Five), new Diagonal(X.X2, Y.Y_1, C.Black) },
            { new Coordinate(Column.H, Row.Five), new Diagonal(X.X2, Y.Y_2, C.White) },

            { new Coordinate(Column.A, Row.Six), new Diagonal(X.X_1, Y.Y3, C.White) },
            { new Coordinate(Column.B, Row.Six), new Diagonal(X.X_1, Y.Y2, C.Black) },
            { new Coordinate(Column.C, Row.Six), new Diagonal(X.X0, Y.Y2, C.White) },
            { new Coordinate(Column.D, Row.Six), new Diagonal(X.X1, Y.Y1, C.Black) },
            { new Coordinate(Column.E, Row.Six), new Diagonal(X.X1, Y.Y1, C.White) },
            { new Coordinate(Column.F, Row.Six), new Diagonal(X.X2, Y.Y0, C.Black) },
            { new Coordinate(Column.G, Row.Six), new Diagonal(X.X2, Y.Y_1, C.White) },
            { new Coordinate(Column.H, Row.Six), new Diagonal(X.X3, Y.Y_1, C.Black) },

            { new Coordinate(Column.A, Row.Seven), new Diagonal(X.X_1, Y.Y3, C.Black) },
            { new Coordinate(Column.B, Row.Seven), new Diagonal(X.X0, Y.Y3, C.White) },
            { new Coordinate(Column.C, Row.Seven), new Diagonal(X.X1, Y.Y2, C.Black) },
            { new Coordinate(Column.D, Row.Seven), new Diagonal(X.X1, Y.Y2, C.White) },
            { new Coordinate(Column.E, Row.Seven), new Diagonal(X.X2, Y.Y1, C.Black) },
            { new Coordinate(Column.F, Row.Seven), new Diagonal(X.X2, Y.Y1, C.White) },
            { new Coordinate(Column.G, Row.Seven), new Diagonal(X.X3, Y.Y0, C.Black) },
            { new Coordinate(Column.H, Row.Seven), new Diagonal(X.X3, Y.Y_1, C.White) },

            { new Coordinate(Column.A, Row.Eight), new Diagonal(X.X0, Y.Y4, C.White) },
            { new Coordinate(Column.B, Row.Eight), new Diagonal(X.X1, Y.Y3, C.Black) },
            { new Coordinate(Column.C, Row.Eight), new Diagonal(X.X1, Y.Y3, C.White) },
            { new Coordinate(Column.D, Row.Eight), new Diagonal(X.X2, Y.Y2, C.Black) },
            { new Coordinate(Column.E, Row.Eight), new Diagonal(X.X2, Y.Y2, C.White) },
            { new Coordinate(Column.F, Row.Eight), new Diagonal(X.X3, Y.Y1, C.Black) },
            { new Coordinate(Column.G, Row.Eight), new Diagonal(X.X3, Y.Y1, C.White) },
            { new Coordinate(Column.H, Row.Eight), new Diagonal(X.X4, Y.Y0, C.Black) },
        };
        private static readonly Dictionary<Diagonal, Coordinate> DiagonalToCoordinate = CoordinateToDiagonal.ToDictionary((i) => i.Value, (i) => i.Key);

        public static Coordinate GetCoordinate(this Diagonal d) => DiagonalToCoordinate.GetValueOrDefault(d);
        public static Diagonal GetDiagonal(this Coordinate c) => CoordinateToDiagonal.GetValueOrDefault(c);
    }
}
