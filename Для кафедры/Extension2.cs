﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Normalization
{   
    public static class Extension2
    {
        public static string GetContext(this string s, int i, int l, int w)
        {
            string leftContext = "";
            string rightContext = "";
            if (i - w >= 0)
                leftContext = s.Substring(i - w, w);
            else
                leftContext = s.Substring(0, i);

            if (i + l + w < s.Length)
                rightContext = s.Substring(i + l, w);
            else
                rightContext = s.Substring(i + l);
            string result = leftContext + s.Substring(i, l) + rightContext;
            result = result.Replace("\r", "\\r").Replace("\n", "\\n");
            return result;
        }

        public static string MyReplace(this string s, string s1, string s2, ref string logs)
        {
            int currentIndex = s.IndexOf(s1);
            int nextIterationStart = -1;
            while (currentIndex != -1)
            {
                nextIterationStart = (s.Substring(0, currentIndex) + s2).Length;
                logs += "Заменили " + s1.Replace("\r", "\\r").Replace("\n", "\\n") + " на " + s2.Replace("\r", "\\r").Replace("\n", "\\n") + " в цепочке " + s.GetContext(currentIndex, s1.Length, 10) + "\r\n";
                s = s.Substring(0, currentIndex) + s2 + s.Substring(currentIndex + s1.Length);
                currentIndex = s.IndexOf(s1, nextIterationStart);
            }
            return s;
        }

        public static string MyReplace(this string s, char c1, char c2, ref string logs)
        {
            return s.MyReplace(new string(c1, 1), new string(c2, 1), ref logs);
        }

        public static bool ContainsCyrillic(string s)
        {
            bool f = false;
            foreach (char c in s)
            {
                f |= ((c >= 'А') && (c <= 'я')) | ("ёЁ".Contains(c));
            }
            return f;
        }

        public static string NormalizeCyrLat(this string str, ref string logs)
        {
            string[] splitted = str.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            for (int i = 0; i < splitted.Length; i++)
            {
                string str1 = splitted[i];
                string[] splitted1 = str1.Split(new string[] { "-" }, StringSplitOptions.None);
                for (int j = 0; j < splitted1.Length; j++)
                {
                    string str2 = splitted1[j];
                    string[] splitted2 = str2.Split(new string[] { " " }, StringSplitOptions.None);
                    for (int k = 0; k < splitted2.Length; k++)
                    {
                        string word = splitted2[k];
                        if (ContainsCyrillic(word))
                        {
                            word = word.MyReplace('A', 'А', ref logs);
                            word = word.MyReplace('B', 'В', ref logs);
                            word = word.MyReplace('C', 'С', ref logs);
                            word = word.MyReplace('E', 'Е', ref logs);
                            word = word.MyReplace('H', 'Н', ref logs);
                            word = word.MyReplace('K', 'К', ref logs);
                            word = word.MyReplace('M', 'М', ref logs);
                            word = word.MyReplace('O', 'О', ref logs);
                            word = word.MyReplace('P', 'Р', ref logs);
                            word = word.MyReplace('T', 'Т', ref logs);
                            word = word.MyReplace('X', 'Х', ref logs);

                            word = word.MyReplace('a', 'а', ref logs);
                            word = word.MyReplace('c', 'с', ref logs);
                            word = word.MyReplace('e', 'е', ref logs);
                            word = word.MyReplace('o', 'о', ref logs);
                            word = word.MyReplace('p', 'р', ref logs);
                            word = word.MyReplace('x', 'х', ref logs);
                            word = word.MyReplace('y', 'у', ref logs);
                        }
                        splitted2[k] = word;
                    }
                    str2 = string.Join(" ", splitted2);
                    splitted1[j] = str2;
                }
                str1 = string.Join("-", splitted1);
                splitted[i] = str1;
            }
            str = string.Join("\r\n", splitted);
            return str;
        }

        public static string NormalizeCyrLatExt(this string str, ref string logs)
        {
            string[] splitted = str.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            for (int i = 0; i < splitted.Length; i++)
            {
                string str1 = splitted[i];
                string[] splitted1 = str1.Split(new string[] { "-" }, StringSplitOptions.None);
                for (int j = 0; j < splitted1.Length; j++)
                {
                    string str2 = splitted1[j];
                    string[] splitted2 = str2.Split(new string[] { " " }, StringSplitOptions.None);
                    for (int k = 0; k < splitted2.Length; k++)
                    {
                        string word = splitted2[k];
                        if (ContainsCyrillic(word))
                        {
                            word = word.MyReplace('è', 'ѐ', ref logs);
                            word = word.MyReplace('i', 'і', ref logs);
                            word = word.MyReplace('ï', 'ї', ref logs);
                            word = word.MyReplace('j', 'ј', ref logs);
                            word = word.MyReplace('ħ', 'ћ', ref logs);
                            word = word.MyReplace('s', 'ѕ', ref logs);
                            word = word.MyReplace('ç', 'ҫ', ref logs);
                            word = word.MyReplace('Y', 'Ү', ref logs);
                            word = word.MyReplace('I', 'Ӏ', ref logs);
                            word = word.MyReplace('Ă', 'Ӑ', ref logs);
                            word = word.MyReplace('ă', 'ӑ', ref logs);
                            word = word.MyReplace('Ä', 'Ӓ', ref logs);
                            word = word.MyReplace('ä', 'ӓ', ref logs);
                            word = word.MyReplace('Æ', 'Ӕ', ref logs);
                            word = word.MyReplace('æ', 'ӕ', ref logs);
                            word = word.MyReplace('Ĕ', 'Ӗ', ref logs);
                            word = word.MyReplace('ĕ', 'ӗ', ref logs);
                            word = word.MyReplace('Ə', 'Ә', ref logs);
                            word = word.MyReplace('ǝ', 'ә', ref logs);
                            word = word.MyReplace('Ö', 'Ӧ', ref logs);
                            word = word.MyReplace('ö', 'ӧ', ref logs);
                            word = word.MyReplace('ɵ', 'ө', ref logs);
                            word = word.MyReplace('d', 'ԁ', ref logs);
                            word = word.MyReplace('G', 'Ԍ', ref logs);
                            word = word.MyReplace('Ɛ', 'Ԑ', ref logs);
                        }
                        splitted2[k] = word;
                    }
                    str2 = string.Join(" ", splitted2);
                    splitted1[j] = str2;
                }
                str1 = string.Join("-", splitted1);
                splitted[i] = str1;
            }
            str = string.Join("\r\n", splitted);
            return str;
        }

        public static string AddSpaces(this string s, ref string logs)
        {
            StringBuilder sb = new StringBuilder(logs);
            for (int i = 0; i < s.Length; i++)
            {
                //после
                if (i != s.Length - 1)
                {
                    if (s[i] == ',' && !(s[i + 1] == ' ') 
                        && !(s[i-1] >= '0' && s[i-1] <= '9' && s[i+1] >= '0' && s[i+1] <= '9'))//дробные числа
                    {
                        sb.Append(string.Format("Добавили пробел после {0} в цепочке" + s.GetContext(i, 1, 10) + "\r\n", s[i]));
                        s = s.Insert(i + 1, " ");
                    }

                    if ((":;".Contains(s[i])) && !(s[i + 1] == ' '))
                    {
                        sb.Append(string.Format("Добавили пробел после {0} в цепочке" + s.GetContext(i, 1, 10) + "\r\n", s[i]));
                        s = s.Insert(i + 1, " ");
                    }

                    if ((s[i] == '.') && !(".,-\r\"») ".Contains(s[i + 1]))
                        && !(s[i - 1] >= '0' && s[i - 1] <= '9' && s[i + 1] >= '0' && s[i + 1] <= '9')//дробные числа
                        && !(s[i - 1] >= 'a' && s[i - 1] <= 'z' && s[i + 1] >= 'a' && s[i + 1] <= 'z'))//интернет-адреса
                    {
                        sb.Append(string.Format("Добавили пробел после {0} в цепочке" + s.GetContext(i, 1, 10) + "\r\n", s[i]));
                        s = s.Insert(i + 1, " ");
                    }

                    if ((s[i] == '>') && !("-\r ".Contains(s[i + 1])))
                    {
                        sb.Append(string.Format("Добавили пробел после {0} в цепочке" + s.GetContext(i, 1, 10) + "\r\n", s[i]));
                        s = s.Insert(i + 1, " ");
                    }

                    if (("!?".Contains(s[i])) && !("\r?!)»\" ".Contains(s[i + 1])))
                    {
                        sb.Append(string.Format("Добавили пробел после {0} в цепочке" + s.GetContext(i, 1, 10) + "\r\n", s[i]));
                        s = s.Insert(i + 1, " ");
                    }

                    if (")»".Contains(s[i]) && !(")»\";:!?.,\r ".Contains(s[i + 1])))
                    {
                        sb.Append(string.Format("Добавили пробел после {0} в цепочке" + s.GetContext(i, 1, 10) + "\r\n", s[i]));
                        s = s.Insert(i + 1, " ");
                    }
                }
                //перед
                if (i != 0)
                {
                    if ("«(<".Contains(s[i]) && !"«\"(\n ".Contains(s[i - 1]))
                    {
                        sb.Append(string.Format("Добавили пробел перед {0} в цепочке" + s.GetContext(i, 1, 10) + "\r\n", s[i]));
                        s = s.Insert(i, " ");
                    }
                }
            }
            logs = sb.ToString();
            return s;
        }
    }
}
