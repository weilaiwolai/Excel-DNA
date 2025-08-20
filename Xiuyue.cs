using ExcelDna.Integration;
using System;

public class XiuyueFunctions
{
    [ExcelFunction(Name = "XIUYUE_JS")]
    public static double XiuyueJS(
        [ExcelArgument("需要修约的数值")] double value,
        [ExcelArgument("小数位数", DefaultValue = 0)] int decimals,
        [ExcelArgument("修约间隔（可选）", DefaultValue = 0)] double interval)
    {
        if (value == 0) return 0;

        var ri = decimals != 0 ? Math.Pow(10, -decimals)
                               : (interval > 0 ? interval : double.NaN);
        if (double.IsNaN(ri)) return double.NaN;

        var m = Math.Abs(value) / ri;
        var f = Math.Floor(m + 0.5);
        if (m - f == -0.5 && ((int)Math.Floor(m) & 1) == 1) f -= 1;

        return Math.Sign(value) * f * ri;
    }
}