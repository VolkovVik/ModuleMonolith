using System.Reflection;
using Carter;

namespace ModuleMonolith.Common.Presentation.Endpoins;

public class DependencyContextAssemblyCatalogCustom(params Assembly[] assemblies) : DependencyContextAssemblyCatalog
{
    public override IReadOnlyCollection<Assembly> GetAssemblies() => assemblies;
}

