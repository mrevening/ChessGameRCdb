using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;

namespace ChessGameTests
{
    public class NWTest
    {
        public static IEnumerable<object[]> BishopOnFirstLine => new List<object[]> {
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("H1"))),
                new List<Coordinate>()
                {
                    new Coordinate("G2"),
                    new Coordinate("F3"),
                    new Coordinate("E4"),
                    new Coordinate("D5"),
                    new Coordinate("C6"),
                    new Coordinate("B7"),
                    new Coordinate("A8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("G1"))),
                new List<Coordinate>()
                {
                    new Coordinate("F2"),
                    new Coordinate("E3"),
                    new Coordinate("D4"),
                    new Coordinate("C5"),
                    new Coordinate("B6"),
                    new Coordinate("A7")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("F1"))),
                new List<Coordinate>()
                {
                    new Coordinate("E2"),
                    new Coordinate("D3"),
                    new Coordinate("C4"),
                    new Coordinate("B5"),
                    new Coordinate("A6")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("E1"))),
                new List<Coordinate>()
                {
                    new Coordinate("D2"),
                    new Coordinate("C3"),
                    new Coordinate("B4"),
                    new Coordinate("A5")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("D1"))),
                new List<Coordinate>()
                {
                    new Coordinate("C2"),
                    new Coordinate("B3"),
                    new Coordinate("A4")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("C1"))),
                new List<Coordinate>()
                {
                    new Coordinate("B2"),
                    new Coordinate("A3")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("B1"))),
                new List<Coordinate>()
                {
                    new Coordinate("A2")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("A1"))),
                new List<Coordinate>()
                {
                }
            }
        };
        public static IEnumerable<object[]> BishopOnSecondLine => new List<object[]> {
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("H2"))),
                new List<Coordinate>()
                {
                    new Coordinate("G3"),
                    new Coordinate("F4"),
                    new Coordinate("E5"),
                    new Coordinate("D6"),
                    new Coordinate("C7"),
                    new Coordinate("B8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("G2"))),
                new List<Coordinate>()
                {
                    new Coordinate("F3"),
                    new Coordinate("E4"),
                    new Coordinate("D5"),
                    new Coordinate("C6"),
                    new Coordinate("B7"),
                    new Coordinate("A8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("F2"))),
                new List<Coordinate>()
                {
                    new Coordinate("E3"),
                    new Coordinate("D4"),
                    new Coordinate("C5"),
                    new Coordinate("B6"),
                    new Coordinate("A7")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("E2"))),
                new List<Coordinate>()
                {
                    new Coordinate("D3"),
                    new Coordinate("C4"),
                    new Coordinate("B5"),
                    new Coordinate("A6")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("D2"))),
                new List<Coordinate>()
                {
                    new Coordinate("C3"),
                    new Coordinate("B4"),
                    new Coordinate("A5")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("C2"))),
                new List<Coordinate>()
                {
                    new Coordinate("B3"),
                    new Coordinate("A4")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("B2"))),
                new List<Coordinate>()
                {
                    new Coordinate("A3")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("A2"))),
                new List<Coordinate>()
                {
                }
            }
        };
        public static IEnumerable<object[]> BishopOnThirdLine => new List<object[]> {
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("H3"))),
                new List<Coordinate>()
                {
                    new Coordinate("G4"),
                    new Coordinate("F5"),
                    new Coordinate("E6"),
                    new Coordinate("D7"),
                    new Coordinate("C8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("G3"))),
                new List<Coordinate>()
                {
                    new Coordinate("F4"),
                    new Coordinate("E5"),
                    new Coordinate("D6"),
                    new Coordinate("C7"),
                    new Coordinate("B8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("F3"))),
                new List<Coordinate>()
                {
                    new Coordinate("E4"),
                    new Coordinate("D5"),
                    new Coordinate("C6"),
                    new Coordinate("B7"),
                    new Coordinate("A8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("E3"))),
                new List<Coordinate>()
                {
                    new Coordinate("D4"),
                    new Coordinate("C5"),
                    new Coordinate("B6"),
                    new Coordinate("A7")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("D3"))),
                new List<Coordinate>()
                {
                    new Coordinate("C4"),
                    new Coordinate("B5"),
                    new Coordinate("A6")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("C3"))),
                new List<Coordinate>()
                {
                    new Coordinate("B4"),
                    new Coordinate("A5")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("B3"))),
                new List<Coordinate>()
                {
                    new Coordinate("A4")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("A3"))),
                new List<Coordinate>()
                {
                }
            }
        };
        public static IEnumerable<object[]> BishopOnFourhLine => new List<object[]> {
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("H4"))),
                new List<Coordinate>()
                {
                    new Coordinate("G5"),
                    new Coordinate("F6"),
                    new Coordinate("E7"),
                    new Coordinate("D8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("G4"))),
                new List<Coordinate>()
                {
                    new Coordinate("F5"),
                    new Coordinate("E6"),
                    new Coordinate("D7"),
                    new Coordinate("C8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("F4"))),
                new List<Coordinate>()
                {
                    new Coordinate("E5"),
                    new Coordinate("D6"),
                    new Coordinate("C7"),
                    new Coordinate("B8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("E4"))),
                new List<Coordinate>()
                {
                    new Coordinate("D5"),
                    new Coordinate("C6"),
                    new Coordinate("B7"),
                    new Coordinate("A8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("D4"))),
                new List<Coordinate>()
                {
                    new Coordinate("C5"),
                    new Coordinate("B6"),
                    new Coordinate("A7")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("C4"))),
                new List<Coordinate>()
                {
                    new Coordinate("B5"),
                    new Coordinate("A6")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("B4"))),
                new List<Coordinate>()
                {
                    new Coordinate("A5")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("A4"))),
                new List<Coordinate>()
                {
                }
            }
        };
        public static IEnumerable<object[]> BishopOnFifthLine => new List<object[]> {
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("H5"))),
                new List<Coordinate>()
                {
                    new Coordinate("G6"),
                    new Coordinate("F7"),
                    new Coordinate("E8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("G5"))),
                new List<Coordinate>()
                {
                    new Coordinate("F6"),
                    new Coordinate("E7"),
                    new Coordinate("D8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("F5"))),
                new List<Coordinate>()
                {
                    new Coordinate("E6"),
                    new Coordinate("D7"),
                    new Coordinate("C8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("E5"))),
                new List<Coordinate>()
                {
                    new Coordinate("D6"),
                    new Coordinate("C7"),
                    new Coordinate("B8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("D5"))),
                new List<Coordinate>()
                {
                    new Coordinate("C6"),
                    new Coordinate("B7"),
                    new Coordinate("A8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("C5"))),
                new List<Coordinate>()
                {
                    new Coordinate("B6"),
                    new Coordinate("A7")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("B5"))),
                new List<Coordinate>()
                {
                    new Coordinate("A6")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("A5"))),
                new List<Coordinate>()
                {
                }
            }
        };
        public static IEnumerable<object[]> BishopOnSixthLine => new List<object[]> {
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("H6"))),
                new List<Coordinate>()
                {
                    new Coordinate("G7"),
                    new Coordinate("F8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("G6"))),
                new List<Coordinate>()
                {
                    new Coordinate("F7"),
                    new Coordinate("E8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("F6"))),
                new List<Coordinate>()
                {
                    new Coordinate("E7"),
                    new Coordinate("D8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("E6"))),
                new List<Coordinate>()
                {
                    new Coordinate("D7"),
                    new Coordinate("C8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("D6"))),
                new List<Coordinate>()
                {
                    new Coordinate("C7"),
                    new Coordinate("B8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("C6"))),
                new List<Coordinate>()
                {
                    new Coordinate("B7"),
                    new Coordinate("A8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("B6"))),
                new List<Coordinate>()
                {
                    new Coordinate("A7")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("A6"))),
                new List<Coordinate>()
                {
                }
            }
        };
        public static IEnumerable<object[]> BishopOnSeventhLine => new List<object[]> {
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("H7"))),
                new List<Coordinate>()
                {
                    new Coordinate("G8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("G7"))),
                new List<Coordinate>()
                {
                    new Coordinate("F8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("F7"))),
                new List<Coordinate>()
                {
                    new Coordinate("E8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("E7"))),
                new List<Coordinate>()
                {
                    new Coordinate("D8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("D7"))),
                new List<Coordinate>()
                {
                    new Coordinate("C8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("C7"))),
                new List<Coordinate>()
                {
                    new Coordinate("B8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("B7"))),
                new List<Coordinate>()
                {
                    new Coordinate("A8")
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("A7"))),
                new List<Coordinate>()
                {
                }
            }
        };
        public static IEnumerable<object[]> BishopOnEightLine => new List<object[]> {
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("H8"))),
                new List<Coordinate>()
                {
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("G8"))),
                new List<Coordinate>()
                {
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("F8"))),
                new List<Coordinate>()
                {
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("E8"))),
                new List<Coordinate>()
                {
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("D8"))),
                new List<Coordinate>()
                {
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("C8"))),
                new List<Coordinate>()
                {
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("B8"))),
                new List<Coordinate>()
                {
                }
            },
            new object[] {
                new NW().GetCoordinates(new Bishop(Color.White, new Coordinate("A8"))),
                new List<Coordinate>()
                {
                }
            }
        };

        [Theory]
        [MemberData(nameof(BishopOnFirstLine))]
        [MemberData(nameof(BishopOnSecondLine))]
        [MemberData(nameof(BishopOnThirdLine))]
        [MemberData(nameof(BishopOnFourhLine))]
        [MemberData(nameof(BishopOnFifthLine))]
        [MemberData(nameof(BishopOnSixthLine))]
        [MemberData(nameof(BishopOnSeventhLine))]
        [MemberData(nameof(BishopOnEightLine))]
        public void Directions_ProperOrder_True(IEnumerable<Coordinate>actual, IEnumerable<Coordinate> expected)
        {
            Assert.Equal(expected, actual);
        }
    }
}
