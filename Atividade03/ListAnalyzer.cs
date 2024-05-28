using System;
using System.Collections.Generic;
using System.Linq;

namespace Atividade03
{
    public class ListAnalyzer
    {
        public int? FindMax(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                return null;
            }
            return numbers.Max();
        }
    }
}
