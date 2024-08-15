using Square.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Helpers;

public class SquareUpHelper
{

    public static long ConvertFloatToSquareLong(float value)
    {
        return long.Parse(value.ToString("0.00").Replace(".", string.Empty));
    }

    public static float ConvertSquareLongToFloat(long value)
    {
        string amt = value.ToString();
        amt = amt.Insert(amt.Length - 2, ".");
        return float.Parse(amt);
    }
}
