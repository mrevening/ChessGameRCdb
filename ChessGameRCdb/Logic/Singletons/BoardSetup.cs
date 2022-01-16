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
                new Pawn(Player.White, Column.D, Row.Two)
            };
            return ImmutableList.CreateRange(list).ToImmutableList();
        }
        public IImmutableList<IFigure> GetOnePawnAlreadyMovedSetup()
        {
            var list = new List<IFigure>() {
                new Pawn(Player.White, Column.D, Row.Three)
            };
            return ImmutableList.CreateRange(list).ToImmutableList();
        }

        public IImmutableList<IFigure> GetTwoPawnsCase1Setup()
        {
            var list = new List<IFigure>() {
                new Pawn(Player.White, Column.D, Row.Two),
                new Pawn(Player.Black, Column.D, Row.Four)
            };
            return ImmutableList.CreateRange(list).ToImmutableList();
        }

        public IImmutableList<IFigure> GetTwoPawnsEnFaceSetup()
        {
            var list = new List<IFigure>() {
                new Pawn(Player.White, Column.D, Row.Four),
                new Pawn(Player.Black, Column.D, Row.Five)
            };
            return ImmutableList.CreateRange(list).ToImmutableList();
        }
        public IImmutableList<IFigure> GetTwoPawnsDiagonalSetup()
        {
            var list = new List<IFigure>() {
                new Pawn(Player.White, Column.D, Row.Four),
                new Pawn(Player.Black, Column.E, Row.Five)
            };
            return ImmutableList.CreateRange(list).ToImmutableList();
        }

        public IImmutableList<IFigure> GetTwoPawnsEnPassantSetup()
        {
            var list = new List<IFigure>() {
                new Pawn(Player.White, Column.D, Row.Five),
                new Pawn(Player.Black, Column.E, Row.Seven)
            };
            return ImmutableList.CreateRange(list).ToImmutableList();
        }

        public IImmutableList<IFigure> GetStandardSetup()
        {
            var list = new List<IFigure>() {
                new Rook(Player.White, Column.A, Row.One),
                new Knight(Player.White, Column.B, Row.One),
                new Bishop(Player.White, Column.C, Row.One),
                new Queen(Player.White, Column.D, Row.One),
                new King(Player.White, Column.E, Row.One),
                new Bishop(Player.White, Column.F, Row.One),
                new Knight(Player.White, Column.G, Row.One),
                new Rook(Player.White, Column.H, Row.One),

                new Pawn(Player.White, Column.A, Row.Two),
                new Pawn(Player.White, Column.B, Row.Two),
                new Pawn(Player.White, Column.C, Row.Two),
                new Pawn(Player.White, Column.D, Row.Two),
                new Pawn(Player.White, Column.E, Row.Two),
                new Pawn(Player.White, Column.F, Row.Two),
                new Pawn(Player.White, Column.G, Row.Two),
                new Pawn(Player.White, Column.H, Row.Two),

                new Pawn(Player.Black, Column.A, Row.Seven),
                new Pawn(Player.Black, Column.B, Row.Seven),
                new Pawn(Player.Black, Column.C, Row.Seven),
                new Pawn(Player.Black, Column.D, Row.Seven),
                new Pawn(Player.Black, Column.E, Row.Seven),
                new Pawn(Player.Black, Column.F, Row.Seven),
                new Pawn(Player.Black, Column.G, Row.Seven),
                new Pawn(Player.Black, Column.H, Row.Seven),

                new Rook(Player.Black, Column.A, Row.Eight),
                new Knight(Player.Black, Column.B, Row.Eight),
                new Bishop(Player.Black, Column.C, Row.Eight),
                new Queen(Player.Black, Column.D, Row.Eight),
                new King(Player.Black, Column.E, Row.Eight),
                new Bishop(Player.Black, Column.F, Row.Eight),
                new Knight(Player.Black, Column.G, Row.Eight),
                new Rook(Player.Black, Column.H, Row.Eight),
            };
            return ImmutableList.CreateRange(list).ToImmutableList();
        }
    }
}
