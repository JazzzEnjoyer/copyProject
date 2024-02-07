using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // ���� � .proj �����
        string projFilePath = "copyscript.csproj";

        // ��������, ������� ����� ������� � .proj ����
        string copyFolderParam = "Folder1"; // �������� �� "Folder2" ��� ������ ��������, ���� ����������

        // ������� ����� �������
        Process process = new Process();
        process.StartInfo.FileName = "dotnet"; // ���� � ������������ ����� dotnet
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;

        // �������� ��������� � .proj ���� ����� ��������� ��������� ������
        process.StartInfo.Arguments = $"msbuild \"{projFilePath}\" /p:CopyFolderParam={copyFolderParam}";

        // ��������� �������
        process.Start();

        // ��������� ���������� �������� � �������� �����
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        // ������� ��������� ���������� �������� (stdout)
        Console.WriteLine(output);

        // ��������� ��� ����������
        int exitCode = process.ExitCode;
        if (exitCode == 0)
        {
            Console.WriteLine("����������� ��������� �������.");
        }
        else
        {
            Console.WriteLine($"������ ���������� � �������. ��� ����������: {exitCode}");
        }
    }
}