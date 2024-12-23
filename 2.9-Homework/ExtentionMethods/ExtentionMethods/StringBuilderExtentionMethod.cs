using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethods.ExtentionMethods;

public static class StringBuilderExtentionMethod
{
    public static int UpperLetterCount(this StringBuilder sb)
    {
        int count = 0;
        for (int i = 0; i < sb.Length; i++)
        {
            if (char.IsUpper(sb[i]))
            {
                count++;
            }
        }
        return count;
    }
}
