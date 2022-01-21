import IBoard from './IBoard'

export default interface IGame{
    BoardTurnsHistory: Array<IBoard>
    
    addTurn(boardState: IBoard): void

}

// class Game : IGame{
//     addTurn(boardState: IBoard){
//         this.BoardTurnsHistory
//     }
// }