using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque
{
    class Program
    {
        static string command;
        static int argument = 0;
        static NodeStack stack = new NodeStack();
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
            stack.Push_front(argument);
            PrintOk();
        }

        static void Push_back()
        {
            stack.Push_back(argument);
            PrintOk();
        }
        static void Pop_front()
        {
            if (stack.IsEmpty)
                PrintError();
            else
                Console.WriteLine(stack.Pop_front());

        }

        static void Pop_back()
        {
            if (stack.IsEmpty)
                PrintError();
            else
                Console.WriteLine(stack.Pop_back());

        }
        static void Front()
        {
            if (stack.IsEmpty)
                PrintError();
            else
                Console.WriteLine(stack.Front());
        }
        static void Back()
        {
            if (stack.IsEmpty)
                PrintError();
            else
                Console.WriteLine(stack.Back());
        }
        static void Clear()
        {
            stack.Clear();
            PrintOk();
        }
        static void Size() => Console.WriteLine(stack.Size);

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

