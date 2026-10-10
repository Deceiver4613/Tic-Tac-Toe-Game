using System;
using System.Collections.Generic;
using System.Text;


namespace TicTacToe
{
    internal class Board
    {
        public string[] boardArr;

        public Board()
        {
            boardArr = new string[9];

            for (int i = 0; i < boardArr.Length; i++)
            {
                boardArr[i] = ".";
            }
        }

        public void PrintBoardNumber()
        {
            Console.WriteLine("1 | 2 | 3");
            Console.WriteLine("---------");
            Console.WriteLine("4 | 5 | 6");
            Console.WriteLine("---------");
            Console.WriteLine("7 | 8 | 9");
        }

        public void PrintBoard()
        {
            Console.WriteLine($"{boardArr[0]} | {boardArr[1]} | {boardArr[2]}");
            Console.WriteLine("---------");
            Console.WriteLine($"{boardArr[3]} | {boardArr[4]} | {boardArr[5]}");
            Console.WriteLine("---------");
            Console.WriteLine($"{boardArr[6]} | {boardArr[7]} | {boardArr[8]}");
        }
    }

    internal class Game
    {
        public Board board; //보드 메모리에 만들어짐
        public string player;

        public Game()
        {
            board = new Board();
            player = "X";
        }

        public void start(){
            while (true)
            {
                Console.WriteLine($"현재 차례: {player}");
                Console.WriteLine($"위치 입력(1 ~ 9): ");
                string input = Console.ReadLine();

                bool check = int.Parse(input, out int position);

                
            }
        }
    }
}