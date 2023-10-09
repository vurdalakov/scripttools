## RegisteredWindowMessages.csx

Lists windows messages that were registered with [RegisterWindowMessageA()](https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerwindowmessagea) and
[RegisterWindowMessageW()](https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerwindowmessagew) functions.

| Switch | Long switch                     | Description                                                                                                         |
| ------ | ------------------------------- | ------------------------------------------------------------------------------------------------------------------- |
| -b     | --bare                          | Displays a bare list of message names, with no message identifiers and totals.                                      |

#### Source code

* [RegisteredWindowMessages.csx](RegisteredWindowMessages.csx)

#### Usage

```
RegisteredWindowMessages.csx <-b>
```

#### Example output (with no switch)

```
RegisteredWindowMessages.csx
```

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

#### Example output (with `-b` switch)

```
RegisteredWindowMessages.csx -b
```

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
