using SharpEngine.Core.Manager;
using SharpEngine.Core.Math;

namespace SharpEngine.Shaders;

/// <summary>
/// Static class with extensions and add version functions
/// </summary>
public static class SEShaders
{
    /// <summary>
    /// Add versions to DebugManager
    /// </summary>
    public static void AddVersions()
    {
        DebugManager.Versions.Add("SharpEngine.Shaders", "1.0.0");
    }
}