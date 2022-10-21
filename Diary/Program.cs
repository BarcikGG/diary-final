using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Diary
{
    internal class Program
    {
        public static bool CanAdd=true;
        public static string task_1;
        public static string task_2;
        public static string disc_1;
        public static string disc_2;
        public static string user_date;

        static void Main(string[] args)
        {
            Greeting();
            Menu();
        }

        static void Greeting()
        {
            Console.SetCursorPosition(40, 10);
            Console.WriteLine("Добро пожаловать в заметки");
            Console.SetCursorPosition(40, 12);
            Console.WriteLine("**************************");
            Console.SetCursorPosition(40, 13);
            Console.WriteLine($"Сегодня {DateTime.Now}");
            Console.SetCursorPosition(40, 14);
            Console.WriteLine("**************************");
            Console.SetCursorPosition(28, 17);
            Console.WriteLine("Переключение между датами - двойное нажатие стрелочек");
            Console.SetCursorPosition(35, 18);
            Console.WriteLine("Для выхода из программы нажмите - Esc");
            Thread.Sleep(6000);
            Console.Clear();
        }

        static void Menu()
        {
            int position = 1;
            int page = 0;
            Page page_1 = new Page()
            {
                date = DateTime.Now,
                title_1 = "  1. Поиграть в доту",
                d_1 = "Пикнуть пуджа в мид\nУйти с лайна 0 10\nКупить мом и пойти в лес\nЛивнуть на 25 минуте",
                title_2 = "  2. Сварить суп",
                d_2 = "Рецепт борща: свекла\nnкапуста\nnморковь\nкартофель\nлук\nnмясо"
            };
            Page page_2 = new Page()
            {
                date = DateTime.Now,
                title_1 = "  1. пойти на пары",
                d_1 = "4 пары капец :(",
                title_2 = "  2. поспать",
                d_2 = "Я люблю спать"
            };
            Page page_3 = new Page()
            {
                date = DateTime.Now,
                title_1 = "  1. new task",
                d_1 = "aasssdf", 
                title_2 = "  2. new task 2",
                d_2 = "disc 2"
            };
            
            List<Page> pages = new List<Page>()
            {page_1, page_2, page_3};

            m1(page_1, position);

            while (true)
            {

                ConsoleKeyInfo pos = Console.ReadKey();
                switch (pos.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (position! <= 0)
                        {
                            position--;
                            UpDown(page, position, page_1, page_2, page_3);
                        }
                        else
                        {
                            position=1;
                            UpDown(page, position, page_1, page_2, page_3);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (position < 2)
                        {
                            position++;
                            UpDown(page, position, page_1, page_2, page_3);
                        }
                        else 
                        {
                            position=2;
                            UpDown(page, position, page_1, page_2, page_3);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        page++;
                        if (page == 0)
                        {
                            m1(page_1, position);
                        }
                        else if (page == 1)
                        {
                            m2(page_2, position);
                        }
                        else if (page == 2)
                        {
                            m3(page_3, position);
                        }
                        else if (page == 3)
                        {
                            if (CanAdd == false)
                            {
                                user_m(position);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Здесь будет ваша заметка");
                            }
                        }
                        else if (page > 3)
                        {
                            page--;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        page--;
                        if (page == -1)
                        {
                            add_m();
                        }
                        else if (page == 0)
                        {
                            m1(page_1, position);
                        }
                        else if (page == 1)
                        {
                            m2(page_2, position);
                        }
                        else if (page == 2)
                        {
                            m3(page_3, position);
                        }
                        else if (page < -1)
                        {
                            page++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (page)
                        {
                            case -1:
                                if (CanAdd == true)
                                {
                                    fill();
                                }
                                else
                                {
                                    Console.WriteLine("Ну сказали же, что не можешь...");
                                }
                                break;
                            case 0:
                                if (position == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Выбарана дата: {page_1.date.AddDays(-1)}");
                                    Console.WriteLine("<------------описание дела------------->");
                                    Console.WriteLine(page_1.d_1);
                                }
                                else if (position == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Выбарана дата: {page_1.date.AddDays(-1)}");
                                    Console.WriteLine("<------------описание дела------------->");
                                    Console.WriteLine(page_1.d_2);
                                }
                                break;
                            case 1:
                                if (position == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Выбарана дата: {page_2.date}");
                                    Console.WriteLine("<------------описание дела------------->");
                                    Console.WriteLine(page_2.d_1);
                                }
                                else if (position == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Выбарана дата: {page_2.date}");
                                    Console.WriteLine("<------------описание дела------------->");
                                    Console.WriteLine(page_2.d_2);
                                }
                                break;
                            case 2:
                                if (position == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Выбарана дата: {page_3.date.AddDays(+1)}");
                                    Console.WriteLine("<------------описание дела------------->");
                                    Console.WriteLine(page_3.d_1);
                                }
                                else if (position == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Выбарана дата: {page_3.date.AddDays(+1)}");
                                    Console.WriteLine("<------------описание дела------------->");
                                    Console.WriteLine(page_3.d_2);
                                }
                                break;
                            case 3:
                                if (CanAdd == false)
                                {
                                    if (position == 1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Выбарана дата: {user_date}");
                                        Console.WriteLine("<------------описание дела------------->");
                                        Console.WriteLine(disc_1);
                                    }
                                    else if (position == 2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Выбарана дата: {user_date}");
                                        Console.WriteLine("<------------описание дела------------->");
                                        Console.WriteLine(disc_2);
                                    }
                                }
                                else 
                                {
                                    Console.Clear();
                                    Console.WriteLine("Куда мы лезим, заметки еще нет");
                                }
                                break;
                        }
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void UpDown(int page, int position, Page page_1, Page page_2, Page page_3) 
        {
            if (page == 0)
            {
                m1(page_1, position);
            }
            else if (page == 1)
            {
                m2(page_2, position);
            }
            else if (page == 2)
            {
                m3(page_3, position);
            }
            else if (page == 3)
            {
                user_m(position);
            }
        }

        static void m1(Page page_1, int position)
        {
            Console.Clear();
            Console.WriteLine($"Выбарана дата: {page_1.date.AddDays(-1)}");
            Console.WriteLine(page_1.title_1);
            Console.WriteLine(page_1.title_2);
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
        }

        static void m2(Page page_2, int position)
        {
            Console.Clear();
            Console.WriteLine($"Выбарана дата: {page_2.date.AddDays(0)}");
            Console.WriteLine(page_2.title_1);
            Console.WriteLine(page_2.title_2);
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
        }

        static void m3(Page page_3, int position)
        {
            Console.Clear();
            Console.WriteLine($"Выбарана дата: {page_3.date.AddDays(+1)}");
            Console.WriteLine(page_3.title_1);
            Console.WriteLine(page_3.title_2);
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
        }

        static void add_m()
        {
            Console.Clear();
            if (CanAdd == true)
            {
                Console.Clear();
                Console.WriteLine("Нажмите Enter для добавления заметки");
            }
            else
            {
                Console.WriteLine("Кодер даун, пока можно добавить только 1 свою заметку");
            }
        }

        static void fill()
        {
            Console.Clear();
            Console.WriteLine("Введите дату (dd.mm.yyyy): ");
            user_date = Console.ReadLine();
            Console.WriteLine("Напишите первую заметку: ");
            task_1 = Console.ReadLine();
            Console.WriteLine("Напишите вторую заметку: ");
            task_2 = Console.ReadLine();
            Console.WriteLine("Теперь описание для первой: ");
            disc_1 = Console.ReadLine();
            Console.WriteLine("И описание для второй: ");
            disc_2 = Console.ReadLine();
            Console.WriteLine("Готово, жми на стрелку вправо!");
            CanAdd = false;
        }

        static void user_m(int position)
        {
            Console.Clear();
            Console.WriteLine($"Выбарана дата: {user_date}");
            Console.WriteLine($"  1.{task_1}");
            Console.WriteLine($"  2.{task_2}");
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
        }

    }
}