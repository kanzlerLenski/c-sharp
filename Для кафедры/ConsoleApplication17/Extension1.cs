using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Normalization
{
    public static class Extension1
    {
        public static string normalizeSpaces(this string text)
        {
            text = text.Trim(' ');
            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }

            string[] noSpaceBeforeandAfter = new string[] { ".", ",", ":", ";", "?", "!", ")", "\r\n"};
            foreach (string s in noSpaceBeforeandAfter)
            {
                text = text.Replace(" " + s, s);
            }

            text = text.Replace("( ", "(").Replace("\r\n ", "\r\n");
            return text;
        }


        public static string normalizeDashes(this string text)
        {
            text = text.Replace("-\r\n", "");


            if (text.Contains(" - "))
            {
                text = text.Replace(" - ", " – ");
            }

            text = text.Replace("--", "–");
            text = text.Replace("––", "----");
            text = text.Replace("–-", "---");
            text = text.Replace(" -", "-");
            text = text.Replace("- ", "-");

            return text;

        }

        public static string normalizeReturns(this string text)
        {
            if (!text.Contains("prvkhjdfkhdgioujerlkntknbkrjg57tidjhseojruhgpsdouitytjkhgjfdj546757ygs8jfhjhdoh0jrhduithggjudtoi467usjtjgvbkjhsolsjith785656gvsetkc"))
            {

                text = text.Replace("\r\n\r\n", "prvkhjdfkhdgioujerlkntknbkrjg57tidjhseojruhgpsdouitytjkhgjfdj546757ygs8jfhjhdoh0jrhduithggjudtoi467usjtjgvbkjhsolsjith785656gvsetkc");
                text = text.Replace("\r\n", " ");
                text = text.Replace("\r", " ");
                text = text.Replace("\n", " ");
                text = text.Replace("prvkhjdfkhdgioujerlkntknbkrjg57tidjhseojruhgpsdouitytjkhgjfdj546757ygs8jfhjhdoh0jrhduithggjudtoi467usjtjgvbkjhsolsjith785656gvsetkc", "\r\n\r\n");
            }


            /*else if (!text.Contains("blntm"))
            {

                text = text.Replace("\r\n\r\n", "blntm");
                text = text.Replace("\r", "\r\n");
                text = text.Replace("\n", "\r\n");
                text = text.Replace("\r\n", " ");
                text = text.Replace("blntm", "\r\n\r\n");
            }

            else

                text = text.Replace("\r\n\r\n", "stvst");
                text = text.Replace("\r", "\r\n");
                text = text.Replace("\n", "\r\n");
                text = text.Replace("\r\n", " ");
                text = text.Replace("\r  ", " ");
                text = text.Replace("stvst", "\r\n\r\n");*/

            return text;

        }


        public static string normalizeQuotations(this string text)
        {
            // „“ – words;
            // «» – sentence;
            
            text = text.Replace("''", "\"");
            text = text.Replace(" '", " \"");
            text = text.Replace("' ", "\" ");
            text = text.Replace("“", "\"");
            text = text.Replace("„", "\"");


            string[] quot = new string[] { "?", "!", ")", "(", "?!" };
            foreach (string s in quot)
            {
                text = text.Replace(" " + "\"", " " + "«");
                text = text.Replace("\"" + " ", "»" + " ");
                text = text.Replace("\"" + "\r\n", "»" + "\r\n");
                text = text.Replace("\"" + s, s + "»");
                text = text.Replace(s + "\"", s + "»");
            }

            string[] quot2 = new string[] { ".", ",", ":", ";" };
            foreach (string s in quot2)
            {
                text = text.Replace("\"" + s, "»" + s);

            }

            /*text = text.Replace(" " + s, s);
            text = text.Replace("'. ", "». ");
            text = text.Replace("\". ", "». ");
            text = text.Replace("“. ", "». ");
            text = text.Replace("'' ", "». ");
            text = text.Replace("'. ", "». ");
            text = text.Replace("\". ", "». ");
            text = text.Replace("“. ", "». ");*/

            return text; 

        }
    }
        }

            
        

