// See https://aka.ms/new-console-template for more information
// #error version

using System.Reflection;

Assembly? myApp = Assembly.GetEntryAssembly();
if (myApp == null) return;

foreach (AssemblyName name in myApp.GetReferencedAssemblies())
{
    Assembly a = Assembly.Load(name);
    int methodCount = 0;
    foreach (TypeInfo t in a.DefinedTypes)
    {
        methodCount += t.GetMethods().Count();
    }
    Console.WriteLine(
        "{0:N0} types with {1:N0} methods in {2} asembly.",
        arg0: a.DefinedTypes.Count(),
        arg1: methodCount,
        arg2: name.Name);
}
