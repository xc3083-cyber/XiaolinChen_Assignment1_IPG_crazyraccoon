using System;
using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace IPG.ContentPipeline;

[ContentImporter(".png", DisplayName = "Texture Importer - Relative Path", DefaultProcessor = "TextureProcessor")]
public sealed class RelativeTextureImporter : TextureImporter
{
    public override TextureContent Import(string filename, ContentImporterContext context)
    {
        // Avoid passing the non-ASCII parent directory to the native image loader.
        string importPath = OperatingSystem.IsWindows()
            ? Path.GetRelativePath(Directory.GetCurrentDirectory(), filename)
            : filename;

        TextureContent texture = base.Import(importPath, context);
        texture.Identity = new ContentIdentity(filename);
        return texture;
    }
}
