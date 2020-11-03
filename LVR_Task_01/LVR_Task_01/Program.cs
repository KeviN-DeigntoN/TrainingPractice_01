using System;

namespace LVR_Task_01
{
    class Program
    {
        //Стоимость 1 кристалла
        public const int Quality = 100;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите кол-во золота: ");
            int Gold = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Сколько кристаллов вы хотите приобрести? Курс: 1 кристалл = {Quality} золота");
            int crystals = Convert.ToInt32(Console.ReadLine());




        }
    }
}
