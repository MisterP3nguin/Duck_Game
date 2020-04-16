using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Duck_Game.UI;
using Duck_Game.Entities;

namespace Duck_Game
{
    public class Scene : IDisposable
    {
        public List<Sprite> sprites = new List<Sprite>();
        public UIManager uiManager;
        public Scene(string sceneName,Input input)
        {
            Load(sceneName,input);
        }
        public void Update(GameTime gameTime)
        {
            uiManager.Update(gameTime);
            foreach(Sprite sprite in sprites)
            {
                sprite.Update(gameTime);
            }
        }
        public void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            uiManager.Draw(gameTime,spriteBatch);
            foreach (Sprite sprite in sprites)
            {
                sprite.Draw(gameTime, spriteBatch);
            }
        }
        public void Load(string sceneName ,Input input)
        {
            switch(sceneName)
            {
                case "main_menu":
                    uiManager = UIGenerator.CreateMainMenu(input);
                    break;
                case "game":
                    uiManager = UIGenerator.CreateGameMenu(input);
                    break;
                default:
                    throw new Exception("Specified Scene does not exist. Add new case to Scene.Load");
            }
        }
        public void Save()
        {

        }
        void Compress(FileInfo fileToCompress)
        {
            using (FileStream originalFileStream = fileToCompress.OpenRead())
            {
                if ((File.GetAttributes(fileToCompress.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                {
                    using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                    using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressionStream);
                    }
                }
            }
        }
        void Decompress(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }
            }
        }
        public void Dispose()
        {
            uiManager.Dispose();
        }
    }
}
