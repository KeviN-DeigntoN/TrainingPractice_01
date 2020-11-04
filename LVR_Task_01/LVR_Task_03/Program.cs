using System;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace LVR_Task_03
{
    class Program
    {
        private const string _password = "password";
        private const string _seсret = "Hello, world!";
        static void Main(string[] args)
        {
            int attempt = 0;
            string pass = null;
            while (pass != _password)
            {
                if (2 < attempt)
                    Console.WriteLine("У вас не осталось попыток.");
                else
                    Console.WriteLine($"Введите пароль. У вас осталось {3 - attempt} попытки.");
                attempt++;
                if (3 < attempt)
                    System.Environment.Exit(1);
                pass = Console.ReadLine();
            }
            Console.WriteLine("Секретное сообщение");
            Console.WriteLine("________________________");
            Console.WriteLine($"{_seсret}");

        }
    }
}

