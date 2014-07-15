using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication5
{
    static public class Program
    {
        // открывает файл, заполняет значениями все поля
        static void Preparefile()
        {
            // считывает все символы файла в одну строку!
            string file = File.ReadAllText("C:\\Users\\Всеволод\\Desktop\\text\\test.txt");
            
            filelenght = file.Length;
            chrarray = new int[filelenght];
            s = new int[filelenght];
            
            for (int i = 0; i < filelenght; i++)
            {
                chrarray[i] = (int)file[i];
            }
        }

        // число всех символов файла
        static int filelenght;
        // массив состоящий из массивов символов каждой строки
        static int[] chrarray;
        static int[] s;
        static int code1;
        static int code2;
        static int code3;
        // вывод массива содержащего текст файла (или уже зашифр.) на консоль
        static void Writefile()
        {
            for (int i = 0; i < filelenght; i++)
            {
                Console.Write(chrarray[i]);
                Console.Write(" ");
            }
                Console.WriteLine();
                Console.WriteLine();
        }
        // шифратор
        static void Shifrator(int t, int t1, int t2)  // три переменные кода - три уровня шифра
        {
            int k = 0;
            int p = t1;
            // первые два уровня один - лин. ко всему массиву
            // второй - вычитает либо одно, либо другое число из части эл-ов
            for (int i = 0; i < filelenght; i++)
                {
                    chrarray[i] = chrarray[i] + t;
                if (chrarray[i] > 130)
                {
                    chrarray[i] = chrarray[i] - 9 - p;
                    s[k] = i;
                    k = k + 1;
                    if (t1 == p/2)
                    {
                        p = t1;
                    }
                    p = 2*t1;
                }
                }
            k = 0;
            // третий уровень шифра линейный - прибавляет сумму ряда к эл-ту 
            for (int i = 0; i < filelenght; i++)
            {
                for (int j = 0; j < t2; j++)
                {
                    chrarray[i] = chrarray[i] + j;
                }
            }
        }
        static void Deshifrator(int t, int t1, int t2) // тоже что и в шифраторе, но наоборот)
        {
            int k = 0;
            int p = t1;
            for (int i = 0; i < filelenght; i++)
            {
                chrarray[i] = chrarray[i] - t;
                if (i == s[k])
                {
                    chrarray[i] = chrarray[i] + 9 + p;
                    k = k + 1;
                    if (t1 == p/2)
                    {
                        p = t1;
                    }
                    p = 2 * t1;
                }
            }
            k = 0;
            for (int i = 0; i < filelenght; i++)
            {
                for (int j = 1; j < t2; j++)
                {
                    chrarray[i] = chrarray[i] - j;
                }
            }
        }
        static void ReadCode()
        {
            Console.WriteLine("Введите код из трех символов.");
            string code = Console.ReadLine();
            // проверка длины введенного кода
            if (code.Length == 3)
            {
                    code1 = Convert.ToInt32(code[0]);
                    code2 = Convert.ToInt32(code[1]);
                    code3 = Convert.ToInt32(code[2]);
            }
            else
            {
                Console.WriteLine("Ошибка ввода.");
                return;
            }
            
        }
        static void Convertfiletobyte()
        {
            // ммм, потенциально полезная функция, лень писать
        }
        static void Main(string[] args)
        {
            Preparefile();
            Writefile();
            ReadCode();
            Shifrator(code1,code2,code3);
            Writefile();
            ReadCode();
            Deshifrator(code1, code2, code3);
            Writefile();

            
            Console.ReadKey();
        }
    }
}
