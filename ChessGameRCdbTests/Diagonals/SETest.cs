using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;
using System.Linq;

namespace ChessGameTests
{
    public class SETest
    {
        //private static IFigure f1 = new Bishop(Color.White, new Coordinate("A8"));
        ////private static IFigure f2 = new Queen(Color.Black, new Coordinate("H1"));
        //public static IEnumerable<object[]> CoordinateEquality => new List<object[]> {
        //    new object[] {
        //        new SE().GetCoordinates(f1),
        //        new List<Coordinate>()
        //        {
        //            new Coordinate("B7"),
        //            new Coordinate("C6"),
        //            new Coordinate("D5"),
        //            new Coordinate("E4"),
        //            new Coordinate("F3"),
        //            new Coordinate("G2"),
        //            new Coordinate("H1")
        //        }
        //    },
        //    //new object[] {
        //    //    new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("C1"))),
        //    //    new List<Coordinate>()
        //    //    {
        //    //        new Coordinate("B2"),
        //    //        new Coordinate("C3")
        //    //    }
        //    //},
        //    //new object[] {
        //    //    new SE().GetCoordinates(f2),
        //    //    new List<Coordinate>(){ }
        //    //},
        //};

        public static IEnumerable<object[]> FirstLine => new List<object[]> {
            new object[] {
                new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("A1"))),
                new List<Coordinate>()
                {
                }
            },
            new object[] {
                new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("B1"))),
                new List<Coordinate>()
                {
                }
            },
            new object[] {
                new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("C1"))),
                new List<Coordinate>()
                {
                }
            },
            new object[] {
                new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("D1"))),
                new List<Coordinate>()
                {
                }
            },
            new object[] {
                new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("E1"))),
                new List<Coordinate>()
                {
                }
            },
            new object[] {
                new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("F1"))),
                new List<Coordinate>()
                {
                }
            },
            new object[] {
                new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("G1"))),
                new List<Coordinate>()
                {
                }
            },
            new object[] {
                new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("H1"))),
                new List<Coordinate>()
                {
                }
            }
        };

        public static IEnumerable<object[]> SecondLine => new List<object[]> {
            new object[] {
                new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("A2"))),
                new List<Coordinate>()
                {
                    new Coordinate("B1"),
                }
            },
            new object[] {
                new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("B2"))),
                new List<Coordinate>()
                {
                    new Coordinate("C1"),
                }
            },
            new object[] {
                new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("C2"))),
                new List<Coordinate>()
                {
                    new Coordinate("D1"),
                }
            },
            new object[] {
                new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("D2"))),
                new List<Coordinate>()
                {
                    new Coordinate("E1"),
                }
            },
            new object[] {
                new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("E2"))),
                new List<Coordinate>()
                {
                    new Coordinate("F1"),
                }
            },
            new object[] {
                new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("F2"))),
                new List<Coordinate>()
                {
                    new Coordinate("G1"),
                }
            },
            new object[] {
                new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("G2"))),
                new List<Coordinate>()
                {
                    new Coordinate("H1"),
                }
            },
            new object[] {
                new SE().GetCoordinates(new Bishop(Color.White, new Coordinate("H2"))),
                new List<Coordinate>()
                {
                }
            }
        };

        [Theory]
        [MemberData(nameof(FirstLine))]
        [MemberData(nameof(SecondLine))]
        public void Directions_ProperOrder_True(IEnumerable<Coordinate>actual, IEnumerable<Coordinate> expected)
        {
            Assert.Equal(expected, actual);
        }
    }
}
