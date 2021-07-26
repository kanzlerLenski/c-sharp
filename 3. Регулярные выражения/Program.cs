using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace RegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"..\..\File01.txt");
            StringBuilder sb = new StringBuilder();
            string s = sr.ReadToEnd();

            //-\r\n->удалить
            string pattern = "([^\r\n])-\r\n([^\r\n])";
            string replacement = "$1$2";
            MatchCollection matches = Regex.Matches(s, pattern);
            foreach (Match m in matches)
                sb.AppendFormat("Удалили перенос на позиции {0}\r\n", m.Index);

            //\r\n->пробел (кроме перечислений)
            pattern = "([^\r\n])\r\n([^\r\n-])";
            replacement = "$1 $2";
            matches = Regex.Matches(s, pattern);
            foreach (Match m in matches)
                sb.AppendFormat("Заменили перенос на пробел на позиции {0}\r\n", m.Index);
            
            //переводы строки
            pattern = "(\r\n){3,}";
            replacement = "\r\n\r\n";
            matches = Regex.Matches(s, pattern);
            foreach (Match m in matches)
                sb.AppendFormat("Заменили {0} на позиции {1}\r\n", m.Value.Replace("\r", "\\r").Replace("\n", "\\n"), m.Index);

            pattern = " {2,}";
            replacement = " {1}";
            matches = Regex.Matches(s, pattern);
            foreach (Match m in matches)
                sb.AppendFormat("Заменили двойные пробелы на позиции {0}\r\n", m.Index);

            pattern = " ([.,:;?!)\r\n])";
            replacement = "$1";
            matches = Regex.Matches(s, pattern);
            foreach (Match m in matches)
                sb.AppendFormat("Заменили лишние пробелы перед знаками препинания на позиции {0}\r\n", m.Index);

            pattern = "([(\r\n])";
            replacement = "$1";
            matches = Regex.Matches(s, pattern);
            foreach (Match m in matches)
                sb.AppendFormat("Заменили лишние пробелы после знаков препинания на позиции {0}\r\n", m.Index);

            //собственно, замены
            pattern = "([^\r\n])-\r\n([^\r\n])";
            replacement = "$1$2";
            s = Regex.Replace(s, pattern, replacement);
            pattern = "([^\r\n])\r\n([^\r\n-])";
            replacement = "$1 $2";
            s = Regex.Replace(s, pattern, replacement);
            pattern = "(\r\n){3,}";
            replacement = "\r\n\r\n";
            s = Regex.Replace(s, pattern, replacement);
            pattern = "( ){2,}";
            replacement = "( ){1}";
            s = Regex.Replace(s, pattern, replacement);
            pattern = " ([.,:;?!)\r\n])";
            replacement = "$1";
            s = Regex.Replace(s, pattern, replacement);
            pattern = "([(\r\n])";
            replacement = "$1";
            s = Regex.Replace(s, pattern, replacement);

            File.WriteAllText(@"..\..\File01_result.txt", s);
            File.WriteAllText(@"..\..\File01_log.txt", sb.ToString());
        }
    }
}
