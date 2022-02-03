using Xunit;
using ChessGame.Logic;
using System.Collections.Generic;

namespace ChessGameTests
{
    public class PawnTests
    {
        //Arrange, Act, Assert
        //Add_MaximumSumResult_ThrowsOverflowException()
        private readonly BoardSetup setup = BoardSetup.GetInstance();

        [Fact]
        public void Init_WhitePionMoves()
        {
            var processor = new BoardProcessor(new Board(setup.GetAllWhitePionsSetup()), new List<Log>());
            foreach(var col in Enumeration.GetAll<Column>())
            {
                var correctOptions = new HashSet<MoveOption>()
                {
                    new MoveOption(ActionType.Move, new Log(new Coordinate(col, Row.Two), new Coordinate(col, Row.Three))),
                    new MoveOption(ActionType.Move, new Log(new Coordinate(col, Row.Two), new Coordinate(col, Row.Four)))
                };
                var calculatedOptions = processor.OutputBoard.GetFigure(new Coordinate(col, Row.Two)).MoveOptions;
                Assert.Equal(correctOptions, calculatedOptions);
            } 
        }



        //[Fact]
        //public void Standard_OneFoward_Success()
        //{
        //    var logList = new List<Log>()
        //    {
        //        new Log(new Coordinate(Column.D, Row.Two), new Coordinate(Column.D, Row.Three))
        //    };
        //    var processor = new BoardProcessor(new Board(setup.GetOnePawnSetup()), logList);
        //    Assert.Equal(Figure.WhitePawn, processor.OutputBoard.GetFigure(new Coordinate(Column.D, Row.Three)));
        //}
        //[Fact]
        //public void StartLine_TwoForward_Success()
        //{
        //    var logList = new List<Log>()
        //    {
        //        new Log(new Coordinate(Column.D, Row.Two), new Coordinate(Column.D, Row.Four))
        //    };
        //    var processor = new BoardProcessor(new Board(setup.GetOnePawnSetup()), logList);
        //    Assert.Equal(Figure.WhitePawn, processor.OutputBoard.GetFigure(new Coordinate(Column.D, Row.Four)));
        //}
        //[Fact]
        //public void StartLine_TwoForward_Blocked()
        //{
        //    var logList = new List<Log>()
        //    {
        //        new Log(new Coordinate(Column.D, Row.Two), new Coordinate(Column.D, Row.Four))
        //    };
        //    var processor = new BoardProcessor(new Board(setup.GetOnePawnSetup()), logList);
        //    Assert.Throws<IllegalMoveException>(() => processor);
        //}


       
    }
}
