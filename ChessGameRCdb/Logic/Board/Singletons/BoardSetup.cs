using System.Collections.Generic;
using System.Collections.Immutable;

namespace ChessGame.Logic
{
    public class BoardSetup
    {
        private BoardSetup() { }
        private static BoardSetup _instance;
        public static BoardSetup GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BoardSetup();
            }
            return _instance;
        }

        public IImmutableList<IFigure> GetOnePawnSetup()
        {
            var list = new List<IFigure>() {
                new Pawn(Color.White, Column.D, Row.Two)
            };
            return ImmutableList.CreateRange(list).ToImmutableList();
        }
        public IImmutableList<IFigure> GetOnePawnAlreadyMovedSetup()
        {
            var list = new List<IFigure>() {
                new Pawn(Color.White, Column.D, Row.Three)
            };
            return ImmutableList.CreateRange(list).ToImmutableList();
        }

        public IImmutableList<IFigure> GetTwoPawnsCase1Setup()
        {
            var list = new List<IFigure>() {
                new Pawn(Color.White, Column.D, Row.Two),
                new Pawn(Color.Black, Column.D, Row.Four)
            };
            return ImmutableList.CreateRange(list).ToImmutableList();
        }

        public IImmutableList<IFigure> GetTwoPawnsEnFaceSetup()
        {
            var list = new List<IFigure>() {
                new Pawn(Color.White, Column.D, Row.Four),
                new Pawn(Color.Black, Column.D, Row.Five)
            };
            return ImmutableList.CreateRange(list).ToImmutableList();
        }
        public IImmutableList<IFigure> GetTwoPawnsDiagonalSetup()
        {
            var list = new List<IFigure>() {
                new Pawn(Color.White, Column.D, Row.Four),
                new Pawn(Color.Black, Column.E, Row.Five)
            };
            return ImmutableList.CreateRange(list).ToImmutableList();
        }

        public IImmutableList<IFigure> GetTwoPawnsEnPassantSetup()
        {
            var list = new List<IFigure>() {
                new Pawn(Color.White, Column.D, Row.Five),
                new Pawn(Color.Black, Column.E, Row.Seven)
            };
            return ImmutableList.CreateRange(list).ToImmutableList();
        }

        public IImmutableList<IFigure> GetAllWhitePionsSetup()
        {
            var list = new List<IFigure>() {
                new Pawn(Color.White, Column.A, Row.Two),
                new Pawn(Color.White, Column.B, Row.Two),
                new Pawn(Color.White, Column.C, Row.Two),
                new Pawn(Color.White, Column.D, Row.Two),
                new Pawn(Color.White, Column.E, Row.Two),
                new Pawn(Color.White, Column.F, Row.Two),
                new Pawn(Color.White, Column.G, Row.Two),
                new Pawn(Color.White, Column.H, Row.Two),
            };
            return ImmutableList.CreateRange(list).ToImmutableList();
        }

        public IImmutableList<IFigure> GetStandardSetup()
        {
            var list = new List<IFigure>() {
                new Rook(Color.White, Column.A, Row.One),
                new Knight(Color.White, Column.B, Row.One),
                new Bishop(Color.White, Column.C, Row.One),
                new Queen(Color.White, Column.D, Row.One),
                new King(Color.White, Column.E, Row.One),
                new Bishop(Color.White, Column.F, Row.One),
                new Knight(Color.White, Column.G, Row.One),
                new Rook(Color.White, Column.H, Row.One),

                new Pawn(Color.White, Column.A, Row.Two),
                new Pawn(Color.White, Column.B, Row.Two),
                new Pawn(Color.White, Column.C, Row.Two),
                new Pawn(Color.White, Column.D, Row.Two),
                new Pawn(Color.White, Column.E, Row.Two),
                new Pawn(Color.White, Column.F, Row.Two),
                new Pawn(Color.White, Column.G, Row.Two),
                new Pawn(Color.White, Column.H, Row.Two),

                new Pawn(Color.Black, Column.A, Row.Seven),
                new Pawn(Color.Black, Column.B, Row.Seven),
                new Pawn(Color.Black, Column.C, Row.Seven),
                new Pawn(Color.Black, Column.D, Row.Seven),
                new Pawn(Color.Black, Column.E, Row.Seven),
                new Pawn(Color.Black, Column.F, Row.Seven),
                new Pawn(Color.Black, Column.G, Row.Seven),
                new Pawn(Color.Black, Column.H, Row.Seven),

                new Rook(Color.Black, Column.A, Row.Eight),
                new Knight(Color.Black, Column.B, Row.Eight),
                new Bishop(Color.Black, Column.C, Row.Eight),
                new Queen(Color.Black, Column.D, Row.Eight),
                new King(Color.Black, Column.E, Row.Eight),
                new Bishop(Color.Black, Column.F, Row.Eight),
                new Knight(Color.Black, Column.G, Row.Eight),
                new Rook(Color.Black, Column.H, Row.Eight),
            };
            return ImmutableList.CreateRange(list).ToImmutableList();
        }
    }
}
