﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Normalization
{
    public static class Extension1
    {

        public static string[] SplitToParagraphs(this string s, string d)
        {
            List<string> list = new List<string>();
            int i;
            while (s.Contains(d))
            {
                i = s.IndexOf(d);
                list.Add(s.Substring(0, i));
                s = s.Substring(i + d.Length);
            }
            list.Add(s);
            while (list.Contains(""))
            {
                list.Remove("");
            }
            return list.ToArray();
        }

        public static string NormalizeDashes(this string s, ref string logs)
        {
            s = s.MyReplace("-\r\n", "", ref logs);
            s = s.MyReplace(" - ", " – ", ref logs);
            s = s.MyReplace("--", "–", ref logs);
            s = s.Replace("––", "----");
            s = s.Replace("–-", "---");
            s = s.MyReplace(" -", "-", ref logs);
            s = s.MyReplace("- ", "-", ref logs);
            s = s.MyReplace("\r\n-", "\r\n- ", ref logs);
            return s;
        }

        public static string NormalizeReturns(this string text, bool b, ref string logs)
        {
            string[] pars = text.SplitToParagraphs("\r\n\r\n");
            for (int i = 0; i <pars.Length; i++)
            {
                string s = pars[i];
                s = s.MyReplace("\r\n", " ", ref logs);
                s = s.MyReplace("\r", " ", ref logs);
                s = s.MyReplace("\n", " ", ref logs);
                pars[i] = s;
            }
            
            if (b) return string.Join("\r\n", pars);
            else return string.Join("\r\n\r\n", pars);
        }

        public static string RemoveSpaces(this string text, ref string logs)
        {
            string[] noSpaceBefore = new string[] { ".", ",", ":", ";", "?", "!", ")", "\r\n" };
            string[] noSpaceAfter = new string[] { "(", "\r\n" };
            text = text.Trim(' ');
            while (text.Contains("  "))
                text = text.MyReplace("  ", " ", ref logs);
            foreach (string s in noSpaceBefore)
                text = text.MyReplace(" " + s, s, ref logs);
            foreach (string s in noSpaceAfter)
                text = text.MyReplace(s + " ", s, ref logs);
            return text;
        }

        public static string NormalizeQuotations(this string text, ref string logs)
        {
            // „“ – words;
            // «» – sentence;
            string[] quotesOut = new string[] { "?", "!", ")", "?!", ",", ":" };
            string[] quotesIn = new string[] { ",", "?", "!", ")", "?!", "\r\n" };
            text = text.MyReplace(".\"", ".»", ref logs);
            text = text.MyReplace("\".", "».", ref logs);
            text = text.MyReplace("(\"", "(«", ref logs);
            text = text.MyReplace("\"(", "«(", ref logs);
            text = text.MyReplace("''", "\"", ref logs);
            text = text.MyReplace(" '", " \"", ref logs);
            text = text.MyReplace("' ", "\" ", ref logs);
            text = text.MyReplace("“", "\"", ref logs);
            text = text.MyReplace("„", "\"", ref logs);
            text = text.MyReplace(" \"", " «", ref logs);
            text = text.MyReplace("\" ", "» ", ref logs);
            text = text.MyReplace("\"\r\n", "»\r\n", ref logs);
            foreach (string s in quotesOut)
            {
                text = text.MyReplace("\"" + s, "»" + s, ref logs);
            }
            foreach (string s in quotesIn)
            {
                text = text.MyReplace(s + "\"", "»" + s, ref logs);
            }
            return text;
        }
    }
}
