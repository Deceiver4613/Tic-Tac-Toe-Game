using System;
using TicTacToe;

class Program
{
    static void Main()
    {
        Game game = new Game();

        Console.WriteLine("위치 번호");
        game.board.PrintBoardNumber();

        Console.WriteLine();

        Console.WriteLine("현재 보드");
        game.board.PrintBoard();
    }
}