using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    public class ImportanceEvaluator : IImportance<int>, IImportance<string>
    {
        public int MostImportant(int v1, int v2)
        {
            if(v1 > v2)
            {
                return v1;
            }
            else
            {
                return v2;
            }
        }

        public string MostImportant(string v1, string v2)
        {
            if (v1.Length > v2.Length)
            {
                return v1;
            }
            else
            {
                return v2;
            }
        }
    }
}
