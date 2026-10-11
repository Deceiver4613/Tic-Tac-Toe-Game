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
        private int gameMode; 
        private Random random;
        public Board board; //보드 메모리에 만들어짐
        public string player;

        public Game()
        {
            board = new Board();
            player = "X";
            random = new Random();
        }

        public void Start()
        {
            while (true)
            {
                ChooseMode();

                board = new Board();
                player = "X";

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

                    if (gameMode == 1)
                    {
                        //두 사람 대전
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

                        int index = position - 1;

                        if (board.boardArr[index] != ".")
                        {
                            message = "이미 사용한 칸";
                            continue;
                        }

                        board.boardArr[index] = player;
                        message = string.Empty;
                    }
                    else
                    {
                        //컴퓨터 대전
                        if (player == "X")
                        {
                            //사람이 먼저 X임 
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

                            int index = position - 1;

                            if (board.boardArr[index] != ".")
                            {
                                message = "이미 사용한 칸";
                                continue;
                            }

                            board.boardArr[index] = player;
                            message = string.Empty;
                        }
                        else
                        {
                            //컴퓨터 차례
                            //랜덤 이지모드
                            Console.WriteLine("컴퓨터 차례");

                            int index;

                            while (true)
                            {
                                index = random.Next(0, 9);

                                if (board.boardArr[index] == ".")
                                {
                                    break;
                                }
                            }

                            board.boardArr[index] = player;


                            //컴퓨터가 둘 우선순위
                            //1. 놓으면 바로 이길 수 있는 위치 찾아 놓기
                            //2. 상대가 놓으면 이길수 있는 위치 방어
                            //3. 5번두기(index == 4)
                            ///////////////////////////////
                        }
                    }

                    //승리 판정
                    if (board.CheckWin(player))
                    {
                        Console.Clear();

                        Console.WriteLine("현재 보드");
                        board.PrintBoard();

                        Console.WriteLine();
                        Console.WriteLine($"플레이어 {player} 승리!");

                        break;
                    }

                    //무승부 판정
                    if (board.CheckDraw())
                    {
                        Console.Clear();

                        Console.WriteLine("현재 보드");
                        board.PrintBoard();

                        Console.WriteLine();
                        Console.WriteLine("무승부!");

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

                //다시 하기
                if (!Replay())
                {
                    return;
                }
            }
        }

        public void ChooseMode()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("게임 모드 선택");
                Console.WriteLine("1. 두 사람 대전");
                Console.WriteLine("2. 컴퓨터 대전");
                Console.Write("선택: ");

                string input = Console.ReadLine();

                bool check = int.TryParse(input, out int mode);

                if (!check)
                {
                    Console.WriteLine("숫자를 입력하세요");
                    continue;
                }

                if (mode < 1 || mode > 2)
                {
                    Console.WriteLine("1 또는 2를 입력하세요");
                    continue;
                }

                gameMode = mode;
                break;
            }


        }

        private bool Replay()
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write("다시 하시겠습니까? (Y/N): ");

                string input = Console.ReadLine();

                if (input == string.Empty)
                {
                    Console.WriteLine("Y 또는 N을 입력하세요");
                    continue;
                }

                input = input.ToUpper();

                if (input == "Y")
                {
                    return true;
                }

                if (input == "N")
                {
                    return false;
                }

                Console.WriteLine("Y 또는 N을 입력하세요");
            }
        }
    }
}