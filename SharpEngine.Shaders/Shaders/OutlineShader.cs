using System.Drawing;
using System.Numerics;
using Raylib_cs;
using SharpEngine.Core.Manager;
using SharpEngine.Core.Math;
using SharpEngine.Core.Utils;
using Color = SharpEngine.Core.Utils.Color;

namespace SharpEngine.Shaders.Shaders;

/// <summary>
/// Class which represents Outline shader
/// </summary>
public class OutlineShader: SEShader
{
    /// <summary>
    /// Size of texture in shader
    /// </summary>
    public Vec2 TextureSize
    {
        get => _textureSize;
        set
        {
            _textureSize = value;
            Raylib.SetShaderValue(internalShader, Raylib.GetShaderLocation(internalShader, "textureSize"), (Vector2)value,
                ShaderUniformDataType.Vec2);
        }
    }

    /// <summary>
    /// Size of outline in shader
    /// </summary>
    public float OutlineSize
    {
        get => _outlineSize;
        set
        {
            _outlineSize = value;
            Raylib.SetShaderValue(internalShader, Raylib.GetShaderLocation(internalShader, "outlineSize"), value,
                ShaderUniformDataType.Float);
        }
    }

    /// <summary>
    /// Color of outline in shader
    /// </summary>
    public Color OutlineColor
    {
        get => _outlineColor;
        set
        {
            _outlineColor = value;
            Raylib.SetShaderValue(internalShader, Raylib.GetShaderLocation(internalShader, "outlineColor"), value.ToVec4(),
                ShaderUniformDataType.Vec4);
        }
    }

    private Vec2 _textureSize;
    private float _outlineSize;
    private Color _outlineColor;

    /// <summary>
    /// Create Outline Shader
    /// </summary>
    public OutlineShader(): base(null, FragmentShader) { }


    private const string FragmentShader = """

                                           #version 330

                                           in vec2 fragTexCoord;
                                           in vec4 fragColor;

                                           uniform sampler2D texture0;
                                           uniform vec4 colDiffuse;
                                           uniform vec2 textureSize;
                                           uniform float outlineSize;
                                           uniform vec4 outlineColor;

                                           out vec4 finalColor;

                                           void main() {
                                               vec4 texel = texture(texture0, fragTexCoord);
                                               vec2 texelScale = vec2(0, 0);
                                               texelScale.x = outlineSize / textureSize.x;
                                               texelScale.y = outlineSize / textureSize.y;
                                           
                                               vec4 corners = vec4(0.0);
                                               corners.x = texture(texture0, fragTexCoord + vec2(texelScale.x, texelScale.y)).a;
                                               corners.y = texture(texture0, fragTexCoord + vec2(texelScale.x, -texelScale.y)).a;
                                               corners.z = texture(texture0, fragTexCoord + vec2(-texelScale.x, texelScale.y)).a;
                                               corners.w = texture(texture0, fragTexCoord + vec2(-texelScale.x, -texelScale.y)).a;
                                           
                                               float outline = min(dot(corners, vec4(1.0)), 1.0);
                                               vec4 color = mix(vec4(0.0), outlineColor, outline);
                                               finalColor = mix(color, texel, texel.a);
                                           }
                                           """;

}