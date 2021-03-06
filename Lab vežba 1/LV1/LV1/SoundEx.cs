﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV1
{
    class SoundEx // https://en.wikipedia.org/wiki/Soundex#American_Soundex
    {
        // abcdefghijklmnopqrstuvwxyz
        // 01230120022455012623010202
        public static readonly char[] LetterCodes = {'0', '1', '2', '3', '0', '1', '2', '0', '0', '2', '2', '4', '5', '5', '0', '1', '2', '6', '2', '3', '0', '1', '0', '2', '0', '2'};
        public static readonly char[] Vowels = { 'A', 'E', 'I', 'O', 'U' };
        private readonly string _patternCode;
        private readonly string _pattern;

        public SoundEx(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentNullException();
            this._pattern = pattern;
            this._patternCode = SoundExCode(pattern);
        }

        public static string SoundExCode(string word)
        {
            if (string.IsNullOrEmpty(word))
                throw new ArgumentNullException();
            word.Trim();
            word = word.ToUpper();
            if (!IsComprisedOfAlphabet(word))
                throw new ArgumentException("string contains invalid characters for SoundEx");

            char firstLetter = word[0];
            char prevLetter = firstLetter;
            char prevCode = LetterCodes[firstLetter - 65];

            StringBuilder sxCode = new StringBuilder();
            sxCode.Append(firstLetter);

            int i = 1;
            while (i < word.Length && word[i] == firstLetter) i++;
            if (i < word.Length && i == 1 && (word[i] == 'H' || word[i] == 'W'))
            {
                if (i + 1 < word.Length && LetterCodes[word[++i] - 65] == prevCode)
                    sxCode.Append(prevCode);
            }

            for (; i < word.Length; i++)
            {
                char code = LetterCodes[word[i] - 65];
                if (code == prevCode && code != '0') // code != '0' needed if first two are vowels
                {
                    if (i > 1 && Vowels.Contains(word[i - 1])) // i > 1 means i-1 is not the first letter
                        sxCode.Append(code);
                    continue;
                }
                if (code == '0') continue;
                prevCode = code;
                sxCode.Append(code);
                if (sxCode.Length == 4) break;
            }

            while (sxCode.Length < 4)
                sxCode.Append('0');

            return sxCode.ToString();
        }

        private static bool IsComprisedOfAlphabet(string str)
        {
            foreach (char c in str)
                if (c < 'A' || c > 'Z')
                    return false;
            
            return true;
        }

        public void SearchAllEqualCodes(string[] words, string writeToFile)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(writeToFile, FileMode.Create)))
            {
                Stopwatch t = new Stopwatch();
                t.Start();
                Console.WriteLine("Start SoundEx - " + t.Elapsed);
                foreach (string word in words)
                {
                    try
                    {
                        if (SoundExEquals(word))
                        {
                            sw.Write(t.Elapsed + " : ");
                            sw.WriteLine(_pattern + " - " + word + " - " + _patternCode);
                        }
                    } catch (ArgumentException)
                    {

                    }
                    
                }
                Console.WriteLine("Stop SoundEx - " + t.Elapsed);
                t.Stop();
            }
        }

        public bool SoundExEquals(string word)
        {
            return _patternCode.Equals(SoundExCode(word));
        }
    }
}
