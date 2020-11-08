using System;
using System.Collections.Generic;

namespace Deque
{
    class Program
    {
        static string command;
        static int argument = 0;
        static Deque deque = new Deque();
        static void Main()
        {
            Dictionary<string, Action> commands = new Dictionary<string, Action>()
            {
                {"push_front", () => Push_front()},
                {"push_back", () => Push_back()},
                {"pop_front", () => Pop_front()},
                {"pop_back", () => Pop_back()},
                {"front", () => Front()},
                {"back", () => Back()},
                {"exit", () => Exit()},
                {"clear", () => Clear()},
                {"size", () => Size()}
            };
            while (true)
            {
                command = Console.ReadLine();
                SplitCommandAndArgument();
                if (commands.ContainsKey(command))
                    commands[command]();
                else
                    PrintError();
            }
        }

        static void Push_front()
        {
            deque.Push_front(argument);
            PrintOk();
        }

        static void Push_back()
        {
            deque.Push_back(argument);
            PrintOk();
        }
        static void Pop_front()
        {
            if (deque.IsEmpty)
                PrintError();
            else
                Console.WriteLine(deque.Pop_front());

        }

        static void Pop_back()
        {
            if (deque.IsEmpty)
                PrintError();
            else
                Console.WriteLine(deque.Pop_back());

        }
        static void Front()
        {
            if (deque.IsEmpty)
                PrintError();
            else
                Console.WriteLine(deque.Front());
        }
        static void Back()
        {
            if (deque.IsEmpty)
                PrintError();
            else
                Console.WriteLine(deque.Back());
        }
        static void Clear()
        {
            deque.Clear();
            PrintOk();
        }
        static void Size() => Console.WriteLine(deque.Size);

        static void SplitCommandAndArgument()
        {
            string[] data = command.Split(new char[] { ' ' });
            command = data[0];
            if (command.Contains("push"))
            {
                argument = 0;
                int.TryParse(data[1], out argument);
            }
        }
        static void PrintError() => Console.WriteLine("error :(");
        static void PrintOk() => Console.WriteLine("Ok :)");
        static void Exit()
        {
            Console.WriteLine("bye");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}

