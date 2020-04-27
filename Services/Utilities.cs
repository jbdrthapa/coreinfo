using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Core.Server
{
    public static class Utilities
    {
        public static string ExecuteCommand(string command)
        {
            var commandOutput = string.Empty;
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "/bin/bash";
            startInfo.Arguments = $"-c \"{command}\"";
            startInfo.RedirectStandardOutput = true;

            using (var process = Process.Start(startInfo))
            {
                commandOutput = process.StandardOutput.ReadToEnd();
            }

            return commandOutput;
        }

        public static string GetValue(string searchString, string searchText)
        {
            var searchValue = "Unknown";
            var searchPattern = @"[\n\r].*{0}\s*([^\n\r]*)";

            var matchString = new Regex(string.Format(searchPattern, searchString)).Match(searchText);
            if (matchString.Success)
            {
                searchValue = matchString.Value.Split(": ")[1];
            }

            return searchValue;

        }
    }

}