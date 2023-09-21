WriteLine($"There are {args.Length} arguments.");
foreach (string arg in args)
{
    WriteLine( arg );
}
if  ( args.Length < 3 )
{
    WriteLine("You must specify two colors and cursor size, e.g.");
    WriteLine("dotnet run red yellow 50");
    return;
}
ForegroundColor = (ConsoleColor)Enum.Parse(
      enumType: typeof(ConsoleColor),
      value: args[0],
      ignoreCase: true
  );
BackgroundColor = (ConsoleColor)Enum.Parse(
    enumType: typeof(ConsoleColor),
    value: args[1],
    ignoreCase: true
);
try
{
    CursorSize = int.Parse(args[2]);
}
catch (PlatformNotSupportedException)
{
    WriteLine("The current platform does not support changing the size of the cursor.");
}

if (OperatingSystem.IsWindows())
{
    WriteLine("execute code that only works on Windows");
}
else if (OperatingSystem.IsWindowsVersionAtLeast(major: 10))
{
   WriteLine("execute code that only works on Windows 10 or later");
}
else if (OperatingSystem.IsIOSVersionAtLeast(major: 14, minor: 5))
{
   WriteLine("execute code that only works on iOS 14.5 or later");
}
else if (OperatingSystem.IsBrowser())
{
   WriteLine("execute code that only works in the browser with Blazor");
}

#if NET7_0_ANDROID
Write("compile statements that only works on Android");
#elif NET7_0_IOS
Write("compile statements that only works on iOS");
#else
WriteLine("compile statements that work everywhere else");
#endif