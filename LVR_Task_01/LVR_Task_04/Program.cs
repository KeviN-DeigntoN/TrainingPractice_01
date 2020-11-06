using System;


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
            const int max = 7; //Кол-во заклинаний (не менее 5)
            Skill[] arr = new Skill[max]; //Массив для заклинаний
            Random random = new Random(); //Случайность
            String[] names = {"Ничего", "Физический удар", "Заклятие поглощения", "Вызвать друга", "Совместный удар", "Силы предков", "Сбежать" }; //Название способностей

            int health = random.Next(100, 500);
            int boss = random.Next(300, 800);

            Console.WriteLine("\tПОБЕДИ БОССА");
            Console.WriteLine("___________________________");
            Console.WriteLine("Список способностей:");

            //Свойства заклинаний
            arr[1] = new Skill(
                names[1],              //Имя
                0,                    //Стоимость
                random.Next(5, 50),  //Урон
                false               //Использование
                );
            arr[2] = new Skill(
                names[2],
                boss, 
                boss,
                false
                );
            arr[3] = new Skill(
                names[3],
                random.Next(10, 50),
                0,
                false
                );
            arr[4] = new Skill(
                names[4],
                0,
                random.Next(25, 70),
                false
                );
            arr[5] = new Skill(
                names[5],
                -250,
                0,
                false
                );
            arr[6] = new Skill(
                names[6],
                0,
                0,
               false
                );

            //Описание заклинаний
            for (int i = 1; i < max; i++)
                Console.WriteLine($"\n {i}) Заклинание: {arr[i].name} \n Нанесёт урон: {arr[i].damage} очков жизни, отнимет у вас: {arr[i].quality}");
                
                Console.WriteLine($"{arr[4].name} и {arr[5].name} cработает, если вы уже использовали заклинание {arr[3].name}!\n {arr[5].name} - заклинание восстанавливающее 250 единиц здоровья");

            //Начало боя
            Console.WriteLine("\nБой начался!\n");
            while (boss > 0 && health > 0)
            {
                Console.WriteLine($"У вас {health} кол-во жизней, у БОССА - {boss}!\nВведите заклинание...");

                //Проверка правильности ввода заклинания
                string check = Console.ReadLine();
                while (check != "1" && check != "2" && check != "3" && check != "4" && check != "5" && check != "6")
                    check = Console.ReadLine();
                int input = Convert.ToInt32(check);

                //Алгоритм использования заклинания
                bool found = false;
                for (int i = 1; i < max; i++)
                {
                    if (i == input)
                    {
                        arr[2].quality = boss;

                        int cube = random.Next(1, 6); // Куб - своеобразный случайный шанс проведения атаки с уроном
                        if (((i == 4) || (i == 5)) && arr[3].used == false)
                        {
                            Console.WriteLine($"Для вызова этого заклинания вначале примените: {arr[3].name}!");
                        }
                        else if (0 == cube)
                        {
                            Console.WriteLine("Упс, босс увернулся от заклинания!");
                        }
                        else if (i == 6)
                        {
                            Console.WriteLine("Вы сбежали.\nМы вас не осуждаем, но этому миру требовался герой, который бы мог его спасти.\nСейчас же монстр сеет Хаос по всей земле, и это отчасти ваших рук дело.\nА мир надеется на появление нового смелого и храброго воина, что освободит их сердца!");
                            System.Environment.Exit(1);
                        }

                        else
                        {
                            if (i == 2)
                                if (health < boss)
                                {
                                    boss -= health;
                                    health = 0;
                                    break;
                                }
                                else
                                    cube = 1;
                            if (cube == 6 || cube == 5)
                                Console.WriteLine("Критический удар!");
                            boss -= arr[i].damage * cube;
                            health -= arr[i].quality;
                            Console.WriteLine($"Вы нанесли {arr[i].damage * cube} урона жизни, это стоило {arr[i].quality} жизней");
                        }
                        arr[i].used = true;
                        found = true;
                        break;
                    }
                }
                // Ход БОССА
                if (boss > 0)
                {
                    int temp = random.Next(0, 250);
                    if (temp > 150)
                        Console.WriteLine("Критический удар босса!");
                    if (temp == 0)
                        Console.WriteLine("БОСС ПРОМАЗАЛ!");
                    health -= temp;
                    Console.WriteLine($"Босс наносит ответный удар: -{temp} жизней...");
                }
                else Console.WriteLine("Босс уже не дышит и не может нанести ответный удар..");
            }
            
            //Финальный экран
            Console.WriteLine("\n\nИгра окончена!");
            if (boss <= 0 && health <= 0) Console.WriteLine("Вы пожертвовали собой ради победы над боссом, т.е. умерли оба!");
            else if (boss <= 0) Console.WriteLine($"Вы убили босса, у вас осталось {health} ХП!");
            else Console.WriteLine($"Вы проиграли, поскольку умерли, у босса осталось {boss} ХП!");
        }


    }
}