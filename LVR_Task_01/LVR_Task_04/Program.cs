using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LVR_Task_04
{
    class Program
    {
        //Класс способностей
        public struct Skill
        {
            public string name;
            public int quality;
            public int damage;
            public bool used;
            public Skill(string name, int quality, int damage, bool used)
            {
                this.name = name;
                this.quality = quality;
                this.damage = damage;
                this.used = used;
            }
        }
        static void Main(string[] args)
        {
            const int max = 6; //Кол-во заклинаний (не менее 5)
            Skill[] arr = new Skill[max]; //Массив для заклинаний
            Random random = new Random(); //Случайность
            String[] names = { "Физический удар", "Заклятие поглощения", "Вызвать друга", "Совместный удар", "Силы предков", "Сбежать" }; //Название способностей

            int health = random.Next(100, 500);
            int boss = random.Next(300, 800);

            Console.WriteLine("\tПОБЕДИ БОССА");
            Console.WriteLine("___________________________");
            Console.WriteLine("Список способностей:");

            //Свойства заклинаний
            arr[1] = new Skill(
                names[1],            //Имя
                random.Next(5, 50), //Стоимость
                0,                 //Урон
                false             //Использование
                );
            arr[2] = new Skill(
                names[2],
                boss, 
                boss,
                false
                );
            arr[3] = new Skill(
                names[3],
                0,
                random.Next(10, 50),
                false
                );
            arr[4] = new Skill(
                names[4],
                random.Next(50, 100),
                0,
                false
                );
            arr[5] = new Skill(
                names[5],
                0,
                -250,
                false
                );
            arr[6] = new Skill(
                names[6],
                0,
                0,
                false
                );

            for (int i = 0; i < max; i++)
                Console.WriteLine($"\n {i + 1}) Заклинание: {arr[i].name} \n Нанесёт урон: {arr[i].damage} очков жизни, отнимет у вас: {arr[i].quality}");

                Console.WriteLine($"{arr[4].name} и {arr[5].name} cработает, если вы уже использовали заклинание {arr[3].name}!");

            Console.WriteLine("\nБой начался!\n");
            while (boss > 0 && health > 0)
            {

            }
        }
        }
    }
}
