using SharpEngine.Core.Component;
using SharpEngine.Core.Entity;
using SharpEngine.Core.Math;
using SharpEngine.Core.Utils;
using SharpEngine.Shaders.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Entities
{
    internal class OutlineEntity: Entity
    {
        public OutlineEntity()
        {
            AddComponent(new TransformComponent(new Vec2(200), new Vec2(4)));
            AddComponent(new SpriteComponent("Outline", shader: "Outline"));
        }
    }
}
