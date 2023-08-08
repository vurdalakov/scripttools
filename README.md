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

### RegisteredWindowMessages.csx

Lists windows messages that were registered with [RegisterWindowMessageA()](https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerwindowmessagea) and
[RegisterWindowMessageW()](https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerwindowmessagew) functions.

| Switch | Long switch                     | Description                                                                                                         |
| ------ | ------------------------------- | ------------------------------------------------------------------------------------------------------------------- |
| -b     | --bare                          | Displays a bare list of message names, with no message identifiers and totals.                                      |

#### Example output (with no switch):

```
0xC001 USER32
0xC002 ObjectLink
0xC003 OwnerLink
0xC004 Native
0xC005 Binary

/.../

0xC846 TEdit
0xC848 TWindowDisabler-Window
0xC849 MsoCommandBarDock
0xC84A DropShadow
0xC84C vsdebugeng.impl.a957346c-96da-4d42-f4c9-fe477ac36867
--- 1,994 strings found
```

#### Example output (with `-b` switch):

```
USER32
ObjectLink
OwnerLink
Native
Binary

/.../

TEdit
TWindowDisabler-Window
MsoCommandBarDock
DropShadow
vsdebugeng.impl.a957346c-96da-4d42-f4c9-fe477ac36867
```
