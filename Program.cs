using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LUNYNE
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        { // Проверка наличия .dll файлов
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string[] dllFiles = Directory.GetFiles(directoryPath, "*.dll");

            if (dllFiles.Length > 0)
            {
                MessageBox.Show("Приложение не может быть запущено, так как в папке присутствуют .dll файлы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Завершаем выполнение
            }
            {
                // Список процессов, которые нужно проверить
                string[] forbiddenProcesses = { "dnspy", "ILspy", "de4dot", "JotPeek", "JootPeek", "cheatengine", "cheatengine-x86_64", "de4dot-x64", "de4dot-x32", "dnspy.exe", "ILspy.exe", "de4dot.exe", "JotPeek.exe", "JootPeek.exe", "cheatengine.exe", "cheatengine-x86_64.exe", "de4dot-x64.exe", "de4dot-x32.exe" }; // Замените на названия процессов

                // Проверка запущенных процессов
                if (IsAnyProcessRunning(forbiddenProcesses))
                {
                    MessageBox.Show("Приложение не может быть запущено, так как установлены запрещенные программы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Завершаем выполнение
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        static bool IsAnyProcessRunning(string[] processNames)
        {
            return processNames.Any(name => Process.GetProcessesByName(name).Length > 0);
        }
    }
}
