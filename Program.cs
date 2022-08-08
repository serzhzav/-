using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lesson4Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int cursorX = 40;
            int cursorY = 20;
            int cursorLeft = 24;
            int cursorDown = 6;
            string[] answerWord = { "а", "у", "т" };
            int wordLenght = answerWord.Length;

            Console.WriteLine("Выход за пределы игрового поля. 3 буквы.");

            for (int i = 0; i < wordLenght; i++, cursorLeft++)
            {
                Console.SetCursorPosition(cursorLeft, 2);
                Console.WriteLine("*");
                Thread.Sleep(200);
            }

            for (int j = 3; j >= 0;)
            {
                Console.SetCursorPosition(0, 2);
                Console.Write("Введите букву :   ");
                Console.SetCursorPosition(0, 2);
                Console.Write("Введите букву : ");
                string str = Console.ReadLine();
                string[] YouLetter = new string[wordLenght];
                YouLetter[0] = str;
                int ifYouRight = 0;

                for (int i = 0; i < answerWord.Length; i++)
                {
                    int result = string.Compare(answerWord[i], YouLetter[0]);
                    if (result == 0)
                    {
                        ifYouRight++;
                        YouLetter[i] = str;
                        Console.SetCursorPosition(24 + i, 2);
                        Console.WriteLine(YouLetter[i]);
                    }
                }

                if (ifYouRight == 0)
                {

                    Console.WriteLine($"\nУ вас осталось {j} попыток");
                    Console.SetCursorPosition(0, cursorDown++);
                    Console.WriteLine(YouLetter[0]);
                    switch (j)
                    {
                        case 3:
                            {
                                for (int i = 0; i < 16; i++)
                                {
                                    Thread.Sleep(50);
                                    if (i <= 6)
                                    {
                                        Console.SetCursorPosition(cursorX, cursorY);
                                        Console.WriteLine("|");
                                        cursorY--;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(cursorX, cursorY);
                                        Console.WriteLine("_");
                                        cursorX++;
                                    }

                                }
                                break;
                            }

                        case 2:
                            {
                                cursorY++;
                                Console.SetCursorPosition(cursorX, cursorY);
                                Console.WriteLine("|");
                                cursorY++;
                                Console.SetCursorPosition(cursorX, cursorY);
                                Console.WriteLine("О");
                                break;
                            }

                        case 1:
                            {
                                cursorY++;
                                cursorX--;
                                Console.SetCursorPosition(cursorX, cursorY);
                                Console.WriteLine("/|\\");
                                break;
                            }

                        case 0:
                            {
                                cursorY++;
                                Console.SetCursorPosition(cursorX, cursorY);
                                Console.WriteLine("/ \\");
                                cursorY++; cursorY++; cursorY++;
                                cursorX--; cursorX--;

                                Console.SetCursorPosition(cursorX, cursorY);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("_______");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(0, 5);
                                Console.WriteLine("You dead");
                                Console.ResetColor();
                                break;
                            }
                    }
                    j--;
                }

            }
        }
    }
}
