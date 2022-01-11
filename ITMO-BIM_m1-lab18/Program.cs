using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1.Дана строка, содержащая скобки трёх видов (круглые, квадратные и фигурные) и любые другие символы.
//Проверить, корректно ли в ней расставлены скобки. Например, в строке ([]{ })[] скобки расставлены корректно,
//а в строке ([]] — нет.
//Указание: задача решается однократным проходом по символам заданной строки слева направо;
//для каждой открывающей скобки в строке в стек помещается соответствующая закрывающая,
//каждая закрывающая скобка в строке должна соответствовать скобке из вершины стека (при этом скобка с вершины стека снимается);
//в конце прохода стек должен быть пуст.

namespace ITMO_BIM_m1_lab18
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            // input = "([]{ })[]";
            // input = "([]]";
            // input = ")[{}]";

            Console.WriteLine("Введите текст/выражение в котором необходимо проверить корректность расстановки скобок (в т.ч.квадратные и фигурные):");
            input = Console.ReadLine();

            Stack<char> Char_Stack = new Stack<char>();
            char chr;
            for (int i = 0; i < input.Length; i++)
            {
                chr = Convert.ToChar(input.Substring(i,1));
                if ("([{".Contains(chr))
                    Char_Stack.Push(chr);
                else if (")]}".Contains(chr))
                    {
                    if (Char_Stack.Count == 0)
                        Char_Stack.Push(chr);
                    else
                    {
                        switch (chr)
                        {
                            case ')':
                                {
                                    if (Char_Stack.Peek() == '(')
                                        Char_Stack.Pop();
                                    break;
                                }
                            case ']':
                                {
                                    if (Char_Stack.Peek() == '[')
                                        Char_Stack.Pop();
                                    break;
                                }
                            case '}':
                                {
                                    if (Char_Stack.Peek() == '{')
                                        Char_Stack.Pop();
                                    break;
                                }
                        }
                    }
                    //default:
                    //    break;
                }
            }
            if (Char_Stack.Count == 0)
                Console.WriteLine("УРА! Скобки расставлены корректно.");
            else
                Console.WriteLine("УПС! Скобки расставлены НЕ корректно.");
            Console.ReadKey();
        }
    }
}
