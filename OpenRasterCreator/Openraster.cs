using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace OpenRasterCreator
{
    class Openraster :OpenRasterNodeParent
    {
        public static int CountOfLayers { get; }


        public void BuildFile()
        {
            using (FileStream zipToOpen = new FileStream(@"output.zip", FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    var layers = GetLayers();
                    SetLayerIds(layers);
                    Bitmap megrgedImage = layers[0].Bitmap;

                    Height = megrgedImage.Height;
                    Wigth = megrgedImage.Width;

                    WriteStackXML(archive);
                    WriteMietype(archive);

   
                    WriteImage(archive, megrgedImage, @"mergedimage.png");

                    Bitmap imageThumbnail = new Bitmap(megrgedImage, new Size(256, 192));
                    WriteImage(archive, imageThumbnail, @"Thumbnails/thumbnail.png");

                    for (int i = 0; i < layers.Count; i++)
                    {
                        WriteImage(archive, layers[i].Bitmap, $"data/layer{layers[i].Id}.png");
                    }
                }
            }
        }

      

        public static void WriteImage(ZipArchive archive, Bitmap bitmap, string entryName)
        {
            ZipArchiveEntry readmeEntry = archive.CreateEntry(entryName);
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                using (var entryStream = readmeEntry.Open())
                {
                    var bytes = stream.ToArray();
                    entryStream.Write(bytes, 0, bytes.Length);
                }
            }
        }

 
        private static void SetLayerIds(List<Layer> layers)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                layers[i].Id = i;
            }
        }

        private static void WriteMietype(ZipArchive archive)
        {
            ZipArchiveEntry readmeEntry2 = archive.CreateEntry(@"mimetype");
            using (StreamWriter writer = new StreamWriter(readmeEntry2.Open()))
            {
                writer.WriteLine("image/openraster");
            }
        }

        private void WriteStackXML(ZipArchive archive)
        {
            ZipArchiveEntry readmeEntry = archive.CreateEntry(@"stack.xml");
            string xml = ToXml().ToString().Replace($"<?xml version=\"1.0\" encoding=\"utf - 8\"?>", "");

            using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
            {
                writer.Write(xml);
            }
        }

        public override XElement ToXml()
        {
            var root = new LayerFolder("root");
            root.nodes = nodes;

            XElement xmlElement = new XElement("image",
                new XAttribute("w", Wigth),
                new XAttribute("h", Height),
                new XAttribute("version", "0.0.1"),
                new XAttribute("xres", 300),
                new XAttribute("yres", 300),
                root.ToXml());
            return xmlElement;
        }

        public override List<Layer> GetLayers()
        {
            List<Layer> layers =new List<Layer>();
            foreach (var openRasterNode in nodes)
            {
                layers.AddRange(openRasterNode.GetLayers());
            }

            return layers;
        }

        public object Height { get; set; }

        public object Wigth { get; set; }
    }
}
