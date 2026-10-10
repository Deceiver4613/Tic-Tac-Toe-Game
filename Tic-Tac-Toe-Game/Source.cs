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

        public bool CheckWin(string player)
        {
            for (int i = 0; i < 3; i++)
            {
                int rowStart = i * 3;

                //가로
                if (boardArr[rowStart] == player &&
                   boardArr[rowStart + 1] == player &&
                   boardArr[rowStart + 2] == player)
                {
                    return true;
                }

                //세로
                if (boardArr[i] == player &&
                   boardArr[i + 3] == player &&
                   boardArr[i + 6] == player)
                {
                    return true;
                }
            }

            //대각선
            if (boardArr[0] == player &&
               boardArr[4] == player &&
               boardArr[8] == player)
            {
                return true;
            }

            if (boardArr[2] == player &&
               boardArr[4] == player &&
               boardArr[6] == player)
            {
                return true;
            }

            return false;
        }

        public bool CheckDraw()
        {
            for (int i = 0; i < boardArr.Length; i++)
            {
                if (boardArr[i] == ".")
                {
                    return false;
                }
            }

            return true;
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

        public void Start()
        {
            string message = string.Empty;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("위치 번호");
                board.PrintBoardNumber();

                Console.WriteLine();

                Console.WriteLine("현재 보드");
                board.PrintBoard();

                Console.WriteLine();

                if (message != string.Empty)
                {
                    Console.WriteLine(message);
                    Console.WriteLine();
                }

                Console.WriteLine($"현재 차례: {player}");
                Console.Write("위치 입력(1 ~ 9): ");
                string input = Console.ReadLine();

                if (input == string.Empty)
                {
                    message = "입력이 비어있음";
                    continue;
                }

                bool check = int.TryParse(input, out int position);

                if (!check)
                {
                    message = "숫자를 입력하세요";
                    continue;
                }

                if (position < 1 || position > 9)
                {
                    message = "1부터 9까지 입력하세요";
                    continue;
                }

                int index = position - 1; //보드 배열 인덱스

                if (board.boardArr[index] != ".")
                {
                    message = "이미 사용한 칸";
                    continue;
                }

                board.boardArr[index] = player;
                message = string.Empty;
                //승리 판정
                if (board.CheckWin(player))
                {
                    Console.Clear();

                    Console.WriteLine("현재 보드");
                    board.PrintBoard();

                    Console.WriteLine();
                    Console.WriteLine($"플레이어 {player} 승!");

                    break;
                }

                //무승부 판정
                if (board.CheckDraw())
                {
                    Console.Clear();

                    Console.WriteLine("현재 보드");
                    board.PrintBoard();

                    Console.WriteLine();
                    Console.WriteLine($"무승부!");

                    break;
                }

                //차례 변경
                if (player == "X")
                {
                    player = "O";
                }
                else
                {
                    player = "X";
                }
            }
        }
    }
}