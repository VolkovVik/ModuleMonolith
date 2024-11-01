using System.Reflection;

namespace ModuleMonolith.Modules.Users.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
