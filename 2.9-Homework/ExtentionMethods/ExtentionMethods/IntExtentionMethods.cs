using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethods.ExtentionMethods;

public static class IntExtentionMethods
{
    public static bool EvenNumber(this int input)
    {
        if (input % 2 == 0)
        {
            return true;
        }
        return false;
    }
    public static bool PrimeNumber(this int input)
    {
        if (input == 0 || input == 1)
        {
            return false;
        }
        if (input == 2)
        {
            return true;
        }
        for (int i = 3; i < input; i += 2)
        {
            if (input % i == 0)
            {
                return false;
            }
        }
        if(EvenNumber(input))
        {
            return false;
        }
        return true;
    }
    public static int AddNumber(this int input, int value)
    {
        return input + value;
    }

}
