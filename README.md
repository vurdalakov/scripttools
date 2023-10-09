# ScriptTools

`ScriptTools` is a collection of C# scripts that use [dotnet script](https://github.com/dotnet-script/dotnet-script) engine to run.

All scripts are distributed under the [MIT license](http://opensource.org/licenses/MIT).

## Using dotnet script

#### Install dotnet script

1. Install [.NET 7](https://dotnet.microsoft.com/en-us/download)
1. Run from command line (to install `dotnet script`):
    ```
    dotnet tool install -g dotnet-script
    ```
1. Run from command line (to execute scripts directly from a command line as if they were executables):
    ```
    dotnet script register
    ```

#### Create and run script

1. Create an empty `HelloWorld.csx` text file.
1. Add this line:
    ```
    Console.WriteLine("Hello world");
    ```
1. Run from command line:
    ```
    HelloWorld.csx
    ```

## Scripts

* [File2CppByteArray.csx](src/File2CppByteArray/README.md) - Converts a file to a C++ bytes array.
* [RegisteredWindowMessages.csx](src/RegisteredWindowMessages/README.md) - Lists windows messages that were registered with RegisterWindowMessageA() and RegisterWindowMessageW functions.
* [ShowBits.csx](src/ShowBits/README.md) - Shows bits of any number.
