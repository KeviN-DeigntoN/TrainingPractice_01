using System;

namespace LVR_Task_07
{
    class Program
    {
        static void Main(string[] args)
            {
                Random rnd = new Random();
                Console.WriteLine("Размер массива: ");
                int size = Convert.ToInt32(Console.ReadLine());
                int[] arr = new int[size];

                for (int i = 0; i < size; i++) arr[i] = rnd.Next(0, 100);

                Console.WriteLine($"Было:");
                Console.WriteLine(string.Join(" ", arr));

                Shuffle(size, arr);

                Console.WriteLine($"Стало: ");
                Console.WriteLine(string.Join(" ", arr));

            }
        static void Shuffle(int size, int[] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                int rndI2 = rnd.Next(0, i);
                int rndI1 = rnd.Next(0, i + 1);
                int temp = arr[rndI2];
                arr[rndI2] = arr[rndI1];
                arr[rndI1] = temp;
            }
        }
    }
}