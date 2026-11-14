using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace main
{
    class Programm
    {
        static void about()
        {
            Console.WriteLine("\nАвтор:"); Console.WriteLine(" ФИО: Каткасов Матвей Сергеевич"); Console.WriteLine(" Группа: 6106-090301D");
        }

        static double inp()
        {
            double retdoub = 0.0;
            bool boolinp = false;
            while (!boolinp)
            {
                if (double.TryParse(Console.ReadLine(), out retdoub))
                {
                    boolinp = true;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода! Попробуйте еще раз.");
                }
            }
            return retdoub;
        }

        static double func(double a1, double a2)
        {
            double rada = a1 * (Math.PI / 180);
            double radb = a2 * (Math.PI / 180);
            double sina = Math.Sin(rada);
            double cosb = Math.Cos(radb);
            double result;
            double verh = (Math.Pow(sina, 2)) + (Math.Pow(cosb, 3));
            double niz = (Math.Pow(sina, 3)) - (Math.Pow(cosb, 2));
            if (niz != 0)
            {
                if (verh / niz < 0)
                {
                    Console.WriteLine("Число под корнем не положительно."); return 0;
                }
                else
                {
                    result = Math.Sqrt(verh / niz);
                }
            }
            else
            {
                Console.WriteLine("Знаменатель равен нулю!"); return 0;
            }
            return Math.Round(result,2);
        }

        static void guess(double res)
        {
            short att = 0;
            Console.WriteLine("Попробуйте угадать значание функции:\nf=Sqrt(sin^2 a + cos^3 b / sin^3 a - cos^2 b)\n(с точностью до 2 знаков после запятой, у вас есть " + (3 - att) + " попытки)");
            while (att <= 2)
            {
                double guess  = inp();
                if (res == guess)
                {
                    att++;
                    Console.WriteLine("Вы угадали! Ответом было " + res + ". Вы поняли это за " + att + " попытку(-ки).");
                    att = 4;
                }
                else
                {
                    ++att;
                    Console.WriteLine("Вы не угадали! Попробуйде еще раз, ведь у вас " + (3 - att) + " попытки(-а)");
                }
            }
            if (att == 3)
            {
                Console.WriteLine("Ваши попытки закончилсь! Правильным ответом было: " + res + "!");
            }
        }

        static int arrinp()
        {
            Console.Write("Введите длину массива (больше 0): ");
            int n = (int)inp();
            while (n <= 0)
            {
                Console.WriteLine("Ошибка! Попробуйте еще раз.");
                n = (int)inp();
            }
            return n;
        }

        static void guessgame()
        {
            Console.WriteLine("Введите значение угла a в градусах: ");
            double a = inp();
            Console.WriteLine("Введите значение угла b в градусах: ");
            double b = inp();
            double result = func(a,b);
            guess(result);
        }

        static bool exit()
        {
            Console.WriteLine("Вы уверены что хотите выйти? (д/н): ");
            string exitchoise = Console.ReadLine();
            while (exitchoise != "д" && exitchoise != "н")
            {
                Console.WriteLine("Вы ввели неверное значение! Попробуйте еще раз.");
                exitchoise = Console.ReadLine();
            }
            if (exitchoise == "д")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int[] arrinit(int arrlen)
        {
            int[] mass = new int[arrlen];
            Random rnd = new Random();
            for (int i = 0; i<arrlen; i++)
            {
                mass[i] = rnd.Next(-100,100);
            }
            return mass;
        }

        static int[] copyarr(int[] mass)
        {
            int[] copyarr = new int[mass.Length];
            for (int i = 0; i<mass.Length; i++)
            {
                copyarr[i] = mass[i];
            }
            return copyarr;
        }

        static void writearr(int[] mass)
        {
            if (mass.Length > 10)
            {
                Console.WriteLine("Длинна массива больше 10. Он не будет выведен на экран.");
            }
            else
            {
                Console.Write("{");
                for (int i = 0; i<mass.Length; i++)
                {
                    Console.Write(mass[i]+",");
                }
                Console.WriteLine("}");
            }
        }

        public static void shellsort(int[] arr)
        {
            int n = arr.Length;
            for (int gap = n/2; gap > 0; gap = gap / 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j;
                    for (j = i; j>= gap && arr[j - gap] > temp; j = j - gap)
                    {
                        arr[j] = arr[j-gap];
                    }
                    arr[j] = temp;
                }
            }
        }

        public static void inpsort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        public static void arr()
        {
            int n = arrinp();
            int[] mass = arrinit(n);
            int[] copymass1 = copyarr(mass);
            int[] copymass2 = copyarr(mass);
            Stopwatch shelltimer = Stopwatch.StartNew();
            shellsort(copymass1);
            shelltimer.Stop();
            Stopwatch inptimer = Stopwatch.StartNew();
            inpsort(copymass2);
            inptimer.Stop();
            Console.Write("Исходный массив: ");
            writearr(mass);
            Console.Write("\nМассив, отсортированный методом сортировки Шелла: ");
            writearr(copymass1);
            Console.Write($". Он был отсортирован за {shelltimer.Elapsed.TotalMilliseconds} миллисекунд.\n");
            Console.WriteLine("\nМассив, отсортированный методом сортировки вставками: ");
            writearr(copymass2);
            Console.Write($". Он был отсортирован за {inptimer.Elapsed.TotalMilliseconds} миллисекунд(-ы).");
        }


        static void Main()
        {   
            bool open = true;
            while (open)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine(" 1. Отгадай ответ");
                Console.WriteLine(" 2. Об авторе");
                Console.WriteLine(" 3. Сортировка массива");
                Console.WriteLine(" 4. Выход");
                Console.WriteLine("Выберите пункт для продолжения: ");
                int vibor = (int)inp();
                switch (vibor)
                {
                    case 1:
                        {   
                            guessgame(); break;
                        }                            
                        case 2: 
                        {
                            about(); break;
                        }
                        case 3:
                        {
                            arr();
                            break;
                        }
                        case 4:
                        {
                            if (exit())
                            {
                                open = false;
                            }
                            else
                            {
                                break;
                            }
                            break;
                        }
                        default: Console.WriteLine("\nОшибка, вы ввели несуществующий пункт меню! Попробуйте еще раз."); break;
                }
            }

        }

     }
}
