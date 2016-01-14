using System;
using System.Text;
using System.Text.RegularExpressions;


class Project
{
    static void Main()
    {
        Console.WriteLine("Write your first line of the input:");

        string input;
        
        StringBuilder sb = new StringBuilder();
        while ((input = Console.ReadLine()) != "END")
        {
            sb.Append(input);
            string htmlStr = sb.ToString();

            Regex aPattern = new Regex(@"<\s*a\s+[^>]+?>", RegexOptions.IgnoreCase);

            Regex hrefPattern = new Regex(@"href\s*=\s*([\u0022'])(.+?)\1");

            foreach (Match anchor in aPattern.Matches(htmlStr))
            {
                string anchorStr = anchor.Value;
                Match match = hrefPattern.Match(anchor.Value);
                if (match.Success)
                {
                    Console.WriteLine(match.Groups[2].Value);
                }
            }
        }
    }
}
