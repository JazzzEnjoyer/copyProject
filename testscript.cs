using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Путь к .proj файлу
        string projFilePath = "copyscript.csproj";

        // Параметр, который будет передан в .proj файл
        string copyFolderParam = "Folder1"; // Измените на "Folder2" или другое значение, если необходимо

        // Создать новый процесс
        Process process = new Process();
        process.StartInfo.FileName = "dotnet"; // Путь к исполняемому файлу dotnet
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;

        // Передать параметры в .proj файл через аргументы командной строки
        process.StartInfo.Arguments = $"msbuild \"{projFilePath}\" /p:CopyFolderParam={copyFolderParam}";

        // Запустить процесс
        process.Start();

        // Дождаться завершения процесса и получить вывод
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        // Вывести результат выполнения процесса (stdout)
        Console.WriteLine(output);

        // Проверить код завершения
        int exitCode = process.ExitCode;
        if (exitCode == 0)
        {
            Console.WriteLine("Копирование завершено успешно.");
        }
        else
        {
            Console.WriteLine($"Проект завершился с ошибкой. Код завершения: {exitCode}");
        }
    }
}