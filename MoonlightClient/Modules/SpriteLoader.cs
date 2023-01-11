using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Moonlight_Client.Modules
{
    public static class SpriteLoader
    {
        internal static System.Drawing.Image GetImageFromResources(string imageName)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string[] manifestResourceNames = executingAssembly.GetManifestResourceNames();
            string[] array = manifestResourceNames;
            foreach (string text in array)
            {
                if (text.EndsWith(".png") && text.Contains(imageName))
                {
                    Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(text);
                    MemoryStream memoryStream = new MemoryStream();
                    manifestResourceStream.CopyTo(memoryStream);
                    return System.Drawing.Image.FromStream(memoryStream);
                }
            }
            return null;
        }

        internal static Sprite MakeSpriteFromImage(System.Drawing.Image image)
        {
            if (image == null)
            {
                return null;
            }
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            Texture2D texture2D = new Texture2D(1024, 1024);
            Sprite result;
            if (!ImageConversion.LoadImage(texture2D, memoryStream.ToArray()))
            {
                result = null;
            }
            else
            {
                Sprite sprite = Sprite.CreateSprite(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(texture2D.width / 2, texture2D.height / 2), 100000f, 1000u, SpriteMeshType.FullRect, default(Vector4), generateFallbackPhysicsShape: false);
                result = sprite;
            }
            return result;
        }
    }
}
