using SharpEngine.Core;
using SharpEngine.Core.Manager;
using SharpEngine.Core.Math;
using SharpEngine.Core.Utils;
using SharpEngine.Shaders;
using SharpEngine.Shaders.Shaders;

namespace Testing;

internal static class Program
{
    private static void Main()
    {
        SEShaders.AddVersions();
        
        var window = new Window(1280, 920, "SE Shaders", Color.CornflowerBlue, null, true, true, true);

        window.TextureManager.AddTexture("Outline", "Resource/Food.png");

        var shader = new OutlineShader
        {
            TextureSize = new Vec2(30, 29),
            OutlineSize = 1f,
            OutlineColor = Color.Red
        };

        window.ShaderManager.AddShader("Outline", shader);

        window.AddScene(new MyScene());

        window.Run();
    }
}