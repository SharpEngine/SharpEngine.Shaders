using SharpEngine.Core;
using SharpEngine.Core.Manager;
using SharpEngine.Core.Utils;
using SharpEngine.Shaders;

namespace Testing;

internal static class Program
{
    private static void Main()
    {
        SEShaders.AddVersions();
        
        var window = new Window(1280, 920, "SE Shaders", Color.CornflowerBlue, null, true, true, true)
        {
            RenderImGui = DebugManager.CreateSeImGuiWindow
        };
        
        window.AddScene(new MyScene());
        
        window.Run();
    }
}