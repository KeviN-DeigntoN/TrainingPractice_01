using System;

namespace LVR_Task_01
{
    class Program
    {
        //Стоимость 1 кристалла
        private const int _quality = 10;
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите кол-во золота: ");
            int gold = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Сколько кристаллов вы хотите приобрести? Курс: 1 кристалл = {_quality} золота");
            int crystals = Convert.ToInt32(Console.ReadLine());

            if (crystals*_quality > gold)
            {
                Console.WriteLine("У вас недостаточное количество золота");
                crystals = 0;
            }
            else
            {
                gold -= crystals * _quality;
            }

            Console.WriteLine($"У вас {gold} золота и {crystals} кристаллов. Удачи!");
        }
    }
}
