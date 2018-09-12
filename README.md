# .NET Assembly Information

This application was originally hosted on Codeplex and discontinued (https://archive.codeplex.com/?p=assemblyinformation).
I attempted to bring it on to github with a fully downloadable and installable release while also converting the shell extension from using C++ to using a C# lib that will enable to do that for me. 

I used the following libs and plugins:
- [SharpShell](https://github.com/dwmkerr/sharpshell)
- [Visual Studio 2017 Installer Project](https://marketplace.visualstudio.com/items?itemName=VisualStudioClient.MicrosoftVisualStudio2017InstallerProjects)

Display .NET Assembly information like:

1. Compilation mode (Debug/Release)
2. .NET Assembly full name
3. .NET Assembly references (even recursively)

## License

.NET Assembly Information source code is license under [Microsoft Public License (Ms-PL)](LICENSE.txt)