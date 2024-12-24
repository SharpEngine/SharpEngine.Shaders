using SharpEngine.Core;
using SharpEngine.Core.Manager;
using SharpEngine.Shaders.Shaders;

namespace Testing;

public class MyScene: Scene
{
    public MyScene()
    {
        AddEntity(new Entities.OutlineEntity());
    }

    public override void Update(float delta)
    {
        base.Update(delta);

        if(InputManager.IsKeyPressed(SharpEngine.Core.Input.Key.Z))
            ((OutlineShader)Window!.ShaderManager.GetShader("Outline")).OutlineSize += 0.1f;
        if (InputManager.IsKeyPressed(SharpEngine.Core.Input.Key.S))
            ((OutlineShader)Window!.ShaderManager.GetShader("Outline")).OutlineSize -= 0.1f;
    }

}