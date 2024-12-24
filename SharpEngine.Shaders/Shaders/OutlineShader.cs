using System.Numerics;
using Raylib_cs;
using SharpEngine.Core.Math;
using Color = SharpEngine.Core.Utils.Color;

namespace SharpEngine.Shaders.Shaders;

/// <summary>
/// Class which represents Outline shader
/// </summary>
public static class OutlineShader
{
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

    /// <summary>
    /// Get Loaded Outline Shader
    /// </summary>
    /// <returns>Loaded Shader</returns>
    public static Shader GetShader() => Raylib.LoadShaderFromMemory("", FragmentShader);

    /// <summary>
    /// Define Texture Size for Outline Shader
    /// </summary>
    /// <param name="shader">Outline Shader</param>
    /// <param name="size">Texture Size</param>
    public static void SetTextureSize(this Shader shader, Vec2 size) =>
        Raylib.SetShaderValue(shader, Raylib.GetShaderLocation(shader, "textureSize"), (Vector2)size,
            ShaderUniformDataType.Vec2);

    /// <summary>
    /// Define Outline Size for Outline Shader
    /// </summary>
    /// <param name="shader">Outline Shader</param>
    /// <param name="size">Outline Size</param>
    public static void SetOutlineSize(this Shader shader, float size) =>
        Raylib.SetShaderValue(shader, Raylib.GetShaderLocation(shader, "outlineSize"), size,
            ShaderUniformDataType.Float);

    /// <summary>
    /// Define Outline Color for Outline Shader
    /// </summary>
    /// <param name="shader">Outline Shader</param>
    /// <param name="color">Outline Color</param>
    public static void SetOutlineColor(this Shader shader, Color color) =>
        Raylib.SetShaderValue(shader, Raylib.GetShaderLocation(shader, "outlineColor"), color.ToVec4(),
            ShaderUniformDataType.Vec4);

}