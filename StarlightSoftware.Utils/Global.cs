global using System;
global using JetBrains.Annotations;

namespace StarlightSoftware.Utils;

#pragma warning disable ET001 // Type name does not match file name
/// <summary>
/// Used as a flag for this assembly, e.g. for type scanning.
/// </summary>
[PublicAPI]
public record StarlightUtilsAssemblyMarker;
#pragma warning restore ET001 // Type name does not match file name