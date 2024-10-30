using System.Reflection;

namespace ModuleMonolith.Modules.Codes.Presentation;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
