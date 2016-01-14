using System;
using System.Text.RegularExpressions;

namespace _02.Replace_tag
{
    class Program
    {
        class ReplaceATag
        {
            static void Main()
            {
                string input = Console.ReadLine();
                string pattern = @"<a\s+href=([^>]+)>([^<]+)</a>";
                Regex regex = new Regex(pattern);
                string replacement = "[URL href=$1]$2[/URL]";
                string result = Regex.Replace(input, pattern, replacement);
                Console.WriteLine(result);
            }
        }
    }
}
