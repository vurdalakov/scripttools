#!/usr/bin/env dotnet-script
// https://github.com/vurdalakov/scripttools/

using System.Runtime.InteropServices;

var bareOutput = (1 == Args.Count) && (("-b" == Args[0]) | ("--bare" == Args[0]));

var stringBuilder = new StringBuilder(1024);
var count = 0;

for (var message = 0xC000U; message <= 0xFFFFU; message++)
{
    if (GetClipboardFormatName(message, stringBuilder, stringBuilder.Capacity) > 0)
    {
        if (bareOutput)
        {
            Console.WriteLine(stringBuilder.ToString());
        }
        else
        {
            Console.WriteLine($"0x{message:X04} {stringBuilder}");
            count++;
        }
    }
}

if (!bareOutput)
{
    Console.WriteLine($"--- {count:N0} strings found");
}

[DllImport("user32.dll")]
static extern Int32 GetClipboardFormatName(UInt32 format, StringBuilder lpszFormatName, Int32 cchMaxCount);
