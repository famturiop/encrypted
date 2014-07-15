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
            string file = File.ReadAllText("C:\\Users\\Всеволод\\Desktop\\text\\test.txt");
            
            filelenght = file.Length;
            chrarray = new int[filelenght];
            s = new int[filelenght];
            r = new int[filelenght];
            for (int i = 0; i < filelenght; i++)
            {
                chrarray[i] = (int)file[i];
            }

        }

        // число 
        static int filelenght;
        // массив состоящий из массивов символов каждой строки
        static int[] chrarray;
        // вывод массива содержащего текст файла (или уже зашифр.) на консоль
        static int[] s;
        static int[] r;
        static int code1;
        static int code2;
        static int code3;
        static void Writefile()
        {
            for (int i = 0; i < filelenght; i++)
            {
                Console.Write((char)chrarray[i]);
                
            }
                Console.WriteLine();
                Console.WriteLine();
        }
        // обычный шифратор, числа 1, 5 и 7 могут задаватся ключом
        static void Shifrator(int t, int t1, int t2)
        {
            int k = 0;
            
            int p = t1;
            for (int i = 1; i < filelenght; i++)
                {
                    chrarray[i] = chrarray[i] + t;
                if (chrarray[i] > 100)
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
            for (int i = 1; i < filelenght; i++)
            {
                if (chrarray[i] == 91)
                {
                    chrarray[i] = chrarray[i] + t2;
                    r[k] = i;
                    k = k + 1;
                }
            }
        }
        static void Deshifrator(int t, int t1, int t2)
        {
            int k = 0;
            
            int p = t1;
            for (int i = 1; i < filelenght; i++)
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
            for (int i = 1; i < filelenght; i++)
            {
                if (i == r[k])
                {
                    chrarray[i] = chrarray[i] - t2;
                    
                    k = k + 1;
                }
            }
        }
        static void ReadCode()
        {
            Console.WriteLine("Введите код из трех цифр.");
            string code = Console.ReadLine();
            if (code.Length == 3)
            {
                int i = 0;
                i = 3;
                if (i == 3)
                {
                    code1 = code[0];
                    code2 = code[1];
                    code3 = code[2];
                }
                else
                {
                    Console.WriteLine("Ошибка ввода.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода.");
            }
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
