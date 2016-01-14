using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.Valid_Usernames
{
    class ValidUsernames
    {
        static void Main()
        {
            string line = Console.ReadLine().Trim();
            string[] usernames = Regex.Split(line, @"[\s/\\\(\)]+");
            List<string> validUsernames = new List<string>();

           
            string validUsernamePat = @"^[A-Za-z]\w+$";
            foreach (string username in usernames)
            {
                if (username.Length >= 3 && username.Length <= 25
                    && Regex.IsMatch(username, validUsernamePat))
                    validUsernames.Add(username);
            }
            
            int maxSumLen = 0, currentSumLen = 0, maxSumLenIndex = 0;
            for (int i = 0; i < validUsernames.Count - 1; i++)
            {
                currentSumLen = validUsernames[i].Length + validUsernames[i + 1].Length;
                if (currentSumLen > maxSumLen)
                {
                    maxSumLen = currentSumLen;
                    maxSumLenIndex = i;
                }
            }

            Console.WriteLine("{0}\n{1}", validUsernames[maxSumLenIndex],
                validUsernames[maxSumLenIndex + 1]);
        }
    }
}
