#!/usr/bin/env dotnet-script
// https://github.com/vurdalakov/scripttools/

if (Args.Count != 1)
{
    Console.WriteLine("Usage: File2CppByteArray.csx <file-name>");
    Environment.Exit(1);
}

var filePath = Args[0];
var fileName = Path.GetFileNameWithoutExtension(filePath);

var i = 0;

using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
{
    Console.WriteLine($"// {filePath}");
    Console.WriteLine($"const unsigned char {fileName}[{fileStream.Length}] =");
    Console.Write("{");

    while (true)
    {
        var b = fileStream.ReadByte();
        if (b < 0)
        {
            break;
        }

        if (0 == (i % 32))
        {
            Console.WriteLine();
            Console.Write("    ");
        }

        Console.Write($"0x{b:X02},");
        
        i++;
        if ((i % 32) > 0)
        {
            Console.Write(" ");
        }
    }

    Console.WriteLine();
    Console.WriteLine("};");
}
