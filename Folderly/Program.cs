// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

string directoryPath = "/testdirectory";
string fileEnding = "*.txt";
string[] fileNames = Directory.GetFiles(directoryPath, fileEnding);
string[] commands = ExtractCommand(fileNames);
Console.WriteLine($"Found {commands[0]} commands");

Console.WriteLine(CreateCommand(commands));

static string[] ExtractCommand(string[] fileNames)
{
    string[] commands = new string[fileNames.Length];
    string regexPattern = "\\d{4}_(.*?)\\.txt$";

    for (int i = 0; i < fileNames.Length; i++)
    {
        Match match = Regex.Match(fileNames[i], regexPattern);
        if (!match.Success)
        {
            throw new Exception();
        }
        commands[i] = match.Groups[1].Value;
    }

    return commands;
}

static string CreateCommand(string[] commands)
{
    string command = "";
    for (int i = commands.Length -1 ; i >= 0; i--)
    {
        command += commands[i] + " ";
    }
    return command;
}

