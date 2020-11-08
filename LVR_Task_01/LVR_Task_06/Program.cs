﻿using System;
using System.Diagnostics;
using System.Reflection;
namespace LVR_Task_06
{
    class Program
    {
        static string[,] _users = new string[0, 2];
        static int _size = 0;
        //Запись
        static void Record(string surname, string post)
        {
            Resize((_size + 1));
            _users[_size - 1, 0] = surname;
            _users[_size - 1, 1] = post;
            Console.WriteLine($"В базу добавлен {surname}, должность - {post}, номер: {_size}");
        }
        //Увеличение для записи
        static void Resize(int newsize)
        {
            if (newsize < 0)
            {
                Console.WriteLine($"Неправильный размер массива.");
                return;
            }
            if (newsize != _size)
            {
                string[,] newer = new string[newsize, 2];
                for (int i = 0; i < Math.Min(_size, newsize); i++)
                {
                    newer[i, 0] = _users[i, 0];
                    newer[i, 1] = _users[i, 1];
                }
                if (newsize > _size) for (int i = _size; i < newsize; i++)
                    {
                        newer[i, 0] = "";
                        newer[i, 1] = "";
                    }
                _users = newer;
                _size = newsize;
            }
        }
        //Вывод
        static void List()
        {
            if (_size == 0) Console.WriteLine("Нет досье, вначале добавьте кого-нибудь...");
            else for (int i = 0; i < _size; i++) Console.WriteLine($"{i + 1}) {_users[i, 0]} - {_users[i, 1]}");
        }
        //Удаление
        static void Remove(int pos)
        {
            if (pos >= _size || pos < 0 || _size <= 0)
            {
                Console.WriteLine($"Неправильный индекс.");
                return;
            }
            string[,] newer = new string[_size - 1, 2];

            int temp = 0;
            for (int i = 0; i < _size; i++)
            {
                if (i != pos)
                {
                    newer[temp, 0] = _users[i, 0];
                    newer[temp, 0] = _users[i, 1];
                    temp++;
                }
                else
                {
                    Console.WriteLine($"Удаляем {_users[i, 0]}...");
                }
            }

            _users = newer;
            _size -= 1;
        }
        //Поиск
        static void Search(string str)
        {
            int count = 0;
            for (int i = 0; i < _size; i++)
            {
                if (_users[i, 0].IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine($"Досье: {i + 1}) {_users[i, 0]} - {_users[i, 1]}");
                    count++;
                }
            }
            if (count == 0) Console.WriteLine("Таких досье нет.");
        }

      

        static void Main(string[] args)
        {
            //Главная информация
            Console.WriteLine("Отдел кадров..\n1. Добавить досье \n2. Вывести все досье \n3. Удалить досье \n4. Поиск по фамилии \n5. Выйти из программы\n6. Показать эту справку");
            //Действия
            while (true)
            {
                Console.WriteLine("\nОжидание ввода...\n");
                string select = Console.ReadLine();
                if (select == "1")
                {
                    Console.WriteLine("Введите фамилию: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Введите имя: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите отчество: ");
                    string patronymic = Console.ReadLine();
                    Console.WriteLine("Введите должность: ");
                    string post = Console.ReadLine();
                    Record(surname + " " + name + " " + patronymic, post);
                }
                else if (select == "2")
                {
                    List();
                }
                else if (select == "3")
                {
                    if (_size < 1) Console.WriteLine("В базе нет досье.");
                    else
                    {
                        Console.WriteLine($"Введите номер для удаления досье (минимум {1}, максимум {_size})");
                        int pos = Convert.ToInt32(Console.ReadLine());
                        Remove(pos - 1);
                    }
                }
                else if (select == "4")
                {
                    Console.WriteLine("Введите фамилию для поиска: ");
                    string surname = Console.ReadLine();
                    Search(surname);
                }
                else if (select == "5")
                {
                    Console.WriteLine("Завершение работы программы...");
                    System.Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("Введите значение от 1 до 5.");
                }
            }
        }
    }
}