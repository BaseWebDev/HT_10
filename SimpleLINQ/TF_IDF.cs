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
        public List<Dictionary<string, double>> GetTfidf() {
            var regex = new Regex("\\w+", RegexOptions.Compiled);
            var data = Lines
                .Select(line => regex.Matches(line)
                    .OfType<Match>()  // Для приведения к типу с поддержкой IEnumerable<T>
                    .Select(m => m.Value)
                    //.Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(s => s.ToLower())
                    .ToArray())
                .ToArray();
            // SelectMany - общая последовательность из нескольких
            var words = data.SelectMany(d => d).Distinct().OrderBy(s => s).ToArray();



            return null;// List<Dictionary<string,double>>  ;
        }
    }
}
