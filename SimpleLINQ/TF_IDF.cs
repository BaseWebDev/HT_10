using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleLINQ
{
    class TF_IDF
    {
        public string[] Lines { get; set; }
        public Dictionary<string, double> GetTfidf() {
            var regex = new Regex("\\w+", RegexOptions.Compiled);
            var data = Lines
                .Select(line => regex.Matches(line)
                    .OfType<Match>()  // Для приведения к типу с поддержкой IEnumerable<T>
                    .Select(m => m.Value)
                    .Select(s => s.ToLower())
                    .ToArray())
                .ToArray();
            // SelectMany - общая последовательность из нескольких вложенных массивов
            int countWords = data.SelectMany(v => v).Count();
            var wordsTF =
                data.SelectMany(d => d)
                .OrderBy(s => s)
                .GroupBy(t=>t)
                .Select(group=> new {WKey= group.Key, WTF =((double)group.Count() / countWords) });
            // Корпусом (или документом) будет считаться абзац, тоесть элемент массива Lines
            int countDoc = data.Count();
            var wordsIDF =
                data.Select(parag => parag.Distinct())
                .SelectMany(d1 => d1)
                .OrderBy(s2 => s2)
                .GroupBy(r => r)
                .Select(group1 => new { WKey = group1.Key, WIDF = Math.Log10(countDoc / (double)group1.Count()) });
            Dictionary<string, double> TF_IDF =
                wordsTF.Join(wordsIDF, wTF => wTF.WKey, wIDF => wIDF.WKey, (wTF, wIDF) => (wTF.WKey, wTF.WTF * wIDF.WIDF))
                .ToDictionary(gh=>gh.Item1, gh=>gh.Item2);
            return TF_IDF;
        }
    }
}
