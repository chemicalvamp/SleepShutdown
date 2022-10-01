# SleepShutdown

Usage, Make a shortcut, You can add arguments to the shortcut's target text box,

SleepShutdown.exe decimalHoursToIdle stringDirectoryToWatch

if the directory path has any spaces in it, You must put it in quotes, Here are some exmaples:

SleepShutdown.exe 1.0 F:\SteamLibrary\steamapps

Will shutdown the computer 1 hour after there has been no activity in F:\SteamLibrary\steamapps (and its subfolders) or any keyboard/mouse input.

SleepShutdown.exe 0.25 "C:\Program Files (x86)\Steam\steamapps"

Will shutdown the computer 15 minutes after there has been no activity in "C:\Program Files (x86)\Steam\steamapps" notice the quotes, they are needed because of the spaces in "Program Files (x86)".

I recommend making a shortcut with your time and directory of choice at the end of the target box, But you don't need to!
If you just open it someplace, it will monitor the directory it's in (and it's subfolders) and shutdown after it has seen no activity for 1 hour.

Remember its watching the keyboard and mouse as well, the slightest mouse nudge will restart the timer. 
