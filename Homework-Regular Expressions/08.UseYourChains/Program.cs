using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace _08.UseYourChains
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert your text:");
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
            string input = Console.ReadLine();
            StringBuilder inputSB = new StringBuilder();

            string tagContents = @"<\s*p\s*>([^<]+?)<\s*\/p\s*>";
            Regex regexPCont = new Regex(tagContents, RegexOptions.IgnoreCase);
            Regex regexNotSmallLetter = new Regex(@"[^a-z0-9]");
            foreach (Match match in regexPCont.Matches(input))
            {
                String pContent = match.Groups[1].Value;
                pContent = regexNotSmallLetter.Replace(pContent, " ");
                pContent = Regex.Replace(pContent, @"\s+", " ");
                inputSB.Append(pContent);
            }
            for (int i = 0; i < inputSB.Length; i++)
            {
                char ch = inputSB[i];
                if (Char.IsLower(ch))
                {
                    if (ch >= 'a' && ch < 'n')
                        ch = (char)(ch + 13);
                    else
                        ch = (char)(ch - 13);
                    inputSB[i] = ch;
                }
            }

            Console.WriteLine(inputSB);
        }
    }
}
