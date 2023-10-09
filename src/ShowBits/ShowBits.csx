#!/usr/bin/env dotnet-script
// https://github.com/vurdalakov/scripttools/

using System.Globalization;

if (Args.Count != 1)
{
    Console.WriteLine("Usage: ShowBits.csx <dec-or-hex-number>");
    Environment.Exit(1);
}

var number = Args[0].Trim().Replace("_", "").ToUpper();
var isHex = false;

if (number.StartsWith("#") || number.StartsWith("$") || number.StartsWith("&") || number.StartsWith("%"))
{
    isHex = true;
    number = number.Substring(1);
}
else if (number.StartsWith("0X") || number.StartsWith("\\X") || number.StartsWith("&H") || number.StartsWith("0H") || number.StartsWith("U+"))
{
    isHex = true;
    number = number.Substring(2);
}
else if (number.StartsWith("&#x"))
{
    isHex = true;
    number = number.Substring(3);
}
else if (number.EndsWith("H"))
{
    isHex = true;
    number = number.Substring(0, number.Length - 1);
}

if (!isHex)
{
    isHex = number.IndexOfAny(new[] { 'A', 'B', 'C', 'D', 'E', 'F' }) >= 0;
}

var integer = 0UL;

if (isHex)
{
    if (!UInt64.TryParse(number, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out integer))
    {
        NotANumber();
    }
}
else
{
    if (number.StartsWith('-'))
    {
        if (!Int64.TryParse(number, out var int64))
        {
            NotANumber();
        }
    
        integer = (UInt64)int64;
    }
    else
    {
        if (!UInt64.TryParse(number, out integer))
        {
            NotANumber();
        }
    }
}

void NotANumber()
{
    Console.WriteLine($"Not a dec or hex number: '{Args[0]}'");
    Environment.Exit(1);
}

var width = integer < 256 ? 2 : (integer < 65_536 ? 4 : (integer < 4_294_967_296 ? 8 : (integer < 281_474_976_710_656 ? 12 : 16)));
var hexFormat = $"X{width}";

Console.WriteLine($"Bits of    {FormatNumber(integer)}:");

var n = 1UL;

for (var i = 0U; i < 64; i++)
{
    if (1 == (integer & 1))
    {
        Console.WriteLine($" * Bit {i,2}: {FormatNumber(n)}");
    }
    
    integer >>= 1;
    n <<= 1;
}

String FormatNumber(UInt64 numberToFormat)
{
    var hex = numberToFormat.ToString(hexFormat);
    
    var i = 4;
    while (i < hex.Length)
    {
        hex = hex.Insert(i, "_");
        i += 5;
    }
    
    return String.Format($"0x{hex} or {numberToFormat}");
}
