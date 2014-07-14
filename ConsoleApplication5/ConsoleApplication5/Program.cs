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
            string[] file = File.ReadAllLines("C:\\Users\\Всеволод\\Desktop\\text\\test.txt");
            filelenght = file.Length;
            stringsize = new int[filelenght];
            s = new string[filelenght];
            chrarray = new char[filelenght][];
            for (int i = 0; i < filelenght; i++)
            {
                stringsize[i] = file[i].Length;
                s[i] = file[i];
            }
            for (int i = 0; i < filelenght; i++)
            {
                chrarray[i] = new char[stringsize[i]];
                for (int j = 0; j < stringsize[i]; j++)
                {

                    chrarray[i][j] = s[i][j];
                }

            }
        }

        // число строк в файле
        static int filelenght;
        // массив длин строк файла
        static int[] stringsize = new int[filelenght];
        // массив строк файла (сам файла)
        static string[] s = new string[filelenght];
        // массив состоящий из массивов символов каждой строки
        static char[][] chrarray = new char[filelenght][];
        // вывод массива содержащего текст файла (или уже зашифр.) на консоль
        static void Writefile()
        {
            for (int i = 0; i < filelenght; i++)
            {
                
                for (int j = 0; j < stringsize[i]; j++)
                {

                    Console.Write(chrarray[i][j]);
                }
                Console.WriteLine();
            }
        }
        // обычный шифратор
        static void Shifrator()
        {
            for (int i = 0; i < filelenght; i++)
            {

                for (int j = 0; j < stringsize[i]; j++)
                {
                    chrarray[i][j] = (char)(s[i][j] + 1);
                    
                }
                
            }
        }
        // дешифратор
        static void Deshifrator()
        {
            for (int i = 0; i < filelenght; i++)
            {

                for (int j = 0; j < stringsize[i]; j++)
                {
                    chrarray[i][j] = (char)(s[i][j] - 1);

                }

            }
        }
        static void Main(string[] args)
        {
            Preparefile();
            Writefile();
            Shifrator();
            Writefile();
            Deshifrator();
            Writefile();
            Console.ReadKey();
        }
    }
}
