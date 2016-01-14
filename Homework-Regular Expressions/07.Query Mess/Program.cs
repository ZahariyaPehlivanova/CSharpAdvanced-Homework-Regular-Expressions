using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class QueryMess
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ïnsert your input text:");
        string text;
        string pattern = @"([^=&]+)=([^&=]+)";

        Regex regex = new Regex(pattern);
        MatchCollection matches;

        var query = new Dictionary<string, List<string>>();

        while (((text = Console.ReadLine()) != "END"))
        {
            text = text.Replace("%20", " ").Replace("+", " ").Replace("?", "&");
            matches = regex.Matches(text);

         foreach (Match match in matches)
            {
                string field = match.Groups[1].ToString().Trim();
                string value = match.Groups[2].ToString().Trim();
                if (!query.ContainsKey(field))
                {
                    query.Add(field, new List<string>());
                }
                query[field].Add(value);
            }
            foreach (string field in query.Keys)
            {
                Console.Write("{0} = [{1}]",field, string.Join(", ", query[field]));
            }
            Console.WriteLine();
            query.Clear();
        }
    }
}